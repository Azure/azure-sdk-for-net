// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

#pragma warning disable AAIP001
#pragma warning disable SCME0002

namespace Azure.AI.Projects.Tests;

public class ProjectsLiveClientTests
{
    [Test]
    public async Task FactoryIsCachedAcrossConcurrentCallersAndSharesProjectConfiguration()
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("https://example.test/api/projects/project"), provider);
        ProjectsLiveClient[] clients = await Task.WhenAll(Enumerable.Range(0, 16)
            .Select(_ => Task.Run(() => project.ProjectsLiveClient)));

        Assert.Multiple(() =>
        {
            foreach (ProjectsLiveClient client in clients)
            {
                Assert.That(client, Is.SameAs(project.ProjectsLiveClient));
                Assert.That(client.Endpoint, Is.EqualTo(new Uri("https://example.test/api/projects/project")));
                Assert.That(client.Pipeline, Is.SameAs(project.Pipeline));
            }
            Assert.That(provider.AsyncCalls, Is.Zero);
            Assert.That(provider.SyncCalls, Is.Zero);
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task CredentialSettingsRetainProviderForLiveHandshake(bool useCredentialSettings)
    {
        using LiveLoopbackServer server = new();
        LiveTestTokenProvider provider = new();
        IConfiguration configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            ["Credential:Scope"] = "https://ai.azure.com/.default"
        }).Build();
        AIProjectClientSettings settings = new()
        {
            Endpoint = server.Endpoint,
            Credential = new CredentialSettings(configuration.GetSection("Credential")) { CredentialSource = "TokenCredential" }
        };
        if (useCredentialSettings)
        {
            settings.Credential.TokenProvider = provider;
        }
        else
        {
            settings.CredentialProvider = provider;
        }
        AIProjectClient project = new(settings);
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        using ProjectsLiveSessionClient session = await LiveTestHelpers.AwaitAsync(
            project.ProjectsLiveClient.StartSessionAsync("settings-agent", cancellationToken: timeout.Token));
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);

        Assert.Multiple(() =>
        {
            Assert.That(connection.Request.Headers["Authorization"], Is.EqualTo("TestScheme live-test-token"));
            Assert.That(provider.AsyncCalls, Is.EqualTo(1));
            Assert.That(provider.SyncCalls, Is.Zero);
            Assert.That(project.ProjectsLiveClient.Pipeline, Is.SameAs(project.Pipeline));
            Assert.That(session.State, Is.EqualTo(WebSocketState.Open));
        });
    }

    [Test]
    public void ApiKeySettingsDoNotExposeAnUnauthenticatedLiveClient()
    {
        AIProjectClient project = new(new AIProjectClientSettings
        {
            Endpoint = new Uri("https://example.test/api/projects/project"),
            Credential = new CredentialSettings(null) { CredentialSource = "ApiKey", Key = "not-a-real-key" }
        });

        Assert.Throws<InvalidOperationException>(() => _ = project.ProjectsLiveClient);
    }

    [TestCase(null)]
    [TestCase(true)]
    [TestCase(false)]
    public async Task HandshakeUsesEscapedLiveEndpointFoundryAuthAndMergedOptions(bool? store)
    {
        using LiveLoopbackServer server = new();
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(server.Endpoint, provider,
            new AIProjectClientOptions(AIProjectClientOptions.ServiceVersion.V2025_05_01));
        const string agentName = "voice agent+%/name";
        ProjectsLiveSessionClientOptions options = new()
        {
            Store = store,
            AgentVersion = "version /+%7",
            QueryString = "?keep=one&keep=two&path=folder%2Ffile&flag"
        };
        options.StructuredInputs.Add("display_name", BinaryData.FromString("\"Ada & Grace /+\""));
        options.Headers.Add("x-live-test", "custom-header");
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        using ProjectsLiveSessionClient session = await LiveTestHelpers.AwaitAsync(
            project.ProjectsLiveClient.StartSessionAsync(agentName, options, timeout.Token));
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);
        string[] query = connection.Request.Url.Query.TrimStart('?').Split('&');
        string structured = query.Single(parameter => parameter.StartsWith("structured_inputs=", StringComparison.Ordinal));
        using JsonDocument structuredInputs = JsonDocument.Parse(Uri.UnescapeDataString(structured.Substring("structured_inputs=".Length)));

        Assert.Multiple(() =>
        {
            Assert.That(connection.Request.RawUrl.Split('?')[0],
                Is.EqualTo("/api/projects/project/agents/" + Uri.EscapeDataString(agentName) + "/endpoint/protocols/voice/live/sessions"));
            Assert.That(query, Does.Contain("api-version=2025-05-01"));
            Assert.That(query, Does.Contain("x-agent-version-override=" + Uri.EscapeDataString("version /+%7")));
            Assert.That(structuredInputs.RootElement.GetProperty("display_name").GetString(), Is.EqualTo("Ada & Grace /+"));
            Assert.That(query, Does.Contain("keep=one").And.Contain("keep=two"));
            Assert.That(query, Does.Contain("path=folder%2Ffile").And.Contain("flag"));
            Assert.That(query.Where(parameter => parameter.StartsWith("store=", StringComparison.Ordinal)),
                store.HasValue ? Is.EqualTo(new[] { store.Value ? "store=true" : "store=false" }) : Is.Empty);
            Assert.That(connection.Request.Headers["x-live-test"], Is.EqualTo("custom-header"));
            Assert.That(connection.Request.Headers["Foundry-Features"], Does.Contain("VoiceAgents=V1Preview"));
            Assert.That(connection.Request.Headers["Authorization"], Is.EqualTo("TestScheme live-test-token"));
            Assert.That(connection.Request.Headers["Sec-WebSocket-Protocol"], Is.Null.Or.Empty);
            Assert.That(connection.Socket.SubProtocol, Is.Null.Or.Empty);
            Assert.That(Guid.TryParse(connection.Request.Headers["x-ms-client-request-id"], out _), Is.True);
            Assert.That(provider.LastOptions.Properties[GetTokenOptions.ScopesPropertyName],
                Is.EqualTo(new[] { "https://ai.azure.com/.default" }));
            Assert.That(provider.LastOptions.Properties[GetTokenOptions.AuthorizationUrlPropertyName],
                Is.EqualTo("https://login.microsoftonline.com/common/oauth2/v2.0/authorize"));
            Assert.That(provider.SyncCalls, Is.Zero);
            Assert.That(session.SessionStarted, Is.Not.Null);
            Assert.That(LiveTestHelpers.EventType(session.SessionStarted), Is.EqualTo("session.started"));
        });
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task StartWaitsForFoundryAcknowledgmentWithoutSendingClientCommand(bool useOptions)
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        ProjectsLiveSessionClientOptions options = useOptions ? new() { Store = false } : null;
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync(acknowledge: false);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", options, timeout.Token);
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);
        Task<BinaryData> firstClientCommand = LiveTestHelpers.ReceiveTextAsync(connection.Socket, timeout.Token);

        Assert.That(starting.IsCompleted, Is.False, "A successful WebSocket handshake is not a started Live session.");
        await LiveTestHelpers.SendTextAsync(connection.Socket, LiveTestHelpers.SessionStartedJson, timeout.Token);
        using ProjectsLiveSessionClient session = await LiveTestHelpers.AwaitAsync(starting);
        await session.SendEventAsync(new LiveClientEventLiveSessionCloseParam { EventId = "first-client-command" }, timeout.Token);
        using JsonDocument command = JsonDocument.Parse(await LiveTestHelpers.AwaitAsync(firstClientCommand));

        Assert.Multiple(() =>
        {
            Assert.That(session.State, Is.EqualTo(WebSocketState.Open));
            Assert.That(LiveTestHelpers.EventType(session.SessionStarted), Is.EqualTo("session.started"));
            Assert.That(session.SessionClosed, Is.Null);
            Assert.That(command.RootElement.GetProperty("type").GetString(), Is.EqualTo("session.close"),
                "The first client frame must be the caller's command, not an automatic duplicate session.start.");
            Assert.That(command.RootElement.GetProperty("event_id").GetString(), Is.EqualTo("first-client-command"));
        });
    }

    [Test]
    public async Task ConcurrentSessionsHaveIndependentSocketsAndDisposal()
    {
        using LiveLoopbackServer server = new();
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(server.Endpoint, provider);
        Task<LiveLoopbackConnection> acceptingFirst = server.AcceptSessionAsync();
        Task<LiveLoopbackConnection> acceptingSecond = server.AcceptSessionAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> startingLeft = project.ProjectsLiveClient.StartSessionAsync("left", cancellationToken: timeout.Token);
        Task<ProjectsLiveSessionClient> startingRight = project.ProjectsLiveClient.StartSessionAsync("right", cancellationToken: timeout.Token);
        using ProjectsLiveSessionClient left = await LiveTestHelpers.AwaitAsync(startingLeft);
        using ProjectsLiveSessionClient right = await LiveTestHelpers.AwaitAsync(startingRight);
        LiveLoopbackConnection[] connections = await LiveTestHelpers.AwaitAsync(Task.WhenAll(acceptingFirst, acceptingSecond));
        LiveLoopbackConnection rightConnection = connections.Single(connection =>
            connection.Request.Url.AbsolutePath.Contains("/agents/right/"));

        left.Dispose();
        await right.SendEventAsync(new LiveClientEventLiveSessionCloseParam(), timeout.Token);
        BinaryData received = await LiveTestHelpers.ReceiveTextAsync(rightConnection.Socket, timeout.Token);
        await using IAsyncEnumerator<LiveServerEvent> rightEvents = right.ReceiveEventsAsync(timeout.Token).GetAsyncEnumerator();

        Assert.That(await LiveTestHelpers.AwaitAsync(rightEvents.MoveNextAsync().AsTask()), Is.True);
        Assert.Multiple(() =>
        {
            Assert.That(left, Is.Not.SameAs(right));
            Assert.That(left.SessionStarted, Is.Not.SameAs(right.SessionStarted));
            Assert.That(right.State, Is.EqualTo(WebSocketState.Open));
            Assert.That(LiveTestHelpers.EventType(received), Is.EqualTo("session.close"));
            Assert.That(rightEvents.Current, Is.SameAs(right.SessionStarted));
            Assert.That(provider.AsyncCalls, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task FactoryRetainsTypedFoundryStartupAndConversationWithoutSessionOverrides()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        using ProjectsLiveSessionClient session = await LiveTestHelpers.AwaitAsync(
            project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: timeout.Token));
        await LiveTestHelpers.AwaitAsync(accepting);
        LiveServerEventLiveSessionStarted started = session.SessionStarted;

        Assert.Multiple(() =>
        {
            Assert.That(started.EventId, Is.EqualTo("started-event"));
            Assert.That(started.Session.Id, Is.EqualTo("live-session"));
            Assert.That(started.Session.Model, Is.EqualTo(ModelIdsLive.GptLive1));
            Assert.That(started.Session.Status, Is.EqualTo("active"));
            Assert.That(started.ConversationId, Is.EqualTo("foundry-conversation"));
            Assert.That(session.SessionClosed, Is.Null);
        });
    }

    [Test]
    public void StructuredInputsPreserveJsonTypesAndAreEncodedAsOneHandshakeParameter()
    {
        ProjectsLiveSessionClientOptions options = new() { AgentVersion = "7", QueryString = "keep=one" };
        options.StructuredInputs.Add("name", BinaryData.FromString("\"Ada & Grace /+\""));
        options.StructuredInputs.Add("count", BinaryData.FromString("7"));
        options.StructuredInputs.Add("enabled", BinaryData.FromString("true"));
        options.StructuredInputs.Add("settings", BinaryData.FromString("""{"nested":[1,"two",null]}"""));
        options.StructuredInputs.Add("empty", null);

        Uri uri = LiveTestHelpers.BuildEndpoint(new Uri("https://example.test/api/projects/project"), "agent", "v1", options);
        string[] query = uri.Query.TrimStart('?').Split('&');
        string structured = query.Single(parameter => parameter.StartsWith("structured_inputs=", StringComparison.Ordinal));
        using JsonDocument document = JsonDocument.Parse(Uri.UnescapeDataString(structured.Substring("structured_inputs=".Length)));

        Assert.Multiple(() =>
        {
            Assert.That(query, Has.Length.EqualTo(4));
            Assert.That(query, Does.Contain("api-version=v1").And.Contain("x-agent-version-override=7").And.Contain("keep=one"));
            Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("Ada & Grace /+"));
            Assert.That(document.RootElement.GetProperty("count").GetInt32(), Is.EqualTo(7));
            Assert.That(document.RootElement.GetProperty("enabled").GetBoolean(), Is.True);
            Assert.That(document.RootElement.GetProperty("settings").GetProperty("nested").GetArrayLength(), Is.EqualTo(3));
            Assert.That(document.RootElement.GetProperty("empty").ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(options.StructuredInputs.Count, Is.EqualTo(5));
            Assert.That(options.QueryString, Is.EqualTo("keep=one"));
        });
    }

    [TestCase("x-agent-version-override=other", true, false)]
    [TestCase("%78-agent-version-override=other", true, false)]
    [TestCase("X-AGENT-VERSION-OVERRIDE=other", true, false)]
    [TestCase("structured_inputs=other", false, true)]
    [TestCase("%73tructured_inputs=other", false, true)]
    [TestCase("structured_input=other", false, true)]
    public void ConflictingAgentVersionOrStructuredInputsAreRejectedBeforeAuthentication(
        string query, bool setVersion, bool setInputs)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        ProjectsLiveSessionClientOptions options = new() { QueryString = query, AgentVersion = setVersion ? "7" : null };
        if (setInputs)
        {
            options.StructuredInputs.Add("name", BinaryData.FromString("\"Ada\""));
        }

        Assert.ThrowsAsync<ArgumentException>(() => project.ProjectsLiveClient.StartSessionAsync("agent", options));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [Test]
    public void InvalidStructuredInputJsonIsRejectedBeforeAuthentication()
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        ProjectsLiveSessionClientOptions options = new();
        options.StructuredInputs.Add("invalid", BinaryData.FromString("{"));

        Assert.CatchAsync<JsonException>(() => project.ProjectsLiveClient.StartSessionAsync("agent", options));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [TestCase("api-version=other", null)]
    [TestCase("%61pi-version=other", null)]
    [TestCase("API-VERSION=other", null)]
    [TestCase("store=true", false)]
    [TestCase("%73tore=true", false)]
    [TestCase("STORE=false", true)]
    public void ConflictingManagedQueryIsRejectedBeforeAuthentication(string query, bool? store)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        ProjectsLiveSessionClientOptions options = new() { Store = store, QueryString = query };

        ArgumentException exception = Assert.ThrowsAsync<ArgumentException>(() =>
            project.ProjectsLiveClient.StartSessionAsync("agent", options));

        Assert.Multiple(() =>
        {
            Assert.That(exception.ParamName, Is.EqualTo(nameof(options)));
            Assert.That(provider.AsyncCalls, Is.Zero);
        });
    }

    [Test]
    public void RawStoreQueryIsPreservedWhenTypedStoreIsOmitted()
    {
        ProjectsLiveSessionClientOptions options = new() { QueryString = "store=true&keep=%2B" };
        Uri uri = LiveTestHelpers.BuildEndpoint(new Uri("https://example.test/api/projects/project/?ignored=true"),
            "agent", "v1", options);

        Assert.Multiple(() =>
        {
            Assert.That(uri.Scheme, Is.EqualTo("wss"));
            Assert.That(uri.AbsolutePath, Is.EqualTo("/api/projects/project/agents/agent/endpoint/protocols/voice/live/sessions"));
            Assert.That(uri.Query, Is.EqualTo("?api-version=v1&store=true&keep=%2B"));
            Assert.That(options.QueryString, Is.EqualTo("store=true&keep=%2B"));
        });
    }

    [TestCase("Authorization")]
    [TestCase("authorization")]
    [TestCase("Foundry-Features")]
    [TestCase("foundry-features")]
    [TestCase("Sec-WebSocket-Protocol")]
    public void ManagedHandshakeHeadersCannotBeOverridden(string header)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        ProjectsLiveSessionClientOptions options = new();
        options.Headers.Add(header, "not-allowed");

        Assert.ThrowsAsync<ArgumentException>(() => project.ProjectsLiveClient.StartSessionAsync("agent", options));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [TestCase(null)]
    [TestCase("")]
    public void InvalidAgentNameIsRejectedBeforeAuthentication(string agentName)
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);

        Assert.CatchAsync<ArgumentException>(() => project.ProjectsLiveClient.StartSessionAsync(agentName));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [Test]
    public void PreCanceledStartDoesNotAuthenticate()
    {
        LiveTestTokenProvider provider = new();
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(() =>
            project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: cancellation.Token));
        Assert.That(provider.AsyncCalls, Is.Zero);
    }

    [Test]
    public async Task CancellationDuringAuthenticationReachesProvider()
    {
        TaskCompletionSource<bool> entered = LiveTestHelpers.CreateSignal();
        LiveTestTokenProvider provider = new(async cancellationToken =>
        {
            entered.TrySetResult(true);
            await Task.Delay(Timeout.Infinite, cancellationToken);
            throw new AssertionException("Authentication should have been canceled.");
        });
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: cancellation.Token);
        await LiveTestHelpers.AwaitAsync(entered.Task);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(starting));
        Assert.That(provider.LastCancellationToken.IsCancellationRequested, Is.True);
    }

    [Test]
    public void AuthenticationFailureIsPropagatedUnchanged()
    {
        InvalidOperationException failure = new("Test authentication failure.");
        LiveTestTokenProvider provider = new(_ => Task.FromException<AuthenticationToken>(failure));
        AIProjectClient project = new(new Uri("http://127.0.0.1:1/api/projects/project"), provider);

        InvalidOperationException actual = Assert.ThrowsAsync<InvalidOperationException>(() =>
            project.ProjectsLiveClient.StartSessionAsync("agent"));

        Assert.That(actual, Is.SameAs(failure));
    }

    [Test]
    public async Task CancellationDuringWebSocketHandshakeStopsConnection()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<HttpListenerContext> request = server.GetRequestAsync();
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: cancellation.Token);
        HttpListenerContext context = await LiveTestHelpers.AwaitAsync(request);
        Assert.That(context.Request.IsWebSocketRequest, Is.True);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(starting));
    }

    [Test]
    public async Task CancellationWhileWaitingForSessionStartedStopsStartup()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync(acknowledge: false);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: cancellation.Token);
        await LiveTestHelpers.AwaitAsync(accepting);

        cancellation.Cancel();

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(starting));
    }

    [Test]
    public async Task ProjectNetworkTimeoutAlsoBoundsSessionStartup()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider(),
            new AIProjectClientOptions { NetworkTimeout = TimeSpan.FromSeconds(2) });
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync(acknowledge: false);
        using CancellationTokenSource cancellation = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: cancellation.Token);
        await LiveTestHelpers.AwaitAsync(accepting);

        Assert.CatchAsync<OperationCanceledException>(async () => await LiveTestHelpers.AwaitAsync(starting));
        Assert.That(cancellation.IsCancellationRequested, Is.False, "The project's timeout, not the test's deadline, must stop startup.");
    }

    [Test]
    public async Task FailedHttpUpgradeIsNotReportedAsAStartedSession()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<HttpListenerContext> request = server.GetRequestAsync();
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: timeout.Token);
        HttpListenerContext context = await LiveTestHelpers.AwaitAsync(request);
        context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
        context.Response.Close();

        Assert.ThrowsAsync<WebSocketException>(async () => await LiveTestHelpers.AwaitAsync(starting));
    }

    [TestCase("""{"type":"error","event_id":"startup-error","error":{"type":"invalid_request_error","code":"invalid_session","message":"Session rejected."}}""", typeof(InvalidOperationException))]
    [TestCase("""{"type":"session.closed"}""", typeof(InvalidDataException))]
    [TestCase("{", typeof(JsonException))]
    public async Task InvalidStartupEventFailsInsteadOfReturningSession(string firstEvent, Type exceptionType)
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync(acknowledge: false);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: timeout.Token);
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);
        await LiveTestHelpers.SendTextAsync(connection.Socket, firstEvent, timeout.Token);

        Exception exception = Assert.CatchAsync(async () => await LiveTestHelpers.AwaitAsync(starting));
        Assert.That(exception, Is.InstanceOf(exceptionType));
    }

    [Test]
    public async Task PeerClosingBeforeAcknowledgmentFailsStartup()
    {
        using LiveLoopbackServer server = new();
        AIProjectClient project = new(server.Endpoint, new LiveTestTokenProvider());
        Task<LiveLoopbackConnection> accepting = server.AcceptSessionAsync(acknowledge: false);
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        Task<ProjectsLiveSessionClient> starting = project.ProjectsLiveClient.StartSessionAsync("agent", cancellationToken: timeout.Token);
        LiveLoopbackConnection connection = await LiveTestHelpers.AwaitAsync(accepting);
        await connection.Socket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "No session.", timeout.Token);

        Assert.ThrowsAsync<InvalidOperationException>(async () => await LiveTestHelpers.AwaitAsync(starting));
    }
}

internal sealed class LiveTestTokenProvider : AuthenticationTokenProvider
{
    private readonly Func<CancellationToken, Task<AuthenticationToken>> _getToken;
    private int _asyncCalls;
    private int _syncCalls;

    public LiveTestTokenProvider(Func<CancellationToken, Task<AuthenticationToken>> getToken = null)
    {
        _getToken = getToken;
    }

    public int AsyncCalls => Volatile.Read(ref _asyncCalls);
    public int SyncCalls => Volatile.Read(ref _syncCalls);
    public GetTokenOptions LastOptions { get; private set; }
    public CancellationToken LastCancellationToken { get; private set; }

    public override GetTokenOptions CreateTokenOptions(IReadOnlyDictionary<string, object> properties) => new(properties);

    public override AuthenticationToken GetToken(GetTokenOptions options, CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _syncCalls);
        throw new AssertionException("Live startup must use asynchronous authentication.");
    }

    public override ValueTask<AuthenticationToken> GetTokenAsync(GetTokenOptions options, CancellationToken cancellationToken)
    {
        Interlocked.Increment(ref _asyncCalls);
        LastOptions = options;
        LastCancellationToken = cancellationToken;
        cancellationToken.ThrowIfCancellationRequested();
        return _getToken != null
            ? new ValueTask<AuthenticationToken>(_getToken(cancellationToken))
            : new ValueTask<AuthenticationToken>(new AuthenticationToken(
                "live-test-token", "TestScheme", DateTimeOffset.UtcNow.AddHours(1), null));
    }
}

internal sealed class LiveLoopbackServer : IDisposable
{
    private readonly HttpListener _listener = new();
    private readonly List<WebSocket> _sockets = new();

    public LiveLoopbackServer()
    {
        TcpListener portReservation = new(IPAddress.Loopback, 0);
        portReservation.Start();
        int port = ((IPEndPoint)portReservation.LocalEndpoint).Port;
        portReservation.Stop();
        _listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        _listener.Start();
        Endpoint = new Uri($"http://127.0.0.1:{port}/api/projects/project");
    }

    public Uri Endpoint { get; }

    public Task<HttpListenerContext> GetRequestAsync() => _listener.GetContextAsync();

    public async Task<LiveLoopbackConnection> AcceptSessionAsync(bool acknowledge = true)
    {
        HttpListenerContext context = await LiveTestHelpers.AwaitAsync(GetRequestAsync());
        Assert.That(context.Request.IsWebSocketRequest, Is.True);
        HttpListenerWebSocketContext accepted = await LiveTestHelpers.AwaitAsync(context.AcceptWebSocketAsync(null));
        WebSocket socket = accepted.WebSocket;
        lock (_sockets)
        {
            _sockets.Add(socket);
        }
        using CancellationTokenSource timeout = LiveTestHelpers.CreateTimeout();
        if (acknowledge)
        {
            await LiveTestHelpers.SendTextAsync(socket, LiveTestHelpers.SessionStartedJson, timeout.Token);
        }
        return new LiveLoopbackConnection(context.Request, socket);
    }

    public void Dispose()
    {
        lock (_sockets)
        {
            foreach (WebSocket socket in _sockets)
            {
                socket.Dispose();
            }
        }
        _listener.Close();
    }
}

internal sealed class LiveLoopbackConnection
{
    public LiveLoopbackConnection(HttpListenerRequest request, WebSocket socket)
    {
        Request = request;
        Socket = socket;
    }

    public HttpListenerRequest Request { get; }
    public WebSocket Socket { get; }
}

internal static class LiveTestHelpers
{
    internal const string SessionStartedJson = """{"type":"session.started","event_id":"started-event","session":{"id":"live-session","model":"gpt-live-1","expires_at":2000000000,"status":"active"},"conversation_id":"foundry-conversation"}""";
    internal const string SessionClosedJson = """{"type":"session.closed","event_id":"closed-event","reason":"close_requested","session":{"id":"live-session","model":"gpt-live-1","expires_at":2000000000,"status":"active"},"usage":{"seconds":0}}""";

    internal static ProjectsLiveSessionClient CreateSession(WebSocket socket) =>
        (ProjectsLiveSessionClient)Activator.CreateInstance(typeof(ProjectsLiveSessionClient),
            BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { socket }, null);

    internal static Task InitializeAsync(ProjectsLiveSessionClient session, CancellationToken cancellationToken)
    {
        MethodInfo method = typeof(ProjectsLiveSessionClient).GetMethod("InitializeAsync", BindingFlags.Instance | BindingFlags.NonPublic);
        try
        {
            return (Task)method.Invoke(session, new object[] { cancellationToken });
        }
        catch (TargetInvocationException exception) when (exception.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            throw;
        }
    }

    internal static Uri BuildEndpoint(Uri endpoint, string agentName, string apiVersion, ProjectsLiveSessionClientOptions options)
    {
        MethodInfo method = typeof(ProjectsLiveClient).GetMethod("BuildEndpoint", BindingFlags.Static | BindingFlags.NonPublic);
        try
        {
            return (Uri)method.Invoke(null, new object[] { endpoint, agentName, apiVersion, options });
        }
        catch (TargetInvocationException exception) when (exception.InnerException != null)
        {
            ExceptionDispatchInfo.Capture(exception.InnerException).Throw();
            throw;
        }
    }

    internal static CancellationTokenSource CreateTimeout() => new(TimeSpan.FromSeconds(10));

    internal static TaskCompletionSource<bool> CreateSignal() => new(TaskCreationOptions.RunContinuationsAsynchronously);

    internal static async Task AwaitAsync(Task operation)
    {
        Task completed = await Task.WhenAny(operation, Task.Delay(TimeSpan.FromSeconds(15)));
        Assert.That(completed, Is.SameAs(operation), "The deterministic Live operation did not complete before its deadline.");
        await operation;
    }

    internal static async Task<T> AwaitAsync<T>(Task<T> operation)
    {
        await AwaitAsync((Task)operation);
        return await operation;
    }

    internal static string EventType(LiveServerEvent serverEvent) =>
        EventType(ModelReaderWriter.Write(serverEvent, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default));

    internal static string EventType(BinaryData data)
    {
        using JsonDocument document = JsonDocument.Parse(data);
        return document.RootElement.GetProperty("type").GetString();
    }

    internal static Task SendTextAsync(WebSocket socket, string text, CancellationToken cancellationToken) =>
        socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(text)), WebSocketMessageType.Text, true, cancellationToken);

    internal static async Task<BinaryData> ReceiveTextAsync(WebSocket socket, CancellationToken cancellationToken)
    {
        byte[] buffer = new byte[8192];
        using MemoryStream stream = new();
        WebSocketReceiveResult result;
        do
        {
            result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);
            Assert.That(result.MessageType, Is.EqualTo(WebSocketMessageType.Text));
            stream.Write(buffer, 0, result.Count);
        }
        while (!result.EndOfMessage);
        return BinaryData.FromBytes(stream.ToArray());
    }
}
