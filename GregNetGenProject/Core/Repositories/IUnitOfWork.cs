namespace GregNetGenProject.Core.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
    }
}
