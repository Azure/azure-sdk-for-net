using Azure.Core.Diagnostics;
using System;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AzureEventSourceListenerEventHubsLogging
{
    public static class Program
    {
        /// <summary>
        ///   The method invoked as the main entry point for execution.
        /// </summary>
        ///
        /// <param name="args">The arguments passed to the application on the command line.</param>
        ///
        /// <returns>Zero for a successful run, non-zero when an exception is encountered.</returns>
        ///
        /// <remarks>
        ///   If arguments are passed, the first argument is assumed to be the Event Hub connection string; the second is the EventHubName 
        ///   and the third argument is Application Insight instrumentation Keyn
        ///   the rest of arguments are ignored.  If no arguments were present, an interactive prompt will collect the needed parameters.
        /// </remarks>
        ///
        public static async Task Main(string[] args)    
        {
            var connectionString = default(string);
            var eventHubName = default(string);
            var instrumentationKey = default(string);
            // if we have more than two argument passed we asusme that the first is the connection string , 
            // the second is the event hub name and the third is intrumentation key for application insights.
            if (args.Count() > 2)
            {
                connectionString = args[0];
                eventHubName = args[1];
                instrumentationKey = args[2];
            }

            // If there was no connection string provided, then prompt for one.
            while (string.IsNullOrEmpty(connectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs that you'd like to use and then press Enter: ");
                connectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // If there was no eventHubName provided, then prompt for one.
            while (string.IsNullOrEmpty(eventHubName))
            {
                Console.Write("Please provide the Event Hub Name that you'd like to use and then press Enter: ");
                eventHubName = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // If there was no instrumentation Key provided, then prompt for one.
            while (string.IsNullOrEmpty(instrumentationKey))
            {
                Console.Write("Please provide the Event Hub Name that you'd like to use and then press Enter: ");
                instrumentationKey = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            //Create ApplicationInsights Client.
            var telemetryClient = new TelemetryClient(new TelemetryConfiguration(instrumentationKey));
            
            //Create EventHub Producer Client.
            var producerClient = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                // Setup a listener to monitor logged events.
                var listener = new AzureEventSourceListener((args, message) =>
                {
                    // Add condition to manipulate only events related to EventHubs.
                    if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                    {
                        var properties = GetPropertiesDictionnary(args.PayloadNames, args.Payload);
                        var level = args.Level.GetSeverityLevel();
                        var traceMessage = string.Format(args.Message, args.Payload.ToArray());
                        telemetryClient.TrackTrace($"Sample_AzureEventSourceListener | {traceMessage}", level, properties);
                        telemetryClient.Flush();
                    }
                }, EventLevel.LogAlways);

                // Creating a producer client using its default set of options.
                // We will publish three small batch events.

                Console.WriteLine("Preparing event batch...");
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
                // Add events to the batch. An event is a represented by a collection of bytes and metadata.
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("The middle event is this one")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("The event batch has been published.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An exception of type { ex.GetType().Name } occurred.  Message:{ Environment.NewLine }\t{ ex.Message }");
            }
            finally
            {
                await producerClient.CloseAsync();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Exiting...");
            }
        }

        /// <summary>
        /// The method merge two list of payloads names and values to return one dictionary.
        /// </summary>
        /// <param name="payloadNames">List of strings that represent the property names of the event.</param>
        /// <param name="payload">List of objects that represent the property values of the event.</param>
        /// <returns>Dictionary generated from the two list in parameter, empty dictionary if two lists are not the same length.</returns>
        private static Dictionary<string, string> GetPropertiesDictionnary(ReadOnlyCollection<string> payloadNames, ReadOnlyCollection<object> payload)
        {
            var response = new Dictionary<string, string>();
            if (payloadNames.Count != payload.Count)
            {
                return response;
            }

            for (int i = 0; i < payloadNames.Count; i++)
            {
                response.Add(payloadNames[i], payload[i].ToString());
            }
            return response;
        }
    }
}
