// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Azure.AI.AgentServer.Responses.Tests.Provider;

/// <summary>
/// Unit tests for <see cref="InMemoryResponsesProvider"/> — the default
/// in-memory implementation of <see cref="ResponsesProvider"/>.
/// </summary>
public class InMemoryResponsesProviderTests : IDisposable
{
    private readonly InMemoryResponsesProvider _provider;

    public InMemoryResponsesProviderTests()
    {
        var options = Options.Create(new InMemoryProviderOptions());
        _provider = new InMemoryResponsesProvider(options, TimeProvider.System);
    }

    // ---------------------------------------------------------------
    // T016: State Operations
    // ---------------------------------------------------------------

    [Test]
    public async Task CreateResponseAsync_Stores_Response()
    {
        var response = new Models.ResponseObject("resp_abc", "gpt-4o") { Status = ResponseStatus.InProgress };

        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var retrieved = await _provider.GetResponseAsync("resp_abc", IsolationContext.Empty);
        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved!.Id, Is.EqualTo("resp_abc"));
    }

    [Test]
    public async Task GetResponseAsync_ThrowsResourceNotFound_ForUnknownId()
    {
        Assert.ThrowsAsync<ResourceNotFoundException>(
            () => _provider.GetResponseAsync("resp_nonexistent", IsolationContext.Empty));
    }

    [Test]
    public async Task UpdateResponseAsync_PersistsChanges()
    {
        var response = new Models.ResponseObject("resp_update", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        // Mutate and update
        response.Status = ResponseStatus.Completed;
        await _provider.UpdateResponseAsync(response, IsolationContext.Empty);

        var retrieved = await _provider.GetResponseAsync("resp_update", IsolationContext.Empty);
        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved.Status, Is.EqualTo(ResponseStatus.Completed));
    }

    [Test]
    public async Task CreateResponseAsync_DuplicateId_Throws()
    {
        var response1 = new Models.ResponseObject("resp_dup", "gpt-4o") { Status = ResponseStatus.InProgress };
        var response2 = new Models.ResponseObject("resp_dup", "gpt-4o") { Status = ResponseStatus.InProgress };

        await _provider.CreateResponseAsync(new CreateResponseRequest(response1, null, null), IsolationContext.Empty);
        Assert.ThrowsAsync<InvalidOperationException>(
            () => _provider.CreateResponseAsync(new CreateResponseRequest(response2, null, null), IsolationContext.Empty));
    }

    [Test]
    public async Task ConcurrentCreateAndGet_Works()
    {
        var tasks = Enumerable.Range(0, 50).Select(async i =>
        {
            var id = $"resp_{i}";
            var response = new Models.ResponseObject(id, "gpt-4o") { Status = ResponseStatus.InProgress };
            await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
            var retrieved = await _provider.GetResponseAsync(id, IsolationContext.Empty);
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved!.Id, Is.EqualTo(id));
        });

        await Task.WhenAll(tasks);
    }

    // ---------------------------------------------------------------
    // T017: Event Streaming
    // ---------------------------------------------------------------

    [Test]
    public async Task CreateEventPublisherAsync_ReturnsObserver()
    {
        var response = new Models.ResponseObject("resp_pub", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var publisher = await _provider.CreateEventPublisherAsync("resp_pub");

        Assert.That(publisher, Is.Not.Null);
    }

    private static ResponseOutputItemAddedEvent CreateItemAddedEvent(int index)
    {
        var msg = new OutputItemMessage(
            $"msg_{index}",
            MessageStatus.Completed,
            MessageRole.Assistant,
            Array.Empty<MessageContent>());
        return new ResponseOutputItemAddedEvent(0, index, msg);
    }

    [Test]
    public async Task EventStreaming_PublishAndSubscribe_ReceivesAllEvents()
    {
        var response = new Models.ResponseObject("resp_stream", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var publisher = await _provider.CreateEventPublisherAsync("resp_stream");

        // Publish 10 events
        for (int i = 0; i < 10; i++)
        {
            await publisher.OnNextAsync(CreateItemAddedEvent(i));
        }
        await publisher.OnCompletedAsync();

        // Subscribe and collect all
        var received = new List<ResponseStreamEvent>();
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(received, tcs);

        await using var sub = await _provider.SubscribeToEventsAsync("resp_stream", observer);
        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(received.Count, Is.EqualTo(10));
    }

    [Test]
    public async Task EventStreaming_CursorSubscription_SkipsEventsAtOrBeforeCursor()
    {
        var response = new Models.ResponseObject("resp_cursor", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var publisher = await _provider.CreateEventPublisherAsync("resp_cursor");

        // Publish 10 events (seq 0–9 will be auto-assigned)
        for (int i = 0; i < 10; i++)
        {
            await publisher.OnNextAsync(CreateItemAddedEvent(i));
        }
        await publisher.OnCompletedAsync();

        // Subscribe from cursor=4 — should receive events 5–9 (5 events)
        var received = new List<ResponseStreamEvent>();
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(received, tcs);

        await using var sub = await _provider.SubscribeToEventsAsync("resp_cursor", observer, cursor: 4);
        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.That(received.Count, Is.EqualTo(5));
    }

    [Test]
    public async Task EventStreaming_DisposeSubscription_StopsReceiving()
    {
        var response = new Models.ResponseObject("resp_dispose", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var publisher = await _provider.CreateEventPublisherAsync("resp_dispose");

        var received = new List<ResponseStreamEvent>();
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(received, tcs);

        var sub = await _provider.SubscribeToEventsAsync("resp_dispose", observer);

        // Push 3 events
        for (int i = 0; i < 3; i++)
        {
            await publisher.OnNextAsync(CreateItemAddedEvent(i));
        }

        // Dispose subscription
        await sub.DisposeAsync();

        // Push more events — should not be received
        for (int i = 3; i < 6; i++)
        {
            await publisher.OnNextAsync(CreateItemAddedEvent(i));
        }

        // Complete the subject to flush any pending events
        await publisher.OnCompletedAsync();
        await Task.Delay(50); // Brief wait for any stray async deliveries

        Assert.That(received.Count <= 3, Is.True, $"Expected at most 3 events after dispose, got {received.Count}");
    }

    // ---------------------------------------------------------------
    // T018: Cancellation
    // ---------------------------------------------------------------

    [Test]
    public async Task CancelResponseAsync_FiresCancellationToken()
    {
        var response = new Models.ResponseObject("resp_cancel", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        var ct = await _provider.GetResponseCancellationTokenAsync("resp_cancel");
        Assert.That(ct.IsCancellationRequested, Is.False);

        await _provider.CancelResponseAsync("resp_cancel");

        Assert.That(ct.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task CancelResponseAsync_IsFireAndForget()
    {
        var response = new Models.ResponseObject("resp_fandf", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        _ = await _provider.GetResponseCancellationTokenAsync("resp_fandf");

        // Should return immediately (fire-and-forget)
        var task = _provider.CancelResponseAsync("resp_fandf");
        await task; // Should not hang
    }

    [Test]
    public async Task CancelResponseAsync_IdempotentDoubleCancel()
    {
        var response = new Models.ResponseObject("resp_idem", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        _ = await _provider.GetResponseCancellationTokenAsync("resp_idem");

        // First cancel
        await _provider.CancelResponseAsync("resp_idem");

        // Second cancel — should not throw
        var exception = await Record.ExceptionAsync(() => _provider.CancelResponseAsync("resp_idem"));
        Assert.That(exception, Is.Null);
    }

    [Test]
    public async Task CancelResponseAsync_UnknownId_IsNoOp()
    {
        var exception = await Record.ExceptionAsync(
            () => _provider.CancelResponseAsync("resp_unknown"));
        Assert.That(exception, Is.Null);
    }

    [Test]
    public async Task GetResponseCancellationTokenAsync_CreatesIfAbsent()
    {
        var response = new Models.ResponseObject("resp_ct", "gpt-4o") { Status = ResponseStatus.InProgress };
        await _provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        // First call creates
        var ct1 = await _provider.GetResponseCancellationTokenAsync("resp_ct");
        // Second call returns same
        var ct2 = await _provider.GetResponseCancellationTokenAsync("resp_ct");

        Assert.That(ct2, Is.EqualTo(ct1));
        Assert.That(ct1.IsCancellationRequested, Is.False);
    }

    // ---------------------------------------------------------------
    // TTL Eviction (event streams only — responses retained indefinitely)
    // ---------------------------------------------------------------

    [Test]
    public async Task EvictsEventStream_AfterTtl()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(5) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new Models.ResponseObject("resp_evict", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        await provider.CreateEventPublisherAsync("resp_evict");
        await provider.GetResponseCancellationTokenAsync("resp_evict");

        // Move to terminal state
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Advance past event stream TTL
        timeProvider.Advance(TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(1)));

        // Models.ResponseObject is still retrievable (responses are never evicted)
        Assert.That(await provider.GetResponseAsync("resp_evict", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted — subscribing throws
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(new List<ResponseStreamEvent>(), tcs);
        Assert.ThrowsAsync<BadRequestException>(
            () => provider.SubscribeToEventsAsync("resp_evict", observer));
    }

    [Test]
    public async Task ResponseNotEvicted_AfterEventStreamTtl()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(1) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new Models.ResponseObject("resp_persist", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Advance well past event stream TTL
        timeProvider.Advance(TimeSpan.FromHours(1));

        // Models.ResponseObject still retrievable — responses are retained indefinitely
        Assert.That(await provider.GetResponseAsync("resp_persist", IsolationContext.Empty), Is.Not.Null);
    }

    [Test]
    public async Task DoesNotEvictEventStream_BeforeTtlElapses()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(10) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new Models.ResponseObject("resp_early", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        var publisher = await provider.CreateEventPublisherAsync("resp_early");
        await publisher.OnNextAsync(CreateItemAddedEvent(0));
        await publisher.OnCompletedAsync();

        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Advance only halfway through TTL
        timeProvider.Advance(TimeSpan.FromMinutes(5));

        // Event stream still available
        var received = new List<ResponseStreamEvent>();
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(received, tcs);
        await using var sub = await provider.SubscribeToEventsAsync("resp_early", observer);
        await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));
        XAssert.Single(received);
    }

    [Test]
    public async Task DoesNotEvict_InProgressResponse_EventStream()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(5) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new Models.ResponseObject("resp_progress", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);

        // Advance way past TTL — but response never reached terminal status
        timeProvider.Advance(TimeSpan.FromHours(1));

        // Still retrievable since it never reached terminal status
        Assert.That(await provider.GetResponseAsync("resp_progress", IsolationContext.Empty), Is.Not.Null);
    }

    [Test]
    public async Task EvictionCleansUpCancellationToken()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(1) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        var response = new Models.ResponseObject("resp_cleanup", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        await provider.CreateEventPublisherAsync("resp_cleanup");
        var ct = await provider.GetResponseCancellationTokenAsync("resp_cleanup");

        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        timeProvider.Advance(TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1)));

        // Models.ResponseObject still available (never evicted)
        Assert.That(await provider.GetResponseAsync("resp_cleanup", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(new List<ResponseStreamEvent>(), tcs);
        Assert.ThrowsAsync<BadRequestException>(
            () => provider.SubscribeToEventsAsync("resp_cleanup", observer));

        // CancellationTokenSource evicted — new call creates a fresh one
        var newCt = await provider.GetResponseCancellationTokenAsync("resp_cleanup");
        Assert.That(newCt, Is.Not.EqualTo(ct));
    }

    [Test]
    public async Task EvictsEventStream_NonBackgroundPath_CreateWithTerminalStatus()
    {
        var timeProvider = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromMinutes(5) });
        using var provider = new InMemoryResponsesProvider(options, timeProvider);

        // Non-background path: CreateResponseAsync is called with a terminal response
        // (no UpdateResponseAsync call)
        var response = new Models.ResponseObject("resp_nonbg", "gpt-4o") { Status = ResponseStatus.Completed };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        await provider.CreateEventPublisherAsync("resp_nonbg");
        await provider.GetResponseCancellationTokenAsync("resp_nonbg");

        // Advance past TTL
        timeProvider.Advance(TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(1)));

        // Models.ResponseObject still available
        Assert.That(await provider.GetResponseAsync("resp_nonbg", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(new List<ResponseStreamEvent>(), tcs);
        Assert.ThrowsAsync<BadRequestException>(
            () => provider.SubscribeToEventsAsync("resp_nonbg", observer));
    }

    // ---------------------------------------------------------------
    // Test Helpers
    // ---------------------------------------------------------------

    /// <summary>
    /// An IAsyncObserver that collects events and signals completion.
    /// </summary>
    private sealed class CollectingObserver : IAsyncObserver<ResponseStreamEvent>
    {
        private readonly List<ResponseStreamEvent> _received;
        private readonly TaskCompletionSource _tcs;

        public CollectingObserver(List<ResponseStreamEvent> received, TaskCompletionSource tcs)
        {
            _received = received;
            _tcs = tcs;
        }

        public ValueTask OnNextAsync(ResponseStreamEvent value)
        {
            _received.Add(value);
            return default;
        }

        public ValueTask OnErrorAsync(Exception error)
        {
            _tcs.TrySetException(error);
            return default;
        }

        public ValueTask OnCompletedAsync()
        {
            _tcs.TrySetResult();
            return default;
        }
    }

    public void Dispose()
    {
        (_provider as IDisposable)?.Dispose();
    }
}
