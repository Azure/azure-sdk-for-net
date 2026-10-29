// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed class A2AResponseObserver(
    HttpContext context,
    string? method,
    System.Diagnostics.Activity? operation,
    System.Diagnostics.Activity? invocation,
    bool knownTask) : IDisposable
{
    internal const int MaxPayloadBytes = 1024 * 1024;
    private readonly MemoryStream _buffer = new();
    private bool _discarding;
    private bool _previousNewline;
    private int _lineBreakBytes;
    private bool _knownTask = knownTask;
    private bool IsSse => context.Response.ContentType?.StartsWith("text/event-stream", StringComparison.OrdinalIgnoreCase) == true;

    public void Observe(ReadOnlySpan<byte> bytes)
    {
        if (IsSse && _knownTask)
        {
            return;
        }

        foreach (byte value in bytes)
        {
            if (!_discarding)
            {
                if (_buffer.Length < MaxPayloadBytes + (IsSse ? 4 : 0))
                {
                    _buffer.WriteByte(value);
                }
                else
                {
                    _discarding = true;
                    _buffer.SetLength(0);
                }
            }

            if (!IsSse)
            {
                continue;
            }

            if (value == '\n' && _previousNewline)
            {
                if (!_discarding && _buffer.Length - _lineBreakBytes - 1 <= MaxPayloadBytes)
                {
                    var text = Encoding.UTF8.GetString(_buffer.GetBuffer(), 0, (int)_buffer.Length);
                    var payload = string.Join("\n", text.Split('\n')
                        .Where(line => line.StartsWith("data:", StringComparison.Ordinal))
                        .Select(line => line[5..].TrimStart(' ').TrimEnd('\r')));
                    ObservePayload(payload, recordError: false);
                }

                _buffer.SetLength(0);
                _discarding = false;
                _previousNewline = false;
                _lineBreakBytes = 0;
                if (_knownTask)
                {
                    return;
                }
            }
            else if (value != '\r')
            {
                _previousNewline = value == '\n';
                _lineBreakBytes = value == '\n' ? _lineBreakBytes + 1 : 0;
            }
            else
            {
                _lineBreakBytes++;
            }
        }
    }

    public void Complete()
    {
        if (!IsSse && !_discarding && _buffer.Length > 0)
        {
            ObservePayload(Encoding.UTF8.GetString(_buffer.GetBuffer(), 0, (int)_buffer.Length), recordError: true);
        }
    }

    public void Dispose() => _buffer.Dispose();

    private void ObservePayload(string payload, bool recordError)
    {
        if (string.IsNullOrWhiteSpace(payload))
        {
            return;
        }

        try
        {
            using var document = JsonDocument.Parse(payload);
            var root = document.RootElement;
            var errorCode = A2ARpcResult.Property(A2ARpcResult.Property(root, "error"), "code");
            if (recordError && errorCode.ValueKind is JsonValueKind.Number or JsonValueKind.String)
            {
                RecordError(errorCode.ToString());
            }

            if (_knownTask)
            {
                return;
            }

            var result = A2ARpcResult.Property(root, "result");
            string? taskId = null;
            if (method is "GetTask" or "CancelTask")
            {
                taskId = A2ARpcResult.String(result, "id");
            }
            else if (method is "SendMessage" or "SendStreamingMessage" or "SubscribeToTask")
            {
                taskId = A2ARpcResult.String(A2ARpcResult.Property(result, "task"), "id");
                foreach (var name in new[] { "message", "statusUpdate", "artifactUpdate" })
                {
                    taskId ??= A2ARpcResult.String(A2ARpcResult.Property(result, name), "taskId");
                }
            }

            if (!string.IsNullOrEmpty(taskId))
            {
                operation?.SetTag("a2a.task.id", taskId);
                invocation?.SetTag("a2a.task.id", taskId);
                _knownTask = true;
            }
        }
        catch (JsonException exception)
        {
            context.RequestServices.GetRequiredService<ILogger<A2AResponseObserver>>()
                .LogDebug(exception, "A2A response payload could not be observed; response bytes are unchanged");
        }
    }

    public void RecordError(string errorType)
    {
        operation?.SetTag("error.type", errorType);
        operation?.SetStatus(ActivityStatusCode.Error);
        invocation?.SetTag("error.type", errorType);
        invocation?.SetStatus(ActivityStatusCode.Error);
    }

    public void RecordTransmissionFailure(Exception exception, CancellationToken cancellationToken = default)
    {
        if (exception is OperationCanceledException
            && (context.RequestAborted.IsCancellationRequested || cancellationToken.IsCancellationRequested))
        {
            return;
        }

        RecordError(exception.GetType().FullName!);
    }
}
