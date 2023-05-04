using SEB.Models;
using SEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.GUI
{
    internal class DisplayAllOrders
    {
        ReadServices ReadServices = new();
        public void DisplayAllGrocerOrders()
        {
            bool condition = true;
            List<OrderDetails> orders = ReadServices.GetAllOrders();

            for (int i = 1; i < orders.Count; i++)
            {
                Console.WriteLine($"View order {i}");
            }
            int input = Convert.ToInt32(Console.ReadLine());
            do
            {
                if (input < 0 || input > orders.Count)
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    condition = false;
                }
            } while (condition);
            Console.WriteLine($"Order details for order {input}");
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
}
