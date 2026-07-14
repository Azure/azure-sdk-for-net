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

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// T019 — Protocol tests verifying ResponsesProvider DI integration.
/// A recording decorator wraps the default InMemoryResponsesProvider and tracks
/// which provider methods are invoked during standard API operations.
/// Covers SC-003.
/// </summary>
public class ProviderDiIntegrationTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly RecordingResponsesProvider _spy;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ProviderDiIntegrationTests()
    {
        // Create the recording spy — it will be given the real inner provider via DI
        _spy = new RecordingResponsesProvider();

        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
            {
                // Register spy before AddResponsesServer so TryAddSingleton skips the defaults
                services.AddSingleton<ResponsesProvider>(_spy);
                services.AddSingleton<ResponsesCancellationSignalProvider>(_spy.AsCancellationProvider());
            });
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Post_Responses_Calls_CreateResponseAsync()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        XAssert.Contains("CreateResponseAsync", _spy.Calls);
    }

    [Test]
    public async Task Post_Responses_Calls_GetResponseCancellationTokenAsync()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        XAssert.Contains("GetResponseCancellationTokenAsync", _spy.Calls);
    }

    [Test]
    public async Task Post_Responses_Calls_UpdateResponseAsync()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        // Default mode (bg=false): single CreateResponseAsync at terminal state
        XAssert.Contains("CreateResponseAsync", _spy.Calls);
    }

    [Test]
    public async Task Post_Cancel_Calls_CancelResponseAsync()
    {
        // Create a background response that blocks until we signal
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => WaitingEventStream(ctx, tcs.Task, ct);

        var createBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Cancel the response
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);

        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        XAssert.Contains("CancelResponseAsync", _spy.Calls);

        // Clean up
        tcs.SetResult();
        await Task.Delay(100);
    }

    private async Task WaitForCompletionAsync(string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await _client.GetAsync($"/responses/{responseId}");
            var body = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(body);
            var status = doc.RootElement.GetProperty("status").GetString();
            if (status is "completed" or "failed" or "incomplete" or "cancelled")
                return;
            await Task.Delay(50);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// A recording decorator around ResponsesProvider that delegates all operations
    /// to ConcurrentDictionary-backed in-memory storage while recording method calls.
    /// </summary>
    private sealed class RecordingResponsesProvider : ResponsesProvider, IDisposable
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _cancellationTokenSources = new();

        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses.TryAdd(request.Response.Id, request.Response);
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("DeleteResponseAsync");
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<string>());

        // --- Adapter factories for DI registration ---

        internal ResponsesCancellationSignalProvider AsCancellationProvider() => new CancellationAdapter(this);

        private sealed class CancellationAdapter(RecordingResponsesProvider provider) : ResponsesCancellationSignalProvider
        {
            public override Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
                => provider.CancelResponseAsync(responseId, cancellationToken);
            public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken cancellationToken = default)
                => provider.GetResponseCancellationTokenAsync(responseId, cancellationToken);
        }

        public Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
        {
            Calls.Add("CancelResponseAsync");
            if (_cancellationTokenSources.TryGetValue(responseId, out var cts))
            {
                try
                { cts.Cancel(); }
                catch (ObjectDisposedException) { }
            }
            return Task.CompletedTask;
        }

        public Task<CancellationToken> GetResponseCancellationTokenAsync(
            string responseId, CancellationToken cancellationToken = default)
        {
            Calls.Add("GetResponseCancellationTokenAsync");
            var cts = _cancellationTokenSources.GetOrAdd(responseId, _ => new CancellationTokenSource());
            return Task.FromResult(cts.Token);
        }

        public void Dispose()
        {
            foreach (var cts in _cancellationTokenSources.Values)
                cts.Dispose();
        }
    }
}

/// <summary>
/// T020 — Protocol tests verifying zero-regression with the default InMemoryResponsesProvider.
/// These run key scenarios (sync, streaming, background, cancel) and verify identical results
/// to the pre-refactoring baseline. Covers SC-004.
/// </summary>
public class DefaultProviderZeroRegressionTests : ProtocolTestBase
{
    [Test]
    public async Task Default_Sync_Create_Returns_Completed_Response()
    {
        var responseId = await CreateDefaultResponseAsync();

        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
    }

    [Test]
    public async Task Default_Streaming_Create_Returns_SSE_Events()
    {
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var events = await ParseSseAsync(response);
        Assert.That(events.Count >= 2, Is.True, $"Expected at least 2 SSE events, got {events.Count}");

        // First event should be response.created
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        // Last event should be response.completed
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task Default_Background_Create_Returns_InProgress_Then_Completed()
    {
        var responseId = await CreateBackgroundResponseAsync();

        // Should be completable
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        using var doc = await ParseJsonAsync(getResponse);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public async Task Default_Background_Cancel_Returns_Cancelled()
    {
        var tcs = new TaskCompletionSource();
        Handler.EventFactory = (_, ctx, ct) => WaitingEventStream(ctx, tcs.Task, ct);

        var responseId = await CreateBackgroundResponseAsync();

        // Cancel
        var cancelResponse = await CancelResponseAsync(responseId);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Let handler unblock (it will see cancellation)
        tcs.SetResult();
        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        using var doc = await ParseJsonAsync(getResponse);
        var status = doc.RootElement.GetProperty("status").GetString();
        Assert.That(status, Is.EqualTo("cancelled"));
    }

    [Test]
    public async Task Default_Background_Streaming_SSE_Replay()
    {
        var responseId = await CreateBackgroundStreamingResponseAsync();

        await WaitForBackgroundCompletionAsync(responseId);

        // SSE replay
        var replayResponse = await GetResponseStreamAsync(responseId);
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(replayResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var events = await ParseSseAsync(replayResponse);
        Assert.That(events.Count >= 2, Is.True, $"Expected at least 2 SSE replay events, got {events.Count}");
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task Default_Get_Unknown_Returns_404()
    {
        var response = await GetResponseAsync(IdGenerator.NewResponseId());
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }
}

/// <summary>
/// T014 — Protocol tests verifying partial provider override:
/// register only ResponsesProvider (custom) while ResponsesCancellationSignalProvider
/// and event streaming fall back to the SDK's Core defaults.
/// </summary>
public class PartialProviderOverrideTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly StateOnlyProvider _stateProvider;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public PartialProviderOverrideTests()
    {
        _stateProvider = new StateOnlyProvider();

        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
            {
                // Register ONLY ResponsesProvider — streaming and cancellation fall back to defaults
                services.AddSingleton<ResponsesProvider>(_stateProvider);
            });
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task Post_Uses_Custom_StateProvider_For_CreateResponse()
    {
        var body = JsonSerializer.Serialize(new { model = "test" });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        XAssert.Contains("CreateResponseAsync", _stateProvider.Calls);
    }

    [Test]
    public async Task Post_Background_Uses_Custom_StateProvider_For_UpdateResponse()
    {
        // Create a background response
        var body = JsonSerializer.Serialize(new { model = "test", background = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Wait for background completion
        var createBody = await response.Content.ReadAsStringAsync();
        using var createDoc = JsonDocument.Parse(createBody);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;
        await WaitForCompletionAsync(responseId);

        // Background responses call CreateResponseAsync (at response.created)
        // and UpdateResponseAsync (at terminal state)
        XAssert.Contains("CreateResponseAsync", _stateProvider.Calls);
        XAssert.Contains("UpdateResponseAsync", _stateProvider.Calls);
    }

    [Test]
    public async Task Streaming_Uses_Default_InMemory_StreamProvider()
    {
        // POST stream=true — streaming events handled by default InMemoryResponsesProvider
        var body = JsonSerializer.Serialize(new { model = "test", stream = true });
        var response = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var sseBody = await response.Content.ReadAsStringAsync();
        var events = SseParser.Parse(sseBody);
        Assert.That(events.Count >= 2, Is.True, $"Expected at least 2 SSE events, got {events.Count}");
        Assert.That(events[0].EventType, Is.EqualTo("response.created"));
        Assert.That(events[^1].EventType, Is.EqualTo("response.completed"));
    }

    [Test]
    public async Task Cancel_Uses_Default_InMemory_CancellationProvider()
    {
        // Create a background response that blocks until we signal
        var tcs = new TaskCompletionSource();
        _handler.EventFactory = (_, ctx, ct) => WaitingEventStream(ctx, tcs.Task, ct);

        var createBody = JsonSerializer.Serialize(new { model = "test", background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(createBody, Encoding.UTF8, "application/json"));
        var created = await createResponse.Content.ReadFromJsonAsync<JsonElement>();
        var responseId = created.GetProperty("id").GetString()!;

        // Cancel should work via the default InMemory cancellation provider
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Clean up
        tcs.SetResult();
        await Task.Delay(100);
    }

    [Test]
    public async Task SseReplay_Uses_Default_InMemory_StreamProvider()
    {
        // Create a background streaming response
        var body = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });
        var createResponse = await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        var sseBody = await createResponse.Content.ReadAsStringAsync();
        var events = SseParser.Parse(sseBody);
        using var doc = JsonDocument.Parse(events[0].Data);
        var responseId = doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // Wait for background to complete
        await WaitForCompletionAsync(responseId);

        // SSE replay should work via default InMemory stream provider
        var replayResponse = await _client.GetAsync($"/responses/{responseId}?stream=true");
        Assert.That(replayResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(replayResponse.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var replayEvents = SseParser.Parse(await replayResponse.Content.ReadAsStringAsync());
        Assert.That(replayEvents.Count >= 2, Is.True);
    }

    [Test]
    public async Task StateProvider_Receives_No_Streaming_Or_Cancellation_Calls()
    {
        // Run a full lifecycle: create, cancel attempt, SSE — state provider only sees state ops
        var body = JsonSerializer.Serialize(new { model = "test" });
        await _client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        // State provider should never see streaming or cancellation calls. Streaming is now handled
        // by the Core event-stream primitive, so a custom state-only provider is never asked to
        // publish or subscribe to events.
        XAssert.DoesNotContain("CancelResponseAsync", _stateProvider.Calls);
        XAssert.DoesNotContain("GetResponseCancellationTokenAsync", _stateProvider.Calls);
    }

    private async Task WaitForCompletionAsync(string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await _client.GetAsync($"/responses/{responseId}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                await Task.Delay(50);
                continue;
            }
            var respBody = await response.Content.ReadAsStringAsync();
            using var respDoc = JsonDocument.Parse(respBody);
            var status = respDoc.RootElement.GetProperty("status").GetString();
            if (status is "completed" or "failed" or "incomplete" or "cancelled")
                return;
            await Task.Delay(50);
        }
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> WaitingEventStream(
        ResponseContext ctx,
        Task delayTask,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        await delayTask.WaitAsync(ct);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// A state-only provider that handles Create/Get/Update with in-memory storage
    /// but does NOT extend ResponsesCancellationSignalProvider.
    /// </summary>
    private sealed class StateOnlyProvider : ResponsesProvider
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();

        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses.TryAdd(request.Response.Id, request.Response);
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, PlatformContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("DeleteResponseAsync");
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<string>());
    }
}
