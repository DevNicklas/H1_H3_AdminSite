using AdminSite.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSite.Category
{
    public interface ICategory
    {
        public int Id { get; }
        public string Name { get; }
    }
}
