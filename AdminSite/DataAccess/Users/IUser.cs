using AdminSite.Utils;
using System.Data;

namespace AdminSite.DataAccess.Users
{
    public interface IUser
    {
        public string UserId { get; }
        public string UserName { get; }
        public string EnteredPassword { get; }
        public Roles UserRole { get; }
        public bool NewUser();
        public bool RemoveUser();
        public bool UpdateUser();
    }
}