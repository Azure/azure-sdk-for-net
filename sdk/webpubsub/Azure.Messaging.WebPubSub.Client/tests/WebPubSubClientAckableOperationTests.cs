// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.WebPubSub.Client.Tests.Utils;
using Azure.Messaging.WebPubSub.Clients;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class WebPubSubClientAckableOperationTests
    {
        private Mock<IWebSocketClient> _webSocketClientMoc;
        private Mock<IWebSocketClientFactory> _factoryMoc;
        private WebPubSubProtocol _protocol;

        [SetUp]
        public void WebPubSubClientAckableOperationTestsSetup()
        {
            _protocol = new WebPubSubJsonReliableProtocol();
            _webSocketClientMoc = new Mock<IWebSocketClient>();
            _webSocketClientMoc.SetReturnsDefault(Task.CompletedTask);
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns<CancellationToken>(async token =>
            {
                await Task.Delay(int.MaxValue).AwaitWithCancellation(token);
                return new WebSocketReadResult(new ReadOnlySequence<byte>(), false);
            });
            _factoryMoc = new Mock<IWebSocketClientFactory>();
            _factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns(_webSocketClientMoc.Object);
        }

        [Test]
        public async Task SendMessageWithAckSucceededTest()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.SendMessageWithAckAsync(_ => new JoinGroupMessage("group", 1), 1, default);
            TestUtils.AssertTimeout(t);

            client.HandleAckMessage(new AckMessage(1, true, null));
            await t.OrTimeout();
        }

        [Test]
        public void SendMessageWithAckFailedTest()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.SendMessageWithAckAsync(_ => new JoinGroupMessage("group", 1), 1, default);
            TestUtils.AssertTimeout(t);

            client.HandleAckMessage(new AckMessage(1, false, new AckMessageError("error", "message")));
            var ex = Assert.ThrowsAsync<SendMessageFailedException>(() => t);
            Assert.AreEqual(1u, ex.AckId);
            Assert.AreEqual("error", ex.Code);
            Assert.AreEqual("Received non-success acknowledge from the service: message", ex.Message);
        }

        [Test]
        public async Task SendMessageWithAckDuplicateTest()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.SendMessageWithAckAsync(_ => new JoinGroupMessage("group", 1), 1, default);
            TestUtils.AssertTimeout(t);

            client.HandleAckMessage(new AckMessage(1, false, new AckMessageError("Duplicate", "message")));
            await t.OrTimeout();
        }

        [Test]
        public async Task AckableOperationIntegrationTest_Success()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var client = new WebPubSubClient(new Uri("wss://test.com"));
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();

            var t = client.JoinGroupAsync("group", 1);
            TestUtils.AssertTimeout(t);
            await wsPair.Output().OrTimeout();

            wsPair.Input(TestUtils.GetAckMessagePayload(1, null), false);
            await t.OrTimeout();
        }

        [Test]
        public async Task AckableOperationIntegrationTest_Failed()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var options = new WebPubSubClientOptions();
            options.MessageRetryOptions.MaxRetries = 0;
            var client = new WebPubSubClient(new Uri("wss://test.com"), options);
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();

            var t = client.JoinGroupAsync("group", 1);
            TestUtils.AssertTimeout(t);
            await wsPair.Output().OrTimeout();

            wsPair.Input(TestUtils.GetAckMessagePayload(1, "InternalServerError"), false);
            Assert.ThrowsAsync<SendMessageFailedException>(() => t);
        }

        [Test]
        public async Task AckableOperationIntegrationTest_AllRetryFailed()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var client = new WebPubSubClient(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();

            var t = client.JoinGroupAsync("group", 1);
            TestUtils.AssertTimeout(t);

            // return 4 times ack failure
            for (var i = 0; i < 4; i++)
            {
                await wsPair.Output().OrTimeout();
                wsPair.Input(TestUtils.GetAckMessagePayload(1, "InternalServerError"), false);
            }
            Assert.ThrowsAsync<SendMessageFailedException>(() => t);
        }

        [Test]
        public async Task AckableOperationIntegrationTest_1FailedAndRetrySuccess()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var client = new WebPubSubClient(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();

            var t = client.JoinGroupAsync("group", 1);

            // 1
            await wsPair.Output().OrTimeout();
            wsPair.Input(TestUtils.GetAckMessagePayload(1, "InternalServerError"), false);

            // 2
            await wsPair.Output().OrTimeout();
            wsPair.Input(TestUtils.GetAckMessagePayload(1, "InternalServerError"), false);

            // 3
            await wsPair.Output().OrTimeout();
            wsPair.Input(TestUtils.GetAckMessagePayload(1, "InternalServerError"), false);

            // 4
            await wsPair.Output().OrTimeout();
            wsPair.Input(TestUtils.GetAckMessagePayload(1, null), false);

            await t.OrTimeout();
        }

        [Test]
        public async Task CleanAckableAfterConnectionClose()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var client = new WebPubSubClient(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest(options => options.MaxRetries = 0));
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();
            var t1 = client.JoinGroupAsync("group1", 1);
            var t2 = client.JoinGroupAsync("group2", 2);
            var t3 = client.JoinGroupAsync("group3", 3);

            await wsPair.Output().OrTimeout();
            await wsPair.Output().OrTimeout();
            await wsPair.Output().OrTimeout();

            // Close connection
            wsPair.Input(default, true);
            Assert.ThrowsAsync<SendMessageFailedException>(() => t1);
            Assert.ThrowsAsync<SendMessageFailedException>(() => t2);
            Assert.ThrowsAsync<SendMessageFailedException>(() => t3);
        }

        [Test]
        public async Task AckableOperationCancellationTest()
        {
            var wsPair = new TestWebSocketClientPair(_webSocketClientMoc);
            var options = new WebPubSubClientOptions();
            options.MessageRetryOptions.MaxRetries = 0;
            var client = new WebPubSubClient(new Uri("wss://test.com"), options);
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync();

            var cts = new CancellationTokenSource();
            var t = client.JoinGroupAsync("group", 1, cancellationToken: cts.Token);
            TestUtils.AssertTimeout(t);
            await wsPair.Output().OrTimeout();

            cts.Cancel();
            var ex = Assert.ThrowsAsync<SendMessageFailedException>(() => t);

            // Retry won't be affected
            var t2 = client.JoinGroupAsync("group", ex.AckId);
            TestUtils.AssertTimeout(t2);

            wsPair.Input(TestUtils.GetAckMessagePayload(1, null), false);
            await t2.OrTimeout();
        }
    }
}
