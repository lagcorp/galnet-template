using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<Galnet.Web.Base.GalnetApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddGalnetWebBase(
    typeof(Program).Assembly,
    new List<System.Reflection.Assembly>
    {
        typeof(Pages.Details).Assembly
    });

await builder.Build().RunAsync();
