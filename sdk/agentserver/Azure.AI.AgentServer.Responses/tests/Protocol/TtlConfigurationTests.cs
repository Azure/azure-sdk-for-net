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
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Time.Testing;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for User Story 4 — In-Memory Provider TTL Configuration.
/// Verifies S-038/B35 (default 10-minute TTL), S-038 (custom response TTL),
/// S-038/B35 (separate event stream TTL), and custom provider isolation.
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
        Assert.That(options.Value.EventStreamTtl, Is.EqualTo(TimeSpan.FromMinutes(10)));

        // Create and complete a response with an event stream
        var response = new Models.ResponseObject("resp_default_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        var publisher = await provider.CreateEventPublisherAsync("resp_default_ttl");
        await publisher.OnNextAsync(ResponsesModelFactory.ResponseCreatedEvent(response));
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Still retrievable before TTL
        Assert.That(await provider.GetResponseAsync("resp_default_ttl", IsolationContext.Empty), Is.Not.Null);

        // Advance to 9 minutes — still available
        fakeTime.Advance(TimeSpan.FromMinutes(9));
        Assert.That(await provider.GetResponseAsync("resp_default_ttl", IsolationContext.Empty), Is.Not.Null);

        // Advance past 10 minutes — response still available, event stream evicted
        fakeTime.Advance(TimeSpan.FromMinutes(2));
        Assert.That(await provider.GetResponseAsync("resp_default_ttl", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted
        Assert.ThrowsAsync<BadRequestException>(async () =>
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
        var response = new Models.ResponseObject("resp_1s_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        var publisher = await provider.CreateEventPublisherAsync("resp_1s_ttl");
        await publisher.OnNextAsync(ResponsesModelFactory.ResponseCreatedEvent(response));
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Still retrievable immediately
        Assert.That(await provider.GetResponseAsync("resp_1s_ttl", IsolationContext.Empty), Is.Not.Null);

        // Advance past 1 second — event stream evicted, response retained
        fakeTime.Advance(TimeSpan.FromSeconds(2));
        Assert.That(await provider.GetResponseAsync("resp_1s_ttl", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted
        Assert.ThrowsAsync<BadRequestException>(async () =>
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
        var response = new Models.ResponseObject("resp_split_ttl", "gpt-4o") { Status = ResponseStatus.InProgress };
        await provider.CreateResponseAsync(new CreateResponseRequest(response, null, null), IsolationContext.Empty);
        var publisher = await provider.CreateEventPublisherAsync("resp_split_ttl");

        // Publish an event and complete
        var evt = ResponsesModelFactory.ResponseCreatedEvent(response);
        await publisher.OnNextAsync(evt);
        await publisher.OnCompletedAsync();
        response.Status = ResponseStatus.Completed;
        await provider.UpdateResponseAsync(response, IsolationContext.Empty);

        // Before any eviction: both response and event stream available
        Assert.That(await provider.GetResponseAsync("resp_split_ttl", IsolationContext.Empty), Is.Not.Null);
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

        // Models.ResponseObject still retrievable (retained indefinitely)
        Assert.That(await provider.GetResponseAsync("resp_split_ttl", IsolationContext.Empty), Is.Not.Null);

        // Event stream evicted — subscribing throws
        Assert.ThrowsAsync<BadRequestException>(async () =>
        {
            var observer2 = new CollectingObserver(new List<ResponseStreamEvent>(), new TaskCompletionSource());
            await provider.SubscribeToEventsAsync("resp_split_ttl", observer2);
        });

        // Even after a very long time, response is still available
        fakeTime.Advance(TimeSpan.FromHours(24));
        Assert.That(await provider.GetResponseAsync("resp_split_ttl", IsolationContext.Empty), Is.Not.Null);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T048: Custom ResponsesProvider — InMemoryProviderOptions has no effect
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
                services.AddSingleton<ResponsesProvider>(spy);
                services.AddSingleton<ResponsesCancellationSignalProvider>(spy.AsCancellationProvider());
                services.AddSingleton<ResponsesStreamProvider>(spy.AsStreamProvider());
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
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await JsonDocument.ParseAsync(
            await postResponse.Content.ReadAsStreamAsync());
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        // Wait for handler to complete
        await WaitForBackgroundCompletion(client, responseId);

        // Verify spy was used (custom provider)
        Assert.That(spy.Calls.Count > 0, Is.True, "Custom provider should have been called");
        XAssert.Contains("CreateResponseAsync", spy.Calls.ToArray());

        // Wait much longer than the InMemoryProviderOptions TTL
        await Task.Delay(100);

        // Models.ResponseObject still available via GET (custom provider never evicts)
        var getResponse = await client.GetAsync($"/responses/{responseId}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    private static async IAsyncEnumerable<ResponseStreamEvent> CompletingStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test");
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
    /// A custom ResponsesProvider that never evicts — proves InMemoryProviderOptions has no effect.
    /// </summary>
    private sealed class NoEvictionProvider : ResponsesProvider
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
        private readonly ConcurrentDictionary<string, CancellationTokenSource> _cts = new();
        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses[request.Response.Id] = request.Response;
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
            {
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
            }
            return Task.FromResult(response);
        }

        public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("UpdateResponseAsync");
            _responses[response.Id] = response;
            return Task.CompletedTask;
        }

        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("DeleteResponseAsync");
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

        private sealed class CancellationAdapter(NoEvictionProvider provider) : ResponsesCancellationSignalProvider
        {
            public override Task CancelResponseAsync(string responseId, CancellationToken ct = default)
                => provider.CancelResponseAsync(responseId, ct);
            public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken ct = default)
                => provider.GetResponseCancellationTokenAsync(responseId, ct);
        }

        private sealed class StreamAdapter(NoEvictionProvider provider) : ResponsesStreamProvider
        {
            public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken ct = default)
                => provider.CreateEventPublisherAsync(responseId, ct);
            public override Task<IAsyncDisposable> SubscribeToEventsAsync(string responseId, IAsyncObserver<ResponseStreamEvent> observer, long? cursor = null, CancellationToken ct = default)
                => provider.SubscribeToEventsAsync(responseId, observer, cursor, ct);
        }

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
