// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.AI.VoiceLive.Diagnostics;

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
        private readonly VoiceLiveWebSocketContentLogger _contentLogger;
        private readonly string _connectionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncVoiceLiveMessageEnumerator"/> class.
        /// </summary>
        /// <param name="webSocket">The WebSocket to enumerate messages from.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="contentLogger">The content logger for WebSocket operations.</param>
        /// <param name="connectionId">The connection identifier for logging.</param>
        public AsyncVoiceLiveMessageEnumerator(WebSocket webSocket, CancellationToken cancellationToken, VoiceLiveWebSocketContentLogger contentLogger, string connectionId)
        {
            Argument.AssertNotNull(webSocket, nameof(webSocket));
            Argument.AssertNotNull(contentLogger, nameof(contentLogger));
            Argument.AssertNotNull(connectionId, nameof(connectionId));

            _webSocket = webSocket;
            // Use an 18K buffer size based on traffic observation; the connection will appropriately negotiate and use
            // fragmented messages if the buffer size is inadequate.
            _receiveBuffer = ArrayPool<byte>.Shared.Rent(1024 * 18);
            _cancellationToken = cancellationToken;
            _contentLogger = contentLogger;
            _connectionId = connectionId;
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

            WebSocketPipelineResponse websocketPipelineResponse = new();

            try
            {
                for (int partialMessageCount = 1; !websocketPipelineResponse.IsComplete; partialMessageCount++)
                {
                    WebSocketReceiveResult receiveResult = await _webSocket
                        .ReceiveAsync(new(_receiveBuffer), _cancellationToken)
                        .ConfigureAwait(false);

                    if (receiveResult.CloseStatus.HasValue)
                    {
                        if (_webSocket.State == WebSocketState.CloseReceived)
                        {
                            _contentLogger.LogConnectionClosing(_connectionId, (int)receiveResult.CloseStatus, receiveResult.CloseStatusDescription);
                            await _webSocket.CloseOutputAsync(receiveResult.CloseStatus.Value, "Acknowledge Close frame", CancellationToken.None).ConfigureAwait(false);
                            _contentLogger.LogConnectionClosed(_connectionId);
                        }
                        Current = null;
                        return false;
                    }

                    ReadOnlyMemory<byte> receivedBytes = _receiveBuffer.AsMemory(0, receiveResult.Count);
                    BinaryData receivedData = BinaryData.FromBytes(receivedBytes);

                    websocketPipelineResponse.IngestReceivedResult(receiveResult, receivedData);
                }

                Current = websocketPipelineResponse.GetContent();

                // Log received message content
                if (Current != null)
                {
                    var content = Current.ToMemory();
                    _contentLogger.LogReceivedMessage(_connectionId, content, isText: true);
                }

                return true;
            }
            catch (WebSocketException webEx)
            {
                // Log the error
                _contentLogger.LogError(_connectionId, $"WebSocket receive error: {webEx.Message}");

                var errorDetails = new SessionUpdateErrorDetails(webEx.GetType().Name, webEx.Message);

                var id = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var errorUpdate = new SessionUpdateError(errorDetails);

                var persistable = errorUpdate as IPersistableModel<SessionUpdateError>;
                var errorAsData = persistable?.Write(new ModelReaderWriterOptions("J")) ?? null;

                websocketPipelineResponse.IngestReceivedResult(errorAsData);

                Current = websocketPipelineResponse.GetContent();

                // Log error content if available
                if (Current != null)
                {
                    var content = Current.ToMemory();
                    _contentLogger.LogError(_connectionId, webEx.Message, content, isText: true);
                }

                return true;
            }
        }
    }
}
