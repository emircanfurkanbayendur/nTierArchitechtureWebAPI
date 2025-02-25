using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace WebAPI.ContextFactory
{
    //Bu sinif design time migration icin kullanilir.
    //Design time migration, projeyi build etmeden, calistirmadan migration almaktir. Proje gelistirme asamasinda iken kolaylik saglar.
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        //Migration yapmak icin iki seye ihtiyacimiz var. 1.si appsettings uzerindeki conn. string, 2.si DbContextOptionsBuilder
        // DbContextOptionsBuilder conn string'i kullanarak dbcontexti configure eder.
        public RepositoryContext CreateDbContext(string[] args)
        {
            //configurationBuilder ile appsettings.json dosyasindan connection string'i aliyoruz.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //DbContextOptionsBuilder ile dbcontexti configure ediyoruz. appsettings.json'dan aldigimiz connection string'i buraya veriyoruz.
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),

                //MigrationAssembly metodu migration dosyalarinin nerede olacagini belirtir.
                //Migration dosyalari WebAPI projesinde olacagi icin WebAPI projesini belirtiyoruz.
                prj => prj.MigrationsAssembly("WebAPI"));

            return new RepositoryContext(builder.Options);
        }
    }
}
