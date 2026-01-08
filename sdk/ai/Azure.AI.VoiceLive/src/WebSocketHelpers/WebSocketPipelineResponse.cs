// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Net.WebSockets;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Handles accumulation of WebSocket message data across multiple receive operations.
    /// </summary>
    /// <remarks>
    /// WebSocket messages can be split across multiple network receive operations and a single
    /// <see cref="WebSocketPipelineResponse"/> may thus ingest and present data across several such operations.
    /// </remarks>
    internal class WebSocketPipelineResponse
    {
        private readonly MemoryStream _contentStream = new();

        /// <summary>
        /// Gets a value indicating whether the WebSocket message is complete.
        /// </summary>
        public bool IsComplete { get; private set; } = false;

        /// <summary>
        /// Ingests a received WebSocket result and associated data.
        /// </summary>
        /// <param name="receivedResult">The WebSocket receive result.</param>
        /// <param name="receivedBytes">The received data.</param>
        public void IngestReceivedResult(WebSocketReceiveResult receivedResult, BinaryData receivedBytes)
        {
            if (receivedResult.MessageType != WebSocketMessageType.Text)
            {
                throw new NotSupportedException($"{nameof(WebSocketPipelineResponse)} currently supports only text messages.");
            }

            byte[] rawReceivedBytes = receivedBytes.ToArray();
            _contentStream.Position = _contentStream.Length;
            _contentStream.Write(rawReceivedBytes, 0, rawReceivedBytes.Length);
            _contentStream.Position = 0;
            IsComplete = receivedResult.EndOfMessage;
        }

        /// <summary>
        /// Ingests a received WebSocket result and associated data.
        /// </summary>
        /// <remarks>
        /// This overload is intended to be used to insert and error message into the stream
        /// when a websocket error occurs.
        /// </remarks>
        /// <param name="receivedBytes">The received data.</param>
        public void IngestReceivedResult(BinaryData receivedBytes)
        {
            byte[] rawReceivedBytes = receivedBytes.ToArray();
            _contentStream.Position = _contentStream.Length;
            _contentStream.Write(rawReceivedBytes, 0, rawReceivedBytes.Length);
            _contentStream.Position = 0;
            IsComplete = true;
        }

        /// <summary>
        /// Gets the accumulated message content as BinaryData.
        /// </summary>
        /// <returns>The complete message content.</returns>
        public BinaryData GetContent()
        {
            return BinaryData.FromStream(_contentStream);
        }
    }
}
