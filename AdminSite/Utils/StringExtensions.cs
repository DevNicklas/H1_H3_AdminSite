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
            try
            {
                return (Roles)Enum.Parse(typeof(Roles), value);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Value is null or empty! ", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Value is not a valid Roles enum value! ", ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Value is outside the valid range for enum Roles! ", ex);
            }
        }
    }
}