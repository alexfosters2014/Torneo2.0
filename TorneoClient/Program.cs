using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TorneoClient;
using TorneoClient.DataService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();
builder.Services.AddMudServices();

string backendUrlLocal = builder.Configuration.GetValue<string>("DefaultConnectionWebApi"); //pasarlo al aoppsetting.json

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("DefaultConnectionWebApi")) });

builder.Services.AddScoped<DataServiceEquipo>();
builder.Services.AddScoped<DataServiceImagen>();
builder.Services.AddScoped<DataServiceJugador>();


await builder.Build().RunAsync();
