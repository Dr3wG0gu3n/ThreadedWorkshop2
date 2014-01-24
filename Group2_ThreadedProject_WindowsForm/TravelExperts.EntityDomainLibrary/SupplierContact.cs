using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*****************************************************
 * Author: Yu Wen Ruan
 * business class of SupplierContact
 * ***************************************************/
namespace TravelExperts.EntityDomainLibrary
{
    public class SupplierContact
    {
        //constructors
        public SupplierContact() { }        
        public SupplierContact(int id)
        {
            SupplierContactId = id;           
        }

        //public properties
        public int SupplierContactId { get; set; }
        public string SupConFirstName { get; set; }
        public string SupConLastName { get; set; }
        public string SupConCompany { get; set; }
        public string SupConAddress { get; set; }
        public string SupConCity { get; set; }
        public string SupConProv { get; set; }
        public string SupConPostal { get; set; }
        public string SupConCountry { get; set; }
        public string SupConBusPhone { get; set; }
        public string SupConFax { get; set; }
        public string SupConEmail { get; set; }
        public string SupConURL { get; set; }
        public string AffiliationId { get; set; }
        public int SupplierId { get; set; }

    }
}
