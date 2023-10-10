namespace AdminSite.Utils
{
    /// <summary>
    /// <c>stringExtensions</c> extends string with custom functions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// converts a string to the Roles enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Roles ToRole(this string value)
        {
            return (Roles)Enum.Parse(typeof(Roles), value);
        }
    }
}