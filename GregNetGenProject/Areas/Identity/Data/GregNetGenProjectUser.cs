

//Imports
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Package
namespace GregNetGenProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GregNetGenProjectUser class
public class GregNetGenProjectUser : IdentityUser
{
    /*
     * These are just the extra fields that were added.
     * I don't think I need the other ones like the 
     * password and email address but could be wrong.
     */

    /// <summary>
    /// This stores the users first name and it will be stored in the local database.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// This stores the users surname and it will be stored in the local database.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// This stores the users cellular number and it will be stored in the local database.
    /// </summary>
    public int CellularNum { get; set; }

    /// <summary>
    /// This stores the users age and it will be stored in the local database.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// This stores the users hobbies and it will be stored in the local database.
    /// </summary>
    public string Hobbies { get; set; }
}

public class ApplicationRole : IdentityRole
{

}

//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//
