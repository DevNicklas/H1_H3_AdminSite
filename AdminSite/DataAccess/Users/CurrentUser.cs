using AdminSite.DataAccess;
using AdminSite.DataAccess.Users;
using System.Security.Cryptography;

public class CurrentUser : UserParameters
{
    public User user;

    public CurrentUser(string username, string password, string connectionString) : base(connectionString, GetParameters(username, password))
    {
    }
}