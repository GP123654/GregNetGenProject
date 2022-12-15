using GregNetGenProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace GregNetGenProject.Core.ViewModels
{
    public class EditUserViewModel
    {

        public GregNetGenProjectUser User { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
