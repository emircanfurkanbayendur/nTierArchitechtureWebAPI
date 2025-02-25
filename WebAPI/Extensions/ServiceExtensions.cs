using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions
{
    // Bu class'ı new'lemeye gerek olmasın diye static yaptık.
    // Program.cs içinde servisleri tek tek eklemek yerine burada topluca ekleyip,
    // sadece extension methodunu çağırarak işleri kolaylaştırıyoruz.
    public static class ServiceExtensions
    {
        // hangi tipi genisletmek istiyorsak this anahtar sozcugu ile parametrede veriyoruz.
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) 
        {
            // Bu connection string'i kullanarak RepositoryContext'i configure ediyoruz.
            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        // RepositoryManager sınıfını ekliyoruz.
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            // RepositoryManager sınıfını ekliyoruz.
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            // ServiceManager sınıfını ekliyoruz.
            services.AddScoped<IServiceManager, ServiceManager>();
        }

    }
}
