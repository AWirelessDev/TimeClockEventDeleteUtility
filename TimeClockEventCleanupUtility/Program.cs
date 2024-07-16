
using WorkdayTimetrackingLibrary;
using Microsoft.Extensions.DependencyInjection;
using timeClockEventCleanup_consoleApp;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

Console.WriteLine("Enter an HRAssociateOID:");
string hrAssociateOID = Console.ReadLine();

if (Guid.TryParse(hrAssociateOID, out Guid result))
{
    Console.WriteLine("HRAssociateOID is valid");
    Console.WriteLine(result);
    
}
else
{
    Console.WriteLine("HRAssociateOID is invalid");
    Console.WriteLine("Please enter a valid HRAssociateOID");   

}

Console.WriteLine("Enter a Start Date:");
string fromDate = Console.ReadLine(); 

if (fromDate != null && DateOnly.TryParse(fromDate, out DateOnly resultDate))
{
    Console.WriteLine("Start Date is valid");
}
else
{
    Console.WriteLine("Start Date is invalid");
    Console.WriteLine("Please enter a valid Start Date");
}



Console.WriteLine("Enter an End Date:");
string toDate = Console.ReadLine();

if (toDate != null && DateOnly.TryParse(toDate, out DateOnly resultToDate))
{
    Console.WriteLine("Start Date is valid");
}
else
{
    Console.WriteLine("Please enter a valid Start Date");
}

Console.WriteLine("====================================");
Console.WriteLine("The following values have been entered:");
Console.WriteLine(hrAssociateOID);
Console.WriteLine(fromDate);
Console.WriteLine(toDate);
Console.WriteLine("====================================");

IServiceCollection services = new ServiceCollection();
Startup startup = new Startup();
startup.ConfigureServices(services);
IServiceProvider serviceProvider = services.BuildServiceProvider();
var workdayApiService = serviceProvider.GetService<IWorkdayApiService>();

var timeClockEventCleanupService = new TimeClockEventCleanupUtility.TimeClockEventCleanupService(workdayApiService);

timeClockEventCleanupService.CleanupTimeClockEvents(hrAssociateOID!, DateOnly.Parse(fromDate), DateOnly.Parse(toDate));