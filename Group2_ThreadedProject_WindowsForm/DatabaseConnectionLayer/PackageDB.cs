using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TravelExperts.EntityDomainLibrary;

/*********************************************************************
 * Author: Vishnu
 * Date: Jan 21, 2014
 * Task: Workshop 
 * 
 * Static class PackageDB
 * method: GetPackage, AddPackage, UpdatePackage,DeletePackage
 * *****************************************************************/


namespace DatabaseConnectionLayer
{
    public static class PackageDB
    {
        //method to get products from table Product
        public static Package GetPackage(int PackageId)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //select statement
            string selectStatement
                = "SELECT PackageId,PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission "
                + "FROM Packages "
                + "WHERE PackageId = @PackageId";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            //set parameter for select statement
            selectCommand.Parameters.AddWithValue("@PackageId", PackageId);

            try
            {
                connection.Open();
                //execute select query
                SqlDataReader packageReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                //get record from recordset
                if (packageReader.Read())
                {
                    Package package = new Package();
                    package.PackageId = (int)packageReader["PackageId"];
                    package.PkgName = packageReader["PkgName"].ToString();
                    package.PkgStartDate = Convert.ToDateTime (packageReader["PkgStartDate"]);
                    package.PkgEndDate = Convert.ToDateTime(packageReader["PkgEndDate"]);
                    package.PkgDesc = packageReader["PkgDesc"].ToString();
                    package.PkgBasePrice = Convert.ToDouble(packageReader["PkgBasePrice"]);
                    package.PkgAgencyCommission = Convert.ToDouble (packageReader["PkgAgencyCommission"]);

                    return package;
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
            catch (Exception ex) //error catch
            {
                throw ex;
            }
            finally
            {
                connection.Close();     //close the database connection
            }
        }


        //method to add new package
        public static int AddPackage(Package package)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //insert statement
            string insertStatement = @"INSERT Packages (PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) 
                                       VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission); 
                                    SELECT SCOPE_IDENTITY()";

            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            //set parameter for insert statement
            insertCommand.Parameters.AddWithValue("@PkgName", package.PkgName);
            insertCommand.Parameters.AddWithValue("@PkgStartDate", package.PkgStartDate);
            insertCommand.Parameters.AddWithValue("@PkgEndDate", package.PkgEndDate);
            insertCommand.Parameters.AddWithValue("@PkgDesc", package.PkgDesc);
            insertCommand.Parameters.AddWithValue("@PkgBasePrice", package.PkgBasePrice);
            insertCommand.Parameters.AddWithValue("@PkgAgencyCommission", package.PkgAgencyCommission);

            try
            {
                connection.Open();
                //execute insert statement
                int rowNumber = Convert.ToInt32(insertCommand.ExecuteScalar());
                //get current position
                string selectStatement =
                    "SELECT IDENT_CURRENT('Packages') FROM Packages";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int PackageId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return PackageId;
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

        //method to update Package information based on given PackageId
        public static bool UpdatePackage(Package newPackage)
        {
            //connect database
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //update statement 
            string updateStatement =
                "UPDATE Packages SET " +
                "PkgName = @NewName " +
                "PkgStartDate = @NewStartDate " +
                "PkgEndDate = @NewEndDate " +
                "PkgDesc = @NewDesc " +
                "PkgBasePrice = @NewBasePrice " +
                "PkgAgencyCommission = @NewAgencyCommission " +

                "WHERE PackageId = @PackageId ";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            //set parameters for update statement
            updateCommand.Parameters.AddWithValue(
               "@NewName", newPackage.PkgName);
            updateCommand.Parameters.AddWithValue(
               "@NewStartDate", newPackage.PkgStartDate);
            updateCommand.Parameters.AddWithValue(
               "@NewEndDate", newPackage.PkgEndDate);
            updateCommand.Parameters.AddWithValue(
               "@NewDesc", newPackage.PkgDesc);
            updateCommand.Parameters.AddWithValue(
               "@NewBasePrice", newPackage.PkgBasePrice);
            updateCommand.Parameters.AddWithValue(
               "@NewAgencyCommission", newPackage.PkgAgencyCommission);

            updateCommand.Parameters.AddWithValue(
                "@PackageId", newPackage.PackageId);

            try
            {
                connection.Open();
                //execute update statement
                int count = updateCommand.ExecuteNonQuery();
                //get current position
                if (count > 0)
                    return true;
                else
                    return false;
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


        //method to delete one package record from table packages
        public static bool DeletePackage(Package package)
        {
            //database connection
            SqlConnection connection = TravelExpertsDB.GetConnection();
            //delete statement
            string deleteStatement =
                "DELETE FROM Packages " +
                "WHERE PackageId = @PackageId ";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            //set parameter for delete statement
            deleteCommand.Parameters.AddWithValue(
                "@PackageId", package.PackageId);
            try
            {
                connection.Open();
                //execute delete statement
                int count = deleteCommand.ExecuteNonQuery();
                //get current position
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)     //sql error
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
