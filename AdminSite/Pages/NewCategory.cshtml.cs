using AdminSite.DataAccess;
using AdminSite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace AdminSite.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class NewCategoryModel : PageModel
    {
        private string _categoryName;

        [BindProperty]
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnPost() 
        {
            if(ModelState.IsValid)
            {
                DatabaseAction dbAction = new DatabaseAction(UtilityConstants.CONNECTION_STRING);
                Category.Category category = new Category.Category(CategoryName);

                category.Create(dbAction);

                Debug.WriteLine("ITS'a WORKING " + CategoryName);
            }
        }
    }
}
