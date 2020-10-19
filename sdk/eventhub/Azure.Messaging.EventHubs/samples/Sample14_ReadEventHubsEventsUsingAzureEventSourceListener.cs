// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Samples.Infrastructure;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace Azure.Messaging.EventHubs.Samples
{
    /// <summary>
    /// An example of catching all Event Hubs events using AzureEventSourceListener and send them to Application Insights.
    /// </summary>
    public class Sample14_ReadEventHubsEventsUsingAzureEventSourceListener : IEventHubsApplicationInsightsSample
    {
        /// <summary>
        ///   The name of the sample.
        /// </summary>
        ///
        public string Name => nameof(Sample14_ReadEventHubsEventsUsingAzureEventSourceListener);

        /// <summary>
        ///   A short description of the sample.
        /// </summary>
        ///
        public string Description => "An example of catching all Event Hubs events using AzureEventSourceListener and send them to Application Insights.";

        public async Task RunAsync(string connectionString,
                      string eventHubName,
                      string instrumentationKey)
        {
            // Setup a listener to monitor logged events.
            var listener = new AzureEventSourceListener((args, message) =>
            {
                // Add condition to manipulate only events related to EventHubs.
                if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    TelemetryConfiguration configuration = TelemetryConfiguration.CreateDefault();
                    configuration.InstrumentationKey = instrumentationKey;
                    var telemetryClient = new TelemetryClient(configuration);
                    var properties = args.PayloadNames.Zip(args.Payload, (k, v) => new { Key = k, Value = v })
                      .ToDictionary(x => x.Key, x => x.Value.ToString());
                    var level = GetSeverityLevelFromEventLevel(args.Level);
                    var traceMessage = string.Format(args.Message, args.Payload.ToArray());
                    telemetryClient.TrackTrace($"Sample_14 AzureEventSourceListener | {traceMessage}", level, properties);
                }
            }, EventLevel.LogAlways);

            // Creating a producer client using its default set of options.
            // We will publish three small batch events.

            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                Console.WriteLine("Preparing event batch...");
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                // Add events to the batch. An event is a represented by a collection of bytes and metadata.
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Hello, Event Hubs!")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("The middle event is this one")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Goodbye, Event Hubs!")));
                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("The event batch has been published.");
            }
        }

        private SeverityLevel GetSeverityLevelFromEventLevel(EventLevel eventEntry)
        {
            switch (eventEntry)
            {
                case EventLevel.Verbose:
                    return SeverityLevel.Verbose;
                case EventLevel.Informational:
                    return SeverityLevel.Information;
                case EventLevel.Warning:
                    return SeverityLevel.Warning;
                case EventLevel.Error:
                    return SeverityLevel.Error;
                case EventLevel.Critical:
                    return SeverityLevel.Critical;
                default:
                    return SeverityLevel.Information;
            }
        }
    }

}
