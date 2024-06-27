
using Microsoft.EntityFrameworkCore;
using Online_Job.Models;

namespace Online_Job
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddCors(CorsOptions =>
            {
                CorsOptions.AddPolicy("MyPolicy", CorsPolicyBuilder =>
                {
                    CorsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            //Custom Services 


            var app = builder.Build();

            // Configure the HTTP request pipeline.
         //   if (app.Environment.IsDevelopment())
          //  {
                app.UseSwagger();
                app.UseSwaggerUI();
         //   }

            app.UseStaticFiles(); // html , images 

            app.UseCors("MyPolicy"); // policy block and allow

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}