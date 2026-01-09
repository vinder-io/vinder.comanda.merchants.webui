global using System.Text.Json;
global using System.Net.Http.Json;

global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;

global using Microsoft.JSInterop;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.AspNetCore.Components.Authorization;

global using Vinder.Comanda.Merchants.WebUI.Extensions;
global using Vinder.Comanda.Merchants.WebUI.Contracts;
global using Vinder.Comanda.Merchants.WebUI.Constants;
global using Vinder.Comanda.Merchants.WebUI.Gateways;
global using Vinder.Comanda.Merchants.WebUI.Authentication;
global using Vinder.Comanda.Merchants.WebUI.Http.Clients;
global using Vinder.Comanda.Merchants.WebUI.Http.Interceptors;

global using Vinder.Comanda.Internal.Contracts.Clients;
global using Vinder.Comanda.Internal.Contracts.Clients.Interfaces;

global using Vinder.IdentityProvider.Sdk.Contracts.Clients;
global using Vinder.IdentityProvider.Sdk.Contracts.Payloads.Identity;
global using Vinder.IdentityProvider.Sdk.Contracts.Payloads.User;

global using Vinder.Internal.Essentials.Patterns;
global using MudBlazor.Services;
