// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubTriggerDispatcherTests
    {
        private static (string ConnectionId, string AccessKey, string Signature) TestKey = ("0f9c97a2f0bf4706afe87a14e0797b11", "7aab239577fd4f24bc919802fb629f5f", "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561");
        private const string TestHub = "testhub";
        private const string TestOrigin = "localhost";
        private const WebPubSubEventType TestType = WebPubSubEventType.System;
        private const string TestEvent = Constants.Events.ConnectedEvent;
        private static string TestConnectionString = $"Endpoint=http://{TestOrigin};Port=8080;AccessKey={TestKey.AccessKey};Version=1.0;";

        private static readonly WebPubSubValidationOptions TestValidationOption = new(TestConnectionString);
        private static readonly string[] ValidSignature = new string[] { TestKey.Signature };

        [TestCase]
        public async Task TestProcessRequest_ValidRequest()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, ValidSignature, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase]
        public async Task TestProcessRequest_AllowNullUserId()
        {
            var dispatcher = SetupDispatcher();
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, ValidSignature, userId: null, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase]
        public async Task TestProcessRequest_RouteNotFound()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage("hub1", TestType, TestEvent, TestKey.ConnectionId, ValidSignature, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestCase]
        public async Task TestProcessRequest_SignatureInvalid()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { "abc" }, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestCase]
        public async Task TestProcessRequest_ConnectionIdNullBadRequest()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, null, ValidSignature, httpMethod: "Delete");
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase]
        public async Task TestProcessRequest_DeleteMethodBadRequest()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, ValidSignature, httpMethod: "Delete", origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase("OPTIONS", "abc.com", new string[] { "abc.com" })]
        [TestCase("GET", "abc.com", new string[] { "abc.com" })]
        [TestCase("GET", "abc.com", new string[] { "ddd.com", "abc.com" })]
        public async Task TestProcessRequest_AbuseProtectionValidOK(string method, string allowHost, string[] requestHost)
        {
            ;
            var dispatcher = SetupDispatcher(connectionString: $"Endpoint=http://{allowHost};Port=8080;AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;");
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { TestKey.Signature }, httpMethod: method, origin: requestHost);
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase("OPTIONS", "abc.com")]
        [TestCase("GET", "abc.com")]
        public async Task TestProcessRequest_AbuseProtectionInvalidBadRequest(string method, string allowedHost)
        {
            var testhost = "def.com";
            var dispatcher = SetupDispatcher(connectionString: $"Endpoint=http://{allowedHost};Port=8080;AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;");
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { TestKey.Signature }, httpMethod: method, origin: new string[] { testhost });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestCase("sha256=something,sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561")]
        [TestCase("sha256=something, sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561")]
        [TestCase("sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561, sha256=something")]
        [TestCase("sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561,sha256=something")]
        public async Task TestProcessRequest_MultiSignaturesSuccess(string signatures)
        {
            var dispatcher = SetupDispatcher(connectionString: $"Endpoint=http://{TestOrigin};Port=8080;AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;");
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { signatures }, httpMethod: "GET", origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase("application/xml", HttpStatusCode.BadRequest)]
        public async Task TestProcessRequest_MessageMediaTypes(string mediaType, HttpStatusCode expectedCode)
        {
            var dispatcher = SetupDispatcher(TestHub, WebPubSubEventType.User, Constants.Events.MessageEvent, connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.User, Constants.Events.MessageEvent, TestKey.ConnectionId, ValidSignature, contentType: mediaType, payload: Encoding.UTF8.GetBytes("Hello"));
            var response = await dispatcher.ExecuteAsync(request).ConfigureAwait(false);
            Assert.AreEqual(expectedCode, response.StatusCode);
        }

        private static WebPubSubTriggerDispatcher SetupDispatcher(string hub = TestHub, WebPubSubEventType type = TestType, string eventName = TestEvent, string connectionString = null)
        {
            var funcName = $"{hub}.{type}.{eventName}".ToLower();
            var wpsOptions = new WebPubSubFunctionsOptions
            {
                ConnectionString = connectionString
            };
            var dispatcher = new WebPubSubTriggerDispatcher(NullLogger.Instance, wpsOptions);
            var executor = new Mock<ITriggeredFunctionExecutor>();
            executor.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new FunctionResult(true)));
            var listener = new WebPubSubListener(executor.Object, funcName, dispatcher, new WebPubSubValidationOptions(connectionString));

            dispatcher.AddListener(funcName, listener);

            return dispatcher;
        }
    }
}
