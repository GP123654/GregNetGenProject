using GregNetGenProject.Areas.Identity.Data;

namespace GregNetGenProject.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<GregNetGenProjectUser> GetUsers();

        GregNetGenProjectUser GetUser(string id);
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//