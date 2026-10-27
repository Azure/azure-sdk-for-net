// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class VoiceLiveSessionProxyTests
    {
        private const string ApiKey = "synthetic-proxy-test-api-key";
        private const string Model = "proxy-test-model";
        private const string Command = "{\"type\":\"response.create\"}";
        private IWebProxy _originalProxy = HttpClient.DefaultProxy;

        [SetUp]
        public void SaveDefaultProxy() => _originalProxy = HttpClient.DefaultProxy;

        [TearDown]
        public void RestoreDefaultProxy() => HttpClient.DefaultProxy = _originalProxy;

        [Test]
        public async Task DefaultProxyCanConnectSendReceiveAndClose([Values] bool useTokenCredential)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var proxy = new VoiceLiveWebSocketTestServer(timeout.Token);
            proxy.AcceptProxyTunnels = true;
            proxy.Handler = proxy.EchoWebSocketAsync;
            HttpClient.DefaultProxy = new WebProxy(proxy.Address);

            VoiceLiveClient client = CreateClient(useTokenCredential);
            using VoiceLiveSession session = await client.StartSessionAsync(Model, timeout.Token);

            Assert.That(session.IsConnected, Is.True);
            AssertProxyRequest(proxy, useTokenCredential);

            await session.SendCommandAsync(BinaryData.FromString(Command), timeout.Token);
            await using (IAsyncEnumerator<BinaryData> updates = session.ReceiveUpdatesAsync(timeout.Token).GetAsyncEnumerator())
            {
                Assert.That(await updates.MoveNextAsync(), Is.True);
                Assert.That(updates.Current.ToString(), Is.EqualTo(Command));
            }

            await session.CloseAsync(timeout.Token);

            Assert.That(session.ConnectionState, Is.EqualTo(WebSocketState.Closed));
            Assert.That(proxy.ReceivedCommand, Is.EqualTo(Command));
            Assert.That(proxy.CloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure));
            Assert.That(proxy.Failure, Is.Null);
            Assert.That(timeout.IsCancellationRequested, Is.False);
        }

        [Test]
        [Combinatorial]
        public void DefaultProxyDoesNotFollowRedirect(
            [Values(301, 302, 303, 307, 308)] int statusCode,
            [Values] bool useTokenCredential)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var destination = new VoiceLiveWebSocketTestServer(timeout.Token);
            using var proxy = new VoiceLiveWebSocketTestServer(timeout.Token);
            proxy.AcceptProxyTunnels = true;
            proxy.Handler = (request, stream, cancellationToken) =>
                VoiceLiveWebSocketTestServer.WriteResponseAsync(
                    stream, statusCode,
                    new Dictionary<string, string> { ["Location"] = new Uri(destination.Address, "redirect-destination").AbsoluteUri },
                    cancellationToken);
            HttpClient.DefaultProxy = new WebProxy(proxy.Address);

            VoiceLiveClient client = CreateClient(useTokenCredential);
            using VoiceLiveSession session = client.CreateSession(Model);

            Assert.ThrowsAsync<WebSocketException>(() => session.ConnectAsync(client.Options.Headers, timeout.Token));

            Assert.That(destination.Requests, Is.Empty, "Redirect destinations must not receive authenticated requests.");
            AssertProxyRequest(proxy, useTokenCredential);
            Assert.That(proxy.Failure, Is.Null);
            Assert.That(destination.Failure, Is.Null);
            Assert.That(timeout.IsCancellationRequested, Is.False);
        }

        private static VoiceLiveClient CreateClient(bool useTokenCredential)
        {
            var endpoint = new Uri("http://voicelive-proxy-test.invalid");
            return useTokenCredential
                ? new VoiceLiveClient(endpoint, new MockCredential())
                : new VoiceLiveClient(endpoint, new AzureKeyCredential(ApiKey));
        }

        private static void AssertProxyRequest(VoiceLiveWebSocketTestServer proxy, bool useTokenCredential)
        {
            Assert.That(proxy.Requests, Has.Length.EqualTo(1), "The configured proxy must receive exactly one handshake.");
            VoiceLiveWebSocketTestServer.Request request = proxy.Requests[0];
            Assert.That(request.Uri.Host, Is.EqualTo("voicelive-proxy-test.invalid"));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/voice-live/realtime"));
            if (useTokenCredential)
            {
                Assert.That(request.Headers["Authorization"], Does.StartWith("Bearer TEST TOKEN "));
                Assert.That(request.Headers.ContainsKey("api-key"), Is.False);
            }
            else
            {
                Assert.That(request.Headers["api-key"], Is.EqualTo(ApiKey));
                Assert.That(request.Headers.ContainsKey("Authorization"), Is.False);
            }
        }
    }
}
#endif
