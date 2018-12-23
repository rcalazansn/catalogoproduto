using API.Application;
using API.Data;
using API.Middlewares;
using API.Repositories;
using API.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CatalagoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            services.AddTransient<ErrorHandlerMiddleware>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Catalogo", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //var configurationBuilder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddEnvironmentVariables();

            //Configuration = configurationBuilder.Build();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalogo API V1");
                c.RoutePrefix = string.Empty;

            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseMvc();



        }
    }
}
