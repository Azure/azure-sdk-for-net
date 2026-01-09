// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Tests;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    public class TestListener
    {
        // multiple events are processed concurrently
        private static ConcurrentDictionary<string, string> _log = new ConcurrentDictionary<string, string>();
        private const string CloudEventSubscription =
                "{'source': '/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Eventhub/Namespaces/namespace'," +
                "'type': 'Microsoft.EventGrid.SubscriptionValidationEvent'," +
                "'id': 'testid'," +
                "'type': 'Microsoft.EventGrid.SubscriptionValidationEvent'," +
                "'time': '2021-06-04T23:02:03.3136561Z'," +
                "'specversion': '1.0'," +
                // intentionally include quotes and line breaks into JSON to match service behavior for CloudEvents
                "'data': " + @"""{
                                'validationCode': 'validation-code',
                                'validationUrl': 'validation-url'}""}";
        // event grid subscription request is delivered as an array of 1 event
        private const string EventGridEventSubscription =
            "[{" +
            "'id': 'testid'," +
            "'topic': '/subscriptions/subscription/resourceGroups/jolov/providers/Microsoft.Storage/StorageAccounts/jolovstorage'," +
            "'subject': ''," +
            "'data': {" +
            "'validationCode': 'validation-code'," +
            "'validationUrl': 'validation-url'" +
            "}," +
            "'eventType': 'Microsoft.EventGrid.SubscriptionValidationEvent'," +
            "'eventTime': '2021-06-04T23:02:03.3136561Z'," +
            "'metadataVersion': '1'," +
            "'dataVersion': '2'" +
            "}]";

        private const string CloudEventRequiredFields = @"'id':'1','source':'one','type':'t','data':'','specversion':'1.0'";
        [SetUp]
        public void SetupTestListener()
        {
            _log.Clear();
        }

        [Test]
        [TestCase(CloudEventSubscription, "TestJObject")]
        [TestCase(EventGridEventSubscription, "TestJObject")]
        [TestCase(EventGridEventSubscription, "TestEventGrid")]
        public async Task TestSubscribeRequestResponse(string evt, string functionName)
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = CreateEventSubscribeRequest(functionName, evt);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(JObject.Parse(content)["validationResponse"].ToString(), Is.EqualTo("validation-code"));
        }

        [Test]
        public async Task TestSubscribeRequestResponseCloudEvent()
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = CreateEventSubscribeRequest("TestCloudEvent", CloudEventSubscription);
            var response = await ext.ConvertAsync(request, CancellationToken.None);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        }

        [Test]
        [TestCase("TestJObject")]
        [TestCase("TestCloudEvent")]
        public async Task TestSubscribeOptions(string functionName)
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = new HttpRequestMessage(HttpMethod.Options, $"http://localhost/?functionName={functionName}");
            var response = await ext.ConvertAsync(request, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                // no WebHook-Request-Origin header, should fallback to public cloud
                Assert.That(response.Headers.GetValues("Webhook-Allowed-Origin").First(), Is.EqualTo("eventgrid.azure.net"));
            });
        }

        [TestCase("eventgrid.azure.net")]
        [TestCase("eventgrid.azure.us")]
        [TestCase("eventgrid.azure.eaglex.ic.gov")]
        [TestCase("eventgrid.azure.microsoft.scloud")]
        [TestCase("eventgrid.azure.cn")]
        public async Task TestSubscribeOptionsKnownAllowedOrigin(string origin)
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = new HttpRequestMessage(HttpMethod.Options, $"http://localhost/?functionName=TestCloudEvent");
            request.Headers.Add("WebHook-Request-Origin", origin);
            var response = await ext.ConvertAsync(request, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(response.Headers.GetValues("Webhook-Allowed-Origin").First(), Is.EqualTo(origin));
            });
        }

        [Test]
        public async Task TestSubscribeOptionsUnknownAllowedOrigin()
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = new HttpRequestMessage(HttpMethod.Options, $"http://localhost/?functionName=TestCloudEvent");
            request.Headers.Add("WebHook-Request-Origin", "someunknown.origin.com");
            var response = await ext.ConvertAsync(request, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                // Unknown origin, should fallback to public cloud
                Assert.That(response.Headers.GetValues("Webhook-Allowed-Origin").First(), Is.EqualTo("eventgrid.azure.net"));
            });
        }

        [Test]
        public async Task TestSubscribeOptionsEventGridEvent()
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = new HttpRequestMessage(HttpMethod.Options, "http://localhost/?functionName=TestEventGrid");
            var response = await ext.ConvertAsync(request, CancellationToken.None);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
                Assert.That(response.Headers.Contains("Webhook-Allowed-Origin"), Is.False);
            });
        }

        // Unsubscribe gives a 202.
        [Test]
        public async Task TestUnsubscribe()
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = CreateUnsubscribeRequest("TestEventGrid");
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        }

        // Test that an event payload with multiple events causes multiple dispatches,
        // and that each instance has correct binding data.
        // This is the fundamental difference between a regular HTTP trigger and a EventGrid trigger.
        [Test]
        [TestCase("TestJObject")]
        [TestCase("TestEventGrid")]
        public async Task TestDispatch(string functionName)
        {
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var request = CreateDispatchRequest(functionName,
                JObject.Parse(@"{'subject':'one','id':'one','source':'one','eventType':'t','specversion':'1.0','dataVersion':'0','data':{'prop':'alpha'}}"),
                JObject.Parse(@"{'subject':'two','id':'two','source':'two','eventType':'t','specversion':'1.0','dataVersion':'0','data':{'prop':'beta'}}"));
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            // Verify that the user function was dispatched twice, NOT necessarily in order
            // Also verifies each instance gets its own proper binding data (from FakePayload.Prop)
            _log.TryGetValue("one", out string alpha);
            _log.TryGetValue("two", out string beta);
            Assert.Multiple(() =>
            {
                Assert.That(_log.Count, Is.EqualTo(2));
                Assert.That(alpha, Is.EqualTo("alpha"));
                Assert.That(beta, Is.EqualTo("beta"));
                // TODO - Verify that we return from webhook before the dispatch is finished
                // https://github.com/Azure/azure-functions-eventgrid-extension/issues/10
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            });
        }

        [Test]
        public async Task TestCloudEvent()
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            var dateTime = "2024-08-15T12:34:56.0000000-08:00";
            var jObject = JsonConvert.DeserializeObject<JObject>(
                $"{{'id':'one', 'time':'{dateTime}', 'source':'one','type':'t','data':'','specversion':'1.0','data':{{'prop':'alpha'}}}}",
                new JsonSerializerSettings { DateParseHandling = DateParseHandling.None });
            var request = CreateSingleRequest("TestCloudEvent", jObject);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            // verifies each instance gets its own proper binding data (from FakePayload.Prop)
            _log.TryGetValue("one", out string alpha);
            Assert.That(alpha, Is.EqualTo("alpha"));

            // validate that the time matches exactly - i.e. it should not have been translated to UTC or local time of the machine
            _log.TryGetValue("time", out string time);
            Assert.Multiple(() =>
            {
                Assert.That(time, Is.EqualTo(dateTime));

                Assert.That(_log.Count, Is.EqualTo(2));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
            });
        }

        [Test]
        [TestCase("TestJObject")]
        [TestCase("TestEventGrid")]
        public async Task TestEventGridEventWithTracingSingleDispatch(string functionName)
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            var request = CreateDispatchRequest(functionName,
                JObject.Parse(@"{'subject':'one','eventType':'1','id':'1','dataVersion':'0','data':{'prop':'alpha'}}"),
                JObject.Parse(@"{'subject':'one','eventType':'2','id':'1','dataVersion':'0','data':{'prop':'alpha'}}"));
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(2));

            // one of executions will fail because of dup subject
            Assert.That(testListener.Scopes.Count(s => s.Exception != null), Is.EqualTo(1));

            for (int i = 0; i < 2; i++)
            {
                var executionScope = testListener.AssertAndRemoveScope("EventGrid.Process", new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));
                Assert.Multiple(() =>
                {
                    Assert.That(executionScope.Links, Is.Empty);
                    Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                    Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
                });
            }
        }

        [Test]
        [TestCase("TestJObjectMultiple")]
        [TestCase("TestEventGridMultiple")]
        public async Task TestEventGridEventBatchDispatchWithTracing(string functionName)
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            var request = CreateDispatchRequest(functionName,
                JObject.Parse(@"{'subject':'one','eventType':'1','id':'1','dataVersion':'0','data':{'prop':'alpha'}}"),
                JObject.Parse(@"{'subject':'two','eventType':'2','id':'2','dataVersion':'0','data':{'prop':'alpha'}}"));

            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(1));
            var executionScope = testListener.AssertScope("EventGrid.Process",
                new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));

            Assert.Multiple(() =>
            {
                Assert.That(executionScope.Links, Is.Empty);
                Assert.That(executionScope.Exception, Is.Null);
                Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
            });
        }

        [Test]
        public async Task TestSingleCloudEventWithTracing()
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            const string functionName = "TestCloudEvent";
            const string traceparent = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01";
            var request = CreateSingleRequest(functionName,
                JObject.Parse($"{{{CloudEventRequiredFields},'traceparent':'{traceparent}','data':{{'prop':'1'}}}}"));
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(1));
            var executionScope = testListener.AssertScope("EventGrid.Process",
                new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));

            var expectedLinks = new[] { new ClientDiagnosticListener.ProducedLink(traceparent) };
            Assert.Multiple(() =>
            {
                Assert.That(executionScope.Links, Is.EquivalentTo(expectedLinks));
                Assert.That(executionScope.Exception, Is.Null);
                Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
            });
        }

        [Test]
        public async Task TestMultipleCloudEventsWithTracingSingleDispatch()
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            const string functionName = "TestCloudEvent";
            const string traceparent1 = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01";
            const string tracestate1 = "foo1=bar1";
            const string traceparent2 = "00-1123456789abcdef0123456789abcdef-1123456789abcdef-01";

            var request = CreateDispatchRequest(functionName,
                JObject.Parse($"{{{CloudEventRequiredFields},'data':{{'prop':'1'}},'traceparent':'{traceparent1}','tracestate':'{tracestate1}'}}"),
                JObject.Parse($"{{{CloudEventRequiredFields},'data':{{'prop':'2'}},'traceparent':'{traceparent2}'}}"));

            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(2));

            // one of executions will fail because of dup subject
            Assert.That(testListener.Scopes.Count(s => s.Exception != null), Is.EqualTo(1));

            bool fullFound = false, parentOnlyFound = false;
            for (int i = 0; i < 2; i++)
            {
                var executionScope = testListener.AssertAndRemoveScope("EventGrid.Process", new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));
                Assert.Multiple(() =>
                {
                    Assert.That(executionScope.Links.Count, Is.EqualTo(1));
                    Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                    Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
                });

                var link = executionScope.Links.Single();
                if (link.Traceparent == traceparent1)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(link.Tracestate, Is.EqualTo(tracestate1));
                        Assert.That(fullFound, Is.False);
                    });
                    fullFound = true;
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(link.Tracestate, Is.Null);
                        Assert.That(parentOnlyFound, Is.False);
                    });
                    parentOnlyFound = true;
                }
            }

            Assert.Multiple(() =>
            {
                Assert.That(fullFound, Is.True);
                Assert.That(parentOnlyFound, Is.True);
            });
        }

        [Test]
        public async Task TestMultipleCloudEventsWithTracingMultiDispatch()
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg1>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            const string functionName = "TestCloudEventMultiple";
            const string traceparent1 = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01";
            const string tracestate1 = "foo1=bar1";
            const string traceparent2 = "00-1123456789abcdef0123456789abcdef-1123456789abcdef-01";

            var request = CreateDispatchRequest(functionName,
                JObject.Parse($"{{{CloudEventRequiredFields},'traceparent':'{traceparent1}','tracestate':'{tracestate1}'}}"),
                JObject.Parse($"{{{CloudEventRequiredFields},'traceparent':'{traceparent2}'}}"),
                JObject.Parse($"{{{CloudEventRequiredFields},'tracestate':'ignored'}}"));

            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(1));
            var executionScope = testListener.AssertScope("EventGrid.Process",
                new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));

            var expectedLinks = new[] { new ClientDiagnosticListener.ProducedLink(traceparent1, tracestate1),
                                        new ClientDiagnosticListener.ProducedLink(traceparent2, null)};

            Assert.Multiple(() =>
            {
                Assert.That(executionScope.Links, Is.EquivalentTo(expectedLinks));
                Assert.That(executionScope.Exception, Is.Null);
                Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
            });
        }

        [Test]
        public async Task TestMultipleCloudEventsWithTracingMultiDispatchError()
        {
            // individual elements
            using var host = TestHelpers.NewHost<MyProg3>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            using var testListener = new ClientDiagnosticListener("Azure.Messaging.EventGrid");
            const string functionName = "EventGridThrowsExceptionMultiple";
            const string traceparent1 = "00-0123456789abcdef0123456789abcdef-0123456789abcdef-01";
            const string traceparent2 = "00-1123456789abcdef0123456789abcdef-1123456789abcdef-01";

            var request = CreateDispatchRequest(functionName,
                JObject.Parse($"{{'subject':'one','data':{{'prop':'alpha'}},'traceparent':'{traceparent1}'}}"),
                JObject.Parse($"{{'subject':'two','data':{{'prop':'alpha'}},'traceparent':'{traceparent2}'}}"));

            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.That(testListener.Scopes.Count, Is.EqualTo(1));
            var executionScope = testListener.AssertScope("EventGrid.Process",
                new KeyValuePair<string, string>("az.namespace", "Microsoft.EventGrid"));

            var expectedLinks = new[] { new ClientDiagnosticListener.ProducedLink(traceparent1, null),
                                        new ClientDiagnosticListener.ProducedLink(traceparent2, null)};

            Assert.Multiple(() =>
            {
                Assert.That(executionScope.Links, Is.EquivalentTo(expectedLinks));
                Assert.That(executionScope.Exception, Is.Not.Null);
                Assert.That(_log.TryGetValue(executionScope.Activity.Id, out var activityName), Is.True);
                Assert.That(activityName, Is.EqualTo("EventGrid.Process"));
            });
        }

        [Test]
        public async Task WrongFunctionNameTest()
        {
            using var host = TestHelpers.NewHost<MyProg2>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            JObject dummyPayload = JObject.Parse("{}");
            var request = CreateDispatchRequest("RandomFunctionName", dummyPayload);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.Multiple(() =>
            {
                Assert.That(responseContent, Is.EqualTo("cannot find function: 'RandomFunctionName'"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }

        [Test]
        public async Task ExecutionFailureTest()
        {
            using var host = TestHelpers.NewHost<MyProg2>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            JObject dummyPayload = JObject.Parse("{}");
            var request = CreateDispatchRequest("EventGridThrowsException", dummyPayload);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.Multiple(() =>
            {
                Assert.That(responseContent, Is.EqualTo("Exception while executing function: EventGridThrowsException"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            });
        }

        [Test]
        public async Task ExecutionFailureMultipleEventsTest()
        {
            using var host = TestHelpers.NewHost<MyProg3>(CreateConfigProvider);
            var ext = host.Services.GetServices<IExtensionConfigProvider>().OfType<EventGridExtensionConfigProvider>().Single();
            await host.StartAsync(); // add listener

            JObject dummyPayload = JObject.Parse("{}");
            var request = CreateDispatchRequest("EventGridThrowsExceptionMultiple", dummyPayload);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.Multiple(() =>
            {
                Assert.That(responseContent, Is.EqualTo("Exception while executing function: EventGridThrowsExceptionMultiple"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            });
        }

        private static EventGridExtensionConfigProvider CreateConfigProvider(IServiceProvider services)
        {
            return new EventGridExtensionConfigProvider(
                services.GetRequiredService<EventGridAsyncCollectorFactory>(),
                new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()),
                NullLoggerFactory.Instance
            );
        }

        private static HttpRequestMessage CreateEventSubscribeRequest(string funcName, string evt)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/?functionName=" + funcName);
            request.Headers.Add("aeg-event-type", "SubscriptionValidation");
            request.Content = new StringContent(evt);
            return request;
        }

        private static HttpRequestMessage CreateUnsubscribeRequest(string funcName)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/?functionName=" + funcName);
            request.Headers.Add("aeg-event-type", "Unsubscribe");
            return request;
        }

        private static HttpRequestMessage CreateSingleRequest(string funcName, JObject item)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/?functionName=" + funcName);
            request.Headers.Add("aeg-event-type", "Notification");
            request.Content = new StringContent(item.ToString(), Encoding.UTF8, "application/json");
            return request;
        }

        private static HttpRequestMessage CreateDispatchRequest(string funcName, params JObject[] items)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/?functionName=" + funcName);
            request.Headers.Add("aeg-event-type", "Notification");
            var payloadArray = new JArray();
            foreach (var item in items)
            {
                payloadArray.Add(item);
            }
            request.Content = new StringContent(payloadArray.ToString(), Encoding.UTF8, "application/json");
            return request;
        }

        public class FakePayload
        {
            public string Prop { get; set; }
        }

        public class MyProg1
        {
            [FunctionName("TestJObject")]
            public void RunSingleJObject(
                [EventGridTrigger] JObject value,
                [BindingData("{data.prop}")] string prop)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }

                // if the key already exists, we should error
                if (!_log.TryAdd((string)value["subject"], prop))
                {
                    throw new InvalidOperationException($"duplicate subject '{(string)value["subject"]}'");
                }
            }

            [FunctionName("TestEventGrid")]
            public void RunSingleEgEvent(
                [EventGridTrigger] EventGridEvent value,
                [BindingData("{data.prop}")] string prop)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }

                // if the key already exists, we should error
                if (!_log.TryAdd(value.Subject, prop))
                {
                    throw new InvalidOperationException($"duplicate subject '{value.Subject}'");
                }
            }

            [FunctionName("TestJObjectMultiple")]
            public void RunMultipleObjects([EventGridTrigger] JObject[] values)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }
            }

            [FunctionName("TestEventGridMultiple")]
            public void RunMultipleEvents([EventGridTrigger] EventGridEvent[] values)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }
            }

            [FunctionName("TestCloudEvent")]
            public void RunSingle(
                [EventGridTrigger] CloudEvent value,
                [BindingData("{data.prop}")] string prop)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }

                // if the key already exists, we should error
                if (!_log.TryAdd(value.Id, prop))
                {
                    throw new InvalidOperationException($"duplicate subject '{value.Id}'");
                }

                if (!_log.TryAdd("time", value.Time.Value.ToString("o")))
                {
                    throw new InvalidOperationException($"duplicate time '{value.Time}'");
                }
            }

            [FunctionName("TestCloudEventMultiple")]
            public void RunBatch([EventGridTrigger] JObject[] values)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }
            }
        }

        public class MyProg2
        {
            [FunctionName("EventGridThrowsException")]
            public void Run([EventGridTrigger] JObject value)
            {
                throw new InvalidOperationException($"failed with {value.ToString()}");
            }
        }

        public class MyProg3
        {
            [FunctionName("EventGridThrowsExceptionMultiple")]
            public void Run([EventGridTrigger] JObject[] value)
            {
                if (Activity.Current != null)
                {
                    _log.TryAdd(Activity.Current.Id, Activity.Current.OperationName);
                }

                throw new InvalidOperationException($"failed with {value.ToString()}");
            }
        }
    }
}
