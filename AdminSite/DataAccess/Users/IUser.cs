using AdminSite.Utils;
using System.Data;

namespace AdminSite.DataAccess.Users
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUser
    {
        public string UserId { get; }
        public string UserName { get; }
        public Roles UserRole { get; }
    }
}