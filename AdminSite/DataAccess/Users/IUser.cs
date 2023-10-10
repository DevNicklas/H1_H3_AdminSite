using AdminSite.Utils;

namespace AdminSite.DataAccess.Users
{
    /// <summary>
    /// <c>IUser</c> defines a contract for classes which defindes a user.
    /// </summary>
    public interface IUser
    {
        public string UserId { get; }
        public string UserName { get; }
        public string EnteredPassword { get; }
        public Roles UserRole { get; }
    }
}