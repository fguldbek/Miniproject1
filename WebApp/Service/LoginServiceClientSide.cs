using Core;
using Blazored.LocalStorage;
using System.Threading.Tasks;

namespace Miniproject1.Service;

public class LoginServiceClientSide : ILoginService
{
    private ILocalStorageService localStorage { get; set; }

    public LoginServiceClientSide(ILocalStorageService ls)
    {
        localStorage = ls;
    }

    public async Task<User?> GetUserLoggedIn()
    {
        var res = await localStorage.GetItemAsync<User>("user");
        return res;
    }

    public async Task<bool> Login(string username, string password)
    {
        // Opret en liste med godkendte brugere
        var validUsers = new List<User>
        {
            new User { Username = "Peter", Password = "1234", Role = "admin", UserId = 1, BuyerId = 1 },
            new User { Username = "Kim", Password = "1234", Role = "admin", UserId = 2, BuyerId = 2 },
            new User { Username = "Mette", Password = "1234", Role = "admin", UserId = 3, BuyerId = 3 }
        };

        // Tjek, om der findes en gyldig bruger med de indtastede credentials
        var user = validUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
        
        if (user != null)
        {
            // Gem brugeroplysninger i localStorage
            await localStorage.SetItemAsync("user", user);
            return true;
        }
        
        // Returnér false, hvis ingen brugere matchede
        return false;
    }
    public async Task Logout()
    {
        await localStorage.RemoveItemAsync("user");
    }
}
