using Ardalis.SmartEnum.JsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkdayTimetrackingLibrary;
using WorkdayTimetrackingLibrary.Models.Enums;
using WorkdayTimetrackingLibrary.Models.FunctionApiRequestModels;

namespace TimeClockEventCleanupUtility
{
    public class TimeClockEventCleanupService
    {
        private readonly IWorkdayApiService _workdayAPIService;

        public TimeClockEventCleanupService(IWorkdayApiService workdayAPIService)
        {
            _workdayAPIService = workdayAPIService;
        }

        public void CleanupTimeClockEvents(string hrAssociateOID, DateOnly fromDate, DateOnly toDate)
        {
            // Call Workday API to get TimeClockEvents
            var timeClockEvents = _workdayAPIService.GetTimeClockEventsAsync(hrAssociateOID, fromDate, toDate);
            // Filter TimeClockEvents based on hrAssociateOID, fromDate, toDate
            Console.WriteLine("TimeClockEvents:");
            Console.WriteLine("====================================");
            List<string> deleteListString = new List<string>();
            var timeClockEventsList = timeClockEvents.Result.Events;
            foreach (var timeClockEvent in timeClockEventsList)
            {
                deleteListString.Add(timeClockEvent.Id);
            }
            // Delete TimeClockEvents
            Console.WriteLine(timeClockEventsList);
            var payloadRequest = new BatchTimeClockEventPayloadRequest();
            payloadRequest.TimeClockEventDeletionList = deleteListString;
            payloadRequest.TimeClockEventCreationList = new List<TimeClockEventPayloadRequest>();
            payloadRequest.TimeClockEventUpdateList = new List<TimeClockEventPayloadRequest>();

           var response =  _workdayAPIService.BatchTimeClockEventsAsync(payloadRequest);

            //Delete from Audit Table



            Console.WriteLine("====================================");
            Console.WriteLine("TimeClockEvents Deleted:");
            Console.WriteLine(response.Result.ErrorMessage);
            Console.WriteLine("====================================");
        }
    }
/*    public async void DeleteTimeClockAudit(TimeClockAuditRequestDto timeClockAuditRequestDto)
    {
        using (var connection = new SqlConnection(DbConfigurationHelper.LocationGeofenceConnectionString))
        {
            try
            {
                var data = timeClockAuditRequestDto.ToDataTable();
                var param = new { @TimeClockAudit = data.AsTableValuedParameter("[dbo].[udt_TimeClockAudit]") };
                await connection.QueryAsync("[dbo].[usp_Delete_TimeClockMetadata]", param: param, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }*/
}
