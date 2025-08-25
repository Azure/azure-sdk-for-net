// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Provides asynchronous enumeration of WebSocket messages as BinaryData.
    /// </summary>
    internal class AsyncVoiceLiveMessageEnumerator : IAsyncEnumerator<BinaryData>
    {
        /// <inheritdoc/>
        public BinaryData Current { get; private set; }

        private readonly CancellationToken _cancellationToken;
        private readonly WebSocket _webSocket;
        private byte[] _receiveBuffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncVoiceLiveMessageEnumerator"/> class.
        /// </summary>
        /// <param name="webSocket">The WebSocket to enumerate messages from.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public AsyncVoiceLiveMessageEnumerator(WebSocket webSocket, CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(webSocket, nameof(webSocket));

            _webSocket = webSocket;
            // Use an 18K buffer size based on traffic observation; the connection will appropriately negotiate and use
            // fragmented messages if the buffer size is inadequate.
            _receiveBuffer = ArrayPool<byte>.Shared.Rent(1024 * 18);
            _cancellationToken = cancellationToken;
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            if (Interlocked.Exchange(ref _receiveBuffer, null) is byte[] toReturn)
            {
                ArrayPool<byte>.Shared.Return(toReturn);
            }
            return default;
        }

        /// <inheritdoc/>
        public async ValueTask<bool> MoveNextAsync()
        {
            if (_receiveBuffer == null)
            {
                Current = null;
                return false;
            }

            try
            {
                WebSocketPipelineResponse websocketPipelineResponse = new();
                for (int partialMessageCount = 1; !websocketPipelineResponse.IsComplete; partialMessageCount++)
                {
                    WebSocketReceiveResult receiveResult = await _webSocket
                        .ReceiveAsync(new(_receiveBuffer), _cancellationToken)
                        .ConfigureAwait(false);

                    if (receiveResult.CloseStatus.HasValue)
                    {
                        Current = null;
                        return false;
                    }

                    ReadOnlyMemory<byte> receivedBytes = _receiveBuffer.AsMemory(0, receiveResult.Count);
                    BinaryData receivedData = BinaryData.FromBytes(receivedBytes);

                    websocketPipelineResponse.IngestReceivedResult(receiveResult, receivedData);
                }

                Current = websocketPipelineResponse.GetContent();
                return true;
            }
            catch (WebSocketException)
            {
                Current = null;
                return false;
            }
        }
    }
}
