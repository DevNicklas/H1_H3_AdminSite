using AdminSite.DataAccess;
using AdminSite.DataAccess.Product;
using AdminSite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace AdminSite.Pages
{
    public class NewProductModel : PageModel
    {
        private string _productName;
        private int _quantity;
        private decimal _price;
        private int _category;
        private string _description;
        private List<string[]> _categories = new List<string[]>();

        [BindProperty]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [BindProperty]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        [BindProperty]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [BindProperty]
        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        [BindProperty]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public List<string[]> Categories
        {
            get { return _categories; }
            private set { _categories = value; }
        }

        public void OnGet()
        {
            GetAllCategories(new DatabaseAction(UtilityConstants.CONNECTION_STRING));
        }

        private void GetAllCategories(DatabaseAction databaseAction)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>{};
            List<string[]> options = new List<string[]>();

            foreach (DataRow Row in databaseAction.GetData(Utils.Procedures.GetAllCategoriesWithID, parameters).Rows)
            {
                options.Add(new string[2] { Row["ID"].ToString(), Row["Name"].ToString() });
            }
            Categories = options;
        }

        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                DatabaseAction dbAction = new DatabaseAction(UtilityConstants.CONNECTION_STRING);
                Product product = new Product(ProductName, Quantity, Price, Category, Description);
                product.Create(dbAction);
            }
        }
    }
}
