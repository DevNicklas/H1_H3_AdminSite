using AdminSite.DataAccess;
using AdminSite.DataAccess.Users;
using AdminSite.Utils;
using System.Data;

public class CurrentUser : IUser
{
	private string _userId;
	private string _userName;
	private Roles _userRole;

	public CurrentUser(DatabaseAction dbAction, string enteredPassword, string username)
	{
		try
		{
			DataTable UserData = new DataTable();
			UserData = ValidateUser(dbAction, enteredPassword, username);
			if (UserData.Rows.Count == 0)
			{
				throw new ArgumentNullException();
			}

			_userId = UserData.Rows[0]["ID"].ToString()!;
			_userRole = UserData.Rows[0]["Role_ID"].ToString()!.ToRole();
			_userName = username;
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

	private DataTable ValidateUser(DatabaseAction databaseAction, string username = "Admin", string enteredPassword = "AdminHash")
	{
		try
		{
			Dictionary<string, string> parameters = new Dictionary<string, string>
			{
				{ "@Username", username },
				{ "@Hash", enteredPassword }
			};
			return databaseAction.GetData(Procedures.ValidateUser, parameters);
		}
		catch
		{
			throw;
		}
	}
}