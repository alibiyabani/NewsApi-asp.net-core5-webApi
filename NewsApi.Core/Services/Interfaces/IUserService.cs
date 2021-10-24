
namespace NewsApi.Core.Services.Interfaces
{
    public interface IUserService
    {
        bool IsExist(string userName, string password);

    }
}
