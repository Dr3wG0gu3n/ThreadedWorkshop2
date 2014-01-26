/*
 *Created by Vishnu on January 21, 2014 for 
 *Group 2 Workshop 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExperts.EntityDomainLibrary
{
    public class Package
    {
    
        //constructors
        public Package() { }        

        //public Package(string name)
        //{
        //    PkgName = name;
        //}

        //public Package(double basePrice)
        //{
        //    PkgBasePrice = basePrice;

        //}

        //public Package(int id, string name)
        //{
        //    PackageId = id;
        //    PkgName = name;
        //}

        //public Package(int id, string name, double basePrice)
        //{
        //    PackageId = id;
        //    PkgName = name;
        //    PkgBasePrice = basePrice;
        //}
        public Package( string name, string desc, double basePrice)
        {
            //PackageId = id;
            PkgName = name;
            PkgDesc= desc;
            PkgBasePrice = basePrice;
        }


        //automatic properties
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime PkgStartDate { get; set; }
        public DateTime PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public double PkgBasePrice { get; set; }
        public double PkgAgencyCommission { get; set; }
    }
}
