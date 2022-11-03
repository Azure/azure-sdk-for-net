// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP3_1_OR_GREATER
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
using Xunit;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    public class WebPubSubProtocolMiddlewareTests
    {
        private readonly Mock<IWebSocketClient> _webSocketClientMoc;
        private readonly Mock<IWebSocketClientFactory> _factoryMoc;
        private readonly WebPubSubClient _wpsClient;
        private readonly Mock<WebPubSubProtocol> _protocolMoc;
        private readonly MultipleTimesTaskCompletionSource<WebPubSubMessage> _tcs = new MultipleTimesTaskCompletionSource<WebPubSubMessage>(100);

        public WebPubSubProtocolMiddlewareTests()
        {
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

        [Fact]
        public async Task JoinGroupTest()
        {
            _ = _wpsClient.JoinGroupAttemptAsync("group");
            var msg = (JoinGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal(1u, msg.AckId);

            _ = _wpsClient.JoinGroupAttemptAsync("group", 214578694245u);
            msg = (JoinGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal(214578694245u, msg.AckId.Value);
        }

        [Fact]
        public async Task LeaveGroupTest()
        {
            _ = _wpsClient.LeaveGroupAttemptAsync("group");
            var msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal(1u, msg.AckId);

            _ = _wpsClient.LeaveGroupAttemptAsync("group", 214578694245u);
            msg = (LeaveGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal(214578694245u, msg.AckId);
        }

        [Fact]
        public async Task SendToGroupTest()
        {
            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Equal(1u, msg.AckId);
            Assert.False(msg.NoEcho);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245u);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Equal(214578694245u, msg.AckId);
            Assert.False(msg.NoEcho);

            _ = _wpsClient.SendToGroupAttemptAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245u, true, true);
            msg = (SendToGroupMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.Equal("group", msg.Group);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Null(msg.AckId);
            Assert.True(msg.NoEcho);
        }

        [Fact]
        public async Task SendEventTest()
        {
            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text);
            var msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("event", msg.EventName);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Equal(1u, msg.AckId);

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245u);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("event", msg.EventName);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Equal(214578694245u, msg.AckId);

            _ = _wpsClient.SendEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, 214578694245u, true);
            msg = (SendEventMessage)await _tcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.Equal("event", msg.EventName);
            Assert.Equal("text", msg.Data.ToString());
            Assert.Equal(WebPubSubDataType.Text, msg.DataType);
            Assert.Null(msg.AckId);
        }
    }
}
#endif
