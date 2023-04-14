using ShoppingCartApp;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the store. Please specify the maximum capacity of the shopping cart.");
            int capactiy = int.Parse(Console.ReadLine());
            ShoppingCart shop = new ShoppingCart(capactiy);
        }
    }


}
