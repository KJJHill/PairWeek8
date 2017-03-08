using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        string connectionString = @"Data Source=DESKTOP-6JSSBN8\SQLEXPRESS;Initial Catalog=ForumPost;Integrated Security=True;";
        string SQL_GetSpecificProduct = "SELECT name, price, description, product_id, image_name FROM products WHERE product_id = @productId;";
        string SQL_GetAllProducts = "SELECT name, price, description, product_id, image_name FROM products;";
        public Product GetProduct(int id)
        {
            Product result = new Product();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetSpecificProduct, conn);

                    cmd.Parameters.AddWithValue("@productId", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Name = Convert.ToString(reader["name"]);
                        result.Price = Convert.ToDouble(reader["price"]);
                        result.Description = Convert.ToString(reader["description"]);
                        result.ProductId = Convert.ToInt32(reader["product_id"]);
                        result.ImageName = Convert.ToString(reader["image_name"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log and throw the exception
                throw new NotImplementedException();
            }
            return result;
        }

    public List<Product> GetProducts()
    { 
            List<Product> result = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllProducts, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Name = Convert.ToString(reader["name"]);
                        p.Price = Convert.ToDouble(reader["price"]);
                        p.Description = Convert.ToString(reader["description"]);
                        p.ProductId = Convert.ToInt32(reader["product_id"]);
                        p.ImageName = Convert.ToString(reader["image_name"]);

                        result.Add(p);
                    }
                }
            }
            catch (SqlException ex)
            {
                //Log and throw the exception
                throw new NotImplementedException();
            }
            return result;
        }
    }
}