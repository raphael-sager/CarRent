
using CarRent.API.CustomerManagement.Domain;
using CarRent.API.CustomerManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CarRent.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.AddDbContext<CustomerContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("ZbwCarrentContext"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var scope = app.Services.CreateScope();

            var scopeContext = scope.ServiceProvider.GetService<CustomerContext>();
            scopeContext.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}