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
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.AckId, Is.EqualTo(1u));

            _ = _wpsClient.JoinGroupAttemptAsync("group", 214578694245);
            msg = (JoinGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.AckId.Value, Is.EqualTo(214578694245u));
        }

        [Test]
        public async Task LeaveGroupTest()
        {
            _ = _wpsClient.LeaveGroupAttemptAsync("group");
            var msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.AckId, Is.EqualTo(1u));

            _ = _wpsClient.LeaveGroupAttemptAsync("group", 214578694245);
            msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.AckId, Is.EqualTo(214578694245u));
        }

        [Test]
        public async Task SendToGroupTest()
        {
            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.EqualTo(1u));
            Assert.That(msg.NoEcho, Is.False);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.EqualTo(214578694245u));
            Assert.That(msg.NoEcho, Is.False);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245, true, true);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.That(msg.Group, Is.EqualTo("group"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.Null);
            Assert.That(msg.NoEcho, Is.True);
        }

        [Test]
        public async Task SendEventTest()
        {
            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.That(msg.EventName, Is.EqualTo("event"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.EqualTo(1u));

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.That(msg.EventName, Is.EqualTo("event"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.EqualTo(214578694245u));

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245, true);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.That(msg.EventName, Is.EqualTo("event"));
            Assert.That(msg.Data.ToString(), Is.EqualTo("text"));
            Assert.That(msg.DataType, Is.EqualTo(WebPubSubDataType.Text));
            Assert.That(msg.AckId, Is.Null);
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
