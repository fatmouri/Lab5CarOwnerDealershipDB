using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Add the following import (you do not need to use the nu-get package manager).
//We are obtaining the class IdentityUser from it (to inherit from it).
using Microsoft.AspNetCore.Identity;


namespace CarOwnerDealershipDB.Models
{
    /*Inheriting from the class Identity User.
     * AppUser is our model. Why don't we just use IdentityUser as our model 
     * if we have access to it?
     * Mainly because we can add data attributes to AppUser,
     * if we wanted to in the future. 
     * For example, you would like to note the region or address of a user.
     * After this we can move on to the Entity Framework by creating a context class.
     * This time though, we are not going to put the context class in the Models folder.
     * We will create a new folder called Data and insert it in there (much cleaner).
    
    */   
    public class AppUser: IdentityUser
    {

    }
}
