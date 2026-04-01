using ActionCommandGame.Sdk;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// SDK registreren
builder.Services.AddHttpClient("ActionCommandGameApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7000/"); // poort van jouw API
});

builder.Services.AddScoped<GameSdk>();
builder.Services.AddScoped<PlayerSdk>();
builder.Services.AddScoped<ItemSdk>();
builder.Services.AddScoped<PlayerItemSdk>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();