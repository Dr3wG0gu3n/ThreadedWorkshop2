using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.EntityDomainLibrary;

/*********************************************************************
 * Author: Chris & Yu Wen
 * Date: Jan 16, 2014
 * Task: Workshop 2-CMPP248
 * 
 * Static class ProductDB
 * method: GetProduct, AddProduct, UpdateProduct,DeleteProduct
 * *****************************************************************/

namespace TravelExperts
{
    public static class ProductDB
    {
        //method to get products from table Product
        public static Product GetProduct(int productId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //select statement
            string selectStatement
                = "SELECT ProductId,ProdName "
                + "FROM Products "
                + "WHERE ProductId = @ProductId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            //set parameter for select statement
            selectCommand.Parameters.AddWithValue("@ProductId", productId);

            try
            {
                connection.Open();
                //execute select query
                SqlDataReader prodReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                //get record from recordset
                if (prodReader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)prodReader["ProductId"];
                    product.ProdName = prodReader["ProdName"].ToString();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex) //sql error catch
            {
                throw ex;
            }
            finally
            {
                connection.Close();     //close the database connection
            }
        }


        //method to add new product
        public static int AddProduct(Product product)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //insert statement
            string insertStatement = @"INSERT Products (ProdName) VALUES (@ProdName); SELECT SCOPE_IDENTITY()";
                
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            //set parameter for insert statement
            insertCommand.Parameters.AddWithValue(
                "@ProdName", product.ProdName);
            try
            {
                connection.Open();
                //execute insert statement
                int rowNumber = Convert.ToInt32(insertCommand.ExecuteScalar());
                //get current position
                string selectStatement =
                    "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int productId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return productId;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //method to update product information based on given ProductId
        public static bool UpdateProduct(Product newProduct)
        {
            //connect database
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //update statement 
            string updateStatement =
                "UPDATE Products SET " +
                "ProdName = @NewName " +
                "WHERE ProductId = @productId "; 
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            //set parameters for update statement
            updateCommand.Parameters.AddWithValue(
               "@NewName", newProduct.ProdName);
            updateCommand.Parameters.AddWithValue(
                "@productId", newProduct.ProductId);

            try
            {
                connection.Open();
                //execute update statement
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //method to delete one product record from table products
        public static bool DeleteProduct(Product product)
        {
            //database connection
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //delete statement
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductId = @productId "; 
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            //set parameter for delete statement
            deleteCommand.Parameters.AddWithValue(
                "@productId", product.ProductId);
            try
            {
                connection.Open();
                //execute delete statement
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)     //sql error
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Get all products to populate the datagradview in the 2nd GUI project 
        //done by Andrew Goguen
        public static List<Product> GetAllProducts(int supplierId)
        {
            List<Product> products = new List<Product>();
            Product prod;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string getProducts = "select * from Products p, Products_Suppliers i where p.ProductId = i.Productid and i.SupplierId  = @SupplierId";

            SqlCommand getCommand = new SqlCommand(getProducts, connection);
            getCommand.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                connection.Open();
                SqlDataReader reader = getCommand.ExecuteReader();
                while (reader.Read())
                {
                    prod = new Product((int)reader["ProductId"], reader["ProdName"].ToString());
                    products.Add(prod);
                }
                return products;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            Product prod;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string getProducts = "select * from Products";

            SqlCommand getCommand = new SqlCommand(getProducts, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = getCommand.ExecuteReader();
                while (reader.Read())
                {
                    prod = new Product((int)reader["ProductId"], reader["ProdName"].ToString());
                    products.Add(prod);
                }
                return products;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
