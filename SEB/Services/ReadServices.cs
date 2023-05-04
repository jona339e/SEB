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
    internal class ReadServices : IGetProducts, IGetCategories, ICountOrders
    {
        string conn = $"Data Source=.;Initial Catalog=SEBDB;Integrated Security=True;TrustServerCertificate=true;";

        public int CountOrders()
        {
            int count = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_CountOrders", con) { CommandType = CommandType.StoredProcedure })
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return count;
        }

        public List<Categories> GetCategories()
        {
            List<Categories> CategoryList = new List<Categories>();

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetCategories", con) { CommandType = CommandType.StoredProcedure })
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categories category = new();
                            category.id = reader.GetInt32(0);
                            category.CategoryName = reader.GetString(1);

                            CategoryList.Add(category);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return CategoryList;
        }

        public List<Products> GetGroceryProducts(int categoryId)
        {

            // get list of products from database'
            // using a stored procedure

            List<Products> productsList = new List<Products>();

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetGroceries", con) { CommandType = CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products products = new Products();
                            products.Id = reader.GetInt32(0);
                            products.ProductName = reader.GetString(1);
                            products.Price = reader.GetDecimal(2);
                            products.CategoryID = reader.GetInt32(3);


                            productsList.Add(products);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return productsList;
        }
        public List<Products> GetGroceryProducts()
        {

            // get list of products from database'
            // using a stored procedure

            List<Products> productsList = new List<Products>();

            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetAllGroceries", con) { CommandType = CommandType.StoredProcedure })
                {
                    
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Products products = new Products();
                            products.Id = reader.GetInt32(0);
                            products.ProductName = reader.GetString(1);
                            products.Price = reader.GetDecimal(2);
                            products.CategoryID = reader.GetInt32(3);


                            productsList.Add(products);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return productsList;
        }

        // no interface D:
        public List<OrderDetails> GetAllOrders()
        {
            
            List<OrderDetails> orderDetails = new();
            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                using (SqlCommand cmd = new SqlCommand("usp_GetAllOrderDetails", con) { CommandType = CommandType.StoredProcedure })
                {
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetails details = new OrderDetails();
                            details.Id = reader.GetInt32(0);
                            details.OrderId = reader.GetInt32(1);
                            details.ProductID = reader.GetInt32(2);
                            details.Quantity = reader.GetInt32(3);
                            details.OrderPrice = reader.GetDecimal(4);
                            orderDetails.Add(details);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return orderDetails;
        }
    }
}
