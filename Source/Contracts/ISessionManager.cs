namespace Vinder.Comanda.Merchants.WebUI.Contracts;

public interface ISessionManager
{
    Task SignInAsync(string token);
    Task SignOutAsync();
}
