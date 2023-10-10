using AdminSite.Utils;
using System.Data;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace AdminSite.DataAccess.Users
{
    /// <summary>
    /// <c>User</c> models a user.
    /// </summary>
    public class User : UserParameters, IUser
    {
        private string _userId;
        private string _username;
        private Roles _userRole;
        private string? _enteredPassword;

        public User(string username, string enteredPassword) : base(UtilityConstants.CONNECTION_STRING, GetParameters(username, enteredPassword))
        {
            try
            {
                DataTable UserData = GetData();
                _userId = UserData.Rows[0]["ID"].ToString();
                _userRole = (Roles)Enum.Parse(typeof(Roles), UserData.Rows[0]["Role"].ToString());
                _username = username;
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
                return _username;
            }
            private set
            {
                _username = value;
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
        public bool NewUser()
        {
            try
            {
                Procedure = Procedures.InsertNewUser;
                Parameters = new Dictionary<string, string>
                {
                    { "@Role_ID", Convert.ToString((byte)this.UserRole) },
                    { "@Username", UserName },
                    { "@PasswordHash", EnteredPassword }, //todo hash
                    { "@PasswordSalt", EnteredPassword } //todo salt
                };
                GetData();
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
        public bool RemoveUser()
        {
            try
            {
                Procedure = Procedures.DeleteUser;
                Parameters = new Dictionary<string, string>
                {
                    { "@IS", UserId }
                };
                GetData();
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
        public bool UpdateUser()
        {
            try
            {
                Procedure = Procedures.UpdateUser;
                Parameters = new Dictionary<string, string>
                {
                    { "@Role_ID", Convert.ToString((byte)this.UserRole) },
                    { "@Username", UserName },
                    { "@PasswordHash", EnteredPassword }, //todo hash
                    { "@PasswordSalt", EnteredPassword } //todo salt
                };
                GetData();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}