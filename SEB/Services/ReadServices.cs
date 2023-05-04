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
    internal class ReadServices : IGetProducts, IGetCategories
    {
        string conn = $"Data Source=.;Initial Catalog=SEBDB;Integrated Security=True;TrustServerCertificate=true;";

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
                            products.ProductName = reader.GetString(0);
                            products.Price = reader.GetDecimal(1);

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
    }
}
