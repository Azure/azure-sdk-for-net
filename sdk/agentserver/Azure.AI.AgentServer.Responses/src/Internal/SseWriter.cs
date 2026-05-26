// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Writes <see cref="ResponseStreamEvent"/> objects to a stream as SSE
/// with <c>event:</c> + <c>data:</c> lines and keep-alive comments.
/// Thread-safe: serializes writes via a <see cref="SemaphoreSlim"/>.
/// </summary>
internal sealed class SseWriter : IDisposable
{
    private readonly Stream _output;
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly SemaphoreSlim _writeLock = new(1, 1);

    /// <summary>
    /// Initializes a new instance of <see cref="SseWriter"/>.
    /// </summary>
    /// <param name="output">The output stream to write SSE data to.</param>
    /// <param name="jsonOptions">JSON serializer options for event data.</param>
    public SseWriter(Stream output, JsonSerializerOptions jsonOptions)
    {
        _output = output;
        _jsonOptions = jsonOptions;
    }

    /// <summary>
    /// Writes a single SSE event with <c>event:</c> and <c>data:</c> lines,
    /// injecting the given <paramref name="sequenceNumber"/> into the JSON payload.
    /// </summary>
    /// <param name="evt">The event to write.</param>
    /// <param name="sequenceNumber">The sequence number to inject.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task WriteEventAsync(ResponseStreamEvent evt, long sequenceNumber, CancellationToken cancellationToken)
    {
        var eventType = evt.EventType.ToString();
        var json = JsonSerializer.Serialize(evt, evt.GetType(), _jsonOptions);

        // Inject the SDK-assigned sequence number into the serialized JSON
        var node = JsonNode.Parse(json)!;
        node["sequence_number"] = sequenceNumber;
        json = node.ToJsonString(_jsonOptions);

        var sseBlock = $"event: {eventType}\ndata: {json}\n\n";
        var bytes = Encoding.UTF8.GetBytes(sseBlock);

        await _writeLock.WaitAsync(cancellationToken);
        try
        {
            await _output.WriteAsync(bytes, cancellationToken);
            await _output.FlushAsync(cancellationToken);
        }
        finally
        {
            _writeLock.Release();
        }
    }

    /// <summary>
    /// Writes an SSE keep-alive comment (<c>: keep-alive</c>).
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task WriteKeepAliveAsync(CancellationToken cancellationToken)
    {
        var bytes = ": keep-alive\n\n"u8.ToArray();

        await _writeLock.WaitAsync(cancellationToken);
        try
        {
            await _output.WriteAsync(bytes, cancellationToken);
            await _output.FlushAsync(cancellationToken);
        }
        finally
        {
            _writeLock.Release();
        }
    }

    /// <summary>
    /// Writes a standalone SSE error event (not a <c>response.*</c> lifecycle event).
    /// Used for pre-<c>response.created</c> bad handler errors.
    /// </summary>
    /// <param name="errorEvent">The error event to write.</param>
    public async Task WriteErrorEventAsync(ResponseErrorEvent errorEvent)
    {
        var errorJson = JsonSerializer.Serialize(errorEvent, _jsonOptions);

        var sseBlock = $"event: error\ndata: {errorJson}\n\n";
        var bytes = Encoding.UTF8.GetBytes(sseBlock);

        await _writeLock.WaitAsync(CancellationToken.None);
        try
        {
            await _output.WriteAsync(bytes, CancellationToken.None);
            await _output.FlushAsync(CancellationToken.None);
        }
        finally
        {
            _writeLock.Release();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _writeLock.Dispose();
    }
}
