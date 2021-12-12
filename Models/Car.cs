using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOwnerDealershipDB.Models
{
    public class Car
    {

        public int carID { get; set; }

        public string make { get; set; }

        public string model { get; set; }

        public int year { get; set; }

        public int kilometers { get; set; }

        public DateTime lastSoldDate { get; set; }

        public int dealershipID { get; set; }

        public Dealership dealership { get; set; }

        public int ownerID { get; set; }

        public Owner owner { get; set; }
    }
}
