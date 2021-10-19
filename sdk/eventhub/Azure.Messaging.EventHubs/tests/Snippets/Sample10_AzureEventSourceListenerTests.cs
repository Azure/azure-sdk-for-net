﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
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

            #region Snippet:EventHubs_Sample10_ConsoleListener
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            using AzureEventSourceListener consoleListener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

            try
            {
                var events = new[]
                {
                    new EventData("EventOne"),
                    new EventData("EventTwo")
                };

                await producer.SendAsync(events);
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

            #region Snippet:EventHubs_Sample10_TraceListener
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            using AzureEventSourceListener traceListener = AzureEventSourceListener.CreateTraceLogger(EventLevel.LogAlways);

            try
            {
                var events = new[]
                {
                    new EventData("EventOne"),
                    new EventData("EventTwo")
                };

                await producer.SendAsync(events);
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
        public async Task CustomListenerWithFilter()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample10_CustomListenerWithFilter
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
#endif
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            using AzureEventSourceListener customListener = new AzureEventSourceListener((args, message) =>
            {
                if (args.EventSource.Name.StartsWith("Azure-Identity") && args.Level == EventLevel.Verbose)
                {
                    Trace.WriteLine(message);
                }
                else if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    switch (args.EventId)
                    {
                        case 3:   // Publish Start
                        case 4:   // Publish Complete
                        case 5:   // Publish Error
                            Console.WriteLine(message);
                            break;
                    }
                }
            }, EventLevel.LogAlways);

            try
            {
                var events = new[]
                {
                    new EventData("EventOne"),
                    new EventData("EventTwo")
                };

                await producer.SendAsync(events);
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
        public async Task CustomListenerWithFile()
        {
            await using var scope = await EventHubScope.CreateAsync(1);

            #region Snippet:EventHubs_Sample10_CustomListenerWithFile
#if SNIPPET
            var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
            var eventHubName = "<< NAME OF THE EVENT HUB >>";
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            using Stream stream = new FileStream("<< PATH TO THE FILE >>", FileMode.OpenOrCreate, FileAccess.Write);
#else
            var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
            var eventHubName = scope.EventHubName;
            var producer = new EventHubProducerClient(connectionString, eventHubName);

            using Stream stream = new MemoryStream();
#endif

            using StreamWriter streamWriter = new StreamWriter(stream)
            {
                AutoFlush = true
            };

            using AzureEventSourceListener customListener = new AzureEventSourceListener((args, message) =>
            {
                if (args.EventSource.Name.StartsWith("Azure-Messaging-EventHubs"))
                {
                    switch (args.Level)
                    {
                        case EventLevel.Error:
                            streamWriter.Write(message);
                            break;
                        default:
                            Console.WriteLine(message);
                            break;
                    }
                }
            }, EventLevel.LogAlways);

            try
            {
                var events = new[]
                {
                    new EventData("EventOne"),
                    new EventData("EventTwo")
                };

                await producer.SendAsync(events);
            }
            finally
            {
                await producer.CloseAsync();
            }
            #endregion
        }
    }
}
