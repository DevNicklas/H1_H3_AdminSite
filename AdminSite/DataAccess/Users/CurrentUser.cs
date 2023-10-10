using AdminSite.DataAccess;
using AdminSite.DataAccess.Users;
using AdminSite.Utils;
using System.Data;

public class CurrentUser : IUser
{
    private string _userId;
    private string _userName;
    private string _enteredPassword;
    private Roles _userRole;

    public CurrentUser(string enteredPassword, DataTable UserData)
    {
        try
        {
            if (UserData == null)
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

    public bool ValidateUser(DatabaseAction databaseAction)
    {
        try
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@Username", UserName },
                    { "@PasswordHash", EnteredPassword }, //todo hash
                    { "@PasswordSalt", EnteredPassword } //todo salt
                };
            databaseAction.GetData(Procedures.UpdateUser, parameters);
            return true;
        }
        catch
        {
            throw;
        }
    }
}