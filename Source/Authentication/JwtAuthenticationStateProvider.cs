namespace Vinder.Comanda.Merchants.WebUI.Authentication;

public sealed class JwtAuthenticationStateProvider(ILocalStorageGateway localStorage) :
    AuthenticationStateProvider
{
    private readonly JwtSecurityTokenHandler tokenHandler = new();
    private readonly ClaimsPrincipal anonymous =
        new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenString = await localStorage.GetAsync<string>(Storage.SecurityToken);
        if (string.IsNullOrWhiteSpace(tokenString))
        {
            return new AuthenticationState(anonymous);
        }

        var token = tokenHandler.ReadJwtToken(tokenString);
        if (token.ValidTo < DateTime.UtcNow)
        {
            return new AuthenticationState(anonymous);
        }

        var identity = new ClaimsIdentity(token.Claims, AuthenticationDefaults.Type);
        var principal = new ClaimsPrincipal(identity);

        return new AuthenticationState(principal);
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
