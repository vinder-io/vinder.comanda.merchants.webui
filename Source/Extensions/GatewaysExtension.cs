namespace Vinder.Comanda.Merchants.WebUI.Extensions;

public static class GatewaysExtension
{
    public static void AddGateways(this IServiceCollection services, IConfiguration configuration)
    {
        var address = configuration.GetValue<string>("Settings:IdentityProvider")!;
        var tenant = configuration.GetValue<string>("Settings:Tenant")!;

        services.AddScoped<ILocalStorageGateway, LocalStorageGateway>();
        services.AddHttpClient<IIdentityClient, IdentityClient>(client =>
        {
            client.BaseAddress = new Uri(address);
            client.DefaultRequestHeaders.Add(Headers.Tenant, tenant);
            client.Timeout = TimeSpan.FromMinutes(minutes: 1, seconds: 30);
        });
    }
}
