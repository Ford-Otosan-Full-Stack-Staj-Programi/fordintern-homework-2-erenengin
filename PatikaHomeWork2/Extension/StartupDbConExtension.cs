using Microsoft.EntityFrameworkCore;


using Company.Data;

namespace Company.Api;

public static class StartupDbContextExtension
{
    public static void AddDbContextDI(this IServiceCollection services, IConfiguration configuration)
    {

        var dbConfig = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options => options
           .UseSqlServer(dbConfig)
           );


    }


}
