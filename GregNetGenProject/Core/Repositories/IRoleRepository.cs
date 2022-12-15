using Microsoft.AspNetCore.Identity;
using GregNetGenProject.Areas.Identity.Data;

namespace GregNetGenProject.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
        
    }
}
