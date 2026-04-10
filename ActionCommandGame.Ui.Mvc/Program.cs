using ActionCommandGame.Sdk;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// SDK registreren
builder.Services.AddHttpClient("ActionCommandGameApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5180/"); // API poort
});

builder.Services.AddScoped<GameSdk>();
builder.Services.AddScoped<PlayerSdk>();
builder.Services.AddScoped<ItemSdk>();
builder.Services.AddScoped<PlayerItemSdk>();
builder.Services.AddScoped<AuthSdk>();
builder.Services.AddSession();



var app = builder.Build();

app.UseSession();  
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();