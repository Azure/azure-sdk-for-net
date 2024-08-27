// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebPubSub.Common;
using NUnit.Framework;

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
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTrigger", args);
        }

        [TestCase]
        public async Task TestSocketIOTriggerWithIdentityBasedConfig()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: IdentityBasedConfiguration);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOTrigger", args);
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
        public async Task TestSocketIOInputBinding()
        {
            var host = TestHelpers.NewHost(typeof(SocketIOFuncs), configuration: KeyBasedConfiguration);

            await host.GetJobHost().CallAsync("SocketIOFuncs.TestSocketIOInputConnection");
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

        private static SocketIOSocketContext CreateConnectionContext()
        {
            return new SocketIOSocketContext(WebPubSubEventType.User, "message", "testhub", "000000", "/ns", "sid", "sig", "origin", null);
        }

        private sealed class SocketIOFuncs
        {
            public static void TestSocketIOTrigger(
                [SocketIOTrigger("chat", "connect")] SocketIOConnectRequest request,
                SocketIOSocketContext connectionContext)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
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

            public static async Task TestSocketIOOutput(
                [SocketIO(Hub = "chat")] IAsyncCollector<SocketIOAction> operation)
            {
                await operation.AddAsync(new SendToNamespaceAction
                {
                    Parameters = new[] { "arg1" },
                    Namespace = "/",
                });
            }

            public static async Task TestSocketIOOutputMissingHub(
                [SocketIO] IAsyncCollector<SocketIOAction> operation)
            {
                await operation.AddAsync(new SendToNamespaceAction
                {
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
