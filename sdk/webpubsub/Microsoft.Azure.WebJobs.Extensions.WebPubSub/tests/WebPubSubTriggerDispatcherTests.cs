// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Newtonsoft.Json;
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
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase]
        public async Task TestProcessRequest_AllowNullUserId()
        {
            var dispatcher = SetupDispatcher();
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, ValidSignature, userId: null, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase]
        public async Task TestProcessRequest_RouteNotFound()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage("hub1", TestType, TestEvent, TestKey.ConnectionId, ValidSignature, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase]
        public async Task TestProcessRequest_SignatureInvalid()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { "abc" }, origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
        }

        [TestCase]
        public async Task TestProcessRequest_ConnectionIdNullBadRequest()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, null, ValidSignature, httpMethod: "Delete");
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [TestCase]
        public async Task TestProcessRequest_DeleteMethodBadRequest()
        {
            var dispatcher = SetupDispatcher(connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, ValidSignature, httpMethod: "Delete", origin: new string[] { TestOrigin });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
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
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase("OPTIONS", "abc.com")]
        [TestCase("GET", "abc.com")]
        public async Task TestProcessRequest_AbuseProtectionInvalidBadRequest(string method, string allowedHost)
        {
            var testhost = "def.com";
            var dispatcher = SetupDispatcher(connectionString: $"Endpoint=http://{allowedHost};Port=8080;AccessKey=7aab239577fd4f24bc919802fb629f5f;Version=1.0;");
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, TestType, TestEvent, TestKey.ConnectionId, new string[] { TestKey.Signature }, httpMethod: method, origin: new string[] { testhost });
            var response = await dispatcher.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
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
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase("application/xml", HttpStatusCode.BadRequest)]
        public async Task TestProcessRequest_MessageMediaTypes(string mediaType, HttpStatusCode expectedCode)
        {
            var dispatcher = SetupDispatcher(TestHub, WebPubSubEventType.User, Constants.Events.MessageEvent, connectionString: TestConnectionString);
            var request = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.User, Constants.Events.MessageEvent, TestKey.ConnectionId, ValidSignature, contentType: mediaType, payload: Encoding.UTF8.GetBytes("Hello"));
            var response = await dispatcher.ExecuteAsync(request).ConfigureAwait(false);
            Assert.That(response.StatusCode, Is.EqualTo(expectedCode));
        }

        private static IEnumerable<object[]> TestHandleMqttConnectRequest_InProcessModelTestData = new object[][]
        {
            new object[]{ new MqttConnectEventResponse("userId",new string[] {"group1", "group2"}, new string[] {"webpubsub.joinLeaveGroup"}) { Mqtt = new() { UserProperties = new MqttUserProperty[] { new("a", "b") } } },5, HttpStatusCode.OK, "{\"mqtt\":{\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"userId\":\"userId\",\"groups\":[\"group1\",\"group2\"],\"subprotocol\":\"mqtt\",\"roles\":[\"webpubsub.joinLeaveGroup\"]}"},
            new object[]{new MqttConnectEventErrorResponse(MqttV311ConnectReturnCode.NotAuthorized, "not authorized"),4, HttpStatusCode.Unauthorized, "{\"mqtt\":{\"code\":5,\"reason\":\"not authorized\",\"userProperties\":null}}",  },
            new object[]{ CreateMqttConnectErrorResponse(MqttV500ConnectReasonCode.NotAuthorized, "not authorized", new MqttUserProperty[] {new MqttUserProperty("a", "b")}),5, HttpStatusCode.Unauthorized, "{\"mqtt\":{\"code\":135,\"reason\":\"not authorized\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}",  }
        };

        private static MqttConnectEventErrorResponse CreateMqttConnectErrorResponse(MqttV500ConnectReasonCode reasonCode, string reason, MqttUserProperty[] userProperties)
        {
            var res = new MqttConnectEventErrorResponse(reasonCode, reason);
            res.Mqtt.UserProperties = userProperties;
            return res;
        }

        [TestCaseSource(nameof(TestHandleMqttConnectRequest_InProcessModelTestData))]
        public async Task TestHandleMqttConnectRequest_InProcessModel(WebPubSubEventResponse responseObj, int protocolVersion, HttpStatusCode expectedStatusCode, string expectedResponseBody)
        {
            var payload = "{\"mqtt\":{\"protocolVersion\":" + protocolVersion.ToString() + ",\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"claims\":{\"iat\":[\"1723005952\"],\"exp\":[\"1726605954\"],\"aud\":[\"ws://localhost:8080/clients/mqtt/hubs/simplechat\"],\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"user1\"],\"role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"nameid\":[\"user1\"]},\"query\":{\"access_token\":[\"REDATED\"]},\"headers\":{\"Connection\":[\"Upgrade\"],\"Host\":[\"localhost:8080\"],\"Upgrade\":[\"websocket\"],\"Sec-WebSocket-Version\":[\"13\"],\"Sec-WebSocket-Key\":[\"REDATED\"],\"Sec-WebSocket-Extensions\":[\"permessage-deflate; client_max_window_bits\"],\"Sec-WebSocket-Protocol\":[\"mqtt\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[{\"thumbprint\":\"thumbprint\",\"content\":\"certificate content\"}]}";
            var connectHttpRequest = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.System, "connect", "clientId", ValidSignature, origin: new string[] { TestOrigin }, subProtocols: new string[] { "mqtt" }, clientProtocol: WebPubSubClientProtocol.Mqtt, payload: Encoding.UTF8.GetBytes(payload));
            connectHttpRequest.Headers.Add(Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId");

            var dispatcher = new WebPubSubTriggerDispatcher(NullLogger.Instance, new() { Hub = TestHub });
            var mockExecutor = new Mock<ITriggeredFunctionExecutor>();
            var wpsListener = new WebPubSubListener(mockExecutor.Object, Utilities.GetFunctionKey(TestHub, WebPubSubEventType.System, "connect", WebPubSubTriggerAcceptedClientProtocols.Mqtt), dispatcher, null);
            await wpsListener.StartAsync(default);
            mockExecutor.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>((functionData, token) =>
                {
                    var triggerEvent = functionData.TriggerValue as WebPubSubTriggerEvent;
                    var mqttConnectEvent = triggerEvent.Request as MqttConnectEventRequest;
                    Assert.Multiple(() =>
                    {
                        Assert.That(mqttConnectEvent.Mqtt.Username, Is.EqualTo("username"));
                        Assert.That(mqttConnectEvent.Mqtt.Password, Is.EqualTo("password"));
                        Assert.That(mqttConnectEvent.ClientCertificates.First().Content, Is.EqualTo("certificate content"));
                        Assert.That(mqttConnectEvent.ClientCertificates.First().Thumbprint, Is.EqualTo("thumbprint"));
                        Assert.That(mqttConnectEvent.Mqtt.UserProperties.First().Name, Is.EqualTo("a"));
                        Assert.That(mqttConnectEvent.Mqtt.UserProperties.First().Value, Is.EqualTo("b"));
                        Assert.That((int)mqttConnectEvent.Mqtt.ProtocolVersion, Is.EqualTo(protocolVersion));
                    });
                    var tcs = triggerEvent.TaskCompletionSource;
                    tcs.SetResult(responseObj);
                })
                .Returns(Task.FromResult(new FunctionResult(true)));
            var httpResponse = await dispatcher.ExecuteAsync(connectHttpRequest);
            Assert.That(httpResponse.StatusCode, Is.EqualTo(expectedStatusCode));
            var actualBody = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(actualBody);
            Assert.That(actualBody, Is.EqualTo(expectedResponseBody));
        }

        private static readonly IEnumerable<object[]> TestHandleMqttConnectRequest_IsolatedProcessModelTestData = new object[][]
        {
            new object[]{ "{\"mqtt\":{\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"userId\":\"userId\",\"groups\":[\"group1\",\"group2\"],\"subprotocol\":\"mqtt\",\"roles\":[\"webpubsub.joinLeaveGroup\"]}", 5, HttpStatusCode.OK, "{\"mqtt\":{\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"userId\":\"userId\",\"groups\":[\"group1\",\"group2\"],\"subprotocol\":\"mqtt\",\"roles\":[\"webpubsub.joinLeaveGroup\"]}"},
            new object[]{ "{\"mqtt\":{\"code\":5,\"reason\":\"not authorized\",\"userProperties\":null}}", 4, HttpStatusCode.Unauthorized, "{\"mqtt\":{\"code\":5,\"reason\":\"not authorized\",\"userProperties\":null}}",  },
            new object[]{ "{\"mqtt\":{\"code\":135,\"reason\":\"reason\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"errorMessage\":\"reason\"}", 5, HttpStatusCode.Unauthorized, "{\"mqtt\":{\"code\":135,\"reason\":\"reason\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}}",  }
        };

        [TestCaseSource(nameof(TestHandleMqttConnectRequest_IsolatedProcessModelTestData))]
        public async Task TestHandleMqttConnectRequest_IsolatedProcessModel(string responseBodyFromWorker, int actualProtocolVersion, HttpStatusCode expectedStatusCode, string expectedHttpResponseBody)
        {
            var payload = "{\"mqtt\":{\"protocolVersion\":" + actualProtocolVersion.ToString() + ",\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"claims\":{\"iat\":[\"1723005952\"],\"exp\":[\"1726605954\"],\"aud\":[\"ws://localhost:8080/clients/mqtt/hubs/simplechat\"],\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"user1\"],\"role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"nameid\":[\"user1\"]},\"query\":{\"access_token\":[\"REDATED\"]},\"headers\":{\"Connection\":[\"Upgrade\"],\"Host\":[\"localhost:8080\"],\"Upgrade\":[\"websocket\"],\"Sec-WebSocket-Version\":[\"13\"],\"Sec-WebSocket-Key\":[\"REDATED\"],\"Sec-WebSocket-Extensions\":[\"permessage-deflate; client_max_window_bits\"],\"Sec-WebSocket-Protocol\":[\"mqtt\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[{\"thumbprint\":\"thumbprint\",\"content\":\"certificate content\"}]}";
            var connectHttpRequest = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.System, "connect", "clientId", ValidSignature, origin: new string[] { TestOrigin }, subProtocols: new string[] { "mqtt" }, clientProtocol: WebPubSubClientProtocol.Mqtt, payload: Encoding.UTF8.GetBytes(payload));
            connectHttpRequest.Headers.Add(Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId");

            var dispatcher = new WebPubSubTriggerDispatcher(NullLogger.Instance, new() { Hub = TestHub });
            var mockExecutor = new Mock<ITriggeredFunctionExecutor>();
            var wpsListener = new WebPubSubListener(mockExecutor.Object, Utilities.GetFunctionKey(TestHub, WebPubSubEventType.System, "connect", WebPubSubTriggerAcceptedClientProtocols.Mqtt), dispatcher, null);
            await wpsListener.StartAsync(default);
            mockExecutor.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>((functionData, token) =>
                {
                    var triggeredEvent = functionData.TriggerValue as WebPubSubTriggerEvent;
                    var mqttConnectEvent = triggeredEvent.Request as MqttConnectEventRequest;
                    // Isolated process model uses Newtonsoft.Json to serialize the trigger value.
                    var serializerSettings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter>
                        {
                            new BinaryDataJsonConverter(),
                            new ConnectionStatesNewtonsoftConverter(),
                            new WebPubSubDataTypeJsonConverter(),
                            new WebPubSubEventTypeJsonConverter(),
                        },
                    };
                    Console.WriteLine(JsonConvert.SerializeObject(mqttConnectEvent, serializerSettings));
                    Assert.That(JsonConvert.SerializeObject(mqttConnectEvent, serializerSettings), Is.EqualTo("{\"mqtt\":{\"protocolVersion\":" + actualProtocolVersion.ToString() + ",\"username\":\"username\",\"password\":\"password\",\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]},\"claims\":{\"iat\":[\"1723005952\"],\"exp\":[\"1726605954\"],\"aud\":[\"ws://localhost:8080/clients/mqtt/hubs/simplechat\"],\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier\":[\"user1\"],\"role\":[\"webpubsub.sendToGroup\",\"webpubsub.joinLeaveGroup\"],\"nameid\":[\"user1\"]},\"query\":{\"access_token\":[\"REDATED\"]},\"headers\":{\"Connection\":[\"Upgrade\"],\"Host\":[\"localhost:8080\"],\"Upgrade\":[\"websocket\"],\"Sec-WebSocket-Version\":[\"13\"],\"Sec-WebSocket-Key\":[\"REDATED\"],\"Sec-WebSocket-Extensions\":[\"permessage-deflate; client_max_window_bits\"],\"Sec-WebSocket-Protocol\":[\"mqtt\"]},\"subprotocols\":[\"mqtt\"],\"clientCertificates\":[{\"Thumbprint\":\"thumbprint\",\"content\":\"certificate content\"}],\"connectionContext\":{\"physicalConnectionId\":\"physicalConnectionId\",\"sessionId\":null,\"eventType\":\"System\",\"eventName\":\"connect\",\"hub\":\"testhub\",\"connectionId\":\"clientId\",\"userId\":\"testuser\",\"signature\":\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\",\"origin\":\"localhost\",\"states\":{},\"headers\":{\"ce-hub\":[\"testhub\"],\"ce-type\":[\"azure.webpubsub.sys.connect\"],\"ce-eventName\":[\"connect\"],\"ce-connectionId\":[\"clientId\"],\"ce-signature\":[\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\"],\"WebHook-Request-Origin\":[\"localhost\"],\"ce-userId\":[\"testuser\"],\"ce-subprotocol\":[\"mqtt\"],\"ce-physicalConnectionId\":[\"physicalConnectionId\",\"physicalConnectionId\"]}}}"));
                    var tcs = triggeredEvent.TaskCompletionSource;
                    tcs.SetResult(JsonConvert.DeserializeObject(responseBodyFromWorker));
                })
                .Returns(Task.FromResult(new FunctionResult(true)));
            var httpResponse = await dispatcher.ExecuteAsync(connectHttpRequest);
            Assert.That(httpResponse.StatusCode, Is.EqualTo(expectedStatusCode));
            var actualBody = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine(actualBody);
            Assert.That(actualBody, Is.EqualTo(expectedHttpResponseBody));
        }

        [TestCase]
        public async Task TestHandleMqttConnectedEvent()
        {
            var connectedRequest = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.System, "connected", "clientId", ValidSignature, origin: new string[] { TestOrigin }, subProtocols: new string[] { "mqtt" }, clientProtocol: WebPubSubClientProtocol.Mqtt);
            connectedRequest.Headers.Add(Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId");
            connectedRequest.Headers.Add(Constants.Headers.CloudEvents.MqttSessionId, "sessionId");
            var dispatcher = new WebPubSubTriggerDispatcher(NullLogger.Instance, new() { Hub = TestHub });
            var mockExecutor = new Mock<ITriggeredFunctionExecutor>();
            var wpsListener = new WebPubSubListener(mockExecutor.Object, Utilities.GetFunctionKey(TestHub, WebPubSubEventType.System, "connected", WebPubSubTriggerAcceptedClientProtocols.Mqtt), dispatcher, null);
            await wpsListener.StartAsync(default);
            mockExecutor.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>((functionData, token) =>
                {
                    var triggerEvent = (functionData.TriggerValue as WebPubSubTriggerEvent);
                    if (triggerEvent.ConnectionContext is MqttConnectionContext mqttContext)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(mqttContext.PhysicalConnectionId, Is.EqualTo("physicalConnectionId"));
                            Assert.That(mqttContext.SessionId, Is.EqualTo("sessionId"));
                            Assert.That(mqttContext.ConnectionId, Is.EqualTo("clientId"));
                        });
                    }
                    else
                    {
                        Assert.Fail("ConnectionContext is not MqttContext");
                    }

                    var tcs = triggerEvent.TaskCompletionSource;
                    tcs.SetResult(null);
                    WebPubSubConfigProvider.RegisterJsonConverter();

                    // Make sure the serialization of MqttConnectedEventRequest is correct, used in isolated-process models.
                    var expected = "{\"connectionContext\":{\"physicalConnectionId\":\"physicalConnectionId\",\"sessionId\":\"sessionId\",\"eventType\":\"System\",\"eventName\":\"connected\",\"hub\":\"testhub\",\"connectionId\":\"clientId\",\"userId\":\"testuser\",\"signature\":\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\",\"origin\":\"localhost\",\"states\":{},\"headers\":{\"ce-hub\":[\"testhub\"],\"ce-type\":[\"azure.webpubsub.sys.connected\"],\"ce-eventName\":[\"connected\"],\"ce-connectionId\":[\"clientId\"],\"ce-signature\":[\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\"],\"WebHook-Request-Origin\":[\"localhost\"],\"ce-userId\":[\"testuser\"],\"ce-subprotocol\":[\"mqtt\"],\"ce-physicalConnectionId\":[\"physicalConnectionId\",\"physicalConnectionId\"],\"ce-sessionId\":[\"sessionId\",\"sessionId\"]}}}";
                    Assert.That(JsonConvert.SerializeObject(triggerEvent.Request), Is.EqualTo(expected));
                })
                .Returns(Task.FromResult(new FunctionResult(true)));
            var httpResponse = await dispatcher.ExecuteAsync(connectedRequest);
        }

        [TestCase]
        public async Task TestHandleMqttDisonnectedEvent()
        {
            var body = " {\"mqtt\":{\"initiatedByClient\":false,\"disconnectPacket\":{\"code\":128,\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}},\"reason\":\"reason\"}";
            var disconnectedRequest = TestHelpers.CreateHttpRequestMessage(TestHub, WebPubSubEventType.System, "disconnected", "clientId", ValidSignature, origin: new string[] { TestOrigin }, subProtocols: new string[] { "mqtt" }, clientProtocol: WebPubSubClientProtocol.Mqtt, payload: Encoding.UTF8.GetBytes(body));
            disconnectedRequest.Headers.Add(Constants.Headers.CloudEvents.MqttPhysicalConnectionId, "physicalConnectionId");
            disconnectedRequest.Headers.Add(Constants.Headers.CloudEvents.MqttSessionId, "sessionId");
            var dispatcher = new WebPubSubTriggerDispatcher(NullLogger.Instance, new() { Hub = TestHub });
            var mockExecutor = new Mock<ITriggeredFunctionExecutor>();
            var wpsListener = new WebPubSubListener(mockExecutor.Object, Utilities.GetFunctionKey(TestHub, WebPubSubEventType.System, "disconnected", WebPubSubTriggerAcceptedClientProtocols.Mqtt), dispatcher, null);
            await wpsListener.StartAsync(default);
            mockExecutor.Setup(f => f.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback<TriggeredFunctionData, CancellationToken>((functionData, token) =>
                {
                    var triggerEvent = (functionData.TriggerValue as WebPubSubTriggerEvent);
                    if (triggerEvent.ConnectionContext is MqttConnectionContext mqttContext)
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.That(mqttContext.PhysicalConnectionId, Is.EqualTo("physicalConnectionId"));
                            Assert.That(mqttContext.SessionId, Is.EqualTo("sessionId"));
                            Assert.That(mqttContext.ConnectionId, Is.EqualTo("clientId"));
                        });
                    }
                    else
                    {
                        Assert.Fail("ConnectionContext is not MqttContext");
                    }

                    Assert.That(triggerEvent.Request, Is.InstanceOf<MqttDisconnectedEventRequest>());
                    var mqttDisconnectedEvent = triggerEvent.Request as MqttDisconnectedEventRequest;
                    Assert.Multiple(() =>
                    {
                        Assert.That(mqttDisconnectedEvent.Reason, Is.EqualTo("reason"));
                        Assert.That(mqttDisconnectedEvent.Mqtt.InitiatedByClient, Is.EqualTo(false));
                        Assert.That((int)mqttDisconnectedEvent.Mqtt.DisconnectPacket.Code, Is.EqualTo(128));
                        Assert.That(mqttDisconnectedEvent.Mqtt.DisconnectPacket.UserProperties.First().Name, Is.EqualTo("a"));
                        Assert.That(mqttDisconnectedEvent.Mqtt.DisconnectPacket.UserProperties.First().Value, Is.EqualTo("b"));
                    });

                    var tcs = triggerEvent.TaskCompletionSource;
                    tcs.SetResult(null);

                    // Make sure the serialization of MqttConnectedEventRequest is correct, used in isolated-process models.
                    WebPubSubConfigProvider.RegisterJsonConverter();
                    var expected = "{\"mqtt\":{\"initiatedByClient\":false,\"disconnectPacket\":{\"code\":128,\"userProperties\":[{\"name\":\"a\",\"value\":\"b\"}]}},\"reason\":\"reason\",\"connectionContext\":{\"physicalConnectionId\":\"physicalConnectionId\",\"sessionId\":\"sessionId\",\"eventType\":\"System\",\"eventName\":\"disconnected\",\"hub\":\"testhub\",\"connectionId\":\"clientId\",\"userId\":\"testuser\",\"signature\":\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\",\"origin\":\"localhost\",\"states\":{},\"headers\":{\"ce-hub\":[\"testhub\"],\"ce-type\":[\"azure.webpubsub.sys.disconnected\"],\"ce-eventName\":[\"disconnected\"],\"ce-connectionId\":[\"clientId\"],\"ce-signature\":[\"sha256=7767effcb3946f3e1de039df4b986ef02c110b1469d02c0a06f41b3b727ab561\"],\"WebHook-Request-Origin\":[\"localhost\"],\"ce-userId\":[\"testuser\"],\"ce-subprotocol\":[\"mqtt\"],\"ce-physicalConnectionId\":[\"physicalConnectionId\",\"physicalConnectionId\"],\"ce-sessionId\":[\"sessionId\",\"sessionId\"]}}}";
                    Assert.That(JsonConvert.SerializeObject(triggerEvent.Request), Is.EqualTo(expected));
                })
                .Returns(Task.FromResult(new FunctionResult(true)));
            var httpResponse = await dispatcher.ExecuteAsync(disconnectedRequest);
        }

        private static WebPubSubTriggerDispatcher SetupDispatcher(string hub = TestHub, WebPubSubEventType type = TestType, string eventName = TestEvent, string connectionString = null, WebPubSubTriggerAcceptedClientProtocols clientProtocol = WebPubSubTriggerAcceptedClientProtocols.All)
        {
            var funcName = Utilities.GetFunctionKey(hub, type, eventName, clientProtocol).ToLower();
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
