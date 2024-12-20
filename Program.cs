
using LazyEagerLoadingPOC.Data;
using LazyEagerLoadingPOC.Repositories;
using LazyEagerLoadingPOC.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

namespace LazyEagerLoadingPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EmployeeContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")).UseLazyLoadingProxies();
            });

            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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
