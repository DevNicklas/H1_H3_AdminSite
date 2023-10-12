using AdminSite.DataAccess.Product;
using AdminSite.DataAccess;
using AdminSite.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using AdminSite;

namespace AdminSite.Pages
{
    /// <summary>
    /// <c>EditProductModel</c> controls the Edit Product Page.
    /// </summary>
    public class EditProductModel : PageModel
    {
        private List<string[]> _productName;
        private int _id;
        private int _quantity;
        private decimal _price;
        private int _category;
        private string _description;
        private List<string[]> _categories = new List<string[]>();

        Log log = new Log();
        DatabaseAction databaseAction = new DatabaseAction(UtilityConstants.CONNECTION_STRING);
        private bool delete;

        #region Properties
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

        [BindProperty]
        public bool Delete
        {
            get
            {
                return delete;
            }

            set
            {
                delete = value;
            }
        }
        
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
            try
            {
                GetAllProducts(databaseAction);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseAction"></param>
        private void GetAllProducts(DatabaseAction databaseAction)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string> { };
            List<string[]> options = new List<string[]>();

            foreach (DataRow Row in databaseAction.GetData(Utils.Procedures.GetAllProducts, parameters).Rows)
            {
                options.Add(new string[6] { Row["Product_ID"].ToString(), Row["Category"].ToString(), Row["Quantity"].ToString(), Row["Name"].ToString(), Row["Price"].ToString(), Row["Description"].ToString() });
            }
            Products = options;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnPost()
        {
            try
            {
                Product product = new Product(Convert.ToInt32(Request.Form["ProductName"]), Request.Form["ProductName"].ToString(), Quantity, Price, Category, Description);
                string deleteValue = Request.Form["Delete"];
                if (!string.IsNullOrEmpty(deleteValue))
                {
                    // Convert the checkbox value to a bool
                    Delete = deleteValue == "Delete";
                }

                if (Delete)
                {
                    product.Delete(databaseAction);
                }
                else
                {
                    product.Update(databaseAction);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
    }
}
