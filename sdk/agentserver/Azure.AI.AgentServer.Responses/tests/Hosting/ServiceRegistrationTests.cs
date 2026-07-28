// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// T015 — Verify registering all 3 custom interface implementations separately
/// and that each interface receives the correct calls.
/// T016 — Verify TryAddSingleton semantics: consumer registrations before
/// AddResponsesServer() take precedence.
/// </summary>
public class ServiceRegistrationTests
{
    // ═══════════════════════════════════════════════════════════════════════
    // T016: TryAddSingleton semantics — consumer registrations take precedence
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public void Custom_ResponsesProvider_Takes_Precedence_Over_Default()
    {
        var custom = new StubResponsesProvider();
        var services = new ServiceCollection();
        services.AddSingleton<ResponsesProvider>(custom);
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var resolved = sp.GetRequiredService<ResponsesProvider>();

        Assert.That(resolved, Is.SameAs(custom));
    }

    [Test]
    public void Custom_ResponsesCancellationSignalProvider_Takes_Precedence_Over_Default()
    {
        var custom = new StubCancellationProvider();
        var services = new ServiceCollection();
        services.AddSingleton<ResponsesCancellationSignalProvider>(custom);
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var resolved = sp.GetRequiredService<ResponsesCancellationSignalProvider>();

        Assert.That(resolved, Is.SameAs(custom));
    }

    [Test]
    public void Default_Registration_Selects_FileBacked_State_Provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var state = sp.GetRequiredService<ResponsesProvider>();
        var cancel = sp.GetRequiredService<ResponsesCancellationSignalProvider>();

        // The durable file-backed provider is the local default (CC1) so response envelopes
        // survive a process restart with full local fidelity, matching Python. The
        // InMemoryResponsesProvider remains registered (it backs the cancellation signal
        // adapter) but is no longer selected as the ResponsesProvider.
        Assert.That(state, Is.InstanceOf<Azure.AI.AgentServer.Responses.Internal.Resilience.FileResponsesProvider>());
        Assert.That(cancel, Is.InstanceOf<InMemoryCancellationSignalProvider>());
        Assert.That(sp.GetRequiredService<InMemoryResponsesProvider>(), Is.Not.Null);
    }

    [Test]
    public void ResilientBackground_Local_Registers_EventStreamRegistry()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer(o => o.ResilientBackground = true);

        using var sp = services.BuildServiceProvider();

        // SSE streaming now composes the Core event-stream primitive. The durable
        // file-backed replay is an internal Core selection; from the Responses layer
        // we assert the registry is available for the orchestrator/replay to use.
        Assert.That(sp.GetService<Core.Streaming.IEventStreamRegistry>(), Is.Not.Null);
    }

    [Test]
    public void ResilientBackground_Local_Selects_Durable_FileBacked_Provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer(o => o.ResilientBackground = true);

        using var sp = services.BuildServiceProvider();
        var state = sp.GetRequiredService<ResponsesProvider>();

        // Resilient background requires state that survives restart → durable file-backed provider.
        Assert.That(state, Is.InstanceOf<Azure.AI.AgentServer.Responses.Internal.Resilience.FileResponsesProvider>());
    }

    [Test]
    public void Non_Resilient_Local_Defaults_To_FileBacked_Provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer(o => o.ResilientBackground = false);

        using var sp = services.BuildServiceProvider();
        var state = sp.GetRequiredService<ResponsesProvider>();

        // CC1: the file-backed provider is the local default even when ResilientBackground is off.
        // The InMemoryResponsesProvider stays registered but is no longer selected.
        Assert.That(state, Is.InstanceOf<Azure.AI.AgentServer.Responses.Internal.Resilience.FileResponsesProvider>());
        Assert.That(sp.GetRequiredService<InMemoryResponsesProvider>(), Is.Not.Null);
    }

    [Test]
    public void Partial_Override_One_Interface_Leaves_Others_At_Default()
    {
        var customState = new StubResponsesProvider();
        var services = new ServiceCollection();
        services.AddSingleton<ResponsesProvider>(customState);
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var state = sp.GetRequiredService<ResponsesProvider>();
        var cancel = sp.GetRequiredService<ResponsesCancellationSignalProvider>();

        // Custom state provider
        Assert.That(state, Is.SameAs(customState));

        // Cancel should resolve to the InMemory adapter (not custom)
        Assert.That(cancel, Is.InstanceOf<InMemoryCancellationSignalProvider>());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T015: Protocol-level — three separate implementations,
    // each receives the correct calls
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Separate_State_And_Cancel_Providers_Each_Receive_Correct_Calls()
    {
        var stateProvider = new RecordingStateProvider();
        var cancelProvider = new RecordingCancelProvider();

        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(stateProvider);
                services.AddSingleton<ResponsesCancellationSignalProvider>(cancelProvider);
            });
        using var client = factory.CreateClient();

        // POST /responses with bg+streaming — triggers CreateResponseAsync (state) and
        // GetResponseCancellationTokenAsync (cancel). SSE streaming is now handled by the
        // Core event-stream primitive, not a pluggable Responses stream provider.
        var body = JsonSerializer.Serialize(new { model = "test", background = true, stream = true });
        var response = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Consume the SSE stream so the handler completes
        await response.Content.ReadAsStringAsync();

        // Verify state provider got state calls
        XAssert.Contains("CreateResponseAsync", stateProvider.Calls);

        // Verify cancellation provider got token creation call
        XAssert.Contains("GetResponseCancellationTokenAsync", cancelProvider.Calls);

        // Verify NO cross-contamination between the two providers
        XAssert.DoesNotContain("CancelResponseAsync", stateProvider.Calls);
        XAssert.DoesNotContain("CreateResponseAsync", cancelProvider.Calls);
    }

    [Test]
    public async Task Cancel_Operation_Routes_To_CancellationSignalProvider()
    {
        var stateProvider = new RecordingStateProvider();
        var cancelProvider = new RecordingCancelProvider();

        var blockingHandler = new TestHandler();
        blockingHandler.EventFactory = (_, ctx, ct) => BlockingStream(ctx, ct);
        using var factory = new TestWebApplicationFactory(
            handler: blockingHandler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(stateProvider);
                services.AddSingleton<ResponsesCancellationSignalProvider>(cancelProvider);
            });
        using var client = factory.CreateClient();

        // Create a background response
        var createBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Cancel should route to cancellation provider
        var cancelResponse = await client.PostAsync($"/responses/{responseId}/cancel", null);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        XAssert.Contains("CancelResponseAsync", cancelProvider.Calls);

        // Wait for background to finish (poll until terminal status)
        var deadline = DateTime.UtcNow.AddSeconds(5);
        while (DateTime.UtcNow < deadline)
        {
            var getResponse = await client.GetAsync($"/responses/{responseId}");
            var body = await getResponse.Content.ReadFromJsonAsync<JsonElement>();
            var status = body.GetProperty("status").GetString();
            if (status is "completed" or "failed" or "incomplete" or "cancelled")
                break;
            await Task.Delay(50);
        }
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Stub/Recording types for unit tests
    // ═══════════════════════════════════════════════════════════════════════

    private sealed class StubResponsesProvider : ResponsesProvider
    {
        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext isolation, CancellationToken ct = default) => Task.CompletedTask;
        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");
        public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext isolation, CancellationToken ct = default) => Task.CompletedTask;
        public override Task DeleteResponseAsync(string responseId, PlatformContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");
        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));
        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());
        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<string>());
    }

    private sealed class StubCancellationProvider : ResponsesCancellationSignalProvider
    {
        public override Task CancelResponseAsync(string responseId, CancellationToken ct = default) => Task.CompletedTask;
        public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken ct = default)
            => Task.FromResult(CancellationToken.None);
    }

    /// <summary>
    /// State-only recording provider with working in-memory storage.
    /// </summary>
    private sealed class RecordingStateProvider : ResponsesProvider
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext isolation, CancellationToken ct = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses.TryAdd(request.Response.Id, request.Response);
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext isolation, CancellationToken ct = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext isolation, CancellationToken ct = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, PlatformContext isolation, CancellationToken ct = default)
        {
            Calls.Add("DeleteResponseAsync");
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<string>());
    }

    /// <summary>
    /// Cancellation-only recording provider with working CTS backing.
    /// </summary>
    private sealed class RecordingCancelProvider : ResponsesCancellationSignalProvider
    {
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _ctsSources = new();
        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CancelResponseAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("CancelResponseAsync");
            if (_ctsSources.TryGetValue(responseId, out var cts))
            {
                try
                { cts.Cancel(); }
                catch (ObjectDisposedException) { }
            }
            return Task.CompletedTask;
        }

        public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("GetResponseCancellationTokenAsync");
            var cts = _ctsSources.GetOrAdd(responseId, _ => new CancellationTokenSource());
            return Task.FromResult(cts.Token);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> BlockingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        try
        {
            await Task.Delay(Timeout.Infinite, ct);
        }
        catch (OperationCanceledException)
        {
            // Expected
        }
        response.SetCancelled();
        yield return new ResponseIncompleteEvent(0, response);
    }
}
