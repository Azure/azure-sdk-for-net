// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ServiceBusTestProxyTests
    {
        [Test]
        public async Task DisposalClosesAnIncompleteHandshake()
        {
            var proxy = new ServiceBusTestProxy("127.0.0.1");
            using var client = new TcpClient();
            await client.ConnectAsync(IPAddress.Loopback, proxy.Address.Port);
            var request = Encoding.ASCII.GetBytes("CONNECT ");
            await client.GetStream().WriteAsync(request, 0, request.Length);
            var disposal = proxy.DisposeAsync().AsTask();
            Assert.That(await Task.WhenAny(disposal, Task.Delay(TimeSpan.FromSeconds(5))), Is.SameAs(disposal));
            await disposal;
            await proxy.DisposeAsync();
        }

        [Test]
        public async Task ConnectionFailureIsReportedDuringOwnedCleanup()
        {
            var destination = new TcpListener(IPAddress.Loopback, 0);
            destination.Start();
            var port = ((IPEndPoint)destination.LocalEndpoint).Port;
            destination.Stop();
            var proxy = new ServiceBusTestProxy("127.0.0.1", port);
            using var client = new TcpClient();
            await client.ConnectAsync(IPAddress.Loopback, proxy.Address.Port);
            var request = Encoding.ASCII.GetBytes($"CONNECT 127.0.0.1:{port} HTTP/1.1\r\n\r\n");
            using var stream = client.GetStream();
            await stream.WriteAsync(request, 0, request.Length);
            try
            {
                Assert.That(await stream.ReadAsync(new byte[1], 0, 1), Is.Zero);
            }
            catch (IOException)
            {
            }
            Assert.ThrowsAsync<SocketException>(async () => await proxy.DisposeAsync());
        }

        [Test]
        public async Task ResetClosesOnlyOwnedTunnelsAndAllowsNewConnections()
        {
            var destination = new TcpListener(IPAddress.Loopback, 0);
            destination.Start();
            try
            {
                var port = ((IPEndPoint)destination.LocalEndpoint).Port;
                await using var proxy = new ServiceBusTestProxy("127.0.0.1", port);
                for (var attempt = 0; attempt < 2; attempt++)
                {
                    using var client = new TcpClient();
                    await client.ConnectAsync(IPAddress.Loopback, proxy.Address.Port);
                    using var stream = client.GetStream();
                    var request = Encoding.ASCII.GetBytes($"CONNECT 127.0.0.1:{port} HTTP/1.1\r\n\r\n");
                    await stream.WriteAsync(request, 0, request.Length);
                    using var upstream = await destination.AcceptTcpClientAsync();
                    var header = new StringBuilder();
                    var oneByte = new byte[1];
                    while (!header.ToString().EndsWith("\r\n\r\n"))
                    {
                        Assert.That(await stream.ReadAsync(oneByte, 0, 1), Is.EqualTo(1));
                        header.Append((char)oneByte[0]);
                    }
                    Assert.That(header.ToString(), Does.StartWith("HTTP/1.1 200 "));
                    await stream.WriteAsync(new byte[] { 42 }, 0, 1);
                    Assert.That(await upstream.GetStream().ReadAsync(oneByte, 0, 1), Is.EqualTo(1));
                    Assert.That(oneByte[0], Is.EqualTo(42));
                    await upstream.GetStream().WriteAsync(new byte[] { 24 }, 0, 1);
                    Assert.That(await stream.ReadAsync(oneByte, 0, 1), Is.EqualTo(1));
                    Assert.That(oneByte[0], Is.EqualTo(24));
                    proxy.ResetConnections();
                    try
                    {
                        Assert.That(await stream.ReadAsync(oneByte, 0, 1), Is.Zero);
                    }
                    catch (IOException)
                    {
                        // A reset may surface as an exception rather than EOF.
                    }
                }
            }
            finally
            {
                destination.Stop();
            }
        }
    }
}
