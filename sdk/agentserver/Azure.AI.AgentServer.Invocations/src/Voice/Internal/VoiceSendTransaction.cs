// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text.Json;

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// One logical outbound frame before its exact wire envelope is prepared.
/// </summary>
internal readonly record struct VoiceFramePayload(
    string MessageType,
    IReadOnlyDictionary<string, object?> Fields);

/// <summary>
/// The single owner of outbound frame preparation, ordering, reservation, wire
/// attempts, and post-send commit for one Voice connection.
/// </summary>
internal sealed class VoiceSendTransaction
{
    private readonly WebSocket _webSocket;
    private readonly SemaphoreSlim _sendGate = new(1, 1);
    private readonly CancellationToken _wireCancellation;

    public VoiceSendTransaction(WebSocket webSocket, CancellationToken wireCancellation = default)
    {
        _webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
        _wireCancellation = wireCancellation;
    }

    public bool Ending => _webSocket.State != WebSocketState.Open;

    /// <summary>
    /// Sends a stateless frame through the same transaction owner used by
    /// stateful response operations.
    /// </summary>
    public Task SendAsync(
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        CancellationToken cancellationToken) =>
        ExecuteAsync(
            new VoiceFramePayload(messageType, fields),
            static _ => ValueTask.FromResult(0),
            static _ => ValueTask.FromResult(true),
            cancellationToken);

    /// <summary>
    /// Prepares one exact frame before invoking <paramref name="reserveAsync"/>,
    /// attempts the wire write only after reservation succeeds, and invokes
    /// <paramref name="commitAsync"/> only after the complete frame was sent.
    /// </summary>
    public Task<TReservation> ExecuteAsync<TReservation>(
        VoiceFramePayload frame,
        Func<CancellationToken, ValueTask<TReservation>> reserveAsync,
        Func<TReservation, ValueTask<bool>> commitAsync,
        CancellationToken cancellationToken) =>
        ExecuteAsync(new[] { frame }, reserveAsync, commitAsync, cancellationToken);

    /// <summary>
    /// Executes an ordered group of frames as one reservation. This is used
    /// when opening a response and sending its first output must be atomic from
    /// the SDK state machine's perspective.
    /// </summary>
    public async Task<TReservation> ExecuteAsync<TReservation>(
        IReadOnlyList<VoiceFramePayload> frames,
        Func<CancellationToken, ValueTask<TReservation>> reserveAsync,
        Func<TReservation, ValueTask<bool>> commitAsync,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(frames);
        ArgumentNullException.ThrowIfNull(reserveAsync);
        ArgumentNullException.ThrowIfNull(commitAsync);
        if (frames.Count == 0)
        {
            throw new ArgumentException("A send transaction requires at least one frame.", nameof(frames));
        }

        await _sendGate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            EnsureOpen();
            using var preparedFrames = PrepareFrames(frames);

            // Caller cancellation is honored before any state is reserved. Once
            // reservation succeeds, the transaction must either commit or abort
            // the carrier; cancellation cannot roll state back safely.
            cancellationToken.ThrowIfCancellationRequested();
            var reservation = await reserveAsync(CancellationToken.None).ConfigureAwait(false);

            try
            {
                foreach (var preparedFrame in preparedFrames.Frames)
                {
                    await _webSocket.SendAsync(
                        preparedFrame.WrittenMemory,
                        WebSocketMessageType.Text,
                        endOfMessage: true,
                        _wireCancellation).ConfigureAwait(false);
                }
            }
#pragma warning disable CA1031 // Any exception after a wire attempt makes delivery ambiguous.
            catch (Exception exception)
#pragma warning restore CA1031
            {
                AbortBestEffort();
                throw new VoiceBridgeConnectionClosedException(
                    "The voice connection closed during an outbound transaction.",
                    exception);
            }

            bool committed;
            try
            {
                committed = await commitAsync(reservation).ConfigureAwait(false);
            }
#pragma warning disable CA1031 // A sent frame without a state commit requires carrier abort.
            catch (Exception exception)
#pragma warning restore CA1031
            {
                AbortBestEffort();
                throw new VoiceBridgeConnectionClosedException(
                    "The voice connection could not commit an outbound transaction.",
                    exception);
            }

            if (!committed)
            {
                throw new VoiceBridgeConnectionClosedException(
                    "The outbound transaction lost terminal arbitration after its wire write.");
            }

            return reservation;
        }
        finally
        {
            _sendGate.Release();
        }
    }

    internal static void ValidateJsonValue(object value)
    {
        using var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            JsonSerializer.Serialize(writer, value);
            writer.Flush();
        }
        catch (FrameTooLargeException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "The serialized JSON value exceeds the maximum voice frame size.");
        }
    }

    internal static int MeasureEscapedStringBytes(string value)
    {
        using var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            writer.WriteStringValue(value);
            writer.Flush();
            return checked((int)buffer.Length - 2);
        }
        catch (FrameTooLargeException)
        {
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "The JSON-escaped text exceeds the maximum voice frame size.");
        }
    }

    private PreparedFrameCollection PrepareFrames(IReadOnlyList<VoiceFramePayload> frames)
    {
        var prepared = new List<FixedSizeBufferStream>(frames.Count);
        try
        {
            foreach (var frame in frames)
            {
                prepared.Add(PrepareFrame(frame));
            }

            return new PreparedFrameCollection(prepared);
        }
        catch
        {
            foreach (var frame in prepared)
            {
                frame.Dispose();
            }

            throw;
        }
    }

    private static FixedSizeBufferStream PrepareFrame(VoiceFramePayload frame)
    {
        var payload = new Dictionary<string, object?>(frame.Fields, StringComparer.Ordinal)
        {
            ["type"] = frame.MessageType,
            ["id"] = VoiceIds.New(VoiceProtocolConstants.EnvelopeIdPrefix),
            ["ts"] = DateTimeOffset.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture),
        };
        var buffer = new FixedSizeBufferStream(VoiceProtocolConstants.MaxFrameBytes);
        try
        {
            using var writer = new Utf8JsonWriter(buffer);
            JsonSerializer.Serialize(writer, payload);
            writer.Flush();
            return buffer;
        }
        catch (FrameTooLargeException)
        {
            buffer.Dispose();
            throw new ArgumentOutOfRangeException(
                nameof(frame),
                "The serialized voice frame exceeds the maximum size of 1 MiB.");
        }
        catch
        {
            buffer.Dispose();
            throw;
        }
    }

    private void EnsureOpen()
    {
        if (Ending)
        {
            throw new VoiceBridgeConnectionClosedException("The voice connection is closed.");
        }
    }

    private void AbortBestEffort()
    {
        try
        {
            _webSocket.Abort();
        }
#pragma warning disable CA1031 // Ambiguous writes must not escape without carrier abort.
        catch (Exception)
#pragma warning restore CA1031
        {
        }
    }

    private sealed class PreparedFrameCollection : IDisposable
    {
        public PreparedFrameCollection(IReadOnlyList<FixedSizeBufferStream> frames)
        {
            Frames = frames;
        }

        public IReadOnlyList<FixedSizeBufferStream> Frames { get; }

        public void Dispose()
        {
            foreach (var frame in Frames)
            {
                frame.Dispose();
            }
        }
    }

    private sealed class FixedSizeBufferStream : Stream
    {
        private readonly int _capacity;
        private byte[]? _buffer;
        private int _written;

        public FixedSizeBufferStream(int capacity)
        {
            _capacity = capacity;
            _buffer = ArrayPool<byte>.Shared.Rent(Math.Min(4096, capacity));
        }

        public ReadOnlyMemory<byte> WrittenMemory =>
            (_buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream))).AsMemory(0, _written);

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        public override long Length => _written;

        public override long Position
        {
            get => _written;
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count) =>
            throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin) =>
            throw new NotSupportedException();

        public override void SetLength(long value) =>
            throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
        {
            ArgumentNullException.ThrowIfNull(buffer);
            Write(buffer.AsSpan(offset, count));
        }

        public override void Write(ReadOnlySpan<byte> buffer)
        {
            if (buffer.Length > _capacity - _written)
            {
                throw new FrameTooLargeException();
            }

            EnsureCapacity(_written + buffer.Length);
            buffer.CopyTo(
                (_buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream)))
                    .AsSpan(_written, buffer.Length));
            _written += buffer.Length;
        }

        private void EnsureCapacity(int requiredCapacity)
        {
            var current = _buffer ?? throw new ObjectDisposedException(nameof(FixedSizeBufferStream));
            if (requiredCapacity <= current.Length)
            {
                return;
            }

            var targetCapacity = Math.Min(
                _capacity,
                Math.Max(requiredCapacity, Math.Min(_capacity, current.Length * 2)));
            var replacement = ArrayPool<byte>.Shared.Rent(targetCapacity);
            current.AsSpan(0, _written).CopyTo(replacement);
            CryptographicOperations.ZeroMemory(current.AsSpan(0, _written));
            ArrayPool<byte>.Shared.Return(current);
            _buffer = replacement;
        }

        protected override void Dispose(bool disposing)
        {
            var buffer = Interlocked.Exchange(ref _buffer, null);
            if (buffer is not null)
            {
                try
                {
                    CryptographicOperations.ZeroMemory(buffer.AsSpan(0, _written));
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(buffer);
                }
            }

            base.Dispose(disposing);
        }
    }

    private sealed class FrameTooLargeException : Exception
    {
    }
}
