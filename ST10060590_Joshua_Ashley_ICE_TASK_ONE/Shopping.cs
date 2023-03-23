namespace ShoppingCartApp
{
    public enum ProductCategory
    {
        Clothing,
        Electronics,
        Home,
        Beauty,
        Groceries
    }

    public class Product
    {
        private string name { get { return name; } set { name = value; } }
        private double price { get { return price; } set { price = value; } }
        private ProductCategory category { get; set; }

        public Product(string name, double price, ProductCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine("Product name: " + name + "\nProduct Price: " + String.Format("{0:0.0#}", price) + "\nProduct Category: " + category);
        }
    }

    public class ClothingProduct : Product
    {
        private readonly string size;
        private readonly string color;

        public ClothingProduct(string size, string color, string name, double price, ProductCategory category) : base(name, price, category)
        {
            this.size = size;
            this.color = color;
        }

        public override void GetInfo()
        {
            Console.WriteLine("Clothing Product\n" +
                "===============================");

            base.GetInfo();
            Console.WriteLine("Product size: " + size + "\nProduct color: " + color);
        }
    }

    public class ElectronicProduct : Product
    {
        private readonly string brand;
        private readonly string model;

        public ElectronicProduct(string brand, string model, string name, double price, ProductCategory category) : base(name, price, category)
        {
            this.brand = brand;
            this.model = model;
        }

        public override void GetInfo()
        {
            Console.WriteLine("Electronic Product\n" +
                "===============================");
            base.GetInfo();
            Console.WriteLine("Product brand: " + brand + "\nProduct model: " + model);
        }
    }

    public class ShoppingCart
    {
        private readonly Product[] products;
        private readonly int itemCount;


        public ShoppingCart(int capacity)
        {

        }

        public void AddProduct(Product product, int currentItemCount)
        {

        }

        public void RemoveProduct(Product product, int position)
        {

        }
    }
}