// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.ServiceBus.Tests
{
    // Resets only this proxy's encrypted tunnels, without changing client or AMQP state.
    internal sealed class ServiceBusTestProxy : IAsyncDisposable
    {
        private readonly TcpListener _listener = new TcpListener(IPAddress.Loopback, 0);
        private readonly ConcurrentBag<TcpClient> _connections = new ConcurrentBag<TcpClient>();
        private readonly ConcurrentBag<Task> _tunnels = new ConcurrentBag<Task>();
        private readonly string _host;
        private readonly int _port;
        private readonly Task _accept;
        private int _generation;
        private volatile bool _disposed;

        public Uri Address { get; }

        public ServiceBusTestProxy(string host, int port = 443)
        {
            _host = host;
            _port = port;
            _listener.Start();
            Address = new Uri($"http://127.0.0.1:{((IPEndPoint)_listener.LocalEndpoint).Port}");
            _accept = AcceptAsync();
        }

        public void ResetConnections()
        {
            Interlocked.Increment(ref _generation);
            foreach (var connection in _connections)
            {
                connection.Dispose();
            }
        }

        private async Task AcceptAsync()
        {
            try
            {
                while (!_disposed)
                {
                    var client = await _listener.AcceptTcpClientAsync();
                    _tunnels.Add(TunnelAsync(client, Volatile.Read(ref _generation)));
                }
            }
            catch (Exception ex) when (_disposed && (ex is SocketException || ex is ObjectDisposedException))
            {
            }
        }

        private async Task TunnelAsync(TcpClient client, int generation)
        {
            using (client)
            using (var upstream = new TcpClient())
            {
                _connections.Add(client);
                _connections.Add(upstream);
                try
                {
                    client.Client.LingerState = new LingerOption(true, 0);
                    upstream.Client.LingerState = new LingerOption(true, 0);
                    var stream = client.GetStream();
                    var header = new StringBuilder();
                    var oneByte = new byte[1];
                    while (!header.ToString().EndsWith("\r\n\r\n", StringComparison.Ordinal))
                    {
                        if (header.Length >= 8192 || await stream.ReadAsync(oneByte, 0, 1) == 0)
                        {
                            throw new IOException("Incomplete or oversized proxy CONNECT request.");
                        }
                        header.Append((char)oneByte[0]);
                    }
                    if (!header.ToString().StartsWith($"CONNECT {_host}:{_port} HTTP/1.", StringComparison.OrdinalIgnoreCase))
                    {
                        throw new IOException("Proxy CONNECT target does not match the owned test endpoint.");
                    }

                    await upstream.ConnectAsync(_host, _port);
                    var response = Encoding.ASCII.GetBytes("HTTP/1.1 200 Connection Established\r\n\r\n");
                    await stream.WriteAsync(response, 0, response.Length);
                    using var remote = upstream.GetStream();
                    await Task.WhenAll(stream.CopyToAsync(remote), remote.CopyToAsync(stream));
                }
                catch (Exception ex) when ((_disposed || generation != Volatile.Read(ref _generation)) &&
                    (ex is IOException || ex is SocketException || ex is ObjectDisposedException))
                {
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;
            _listener.Stop();
            await _accept;
            ResetConnections();
            await Task.WhenAll(_tunnels);
        }
    }
}
