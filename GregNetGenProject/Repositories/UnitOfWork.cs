using GregNetGenProject.Core.Repositories;

namespace GregNetGenProject.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }


        public UnitOfWork(IUserRepository user)
        {
            User = user;
        }
    }
}
