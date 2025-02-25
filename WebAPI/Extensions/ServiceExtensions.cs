using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

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

    }
}
