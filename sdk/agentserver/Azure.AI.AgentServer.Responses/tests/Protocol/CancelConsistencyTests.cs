// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
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
/// Protocol tests for User Story 6 — Cancel Consistency.
/// Verifies FR-014 (SetCancelled applied exactly once) and
/// FR-015 (persisted state matches returned state on cancel).
/// </summary>
public class CancelConsistencyTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly RecordingProvider _spy;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public CancelConsistencyTests()
    {
        _spy = new RecordingProvider();
        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(_spy);
                services.AddSingleton<ResponsesCancellationSignalProvider>(_spy.AsCancellationProvider());
                services.AddSingleton<ResponsesStreamProvider>(_spy.AsStreamProvider());
            });
        _client = _factory.CreateClient();
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T055: Cancel bg response — persisted state = returned state
    // (0 output items, status: cancelled)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task CancelBgResponse_PersistedStateMatchesReturnedState()
    {
        // Handler that yields events slowly so we can cancel mid-stream
        var handlerStarted = new TaskCompletionSource();
        var cancelDone = new TaskCompletionSource();
        _handler.EventFactory = (req, ctx, ct) =>
            CancellableStream(ctx, handlerStarted, cancelDone, ct);

        // POST bg (non-streaming) response
        var json = JsonSerializer.Serialize(new { model = "test", background = true });
        var postResponse = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for handler to start and emit response.created
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        // Cancel the response
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Parse the cancel endpoint's return value
        using var cancelDoc = await JsonDocument.ParseAsync(
            await cancelResponse.Content.ReadAsStreamAsync());
        var returnedStatus = cancelDoc.RootElement.GetProperty("status").GetString();
        var returnedOutput = cancelDoc.RootElement.GetProperty("output");

        Assert.That(returnedStatus, Is.EqualTo("cancelled"));
        Assert.That(returnedOutput.GetArrayLength(), Is.EqualTo(0));

        // Signal handler to finish (it's already cancelled but let the task complete)
        cancelDone.TrySetResult();

        // Allow the handler task to fully complete
        await Task.Delay(200);

        // Verify the persisted state matches:
        // The last UpdateResponseAsync call should have cancelled state
        var updates = _spy.UpdateCalls.ToArray();
        Assert.That(updates, Is.Not.Empty);

        var lastUpdate = updates[^1];
        Assert.That(lastUpdate.Status?.ToString().ToLowerInvariant(), Is.EqualTo("cancelled"));
        Assert.That(lastUpdate.Output, Is.Empty);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T056: Cancel bg response — UpdateResponseAsync called with cancelled
    // state matching cancel endpoint return value
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task CancelBgResponse_UpdateResponseCalledWithCancelledState()
    {
        // Handler that yields events slowly so we can cancel mid-stream
        var handlerStarted = new TaskCompletionSource();
        var cancelDone = new TaskCompletionSource();
        _handler.EventFactory = (req, ctx, ct) =>
            CancellableStream(ctx, handlerStarted, cancelDone, ct);

        // POST bg+stream response (tests bg+stream path for cancel)
        var json = JsonSerializer.Serialize(
            new { model = "test", background = true, stream = true });
        var postTask = Task.Run(async () =>
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync("/responses", content);
        });

        // Wait for handler to start and emit response.created
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await Task.Delay(100); // Give bg task time to process response.created

        // Get the response ID from the spy provider (response.created triggers CreateResponseAsync)
        var createCalls = _spy.CreateCalls.ToArray();
        Assert.That(createCalls, Is.Not.Empty);
        var responseId = createCalls[0].Id;

        // Cancel the response
        var cancelResponse = await _client.PostAsync($"/responses/{responseId}/cancel", null);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var cancelDoc = await JsonDocument.ParseAsync(
            await cancelResponse.Content.ReadAsStreamAsync());
        var returnedStatus = cancelDoc.RootElement.GetProperty("status").GetString();
        Assert.That(returnedStatus, Is.EqualTo("cancelled"));

        // Signal handler to finish
        cancelDone.TrySetResult();

        // Wait for the SSE stream to complete
        try
        { await postTask.WaitAsync(TimeSpan.FromSeconds(5)); }
        catch { }

        // Allow time for finally block to run UpdateResponseAsync
        await Task.Delay(200);

        // Verify UpdateResponseAsync was called with cancelled state
        var updates = _spy.UpdateCalls.ToArray();
        Assert.That(updates, Is.Not.Empty);

        // The final state persisted should be cancelled
        var lastUpdate = updates[^1];
        Assert.That(lastUpdate.Status?.ToString().ToLowerInvariant(), Is.EqualTo("cancelled"));
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that yields response.created, signals started, waits for gate or cancellation.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> CancellableStream(
        ResponseContext ctx, TaskCompletionSource started, TaskCompletionSource gate,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        started.TrySetResult();

        // Wait for either cancellation or gate signal
        try
        {
            await gate.Task.WaitAsync(ct);
        }
        catch (OperationCanceledException)
        {
            // Cancelled — propagate to exit the enumerable
            throw;
        }

        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    /// <summary>
    /// Spy provider that records Create and Update calls with response snapshots.
    /// </summary>
    private sealed class RecordingProvider : ResponsesProvider
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _cts = new();

        public ConcurrentBag<Models.ResponseObject> CreateCalls { get; } = new();
        public ConcurrentBag<Models.ResponseObject> UpdateCalls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken ct = default)
        {
            // Snapshot the response at call time
            var snapshot = request.Response.Snapshot();
            CreateCalls.Add(snapshot);
            _responses[request.Response.Id] = request.Response;
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
        {
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken ct = default)
        {
            // Snapshot the response at call time
            var snapshot = response.Snapshot();
            UpdateCalls.Add(snapshot);
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
        {
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, IsolationContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, IsolationContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<string>());

        // --- Adapter factories for DI registration ---

        internal ResponsesCancellationSignalProvider AsCancellationProvider() => new CancellationAdapter(this);
        internal ResponsesStreamProvider AsStreamProvider() => new StreamAdapter(this);

        private sealed class CancellationAdapter(RecordingProvider provider) : ResponsesCancellationSignalProvider
        {
            public override Task CancelResponseAsync(string responseId, CancellationToken ct = default)
                => provider.CancelResponseAsync(responseId, ct);
            public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken ct = default)
                => provider.GetResponseCancellationTokenAsync(responseId, ct);
        }

        private sealed class StreamAdapter(RecordingProvider provider) : ResponsesStreamProvider
        {
            public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken ct = default)
                => provider.CreateEventPublisherAsync(responseId, ct);
            public override Task<IAsyncDisposable> SubscribeToEventsAsync(string responseId, IAsyncObserver<ResponseStreamEvent> observer, long? cursor = null, CancellationToken ct = default)
                => provider.SubscribeToEventsAsync(responseId, observer, cursor, ct);
        }

        public Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
            string responseId, CancellationToken ct = default)
        {
            var subject = _subjects.GetOrAdd(responseId,
                _ => new SeekableReplaySubject(TimeSpan.FromMinutes(10)));
            return Task.FromResult(subject.GetPublisher());
        }

        public async Task<IAsyncDisposable> SubscribeToEventsAsync(
            string responseId, IAsyncObserver<ResponseStreamEvent> observer,
            long? cursor = null, CancellationToken ct = default)
        {
            if (!_subjects.TryGetValue(responseId, out var subject))
                throw new InvalidOperationException($"No event stream for '{responseId}'.");
            var adapter = new UnwrappingObserver(observer);
            return await subject.SubscribeAsync(adapter, cursor);
        }

        public Task CancelResponseAsync(string responseId, CancellationToken ct = default)
        {
            if (_cts.TryGetValue(responseId, out var cts))
            {
                try
                { cts.Cancel(); }
                catch (ObjectDisposedException) { }
            }
            return Task.CompletedTask;
        }

        public Task<CancellationToken> GetResponseCancellationTokenAsync(
            string responseId, CancellationToken ct = default)
        {
            var cts = _cts.GetOrAdd(responseId, _ => new CancellationTokenSource());
            return Task.FromResult(cts.Token);
        }

        private sealed class UnwrappingObserver : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
        {
            private readonly IAsyncObserver<ResponseStreamEvent> _inner;
            public UnwrappingObserver(IAsyncObserver<ResponseStreamEvent> inner) => _inner = inner;
            public async ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value)
                => await _inner.OnNextAsync(value.Event);
            public ValueTask OnErrorAsync(Exception error) => _inner.OnErrorAsync(error);
            public ValueTask OnCompletedAsync() => _inner.OnCompletedAsync();
        }
    }
}
