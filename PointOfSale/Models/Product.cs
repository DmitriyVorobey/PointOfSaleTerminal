using PointOfSale.Calculators;

namespace PointOfSale.Models
{
    public class Product
    {
        public char Code { get; }
        public double Price { get; }

        public Product(char code, double price)
        {
            Code = code;
            Price = price;
        }
    }
}
