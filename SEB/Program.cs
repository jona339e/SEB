using SEB.GUI;

internal class Program
{
    static void Main(string[] args)
    {
        DisplayCategories displayCategories = new DisplayCategories();

        while (true)
        {
            Console.WriteLine("My Grocer");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Press 1 to start making an order!");
            Console.WriteLine("Press 2 to view all orders!");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    {
                        displayCategories.DisplayGrocerCategories();
                        // method call to display list of groceries
                        break;
                    }
                case 2:
                    {
                        // display all orders
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Wrong Input try again!");
                        break;
                    }
            }
        }


    }
}