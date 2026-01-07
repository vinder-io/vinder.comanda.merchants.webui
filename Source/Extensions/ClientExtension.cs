namespace Vinder.Comanda.Merchants.WebUI.Extensions;

public static class ClientExtension
{
    public static void AddClients(this IServiceCollection services, IConfiguration configuration)
    {
        var address = configuration.GetValue<string>("Settings:Gateway")!;

        services.AddHttpClient<IEstablishmentClient, EstablishmentClient>(client =>
        {
            client.BaseAddress = new Uri(address);
            client.Timeout = TimeSpan.FromMinutes(minutes: 1, seconds: 30);
        });

        services.AddHttpClient<IOrderClient, OrderClient>(client =>
        {
            client.BaseAddress = new Uri(address);
            client.Timeout = TimeSpan.FromMinutes(minutes: 1, seconds: 30);
        });

        services.AddHttpClient<IProductClient, ProductClient>(client =>
        {
            client.BaseAddress = new Uri(address);
            client.Timeout = TimeSpan.FromMinutes(minutes: 1, seconds: 30);
        });
    }
}