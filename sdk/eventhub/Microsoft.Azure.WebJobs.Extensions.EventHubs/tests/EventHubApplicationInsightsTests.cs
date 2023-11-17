// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    /// <summary>
    /// This test effectively validates that logic from
    /// https://github.com/microsoft/ApplicationInsights-dotnet/blob/004dbd78cecd9a380688288d8a89e152e2e819c6/WEB/Src/DependencyCollector/DependencyCollector/Implementation/AzureSdk/AzureSdkDiagnosticsEventHandler.cs
    /// and
    /// https://github.com/Azure/azure-webjobs-sdk/blob/f0c9d0998ced69c8baf02fedb4e7f9184e0e05c9/src/Microsoft.Azure.WebJobs.Logging.ApplicationInsights/ApplicationInsightsLogger.cs
    /// work correctly together in addition to DiagnosticScope logic inside Azure.Messaging.EventHubs
    /// </summary>
    [NonParallelizable]
    [LiveOnly(true)]
    public class EventHubApplicationInsightsTests : WebJobsEventHubTestBase
    {
        private static EventWaitHandle _eventWait;
        private TestTelemetryChannel _channel;

        [SetUp]
        public void SetUp()
        {
            _eventWait = new ManualResetEvent(initialState: false);
            _channel = new TestTelemetryChannel();

            EventHubTestMultipleDispatchJobs.LinksCount.Clear();
            EventHubTestMultipleDispatchJobs.MessagesCount = 0;
        }

        [TearDown]
        public void TearDown()
        {
            _eventWait.Dispose();
            _channel.Dispose();
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
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobs>();
            using (host)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobs.SendEvent_TestHub), new { input = "data" });
                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();
            List<DependencyTelemetry> dependencies = _channel.Telemetries.OfType<DependencyTelemetry>().ToList();

            // We expect 1 message span and 1 send span
            var messageDependencies = dependencies.Where(d => d.Name == "Message").ToList();
            var sendDependency = dependencies.Single(d => d.Name == "EventHubProducerClient.Send");

            var sendRequest = requests.Single(r => r.Context.Operation.Name == nameof(EventHubTestSingleDispatchJobs.SendEvent_TestHub));
            var sendRequestOperationId = sendRequest.Context.Operation.Id;

            var processRequest = requests.Single(r => r.Context.Operation.Name == nameof(EventHubTestSingleDispatchJobs.ProcessSingleEvent));

            ValidateEventHubDependency(
                sendDependency,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                "EventHubProducerClient.Send",
                nameof(EventHubTestSingleDispatchJobs.SendEvent_TestHub),
                sendRequestOperationId,
                sendRequest.Id,
                LogCategories.Bindings);

            ValidateEventHubRequest(
                processRequest,
                true,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                nameof(EventHubTestSingleDispatchJobs.ProcessSingleEvent),
                null,
                null);

            Assert.AreEqual(1, messageDependencies.Count);
            foreach (var messageDependency in messageDependencies)
            {
                Assert.AreEqual(sendRequestOperationId, messageDependency.Context.Operation.Id);
            }

            Assert.AreEqual(messageDependencies.Single().Id, processRequest.Context.Operation.ParentId);
        }

        [Test]
        public async Task EventHub_MultipleDispatch_BatchSend()
        {
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobs>();
            using (host)
            {
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchJobs.SendEvents_TestHub), new { input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();
            List<DependencyTelemetry> dependencies = _channel.Telemetries.OfType<DependencyTelemetry>().ToList();

            // We expect 5 message spans and 1 send span
            var messageDependencies = dependencies.Where(d => d.Name == "Message").ToList();
            var sendDependency = dependencies.Single(d => d.Name == "EventHubProducerClient.Send");

            Assert.AreEqual(5, messageDependencies.Count);

            var manualCallRequest = requests.Single(r => r.Context.Operation.Name == nameof(EventHubTestMultipleDispatchJobs.SendEvents_TestHub));
            var manualOperationId = manualCallRequest.Context.Operation.Id;

            ValidateEventHubDependency(
                sendDependency,
                EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                _eventHubScope.EventHubName,
                "EventHubProducerClient.Send",
                nameof(EventHubTestMultipleDispatchJobs.SendEvents_TestHub),
                manualOperationId,
                manualCallRequest.Id,
                LogCategories.Bindings);

            var ehTriggerRequests = requests.Where(r => r.Context.Operation.Name == nameof(EventHubTestMultipleDispatchJobs.ProcessMultipleEvents)).ToList();
            List<TestLink> allLinks = new List<TestLink>();

            // EventHub can batch events in a different ways
            foreach (var ehTriggerRequest in ehTriggerRequests)
            {
                ValidateEventHubRequest(
                     ehTriggerRequest,
                     true,
                     EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                     _eventHubScope.EventHubName,
                     nameof(EventHubTestMultipleDispatchJobs.ProcessMultipleEvents),
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
            await using var ehClient = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);

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

                messages[i] = new EventData(Encoding.UTF8.GetBytes(i.ToString()))
                {
                    Properties = { ["Diagnostic-Id"] = $"00-{operationId}-{spanId}-01" }
                };
            }

            await ehClient.SendAsync(messages);

            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobs>();
            using (host)
            {
                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            List<RequestTelemetry> requests = _channel.Telemetries.OfType<RequestTelemetry>().ToList();

            var ehTriggerRequests = requests.Where(r => r.Context.Operation.Name == nameof(EventHubTestMultipleDispatchJobs.ProcessMultipleEvents));

            List<TestLink> actualLinks = new List<TestLink>();
            foreach (var ehTriggerRequest in ehTriggerRequests)
            {
                ValidateEventHubRequest(
                    ehTriggerRequest,
                    true,
                    EventHubsTestEnvironment.Instance.FullyQualifiedNamespace,
                    _eventHubScope.EventHubName,
                    nameof(EventHubTestMultipleDispatchJobs.ProcessMultipleEvents),
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

            // Allow a margin of error of ~125 milliseconds, as timing is not precise.
            functionDuration -= 125;
            Assert.GreaterOrEqual(request.Duration.TotalMilliseconds, functionDuration);

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
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName, Connection = TestHubName)] out EventData evt)
            {
                evt = new EventData(Encoding.UTF8.GetBytes(input));
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] string evt)
            {
                _eventWait.Set();
            }
        }

        public class EventHubTestMultipleDispatchJobs
        {
            public static List<int> LinksCount = new List<int>();
            public static int MessagesCount = 0;

            private const int EventCount = 5;
            private static readonly object MessageLock = new object();
            public static void SendEvents_TestHub(string input, [EventHub(TestHubName, Connection = TestHubName)] out EventData[] events)
            {
                LinksCount.Clear();
                MessagesCount = 0;
                events = new EventData[EventCount];
                for (int i = 0; i < EventCount; i++)
                {
                    var evt = new EventData(Encoding.UTF8.GetBytes(input + i));
                    events[i] = evt;
                }
            }

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] string[] events)
            {
                Activity.Current.AddTag("receivedMessages", events.Length.ToString());
                lock (MessageLock)
                {
                    MessagesCount += events.Length;

                    if (events.Length > 0)
                    {
                        LinksCount.Add(events.Length);
                    }

                    if (MessagesCount >= EventCount)
                    {
                        _eventWait.Set();
                    }
                }
            }
        }

        private (JobHost JobHost, IHost Host) BuildHost<T>()
        {
            var (jobHost, host) = base.BuildHost<T>(builder =>
            {
                builder.ConfigureLogging(b => b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = "mock ikey"));
                ConfigureTestEventHub(builder);
            }, h => h.Services.GetService<TelemetryConfiguration>().TelemetryChannel = _channel);

            return (jobHost, host);
        }

        private class TestTelemetryChannel : ITelemetryChannel, ITelemetryModule
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
