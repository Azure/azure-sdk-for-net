// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;
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
    [Test]
    public void AuthenticationUsesProviderCreatedSpecializedOptions()
    {
        ProviderTokenOptions created = null;
        InvalidOperationException failure = new("Provider-options verification completed.");
        LiveTestTokenProvider provider = new(_ => Task.FromException<AuthenticationToken>(failure), properties =>
        {
            Dictionary<string, object> normalized = properties.ToDictionary(pair => pair.Key, pair => pair.Value);
            normalized["factory-normalized"] = "verified";
            created = new ProviderTokenOptions(normalized);
            return created;
        });
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        ProjectsRealtimeClient realtime = project.ProjectsRealtimeClient;
        int factoryCallsBeforeStartup = provider.FactoryCalls;

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(() =>
            realtime.StartSessionAsync("agent", intent: null));

        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.SameAs(failure));
            Assert.That(provider.FactoryCalls, Is.EqualTo(factoryCallsBeforeStartup + 1));
            Assert.That(provider.LastOptions, Is.SameAs(created).And.TypeOf<ProviderTokenOptions>());
            Assert.That(provider.LastOptions.Properties["factory-normalized"], Is.EqualTo("verified"));
            Assert.That(provider.AsyncCalls, Is.EqualTo(1));
            Assert.That(provider.SyncCalls, Is.Zero);
        });
    }

    [Test]
    public void UnsupportedAuthenticationFlowIsRejectedBeforeRequestingAToken()
    {
        bool supported = true;
        LiveTestTokenProvider provider = new(
            _ => Task.FromException<AuthenticationToken>(new AssertionException("An unsupported flow must not request a token.")),
            properties => supported ? new GetTokenOptions(properties) : null);
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        ProjectsRealtimeClient realtime = project.ProjectsRealtimeClient;
        int factoryCallsBeforeStartup = provider.FactoryCalls;
        supported = false;

        InvalidOperationException error = Assert.ThrowsAsync<InvalidOperationException>(() =>
            realtime.StartSessionAsync("agent", intent: null));

        Assert.Multiple(() =>
        {
            Assert.That(error.Message, Does.Contain("does not support").And.Contain("Realtime"));
            Assert.That(provider.FactoryCalls, Is.EqualTo(factoryCallsBeforeStartup + 1));
            Assert.That(provider.AsyncCalls, Is.Zero);
            Assert.That(provider.SyncCalls, Is.Zero);
        });
    }

    [Test]
    public void TokenOptionsFactoryFailureIsPropagatedUnchanged()
    {
        bool starting = false;
        InvalidOperationException failure = new("The provider rejected the requested authentication flow.");
        LiveTestTokenProvider provider = new(
            _ => Task.FromException<AuthenticationToken>(new AssertionException("A failing options factory must not request a token.")),
            properties => starting ? throw failure : new GetTokenOptions(properties));
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        ProjectsRealtimeClient realtime = project.ProjectsRealtimeClient;
        starting = true;

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(() =>
            realtime.StartSessionAsync("agent", intent: null));

        Assert.That(actual, Is.SameAs(failure));
        Assert.That(provider.AsyncCalls, Is.Zero);
        Assert.That(provider.SyncCalls, Is.Zero);
    }

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
        using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await client.ProjectsRealtimeClient.StartSessionAsync(
            "cs-e2e-connectivity-test-agent",
            intent: null,
            cancellationToken: timeout.Token);

        (string path, string query, string authorization, string foundryFeatures, string subProtocol) = await AwaitServerRequestAsync(serverTask);
        listener.Stop();

        Assert.Multiple(() =>
        {
            Assert.That(path, Is.EqualTo("/api/projects/proj1/agents/cs-e2e-connectivity-test-agent/endpoint/protocols/voice"),
                "Must target the agent-scoped realtime endpoint, not OpenAI's generic /realtime endpoint.");
            Assert.That(query, Does.Contain("api-version="));
            Assert.That(foundryFeatures, Is.Null,
                "GA realtime connections must not automatically opt into any preview features.");
            Assert.That(query, Does.Not.Contain("foundry_features"));
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
    public async Task DefaultRealtimeHandshakeWithoutInheritedFeaturesIsGA()
    {
        HttpListenerRequest request = await CaptureHandshakeRequestAsync(null, withoutDefaultFeatures: true);

        Assert.Multiple(() =>
        {
            Assert.That(request.Headers["Foundry-Features"], Is.Null);
            Assert.That(request.Url.Query, Is.EqualTo("?api-version=v1"));
            Assert.That(request.Headers["Authorization"], Is.EqualTo("Bearer fake-token"));
        });
    }

    [TestCase("Foundry-Features")]
    [TestCase("foundry-features")]
    [TestCase("FOUNDRY-FEATURES")]
    public async Task ExplicitFeatureHeaderOptsIntoPreviewWithoutChangingCallerOptions(string header)
    {
        const string features = "Other=V2Preview,VoiceAgents=V1Preview,Other=V2Preview,voiceagents=v1preview";
        RealtimeSessionClientOptions options = new() { QueryString = "store=true&keep=%2B" };
        options.Headers.Add(header, features);
        options.Headers.Add("x-realtime-test", "custom-header");

        HttpListenerRequest request = await CaptureHandshakeRequestAsync(options);

        Assert.Multiple(() =>
        {
            Assert.That(request.Headers["Foundry-Features"], Is.EqualTo("Other=V2Preview,VoiceAgents=V1Preview"));
            Assert.That(request.Headers.GetValues("Foundry-Features"), Has.Length.EqualTo(1));
            Assert.That(request.Url.Query, Is.EqualTo("?api-version=v1&store=true&keep=%2B"));
            Assert.That(request.Headers["Authorization"], Is.EqualTo("Bearer fake-token"));
            Assert.That(request.Headers["x-realtime-test"], Is.EqualTo("custom-header"));
            Assert.That(options.Headers[header], Is.EqualTo(features));
            Assert.That(options.QueryString, Is.EqualTo("store=true&keep=%2B"));
        });
    }

    [TestCase("foundry_features")]
    [TestCase("%66oundry_features")]
    [TestCase("FOUNDRY_FEATURES")]
    public async Task ExplicitFeatureQueryOptsIntoPreviewWithoutACompetingHeader(string name)
    {
        const string features = "Other=V2Preview,VoiceAgents=V1Preview,Other=V2Preview";
        string query = $"?keep=one&{name}={Uri.EscapeDataString(features)}&keep=two&path=folder%2F&flag";
        RealtimeSessionClientOptions options = new() { QueryString = query };

        HttpListenerRequest request = await CaptureHandshakeRequestAsync(options);

        Assert.Multiple(() =>
        {
            Assert.That(request.Headers["Foundry-Features"], Is.Null);
            Assert.That(request.Url.Query, Is.EqualTo("?api-version=v1&keep=one&foundry_features=" +
                Uri.EscapeDataString("Other=V2Preview,VoiceAgents=V1Preview") + "&keep=two&path=folder%2F&flag"));
            Assert.That(request.Headers["Authorization"], Is.EqualTo("Bearer fake-token"));
            Assert.That(options.QueryString, Is.EqualTo(query));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task UnrelatedExplicitFeaturesDoNotImplyVoicePreview(bool useQuery)
    {
        RealtimeSessionClientOptions options = new();
        if (useQuery)
        {
            options.QueryString = "foundry_features=Other%3DV2Preview";
        }
        else
        {
            options.Headers.Add("Foundry-Features", "Other=V2Preview");
        }

        HttpListenerRequest request = await CaptureHandshakeRequestAsync(options);

        Assert.Multiple(() =>
        {
            Assert.That(request.Headers["Foundry-Features"], useQuery ? Is.Null : Is.EqualTo("Other=V2Preview"));
            Assert.That(request.Url.Query, Is.EqualTo(useQuery
                ? "?api-version=v1&foundry_features=Other%3DV2Preview"
                : "?api-version=v1"));
        });
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase("VoiceAgents")]
    [TestCase("VoiceAgents=")]
    [TestCase("VoiceAgents=V2Preview")]
    [TestCase("VoiceAgents=V1Preview,VoiceAgents=V2Preview")]
    [TestCase("Other=one,Other=two")]
    [TestCase("Other=one,,VoiceAgents=V1Preview")]
    [TestCase("Other=one\r\n")]
    public void InvalidExplicitFeaturesAreRejectedBeforeAuthentication(string features)
    {
        foreach (bool useQuery in new[] { false, true })
        {
            LiveTestTokenProvider provider = new();
            AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
            RealtimeSessionClientOptions options = new();
            if (useQuery)
            {
                options.QueryString = features == null ? "foundry_features" : "foundry_features=" + Uri.EscapeDataString(features);
            }
            else
            {
                options.Headers.Add("Foundry-Features", features);
            }

            Assert.ThrowsAsync<ArgumentException>(() => project.ProjectsRealtimeClient.StartSessionAsync("agent", null, options));
            Assert.That(provider.AsyncCalls, Is.Zero);
            Assert.That(provider.SyncCalls, Is.Zero);
        }
    }

    [TestCase("foundry_features=Other%3Done&foundry_features=Other%3Done", false)]
    [TestCase("foundry_features=Other%3Done&%66oundry_features=Other%3Dtwo", false)]
    [TestCase("foundry_features=VoiceAgents%3DV1Preview", true)]
    [TestCase("foundry_features=Other%3Done", true)]
    [TestCase("foundry_features=Other%3Done%ZZ", false)]
    public void AmbiguousOrMalformedFeatureQueriesAreRejectedBeforeAuthentication(string query, bool addHeader)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        RealtimeSessionClientOptions options = new() { QueryString = query };
        if (addHeader)
        {
            options.Headers.Add("Foundry-Features", "VoiceAgents=V1Preview");
        }

        Assert.ThrowsAsync<ArgumentException>(() => project.ProjectsRealtimeClient.StartSessionAsync("agent", null, options));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [Test]
    public void DuplicateFeatureHeadersAreRejectedBeforeAuthentication()
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        RealtimeSessionClientOptions options = new();
        options.Headers.Add("Foundry-Features", "VoiceAgents=V1Preview");
        options.Headers.Add("foundry-features", "Other=V2Preview");

        Assert.ThrowsAsync<ArgumentException>(() => project.ProjectsRealtimeClient.StartSessionAsync("agent", null, options));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [TestCase("Sec-WebSocket-Protocol")]
    [TestCase("sec-websocket-protocol")]
    [TestCase("SEC-WEBSOCKET-PROTOCOL")]
    public async Task ExplicitRealtimeSubprotocolDoesNotDuplicateAutomaticNegotiation(string header)
    {
        RealtimeSessionClientOptions options = new();
        options.Headers[header] = "realtime";

        await CaptureHandshakeQueryAsync(options);

        Assert.That(options.Headers[header], Is.EqualTo("realtime"), "Connection setup must not mutate caller-owned options.");
    }

    [TestCase("Authorization", "caller-token")]
    [TestCase("authorization", "caller-token")]
    [TestCase("Sec-WebSocket-Protocol", "unsupported")]
    [TestCase("sec-websocket-protocol", "realtime,realtime")]
    public void ManagedRealtimeHeadersRejectConflictingOverrides(string header, string value)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        RealtimeSessionClientOptions options = new();
        options.Headers[header] = value;

        ArgumentException error = Assert.ThrowsAsync<ArgumentException>(() =>
            project.ProjectsRealtimeClient.StartSessionAsync("agent", null, options));

        Assert.That(error.ParamName, Is.EqualTo("headers"));
        Assert.That(provider.AsyncCalls, Is.Zero, "Invalid managed headers must be rejected before acquiring a credential.");
    }

    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task SynchronousReceiversYieldWithoutReadingAheadAndPreserveSocketOwnership(bool protocol, bool preview)
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
        TaskCompletionSource<bool> reading = new(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskCompletionSource<bool> firstDisposed = new(TaskCreationOptions.RunContinuationsAsynchronously);
        Task server = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            Assert.That(context.Request.Headers["Foundry-Features"] ?? "", preview
                ? Is.EqualTo("Other=V2Preview,VoiceAgents=V1Preview")
                : Is.Empty);
            using WebSocket socket = (await context.AcceptWebSocketAsync("realtime")).WebSocket;
            await reading.Task;
            await Task.Delay(50, timeout.Token);
            await SendAsync("first");
            await firstDisposed.Task;
            await Task.Delay(50, timeout.Token);
            await SendAsync("second");
            await Task.Delay(200, timeout.Token);

            Task SendAsync(string id) => socket.SendAsync(
                new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                    "{\"type\":\"response.created\",\"response\":{\"id\":\"" + id + "\",\"status\":\"in_progress\"}}")),
                WebSocketMessageType.Text, true, timeout.Token);
        });
        AIProjectClient project = new(new Uri($"http://127.0.0.1:{port}/api/projects/project"), new FakeTokenProvider());
        RealtimeSessionClientOptions options = new();
        if (preview)
        {
            options.Headers.Add("Foundry-Features", "Other=V2Preview,VoiceAgents=V1Preview");
        }
        using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await project.ProjectsRealtimeClient.StartSessionAsync("agent", null, options, timeout.Token);
        Task<bool> reader = Task.Run(() =>
        {
            SynchronizationContext previous = SynchronizationContext.Current;
            TrackingSynchronizationContext context = new();
            SynchronizationContext.SetSynchronizationContext(context);
            try
            {
                reading.TrySetResult(true);
                ReadOne("first");
                Assert.That(session.WebSocket.State, Is.EqualTo(WebSocketState.Open), "Disposing an event enumerator must not dispose its session.");
                firstDisposed.TrySetResult(true);
                ReadOne("second");
                Assert.That(context.Posts, Is.Zero, "A blocking receiver must not capture the caller's synchronization context.");
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }
            return true;

            void ReadOne(string id)
            {
                if (protocol)
                {
                    using IEnumerator<ClientResult> events = session.ReceiveUpdates(new RequestOptions { CancellationToken = timeout.Token }).GetEnumerator();
                    Assert.That(events.MoveNext(), Is.True);
                    using JsonDocument document = JsonDocument.Parse(events.Current.GetRawResponse().Content);
                    Assert.That(document.RootElement.GetProperty("response").GetProperty("id").GetString(), Is.EqualTo(id));
                }
                else
                {
                    using IEnumerator<RealtimeServerUpdate> events = session.ReceiveUpdates(timeout.Token).GetEnumerator();
                    Assert.That(events.MoveNext(), Is.True);
                    Assert.That(events.Current, Is.TypeOf<RealtimeServerUpdateResponseCreated>());
                    Assert.That(((RealtimeServerUpdateResponseCreated)events.Current).Response.Id, Is.EqualTo(id));
                }
            }
        });
        try
        {
            await AwaitServerRequestAsync(reader);
        }
        finally
        {
            reading.TrySetResult(true);
            firstDisposed.TrySetResult(true);
        }
        await server;
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task SynchronousReceiversPropagateCancellationOfPendingReads(bool protocol)
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();
        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
        TaskCompletionSource<bool> finished = new(TaskCreationOptions.RunContinuationsAsynchronously);
        Task server = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            using WebSocket socket = (await context.AcceptWebSocketAsync("realtime")).WebSocket;
            await finished.Task;
        });
        AIProjectClient project = new(new Uri($"http://127.0.0.1:{port}/api/projects/project"), new FakeTokenProvider());
        using ProjectsRealtimeSessionClient session = (ProjectsRealtimeSessionClient)await project.ProjectsRealtimeClient.StartSessionAsync("agent", null, cancellationToken: timeout.Token);
        using CancellationTokenSource receiving = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token);
        receiving.CancelAfter(200);
        try
        {
            Task<bool> reader = Task.Run(() =>
            {
                if (protocol)
                {
                    using IEnumerator<ClientResult> events = session.ReceiveUpdates(new RequestOptions { CancellationToken = receiving.Token }).GetEnumerator();
                    Assert.Catch<OperationCanceledException>(() => events.MoveNext());
                }
                else
                {
                    using IEnumerator<RealtimeServerUpdate> events = session.ReceiveUpdates(receiving.Token).GetEnumerator();
                    Assert.Catch<OperationCanceledException>(() => events.MoveNext());
                }
                return true;
            });
            await AwaitServerRequestAsync(reader);
        }
        finally
        {
            finished.TrySetResult(true);
            await server;
        }
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
        => (await CaptureHandshakeRequestAsync(options)).Url.Query;

    private static async Task<HttpListenerRequest> CaptureHandshakeRequestAsync(RealtimeSessionClientOptions options, bool withoutDefaultFeatures = false)
    {
        int port = GetFreeTcpPort();
        using HttpListener listener = new();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();

        Task<(HttpListenerRequest Request, WebSocket Socket)> serverTask = Task.Run(async () =>
        {
            HttpListenerContext context = await listener.GetContextAsync();
            Assert.That(context.Request.Headers["Sec-WebSocket-Protocol"], Is.EqualTo("realtime"));
            HttpListenerWebSocketContext webSocket = await context.AcceptWebSocketAsync(subProtocol: "realtime");
            return (context.Request, webSocket.WebSocket);
        });

        WebSocket serverSocket = null;
        try
        {
            Uri endpoint = new($"http://127.0.0.1:{port}/api/projects/proj1");
            AIProjectClient client = new(endpoint, new FakeTokenProvider());
            RealtimeClient realtimeClient = withoutDefaultFeatures
                ? (ProjectsRealtimeClient)Activator.CreateInstance(typeof(ProjectsRealtimeClient),
                    BindingFlags.Instance | BindingFlags.NonPublic, null,
                    new object[] { endpoint, new FakeTokenProvider(), new Dictionary<string, object>(), "v1", null, null }, null)
                : client.ProjectsRealtimeClient;
            using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(10));
            using RealtimeSessionClient session = await realtimeClient.StartSessionAsync(
                "agent", intent: null, options: options, cancellationToken: timeout.Token);
            (HttpListenerRequest request, serverSocket) = await AwaitServerRequestAsync(serverTask);
            await serverSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(
                """{"type":"response.created","response":{"id":"handshake-response","status":"in_progress"}}""")),
                WebSocketMessageType.Text, true, timeout.Token);
            await using (IAsyncEnumerator<RealtimeServerUpdate> events = session.ReceiveUpdatesAsync(timeout.Token).GetAsyncEnumerator())
            {
                Assert.That(await AwaitServerRequestAsync(events.MoveNextAsync().AsTask()), Is.True);
                Assert.That(events.Current, Is.TypeOf<RealtimeServerUpdateResponseCreated>());
                Assert.That(((RealtimeServerUpdateResponseCreated)events.Current).Response.Id, Is.EqualTo("handshake-response"));
            }
            Assert.That(session.WebSocket.State, Is.EqualTo(WebSocketState.Open));
            return request;
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

    private sealed class TrackingSynchronizationContext : SynchronizationContext
    {
        private int _posts;
        public int Posts => Volatile.Read(ref _posts);

        public override void Post(SendOrPostCallback callback, object state)
        {
            Interlocked.Increment(ref _posts);
            ThreadPool.QueueUserWorkItem(_ => callback(state));
        }
    }

    private sealed class ProviderTokenOptions(IReadOnlyDictionary<string, object> properties) : GetTokenOptions(properties);

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
