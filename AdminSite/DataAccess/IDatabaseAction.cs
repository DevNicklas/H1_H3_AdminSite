using AdminSite.Utils;
using System.Data;

/// <summary>
/// Defines a contract for classes that represent actions related to the database.
/// </summary>
public interface IDatabaseAction
{
    public DataTable Value { get; }
    public string ConnectionString { get; }
    public Procedures Procedure { get; }
    public Dictionary<string, string> Parameters { get; }
}