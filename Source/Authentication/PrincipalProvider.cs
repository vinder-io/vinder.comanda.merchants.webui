namespace Vinder.Comanda.Merchants.WebUI.Authentication;

public sealed class PrincipalProvider(HttpClient httpClient) : IPrincipalProvider
{
    public async Task<Result<PrincipalScheme>> GetPrincipalAsync(CancellationToken cancellation = default)
    {
        var response = await httpClient.GetAsync("/api/identity/principal", cancellation);
        var content = await response.Content.ReadAsStringAsync(cancellation);

        var result = JsonSerializer.Deserialize<PrincipalScheme>(content);
        if (result is null)
        {
            return Result<PrincipalScheme>.Failure(UserErrors.UserDoesNotExist);
        }

        return Result<PrincipalScheme>.Success(result);
    }
}