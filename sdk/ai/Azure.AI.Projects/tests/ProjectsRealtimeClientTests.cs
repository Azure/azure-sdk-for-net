// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable AAIP002

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Unit tests for the Voice Agents realtime session connection handshake
/// (<see cref="AIProjectClient.GetProjectsRealtimeSessionClientAsync"/> and
/// <see cref="ProjectsRealtimeSessionClient"/>). These use a real loopback HttpListener/WebSocket
/// handshake (not a live Foundry resource) so the request the client actually sends on the wire can
/// be observed.
/// </summary>
public class ProjectsRealtimeClientTests
{
    // -----------------------------------------------------------------------
    // Verifies (without any live Foundry service, using a real loopback
    // HttpListener/WebSocket handshake): AIProjectClient.GetProjectsRealtimeSessionClientAsync
    // actually performs a connection attempt (the bug fixed in this change was that nothing ever
    // called ConnectAsync), and that it targets the agent-scoped
    // "/agents/{agentName}/endpoint/protocols/voice" path -- not OpenAI's generic
    // "/realtime" endpoint -- with the expected api-version query parameter and
    // Foundry-Features/Authorization headers, and negotiates the "realtime" WebSocket subprotocol
    // the service requires (matching azure-ai-projects' Python realtime client).
    // -----------------------------------------------------------------------
    [Test]
    public async Task ConnectSendsRequestToAgentScopedEndpointWithExpectedHeaders()
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();

        Task<(string Path, string Query, string Authorization, string FoundryFeatures, string SubProtocol, string UserAgent)> serverTask = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            string path = context.Request.Url.AbsolutePath;
            string query = context.Request.Url.Query;
            string authorization = context.Request.Headers["Authorization"];
            string foundryFeatures = context.Request.Headers["Foundry-Features"];
            string subProtocol = context.Request.Headers["Sec-WebSocket-Protocol"];
            string userAgent = context.Request.Headers["User-Agent"];
            if (context.Request.IsWebSocketRequest)
            {
                await context.AcceptWebSocketAsync(subProtocol: "realtime");
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Close();
            }
            return (path, query, authorization, foundryFeatures, subProtocol, userAgent);
        });

        AIProjectClient client = new(new Uri($"http://127.0.0.1:{port}/api/projects/proj1"), new FakeTokenProvider());

        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
        try
        {
            using ProjectsRealtimeSessionClient session = await client.GetProjectsRealtimeSessionClientAsync(
                "cs-e2e-connectivity-test-agent",
                cancellationToken: timeout.Token);
        }
        catch
        {
            // The loopback listener does not implement the real realtime protocol past the
            // handshake, so the client may fault soon after connecting; only the request the
            // server observed (asserted below) matters for this test.
        }

        (string path, string query, string authorization, string foundryFeatures, string subProtocol, string userAgent) = await serverTask;
        listener.Stop();

        Assert.Multiple(() =>
        {
            Assert.That(path, Is.EqualTo("/api/projects/proj1/agents/cs-e2e-connectivity-test-agent/endpoint/protocols/voice"),
                "Must target the agent-scoped realtime endpoint, not OpenAI's generic /realtime endpoint.");
            Assert.That(query, Does.Contain("api-version="));
            Assert.That(foundryFeatures, Does.Contain("VoiceAgents=V1Preview"));
            Assert.That(authorization, Does.StartWith("Bearer "));
            Assert.That(subProtocol, Is.EqualTo("realtime"));
            Assert.That(userAgent, Does.Contain("Azure.AI.Projects"));
        });
    }

    // -----------------------------------------------------------------------
    // Verifies that GetProjectsRealtimeSessionClientAsync's store parameter is reflected as a
    // "store" query parameter on the realtime WebSocket handshake.
    // -----------------------------------------------------------------------
    [Test]
    public async Task ConnectWithStoreOptionIncludesStoreQueryParameter()
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();

        Task<string> serverTask = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            string query = context.Request.Url.Query;
            if (context.Request.IsWebSocketRequest)
            {
                await context.AcceptWebSocketAsync(subProtocol: "realtime");
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Close();
            }
            return query;
        });

        AIProjectClient client = new(new Uri($"http://127.0.0.1:{port}/api/projects/proj1"), new FakeTokenProvider());

        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
        try
        {
            using ProjectsRealtimeSessionClient session = await client.GetProjectsRealtimeSessionClientAsync(
                "cs-e2e-connectivity-test-agent",
                store: true,
                cancellationToken: timeout.Token);
        }
        catch
        {
            // See comment above: only the request the server observed matters for this test.
        }

        string query = await serverTask;
        listener.Stop();

        Assert.That(query, Does.Contain("store=true"));
    }

    private static int GetFreeTcpPort()
    {
        TcpListener tcpListener = new(IPAddress.Loopback, 0);
        tcpListener.Start();
        int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
        tcpListener.Stop();
        return port;
    }

    private sealed class FakeTokenProvider : System.ClientModel.AuthenticationTokenProvider
    {
        public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties)
            => new(properties);

        public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
            => new("fake-token", "Bearer", DateTimeOffset.UtcNow.AddHours(1), null);

        public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
            => new(GetToken(options, cancellationToken));
    }
}
