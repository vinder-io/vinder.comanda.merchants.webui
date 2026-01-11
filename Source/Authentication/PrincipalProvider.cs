namespace Vinder.Comanda.Merchants.WebUI.Authentication;

public sealed class PrincipalProvider(HttpClient httpClient) : IPrincipalProvider
{
    public async Task<Result<PrincipalScheme>> GetPrincipalAsync(CancellationToken cancellation = default)
    {
        var response = await httpClient.GetAsync("/api/v1/identity/principal", cancellation);
        var content = await response.Content.ReadAsStringAsync(cancellation);

        // we prefer explicit boolean comparisons for readability
        // https://rules.sonarsource.com/csharp/RSPEC-1125/

        #pragma warning disable S1125
        if (response.IsSuccessStatusCode is false)
        {
            return Result<PrincipalScheme>.Failure(UserErrors.UserDoesNotExist);
        }

        var result = JsonSerializer.Deserialize<PrincipalScheme>(content);
        if (result is null)
        {
            return Result<PrincipalScheme>.Failure(UserErrors.UserDoesNotExist);
        }

        return Result<PrincipalScheme>.Success(result);
    }
}