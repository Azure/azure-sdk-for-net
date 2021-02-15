using System;
using System.Threading.Tasks;

namespace SmokeTest.Samples
{
    public static class EventHubsApplicationInsightsLoggingTests
    {
        public static async Task RunTests()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("SAMPLE: IoT Hub Connection String Translation");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Functionalities to test: 2");
            Console.WriteLine("\t1.- Query IoT Hub for an Event Hubs connection string");
            Console.WriteLine("\t2.- Validate the connection string is accepted by Event Hubs");

            var connectionString = Environment.GetEnvironmentVariable("EVENT_HUBS_APP_INSIGHT_CONNECTION_STRING");
            var instrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATION_KEY");
            var eventHubName = "myeventhub";

            var retVal = await AzureEventSourceListenerEventHubsLogging.Program.Main(new[] { connectionString,eventHubName,instrumentationKey });

            if (retVal != 0)
            {
                throw new ApplicationException($"{ nameof(IotHubConnectionTests) } failed!");
            }
        }
    }
}
