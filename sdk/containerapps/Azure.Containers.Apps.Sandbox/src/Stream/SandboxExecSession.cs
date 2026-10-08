// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Containers.Apps.Sandbox.Models;
using Azure.Core;

namespace Azure.Containers.Apps.Sandbox
{
    /// <summary> An interactive exec session using the sandbox WebSocket message protocol. </summary>
    public class SandboxExecSession : IDisposable, IAsyncDisposable
    {
        private const int MaximumStartMessageSize = 1_048_576;
        private const int MaximumInputChunkSize = 8 * 1024;
        private readonly SandboxStream _stream;
        /// <summary> Initializes a session for mocking. </summary>
        protected SandboxExecSession() { }

        internal SandboxExecSession(SandboxStream stream) =>
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));

        internal Task StartAsync(SandboxExecStartRequest request, CancellationToken cancellationToken)
        {
            return SendControlAsync(writer =>
            {
                writer.WriteString("type", "start");
                writer.WriteStartObject("start");
                writer.WriteString("command", request.Command);
                writer.WriteStartArray("args");
                foreach (string arg in request.Arguments)
                    writer.WriteStringValue(arg);
                writer.WriteEndArray();
                writer.WriteStartObject("environment");
                foreach (var item in request.Environment)
                    writer.WriteString(item.Key, item.Value);
                writer.WriteEndObject();
                if (request.WorkingDirectory != null)
                    writer.WriteString("workingDirectory", request.WorkingDirectory);
                if (request.User != null)
                    writer.WriteString("user", request.User);
                writer.WriteBoolean("tty", request.AllocateTerminal);
                writer.WriteBoolean("stdin", request.EnableStandardInput);
                writer.WriteNumber("height", request.Height);
                writer.WriteNumber("width", request.Width);
                writer.WriteBoolean("detach", request.RunDetached);
                writer.WriteEndObject();
            }, cancellationToken, MaximumStartMessageSize);
        }

        /// <summary> Sends raw bytes to standard input. </summary>
        public virtual async Task SendInputAsync(BinaryData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));
            ReadOnlyMemory<byte> input = data.ToMemory();
            for (int offset = 0; offset < input.Length; offset += MaximumInputChunkSize)
            {
                int length = Math.Min(MaximumInputChunkSize, input.Length - offset);
                string encoded = Convert.ToBase64String(input.Slice(offset, length).ToArray());
                await SendControlAsync(writer =>
                {
                    writer.WriteString("type", "stdin");
                    writer.WriteString("data", encoded);
                }, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary> Changes the terminal dimensions in rows and columns. </summary>
        public virtual Task ResizeAsync(uint height, uint width, CancellationToken cancellationToken = default) =>
            SendControlAsync(writer =>
            {
                writer.WriteString("type", "resize");
                writer.WriteStartObject("resize");
                writer.WriteNumber("height", height);
                writer.WriteNumber("width", width);
                writer.WriteEndObject();
            }, cancellationToken);

        /// <summary> Closes standard input without closing the session. </summary>
        public virtual Task CloseInputAsync(CancellationToken cancellationToken = default) =>
            SendControlAsync(writer => writer.WriteString("type", "close_stdin"), cancellationToken);

        private Task SendControlAsync(Action<Utf8JsonWriter> write, CancellationToken cancellationToken, int? maximumSize = null)
        {
            using MemoryStream buffer = new MemoryStream();
            using (Utf8JsonWriter writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartObject();
                write(writer);
                writer.WriteEndObject();
            }
            if (maximumSize.HasValue && buffer.Length > maximumSize.Value)
                throw new ArgumentException("Exec start message exceeds the service's maximum size.");
            return _stream.SendMessageAsync(BinaryData.FromBytes(buffer.ToArray()), cancellationToken: cancellationToken);
        }

        /// <summary> Receives and decodes the next exec event. </summary>
        public virtual async Task<SandboxExecEvent> ReceiveAsync(CancellationToken cancellationToken = default)
        {
            SandboxStreamMessage message = await _stream.ReceiveMessageAsync(cancellationToken).ConfigureAwait(false);
            if (message.Type == SandboxStreamMessageType.Close)
                return new SandboxExecEvent(SandboxExecEventType.Closed, text: message.CloseDescription);
            if (message.Type != SandboxStreamMessageType.Text)
                throw new InvalidDataException("Exec stream messages must be JSON text.");

            using JsonDocument document = JsonDocument.Parse(message.Data.ToMemory());
            JsonElement root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object ||
                !root.TryGetProperty("type", out JsonElement type) || type.ValueKind != JsonValueKind.String)
                throw new InvalidDataException("Exec stream message has no type.");

            switch (type.GetString())
            {
                case "session_id":
                    return new SandboxExecEvent(SandboxExecEventType.SessionId, text: GetString(root, "data"));
                case "stdout":
                    return new SandboxExecEvent(SandboxExecEventType.StandardOutput, data: DecodeOutput(root));
                case "stderr":
                    return new SandboxExecEvent(SandboxExecEventType.StandardError, data: DecodeOutput(root));
                case "exit_code":
                    if (root.TryGetProperty("exitCode", out JsonElement code) && code.TryGetInt32(out int value))
                        return new SandboxExecEvent(SandboxExecEventType.ExitCode, exitCode: value);
                    throw new InvalidDataException("Exec exit event has no valid exitCode.");
                case "error":
                    return new SandboxExecEvent(SandboxExecEventType.Error, text: GetString(root, "data"));
                default:
                    throw new InvalidDataException("Unknown exec event type: " + type.GetString());
            }
        }

        private static string GetString(JsonElement root, string property)
        {
            if (root.TryGetProperty(property, out JsonElement value) && value.ValueKind == JsonValueKind.String)
                return value.GetString();
            throw new InvalidDataException("Exec event has no valid " + property + ".");
        }

        private static BinaryData DecodeOutput(JsonElement root)
        {
            try
            {
                return BinaryData.FromBytes(Convert.FromBase64String(GetString(root, "data")));
            }
            catch (FormatException ex)
            {
                throw new InvalidDataException("Exec output is not valid base64.", ex);
            }
        }

        /// <inheritdoc />
        public void Dispose() => _stream?.Dispose();

        /// <inheritdoc />
        public virtual ValueTask DisposeAsync() => _stream?.DisposeAsync() ?? default;
    }
}
