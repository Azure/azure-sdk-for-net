// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using System.ClientModel.Primitives;

namespace Azure.AI.VoiceLive
{
    public partial class VoiceLiveSession
    {
        /// <summary>
        /// Gets all server events from the VoiceLive service as an asynchronous enumerable.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of VoiceLive server events.</returns>
        /// <remarks>
        /// This method provides streaming access to all server events from the service, including session events,
        /// input audio processing events, response streaming, and error notifications.
        ///
        /// The method handles WebSocket message fragmentation automatically and ensures that complete
        /// messages are processed before yielding events.
        /// </remarks>
        public async IAsyncEnumerable<SessionUpdate> GetUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            // Ensure we're connected before starting to receive updates
            if (WebSocket?.State != WebSocketState.Open)
            {
                throw new InvalidOperationException("Session must be connected before retrieving updates.");
            }

            // Use lock to ensure only one reader at a time
            lock (_singleReceiveLock)
            {
                if (_receiveCollectionResult != null)
                {
                    throw new InvalidOperationException("Only one update enumeration can be active at a time.");
                }

                _receiveCollectionResult = new AsyncVoiceLiveMessageCollectionResult(WebSocket, cancellationToken);
            }

            try
            {
                await foreach (BinaryData message in _receiveCollectionResult.WithCancellation(cancellationToken))
                {
                    // Process the message and yield any server events
                    foreach (SessionUpdate serverEvent in ProcessMessage(message))
                    {
                        yield return serverEvent;
                    }
                }
            }
            finally
            {
                lock (_singleReceiveLock)
                {
                    _receiveCollectionResult = null;
                }
            }
        }

        /// <summary>
        /// Gets all server events from the VoiceLive service synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An enumerable of VoiceLive server events.</returns>
        /// <remarks>
        /// This method provides synchronous access to all server events from the service.
        /// For better performance and resource utilization, consider using <see cref="GetUpdatesAsync(CancellationToken)"/> instead.
        /// </remarks>
        public IEnumerable<SessionUpdate> GetUpdates(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync(cancellationToken).ToBlockingEnumerable(cancellationToken);
        }

        /// <summary>
        /// Gets server events of a specific type from the VoiceLive service.
        /// </summary>
        /// <typeparam name="T">The specific type of server event to filter for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of server events of the specified type.</returns>
        public async IAsyncEnumerable<T> GetUpdatesAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default)
            where T : SessionUpdate
        {
            await foreach (SessionUpdate serverEvent in GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                if (serverEvent is T typedEvent)
                {
                    yield return typedEvent;
                }
            }
        }

        /// <summary>
        /// Waits for the next server event of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of server event to wait for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The next server event of the specified type.</returns>
        public async Task<T> WaitForUpdateAsync<T>(CancellationToken cancellationToken = default)
            where T : SessionUpdate
        {
            await foreach (T serverEvent in GetUpdatesAsync<T>(cancellationToken).ConfigureAwait(false))
            {
                return serverEvent;
            }

            throw new OperationCanceledException("No server event received before cancellation.", cancellationToken);
        }

        /// <summary>
        /// Processes a WebSocket message and converts it to VoiceLive server events.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <returns>An enumerable of server events extracted from the message.</returns>
        private IEnumerable<SessionUpdate> ProcessMessage(BinaryData message)
        {
            if (message == null || message.ToArray().Length == 0)
            {
                yield break;
            }

            SessionUpdate sessionUpdate = null;
            try
            {
                // Try to parse as JSON first
                using JsonDocument document = JsonDocument.Parse(message);
                JsonElement root = document.RootElement;

                // Deserialize as a server event
                sessionUpdate = SessionUpdate.DeserializeSessionUpdate(root, ModelSerializationExtensions.WireOptions);
            }
            catch (JsonException)
            {
                // If JSON parsing fails, ignore the message
                yield break;
            }
            catch (Exception)
            {
                // If deserialization fails completely, ignore the message
                yield break;
            }

            if (sessionUpdate != null)
            {
                yield return sessionUpdate;
            }
        }
    }
}
