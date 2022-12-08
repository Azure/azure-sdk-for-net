// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using Azure.Messaging.WebPubSub.Clients;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace Azure.Messaging.WebPubSub.Client.Tests.Utils
{
    internal class TestWebSocketClientPair
    {
        private readonly Mock<IWebSocketClient> _mockWebSocketClient;
        private readonly MultipleTimesTaskCompletionSource<InputItem> _input = new MultipleTimesTaskCompletionSource<InputItem>(1000);
        private readonly MultipleTimesTaskCompletionSource<OutputItem> _output = new MultipleTimesTaskCompletionSource<OutputItem>(1000);
        private volatile int _inputIdx = 1;
        private volatile int _outputIdx = 1;

        private struct InputItem
        {
            public ReadOnlySequence<byte> Payload { get; set; }
            public bool IsClose { get; set; }
            public WebSocketCloseStatus? CloseStatus { get; set; }
        }
        private struct OutputItem
        {
            public ReadOnlyMemory<byte> Payload { get; set; }
            public WebSocketMessageType WebSocketMessageType { get; set; }
        }

        internal TestWebSocketClientPair(Mock<IWebSocketClient> clientMoc)
        {
            _mockWebSocketClient = clientMoc;
            _mockWebSocketClient.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns<CancellationToken>(async token =>
            {
                var item = await _input.VerifyCalledTimesAsync(_inputIdx);
                _inputIdx++;
                return new WebSocketReadResult(item.Payload, item.IsClose, item.CloseStatus);
            });
            _mockWebSocketClient.Setup(c => c.SendAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebSocketMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).
                Returns<ReadOnlyMemory<byte>, WebSocketMessageType, bool, CancellationToken>((p, t, e, c) =>
            {
                _output.IncreaseCallTimes(new OutputItem { Payload = p, WebSocketMessageType = t });
                return Task.CompletedTask;
            });
        }

        public void Input(ReadOnlySequence<byte> payload, bool isClose, WebSocketCloseStatus? closeStatus = null)
        {
            _input.IncreaseCallTimes(new InputItem { Payload = payload, IsClose = isClose, CloseStatus = closeStatus });
        }

        public async Task<ReadOnlyMemory<byte>> Output()
        {
            var item = await _output.VerifyCalledTimesAsync(_outputIdx);
            _outputIdx++;
            return item.Payload;
        }
    }
}
