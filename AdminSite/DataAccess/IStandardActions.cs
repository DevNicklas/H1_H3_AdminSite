namespace AdminSite.DataAccess
{
    /// <summary>
    /// <i>IStandardAction</i> defines a contract for classes that represent standard actions related to the database.
    /// </summary>
    public interface IStandardActions
    {
        bool Create(DatabaseAction databaseAction);
        bool Delete(DatabaseAction databaseAction);
        bool Update(DatabaseAction databaseAction);
    }
}