using Logic;
using Microsoft.AspNetCore.Components;
using Pages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddGalnetWebBase(
    typeof(Galnet.Web.Base.GalnetApp).Assembly,
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

        //ps.AddPlugin("TestWaiter", (ctx) =>
        //{
        //    Thread.Sleep(10000);
        //});

        new Service().Register(ps);
    });

//builder.Services.AddGalnetAuthentication();
//builder.Services.AddGalnetGoogleButton();
//builder.Services.AddGalnetFacebookButton();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_RootWithGoogleButton");
//app.MapFallbackToPage("/_Root");


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.MapGet("/galnetapi/hi", () => "Hello World!");

app.Run();
