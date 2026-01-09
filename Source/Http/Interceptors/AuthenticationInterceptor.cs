namespace Vinder.Comanda.Merchants.WebUI.Http.Interceptors;

public sealed class AuthenticationInterceptor(ILocalStorageGateway localStorage) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellation)
    {
        var token = await localStorage.GetAsStringAsync(Storage.SecurityToken, cancellation);

        /* https://www.rfc-editor.org/rfc/rfc6750 */
        if (!string.IsNullOrWhiteSpace(token))
            request.Headers.Authorization = new(AuthenticationDefaults.Scheme, token);

        return await base.SendAsync(request, cancellation);
    }
}
