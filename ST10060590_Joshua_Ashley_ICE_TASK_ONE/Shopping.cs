using System.Collections;

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
        private string name;
        private double price;
        private ProductCategory category;

        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public ProductCategory Category { get { return category; } }

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
        //global variables that have been changed to exclude readonly as the program would not work
        private Product[] products;
        private int itemCount;


        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;

            PopulateProduct();
            DisplayDetails();
        }

        public void PopulateProduct()
        {
            //standard product variables
            string name;
            double price;
            ProductCategory category;

            //clothing product variables
            string size;
            string colour;

            //electronic product variables
            string brand;
            string model;

            ArrayList tempArr = new ArrayList();

            Console.WriteLine("Please add the products.");
            while (itemCount < products.Length)
            {
                Console.Write("Please enter a new product name: ");
                name = Console.ReadLine();

                Console.Write("Please enter the price of " + name + ": ");
                price = double.Parse(Console.ReadLine());

                Console.WriteLine("Please choose the category of " + name + ": \n" +
                    "1. Clothing\n" +
                    "2. Electronics\n" +
                    "3. Home\n" +
                    "4. Beauty\n" +
                    "5. Groceries");
                category = DetermineCategory(int.Parse(Console.ReadLine()));

                AddProduct(new Product(name, price, category));
            }
        }

        public ProductCategory DetermineCategory(int decision)
        {
            ProductCategory category = ProductCategory.Clothing;

            if (decision == 2)
            {
                category = ProductCategory.Electronics;
            }
            else if (decision == 3)
            {
                category = ProductCategory.Home;
            }
            else if (decision == 4)
            {
                category = ProductCategory.Beauty;
            }
            else if (decision == 5)
            {
                category = ProductCategory.Groceries;
            }

            return category;
        }

        public void AddProduct(Product product)
        {

            if (itemCount < products.Length)
            {
                products[itemCount] = product;
                itemCount++;
            }
            else
            {
                Console.WriteLine("Shopping cart is full.");
            }
        }

        public Product SearchProduct(string searchName)
        {
            foreach (Product product in products)
            {
                if (product != null && product.Name.ToLower() == searchName.ToLower())
                {
                    return product;
                }
            }
            return null;
        }

        public void RemoveProduct(Product product)
        {
            int indexToRemove = -1;
            for (int i = 0; i < itemCount; i++)
            {
                if (products[i] == product)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove == -1)
            {
                Console.WriteLine("Product not found in shopping cart.");
                return;
            }

            // Create a new temporary array to remove the product from the shopping cart
            Product[] tempArray = new Product[itemCount - 1];
            int tempIndex = 0;
            for (int i = 0; i < itemCount; i++)
            {
                if (i == indexToRemove)
                {
                    continue;
                }
                tempArray[tempIndex] = products[i];
                tempIndex++;
            }

            // Replace the shopping cart array with the temporary array
            products = tempArray;
            itemCount--;
        }



        public void DisplayDetails()
        {
            Console.WriteLine("PRODUCTS:");
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Category == ProductCategory.Clothing)
                {

                }
                else if (products[i].Category == ProductCategory.Electronics)
                {

                }
                else
                {
                    products[i].GetInfo();
                    Console.WriteLine();
                }

            }
        }
    }
}
