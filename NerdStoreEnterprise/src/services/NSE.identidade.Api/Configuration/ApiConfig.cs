using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.Identidade.API.Configuration
{

    public class ApiConfig
    {
        public static IserviceCollection AddApiConfiguration(this IserviceCollection services)
        {
            builder.Services.AddControllers();
            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder App, IwebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



            return app;
        }
    }
}
