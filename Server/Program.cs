using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddGalnetWebBase(
    typeof(Galnet.Web.Base.GalnetApp).Assembly,
    new List<System.Reflection.Assembly>
    {
        typeof(Pages.Details).Assembly,
    });

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
app.MapFallbackToPage("/_Root");

app.Run();
