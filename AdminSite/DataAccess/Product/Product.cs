using AdminSite.Utils;
using System.Drawing;

namespace AdminSite.DataAccess.Product
{
    /// <summary>
    /// <c>Product</c> models a product.
    /// </summary>
    public class Product : IProduct, IStandardActions
    {
        private int _productId;
        private byte _category;
        private int _quantity;
        private string _name;
        private int _price;
        private Image _img;
        private string _description;

        /// <summary>
        /// The ID of this product.
        /// </summary>
        public int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        /// <summary>
        /// The category of this product.
        /// </summary>
        public byte Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        /// <summary>
        /// The Stock of this product.
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        /// <summary>
        /// The name of this product.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// The price of this product.
        /// </summary>
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// An Image of this product.
        /// </summary>
        public Image Img
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
            }
        }

        /// <summary>
        /// A description of this product.
        /// </summary>
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// Create new Product.
        /// </summary>
        /// <param name="databaseAction"></param>
        /// <returns></returns>
        public bool Create(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"@Category", Category.ToString()},
                    {"@Quantity", Quantity.ToString()},
                    {"@Name", Name},
                    {"@Price", Price.ToString()},
                    {"@Description", Description.ToString()}
                };
                databaseAction.GetData(Procedures.InsertProduct, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="databaseAction"></param>
        /// <returns></returns>
        public bool Delete(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    {"@ID", ProductId.ToString() }
                };
                databaseAction.GetData(Procedures.DeleteProduct, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Product.
        /// </summary>
        /// <param name="databaseAction"></param>
        /// <returns></returns>
        public bool Update(DatabaseAction databaseAction)
        {
            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "@ID", ProductId.ToString() },
                    { "@Category", Category.ToString() },
                    { "@Quantity", Quantity.ToString() },
                    { "@Name", Name },
                    { "@Price", Price.ToString() },
                    { "@Description", Description }
                };
                databaseAction.GetData(Procedures.UpdateProduct, parameters);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}