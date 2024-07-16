using WorkdayTimetrackingLibrary;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(fn_workday_timetracking_api.Startup))]
namespace timeClockEventCleanup_consoleApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.RegisterWorkdayTimeTrackingServices();
            builder.Services.AddLogging();

        }
    }
}
