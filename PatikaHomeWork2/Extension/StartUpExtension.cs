using AutoMapper;
using Company.Data;
using Company.Service;
using Company.Service;

namespace Company.Api;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        // uow
        services.AddScoped<IUnitOfWork, UnitOfWork>();


      
       

        // repos
        services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

        // services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenManagementService, TokenManagementService>();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }

    
}
