using System.Drawing;

namespace AdminSite.DataAccess.Product
{
    public interface IProduct
    {
        public int ProductId { get; }
        public byte Category { get; }
        public int Quantity { get; }
        public string Name { get; }
        public int Price { get; }
        public Image Img { get; }
        public string Description { get; }

    }
}