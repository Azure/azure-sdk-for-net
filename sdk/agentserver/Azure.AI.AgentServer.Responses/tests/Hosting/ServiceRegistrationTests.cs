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
    public void Custom_ResponsesStreamProvider_Takes_Precedence_Over_Default()
    {
        var custom = new StubStreamProvider();
        var services = new ServiceCollection();
        services.AddSingleton<ResponsesStreamProvider>(custom);
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var resolved = sp.GetRequiredService<ResponsesStreamProvider>();

        Assert.That(resolved, Is.SameAs(custom));
    }

    [Test]
    public void Default_Registration_Provides_InMemory_For_All_Three_Interfaces()
    {
        var services = new ServiceCollection();
        services.AddSingleton<ResponseHandler>(new TestHandler());
        services.AddResponsesServer();

        using var sp = services.BuildServiceProvider();
        var state = sp.GetRequiredService<ResponsesProvider>();
        var cancel = sp.GetRequiredService<ResponsesCancellationSignalProvider>();
        var stream = sp.GetRequiredService<ResponsesStreamProvider>();

        // State should be InMemoryResponsesProvider; cancel and stream are adapters backed by same provider
        Assert.That(state, Is.InstanceOf<InMemoryResponsesProvider>());
        Assert.That(cancel, Is.InstanceOf<InMemoryCancellationSignalProvider>());
        Assert.That(stream, Is.InstanceOf<InMemoryStreamProvider>());
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
        var stream = sp.GetRequiredService<ResponsesStreamProvider>();

        // Custom state provider
        Assert.That(state, Is.SameAs(customState));

        // Cancel and stream should resolve to InMemory adapters (not custom)
        Assert.That(cancel, Is.InstanceOf<InMemoryCancellationSignalProvider>());
        Assert.That(stream, Is.InstanceOf<InMemoryStreamProvider>());
    }

    // ═══════════════════════════════════════════════════════════════════════
    // T015: Protocol-level — three separate implementations,
    // each receives the correct calls
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Three_Separate_Providers_Each_Receive_Correct_Calls()
    {
        var stateProvider = new RecordingStateProvider();
        var cancelProvider = new RecordingCancelProvider();
        var streamProvider = new RecordingStreamProvider();

        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(stateProvider);
                services.AddSingleton<ResponsesCancellationSignalProvider>(cancelProvider);
                services.AddSingleton<ResponsesStreamProvider>(streamProvider);
            });
        using var client = factory.CreateClient();

        // POST /responses with bg+streaming — triggers CreateResponseAsync (state),
        // CreateEventPublisherAsync (stream), GetResponseCancellationTokenAsync (cancel).
        // Only bg+streaming mode exercises all three providers because non-replay modes
        // use NullPublisher internally and skip the stream provider.
        var body = JsonSerializer.Serialize(new { model = "test", background = true, stream = true });
        var response = await client.PostAsync("/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Consume the SSE stream so the handler completes
        await response.Content.ReadAsStringAsync();

        // Verify state provider got state calls
        XAssert.Contains("CreateResponseAsync", stateProvider.Calls);

        // Verify stream provider got streaming call
        XAssert.Contains("CreateEventPublisherAsync", streamProvider.Calls);

        // Verify cancellation provider got token creation call
        XAssert.Contains("GetResponseCancellationTokenAsync", cancelProvider.Calls);

        // Verify NO cross-contamination: state provider should NOT have streaming/cancel calls
        XAssert.DoesNotContain("CreateEventPublisherAsync", stateProvider.Calls);
        XAssert.DoesNotContain("CancelResponseAsync", stateProvider.Calls);

        // Stream provider should NOT have state/cancel calls
        XAssert.DoesNotContain("CreateResponseAsync", streamProvider.Calls);
        XAssert.DoesNotContain("CancelResponseAsync", streamProvider.Calls);

        // Cancel provider should NOT have state/streaming calls
        XAssert.DoesNotContain("CreateResponseAsync", cancelProvider.Calls);
        XAssert.DoesNotContain("CreateEventPublisherAsync", cancelProvider.Calls);
    }

    [Test]
    public async Task Cancel_Operation_Routes_To_CancellationSignalProvider()
    {
        var stateProvider = new RecordingStateProvider();
        var cancelProvider = new RecordingCancelProvider();
        var streamProvider = new RecordingStreamProvider();

        var blockingHandler = new TestHandler();
        blockingHandler.EventFactory = (_, ctx, ct) => BlockingStream(ctx, ct);
        using var factory = new TestWebApplicationFactory(
            handler: blockingHandler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(stateProvider);
                services.AddSingleton<ResponsesCancellationSignalProvider>(cancelProvider);
                services.AddSingleton<ResponsesStreamProvider>(streamProvider);
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
        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken ct = default) => Task.CompletedTask;
        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");
        public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken ct = default) => Task.CompletedTask;
        public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
            => throw new ResourceNotFoundException("not found");
        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, IsolationContext isolation, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken ct = default)
            => Task.FromResult(ResponsesModelFactory.AgentsPagedResultOutputItem(data: Array.Empty<OutputItem>(), hasMore: false));
        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<OutputItem?>());
        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, IsolationContext isolation, CancellationToken ct = default)
            => Task.FromResult(Enumerable.Empty<string>());
    }

    private sealed class StubCancellationProvider : ResponsesCancellationSignalProvider
    {
        public override Task CancelResponseAsync(string responseId, CancellationToken ct = default) => Task.CompletedTask;
        public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken ct = default)
            => Task.FromResult(CancellationToken.None);
    }

    private sealed class StubStreamProvider : ResponsesStreamProvider
    {
        public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken ct = default)
            => throw new NotImplementedException();
        public override Task<IAsyncDisposable> SubscribeToEventsAsync(string responseId, IAsyncObserver<ResponseStreamEvent> observer, long? cursor = null, CancellationToken ct = default)
            => throw new NotImplementedException();
    }

    /// <summary>
    /// State-only recording provider with working in-memory storage.
    /// </summary>
    private sealed class RecordingStateProvider : ResponsesProvider
    {
        private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();
        public ConcurrentBag<string> Calls { get; } = new();

        public override Task CreateResponseAsync(CreateResponseRequest request, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("CreateResponseAsync");
            _responses.TryAdd(request.Response.Id, request.Response);
            return Task.CompletedTask;
        }

        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken ct = default)
        {
            Calls.Add("GetResponseAsync");
            if (!_responses.TryGetValue(responseId, out var response))
                throw new ResourceNotFoundException($"Response '{responseId}' not found.");
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

    /// <summary>
    /// Stream-only recording provider with working SeekableReplaySubject backing.
    /// </summary>
    private sealed class RecordingStreamProvider : ResponsesStreamProvider, IDisposable
    {
        private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
        private readonly TimeSpan _ttl = TimeSpan.FromMinutes(30);
        public ConcurrentBag<string> Calls { get; } = new();

        public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken ct = default)
        {
            Calls.Add("CreateEventPublisherAsync");
            var subject = _subjects.GetOrAdd(responseId, _ => new SeekableReplaySubject(_ttl));
            return Task.FromResult(subject.GetPublisher());
        }

        public override async Task<IAsyncDisposable> SubscribeToEventsAsync(
            string responseId,
            IAsyncObserver<ResponseStreamEvent> observer,
            long? cursor = null,
            CancellationToken ct = default)
        {
            Calls.Add("SubscribeToEventsAsync");
            if (!_subjects.TryGetValue(responseId, out var subject))
                throw new InvalidOperationException($"No event stream for '{responseId}'.");

            var unwrapping = new UnwrappingObserver(observer);
            return await subject.SubscribeAsync(unwrapping, cursor);
        }

        public void Dispose()
        {
            foreach (var s in _subjects.Values)
                s.Dispose();
        }

        private sealed class UnwrappingObserver(IAsyncObserver<ResponseStreamEvent> inner)
            : IAsyncObserver<(long SequenceNumber, ResponseStreamEvent Event)>
        {
            public ValueTask OnNextAsync((long SequenceNumber, ResponseStreamEvent Event) value) => inner.OnNextAsync(value.Event);
            public ValueTask OnErrorAsync(Exception error) => inner.OnErrorAsync(error);
            public ValueTask OnCompletedAsync() => inner.OnCompletedAsync();
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
