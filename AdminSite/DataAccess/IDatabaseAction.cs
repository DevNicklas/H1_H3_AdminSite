using AdminSite.Utils;
using System.Data;

namespace AdminSite.DataAccess
{

    /// <summary>
    /// Defines a contract for classes that represent actions related to the database.
    /// </summary>
    public interface IDatabaseAction
    {
        public string ConnectionString { get; }
    }
}