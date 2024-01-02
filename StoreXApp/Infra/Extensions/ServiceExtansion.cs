using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoraX.Infrastructure.Context;
using StoreX.Application.Contracts;
using StoreX.Application.Services.Concrete;
using StoreX.Application.Services.Contracts;
using StoreX.Entities.Concrete;
using StoreX.Infrastructure.Repositories.Concrete;
using StoreXApp.Models;

namespace StoreXApp.Infra.Extensions
{
    public static class ServiceExtansion
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
             services.AddDbContext<StoreXContext>(options =>
            {
                //not: options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),b=>b.MigrationAssebly("İstenilenYer")); şeklinde tanımlarsak migration dosyasını istediğimiz yerde oluştururuz.
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"));

                //Geliştirme aşamasında kullanıcı adı, şife gibi hassas bilgileri kontrol etmek, loglara bakabilmek için true olarak bırakılabilir. 
                options.EnableSensitiveDataLogging(true);
            });
            
            
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;

            })
                .AddEntityFrameworkStores<StoreXContext>();
        }
        public static void ConfigureSession(this IServiceCollection services )
        {
            //Session ifadeleri için service kayıtları
            services.AddDistributedMemoryCache(); //sunucu çalışırken önbellek sağlar
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreXApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Her kullanıcı için ayrı bir cart nesnesi oluşturulmalı
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }
     
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IProductService, ProductManagerService>();
            services.AddScoped<ICategoryService, CategoryManagerService>();
            services.AddScoped<IOrderService, OrderManagerService>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }
    }
}
