using SEB.Models;
using SEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.GUI
{
    internal class DisplayCategories
    {
        public void DisplayGrocerCategories()
        {
            bool exit = false;
            DisplayGroceries displayGroceries = new DisplayGroceries();
            ReadServices readServices = new ReadServices();
            List<Categories> categories = new();
            categories = readServices.GetCategories();

            while (!exit)
            {
                Console.WriteLine("Chose a category");
                Console.WriteLine("");
                foreach (var c in categories)
                {
                    Console.WriteLine($"{c.id} {c.CategoryName}");
                }

                // this is bad because it needs to be expanded if more categories are added

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            displayGroceries.DisplayGroceryProducts(categories[0].id);
                            break;
                        }

                    case 2:
                        {
                            displayGroceries.DisplayGroceryProducts(categories[1].id);
                            break;
                        }
                    case 3:
                        {
                            displayGroceries.DisplayGroceryProducts(categories[2].id);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Go back");
                            exit = true;
                            break;
                        }
                    default:
                        Console.WriteLine("Wrong input try again");
                        break;
                }
            }
        }
    }
}
