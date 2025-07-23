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
        /// Gets all updates from the VoiceLive service as an asynchronous enumerable.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of VoiceLive updates.</returns>
        /// <remarks>
        /// This method provides streaming access to all updates from the service, including session events,
        /// input audio processing updates, response streaming, and error notifications.
        ///
        /// The method handles WebSocket message fragmentation automatically and ensures that complete
        /// messages are processed before yielding updates.
        /// </remarks>
        public async IAsyncEnumerable<VoiceLiveUpdate> GetUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
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
                    // Fire the ReceivingMessage event
                    ReceivingMessage?.Invoke(this, message);

                    // Process the message and yield any updates
                    foreach (VoiceLiveUpdate update in ProcessMessage(message))
                    {
                        yield return update;
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
        /// Gets all updates from the VoiceLive service synchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An enumerable of VoiceLive updates.</returns>
        /// <remarks>
        /// This method provides synchronous access to all updates from the service.
        /// For better performance and resource utilization, consider using <see cref="GetUpdatesAsync(CancellationToken)"/> instead.
        /// </remarks>
        public IEnumerable<VoiceLiveUpdate> GetUpdates(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync(cancellationToken).ToBlockingEnumerable(cancellationToken);
        }

        /// <summary>
        /// Gets updates of a specific type from the VoiceLive service.
        /// </summary>
        /// <typeparam name="T">The specific type of update to filter for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of updates of the specified type.</returns>
        public async IAsyncEnumerable<T> GetUpdatesAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default)
            where T : VoiceLiveUpdate
        {
            await foreach (VoiceLiveUpdate update in GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                if (update is T typedUpdate)
                {
                    yield return typedUpdate;
                }
            }
        }

        /// <summary>
        /// Gets updates of specific kinds from the VoiceLive service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <param name="kinds">The specific kinds of updates to filter for.</param>
        /// <returns>An asynchronous enumerable of updates of the specified kinds.</returns>
        public async IAsyncEnumerable<VoiceLiveUpdate> GetUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default, params VoiceLiveUpdateKind[] kinds)
        {
            if (kinds == null || kinds.Length == 0)
            {
                await foreach (VoiceLiveUpdate update in GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
                {
                    yield return update;
                }
                yield break;
            }

            var kindSet = new HashSet<VoiceLiveUpdateKind>(kinds);

            await foreach (VoiceLiveUpdate update in GetUpdatesAsync(cancellationToken).ConfigureAwait(false))
            {
                if (kindSet.Contains(update.Kind))
                {
                    yield return update;
                }
            }
        }

        /// <summary>
        /// Waits for the next update of a specific type.
        /// </summary>
        /// <typeparam name="T">The type of update to wait for.</typeparam>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The next update of the specified type.</returns>
        public async Task<T> WaitForUpdateAsync<T>(CancellationToken cancellationToken = default)
            where T : VoiceLiveUpdate
        {
            await foreach (T update in GetUpdatesAsync<T>(cancellationToken).ConfigureAwait(false))
            {
                return update;
            }

            throw new OperationCanceledException("No update received before cancellation.", cancellationToken);
        }

        /// <summary>
        /// Waits for the next update of a specific kind.
        /// </summary>
        /// <param name="kind">The kind of update to wait for.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>The next update of the specified kind.</returns>
        public async Task<VoiceLiveUpdate> WaitForUpdateAsync(VoiceLiveUpdateKind kind, CancellationToken cancellationToken = default)
        {
            await foreach (VoiceLiveUpdate update in GetUpdatesAsync(cancellationToken, kind).ConfigureAwait(false))
            {
                return update;
            }

            throw new OperationCanceledException("No update received before cancellation.", cancellationToken);
        }

        /// <summary>
        /// Gets all delta updates (streaming content) from the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of delta updates.</returns>
        public IAsyncEnumerable<OutputDeltaUpdate> GetDeltaUpdatesAsync(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync<OutputDeltaUpdate>(cancellationToken);
        }

        /// <summary>
        /// Gets all streaming updates from the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of streaming updates.</returns>
        public IAsyncEnumerable<OutputStreamingUpdate> GetStreamingUpdatesAsync(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync<OutputStreamingUpdate>(cancellationToken);
        }

        /// <summary>
        /// Gets all input audio updates from the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of input audio updates.</returns>
        public IAsyncEnumerable<InputAudioUpdate> GetInputAudioUpdatesAsync(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync<InputAudioUpdate>(cancellationToken);
        }

        /// <summary>
        /// Gets all error updates from the service.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of error updates.</returns>
        public IAsyncEnumerable<ErrorUpdate> GetErrorUpdatesAsync(CancellationToken cancellationToken = default)
        {
            return GetUpdatesAsync<ErrorUpdate>(cancellationToken);
        }

        /// <summary>
        /// Processes a WebSocket message and converts it to VoiceLive updates.
        /// </summary>
        /// <param name="message">The message to process.</param>
        /// <returns>An enumerable of updates extracted from the message.</returns>
        private IEnumerable<VoiceLiveUpdate> ProcessMessage(BinaryData message)
        {
            if (message == null || message.ToArray().Length == 0)
            {
                yield break;
            }

            VoiceLiveUpdate update = null;
            try
            {
                // Try to parse as JSON first
                using JsonDocument document = JsonDocument.Parse(message);
                JsonElement root = document.RootElement;

                // Try to deserialize as a server event first
                VoiceLiveServerEvent serverEvent = VoiceLiveServerEvent.DeserializeVoiceLiveServerEvent(root, ModelSerializationExtensions.WireOptions);
                if (serverEvent != null)
                {
                    update = VoiceLiveUpdate.FromServerEvent(serverEvent);
                }

                // If that failed, try to deserialize directly as an update
                if (update == null)
                {
                    update = VoiceLiveUpdate.DeserializeVoiceLiveUpdate(root, ModelSerializationExtensions.WireOptions);
                }
            }
            catch (JsonException)
            {
                // If JSON parsing fails, create a generic unknown update
                update = new UnknownUpdate(message);
            }
            catch (Exception)
            {
                // If deserialization fails completely, create a generic unknown update
                update = new UnknownUpdate(message);
            }

            if (update != null)
            {
                yield return update;
            }
        }

        /// <summary>
        /// Represents an update for unknown or unparseable messages.
        /// </summary>
        private sealed class UnknownUpdate : VoiceLiveUpdate
        {
            private readonly BinaryData _rawData;

            public UnknownUpdate(BinaryData rawData) : base(VoiceLiveUpdateKind.Unknown)
            {
                _rawData = rawData;
            }

            /// <summary>
            /// Gets the raw message data.
            /// </summary>
            public BinaryData RawData => _rawData;

            /// <inheritdoc/>
            public override BinaryData GetRawContent() => _rawData;
        }
    }
}
