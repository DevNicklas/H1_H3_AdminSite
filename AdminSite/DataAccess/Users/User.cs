using AdminSite.Utils;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace AdminSite.DataAccess.Users
{
    /// <summary>
    /// <c>User</c> models a user.
    /// </summary>
    public class User : IUser, IStandardActions
    {
        private string _userId;
        private string _userName;
        private Roles _userRole;
        private string? _enteredPassword;

        public User(string enteredPassword, DataTable UserData)
        {
            try
            {
                if(UserData == null)
                {
                    throw new ArgumentNullException();
                }

                _userId = UserData.Rows[0]["ID"].ToString();
                _userRole = UserData.Rows[0]["Role"].ToString().ToRole();
                _userName = UserData.Rows[0]["UserName"].ToString();
                _enteredPassword = enteredPassword;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The users userid.
        /// </summary>
        public string UserId
        {
            get
            {
                return _userId;
            }
            private set
            {
                _userId = value;
            }
        }

        /// <summary>
        /// The users chosen Username.
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            private set
            {
                _userName = value;
            }
        }

        /// <summary>
        /// The password which was entered for this user.
        /// </summary>
        public string EnteredPassword
        {
            get
            {
                return _enteredPassword;
            }
            private set
            {
                _enteredPassword = value;
            }
        }

        /// <summary>
        /// This users role.
        /// </summary>
        public Roles UserRole
        {
            get
            {
                return _userRole;
            }
            private set
            {
                _userRole = value;
            }
        }

        /// <summary>
        /// Create new User.
        /// </summary>
        /// <param name="Params"></param>
        /// <returns></returns>
        public bool Create(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@Role_ID", Convert.ToString((byte)this.UserRole) },
                    { "@Username", UserName },
                    { "@PasswordHash", EnteredPassword }, //todo hash
                    { "@PasswordSalt", EnteredPassword } //todo salt
                };
                databaseAction.GetData(Procedures.InsertNewUser, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Remove User.
        /// </summary>
        /// <param name="Params"></param>
        /// <returns></returns>
        public bool Delete(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@ID", UserId }
                };
                databaseAction.GetData(Procedures.DeleteUser, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update User.
        /// </summary>
        /// <param name="Params"></param>
        /// <returns></returns>
        public bool Update(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@Role_ID", Convert.ToString((byte)this.UserRole) },
                    { "@Username", UserName },
                    { "@PasswordHash", EnteredPassword }, //todo hash
                    { "@PasswordSalt", EnteredPassword } //todo salt
                };
                databaseAction.GetData(Procedures.UpdateUser,parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}