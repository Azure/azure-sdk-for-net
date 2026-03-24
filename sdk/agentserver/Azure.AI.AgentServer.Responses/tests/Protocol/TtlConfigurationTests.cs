// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for User Story 4 — In-Memory Provider TTL Configuration.
/// Verifies FR-016 (default 10-minute TTL), FR-017 (custom response TTL),
/// FR-018 (separate event stream TTL), FR-019 (custom provider ignores InMemoryProviderOptions).
/// </summary>
public class TtlConfigurationTests : IDisposable
{
    private readonly TestHandler _handler = new();

    // ═══════════════════════════════════════════════════════════════════════
    // T045: Default TTL — response retained indefinitely, event stream evicted
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task DefaultTtl_ResponseRetainedIndefinitely_EventStreamEvictedAfter10Minutes()
    {
        // Arrange: create provider with default options and FakeTimeProvider
        var fakeTime = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions());
        using var provider = new InMemoryResponsesProvider(options, fakeTime);

        // Verify default
        Assert.AreEqual(TimeSpan.FromMinutes(10), options.Value.EventStreamTtl);

        // Create and complete a response with an event stream
        var response = new Models.Response("resp_default_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(response, null, null);
        var publisher = await provider.CreateEventPublisherAsync("resp_default_ttl");
        await publisher.OnNextAsync(ResponsesModelFactory.ResponseCreatedEvent(response));
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response);

        // Still retrievable before TTL
        Assert.IsNotNull(await provider.GetResponseAsync("resp_default_ttl"));

        // Advance to 9 minutes — still available
        fakeTime.Advance(TimeSpan.FromMinutes(9));
        Assert.IsNotNull(await provider.GetResponseAsync("resp_default_ttl"));

        // Advance past 10 minutes — response still available, event stream evicted
        fakeTime.Advance(TimeSpan.FromMinutes(2));
        Assert.IsNotNull(await provider.GetResponseAsync("resp_default_ttl"));

        // Event stream evicted
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            var observer = new CollectingObserver(new List<ResponseStreamEvent>(), new TaskCompletionSource());
            await provider.SubscribeToEventsAsync("resp_default_ttl", observer);
        });
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T046: Custom event stream TTL of 1 second — event stream evicted,
    //       response retained
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task CustomEventStreamTtl_EventStreamEvictedAfter1Second_ResponseRetained()
    {
        // Arrange: 1-second event stream TTL
        var fakeTime = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions { EventStreamTtl = TimeSpan.FromSeconds(1) });
        using var provider = new InMemoryResponsesProvider(options, fakeTime);

        // Create and complete a response with event stream
        var response = new Models.Response("resp_1s_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(response, null, null);
        var publisher = await provider.CreateEventPublisherAsync("resp_1s_ttl");
        await publisher.OnNextAsync(ResponsesModelFactory.ResponseCreatedEvent(response));
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response);

        // Still retrievable immediately
        Assert.IsNotNull(await provider.GetResponseAsync("resp_1s_ttl"));

        // Advance past 1 second — event stream evicted, response retained
        fakeTime.Advance(TimeSpan.FromSeconds(2));
        Assert.IsNotNull(await provider.GetResponseAsync("resp_1s_ttl"));

        // Event stream evicted
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            var observer = new CollectingObserver(new List<ResponseStreamEvent>(), new TaskCompletionSource());
            await provider.SubscribeToEventsAsync("resp_1s_ttl", observer);
        });
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T047: Event stream evicted after TTL — response retained indefinitely
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task EventStreamEvicted_ResponseRetainedIndefinitely()
    {
        // Arrange: event stream TTL = 1 min
        var fakeTime = new FakeTimeProvider();
        var options = Options.Create(new InMemoryProviderOptions
        {
            EventStreamTtl = TimeSpan.FromMinutes(1)
        });
        using var provider = new InMemoryResponsesProvider(options, fakeTime);

        // Create response with event stream
        var response = new Models.Response("resp_split_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(response, null, null);
        var publisher = await provider.CreateEventPublisherAsync("resp_split_ttl");

        // Publish an event and complete
        var evt = ResponsesModelFactory.ResponseCreatedEvent(response);
        await publisher.OnNextAsync(evt);
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response);

        // Before any eviction: both response and event stream available
        Assert.IsNotNull(await provider.GetResponseAsync("resp_split_ttl"));
        var events = new List<ResponseStreamEvent>();
        var tcs = new TaskCompletionSource();
        var observer = new CollectingObserver(events, tcs);
        await using (await provider.SubscribeToEventsAsync("resp_split_ttl", observer))
        {
            await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));
        }
        XAssert.Single(events);

        // Advance past event stream TTL
        fakeTime.Advance(TimeSpan.FromMinutes(1).Add(TimeSpan.FromSeconds(1)));

        // Models.Response still retrievable (retained indefinitely)
        Assert.IsNotNull(await provider.GetResponseAsync("resp_split_ttl"));

        // Event stream evicted — subscribing throws
        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            var observer2 = new CollectingObserver(new List<ResponseStreamEvent>(), new TaskCompletionSource());
            await provider.SubscribeToEventsAsync("resp_split_ttl", observer2);
        });

        // Even after a very long time, response is still available
        fakeTime.Advance(TimeSpan.FromHours(24));
        Assert.IsNotNull(await provider.GetResponseAsync("resp_split_ttl"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T048: Custom IResponsesProvider — InMemoryProviderOptions has no effect
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task CustomProvider_InMemoryProviderOptionsIgnored()
    {
        // Arrange: register a spy provider and configure a very short TTL
        // The spy should be used regardless of InMemoryProviderOptions
        var spy = new NoEvictionProvider();
        using var factory = new TestWebApplicationFactory(
            _handler,
            configureOptions: opts => { },
            configureTestServices: services =>
            {
                services.AddSingleton<IResponsesProvider>(spy);
                services.AddSingleton<IResponsesCancellationSignalProvider>(spy);
                services.AddSingleton<IResponsesStreamProvider>(spy);
                services.Configure<InMemoryProviderOptions>(opts =>
                {
                    opts.EventStreamTtl = TimeSpan.FromMilliseconds(1);
                });
            });
        var client = factory.CreateClient();

        // Create a background response (so it's persisted)
        _handler.EventFactory = (req, ctx, ct) => CompletingStream(ctx);
        var json = JsonSerializer.Serialize(new { model = "test", background = true });
        var postResponse = await client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, postResponse.StatusCode);

        using var doc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        // Wait for handler to complete
        await WaitForBackgroundCompletion(client, responseId);

        // Verify spy was used (custom provider)
        Assert.IsTrue(spy.Calls.Count > 0, "Custom provider should have been called");
        XAssert.Contains("CreateResponseAsync", spy.Calls.ToArray());

        // Wait much longer than the InMemoryProviderOptions TTL
        await Task.Delay(100);

        // Models.Response still available via GET (custom provider never evicts)
        var getResponse = await client.GetAsync($"/responses/{responseId}");
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    private static async IAsyncEnumerable<ResponseStreamEvent> CompletingStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.Response(ctx.ResponseId, "test");
        yield return new ResponseCreatedEvent(0, response);
        yield return new ResponseOutputItemDoneEvent();
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async Task WaitForBackgroundCompletion(
        HttpClient client, string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await client.GetAsync($"/responses/{responseId}");
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

    /// <summary>
    /// Observer that collects events and signals completion.
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
            return ValueTask.CompletedTask;
        }

        public ValueTask OnErrorAsync(Exception error)
        {
            _tcs.TrySetException(error);
            return ValueTask.CompletedTask;
        }

        public ValueTask OnCompletedAsync()
        {
            _tcs.TrySetResult();
            return ValueTask.CompletedTask;
        }
    }

    /// <summary>
    /// A custom IResponsesProvider that never evicts — proves InMemoryProviderOptions has no effect.
    /// </summary>
    private sealed class NoEvictionProvider : IResponsesProvider, IResponsesCancellationSignalProvider, IResponsesStreamProvider
    {
        private readonly ConcurrentDictionary<string, Models.Response> _responses = new();
        private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _cts = new();
        public ConcurrentBag<string> Calls { get; } = new();

        public Task CreateResponseAsync(Models.Response response, IEnumerable<OutputItem>? inputItems, IEnumerable<string>? historyItemIds, CancellationToken ct = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public Task<Models.Response> GetResponseAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public Task UpdateResponseAsync(Models.Response response, CancellationToken ct = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public Task DeleteResponseAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("DeleteResponseAsync");
            if (!_responses.TryRemove(responseId, out _))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            return Task.CompletedTask;
        }

        public Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));

        public Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());

        public Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<string>());

        public Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
            string responseId, CancellationToken ct = default)
        {
            Calls.Add("CreateEventPublisherAsync");
            var subject = _subjects.GetOrAdd(responseId, _ => new SeekableReplaySubject(TimeSpan.FromHours(1)));
            return Task.FromResult(subject.GetPublisher());
        }

        public async Task<IAsyncDisposable> SubscribeToEventsAsync(
            string responseId, IAsyncObserver<ResponseStreamEvent> observer,
            long? cursor = null, CancellationToken ct = default)
        {
            Calls.Add("SubscribeToEventsAsync");
            if (!_subjects.TryGetValue(responseId, out var subject))
                throw new InvalidOperationException($"No event stream for '{responseId}'.");
            var adapter = new UnwrappingObserver(observer);
            return await subject.SubscribeAsync(adapter, cursor);
        }

        public Task CancelResponseAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("CancelResponseAsync");
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
            Calls.Add("GetResponseCancellationTokenAsync");
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
