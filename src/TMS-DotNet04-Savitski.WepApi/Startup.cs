using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using TMS_DotNet04_Savitski.WepApi.Extensions;
using TMS_DotNet04_Savitski.WepApi.Interfaces;
using TMS_DotNet04_Savitski.WepApi.Services;

namespace TMS_DotNet04_Savitski.WepApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddScoped<ICommandService, CommandService>();
            services.AddTelegramBotClient(_configuration);
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }); ;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}