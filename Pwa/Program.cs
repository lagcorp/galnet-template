using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;
using Pages;
using Logic;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<Galnet.Web.Base.GalnetApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddGalnetWebBase(
    typeof(Program).Assembly,
    new List<System.Reflection.Assembly>
    {
        typeof(Details).Assembly,
    },
    new GalnetWebConfig
    {
        ShowTopMenu = true,
        //TopMenu = typeof(CustomTopMenu)
    },
    withLocalPlatformStatusPlugin: true,
    pluginInitialization: (ps) =>
    {
        //ps.AddAuthenticationPlugins();
        //ps.AddFacebookAuthenticationPlugins();

        ps.AddPlugin("TestWaiter", (ctx) =>
        {
            Thread.Sleep(10000);
        });

        new Service().Register(ps);
    });
await builder.Build().RunAsync();
