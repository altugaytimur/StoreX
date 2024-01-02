using StoreX.Application.Mapper;
using StoreXApp.Infra.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//ServiceExtension  yazarak configuration i�leminin bir metota vermi� oluyoruz ve onu servicelere ekliyoruz.
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureIdentity();
//Session configurationlar�n� service ekliyoruz.
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();


//builder.Services.AddAutoMapper(typeof(Program)); mapping profile application katman�nda a�t���m�z i�in bulam�yor. A�a��daki gibi olu�turmam�z gerekiyor.
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
//wwwroot klas�r�n�n kullan�labilmesi i�in UseStaticFiles ekleniyor.
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

//Area added
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();

});

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();
