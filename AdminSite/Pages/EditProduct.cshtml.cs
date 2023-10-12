using AdminSite.DataAccess.Product;
using AdminSite.DataAccess;
using AdminSite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using AdminSite.Category;
using System.Xml.Linq;

namespace AdminSite.Pages
{
    public class EditProductModel : PageModel
    {
        private List<string[]> _productName;
        private int _quantity;
        private decimal _price;
        private int _category;
        private string _description;
        private List<string[]> _categories = new List<string[]>();

        [BindProperty]
        public List<string[]> Products
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
            GetAllProducts(new DatabaseAction(UtilityConstants.CONNECTION_STRING));
        }

        private void GetAllProducts(DatabaseAction databaseAction)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> { };
            List<string[]> options = new List<string[]>();

            foreach (DataRow Row in databaseAction.GetData(Utils.Procedures.GetAllProducts, parameters).Rows)
            {
                options.Add(new string[6] { Row["ID"].ToString(), Row["Category"].ToString(), Row["Quantity"].ToString(), Row["Name"].ToString(), Row["Price"].ToString(), Row["Description"].ToString() });
            }
            Products = options;
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product product = new Product(id, name, Quantity, Price, Category, Description);
                    if()
                }
                catch
                {

                }
            }
        }
    }
}
