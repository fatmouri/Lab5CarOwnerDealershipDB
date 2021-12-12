using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Make sure you use the Nu Get package manager to instal the Microsoft Entity Framework Core
using Microsoft.EntityFrameworkCore;


namespace CarOwnerDealershipDB.Models
{
    //CarOwnerDealershipContext inherits from DbContext a class that is part of the Microsoft Entity Framework.
    public class CarOwnerDealershipContext : DbContext
    {
        //Constructor for CarOwnerDealershipContext
        public CarOwnerDealershipContext(DbContextOptions<CarOwnerDealershipContext> options): base(options)
        {



        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }

        public DbSet<Owner> Owners { get; set; }

    }
}
