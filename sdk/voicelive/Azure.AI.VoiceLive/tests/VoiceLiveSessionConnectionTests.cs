// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Microsoft.AspNetCore.Http.Features;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class VoiceLiveSessionConnectionTests
    {
        private const string ApiKey = "fake-api-key";
        private const string BearerAuthorization = "Bearer TEST TOKEN https://ai.azure.com/.default";
        private const string CustomCredential = "fake-custom-credential";

        [Test]
        public void RejectsHandshakeRedirects(
            [Values(false, true)] bool tokenCredential,
            [Values(301, 302, 303, 307, 308)] int statusCode,
            [Values("cross-host", "cross-port", "relative")] string redirectKind)
        {
            VerifyRedirectRejected(tokenCredential, statusCode, redirectKind, false);
        }

        [Test]
        public void RejectsHandshakeRedirectsWithCustomPipelineTransport([Values(false, true)] bool tokenCredential)
        {
            VerifyRedirectRejected(tokenCredential, 302, "cross-host", true);
        }

        private static void VerifyRedirectRejected(bool tokenCredential, int statusCode, string redirectKind, bool customTransport)
        {
            int redirectedRequests = 0;
            int originalRequests = 0;
            string? originalCredential = null;
            string? originalCustomCredential = null;
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var target = new TestServer(context =>
            {
                Interlocked.Increment(ref redirectedRequests);
                context.Response.StatusCode = 400;
            });
            string location = redirectKind == "relative"
                ? "/capture"
                : new UriBuilder(target.Address)
                {
                    Host = redirectKind == "cross-host" ? "localhost" : target.Address.Host,
                    Path = "/capture"
                }.Uri.AbsoluteUri;
            using var origin = new TestServer(context =>
            {
                if (context.Request.Path == "/capture")
                {
                    Interlocked.Increment(ref redirectedRequests);
                    context.Response.StatusCode = 400;
                    return;
                }

                Interlocked.Increment(ref originalRequests);
                originalCredential = context.Request.Headers[tokenCredential ? "Authorization" : "api-key"];
                originalCustomCredential = context.Request.Headers["X-Custom-Credential"];
                context.Response.StatusCode = statusCode;
                context.Response.Headers["Location"] = location;
            });
            using var httpClient = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
            var options = new VoiceLiveClientOptions();
            options.Headers.Add("X-Custom-Credential", CustomCredential);
            if (customTransport)
            {
                options.Transport = new HttpClientTransport(httpClient);
            }

            VoiceLiveClient client = CreateClient(origin.Address, tokenCredential, options);
            Assert.ThrowsAsync<WebSocketException>(async () =>
            {
                using VoiceLiveSession session = await client.StartSessionAsync("fake-model", timeout.Token);
            });

            Assert.Multiple(() =>
            {
                Assert.That(originalRequests, Is.EqualTo(1));
                Assert.That(originalCredential, Is.EqualTo(tokenCredential ? BearerAuthorization : ApiKey));
                Assert.That(originalCustomCredential, Is.EqualTo(CustomCredential));
                Assert.That(redirectedRequests, Is.Zero, "A redirect destination must not receive any request.");
            });
        }

        [Test]
        public async Task DirectHandshakeAuthenticates([Values(false, true)] bool tokenCredential)
        {
            string? receivedCredential = null;
            string? receivedCustomCredential = null;
            var releaseConnection = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var server = new TestServer(async context =>
            {
                receivedCredential = context.Request.Headers[tokenCredential ? "Authorization" : "api-key"];
                receivedCustomCredential = context.Request.Headers["X-Custom-Credential"];
                string webSocketKey = context.Request.Headers["Sec-WebSocket-Key"].ToString();
                using var sha1 = SHA1.Create();
                byte[] accept = sha1.ComputeHash(Encoding.ASCII.GetBytes(webSocketKey + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"));
                context.Response.Headers["Sec-WebSocket-Accept"] = Convert.ToBase64String(accept);
                context.Response.Headers["Upgrade"] = "websocket";
                IHttpUpgradeFeature upgrade = context.Features.Get<IHttpUpgradeFeature>()
                    ?? throw new InvalidOperationException("The test server must support HTTP upgrades.");
                using Stream connection = await upgrade.UpgradeAsync();
                await releaseConnection.Task;
            });
            var options = new VoiceLiveClientOptions();
            options.Headers.Add("X-Custom-Credential", CustomCredential);
            VoiceLiveClient client = CreateClient(server.Address, tokenCredential, options);

            try
            {
                using VoiceLiveSession session = await client.StartSessionAsync("fake-model", timeout.Token);
                Assert.Multiple(() =>
                {
                    Assert.That(session.IsConnected, Is.True);
                    Assert.That(receivedCredential, Is.EqualTo(tokenCredential ? BearerAuthorization : ApiKey));
                    Assert.That(receivedCustomCredential, Is.EqualTo(CustomCredential));
                });
            }
            finally
            {
                releaseConnection.TrySetResult(true);
            }
        }

        private static VoiceLiveClient CreateClient(Uri endpoint, bool tokenCredential, VoiceLiveClientOptions options)
        {
            return tokenCredential
                ? new VoiceLiveClient(endpoint, new MockCredential(), options)
                : new VoiceLiveClient(endpoint, new AzureKeyCredential(ApiKey), options);
        }
    }
}
