using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.EntityDomainLibrary;
/*
 * Code Written by Chris Kostashuk
 * 22/01/2014
 * Class Database connection to the Packages_Products_Suppliers table
 * */

namespace DatabaseConnectionLayer
{
    class Packages_Products_SuppliersDB
    {
        //A method for getting all Product_Supplier combo's for a package
        public static List<Products_Suppliers> GetPkgProducts(int packageId)
        {
            List<Products_Suppliers> products = new List<Products_Suppliers>();
            Products_Suppliers product;

            //SQL Connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //Select Statement
            string getProducts = "SELECT ps.ProductSupplierID, p.ProdName, s.SupName " +
                                    "FROM Products p, Suppliers s, Products_Suppliers ps, Packages_Products_Suppliers pps " +
                                        "WHERE p.ProductId = ps.ProductId AND s.SupplierId = ps.SupplierId AND ps.ProductSupplierID = @PackageID ";

            SqlCommand command = new SqlCommand(getProducts, connection);
            //set parameter for select statement
            command.Parameters.AddWithValue("@PackageId", packageId);
            try
            {
                connection.Open();
                //execute select query
                SqlDataReader reader = command.ExecuteReader();
                //get record from recordset
                while (reader.Read())
                {
                    product = new Products_Suppliers
                    {
                        ProductSupplierId = (int)reader[0],
                        ProductId = (int)reader[1],
                        SupplierId = (int)reader[2]
                    };


                    products.Add(product);
                }
                return products;
            }
            catch (SqlException ex) //sql error catch
            {
                throw ex;
            }
            catch (Exception ex) //error catch
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close the database connection
            }
        }

        //a method to add Product_Suppliers to a package
        public static bool InsertPkgProduct(int prodSupId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            //insert statement
            string commandStatement = "INSERT INTO Packages_Products_Suppliers (ProductSupplierID) Values(@ProductSupplierID)";

            SqlCommand command = new SqlCommand(commandStatement, connection);

            //set parameter for insert statement
            command.Parameters.AddWithValue("@ProductSupplierID", prodSupId);

            try
            {
                connection.Open();
                //execute insert statement
                int result = command.ExecuteNonQuery();
                //get current position
                if (result > 0)
                    return true;
                else return false;
            }
            catch (SqlException ex) //sql error catch
            {
                throw ex;
            }
            catch (Exception ex) //error catch
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close the database connection
            }
        }

        //method to delete a Product_Suppliers from a Package
        public static bool DeletePkgProduct(int prodSupId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            //DELETE statement
            string commandStatement = "DELETE FROM Packages_Products_Suppliers WHERE ProductSupplierID = @ProductSupplierID";

            SqlCommand command = new SqlCommand(commandStatement, connection);

            //set parameter for delete statement
            command.Parameters.AddWithValue("@ProducSuppliertId", prodSupId);
            try
            {
                connection.Open();
                //execute delete statement
                int result = command.ExecuteNonQuery();
                //get current position
                if (result > 0)
                    return true;
                else return false;
            }
            catch (SqlException ex)  //sql error catch
            {
                throw ex;
            }
            catch (Exception ex) //error catch
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //close the database connection
            }
        }
    }
}
