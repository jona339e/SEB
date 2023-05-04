using SEB.Models;
using SEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.GUI
{
    internal class DisplayBasket
    {
        ReadServices readServices = new ReadServices();
        CreateServices createServices = new CreateServices();
        public void DisplayGrocerBasket(List<OrderDetails> orderDetails)
        {
            bool exit = false;
            decimal totalPrice = 0;
            List<Products> products = new List<Products>();
            products = readServices.GetGroceryProducts();

            while (!exit) 
            {
                foreach (OrderDetails order in orderDetails)
                {
                    Console.WriteLine($"Type: {products[order.ProductID - 1].ProductName} Amount: {order.Quantity} Price: {order.OrderPrice}");
                    totalPrice += order.OrderPrice;
                }
                Console.WriteLine($"Total Price: {totalPrice}");
                Console.WriteLine("----------------------------------------------------------------");

                Console.WriteLine("Chose the following: ");
                Console.WriteLine("1. Place order");
                Console.WriteLine("2. Edit order");
                Console.WriteLine("3. Cancel order");
                Console.WriteLine("4. Continue Shopping");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        {
                            int orderID = readServices.CountOrders()+1;
                            createServices.CreateOrder(orderID, totalPrice);
                            foreach (var item in orderDetails)
                            {
                                item.OrderId = orderID;
                            }
                            createServices.CreateOrderDetails(orderDetails);
                            Console.Clear();
                            Console.WriteLine("Order: ");
                            foreach (OrderDetails order in orderDetails)
                            {
                                Console.WriteLine($"Type: {products[order.ProductID - 1].ProductName} Amount: {order.Quantity} Price: {order.OrderPrice}");
                                totalPrice += order.OrderPrice;
                            }
                            Console.WriteLine("Accepted");
                            exit = true;
                            orderDetails.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Not implemented yet");
                            break;
                        }
                    case 3:
                        {
                            orderDetails.Clear();
                            Console.WriteLine("Order deleted");
                            exit = true;
                            break;
                        }
                    case 4:
                        {
                            exit = true;
                            break;
                        }

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("");
                        break;
                }
            }

            

        }

    }
}
