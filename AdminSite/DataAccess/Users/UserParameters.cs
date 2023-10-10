namespace AdminSite.DataAccess.Users
{
    /// <summary>
    /// <c>UserParameters</c> makes GetParameter available to Current User and User<br/>
    /// </summary>
    public abstract class UserParameters : DatabaseAction
    {
        protected UserParameters(string connectionString, Dictionary<string, string> parameters) : base(connectionString, parameters)
        {
        }

        /// <summary>
        /// Generate a new dictionary from username and entered password.<br/>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>username and password Dictionary</returns>
        protected Dictionary<string, string> GetParameters(string username, string password)
        {
            return new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };
        }
    }
}