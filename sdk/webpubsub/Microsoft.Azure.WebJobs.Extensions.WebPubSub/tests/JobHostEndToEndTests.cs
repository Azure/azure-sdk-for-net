// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Microsoft.Azure.WebPubSub.Common;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JobHostEndToEndTests
    {
        private static readonly WebPubSubConnectionContext TestContext = CreateConnectionContext();
        private static readonly BinaryData TestMessage = BinaryData.FromString("JobHostEndToEndTests");
        private static readonly Dictionary<string, string> FuncConfiguration_WithGlobalConnectionString = new()
        {
            { Constants.WebPubSubConnectionStringName, "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;" }
        };
        private static readonly Dictionary<string, string> FuncConfiguration_WithGlobalIdentity = new()
        {
            { Constants.WebPubSubConnectionStringName+":serviceUri", "https://abc" }
        };
        private static readonly Dictionary<string, string> FuncConfiguration_WithLocalConnectionString = new()
        {
            { "LocalConnection", "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;" }
        };
        private static readonly Dictionary<string, string> FuncConfiguration_WithLocalIdentity = new()
        {
            { "LocalConnection:serviceUri", "https://abc" }
        };

        public static readonly IEnumerable<object[]> FuncConfigurationWithGlobalConnection =
        [
            [FuncConfiguration_WithGlobalConnectionString],
            [FuncConfiguration_WithGlobalIdentity]
        ];
        public static readonly IEnumerable<object[]> FuncConfigurationWithLocalConnection =
        [
            [FuncConfiguration_WithLocalConnectionString],
            [FuncConfiguration_WithLocalIdentity]
        ];

        [TestCase]
        public async Task TestWebPubSubTrigger()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_GlobalConnection), configuration: FuncConfiguration_WithGlobalConnectionString);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            await host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubTrigger), args);
        }

        [TestCase]
        public void TestWebPubSubTrigger_InvalidBindingObject()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_GlobalConnection), configuration: FuncConfiguration_WithGlobalConnectionString);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            var task = host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubTriggerInvalid), args);
            var exception = Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.AreEqual($"Exception while executing function: {nameof(WebPubSubFuncs_GlobalConnection)}.{nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubTriggerInvalid)}", exception.Message);
        }

        [TestCase]
        public async Task TestWebPubSubInputBindingWithGlobalConnection()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_GlobalConnection), configuration: FuncConfiguration_WithGlobalConnectionString);
            // Identity-based connection is not tested because it makes real network connection during the test.

            await host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubInputConnection));

            await host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestMqttInputConnection));
        }

        [TestCase]
        public void TestWebPubSubInputBinding_MissingConnection()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_GlobalConnection));
            var task = host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubInputConnection));
            var exception = Assert.ThrowsAsync<FunctionIndexingException>(() => task);
            Assert.AreEqual($"Error indexing method '{nameof(WebPubSubFuncs_GlobalConnection)}.{nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubInputConnection)}'", exception.Message);
        }

        [TestCaseSource(nameof(FuncConfigurationWithGlobalConnection))]
        public async Task TestWebPubSubOutputWithGlobalConnection(Dictionary<string, string> config)
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_GlobalConnection), configuration: config);

            await host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_GlobalConnection) + "." + nameof(WebPubSubFuncs_GlobalConnection.TestWebPubSubOutput));
        }

        [TestCaseSource(nameof(FuncConfigurationWithLocalConnection))]
        public async Task TestWebPubSubOutputWithLocalConnection(Dictionary<string, string> config)
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs_LocalConnection), configuration: config);

            await host.GetJobHost().CallAsync(nameof(WebPubSubFuncs_LocalConnection) + "." + nameof(WebPubSubFuncs_LocalConnection.TestWebPubSubOutput));
        }

        [TestCase]
        public void TestWebPubSubMissingHub()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubMissingHubFuncs), configuration: FuncConfiguration_WithGlobalConnectionString);

            var task = host.GetJobHost().CallAsync(nameof(WebPubSubMissingHubFuncs) + "." + nameof(WebPubSubMissingHubFuncs.TestWebPubSubOutputMissingHub));
            var exception = Assert.ThrowsAsync<FunctionIndexingException>(() => task);
            Assert.AreEqual($"Error indexing method '{nameof(WebPubSubMissingHubFuncs)}.{nameof(WebPubSubMissingHubFuncs.TestWebPubSubOutputMissingHub)}'", exception.Message);
        }

        private static WebPubSubTriggerEvent CreateTestTriggerEvent()
        {
            return new WebPubSubTriggerEvent
            {
                ConnectionContext = TestContext,
                Data = TestMessage,
                DataType = WebPubSubDataType.Text,
                TaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously)
            };
        }

        private static WebPubSubConnectionContext CreateConnectionContext()
        {
            return new WebPubSubConnectionContext(WebPubSubEventType.User, "message", "testhub", "000000", "user1");
        }

        private sealed class WebPubSubFuncs_GlobalConnection
        {
            public static void TestWebPubSubTrigger(
                [WebPubSubTrigger("chat", WebPubSubEventType.System, "connect")] ConnectEventRequest request,
                WebPubSubConnectionContext connectionContext)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, connectionContext);
            }

            public static void TestWebPubSubTriggerInvalid(
                [WebPubSubTrigger("chat", WebPubSubEventType.System, "connect")] int request)
            {
            }

            public static void TestWebPubSubInputConnection(
                [WebPubSubConnection(Hub = "chat", UserId = "aaa")] WebPubSubConnection connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("wss://abc/client/hubs/chat", connection.BaseUri.AbsoluteUri);
            }

            public static void TestMqttInputConnection(
                [WebPubSubConnection(Hub = "chat", UserId = "aaa", ClientProtocol = WebPubSubClientProtocol.Mqtt)] WebPubSubConnection connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("wss://abc/clients/mqtt/hubs/chat", connection.BaseUri.AbsoluteUri);
            }

            public static async Task TestWebPubSubOutput(
                [WebPubSub(Hub = "chat")] IAsyncCollector<WebPubSubAction> operation)
            {
                await operation.AddAsync(new SendToAllAction
                {
                    Data = TestMessage,
                    DataType = WebPubSubDataType.Text
                });
            }

            public static Task<string> TestResponse(
                [HttpTrigger("get", "post")] HttpRequest req)
            {
                return Task.FromResult("test-response");
            }
        }

        private sealed class WebPubSubFuncs_LocalConnection
        {
            public static void TestWebPubSubInputConnection(
    [WebPubSubConnection(Hub = "chat", UserId = "aaa", Connection = "LocalConnection")] WebPubSubConnection connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("wss://abc/client/hubs/chat", connection.BaseUri.AbsoluteUri);
            }

            public static async Task TestWebPubSubOutput(
    [WebPubSub(Hub = "chat", Connection = "LocalConnection")] IAsyncCollector<WebPubSubAction> operation)
            {
                await operation.AddAsync(new SendToAllAction
                {
                    Data = TestMessage,
                    DataType = WebPubSubDataType.Text
                });
            }
        }

        private sealed class WebPubSubMissingHubFuncs
        {
            public static async Task TestWebPubSubOutputMissingHub(
                [WebPubSub] IAsyncCollector<WebPubSubAction> operation)
            {
                await operation.AddAsync(new SendToAllAction
                {
                    Data = TestMessage,
                    DataType = WebPubSubDataType.Text
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
