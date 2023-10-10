using AdminSite.Utils;
using System.Data;
using System.Data.SqlClient;

namespace AdminSite.DataAccess
{
    /// <summary>
    /// <c>DatabaseAction</c> is an abstract class for executing database operations.
    /// </summary>
    public class DatabaseAction : IDatabaseAction
    {
        protected string _connectionString;

        /// <summary>
        /// Initializes a DatabaseAction instance with a connection string and optional parameters. <br/>
        /// If the connection string is null or empty, an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="parameters">Optional dictionary of parameters for database operations.</param>
        /// <exception cref="ArgumentNullException">Thrown if the connection string is null or empty.</exception>
        protected DatabaseAction(string connectionString, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ArgumentNullException();
            }
            else
            {
                _connectionString = connectionString;
            }
        }

        /// <summary>
        /// the connection string uesd to connect to the database.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            protected set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// Get data from the database.
        /// </summary>
        /// <returns>data table with data from the database</returns>
        public DataTable GetData(Procedures procedure, Dictionary<string, string> parameters)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString)) //instanciate the connection to the database.
            {
                using (SqlCommand command = new SqlCommand(procedure.ToString(), connection)) //instanciate the command to send to the database.
                {
                    foreach (KeyValuePair<string,string> arg in parameters) //for each key value pair in Parameters (We've technically used to use 'var' here, but KeyValuePair is more accuarate.
                    {
                        command.Parameters.AddWithValue(arg.Key, arg.Value); //add parameters to the SqlCommand's Parameters.
                    }
                    using (SqlDataReader reader = command.ExecuteReader()) //execute the command
                    {
                        data.Load(reader); //load the data from the connection into the reader
                    }
                }
            }
            return data;
        }
    }
}