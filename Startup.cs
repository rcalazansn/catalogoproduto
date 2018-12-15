using System.IO;
using ApiProdutos.Data;
using ApiProdutos.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiProdutos
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();

            services.AddScoped<CatalogoContext, CatalogoContext>();
            services.AddTransient<ProdutoRepository, ProdutoRepository>();

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }

    public static class Settings
    {
        public static string ConnectionString = @"Server=.\sqlexpress;Database=catalogo;User ID={user};Password={password};";
    }
}
