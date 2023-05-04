using SEB.Models;
using SEB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.GUI
{
    internal class DisplayGroceries
    {
        
        ReadServices readServices = new ReadServices();
        List<Products> products = new();
        
        List<OrderDetails> orderDetails = new();
        DisplayBasket DisplayBasket = new DisplayBasket();

        // display grocery products
        public void DisplayGroceryProducts(int categoryId)
        {
            // display grocery products
            bool exit = false;

            products = readServices.GetGroceryProducts(categoryId);

            while (!exit)
            {
                Console.WriteLine("Add item to your basket by pressing the corresponding number");
                Console.WriteLine("");
                for (int i = 1; i <= products.Count; i++)
                {
                    Console.WriteLine($"{i}. {products[i - 1].ProductName}   {products[i - 1].Price}$");
                    
                }
                Console.WriteLine("4. Show Basket");
                Console.WriteLine("5. Go back");


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            OrderDetails order = new();
                            Console.Clear();
                            Console.WriteLine($"How many {products[0].ProductName} do you want to add to your basket?");
                            order.Quantity= Convert.ToInt32(Console.ReadLine());
                            order.ProductID = products[0].Id;
                            order.OrderPrice = products[0].Price * order.Quantity;
                            orderDetails.Add(order);
                            break;
                        }

                    case 2:
                        {
                            OrderDetails order = new();
                            Console.Clear();
                            Console.WriteLine($"How many {products[1].ProductName} do you want to add to your basket?");
                            order.Quantity = Convert.ToInt32(Console.ReadLine());
                            order.ProductID = products[1].Id;
                            order.OrderPrice = products[1].Price * order.Quantity;
                            orderDetails.Add(order);

                            break;
                        }
                    case 3:
                        {
                            OrderDetails order = new();
                            Console.Clear();
                            Console.WriteLine($"How many {products[2].ProductName} do you want to add to your basket?");
                            order.Quantity = Convert.ToInt32(Console.ReadLine());
                            order.ProductID = products[2].Id;
                            order.OrderPrice = products[2].Price * order.Quantity;
                            orderDetails.Add(order);

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Show Basket");
                            // go to basket where you can see your order and confirm or deny it
                            // also make changes to the order
                            DisplayBasket.DisplayGrocerBasket(orderDetails);


                            break;
                        }
                    case 5:
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
