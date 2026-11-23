// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class VoiceLiveSessionRedirectTests
    {
        private const string ApiKey = "synthetic-redirect-test-api-key";
        private const string BearerToken = "synthetic-redirect-test-token";
        private const string Model = "redirect-model/preview";
        private const string AgentName = "redirect test agent";
        private const string ProjectName = "redirect-test-project";
        private const string CustomHeader = "X-VoiceLive-Redirect-Test";
        private const string CustomHeaderValue = "preserved-header";
        private const string DestinationPath = "/custom-prefix/voice-live/redirect-destination";
        private const string Command = "{\"type\":\"response.create\",\"event_id\":\"redirect-positive-control\"}";

        private static bool UsesNetStandardSdk =>
            typeof(VoiceLiveClient).Assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName == ".NETStandard,Version=v2.0";

#if NET8_0
        [Test]
        public void Net8UsesNetStandardSdkAsset()
        {
            Assert.That(UsesNetStandardSdk, Is.True, "The .NET 8 CI configuration must exercise the netstandard2.0 SDK asset.");
        }
#endif

        public enum SessionCreation
        {
            Model,
            Agent,
            Manual
        }

        public enum RedirectTarget
        {
            CrossHost,
            CrossPort,
            SameOriginRelative
        }

        public enum InvalidUpgrade
        {
            BadAccept,
            MissingUpgrade,
            WrongUpgrade,
            MissingConnection,
            WrongConnection,
            UnexpectedSubprotocol,
            UnexpectedExtensions
        }

        private static IEnumerable<InvalidUpgrade> InvalidUpgrades
        {
            get
            {
                yield return InvalidUpgrade.BadAccept;
                yield return InvalidUpgrade.MissingUpgrade;
                yield return InvalidUpgrade.WrongUpgrade;
                yield return InvalidUpgrade.MissingConnection;
                yield return InvalidUpgrade.WrongConnection;
                yield return InvalidUpgrade.UnexpectedSubprotocol;
                if (UsesNetStandardSdk)
                {
                    // The legacy handshake must reject unsolicited extensions; native ClientWebSocket ignores them.
                    yield return InvalidUpgrade.UnexpectedExtensions;
                }
            }
        }

        [Test]
        [Combinatorial]
        public async Task AuthenticatedConnectionDoesNotFollowRedirect(
            [Values(301, 302, 303, 307, 308)] int statusCode,
            [Values] RedirectTarget redirectTarget,
            [Values] bool useTokenCredential,
            [Values] SessionCreation creation)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var destination = new VoiceLiveWebSocketTestServer(timeout.Token);
            using var source = new VoiceLiveWebSocketTestServer(timeout.Token);

            string location = redirectTarget switch
            {
                RedirectTarget.CrossHost => new UriBuilder(source.Address)
                {
                    Host = "localhost",
                    Path = DestinationPath
                }.Uri.AbsoluteUri,
                RedirectTarget.CrossPort => new Uri(destination.Address, DestinationPath).AbsoluteUri,
                RedirectTarget.SameOriginRelative => "redirect-destination",
                _ => throw new ArgumentOutOfRangeException(nameof(redirectTarget))
            };

            source.Handler = (request, stream, cancellationToken) =>
                request.Uri.AbsolutePath == DestinationPath
                    ? VoiceLiveWebSocketTestServer.WriteResponseAsync(stream, 400, null, cancellationToken)
                    : VoiceLiveWebSocketTestServer.WriteResponseAsync(
                        stream,
                        statusCode,
                        new Dictionary<string, string> { ["Location"] = location },
                        cancellationToken);

            VoiceLiveClient client = CreateClient(source.Address, useTokenCredential);
            Exception? connectionFailure = await ConnectAndDisposeAsync(client, creation, timeout.Token);

            VoiceLiveWebSocketTestServer.Request[] sourceRequests = source.Requests;
            int destinationRequests = destination.Requests.Length
                + sourceRequests.Count(request => request.Uri.AbsolutePath == DestinationPath);

            // A 400 at the destination also makes the vulnerable connection throw, so check hits first.
            Assert.That(destinationRequests, Is.Zero, "Authenticated WebSocket connections must not follow any redirect.");
            Assert.That(source.Failure, Is.Null, "The redirect source must complete its HTTP response.");
            Assert.That(destination.Failure, Is.Null, "The redirect destination must remain healthy.");
            Assert.That(sourceRequests, Has.Length.EqualTo(1), "Only the original authenticated handshake is allowed.");
            AssertOriginalRequest(sourceRequests[0], creation, useTokenCredential);
            Assert.That(connectionFailure, Is.InstanceOf<WebSocketException>(), "The redirect must reject the WebSocket handshake.");
            Assert.That(timeout.IsCancellationRequested, Is.False, "Redirect rejection must not depend on a timeout.");
        }

        [Test]
        [Combinatorial]
        public async Task DirectUpgradeCanSendReceiveAndClose(
            [Values] bool useTokenCredential,
            [Values] SessionCreation creation)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var server = new VoiceLiveWebSocketTestServer(timeout.Token);
            server.Handler = server.EchoWebSocketAsync;

            VoiceLiveClient client = CreateClient(server.Address, useTokenCredential);
            using VoiceLiveSession session = await ConnectAsync(client, creation, timeout.Token);

            Assert.That(session.IsConnected, Is.True);
            Assert.That(session.ConnectionState, Is.EqualTo(WebSocketState.Open));
            Assert.That(server.Requests, Has.Length.EqualTo(1));
            AssertOriginalRequest(server.Requests[0], creation, useTokenCredential);

            await session.SendCommandAsync(BinaryData.FromString(Command), timeout.Token);
            await using (IAsyncEnumerator<BinaryData> updates = session.ReceiveUpdatesAsync(timeout.Token).GetAsyncEnumerator())
            {
                Assert.That(await updates.MoveNextAsync(), Is.True, "The loopback peer must return a real WebSocket frame.");
                Assert.That(updates.Current.ToString(), Is.EqualTo(Command));
            }

            await session.CloseAsync(timeout.Token);

            Assert.That(session.IsConnected, Is.False);
            Assert.That(session.ConnectionState, Is.EqualTo(WebSocketState.Closed));
            Assert.That(server.ReceivedCommand, Is.EqualTo(Command));
            Assert.That(server.CloseStatus, Is.EqualTo(WebSocketCloseStatus.NormalClosure));
            Assert.That(server.Failure, Is.Null);
            Assert.That(timeout.IsCancellationRequested, Is.False);
        }

        [Test]
        [Combinatorial]
        public async Task MalformedUpgradeIsRejected(
            [ValueSource(nameof(InvalidUpgrades))] InvalidUpgrade invalidUpgrade,
            [Values] bool useTokenCredential)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            using var server = new VoiceLiveWebSocketTestServer(timeout.Token);
            server.Handler = (request, stream, cancellationToken) =>
            {
                Dictionary<string, string> headers = VoiceLiveWebSocketTestServer.CreateUpgradeHeaders(request);
                switch (invalidUpgrade)
                {
                    case InvalidUpgrade.BadAccept:
                        headers["Sec-WebSocket-Accept"] = "invalid-accept";
                        break;
                    case InvalidUpgrade.MissingUpgrade:
                        headers.Remove("Upgrade");
                        break;
                    case InvalidUpgrade.WrongUpgrade:
                        headers["Upgrade"] = "h2c";
                        break;
                    case InvalidUpgrade.MissingConnection:
                        headers.Remove("Connection");
                        break;
                    case InvalidUpgrade.WrongConnection:
                        headers["Connection"] = "keep-alive";
                        break;
                    case InvalidUpgrade.UnexpectedSubprotocol:
                        headers["Sec-WebSocket-Protocol"] = "unrequested-protocol";
                        break;
                    case InvalidUpgrade.UnexpectedExtensions:
                        headers["Sec-WebSocket-Extensions"] = "permessage-deflate";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(invalidUpgrade));
                }

                return VoiceLiveWebSocketTestServer.WriteResponseAsync(stream, 101, headers, cancellationToken);
            };

            VoiceLiveClient client = CreateClient(server.Address, useTokenCredential);
            Exception? connectionFailure = await ConnectAndDisposeAsync(client, SessionCreation.Manual, timeout.Token);

            Assert.That(server.Failure, Is.Null, "The peer must send the intended malformed response.");
            Assert.That(server.Requests, Has.Length.EqualTo(1));
            AssertOriginalRequest(server.Requests[0], SessionCreation.Manual, useTokenCredential);
            Assert.That(connectionFailure, Is.InstanceOf<WebSocketException>(), "A malformed 101 response must not create a session.");
            Assert.That(timeout.IsCancellationRequested, Is.False, "Handshake validation must not depend on a timeout.");
        }

        private static VoiceLiveClient CreateClient(Uri address, bool useTokenCredential)
        {
            var options = new VoiceLiveClientOptions(VoiceLiveClientOptions.ServiceVersion.V2025_10_01);
            options.Headers.Add(CustomHeader, CustomHeaderValue);
            var endpoint = new Uri(address, "custom-prefix?preserved=one%20two");

            return useTokenCredential
                ? new VoiceLiveClient(endpoint, new SyntheticTokenCredential(), options)
                : new VoiceLiveClient(endpoint, new AzureKeyCredential(ApiKey), options);
        }

        private static async Task<VoiceLiveSession> ConnectAsync(
            VoiceLiveClient client,
            SessionCreation creation,
            CancellationToken cancellationToken)
        {
            switch (creation)
            {
                case SessionCreation.Model:
                    return await client.StartSessionAsync(Model, cancellationToken);
                case SessionCreation.Agent:
                    return await client.StartSessionAsync(
                        new AgentSessionConfig(AgentName, ProjectName)
                        {
                            AgentVersion = "7",
                            ConversationId = "synthetic-conversation"
                        },
                        cancellationToken);
                case SessionCreation.Manual:
                    VoiceLiveSession session = client.CreateSession(SessionTarget.FromModel(Model));
                    try
                    {
                        await session.ConnectAsync(client.Options.Headers, cancellationToken);
                        return session;
                    }
                    catch
                    {
                        session.Dispose();
                        throw;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(creation));
            }
        }

        private static async Task<Exception?> ConnectAndDisposeAsync(
            VoiceLiveClient client,
            SessionCreation creation,
            CancellationToken cancellationToken)
        {
            VoiceLiveSession? session = null;
            try
            {
                session = await ConnectAsync(client, creation, cancellationToken);
                return null;
            }
            catch (Exception exception)
            {
                return exception;
            }
            finally
            {
                session?.Dispose();
            }
        }

        private static void AssertOriginalRequest(
            VoiceLiveWebSocketTestServer.Request request,
            SessionCreation creation,
            bool useTokenCredential)
        {
            Assert.That(request.Method, Is.EqualTo("GET"));
            Assert.That(request.Uri.AbsolutePath, Is.EqualTo("/custom-prefix/voice-live/realtime"));
            Assert.That(request.Headers[CustomHeader], Is.EqualTo(CustomHeaderValue));
            Assert.That(request.Headers["Sec-WebSocket-Version"], Is.EqualTo("13"));

            if (useTokenCredential)
            {
                Assert.That(request.Headers["Authorization"], Is.EqualTo("Bearer " + BearerToken));
                Assert.That(request.Headers.ContainsKey("api-key"), Is.False);
            }
            else
            {
                Assert.That(request.Headers["api-key"], Is.EqualTo(ApiKey));
                Assert.That(request.Headers.ContainsKey("Authorization"), Is.False);
            }

            Dictionary<string, string> query = request.Uri.Query.TrimStart('?')
                .Split('&')
                .Select(parameter => parameter.Split(new[] { '=' }, 2))
                .ToDictionary(
                    parameter => Uri.UnescapeDataString(parameter[0]),
                    parameter => Uri.UnescapeDataString(parameter[1]));

            Assert.That(query["api-version"], Is.EqualTo("2025-10-01"));
            Assert.That(query["preserved"], Is.EqualTo("one two"));
            if (creation == SessionCreation.Agent)
            {
                Assert.That(query["agent-name"], Is.EqualTo(AgentName));
                Assert.That(query["agent-project-name"], Is.EqualTo(ProjectName));
                Assert.That(query["agent-version"], Is.EqualTo("7"));
                Assert.That(query["conversation-id"], Is.EqualTo("synthetic-conversation"));
                Assert.That(query.ContainsKey("model"), Is.False);
            }
            else
            {
                Assert.That(query["model"], Is.EqualTo(Model));
                Assert.That(query.ContainsKey("agent-name"), Is.False);
                Assert.That(query.ContainsKey("agent-project-name"), Is.False);
            }
        }

        private sealed class SyntheticTokenCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AccessToken(BearerToken, DateTimeOffset.UtcNow.AddHours(1));
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
