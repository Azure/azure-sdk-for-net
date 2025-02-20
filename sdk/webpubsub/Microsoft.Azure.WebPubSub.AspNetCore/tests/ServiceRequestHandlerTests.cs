// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebPubSub.AspNetCore.Tests
{
    [TestFixture]
    public class ServiceRequestHandlerTests
    {
        private const string TestEndpoint = "https://my-host.webpubsub.net";
        private readonly ServiceRequestHandlerAdapter _adaptor;

        public ServiceRequestHandlerTests()
        {
            var provider = new ServiceCollection()
                .AddLogging()
                .AddWebPubSub(x => x.ServiceEndpoint = new($"Endpoint={TestEndpoint};AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;"))
                .BuildServiceProvider();
            _adaptor = provider.GetRequiredService<ServiceRequestHandlerAdapter>();
        }

        [Test]
        public async Task TestHandleAbuseProtection()
        {
            _adaptor.RegisterHub<TestHub>();
            var context = PrepareHttpContext(httpMethod: HttpMethods.Options);

            await _adaptor.HandleRequest(context);

            context.Response.Headers.TryGetValue(Constants.Headers.WebHookAllowedOrigin, out var allowedOrigin);
            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            Assert.AreEqual("*", allowedOrigin.SingleOrDefault());
        }

        [Test]
        public async Task TestHandleAbuseProtection_Invalid()
        {
            _adaptor.RegisterHub<TestHub>();
            var context = PrepareHttpContext(httpMethod: HttpMethods.Options, uriStr: "https://attacker.com");

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status400BadRequest, context.Response.StatusCode);
        }

        [Test]
        public async Task TestHandleConnect()
        {
            _adaptor.RegisterHub<TestHub>();
            var connectBody = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[],\"headers\":{}}";
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, eventName: "connect", body: connectBody);

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            var converted = JsonSerializer.Deserialize<ConnectEventResponse>(response);
            Assert.AreEqual("testuser", converted.UserId);
        }

        [TestCase(MqttProtocolVersion.V311)]
        [TestCase(MqttProtocolVersion.V500)]
        public async Task TestMqttConnectSuccessfully_ReturnMqttResponse(MqttProtocolVersion protocolVersion)
        {
            var hubName = nameof(TestMqttConnectSuccessfully_ReturnMqttResponse);
            var payload = "{\"mqtt\":{\"protocolVersion\":" + ((int)protocolVersion).ToString() + ",\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"claims\":{\"iat\":[\"1723005952\"],\"exp\":[\"1726605954\"],\"aud\":[\"ws://localhost:8080/clients/mqtt/hubs/simplechat\"],\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"user1\"],\"role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"nameid\":[\"user1\"]},\"query\":{\"access_token\":[\"REDATED\"]},\"headers\":{\"Connection\":[\"Upgrade\"],\"Host\":[\"localhost:8080\"],\"Upgrade\":[\"websocket\"],\"Sec-WebSocket-Version\":[\"13\"],\"Sec-WebSocket-Key\":[\"REDATED\"],\"Sec-WebSocket-Extensions\":[\"permessage-deflate; client_max_window_bits\"],\"Sec-WebSocket-Protocol\":[\"mqtt\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[{\"thumbprint\":\"thumbprint\",\"content\":\"certificate content\"}]}";
            var context = PrepareHttpContext(hub: hubName,
                                             addtionalHeaders: new Dictionary<string, StringValues>
                                             {
                                                 { Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId" },
                                                 { Constants.Headers.CloudEvents.MqttSessionId, "sessionId" },
                                                 { Constants.Headers.CloudEvents.Subprotocol, "mqtt" }
                                             },
                                             body: payload);
            var mqttConnectEventResponse = new MqttConnectEventResponse("userId", new string[] { "group1", "group2" }, new string[] { "webpubsub.joinLeaveGroup" })
            {
                Mqtt = new()
                {
                    UserProperties = new List<MqttUserProperty> { new MqttUserProperty("a", "b") }
                }
            };
            var hubMock = new Mock<WebPubSubHub>();
            hubMock.Setup(h => h.OnConnectAsync(It.IsAny<ConnectEventRequest>(), It.IsAny<CancellationToken>())).Callback<ConnectEventRequest, CancellationToken>((request, token) =>
            {
                var mqttRequest = request as MqttConnectEventRequest;
                Assert.AreEqual("mqtt", mqttRequest.Subprotocols.Single());
                var clientCert = mqttRequest.ClientCertificates.Single();
                Assert.AreEqual("thumbprint", clientCert.Thumbprint);
                Assert.AreEqual("certificate content", clientCert.Content);
                Assert.AreEqual("username", mqttRequest.Mqtt.Username);
                Assert.AreEqual("password", mqttRequest.Mqtt.Password);
                var userProperty = mqttRequest.Mqtt.UserProperties.Single();
                Assert.AreEqual("a", userProperty.Name);
                Assert.AreEqual("b", userProperty.Value);
                Assert.AreEqual(protocolVersion, mqttRequest.Mqtt.ProtocolVersion);
            }).Returns(ValueTask.FromResult(mqttConnectEventResponse as ConnectEventResponse));
            _adaptor.RegisterHub(hubName, hubMock.Object);
            await _adaptor.HandleRequest(context);
            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            var expectedBody = "{\"mqtt\":{\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"userId\":\"userId\",\"groups\":[\"group1\",\"group2\"],\"subprotocol\":\"mqtt\",\"roles\":[\"webpubsub.joinLeaveGroup\"]}";
            Console.WriteLine(response);
            Assert.AreEqual(expectedBody, response);
            hubMock.Verify(h => h.OnConnectAsync(It.IsAny<MqttConnectEventRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [TestCase(MqttProtocolVersion.V311)]
        [TestCase(MqttProtocolVersion.V500)]
        public async Task TestMqttConnectSuccessfully_ReturnGeneralResponse(MqttProtocolVersion protocolVersion)
        {
            var hubName = nameof(TestMqttConnectSuccessfully_ReturnGeneralResponse);
            var payload = "{\"mqtt\":{\"protocolVersion\":" + ((int)protocolVersion).ToString() + ",\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"claims\":{\"iat\":[\"1723005952\"],\"exp\":[\"1726605954\"],\"aud\":[\"ws://localhost:8080/clients/mqtt/hubs/simplechat\"],\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"user1\"],\"role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"nameid\":[\"user1\"]},\"query\":{\"access_token\":[\"REDATED\"]},\"headers\":{\"Connection\":[\"Upgrade\"],\"Host\":[\"localhost:8080\"],\"Upgrade\":[\"websocket\"],\"Sec-WebSocket-Version\":[\"13\"],\"Sec-WebSocket-Key\":[\"REDATED\"],\"Sec-WebSocket-Extensions\":[\"permessage-deflate; client_max_window_bits\"],\"Sec-WebSocket-Protocol\":[\"mqtt\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[{\"thumbprint\":\"thumbprint\",\"content\":\"certificate content\"}]}";
            var context = PrepareHttpContext(hub: hubName,
                                             addtionalHeaders: new Dictionary<string, StringValues>
                                             {
                                                 { Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId" },
                                                 { Constants.Headers.CloudEvents.MqttSessionId, "sessionId" },
                                                 { Constants.Headers.CloudEvents.Subprotocol, "mqtt" }
                                             },
                                             body: payload);
            var mqttConnectEventResponse = new ConnectEventResponse("userId", new string[] { "group1", "group2" }, "mqtt", new string[] { "webpubsub.joinLeaveGroup" });
            var hubMock = new Mock<WebPubSubHub>();
            hubMock.Setup(h => h.OnConnectAsync(It.IsAny<MqttConnectEventRequest>(), It.IsAny<CancellationToken>())).Callback<ConnectEventRequest, CancellationToken>((r, token) =>
            {
                Assert.AreEqual("mqtt", r.Subprotocols.Single());
                var clientCert = r.ClientCertificates.Single();
                Assert.AreEqual("thumbprint", clientCert.Thumbprint);
                Assert.AreEqual("certificate content", clientCert.Content);
            }).Returns(ValueTask.FromResult(mqttConnectEventResponse));
            _adaptor.RegisterHub(hubName, hubMock.Object);
            await _adaptor.HandleRequest(context);
            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            var expectedBody = "{\"userId\":\"userId\",\"groups\":[\"group1\",\"group2\"],\"subprotocol\":\"mqtt\",\"roles\":[\"webpubsub.joinLeaveGroup\"]}";
            Assert.AreEqual(expectedBody, response);
            hubMock.Verify(h => h.OnConnectAsync(It.IsAny<MqttConnectEventRequest>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        private static readonly IEnumerable<object[]> TestHandleMqttConnectErrorWithMqttConnectionExceptionData = new object[][]
        {
            new object[]
            {
                MqttProtocolVersion.V311,
                (MqttConnectEventRequest r, CancellationToken t)=>ValueTask.FromResult(r.CreateErrorResponse(WebPubSubErrorCode.Unauthorized, "error message")as MqttConnectEventErrorResponse),
                HttpStatusCode.Unauthorized,
                "{\"mqtt\":{\"code\":5,\"reason\":\"error message\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}"
            },
            new object[]
            {
                MqttProtocolVersion.V500,
                (MqttConnectEventRequest r, CancellationToken t)=>ValueTask.FromResult(r.CreateErrorResponse(WebPubSubErrorCode.Unauthorized, "error message") as MqttConnectEventErrorResponse),
                HttpStatusCode.Unauthorized,
                "{\"mqtt\":{\"code\":135,\"reason\":\"error message\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}"
            },
            new object[]
            {
                MqttProtocolVersion.V311,
                (MqttConnectEventRequest r, CancellationToken t)=>ValueTask.FromResult(r.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.BadUsernameOrPassword, "error message")),
                HttpStatusCode.Unauthorized,
                "{\"mqtt\":{\"code\":4,\"reason\":\"error message\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}"
            },
            new object[]
            {
                MqttProtocolVersion.V500,
                (MqttConnectEventRequest r, CancellationToken t)=>ValueTask.FromResult(r.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.BadUserNameOrPassword, "error message")),
                HttpStatusCode.Unauthorized,
                "{\"mqtt\":{\"code\":134,\"reason\":\"error message\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}"
            },
        };

        [Test]
        public async Task TestHandleMessage()
        {
            _adaptor.RegisterHub<TestHub>();
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world");

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            // validate message response matched it's defined in TestHub.Message()
            Assert.AreEqual("ACK", response);
        }

        [Test]
        public async Task TestStateChanges()
        {
            _adaptor.RegisterHub<TestHub>();
            var initState = new Dictionary<string, BinaryData>
            {
                { "counter", BinaryData.FromObjectAsJson(2) }
            };
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "1", connectionState: initState);

            // 1 to update counter to 10.
            await _adaptor.HandleRequest(context);

            context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out var states);
            Assert.NotNull(states);
            var updated = states[0].DecodeConnectionStates();
            Assert.AreEqual(1, updated.Count);
            Assert.AreEqual(10, updated["counter"].ToObjectFromJson<int>());

            // 2 to add a new state.
            context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "2", connectionState: initState);
            _adaptor.RegisterHub<TestHub>();
            await _adaptor.HandleRequest(context);

            context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out states);
            Assert.NotNull(states);
            updated = states[0].DecodeConnectionStates();
            Assert.AreEqual(2, updated.Count);
            Assert.AreEqual("new", updated["new"].ToObjectFromJson<string>());

            // 3 to clear states
            context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "3", connectionState: initState);
            await _adaptor.HandleRequest(context);

            var exist = context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out _);
            Assert.False(exist);

            // 4 clar and add
            context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "4", connectionState: initState);
            await _adaptor.HandleRequest(context);

            context.Response.Headers.TryGetValue(Constants.Headers.CloudEvents.State, out states);
            Assert.NotNull(states);
            updated = states[0].DecodeConnectionStates();
            Assert.AreEqual(2, updated.Count);
            Assert.AreEqual("new1", updated["new1"].ToObjectFromJson<string>());
        }

        [Test]
        public async Task TestHubBaseReturns()
        {
            _adaptor.RegisterHub<TestDefaultHub>();
            var connectBody = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[],\"headers\":{}}";
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, eventName: "connect", body: connectBody, hub: nameof(TestDefaultHub));

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            Assert.Null(context.Response.ContentLength);
        }

        [Test]
        public async Task TestHubExceptions()
        {
            _adaptor.RegisterHub<TestCornerHub>();
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.System, eventName: "connected", hub: nameof(TestCornerHub));

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            // validate response matches exception
            Assert.AreEqual("Test Exception", response);
        }

        [Test]
        public async Task TestUserErrorReturns()
        {
            _adaptor.RegisterHub<TestCornerHub>();
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, type: WebPubSubEventType.User, eventName: "message", body: "hello world", hub: nameof(TestCornerHub));

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            // validate response matches exception
            Assert.AreEqual("Test Exception", response);
        }

        [Test]
        public async Task TestWrongTypeReturns()
        {
            _adaptor.RegisterHub<TestCornerHub>();
            var connectBody = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[],\"headers\":{}}";
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, eventName: "connect", body: connectBody, hub: nameof(TestCornerHub));

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status401Unauthorized, context.Response.StatusCode);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var response = await new StreamReader(context.Response.Body).ReadToEndAsync();
            // validate response matches exception
            Assert.AreEqual("Invalid user", response);
        }

        [Test]
        public async Task TestHubBaseReturnsWhenCustomHubName()
        {
            var hubName = "customHub";
            _adaptor.RegisterHub<TestDefaultHub>(hubName);
            var connectBody = "{\"claims\":{\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"ddd\"],\"nbf\":[\"1629183374\"],\"exp\":[\"1629186974\"],\"iat\":[\"1629183374\"],\"aud\":[\"http://localhost:8080/client/hubs/chat\"],\"sub\":[\"ddd\"]},\"query\":{\"access_token\":[\"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZGQiLCJuYmYiOjE2MjkxODMzNzQsImV4cCI6MTYyOTE4Njk3NCwiaWF0IjoxNjI5MTgzMzc0LCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjgwODAvY2xpZW50L2h1YnMvY2hhdCJ9.tqD8ykjv5NmYw6gzLKglUAv-c-AVWu-KNZOptRKkgMM\"]},\"subprotocols\":[\"protocol1\", \"protocol2\"],\"clientCertificates\":[],\"headers\":{}}";
            var context = PrepareHttpContext(httpMethod: HttpMethods.Post, eventName: "connect", body: connectBody, hub: hubName);

            await _adaptor.HandleRequest(context);

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
            Assert.Null(context.Response.ContentLength);
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
            Dictionary<string, BinaryData> connectionState = null,
            Dictionary<string, StringValues> addtionalHeaders = null)
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
                { Constants.Headers.CloudEvents.Signature, signatures },
                { Constants.Headers.CloudEvents.WebPubSubVersion, "1.0" },
            };
            if (addtionalHeaders != null)
            {
                foreach (var item in addtionalHeaders)
                {
                    headers.Add(item);
                }
            }

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
                headers.Add(Constants.Headers.CloudEvents.State, connectionState.EncodeConnectionStates());
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

        private sealed class TestHub : WebPubSubHub
        {
            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);

                return new ValueTask<ConnectEventResponse>(new ConnectEventResponse
                {
                    UserId = request.ConnectionContext.UserId
                });
            }

            public override ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                var response = new UserEventResponse("ACK");
                // simple tests.
                switch (request.Data.ToString())
                {
                    case "1":
                        response.SetState("counter", 10);
                        break;
                    case "2":
                        response.SetState("new", "new");
                        break;
                    case "3":
                        response.ClearStates();
                        break;
                    case "4":
                        response.ClearStates();
                        response.SetState("new1", "new1");
                        break;
                    default:
                        break;
                };
                return new ValueTask<UserEventResponse>(response);
            }

            // test exceptions
            public override Task OnConnectedAsync(ConnectedEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                return Task.CompletedTask;
            }

            public override Task OnDisconnectedAsync(DisconnectedEventRequest request)
            {
                Assert.NotNull(request);
                Assert.AreEqual("my-host.webpubsub.net", request.ConnectionContext.Origin);
                return Task.CompletedTask;
            }
        }

        // Test default return correct
        private sealed class TestDefaultHub : WebPubSubHub
        {
        }

        // Test error cases.
        private sealed class TestCornerHub : WebPubSubHub
        {
            // Test invalid type return 401
            public override ValueTask<ConnectEventResponse> OnConnectAsync(ConnectEventRequest request, CancellationToken cancellationToken)
            {
                throw new UnauthorizedAccessException("Invalid user");
            }

            // Test error return correct 500
            public override ValueTask<UserEventResponse> OnMessageReceivedAsync(UserEventRequest request, CancellationToken cancellationToken)
            {
                throw new Exception("Test Exception");
            }

            // Test exception return correct 500
            public override Task OnConnectedAsync(ConnectedEventRequest request)
            {
                throw new Exception("Test Exception");
            }
        }
    }
}
#endif