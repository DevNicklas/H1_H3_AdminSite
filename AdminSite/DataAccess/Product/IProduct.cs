using System.Drawing;

namespace AdminSite.DataAccess.Product
{
    public interface IProduct
    {
        public int ProductId { get; }
        public int Category { get; }
        public int Quantity { get; }
        public string Name { get; }
        public decimal Price { get; }
        public Image Img { get; }
        public string Description { get; }

    }
}