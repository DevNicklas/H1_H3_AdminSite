using AdminSite.DataAccess;
using AdminSite.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSite.Category
{
    /// <summary>
    /// 
    /// </summary>
    public class Category : ICategory, IStandardActions
    {
        private int _id;
        private string _name;

        public Category(DataTable catData)
        {
            try
            {
                if (catData == null)
                {
                    throw new ArgumentNullException();
                }

                _name = catData.Rows[0]["Name"].ToString();
            }
            catch
            {
                throw;
            }
        }

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        // RemoveCategory
        public bool Create(DatabaseAction dbAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"@Name", Name }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }
        /* DOESN'T EXIST (SP)
        public bool Delete(DatabaseAction dbAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"@Name", Name }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        } */
        /* DOESN'T EXIST (SP)
        public bool Update(DatabaseAction dbAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"@Name", Name }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }*/

        // NewCategory

        // UpdateCategory
    }

}
