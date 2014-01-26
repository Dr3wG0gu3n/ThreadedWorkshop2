using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *Code Written by Chris Kostashuk
 *22/01/2014
 *Packages_Products_Supplier Class
 * 
 */
namespace TravelExperts.EntityDomainLibrary
{
    public class Packages_Products_Suppliers
    {
        //Private properties
        private int PackageId;
        private int ProductSupplierId;

        //Properties
        
        public int Id { get; set; }

        public int ProductSupplierID { get; set; }
        
        //Constructor
        public Packages_Products_Suppliers() { }

        public Packages_Products_Suppliers(int id, int prdSupId )
        {
            Id = id;
            ProductSupplierID = prdSupId;
        }


    }
}
