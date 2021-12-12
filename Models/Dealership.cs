using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarOwnerDealershipDB.Models
{
    public class Dealership
    {
        public int dealershipID { get; set; }

        public string dealershipName { get; set; }

        public string city { get; set; }

        public string province { get; set; }

        public List<Car> cars { get; set; }
    }
}
