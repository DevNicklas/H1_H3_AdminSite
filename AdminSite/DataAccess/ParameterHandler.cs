namespace AdminSite.DataAccess
{
    /// <summary>
    /// <c>UserParameters</c> handles paramters.
    /// </summary>
    public class ParamterHandler
    {
        /// <summary>
        /// Convert input from a form to a dictionary<br/>
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Dictionary with username and password</returns>
        protected static Dictionary<string, string> GetParameters(IFormCollection form)
        {
            return form.ToDictionary(input => input.Key.ToString(), input => input.Value.ToString());
        }
    }
}