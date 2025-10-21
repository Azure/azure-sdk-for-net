// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.AI.VoiceLive.Diagnostics;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Provides asynchronous enumeration of WebSocket messages as BinaryData.
    /// </summary>
    internal class AsyncVoiceLiveMessageCollectionResult : IAsyncEnumerable<BinaryData>
    {
        private readonly WebSocket _webSocket;
        private readonly CancellationToken _cancellationToken;
        private readonly VoiceLiveWebSocketContentLogger _contentLogger;
        private readonly string _connectionId;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncVoiceLiveMessageCollectionResult"/> class.
        /// </summary>
        /// <param name="webSocket">The WebSocket to collect messages from.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="contentLogger">The content logger for WebSocket operations.</param>
        /// <param name="connectionId">The connection identifier for logging.</param>
        public AsyncVoiceLiveMessageCollectionResult(
            WebSocket webSocket,
            VoiceLiveWebSocketContentLogger contentLogger,
            string connectionId,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(webSocket, nameof(webSocket));
            Argument.AssertNotNull(contentLogger, nameof(contentLogger));
            Argument.AssertNotNull(connectionId, nameof(connectionId));

            _webSocket = webSocket;
            _cancellationToken = cancellationToken;
            _contentLogger = contentLogger;
            _connectionId = connectionId;
        }

        /// <inheritdoc/>
        public async IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0100
            await using IAsyncEnumerator<BinaryData> enumerator = new AsyncVoiceLiveMessageEnumerator(_webSocket, cancellationToken, _contentLogger, _connectionId);
#pragma warning restore AZC0100
            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
            {
                yield return enumerator.Current;
            }
        }
    }
}
