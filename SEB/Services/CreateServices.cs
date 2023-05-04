using Microsoft.Data.SqlClient;
using SEB.Interfaces;
using SEB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEB.Services
{
    internal class CreateServices: ICreateOrder
    {
        string conn = $"Data Source=.;Initial Catalog=SEBDB;Integrated Security=True;TrustServerCertificate=true;";

        public void CreateOrder(int orderID, decimal totalPrice)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_InsertOrder", con) { CommandType = CommandType.StoredProcedure })
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", orderID);
                    cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void CreateOrderDetails(List<OrderDetails> orderDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_InsertOrderDetails", con) { CommandType = CommandType.StoredProcedure })
                {

                    con.Open();
                    foreach (var item in orderDetails)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@productID", item.ProductID);
                        cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@orderPrice", item.OrderPrice);
                        cmd.Parameters.AddWithValue("@orderID", item.OrderId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
