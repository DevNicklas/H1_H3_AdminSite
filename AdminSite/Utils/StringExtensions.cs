namespace AdminSite.Utils
{
    public static class StringExtensions
    {
        public static Roles ToRole(this string value)
        {
            return (Roles)Enum.Parse(typeof(Roles), value);
        }
    }
}