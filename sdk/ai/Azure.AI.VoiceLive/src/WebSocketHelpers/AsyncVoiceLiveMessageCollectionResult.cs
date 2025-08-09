// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Provides asynchronous enumeration of WebSocket messages as BinaryData.
    /// </summary>
    internal class AsyncVoiceLiveMessageCollectionResult : IAsyncEnumerable<BinaryData>
    {
        private readonly WebSocket _webSocket;
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncVoiceLiveMessageCollectionResult"/> class.
        /// </summary>
        /// <param name="webSocket">The WebSocket to collect messages from.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        public AsyncVoiceLiveMessageCollectionResult(
            WebSocket webSocket,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(webSocket, nameof(webSocket));

            _webSocket = webSocket;
            _cancellationToken = cancellationToken;
        }

        /// <inheritdoc/>
        public async IAsyncEnumerator<BinaryData> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
#pragma warning disable AZC0100
            await using IAsyncEnumerator<BinaryData> enumerator = new AsyncVoiceLiveMessageEnumerator(_webSocket, cancellationToken);
#pragma warning restore AZC0100
            while (await enumerator.MoveNextAsync().ConfigureAwait(false))
            {
                yield return enumerator.Current;
            }
        }
    }
}
