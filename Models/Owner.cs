using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOwnerDealershipDB.Models
{
    public class Owner
    {
        public int ownerID { get; set; }

        public string fullName { get; set; }

        public string driversLicense { get; set; }

        public List<Car> cars { get; set; }
    }
}
