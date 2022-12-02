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
            Assert.AreEqual("error", ex.Error.Name);
            Assert.AreEqual("message", ex.Error.Message);
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
    }
}
