using Company.Base;
using Company.Api.Extension;

namespace Company.Api;
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public static JwtConfig JwtConfig { get; private set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
        services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));




        services.AddCors();

        services.AddMemoryCache();
        services.AddDbContextDI(Configuration);
        services.AddServices();
        services.AddControllers();
        services.AddJwtAuthentication();
        services.AddCustomSwagger();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Homework1 v2"));
        }
        app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseAuthorization();



        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}