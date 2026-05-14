// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Diagnostics;
using Azure.AI.VoiceLive.Telemetry;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Represents a WebSocket-based session for real-time voice communication with the Azure VoiceLive service.
    /// </summary>
    /// <remarks>
    /// This class abstracts bidirectional communication between the caller and service,
    /// simultaneously sending and receiving WebSocket messages.
    /// </remarks>
    public partial class VoiceLiveSession : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Gets the underlying WebSocket connection.
        /// </summary>
        internal WebSocket WebSocket { get; set; }

        private readonly VoiceLiveClient _parentClient;
        private readonly Uri _endpoint;
        private readonly AzureKeyCredential _credential;
        private readonly TokenCredential _tokenCredential;
        private readonly SemaphoreSlim _audioSendSemaphore = new(1, 1);
        private readonly SemaphoreSlim _clientSendSemaphore = new(1, 1);
        private readonly object _singleReceiveLock = new();
        private AsyncVoiceLiveMessageCollectionResult _receiveCollectionResult;
        private bool _isSendingAudioStream = false;
        private bool _disposed = false;

        // WebSocket content logging
        private readonly VoiceLiveWebSocketContentLogger _contentLogger;
        private readonly string _connectionId;

        // OpenTelemetry tracing (null when no ActivityListener is registered)
        internal readonly VoiceLiveTracer _tracer;

        /// <summary>
        /// Gets or sets a value indicating whether turn response data should be buffered.
        /// </summary>
        internal bool ShouldBufferTurnResponseData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveSession"/> class.
        /// </summary>
        /// <param name="parentClient">The parent <see cref="VoiceLiveClient"/> instance.</param>
        /// <param name="endpoint">The WebSocket endpoint to connect to.</param>
        /// <param name="credential">The credential to use for authentication.</param>
        protected internal VoiceLiveSession(
            VoiceLiveClient parentClient,
            Uri endpoint,
            AzureKeyCredential credential) : this(parentClient, endpoint)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _credential = credential;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VoiceLiveSession"/> class.
        /// </summary>
        /// <param name="parentClient">The parent <see cref="VoiceLiveClient"/> instance.</param>
        /// <param name="endpoint">The WebSocket endpoint to connect to.</param>
        /// <param name="credential">The credential to use for authentication.</param>
        protected internal VoiceLiveSession(
            VoiceLiveClient parentClient,
            Uri endpoint,
            TokenCredential credential) : this(parentClient, endpoint)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            _tokenCredential = credential;
        }

        private VoiceLiveSession(
                    VoiceLiveClient parentClient,
                    Uri endpoint)
        {
            Argument.AssertNotNull(parentClient, nameof(parentClient));
            Argument.AssertNotNull(endpoint, nameof(endpoint));

            _parentClient = parentClient;
            _endpoint = endpoint;

            // Initialize content logging
            _connectionId = Guid.NewGuid().ToString("N").Substring(0, 8); // Short connection ID
            _contentLogger = new VoiceLiveWebSocketContentLogger(parentClient.Options.Diagnostics);

            // Initialize OpenTelemetry tracer; the tracer is cheap to construct and guards itself
            // with ActivitySource.HasListeners() so there is zero overhead when OTel is not configured.
            _tracer = new VoiceLiveTracer(endpoint, null);
        }

        /// <summary>
        /// Transmits audio data from a stream, ending the client turn once the stream is complete.
        /// </summary>
        /// <param name="audio">The audio stream to transmit.</param>
        /// <param name="cancellationToken">An optional cancellation token.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="audio"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when another audio stream is already being sent.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task SendInputAudioAsync(Stream audio, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(audio, nameof(audio));
            ThrowIfDisposed();

            using (await _audioSendSemaphore.AutoReleaseWaitAsync(cancellationToken).ConfigureAwait(false))
            {
                if (_isSendingAudioStream)
                {
                    throw new InvalidOperationException("Only one stream of audio may be sent at once.");
                }
                _isSendingAudioStream = true;
            }

            byte[] buffer = null;
            try
            {
                buffer = ArrayPool<byte>.Shared.Rent(1024 * 16);
                while (true)
                {
                    int bytesRead = await audio.ReadAsync(buffer, 0, buffer.Length, cancellationToken).ConfigureAwait(false);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    ReadOnlyMemory<byte> audioMemory = buffer.AsMemory(0, bytesRead);
                    BinaryData audioData = BinaryData.FromBytes(audioMemory);
                    string base64Audio = Convert.ToBase64String(audioData.ToArray());
                    ClientEventInputAudioBufferAppend appendCommand = new(base64Audio);
                    await SendCommandAsync(appendCommand, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                if (buffer is not null)
                {
                    ArrayPool<byte>.Shared.Return(buffer);
                }
                using (await _audioSendSemaphore.AutoReleaseWaitAsync(cancellationToken).ConfigureAwait(false))
                {
                    _isSendingAudioStream = false;
                }
            }
        }

        /// <summary>
        /// Sends a command to the service asynchronously.
        /// </summary>
        /// <param name="command">The command to send.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="command"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        internal virtual async Task SendCommandAsync(ClientEvent command, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(command, nameof(command));
            ThrowIfDisposed();

            var data = ((IPersistableModel<ClientEvent>)command).Write(ModelReaderWriterOptions.Json);

            string eventType = command.Type.ToString();
            bool isAudioAppend = command.Type == ClientEventType.InputAudioBufferAppend
                              || command.Type == ClientEventType.InputAudioTurnAppend;

            // Track audio bytes without creating a span (too high-frequency for per-message spans)
            if (isAudioAppend)
            {
                if (_tracer != null && _tracer.IsEnabled)
                {
                    try
                    {
                        using JsonDocument audioDoc = JsonDocument.Parse(data);
                        _tracer.OnSendAudioData(audioDoc.RootElement);
                    }
                    catch { /* Never let telemetry parsing break the send path */ }
                }
                await SendCommandAsync(data, cancellationToken).ConfigureAwait(false);
                return;
            }

            // Notify tracer of lifecycle-relevant events before creating the span
            if (command.Type == ClientEventType.ResponseCreate)
                _tracer?.OnSendResponseCreate();
            else if (command.Type == ClientEventType.ResponseCancel)
                _tracer?.OnSendResponseCancel();

            Activity sendActivity = _tracer?.StartSendActivity(eventType);
            if (sendActivity?.IsAllDataRequested == true)
                sendActivity.SetTag(VoiceLiveTelemetryAttributeKeys.GenAiVoiceMessageSize, (long)data.ToMemory().Length);
            try
            {
                if (sendActivity != null)
                {
                    if (command.Type == ClientEventType.SessionUpdate
                        || command.Type == ClientEventType.ResponseCancel
                        || command.Type == ClientEventType.ConversationItemCreate)
                    {
                        try
                        {
                            using JsonDocument doc = JsonDocument.Parse(data);
                            if (command.Type == ClientEventType.SessionUpdate)
                                _tracer.EnrichSendSessionUpdate(sendActivity, doc.RootElement);
                            else
                                _tracer.ExtractSendIds(sendActivity, doc.RootElement, eventType);
                        }
                        catch { /* Never let telemetry parsing break the send path */ }
                    }

                    _tracer.AddSendContentEvent(sendActivity, eventType, data.ToString());
                }

                await SendCommandAsync(data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                VoiceLiveTracer.RecordError(sendActivity, ex);
                throw;
            }
            finally
            {
                sendActivity?.Stop();
            }
        }

        /// <summary>
        /// Sends raw data to the service asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="data"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task SendCommandAsync(BinaryData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ThrowIfDisposed();

            ArraySegment<byte> messageBytes = new(data.ToArray());

            await _clientSendSemaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                // Log before sending
                _contentLogger.LogSentMessage(_connectionId, messageBytes, isText: true);

                await WebSocket.SendAsync(
                    messageBytes,
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    cancellationToken)
                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Log send error
                _contentLogger.LogError(_connectionId, $"Send error: {ex.Message}", messageBytes, isText: true);
                throw;
            }
            finally
            {
                _clientSendSemaphore.Release();
            }
        }

        /// <summary>
        /// Sends raw data to the service asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="data"/> is null.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public virtual async Task SendCommandAsync(RequestContent data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ThrowIfDisposed();

            MemoryStream ms = new MemoryStream();
            await data.WriteToAsync(ms, cancellationToken).ConfigureAwait(false);

            ms.Seek(0, SeekOrigin.Begin);

            await SendCommandAsync(BinaryData.FromStream(ms), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Receives updates from the service asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to use.</param>
        /// <returns>An asynchronous enumerable of binary data messages.</returns>
        public virtual async IAsyncEnumerable<BinaryData> ReceiveUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();

            lock (_singleReceiveLock)
            {
                _receiveCollectionResult ??= new(WebSocket, _contentLogger, _connectionId, cancellationToken);
            }

            await foreach (BinaryData message in _receiveCollectionResult.WithCancellation(cancellationToken))
            {
                yield return message;
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="VoiceLiveSession"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                try
                {
                    WebSocket?.Dispose();
                }
                catch
                {
                    // Ignore disposal exceptions
                }

                _audioSendSemaphore?.Dispose();
                _clientSendSemaphore?.Dispose();

                _disposed = true;
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="VoiceLiveSession"/> asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous dispose operation.</returns>
        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (!_disposed)
            {
                Activity closeActivity = null;
                try
                {
                    if (WebSocket != null && WebSocket.State == WebSocketState.Open)
                    {
                        closeActivity = _tracer?.StartCloseActivity();
                        await WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Session disposed", CancellationToken.None)
                            .ConfigureAwait(false);
                    }
                }
                catch
                {
                    // Ignore disposal exceptions
                }
                finally
                {
                    closeActivity?.Stop();
                }

                // End any open connect span (e.g. if CloseAsync was not called explicitly)
                _tracer?.EndConnectActivity();

                WebSocket?.Dispose();
                _audioSendSemaphore?.Dispose();
                _clientSendSemaphore?.Dispose();

                _disposed = true;
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(VoiceLiveSession));
            }
        }
    }
}
