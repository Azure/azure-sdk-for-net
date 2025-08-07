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
        private static readonly Dictionary<string, string> FuncConfiguration = new()
        {
            { Constants.WebPubSubConnectionStringName, "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;" }
        };

        [TestCase]
        public async Task TestWebPubSubTrigger()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs), configuration: FuncConfiguration);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            await host.GetJobHost().CallAsync("WebPubSubFuncs.TestWebPubSubTrigger", args);
        }

        [TestCase]
        public void TestWebPubSubTrigger_InvalidBindingObject()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs), configuration: FuncConfiguration);
            var args = new Dictionary<string, object>
            {
                { "request", CreateTestTriggerEvent() }
            };

            var task = host.GetJobHost().CallAsync("WebPubSubFuncs.TestWebPubSubTriggerInvalid", args);
            var exception = Assert.ThrowsAsync<FunctionInvocationException>(() => task);
            Assert.AreEqual("Exception while executing function: WebPubSubFuncs.TestWebPubSubTriggerInvalid", exception.Message);
        }

        [TestCase]
        public async Task TestWebPubSubInputBinding()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs), configuration: FuncConfiguration);

            await host.GetJobHost().CallAsync("WebPubSubFuncs.TestWebPubSubInputConnection");

            await host.GetJobHost().CallAsync("WebPubSubFuncs.TestMqttInputConnection");
        }

        [TestCase]
        public void TestWebPubSubInputBinding_MissingConnectionString()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs));
            var task = host.GetJobHost().CallAsync("WebPubSubFuncs.TestWebPubSubInputConnection");
            var exception = Assert.ThrowsAsync<FunctionIndexingException>(() => task);
            Assert.AreEqual($"Error indexing method 'WebPubSubFuncs.TestWebPubSubInputConnection'", exception.Message);
        }

        [TestCase]
        public async Task TestWebPubSubOutput()
        {
            var host = TestHelpers.NewHost(typeof(WebPubSubFuncs), configuration: FuncConfiguration);

            await host.GetJobHost().CallAsync("WebPubSubFuncs.TestWebPubSubOutput");
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

        private sealed class WebPubSubFuncs
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
