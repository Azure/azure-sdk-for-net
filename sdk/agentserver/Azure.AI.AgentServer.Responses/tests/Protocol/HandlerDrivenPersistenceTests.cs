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
/// Protocol tests for User Story 1 — Handler-Driven Persistence.
/// Verifies S-035/B36 (no persistence before handler runs),
/// S-035 (bg=true: Create at response.created, Update at terminal),
/// S-035 (bg=false: single Create at terminal state).
/// </summary>
public class HandlerDrivenPersistenceTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly RecordingProvider _spy;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public HandlerDrivenPersistenceTests()
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
    // T015: Handler delays response.created — provider CreateResponseAsync
    // is NOT called during delay (bg=true, stream=true)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgStream_ProviderCreateNotCalledUntilResponseCreated()
    {
        // Handler delays response.created behind a gate
        var handlerGate = new TaskCompletionSource();
        var handlerStarted = new TaskCompletionSource();
        _handler.EventFactory = (req, ctx, ct) =>
            DelayingStream(ctx, handlerGate.Task, handlerStarted, ct);

        // POST bg+stream — starts SSE connection (non-blocking in Task)
        var postTask = Task.Run(async () =>
        {
            var json = JsonSerializer.Serialize(
                new { model = "test", background = true, stream = true });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync("/responses", content);
        });

        // Wait for the handler to start (but NOT yield response.created)
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await Task.Delay(100); // Give bg task time to process

        // Provider should NOT have CreateResponseAsync called yet
        XAssert.DoesNotContain("CreateResponseAsync", _spy.Calls.ToArray());

        // Release handler gate → response.created will be yielded
        handlerGate.SetResult();

        // Wait for POST to complete
        var postResponse = await postTask.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Provider should now have CreateResponseAsync called
        XAssert.Contains("CreateResponseAsync", _spy.Calls.ToArray());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T016: Handler delays response.created — provider CreateResponseAsync
    // is NOT called during delay (bg=true, stream=false)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgNoStream_ProviderCreateNotCalledUntilResponseCreated()
    {
        // Handler delays response.created behind a gate
        var handlerGate = new TaskCompletionSource();
        var handlerStarted = new TaskCompletionSource();
        _handler.EventFactory = (req, ctx, ct) =>
            DelayingStream(ctx, handlerGate.Task, handlerStarted, ct);

        // POST bg+nostream — now waits for response.created before returning,
        // so wrap in Task.Run (same pattern as T015 streaming version).
        var postTask = Task.Run(async () =>
        {
            var json = JsonSerializer.Serialize(
                new { model = "test", background = true });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync("/responses", content);
        });

        // Wait for handler to start (but NOT yield response.created)
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await Task.Delay(100); // Give bg task time to process

        // Provider should NOT have CreateResponseAsync called yet
        XAssert.DoesNotContain("CreateResponseAsync", _spy.Calls.ToArray());

        // Release handler gate → response.created will be yielded
        handlerGate.SetResult();

        // Wait for POST to complete
        var postResponse = await postTask.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var createDoc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for bg task to complete
        await WaitForBackgroundCompletionAsync(responseId);

        // Provider should now have CreateResponseAsync called
        XAssert.Contains("CreateResponseAsync", _spy.Calls.ToArray());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T017: bg=true — handler yields response.created then completes →
    // provider has exactly 1 Create and 1 Update
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BgMode_ProviderHasOneCreateAndOneUpdate()
    {
        // Default handler: response.created → response.completed

        // POST bg+nostream
        var json = JsonSerializer.Serialize(
            new { model = "test", background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = await _client.PostAsync("/responses", content);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var createDoc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for bg task to complete
        await WaitForBackgroundCompletionAsync(responseId);

        // Provider should have exactly 1 Create and 1 Update
        var calls = _spy.Calls.ToArray();
        Assert.That(calls.Count(c => c == "CreateResponseAsync"), Is.EqualTo(1));
        Assert.That(calls.Count(c => c == "UpdateResponseAsync"), Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T018: bg=false — handler yields response.created then completes →
    // provider has single Create at terminal (no Update)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonBg_ProviderHasSingleCreateAtTerminal()
    {
        // Default handler: response.created → response.completed

        // POST non-bg
        var json = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = await _client.PostAsync("/responses", content);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Verify response is completed
        using var doc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));

        // Provider should have exactly 1 Create and 0 Updates
        var calls = _spy.Calls.ToArray();
        Assert.That(calls.Count(c => c == "CreateResponseAsync"), Is.EqualTo(1));
        Assert.That(calls.Count(c => c == "UpdateResponseAsync"), Is.EqualTo(0));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Handler that signals when started, then waits for a gate before yielding response.created.
    /// </summary>
    private static async IAsyncEnumerable<ResponseStreamEvent> DelayingStream(
        ResponseContext ctx, Task gate, TaskCompletionSource started,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        started.TrySetResult();
        await gate.WaitAsync(ct);
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    /// <summary>
    /// Polls GET until the response reaches a terminal status or timeout.
    /// Handles 404 responses gracefully.
    /// </summary>
    private async Task WaitForBackgroundCompletionAsync(string responseId, TimeSpan? timeout = null)
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
            using var doc = await JsonDocument.ParseAsync(
                await response.Content.ReadAsStreamAsync());
            if (doc.RootElement.TryGetProperty("status", out var statusProp))
            {
                var status = statusProp.GetString();
                if (status is "completed" or "failed" or "incomplete" or "cancelled")
                    return;
            }
            await Task.Delay(50);
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        _spy.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Recording Provider — spy that tracks method calls
    // ═══════════════════════════════════════════════════════════════════════

    private sealed class RecordingProvider : ResponsesProvider, IDisposable
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _ctsSources = new();
        private readonly TimeSpan _ttl = TimeSpan.FromMinutes(30);

        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses.TryAdd(request.Response.Id, request.Response);
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            Calls.Add("DeleteResponseAsync");
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, IsolationContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, IsolationContext isolation, CancellationToken cancellationToken = default)
            => Task.FromResult(Enumerable.Empty<string>());

        // --- Adapter factories for DI registration ---

        internal ResponsesCancellationSignalProvider AsCancellationProvider() => new CancellationAdapter(this);
        internal ResponsesStreamProvider AsStreamProvider() => new StreamAdapter(this);

        private sealed class CancellationAdapter(RecordingProvider provider) : ResponsesCancellationSignalProvider
        {
            public override Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
                => provider.CancelResponseAsync(responseId, cancellationToken);
            public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken cancellationToken = default)
                => provider.GetResponseCancellationTokenAsync(responseId, cancellationToken);
        }

        private sealed class StreamAdapter(RecordingProvider provider) : ResponsesStreamProvider
        {
            public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken cancellationToken = default)
                => provider.CreateEventPublisherAsync(responseId, cancellationToken);
            public override Task<IAsyncDisposable> SubscribeToEventsAsync(string responseId, IAsyncObserver<ResponseStreamEvent> observer, long? cursor = null, CancellationToken cancellationToken = default)
                => provider.SubscribeToEventsAsync(responseId, observer, cursor, cancellationToken);
        }

        public Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
            string responseId, CancellationToken cancellationToken = default)
        {
            Calls.Add("CreateEventPublisherAsync");
            var subject = _subjects.GetOrAdd(responseId, _ => new SeekableReplaySubject(_ttl));
            return Task.FromResult(subject.GetPublisher());
        }

        public async Task<IAsyncDisposable> SubscribeToEventsAsync(
            string responseId,
            IAsyncObserver<ResponseStreamEvent> observer,
            long? cursor = null,
            CancellationToken cancellationToken = default)
        {
            Calls.Add("SubscribeToEventsAsync");
            if (!_subjects.TryGetValue(responseId, out var subject))
                throw new InvalidOperationException($"No event stream for '{responseId}'.");
            var unwrapping = new UnwrappingObserver(observer);
            return await subject.SubscribeAsync(unwrapping, cursor);
        }

        public Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
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

        public Task<CancellationToken> GetResponseCancellationTokenAsync(
            string responseId, CancellationToken cancellationToken = default)
        {
            Calls.Add("GetResponseCancellationTokenAsync");
            var cts = _ctsSources.GetOrAdd(responseId, _ => new CancellationTokenSource());
            return Task.FromResult(cts.Token);
        }

        public void Dispose()
        {
            foreach (var subject in _subjects.Values)
                subject.Dispose();
            foreach (var cts in _ctsSources.Values)
                cts.Dispose();
        }

        private sealed class UnwrappingObserver(IAsyncObserver<ResponseStreamEvent> inner)
            : IAsyncObserver<(long SequenceNumber, ResponseStreamEvent Event)>
        {
            public ValueTask OnNextAsync((long SequenceNumber, ResponseStreamEvent Event) value)
                => inner.OnNextAsync(value.Event);
            public ValueTask OnErrorAsync(Exception error)
                => inner.OnErrorAsync(error);
            public ValueTask OnCompletedAsync()
                => inner.OnCompletedAsync();
        }
    }
}
