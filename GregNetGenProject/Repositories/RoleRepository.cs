using GregNetGenProject.Areas.Identity.Data;
using GregNetGenProject.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GregNetGenProject.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly GregNetGenProjectDBContext _context;

        public RoleRepository(GregNetGenProjectDBContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
