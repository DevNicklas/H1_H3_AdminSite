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
    /// The class <c>Category</c> represents an item Category eg. Helmet, Wheel etc. and their database values, id and name. 
    /// </summary>
    public class Category : ICategory, IStandardActions
    {
        private int _id;
        private string _name;

        public Category(string name)
        {
            _name = name;
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

        /// <summary>
        /// Creates a new category in the database.
        /// </summary>
        /// <param name="dbAction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deletes a category from the database.
        /// </summary>
        /// <param name="dbAction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates (changes) the values (name) of a category in the database.
        /// </summary>
        /// <param name="dbAction"></param>
        /// <returns></returns>
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
