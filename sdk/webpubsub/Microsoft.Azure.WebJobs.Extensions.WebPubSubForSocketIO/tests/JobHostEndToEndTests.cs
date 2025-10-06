// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebPubSub.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class JobHostEndToEndTests
    {
        private static readonly SocketIOSocketContext TestContext = CreateConnectionContext();
        private static readonly BinaryData TestMessage = BinaryData.FromString("JobHostEndToEndTests");
        private static readonly Dictionary<string, string> KeyBasedConfiguration = new()
        {
            { Constants.SocketIOConnectionStringName, "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;" }
        };
        private static readonly Dictionary<string, string> IdentityBasedConfiguration = new()
        {
            { Constants.SocketIOConnectionStringName+":endpoint", "https://abc" },
            { Constants.SocketIOConnectionStringName+":credential", "managedidentity" },
            { Constants.SocketIOConnectionStringName+":clientId", "xyz"},
        };
        private static readonly Dictionary<string, string> IdentityBasedConfigurationMissingEndpoint = new()
        {
            { Constants.SocketIOConnectionStringName+":credential", "managedidentity" },
            { Constants.SocketIOConnectionStringName+":clientId", "xyz"},
        };

        [TestCase]
        public async Task TestSocketIOTriggerWithKeyBasedConfig()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);
            var triggerEvent = CreateTestTriggerEvent();
            var args = new Dictionary<string, object>
            {
                { "request", triggerEvent }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTrigger", args);
            Assert.True(triggerEvent.TaskCompletionSource.Task.IsCompleted);
        }

        [TestCase]
        public async Task TestSocketIOTriggerWithIdentityBasedConfig()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: IdentityBasedConfiguration);
            var triggerEvent = CreateTestTriggerEvent();
            var args = new Dictionary<string, object>
            {
                { "request", triggerEvent }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTrigger", args);
            Assert.True(triggerEvent.TaskCompletionSource.Task.IsCompleted);
        }

        [TestCase]
        public async Task TestSocketIOTriggerWithParam()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: IdentityBasedConfiguration);
            var triggerEvent = CreateTestMessageTriggerEvent();
            var args = new Dictionary<string, object>
            {
                { "request", triggerEvent }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTriggerWith2Param", args);
            Assert.True(triggerEvent.TaskCompletionSource.Task.IsCompleted);
        }

        [TestCase]
        public async Task TestSocketIOTriggerWithParamAttr()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: IdentityBasedConfiguration);
            var triggerEvent = CreateTestMessageTriggerEvent();
            var args = new Dictionary<string, object>
            {
                { "request", triggerEvent }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTriggerWith2ParamAndParameterAttr", args);
            Assert.True(triggerEvent.TaskCompletionSource.Task.IsCompleted);
        }

        [TestCase]
        public void TestSocketIOTrigger_InvalidBindingObject()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            var task = host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTriggerInvalid", args);
            var exception = Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.AreEqual("Exception while executing function: SocketIOFuncs.TestSocketIOTriggerInvalid", exception.Message);
        }

        [TestCase]
        public void TestSocketIOTrigger_InvalidParam()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);
            var args = new Dictionary<string, object>
            {
                { "request",CreateTestMessageTriggerEvent() }
            };

            var task = host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTriggerWith3Param", args);
            var exception = Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.AreEqual("Exception while executing function: SocketIOFuncs.TestSocketIOTriggerWith3Param", exception.Message);
        }

        [TestCase("SocketIOFuncs.TestSocketIOInputConnection")]
        [TestCase("SocketIOFuncs.TestSocketIOInputConnectionWithUserId")]
        public async Task TestSocketIOInputBinding(string function)
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);

            await host.GetJobHost().CallAsync(function);
        }

        [TestCase]
        public void TestSocketIOInputBinding_MissingConnectionString()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs));
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOInputConnection"));
            Assert.AreEqual($"SocketIO connection string 'WebPubSubForSocketIOConnectionString' does not exist. Please set either 'WebPubSubForSocketIOConnectionString' to use access key based connection. "
                + $"Or set `WebPubSubForSocketIOConnectionString:credential`, `WebPubSubForSocketIOConnectionString:clientId` and `WebPubSubForSocketIOConnectionString:endpoint` to use identity-based connection. "
                + $"See https://learn.microsoft.com/azure/azure-functions/functions-reference#common-properties-for-identity-based-connections for more details.", exception.Message);
        }

        [TestCase]
        public void TestSocketIOInputBinding_MissingEndpoint()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: IdentityBasedConfigurationMissingEndpoint);
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOInputConnection"));
            Assert.AreEqual("SocketIO connection should have an 'WebPubSubForSocketIOConnectionString:endpoint' propert when it uses identity-based authentication, or it should set `WebPubSubForSocketIOConnectionString` setting to use access key based authentication.", exception.Message);
        }

        [TestCase]
        public async Task TestSocketIOOutput()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOOutput");
        }

        private static SocketIOTriggerEvent CreateTestTriggerEvent()
        {
            return new SocketIOTriggerEvent
            {
                ConnectionContext = TestContext,
                Request = new SocketIOConnectRequest("ns", "sid", null, null, null, null),
                TaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously)
            };
        }

        private static SocketIOTriggerEvent CreateTestMessageTriggerEvent()
        {
            return new SocketIOTriggerEvent
            {
                ConnectionContext = TestContext,
                Request = new SocketIOMessageRequest("ns", "sid", "42ns/,[\"msgEvent\", \"d1\", \"d2\"]", "msgEvent", new[] { "d1", "d2" }),
                TaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously)
            };
        }

        private static SocketIOSocketContext CreateConnectionContext()
        {
            return new SocketIOSocketContext(WebPubSubEventType.User, "message", "testhub", "000000", "uid", "/ns", "sid", "sig", "origin", null);
        }

        private sealed class SocketIOFuncs
        {
            public static void TestSocketIOTrigger(
                [SocketIOTrigger("chat", "connect")] SocketIOConnectRequest request,
                SocketIOSocketContext connectionContext)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
                Assert.AreEqual("uid", connectionContext.UserId);
            }

            public static void TestSocketIOTriggerWith2Param(
                [SocketIOTrigger("chat", "msgEvent", parameterNames: new[] { "arg1", "arg2" })] SocketIOMessageRequest request,
                SocketIOSocketContext connectionContext,
                string arg1,
                string arg2)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
                Assert.AreEqual("msgEvent", request.EventName);
                Assert.AreEqual("d1", arg1);
                Assert.AreEqual("d2", arg2);
                Assert.AreEqual("uid", connectionContext.UserId);
            }

            public static void TestSocketIOTriggerWith3Param(
                [SocketIOTrigger("chat", "msgEvent", parameterNames: new[] { "arg1", "arg2", "arg3" })] SocketIOMessageRequest request,
                SocketIOSocketContext connectionContext,
                string arg1,
                string arg2,
                string arg3)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
                Assert.AreEqual("msgEvent", request.EventName);
                Assert.AreEqual("d1", arg1);
                Assert.AreEqual("d2", arg2);
                Assert.AreEqual("uid", connectionContext.UserId);
            }

            public static void TestSocketIOTriggerWith2ParamAndParameterAttr(
                [SocketIOTrigger("chat", "msgEvent")] SocketIOMessageRequest request,
                SocketIOSocketContext connectionContext,
                [SocketIOParameter] string arg2,
                [SocketIOParameter] string arg1)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
                Assert.AreEqual("msgEvent", request.EventName);
                Assert.AreEqual("d1", arg2);
                Assert.AreEqual("d2", arg1);
                Assert.AreEqual("uid", connectionContext.UserId);
            }

            public static void TestSocketIOTriggerInvalid(
                [SocketIOTrigger("chat", "connect")] int request)
            {
            }

            public static void TestSocketIOInputConnection(
                [SocketIONegotiation(Hub = "chat")] SocketIONegotiationResult connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("https://abc/", connection.Endpoint.AbsoluteUri);
            }

            public static void TestSocketIOInputConnectionWithUserId(
                [SocketIONegotiation(Hub = "chat", UserId = "uid")] SocketIONegotiationResult connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("https://abc/", connection.Endpoint.AbsoluteUri);
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(connection.Token);
                Assert.AreEqual("uid", jwt.Subject);
            }

            public static async Task TestSocketIOOutput(
                [SocketIO(Hub = "chat")] IAsyncCollector<SocketIOAction> operation)
            {
                await operation.AddAsync(new SendToNamespaceAction
                {
                    EventName = "event",
                    Parameters = new[] { "arg1" },
                    Namespace = "/",
                });
            }

            public static async Task TestSocketIOOutputMissingHub(
                [SocketIO] IAsyncCollector<SocketIOAction> operation)
            {
                await operation.AddAsync(new SendToNamespaceAction
                {
                    EventName = "event",
                    Parameters = new[] { "arg1" },
                    Namespace = "/",
                });
            }

            public static Task<string> TestResponse(
                [HttpTrigger("get", "post")] HttpRequest req)
            {
                return Task.FromResult("test-response");
            }
        }
    }
}
