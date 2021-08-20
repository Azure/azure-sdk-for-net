// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Identity;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests.Snippets
{
    /// <summary>
    ///   The suite of tests defining the snippets used in the Event Hubs
    ///   Sample10_AzureEventSourceListener sample.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class Sample10_AzureEventSourceListenerTests
    {
        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task ConsoleListener()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_EventBatch

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

            EventHubProducerClient producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                Debug.WriteLine("The Event Hub has the following properties:");
                Debug.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Debug.WriteLine($"\tThe Event Hub was created at: { properties.CreatedOn }, in UTC.");
                Debug.WriteLine($"\tThe following partitions are available: [{ string.Join(", ", properties.PartitionIds) }]");
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task TraceListener()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_EventBatch

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.LogAlways);

            EventHubProducerClient producer = new EventHubProducerClient(connectionString, eventHubName);

            try
            {
                EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                Debug.WriteLine("The Event Hub has the following properties:");
                Debug.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Debug.WriteLine($"\tThe Event Hub was created at: { properties.CreatedOn }, in UTC.");
                Debug.WriteLine($"\tThe following partitions are available: [{ string.Join(", ", properties.PartitionIds) }]");
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }

        /// <summary>
        ///   Performs basic smoke test validation of the contained snippet.
        /// </summary>
        ///
        [Test]
        public async Task CustomListener()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample04_EventBatch

#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif

            using AzureEventSourceListener customListener = new AzureEventSourceListener((args, message) =>
            {
                if (args.EventSource.Name.StartsWith("Azure-Identity"))
                {
                    Trace.WriteLine(message);
                }
                else if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    Console.WriteLine(message);
                }
            }, EventLevel.LogAlways);

            EventHubsConnectionStringProperties connectionStringProperties = EventHubsConnectionStringProperties.Parse(connectionString);

            TokenCredential credential = new DefaultAzureCredential();

            var producer = new EventHubProducerClient(
                connectionStringProperties.FullyQualifiedNamespace,
                connectionStringProperties.EventHubName ?? eventHubName,
                credential);

            try
            {
                EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                Debug.WriteLine("The Event Hub has the following properties:");
                Debug.WriteLine($"\tThe path to the Event Hub from the namespace is: { properties.Name }");
                Debug.WriteLine($"\tThe Event Hub was created at: { properties.CreatedOn }, in UTC.");
                Debug.WriteLine($"\tThe following partitions are available: [{ string.Join(", ", properties.PartitionIds) }]");
            }
            finally
            {
                await producer.CloseAsync();
            }

            #endregion
        }
    }
}
