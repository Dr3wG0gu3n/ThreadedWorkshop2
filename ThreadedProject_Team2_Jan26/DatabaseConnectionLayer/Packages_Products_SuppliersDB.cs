using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.EntityDomainLibrary;
using TravelExperts;
/*
 * Code Written by Chris Kostashuk
 * 22/01/2014
 * Class Database connection to the Packages_Products_Suppliers table
 * */

namespace DatabaseConnectionLayer
{
    public static class Packages_Products_SuppliersDB
    {
        //A method for getting all Product_Supplier combo's for a package
        public static List<Products_Suppliers> GetPkgProducts(int packageId)
        {
            List<Products_Suppliers> p_suppliers = new List<Products_Suppliers>();

            //SQL Connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //Select Statement
            string getProducts = "SELECT ps.ProductSupplierId, ps.ProductId, ps.SupplierId " +
                        "FROM Products_Suppliers ps, Packages_Products_Suppliers pps " +
                        "WHERE ps.ProductSupplierID =pps.ProductSupplierID AND pps.PackageId=@PackageID ";

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
                    Products_Suppliers p_supplier = new Products_Suppliers();
                    p_supplier.ProductSupplierId = reader[0] as int? ?? default(int);
                    p_supplier.ProductId = reader[1] as int? ?? default(int);
                    p_supplier.SupplierId = reader[2] as int? ?? default(int);
                    p_suppliers.Add(p_supplier);
                }
                return p_suppliers;
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

        //a method to add record to a Packages_Products_Suppliers
        public static bool InsertPkgProduct(int packageId, int psId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            //insert statement
            string commandStatement = "INSERT INTO Packages_Products_Suppliers (PackageId, ProductSupplierID) Values(@packageId, @psId)";

            SqlCommand command = new SqlCommand(commandStatement, connection);

            //set parameter for insert statement
            command.Parameters.AddWithValue("@packageId", packageId);
            command.Parameters.AddWithValue("@psId", psId);

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

        //method to delete a Packages_Products_Suppliers from a Package
        public static bool DeletePkgProduct(int packId)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            //DELETE statement
            string commandStatement = "DELETE FROM Packages_Products_Suppliers WHERE PackageId = @PackageId";

            SqlCommand command = new SqlCommand(commandStatement, connection);

            //set parameter for delete statement
            command.Parameters.AddWithValue("@PackageId", packId);
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
