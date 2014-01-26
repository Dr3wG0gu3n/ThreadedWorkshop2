/*SupplierDB class written by Andrew Goguen, and Vishnu on Jan. 16, 2014
 * to Access the Database and perform basic CRUD functions
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;              //we need to use these namespaces to access
using System.Data.SqlClient;    //databases

namespace TravelExperts.EntityDomainLibrary
{
    public static class SupplierDB
    {
        
        //a method to get a list of all suppliers from the Datasource
        public static List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            Supplier sup;

            SqlConnection connection = TravelExpertsDB.GetConnection();

            string selectStatement = "SELECT * FROM Suppliers";                    //Select statement
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);  //create the command object

            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    sup = new Supplier((int)reader[0], reader[1].ToString());       //read in the values and assign to
                    suppliers.Add(sup);                                             //to new supplier object
                }
                return suppliers;                                                   //return the list of suppliers
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
               connection.Close();                                                 //close the connection
            }
        }

        //a Simple method to Get the Supplier using the SupplierId
        public static Supplier GetSupplierById(int supplierId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT SupplierId, SupName FROM Suppliers WHERE SupplierId = @SupplierId";

            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();
                SqlDataReader supplierReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (supplierReader.Read())
                {
                    Supplier supplier = new Supplier();
                    supplier.Id = (int)supplierReader["SupplierId"];
                    supplier.Name = supplierReader["SupName"].ToString();
                    return supplier;
                }            
                else
                {
                    return null;
                }
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

        //A method to Add a Supplier into the database, returning the newly created supplierId
        public static bool AddSupplier(Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string insertStatement ="INSERT into Suppliers (SupplierId, SupName) VALUES (@Id, @Name)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@Id", supplier.Id);
            insertCommand.Parameters.AddWithValue("@Name", supplier.Name);
      
            try
            {
                connection.Open();

                int count = insertCommand.ExecuteNonQuery();
                if (count > 0)                              //make sure the insert Supplier worked
                    return true;
                else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateSupplier(int supplierId, string newName)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateStatement = "UPDATE Suppliers Set SupName = @NewName WHERE SupplierId = @SupplierId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            updateCommand.Parameters.AddWithValue("@NewName", newName);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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

        // A method to delete a supplier using the supplier Id of the Supplier passed in
        public static bool DeleteSupplier(Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string deleteStatement = "DELETE FROM Suppliers WHERE SupplierId = @SupplierID";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@SupplierId", supplier.Id);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
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

        //A method to return the next available SupplierId
        public static int GetNextSupplierId()
        {
            List<int> numbers = new List<int>(); //the local variables to use
            int oldId;
            int newId;

            SqlConnection connection = TravelExpertsDB.GetConnection(); //Set up our command object
            string getIdCommand = "SELECT SupplierId from Suppliers";
            SqlCommand selectCommand = new SqlCommand(getIdCommand, connection);

            try
            {
                connection.Open();                                          //open the connection and
                SqlDataReader supIdReader = selectCommand.ExecuteReader();  //read in all values from SupplierId column
                while (supIdReader.Read())
                {
                    oldId = (int)supIdReader["SupplierId"];                 //loop through adding values to 
                    numbers.Add(oldId);                                     //the List
                }
                
                newId = numbers.Max() + 1;                                  //increment the list by 1
                                                                            //by getting max value and adding 1
                return newId;                                               //then return newId
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
                connection.Close();                                         //close the connection
            }

        }

    }
}
