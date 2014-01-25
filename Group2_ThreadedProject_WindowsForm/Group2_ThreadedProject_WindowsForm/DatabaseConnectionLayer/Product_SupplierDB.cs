/* This Class was written by all 4 members of our Group (Andrew, YuWen, Chris, and Vishnu)
 * on jan. 16, 2014 as a bridge between the Products and Suppliers tables
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TravelExperts.EntityDomainLibrary
{
    public static class Product_SupplierDB
    {

        //a get all Products using the SupplierId
        public static List<Product> GetAllProducts(int supplierId)
        {
            List<Product> products = new List<Product>();
            Product product;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string getProducts = "SELECT p.ProductId, ProdName " + 
                                 "FROM Products p, Products_Suppliers s " +
                                 "WHERE p.ProductId = s.ProductId AND s.SupplierId = @SupplierId";

            SqlCommand command = new SqlCommand(getProducts, connection);
            command.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product = new Product();
                    product.ProductId = (int)reader["ProductId"];
                    product.ProdName = reader["ProdName"]as string;
                    products.Add(product);
                }
                return products;              
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            
        }

        //get all suppliers using a Product Id
        public static List<Supplier> GetAllSuppliers(int productId)
        {
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supplier;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string getSuppliers = "SELECT p.SupplierId, SupName " + 
                                 "FROM Suppliers p, Products_Suppliers s " +
                                 "WHERE p.SupplierId = s.SupplierId AND s.ProductId = @ProductId";

            SqlCommand command = new SqlCommand(getSuppliers, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    supplier = new Supplier();
                    supplier.Id = (int)reader["SupplierId"];
                    supplier.Name = reader["SupName"] as string;
                    suppliers.Add(supplier);
                }
                return suppliers;              
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public static bool InsertProduct_Supplier(int prodId, int suppId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string commandStatement = "INSERT INTO Products_Suppliers (ProductId, SupplierId) Values(@ProductId, @SupplierId)";
           
            SqlCommand command = new SqlCommand(commandStatement, connection);
                                                                                        //we have a major problem somewhere here
            command.Parameters.AddWithValue("@ProductId", prodId);                      //FK_Constraint violation in Supplier Table
            command.Parameters.AddWithValue("@SupplierId", suppId);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteProduct_Supplier(int prodId, int suppId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string commandStatement = "DELETE FROM Products_Suppliers WHERE ProductId = @ProductId and SupplierId = @SupplierId";

            SqlCommand command = new SqlCommand(commandStatement, connection);

            command.Parameters.AddWithValue("@ProductId", prodId);
            command.Parameters.AddWithValue("@SupplierId", suppId);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }


        //get all product_suppliers using a Product Id from Products_Suppliers table
        public static List<Products_Suppliers> GetAllProductSuppliers(int productId)
        {
            List<Products_Suppliers> product_suppliers = new List<Products_Suppliers>();
            Products_Suppliers product_supplier;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string getSuppliers = "SELECT ps.ProductSupplierId, ps.ProductId, ps.SupplierId " +
                                 "FROM Suppliers s, Products_Suppliers ps " +
                                 "WHERE s.SupplierId = ps.SupplierId " +
                                 " AND ps.ProductId=@productId";

            SqlCommand command = new SqlCommand(getSuppliers, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product_supplier = new Products_Suppliers();
                    product_supplier.ProductSupplierId = (int)reader[0];
                    product_supplier.ProductId = reader[1] as int? ?? default(int);
                    product_supplier.SupplierId = reader[2] as int? ?? default(int);
                    product_suppliers.Add(product_supplier);
                }
                return product_suppliers;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
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
