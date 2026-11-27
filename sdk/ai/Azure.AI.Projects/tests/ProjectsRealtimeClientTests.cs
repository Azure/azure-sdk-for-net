// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Tests;

/// <summary>
/// Unit tests for the Voice Agents realtime session connection handshake
/// (<see cref="ProjectsRealtimeClient.StartSessionAsync"/> and
/// <see cref="ProjectsRealtimeSessionClient"/>). These use a real loopback HttpListener/WebSocket
/// handshake (not a live Foundry resource) so the request the client actually sends on the wire can
/// be observed.
/// </summary>
public class ProjectsRealtimeClientTests
{
    // -----------------------------------------------------------------------
    // Verifies (without any live Foundry service, using a real loopback
    // HttpListener/WebSocket handshake): ProjectsRealtimeClient.StartSessionAsync
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

        Task<(string Path, string Query, string Authorization, string FoundryFeatures, string SubProtocol)> serverTask = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            string path = context.Request.Url.AbsolutePath;
            string query = context.Request.Url.Query;
            string authorization = context.Request.Headers["Authorization"];
            string foundryFeatures = context.Request.Headers["Foundry-Features"];
            string subProtocol = context.Request.Headers["Sec-WebSocket-Protocol"];
            if (context.Request.IsWebSocketRequest)
            {
                await context.AcceptWebSocketAsync(subProtocol: "realtime");
            }
            else
            {
                context.Response.StatusCode = 400;
                context.Response.Close();
            }
            return (path, query, authorization, foundryFeatures, subProtocol);
        });

        AIProjectClient client = new(new Uri($"http://127.0.0.1:{port}/api/projects/proj1"), new FakeTokenProvider());

        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
        try
        {
            using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
                "cs-e2e-connectivity-test-agent",
                intent: null,
                cancellationToken: timeout.Token);
        }
        catch
        {
            // The loopback listener does not implement the real realtime protocol past the
            // handshake, so the client may fault soon after connecting; only the request the
            // server observed (asserted below) matters for this test.
        }

        (string path, string query, string authorization, string foundryFeatures, string subProtocol) = await AwaitServerRequestAsync(serverTask);
        listener.Stop();

        Assert.Multiple(() =>
        {
            Assert.That(path, Is.EqualTo("/api/projects/proj1/agents/cs-e2e-connectivity-test-agent/endpoint/protocols/voice"),
                "Must target the agent-scoped realtime endpoint, not OpenAI's generic /realtime endpoint.");
            Assert.That(query, Does.Contain("api-version="));
            Assert.That(foundryFeatures, Does.Contain("VoiceAgents=V1Preview"));
            Assert.That(authorization, Does.StartWith("Bearer "));
            Assert.That(subProtocol, Is.EqualTo("realtime"));
        });
    }

    // -----------------------------------------------------------------------
    // Verifies that ProjectsRealtimeClient.StartSessionAsync's options.QueryString "store=true" is
    // reflected as a "store" query parameter on the realtime WebSocket handshake.
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
            using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
                "cs-e2e-connectivity-test-agent",
                intent: null,
                options: new RealtimeSessionClientOptions { QueryString = "store=true" },
                cancellationToken: timeout.Token);
        }
        catch
        {
            // See comment above: only the request the server observed matters for this test.
        }

        string query = await AwaitServerRequestAsync(serverTask);
        listener.Stop();

        Assert.That(query, Does.Contain("store=true"));
    }

    [TestCase("websocket")]
    [TestCase("webrtc")]
    [TestCase("future-transport")]
    [TestCase("future transport/+")]
    public async Task TypedTransportOverridesLegacyQueryWithoutChangingOtherValues(string transportValue)
    {
        const string additionalQuery = "store=true&transport=old&%74ransport=duplicate&keep=one&keep=two&path=folder%2F";
        RealtimeSessionClientOptions options = new ProjectsRealtimeSessionClientOptions
        {
            Transport = transportValue switch
            {
                "websocket" => VoiceAgentTransport.Websocket,
                "webrtc" => VoiceAgentTransport.Webrtc,
                _ => new VoiceAgentTransport(transportValue)
            },
            QueryString = additionalQuery
        };

        string query = await CaptureHandshakeQueryAsync(options);
        string[] parameters = query.TrimStart('?').Split('&');
        string[] transports = parameters
            .Where(parameter => Uri.UnescapeDataString(parameter.Split('=')[0]) == "transport")
            .ToArray();

        Assert.Multiple(() =>
        {
            Assert.That(transports, Is.EqualTo(new[] { $"transport={Uri.EscapeDataString(transportValue)}" }));
            Assert.That(parameters, Does.Contain("store=true"));
            Assert.That(parameters, Does.Contain("keep=one").And.Contain("keep=two"));
            Assert.That(parameters, Does.Contain("path=folder%2F"));
            Assert.That(parameters, Does.Contain("api-version=v1"));
            Assert.That(options.QueryString, Is.EqualTo(additionalQuery));
        });
    }

    [TestCase(null)]
    [TestCase("store=true&transport=webrtc")]
    public async Task OmittedTransportPreservesExistingQueryBehavior(string additionalQuery)
    {
        RealtimeSessionClientOptions options = additionalQuery is null ? null : new() { QueryString = additionalQuery };

        string query = await CaptureHandshakeQueryAsync(options);
        string[] transports = query.TrimStart('?').Split('&')
            .Where(parameter => Uri.UnescapeDataString(parameter.Split('=')[0]) == "transport")
            .ToArray();

        Assert.That(transports, additionalQuery is null ? Is.Empty : Is.EqualTo(new[] { "transport=webrtc" }));
    }

    [Test]
    public async Task TypedOptionsWithoutTransportPreserveLegacyQuery()
    {
        ProjectsRealtimeSessionClientOptions options = new() { QueryString = "store=true&transport=websocket" };

        string query = await CaptureHandshakeQueryAsync(options);

        Assert.That(query, Does.Contain("store=true&transport=websocket"));
    }

    [Test]
    public void DefaultTransportValueIsRejectedBeforeConnecting()
    {
        AIProjectClient client = new(new Uri("http://127.0.0.1:1/api/projects/proj1"), new FakeTokenProvider());
        ProjectsRealtimeSessionClientOptions options = new() { Transport = default(VoiceAgentTransport) };

        ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(() =>
            client.ProjectsRealtimeClient.StartSessionAsync("agent", intent: null, options: options));

        Assert.That(exception.ParamName, Is.EqualTo(nameof(options)));
    }

    private static async Task<string> CaptureHandshakeQueryAsync(RealtimeSessionClientOptions options)
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();

        Task<(string Query, WebSocket Socket)> serverTask = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            string query = context.Request.Url.Query;
            HttpListenerWebSocketContext webSocket = await context.AcceptWebSocketAsync(subProtocol: "realtime");
            return (query, webSocket.WebSocket);
        });

        WebSocket serverSocket = null;
        try
        {
            AIProjectClient client = new(new Uri($"http://127.0.0.1:{port}/api/projects/proj1"), new FakeTokenProvider());
            RealtimeClient realtimeClient = client.ProjectsRealtimeClient;
            using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
            using RealtimeSessionClient session = await realtimeClient.StartSessionAsync(
                "agent", intent: null, options: options, cancellationToken: timeout.Token);
            (string query, serverSocket) = await AwaitServerRequestAsync(serverTask);
            return query;
        }
        finally
        {
            serverSocket?.Dispose();
            listener.Stop();
        }
    }

    // The client-side call above is bounded by its own 10-second cancellation token, but that
    // alone can't stop this test from hanging (until the CI job's own outer timeout, e.g. 60
    // minutes) if the client faults before ever reaching the socket -- the loopback listener would
    // then wait for a request that never arrives. Bound the server side independently too.
    private static async Task<T> AwaitServerRequestAsync<T>(Task<T> serverTask)
    {
        Task winner = await Task.WhenAny(serverTask, Task.Delay(TimeSpan.FromSeconds(15)));
        if (winner != serverTask)
        {
            Assert.Fail("Timed out waiting for the loopback listener to receive the client's request.");
        }
        return await serverTask;
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
