using GregNetGenProject.Areas.Identity.Data;
using GregNetGenProject.Core.Repositories;

namespace GregNetGenProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        //
        private readonly GregNetGenProjectDBContext _context;

        //
        public UserRepository(GregNetGenProjectDBContext context) {
            _context = context;
        }

        public GregNetGenProjectUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        //------------------------------------------------------------------------------//
        /// <summary>
        /// Implementing the Interface
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ICollection<GregNetGenProjectUser> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//