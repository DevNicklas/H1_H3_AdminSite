using AdminSite.Utils;
using System.Data;
using System.Data.SqlClient;

namespace AdminSite.DataAccess
{
    /// <summary>
    /// <c>DatabaseAction</c> is an abstract class for executing database operations.
    /// </summary>
    public abstract class DatabaseAction : IDatabaseAction
    {
        protected DataTable _value;
        protected string _connectionString;
        protected Procedures _procedure;
        protected Dictionary<string, string> _parameters;

        /// <summary>
        /// Initializes a DatabaseAction instance with a connection string and optional parameters. <br/>
        /// If the connection string is null or empty, an ArgumentNullException is thrown.
        /// </summary>
        /// <param name="connectionString">The connection string to the database.</param>
        /// <param name="parameters">Optional dictionary of parameters for database operations.</param>
        /// <exception cref="ArgumentNullException">Thrown if the connection string is null or empty.</exception>
        private DatabaseAction(string connectionString, Dictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                throw new ArgumentNullException();
            }
            else
            {
                _connectionString = connectionString;
            }
            if (parameters == null)
            {
                _parameters = new Dictionary<string, string>();
            }
            else
            {
                _parameters = parameters;
            }
            _value = GetData();
        }

        /// <summary>
        /// A datatable containing the data from the database.
        /// </summary>
        public DataTable Value
        {
            get
            {
                return _value;
            }
            protected set
            {
                _value = value;
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
        /// The procedures to be executed in the database.
        /// </summary>
        public Procedures Procedure
        {
            get
            {
                return _procedure;
            }
            protected set
            {
                _procedure = value;
            }
        }

        /// <summary>
        /// The parameters to be passed with the procedure to the database.
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get
            {
                return _parameters;
            }
            protected set
            {
                _parameters = value;
            }
        }

        /// <summary>
        /// Get data from the database.
        /// </summary>
        /// <returns>data table with data from the database</returns>
        public DataTable GetData()
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString)) //instanciate the connection to the database.
            {
                using (SqlCommand command = new SqlCommand(Procedure.ToString(), connection)) //instanciate the command to send to the database.
                {
                    foreach (KeyValuePair<string,string> arg in Parameters) //for each key value pair in Parameters (We've technically used to use 'var' here, but KeyValuePair is more accuarate.
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