﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

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

        [SetUp]
        public void SetupTestListener()
        {
            _log.Clear();
        }

        [Test]
        [TestCase(CloudEventSubscription)]
        [TestCase(EventGridEventSubscription)]
        public async Task TestSubscribe(string evt)
        {
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg1>(ext);
            await host.StartAsync(); // add listener

            var request = CreateEventSubscribeRequest("TestEventGrid", evt);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("validation-code", JObject.Parse(content)["validationResponse"].ToString());
        }

        // Unsubscribe gives a 202.
        [Test]
        public async Task TestUnsubscribe()
        {
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg1>(ext);
            await host.StartAsync(); // add listener

            var request = CreateUnsubscribeRequest("TestEventGrid");
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }

        // Test that an event payload with multiple events causes multiple dispatches,
        // and that each instance has correct binding data.
        // This is the fundamental difference between a regular HTTP trigger and a EventGrid trigger.
        [Test]
        public async Task TestDispatch()
        {
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg1>(ext);
            await host.StartAsync(); // add listener

            var request = CreateDispatchRequest("TestEventGrid",
                JObject.Parse(@"{'subject':'one','data':{'prop':'alpha'}}"),
                JObject.Parse(@"{'subject':'two','data':{'prop':'beta'}}"));
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            // Verify that the user function was dispatched twice, NOT necessarily in order
            // Also verifies each instance gets its own proper binding data (from FakePayload.Prop)
            _log.TryGetValue("one", out string alpha);
            _log.TryGetValue("two", out string beta);
            Assert.AreEqual("alpha", alpha);
            Assert.AreEqual("beta", beta);
            // TODO - Verify that we return from webhook before the dispatch is finished
            // https://github.com/Azure/azure-functions-eventgrid-extension/issues/10
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Test]
        public async Task TestCloudEvent()
        {
            // individual elements
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg1>(ext);
            await host.StartAsync(); // add listener

            var request = CreateSingleRequest("TestEventGrid",
                JObject.Parse(@"{'subject':'one','data':{'prop':'alpha'}}"));
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            // verifies each instance gets its own proper binding data (from FakePayload.Prop)
            _log.TryGetValue("one", out string alpha);
            Assert.AreEqual("alpha", alpha);
            Assert.AreEqual(HttpStatusCode.Accepted, response.StatusCode);
        }

        [Test]
        public async Task WrongFunctionNameTest()
        {
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg2>(ext);
            await host.StartAsync(); // add listener

            JObject dummyPayload = JObject.Parse("{}");
            var request = CreateDispatchRequest("RandomFunctionName", dummyPayload);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("cannot find function: 'RandomFunctionName'", responseContent);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public async Task ExecutionFailureTest()
        {
            var ext = new EventGridExtensionConfigProvider(new HttpRequestProcessor(NullLoggerFactory.Instance.CreateLogger<HttpRequestProcessor>()), NullLoggerFactory.Instance);
            var host = TestHelpers.NewHost<MyProg2>(ext);
            await host.StartAsync(); // add listener

            JObject dummyPayload = JObject.Parse("{}");
            var request = CreateDispatchRequest("EventGridThrowsException", dummyPayload);
            var response = await ext.ConvertAsync(request, CancellationToken.None);

            string responseContent = await response.Content.ReadAsStringAsync();
            Assert.AreEqual("Exception while executing function: EventGridThrowsException", responseContent);
            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
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
            [FunctionName("TestEventGrid")]
            public void Run(
                [EventGridTrigger] JObject value,
                [BindingData("{data.prop}")] string prop)
            {
                // if the key already exists, we should error
                if (!_log.TryAdd((string)value["subject"], prop))
                {
                    throw new InvalidOperationException($"duplicate subject '{(string)value["subject"]}'");
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
    }
}
