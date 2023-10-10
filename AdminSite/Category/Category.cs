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
                    { "@Name", Name }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(DatabaseAction dbAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@ID", Id.ToString() }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        } 

        public bool Update(DatabaseAction dbAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@ID", Id.ToString() },
                    { "@Name", Name }
                };

                dbAction.GetData(Procedures.CreateNewCategory, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }

}
