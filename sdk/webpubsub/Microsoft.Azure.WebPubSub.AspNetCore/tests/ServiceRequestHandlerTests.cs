// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests
{
    [TestFixture]
    public class ServiceRequestHandlerTests
    {
        private const string TestEndpoint = "https://my-host.webpubsub.net";
        private readonly WebPubSubValidationOptions _options;
        private readonly IServiceRequestHandler _handler;
        private readonly string _testHost;

        public ServiceRequestHandlerTests()
        {
            _options = new WebPubSubValidationOptions($"Endpoint={TestEndpoint};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;");
            _handler = new ServiceRequestHandler(_options);
            _testHost = new Uri(TestEndpoint).Host;
        }

        [Test]
        public async Task TestHandleAbuseProtection()
        {
            var context = PrepareHttpContext(httpMethod: HttpMethods.Options);

            await _handler.HandleRequest(context, new TestHub());

            context.Response.Headers.TryGetValue(Constants.Headers.WebHookAllowedOrigin, out var allowedOrigin);
            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            Assert.AreEqual(_testHost, allowedOrigin);
        }

        [Test]
        public async Task TestHandleAbuseProtection_Invalid()
        {
            var context = PrepareHttpContext(httpMethod: HttpMethods.Options, uriStr: "https://attacker.com");

            await _handler.HandleRequest(context, new TestHub());

            Assert.AreEqual(StatusCodes.Status400BadRequest, context.Response.StatusCode);
        }

        [Test]
        public async Task TestHandleConnect()
        {
            var connectBody = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[]}";
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, eventName: "connect", body: connectBody);

            await _handler.HandleRequest(context, new TestHub());

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            var converted = JsonSerializer.Deserialize<ConnectResponse>(response);
            Assert.AreEqual("testuser", converted.UserId);
        }

        [Test]
        public async Task TestHandleMessage()
        {
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world");

            await _handler.HandleRequest(context, new TestHub());

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            // validate message response matched it's defined in TestHub.Message()
            Assert.AreEqual("ACK", response);
        }

        [Test]
        public async Task TestStateChanges()
        {
            var initState = new Dictionary<string, object>();
            initState.Add("counter", 2);
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world", connectionState: initState);

            // 1 to update counter to 10.
            await _handler.HandleRequest(context, new TestHub(1));

            context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out var states);
            Assert.NotNull(states);
            var updated = states[0].DecodeConnectionState();
            Assert.AreEqual(1, updated.Count);
            Assert.AreEqual("10", updated["counter"]);

            // 2 to add a new state.
            context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world", connectionState: initState);
            await _handler.HandleRequest(context, new TestHub(2));

            context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out states);
            Assert.NotNull(states);
            updated = states[0].DecodeConnectionState();
            Assert.AreEqual(2, updated.Count);
            Assert.AreEqual("new", updated["new"]);

            // 3 to clear states
            context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world", connectionState: initState);
            await _handler.HandleRequest(context, new TestHub(3));

            var exist = context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out states);
            Assert.False(exist);
        }

        private static HttpContext PrepareHttpContext(
            WebPubSubEventType type = WebPubSubEventType.System,
            string eventName = "connect",
            string uriStr = TestEndpoint,
            string connectionId = "0f9c97a2f0bf4706afe87a14e0797b11",
            string signatures = "sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561",
            string hub = "testhub",
            string httpMethod = "POST",
            string userId = "testuser",
            string body = null,
            string contentType = Constants.ContentTypes.PlainTextContentType,
            Dictionary<string,object> connectionState = null)
        {
            var context = new DefaultHttpContext();
            var services = new ServiceCollection();
            var sp = services.BuildServiceProvider();
            context.RequestServices = sp;

            var uri = new Uri(uriStr);
            var request = context.Request;
            var requestFeature = request.HttpContext.Features.Get<IHttpRequestFeature>();
            requestFeature.Method = httpMethod;
            requestFeature.Scheme = uri.Scheme;
            requestFeature.PathBase = uri.Host;
            requestFeature.Path = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Path, UriFormat.Unescaped);
            requestFeature.PathBase = "/";
            requestFeature.QueryString = uri.GetComponents(UriComponents.KeepDelimiter | UriComponents.Query, UriFormat.Unescaped);

            var headers = new HeaderDictionary
            {
                { Constants.Headers.CloudEvents.Hub, hub },
                { Constants.Headers.CloudEvents.Type, GetFormedType(type, eventName) },
                { Constants.Headers.CloudEvents.EventName, eventName },
                { Constants.Headers.CloudEvents.ConnectionId, connectionId },
                { Constants.Headers.CloudEvents.Signature, signatures }
            };

            if (!string.IsNullOrEmpty(uri.Host))
            {
                headers.Add("Host", uri.Host);
                headers.Add(Constants.Headers.WebHookRequestOrigin, uri.Host);
            }

            if (userId != null)
            {
                headers.Add(Constants.Headers.CloudEvents.UserId, userId);
            }

            if (connectionState != null)
            {
                headers.Add(Constants.Headers.CloudEvents.State, connectionState.ToHeaderStates());
            }

            if (body != null)
            {
                requestFeature.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                request.ContentLength = request.Body.Length;
                headers.Add("Content-Length", request.Body.Length.ToString());
                request.ContentType = contentType;
                headers.Add("Content-Type", contentType);
            }

            requestFeature.Headers = headers;
            context.Response.Body = new MemoryStream();

            return context;
        }

        private static string GetFormedType(WebPubSubEventType type, string eventName)
        {
            return type == WebPubSubEventType.User ?
                $"{Constants.Headers.CloudEvents.TypeUserPrefix}{eventName}" :
                $"{Constants.Headers.CloudEvents.TypeSystemPrefix}{eventName}";
        }

        private sealed class TestHub : ServiceHub
        {
            private readonly int _flag;

            public TestHub()
            { }

            public TestHub(int flag)
            {
                _flag = flag;
            }

            public override Task<ServiceResponse> Connect(ConnectEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                return Task.FromResult<ServiceResponse>(new ConnectResponse
                {
                    UserId = request.ConnectionContext.UserId
                });
            }

            public override Task<ServiceResponse> Message(MessageEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                var response = new MessageResponse("ACK");
                // simple tests.
                switch (_flag)
                {
                    case 0: break;
                    case 1: response.SetState("counter", 10);
                        break;
                    case 2: response.SetState("new", "new");
                        break;
                    default:
                        response.ClearStates();
                        break;
                };
                return Task.FromResult<ServiceResponse>(response);
            }

            public override Task Connected(ConnectedEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                return Task.CompletedTask;
            }

            public override Task Disconnected(DisconnectedEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                return Task.CompletedTask;
            }
        }
    }
}
