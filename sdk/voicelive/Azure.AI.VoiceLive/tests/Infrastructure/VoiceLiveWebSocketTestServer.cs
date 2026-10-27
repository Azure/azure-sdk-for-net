// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.VoiceLive.Tests.Infrastructure
{
    // Raw HTTP permits intentionally invalid 101 responses without HttpListener URL ACLs or WebSocket middleware.
    internal sealed class VoiceLiveWebSocketTestServer : IDisposable
    {
        private readonly TcpListener _listener;
        private readonly CancellationTokenSource _shutdown;
        private readonly CancellationTokenRegistration _stopListener;
        private readonly ConcurrentQueue<Request> _requests = new ConcurrentQueue<Request>();
        private readonly Task _serverTask;
        private bool _disposed;

        internal VoiceLiveWebSocketTestServer(CancellationToken cancellationToken)
        {
            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();
            Address = new Uri($"http://127.0.0.1:{((IPEndPoint)_listener.LocalEndpoint).Port}/");
            _shutdown = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _stopListener = _shutdown.Token.Register(_listener.Stop);
            _serverTask = RunAsync();
        }

        internal Uri Address { get; }
        internal Request[] Requests => _requests.ToArray();
        internal Exception? Failure { get; private set; }
        internal string? ReceivedCommand { get; private set; }
        internal WebSocketCloseStatus? CloseStatus { get; private set; }

        internal Func<Request, Stream, CancellationToken, Task> Handler { get; set; }
            = (request, stream, cancellationToken) => WriteResponseAsync(stream, 400, null, cancellationToken);

        internal static Dictionary<string, string> CreateUpgradeHeaders(Request request)
        {
            using SHA1 sha1 = SHA1.Create();
            byte[] accept = sha1.ComputeHash(Encoding.ASCII.GetBytes(
                request.Headers["Sec-WebSocket-Key"] + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"));

            return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["Upgrade"] = "websocket",
                ["Connection"] = "Upgrade",
                ["Sec-WebSocket-Accept"] = Convert.ToBase64String(accept)
            };
        }

        internal static Task WriteResponseAsync(
            Stream stream,
            int statusCode,
            IDictionary<string, string>? headers,
            CancellationToken cancellationToken)
        {
            string reason = statusCode == 101 ? "Switching Protocols" : statusCode == 400 ? "Bad Request" : "Redirect";
            var response = new StringBuilder($"HTTP/1.1 {statusCode} {reason}\r\n");
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    response.Append(header.Key).Append(": ").Append(header.Value).Append("\r\n");
                }
            }

            if (statusCode != 101)
            {
                response.Append("Content-Length: 0\r\nConnection: close\r\n");
            }

            response.Append("\r\n");
            byte[] bytes = Encoding.ASCII.GetBytes(response.ToString());
            return stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }

        internal async Task EchoWebSocketAsync(Request request, Stream stream, CancellationToken cancellationToken)
        {
            await WriteResponseAsync(stream, 101, CreateUpgradeHeaders(request), cancellationToken).ConfigureAwait(false);
            while (true)
            {
                byte[] header = await ReadExactlyAsync(stream, 2, cancellationToken).ConfigureAwait(false);
                if ((header[0] & 0xF0) != 0x80 || (header[1] & 0x80) == 0)
                {
                    throw new InvalidDataException("The loopback peer expects final, masked client frames.");
                }

                int opcode = header[0] & 0x0F;
                int length = header[1] & 0x7F;
                if (length == 126)
                {
                    byte[] extendedLength = await ReadExactlyAsync(stream, 2, cancellationToken).ConfigureAwait(false);
                    length = (extendedLength[0] << 8) | extendedLength[1];
                }
                else if (length == 127)
                {
                    throw new InvalidDataException("The loopback controls do not send frames larger than 65535 bytes.");
                }

                byte[] mask = await ReadExactlyAsync(stream, 4, cancellationToken).ConfigureAwait(false);
                byte[] payload = await ReadExactlyAsync(stream, length, cancellationToken).ConfigureAwait(false);
                for (int i = 0; i < payload.Length; i++)
                {
                    payload[i] ^= mask[i % 4];
                }

                switch (opcode)
                {
                    case 1:
                        ReceivedCommand = Encoding.UTF8.GetString(payload);
                        await WriteFrameAsync(stream, 1, payload, cancellationToken).ConfigureAwait(false);
                        break;
                    case 8:
                        CloseStatus = payload.Length >= 2
                            ? (WebSocketCloseStatus)((payload[0] << 8) | payload[1])
                            : WebSocketCloseStatus.Empty;
                        await WriteFrameAsync(stream, 8, payload, cancellationToken).ConfigureAwait(false);
                        return;
                    case 9:
                        await WriteFrameAsync(stream, 10, payload, cancellationToken).ConfigureAwait(false);
                        break;
                    case 10:
                        break;
                    default:
                        throw new InvalidDataException("The loopback controls expect text, close, ping, or pong frames.");
                }
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _shutdown.Cancel();
            _serverTask.GetAwaiter().GetResult();
            _stopListener.Dispose();
            _shutdown.Dispose();
        }

        private async Task RunAsync()
        {
            try
            {
                while (!_shutdown.IsCancellationRequested)
                {
                    using TcpClient connection = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                    // Closing the socket also cancels reads on .NET Framework, which ignores stream read cancellation.
                    using CancellationTokenRegistration closeConnection = _shutdown.Token.Register(connection.Close);
                    _shutdown.Token.ThrowIfCancellationRequested();
                    using NetworkStream stream = connection.GetStream();
                    Request request = await ReadRequestAsync(stream, _shutdown.Token).ConfigureAwait(false);
                    _requests.Enqueue(request);
                    await Handler(request, stream, _shutdown.Token).ConfigureAwait(false);
                }
            }
            catch (Exception) when (_shutdown.IsCancellationRequested)
            {
            }
            catch (Exception exception)
            {
                Failure = exception;
            }
            finally
            {
                _listener.Stop();
            }
        }

        private async Task<Request> ReadRequestAsync(Stream stream, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[16384];
            for (int length = 1; length <= buffer.Length; length++)
            {
                if (await stream.ReadAsync(buffer, length - 1, 1, cancellationToken).ConfigureAwait(false) == 0)
                {
                    throw new EndOfStreamException("The connection closed before the HTTP request headers arrived.");
                }

                if (length < 4 || buffer[length - 4] != '\r' || buffer[length - 3] != '\n'
                    || buffer[length - 2] != '\r' || buffer[length - 1] != '\n')
                {
                    continue;
                }

                string[] lines = Encoding.ASCII.GetString(buffer, 0, length - 4)
                    .Split(new[] { "\r\n" }, StringSplitOptions.None);
                string[] requestLine = lines[0].Split(' ');
                var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                for (int i = 1; i < lines.Length; i++)
                {
                    int separator = lines[i].IndexOf(':');
                    if (separator <= 0)
                    {
                        throw new InvalidDataException("The client sent a malformed HTTP request header.");
                    }

                    headers.Add(lines[i].Substring(0, separator), lines[i].Substring(separator + 1).Trim());
                }

                return new Request(requestLine[0], new Uri(Address, requestLine[1]), headers);
            }

            throw new InvalidDataException("The loopback request headers exceeded 16384 bytes.");
        }

        private static async Task<byte[]> ReadExactlyAsync(Stream stream, int length, CancellationToken cancellationToken)
        {
            byte[] bytes = new byte[length];
            int offset = 0;
            while (offset < bytes.Length)
            {
                int read = await stream.ReadAsync(bytes, offset, bytes.Length - offset, cancellationToken).ConfigureAwait(false);
                if (read == 0)
                {
                    throw new EndOfStreamException("The connection closed before a complete WebSocket frame arrived.");
                }

                offset += read;
            }

            return bytes;
        }

        private static Task WriteFrameAsync(Stream stream, int opcode, byte[] payload, CancellationToken cancellationToken)
        {
            int headerLength = payload.Length < 126 ? 2 : 4;
            byte[] frame = new byte[headerLength + payload.Length];
            frame[0] = (byte)(0x80 | opcode);
            if (headerLength == 2)
            {
                frame[1] = (byte)payload.Length;
            }
            else
            {
                frame[1] = 126;
                frame[2] = (byte)(payload.Length >> 8);
                frame[3] = (byte)payload.Length;
            }

            Buffer.BlockCopy(payload, 0, frame, headerLength, payload.Length);
            return stream.WriteAsync(frame, 0, frame.Length, cancellationToken);
        }

        internal sealed class Request
        {
            internal Request(string method, Uri uri, Dictionary<string, string> headers)
            {
                Method = method;
                Uri = uri;
                Headers = headers;
            }

            internal string Method { get; }
            internal Uri Uri { get; }
            internal Dictionary<string, string> Headers { get; }
        }
    }
}
