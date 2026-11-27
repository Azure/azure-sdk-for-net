// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Monitor.OpenTelemetry.Exporter.Benchmarks
{
    /// <summary>
    /// A loopback stand-in for ingestion with a configurable response delay, so that shutdown cost
    /// can be measured against the real HTTP pipeline rather than a mocked transport.
    /// </summary>
    internal sealed class LocalIngestionServer : IDisposable
    {
        private const string ResponseBody = "{\"itemsReceived\":1,\"itemsAccepted\":1,\"errors\":[]}";

        private readonly TcpListener _listener;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly TimeSpan _responseDelay;

        public LocalIngestionServer(TimeSpan responseDelay)
        {
            _responseDelay = responseDelay;

            _listener = new TcpListener(IPAddress.Loopback, 0);
            _listener.Start();

            Endpoint = string.Format(
                CultureInfo.InvariantCulture,
                "http://127.0.0.1:{0}/",
                ((IPEndPoint)_listener.LocalEndpoint).Port);

            _ = Task.Run(AcceptLoopAsync);
        }

        public string Endpoint { get; }

        public string BuildConnectionString()
            => string.Format(CultureInfo.InvariantCulture, "InstrumentationKey={0};IngestionEndpoint={1}", Guid.NewGuid(), Endpoint);

        private async Task AcceptLoopAsync()
        {
            while (!_cancellation.IsCancellationRequested)
            {
                TcpClient client;

                try
                {
                    client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    return;
                }

                _ = Task.Run(() => HandleAsync(client));
            }
        }

        private async Task HandleAsync(TcpClient client)
        {
            using (client)
            {
                try
                {
                    var stream = client.GetStream();

                    await ReadRequestAsync(stream).ConfigureAwait(false);

                    if (_responseDelay > TimeSpan.Zero)
                    {
                        await Task.Delay(_responseDelay, _cancellation.Token).ConfigureAwait(false);
                    }

                    var response = "HTTP/1.1 200 OK\r\nContent-Type: application/json\r\nContent-Length: "
                        + Encoding.UTF8.GetByteCount(ResponseBody).ToString(CultureInfo.InvariantCulture)
                        + "\r\nConnection: close\r\n\r\n"
                        + ResponseBody;

                    var bytes = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
                    await stream.FlushAsync().ConfigureAwait(false);
                }
                catch (Exception)
                {
                    // The client went away, which is expected when a benchmark iteration ends.
                }
            }
        }

        /// <summary>
        /// Drains the full request so the client never sees a reset while it is still writing.
        /// </summary>
        private static async Task ReadRequestAsync(NetworkStream stream)
        {
            var buffer = new byte[8192];
            var request = new StringBuilder();
            var headerLength = -1;
            var contentLength = 0;
            var total = 0;

            while (true)
            {
                var read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                if (read == 0)
                {
                    return;
                }

                total += read;
                request.Append(Encoding.UTF8.GetString(buffer, 0, read));

                if (headerLength < 0)
                {
                    var headerEnd = request.ToString().IndexOf("\r\n\r\n", StringComparison.Ordinal);
                    if (headerEnd < 0)
                    {
                        continue;
                    }

                    headerLength = headerEnd + 4;
                    contentLength = ParseContentLength(request.ToString(0, headerEnd));
                }

                if (total >= headerLength + contentLength)
                {
                    return;
                }
            }
        }

        private static int ParseContentLength(string headers)
        {
            foreach (var line in headers.Split('\n'))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(trimmed.Substring("Content-Length:".Length).Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var value))
                {
                    return value;
                }
            }

            return 0;
        }

        public void Dispose()
        {
            _cancellation.Cancel();
            _listener.Stop();
            _cancellation.Dispose();
        }
    }
}
