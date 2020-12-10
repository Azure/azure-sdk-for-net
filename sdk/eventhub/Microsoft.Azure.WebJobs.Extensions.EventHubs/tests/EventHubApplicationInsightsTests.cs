// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    /// <summary>
    /// https://github.com/microsoft/ApplicationInsights-dotnet/blob/004dbd78cecd9a380688288d8a89e152e2e819c6/WEB/Src/DependencyCollector/DependencyCollector/Implementation/AzureSdk/AzureSdkDiagnosticsEventHandler.cs
    /// https://github.com/Azure/azure-webjobs-sdk/blob/f0c9d0998ced69c8baf02fedb4e7f9184e0e05c9/src/Microsoft.Azure.WebJobs.Logging.ApplicationInsights/ApplicationInsightsLogger.cs
    /// </summary>
    public class EventHubApplicationInsightsTests : IDisposable
    {
        private const string TestHubName = "%webjobstesthub%";
        private const int Timeout = 30000;
        private static EventWaitHandle _eventWait;
        private readonly TestTelemetryChannel _channel = new TestTelemetryChannel();
        private static string _testPrefix;

        /// <summary>The active Event Hub resource scope for the test fixture.</summary>
        private EventHubScope _eventHubScope;

        /// <summary>The active Blob storage resource scope for the test fixture.</summary>
        private StorageScope _storageScope;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [SetUp]
        public async Task FixtureSetUp()
        {
            _eventWait = new ManualResetEvent(initialState: false);
            _eventHubScope = await EventHubScope.CreateAsync(2);
            _storageScope = await StorageScope.CreateAsync();
            _eventWait = new ManualResetEvent(initialState: false);
            _testPrefix = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///   Performs the tasks needed to cleanup the test fixture after all
        ///   tests have run.  This method runs once for the entire fixture.
        /// </summary>
        ///
        [TearDown]
        public async Task FixtureTearDown()
        {
            await Task.WhenAll
            (
                _eventHubScope.DisposeAsync().AsTask(),
                _storageScope.DisposeAsync().AsTask()
            );
        }

        private readonly JsonSerializerSettings jsonSettingThrowOnError = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Error,
            ReferenceLoopHandling = ReferenceLoopHandling.Error,
            NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include,
        };

        [Test]
        public async Task EventHub_SingleDispatch()
        {
            using (var host = BuildHost<EventHubTestSingleDispatchJobs>())
            {
                await host.StartAsync();

                var method = typeof(EventHubTestSingleDispatchJobs).GetMethod("SendEvent_TestHub", BindingFlags.Static | BindingFlags.Public);
                await host.GetJobHost().CallAsync(method, new { input = _testPrefix });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();
            List<DependencyTelemetry> dependencies = _channel.Telemetries.OfType<DependencyTelemetry>().ToList();

            // We expect 1 message span and 1 send span
            var messageDependencies = dependencies.Where(d => d.Name == "EventHubs.Message").ToList();
            var sendDependency = dependencies.Single(d => d.Name == "EventHubProducerClient.Send");

            var sendRequest = requests.Single(r => r.Context.Operation.Name == "SendEvent_TestHub");
            var sendRequestOperationId = sendRequest.Context.Operation.Id;

            var processRequest = requests.Single(r => r.Context.Operation.Name == "ProcessSingleEvent");

            ValidateEventHubDependency(
                sendDependency,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                "EventHubProducerClient.Send",
                "SendEvent_TestHub",
                sendRequestOperationId,
                sendRequest.Id,
                LogCategories.Bindings);

            ValidateEventHubRequest(
                processRequest,
                true,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                "ProcessSingleEvent",
                null,
                null);

            Assert.AreEqual(1, messageDependencies.Count);
            foreach (var messageDependency in messageDependencies)
            {
                Assert.AreEqual(sendRequestOperationId, messageDependency.Context.Operation.Id);
            }

            Assert.True(processRequest.Properties.TryGetValue("_MS.links", out var linksStr));
            var links = JsonConvert.DeserializeObject<TestLink[]>(linksStr, jsonSettingThrowOnError).ToArray();
            Assert.AreEqual(1, links.Length);
            foreach (var link in links)
            {
                Assert.True(messageDependencies.Any(m => m.Id == link.id && m.Context.Operation.Id == link.operation_Id));
            }
        }

        [Test]
        public async Task EventHub_MultipleDispatch_BatchSend()
        {
            using (var host = BuildHost<EventHubTestMultipleDispatchJobs>())
            {
                await host.StartAsync();

                var method = typeof(EventHubTestMultipleDispatchJobs).GetMethod("SendEvents_TestHub", BindingFlags.Static | BindingFlags.Public);
                await host.GetJobHost().CallAsync(method, new { input = _testPrefix });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();
            List<DependencyTelemetry> dependencies = _channel.Telemetries.OfType<DependencyTelemetry>().ToList();

            // We expect 5 message spans and 1 send span
            var messageDependencies = dependencies.Where(d => d.Name == "EventHubs.Message").ToList();
            var sendDependency = dependencies.Single(d => d.Name == "EventHubProducerClient.Send");

            Assert.AreEqual(5, messageDependencies.Count);

            var manualCallRequest = requests.Single(r => r.Context.Operation.Name == "SendEvents_TestHub");
            var manualOperationId = manualCallRequest.Context.Operation.Id;

            ValidateEventHubDependency(
                sendDependency,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                "EventHubProducerClient.Send",
                "SendEvents_TestHub",
                manualOperationId,
                manualCallRequest.Id,
                LogCategories.Bindings);

            var ehTriggerRequests = requests.Where(r => r.Context.Operation.Name == "ProcessMultipleEvents").ToList();
            List<TestLink> allLinks = new List<TestLink>();

            // EventHub can batch events in a different ways
            foreach (var ehTriggerRequest in ehTriggerRequests)
            {
               ValidateEventHubRequest(
                    ehTriggerRequest,
                    true,
                    EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                    _eventHubScope.EventHubName,
                    "ProcessMultipleEvents",
                    null,
                    null);

                Assert.NotNull(ehTriggerRequest.Context.Operation.Id);
                Assert.Null(ehTriggerRequest.Context.Operation.ParentId);

                Assert.True(ehTriggerRequest.Properties.TryGetValue("_MS.links", out var linksStr));
                var currentRequestAndTestLinks = JsonConvert.DeserializeObject<TestLink[]>(linksStr, jsonSettingThrowOnError).ToArray();
                allLinks.AddRange(currentRequestAndTestLinks);

                Assert.True(ehTriggerRequest.Properties.TryGetValue("receivedMessages", out var receivedMessagesPropStr));
                Assert.AreEqual(int.Parse(receivedMessagesPropStr), currentRequestAndTestLinks.Length);
            }

            Assert.AreEqual(EventHubTestMultipleDispatchJobs.LinksCount.Sum(), allLinks.Count);
            foreach (var link in allLinks)
            {
                Assert.True(messageDependencies.Any(m => m.Id == link.id && m.Context.Operation.Id == link.operation_Id));
            }
        }

        [Test]
        public async Task EventHub_MultipleDispatch_IndependentMessages()
        {
            // send individual messages via EventHub client, process batch by host
            var ehClient = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);

            var messages = new EventData[5];
            var expectedLinks = new TestLink[messages.Length];

            for (int i = 0; i < messages.Length; i++)
            {
                var operationId = ActivityTraceId.CreateRandom().ToHexString();
                var spanId = ActivitySpanId.CreateRandom().ToHexString();
                expectedLinks[i] = new TestLink
                {
                    operation_Id = operationId,
                    id = spanId
                };

                messages[i] = new EventData(Encoding.UTF8.GetBytes(_testPrefix + i))
                {
                    Properties = {["Diagnostic-Id"] = $"00-{operationId}-{spanId}-01"}
                };
            }

            await ehClient.SendAsync(messages);

            using (var host = BuildHost<EventHubTestMultipleDispatchJobs>())
            {
                await host.StartAsync();
                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();

            var ehTriggerRequests = requests.Where(r => r.Context.Operation.Name == "ProcessMultipleEvents");

            List<TestLink> actualLinks = new List<TestLink>();
            foreach (var ehTriggerRequest in ehTriggerRequests)
            {
                ValidateEventHubRequest(
                    ehTriggerRequest,
                    true,
                    EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                    _eventHubScope.EventHubName,
                    "ProcessMultipleEvents",
                    null,
                    null);

                Assert.NotNull(ehTriggerRequest.Context.Operation.Id);
                Assert.Null(ehTriggerRequest.Context.Operation.ParentId);
                Assert.True(ehTriggerRequest.Properties.TryGetValue("_MS.links", out var linksStr));
                actualLinks.AddRange(JsonConvert.DeserializeObject<TestLink[]>(linksStr, jsonSettingThrowOnError));
            }

            Assert.AreEqual(expectedLinks.Length, actualLinks.Count);
            foreach (var link in actualLinks)
            {
                Assert.True(expectedLinks.Any(l => l.operation_Id == link.operation_Id && l.id == link.id));
            }
        }

        private void ValidateEventHubRequest(
            RequestTelemetry request,
            bool success,
            string endpoint,
            string entityName,
            string operationName,
            string operationId,
            string parentId)
        {
            Assert.AreEqual(request.Source, $"{endpoint}/{entityName}");
            Assert.Null(request.Url);

            Assert.True(request.Properties.ContainsKey(LogConstants.FunctionExecutionTimeKey));
            Assert.True(double.TryParse(request.Properties[LogConstants.FunctionExecutionTimeKey], out double functionDuration));
            Assert.True(request.Duration.TotalMilliseconds >= functionDuration);

            Assert.AreEqual(LogCategories.Results, request.Properties[LogConstants.CategoryNameKey]);
            Assert.AreEqual((success ? LogLevel.Information : LogLevel.Error).ToString(), request.Properties[LogConstants.LogLevelKey]);
            Assert.NotNull(request.Name);
            Assert.NotNull(request.Id);

            if (operationId != null)
            {
                Assert.AreEqual(operationId, request.Context.Operation.Id);
            }

            if (parentId != null)
            {
                Assert.AreEqual(parentId, request.Context.Operation.ParentId);
            }

            Assert.AreEqual(operationName, request.Context.Operation.Name);
            Assert.AreEqual(operationName, request.Name);

            Assert.True(request.Properties.ContainsKey(LogConstants.InvocationIdKey));

            // EventHub does not populate Trigger reason
            Assert.False(request.Properties.ContainsKey(LogConstants.TriggerReasonKey));

            StringAssert.StartsWith("webjobs:", request.Context.GetInternalContext().SdkVersion);

            Assert.AreEqual(success, request.Success);
            Assert.AreEqual("0", request.ResponseCode);

            Assert.False(request.Properties.Any(p => p.Key == LogConstants.SucceededKey));
        }

        private void ValidateEventHubDependency(
            DependencyTelemetry dependency,
            string endpoint,
            string entityName,
            string name,
            string operationName,
            string operationId,
            string parentId,
            string category)
        {
            Assert.AreEqual($"{endpoint}/{entityName}", dependency.Target);
            Assert.AreEqual("Azure Event Hubs", dependency.Type);
            Assert.AreEqual(name, dependency.Name);
            Assert.True(dependency.Success);
            Assert.True(string.IsNullOrEmpty(dependency.Data));

            Assert.AreEqual(category, dependency.Properties[LogConstants.CategoryNameKey]);
            Assert.AreEqual(LogLevel.Information.ToString(), dependency.Properties[LogConstants.LogLevelKey]);
            Assert.NotNull(dependency.Target);
            Assert.NotNull(dependency.Name);
            Assert.NotNull(dependency.Id);

            if (operationId != null)
            {
                Assert.AreEqual(operationId, dependency.Context.Operation.Id);
            }

            Assert.AreEqual(operationName, dependency.Context.Operation.Name);

            if (parentId != null)
            {
                Assert.AreEqual(parentId, dependency.Context.Operation.ParentId);
            }

            Assert.True(dependency.Properties.ContainsKey(LogConstants.InvocationIdKey));
        }

        public class EventHubTestSingleDispatchJobs
        {
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName)] out EventData evt)
            {
                evt = new EventData(Encoding.UTF8.GetBytes(input));
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName)] string evt)
            {
                if (evt.StartsWith(_testPrefix))
                {
                    _eventWait.Set();
                }
            }
        }

        public class EventHubTestMultipleDispatchJobs
        {
            public static List<int> LinksCount = new List<int>();
            public const int EventCount = 5;
            private static readonly object lck = new object();
            private static int messagesCount = 0;
            public static void SendEvents_TestHub(string input, [EventHub(TestHubName)] out EventData[] events)
            {
                LinksCount.Clear();
                messagesCount = 0;
                events = new EventData[EventCount];
                for (int i = 0; i < EventCount; i++)
                {
                    var evt = new EventData(Encoding.UTF8.GetBytes(input + i));
                    events[i] = evt;
                }
            }

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName)] string[] events)
            {
                var eventsFromCurrentTest = events.Where(e => e.StartsWith(_testPrefix)).ToArray();
                Activity.Current.AddTag("receivedMessages", eventsFromCurrentTest.Length.ToString());
                lock (lck)
                {
                    messagesCount += eventsFromCurrentTest.Length;

                    if (eventsFromCurrentTest.Length > 0)
                    {
                        LinksCount.Add(eventsFromCurrentTest.Length);
                    }

                    if (messagesCount >= EventCount)
                    {
                        _eventWait.Set();
                    }
                }
            }
        }

        private IHost BuildHost<T>()
        {
            var eventHubName = _eventHubScope.EventHubName;

            IHost host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"webjobstesthub", eventHubName},
                        {"AzureWebJobsStorage", StorageTestEnvironment.Instance.StorageConnectionString}
                    });
                })
                .ConfigureDefaultTestHost<T>(b =>
                {
                    b.AddEventHubs(options =>
                    {
                        options.CheckpointContainer = _storageScope.ContainerName;
                        // Speedup shutdown
                        options.EventProcessorOptions.MaximumWaitTime = TimeSpan.FromSeconds(5);
                        options.AddSender(eventHubName, EventHubsTestEnvironment.Instance.EventHubsConnectionString);
                        options.AddReceiver(eventHubName, EventHubsTestEnvironment.Instance.EventHubsConnectionString);
                    });
                })
                .ConfigureLogging(b =>
                {
                    b.SetMinimumLevel(LogLevel.Information);
                    b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = "mock ikey");
                })
                .Build();

            TelemetryConfiguration telemetryConfiguration = host.Services.GetService<TelemetryConfiguration>();
            telemetryConfiguration.TelemetryChannel = _channel;

            return host;
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }

        public class TestTelemetryChannel : ITelemetryChannel, ITelemetryModule
        {
            public ConcurrentBag<ITelemetry> Telemetries = new ConcurrentBag<ITelemetry>();

            public bool? DeveloperMode { get; set; }

            public string EndpointAddress { get; set; }

            public void Dispose()
            {
            }

            public void Flush()
            {
            }

            public void Send(ITelemetry item)
            {
                Telemetries.Add(item);
            }

            public void Initialize(TelemetryConfiguration configuration)
            {
            }
        }

        private class TestLink
        {
            public string operation_Id { get; set; }
            public string id { get; set; }
        }
    }
}
