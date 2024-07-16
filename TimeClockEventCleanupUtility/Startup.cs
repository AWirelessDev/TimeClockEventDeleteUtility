using WorkdayTimetrackingLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

//[assembly: FunctionsStartup(typeof(timeClockEventCleanup_consoleApp.Startup))]
namespace timeClockEventCleanup_consoleApp
{
    public class Startup  
    {
        private readonly IConfiguration _configuration;

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                    .AddJsonFile($"local.settings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            _configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterWorkdayTimeTrackingServices();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(_configuration);

        }
 
    }
}
