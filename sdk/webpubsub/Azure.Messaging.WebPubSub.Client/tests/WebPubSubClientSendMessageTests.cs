// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.WebPubSub.Clients;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class WebPubSubClientSendMessageTests
    {
        private Mock<IWebSocketClient> _webSocketClientMoc;
        private Mock<IWebSocketClientFactory> _factoryMoc;
        private WebPubSubClient _wpsClient;
        private Mock<WebPubSubProtocol> _protocolMoc;
        private MultipleTimesTaskCompletionSource<WebPubSubMessage> _tcs;

        [SetUp]
        public void WebPubSubProtocolMiddlewareTestsSetup()
        {
            _tcs = new MultipleTimesTaskCompletionSource<WebPubSubMessage>(100);
            _webSocketClientMoc = new Mock<IWebSocketClient>();
            _webSocketClientMoc.SetReturnsDefault(Task.CompletedTask);
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns<CancellationToken>(async token =>
            {
                await Task.Delay(int.MaxValue).AwaitWithCancellation(token);
                return new WebSocketReadResult(new ReadOnlySequence<byte>(), false);
            });
            _factoryMoc = new Mock<IWebSocketClientFactory>();
            _factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns(_webSocketClientMoc.Object);
            _protocolMoc = new Mock<WebPubSubProtocol>();
            _protocolMoc.Setup(p => p.GetMessageBytes(It.IsAny<WebPubSubMessage>())).Returns<WebPubSubMessage>(msg =>
            {
                _tcs.IncreaseCallTimes(msg);
                return default;
            });
            _wpsClient = new WebPubSubClient(new Uri("wss://test.com"), new WebPubSubClientOptions() { Protocol = _protocolMoc.Object });
        }

        [Test]
        public async Task JoinGroupTest()
        {
            _ = _wpsClient.JoinGroupAttemptAsync("group");
            var msg = (JoinGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual(1u, msg.AckId);

            _ = _wpsClient.JoinGroupAttemptAsync("group", 214578694245);
            msg = (JoinGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual(214578694245u, msg.AckId.Value);
        }

        [Test]
        public async Task LeaveGroupTest()
        {
            _ = _wpsClient.LeaveGroupAttemptAsync("group");
            var msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual(1u, msg.AckId);

            _ = _wpsClient.LeaveGroupAttemptAsync("group", 214578694245);
            msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual(214578694245u, msg.AckId);
        }

        [Test]
        public async Task SendToGroupTest()
        {
            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.AreEqual(1u, msg.AckId);
            Assert.False(msg.NoEcho);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.AreEqual(214578694245u, msg.AckId);
            Assert.False(msg.NoEcho);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245, true, true);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.AreEqual("group", msg.Group);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.Null(msg.AckId);
            Assert.True(msg.NoEcho);
        }

        [Test]
        public async Task SendEventTest()
        {
            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.AreEqual("event", msg.EventName);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.AreEqual(1u, msg.AckId);

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.AreEqual("event", msg.EventName);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.AreEqual(214578694245u, msg.AckId);

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245, true);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.AreEqual("event", msg.EventName);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.Null(msg.AckId);
        }

        [Test]
        public void OperationWithInvalidAckIdTest()
        {
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _wpsClient.JoinGroupAsync("group", -1));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _wpsClient.LeaveGroupAsync("group", -1));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _wpsClient.SendToGroupAsync("group", BinaryData.FromString("test"), WebPubSubDataType.Text, -1));
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _wpsClient.SendEventAsync("event", BinaryData.FromString("test"), WebPubSubDataType.Text, -1));
        }
    }
}
