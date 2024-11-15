using Core;

namespace Miniproject1.Service;

public interface ILoginService
{

    Task<User> GetUserLoggedIn();

    Task<bool> Login(string username, string password);
    Task Logout();
    
}
