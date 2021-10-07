// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Indexers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class JobHostEndToEndTests
    {
        private static ConnectionContext TestContext = CreateConnectionContext();
        private static BinaryData TestMessage = BinaryData.FromString("JobHostEndToEndTests");
        private static Dictionary<string, string> FuncConfiguration = new Dictionary<string, string>
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
                Message = TestMessage,
                DataType = MessageDataType.Text,
                TaskCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously)
            };
        }

        private static ConnectionContext CreateConnectionContext()
        {
            return new ConnectionContext
            {
                ConnectionId = "000000",
                EventName = "message",
                EventType = WebPubSubEventType.User,
                Hub = "testhub",
                UserId = "user1"
            };
        }

        private sealed class WebPubSubFuncs
        {
            public static void TestWebPubSubTrigger(
                [WebPubSubTrigger("chat", WebPubSubEventType.System, "connect")] ConnectionContext request)
            {
                // Valid case use default url for verification.
                Assert.AreEqual(TestContext, request);
            }

            public static void TestWebPubSubTriggerInvalid(
                [WebPubSubTrigger("chat", WebPubSubEventType.System, "connect")] int request)
            {
            }

            public static void TestWebPubSubInputConnection(
                [WebPubSubConnection(Hub = "chat", UserId = "aaa")] WebPubSubConnection connection)
            {
                // Valid case use default url for verification.
                Assert.AreEqual("wss://abc/client/hubs/chat", connection.BaseUrl);
            }

            public static async Task TestWebPubSubOutput(
                [WebPubSub(Hub = "chat")] IAsyncCollector<WebPubSubOperation> operation)
            {
                await operation.AddAsync(new SendToAll
                {
                    Message = TestMessage,
                    DataType = MessageDataType.Text
                });
            }

            public static async Task TestWebPubSubOutputMissingHub(
                [WebPubSub] IAsyncCollector<WebPubSubOperation> operation)
            {
                await operation.AddAsync(new SendToAll
                {
                    Message = TestMessage,
                    DataType = MessageDataType.Text
                });
            }
        }
    }
}
