// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}
using AutoMapper;
using Azure.Messaging.EventGrid;
using ExampleProject.Core.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExampleProject.Function
{
    public class ExampleFunction
    {
        private readonly IEmployeeService _EmployeeService;
        private readonly IMapper _mapper;

        public ExampleFunction(IEmployeeService EmployeeService, IMapper mapper)
        {
            _EmployeeService = EmployeeService;
            _mapper = mapper;
        }

        [FunctionName("ExampleFunction")]
        public async Task Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
            var result = await _EmployeeService.GetEmployeeById(1);
            log.LogInformation(result?.ToString());
        }

    }
}
