using AdminSite.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSite.Category
{
    /// <summary>
    /// <c>ICategory</c> defines a contract for classes that model categories.
    /// </summary>
    public interface ICategory
    {
        public int Id { get; }
        public string Name { get; }
    }
}
