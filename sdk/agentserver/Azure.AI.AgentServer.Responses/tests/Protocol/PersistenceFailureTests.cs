// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for persistence failure handling (Layer 2).
/// <para>
/// Verifies:
/// - Terminal persistence failures (FinalizeExecutionAsync) mutate the response to
///   <c>status: "failed"</c> with <c>error.code: "storage_error"</c>.
/// - The failed response remains retrievable via GET from the in-memory tracker (no eviction).
/// - All storage errors (transient and non-retryable) mark the response as failed
///   (the Foundry provider's Azure.Core pipeline handles transport-level retries internally).
/// - Streaming mode: terminal event is replaced with <c>response.failed</c> when persistence fails.
/// - Background+streaming Phase 1 (CreateResponseAsync at response.created time): failure
///   before client receives <c>response.created</c> emits standalone <c>error</c> event per spec.
/// </para>
/// </summary>
public class PersistenceFailureTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly FailingProvider _provider;
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public PersistenceFailureTests()
    {
        _provider = new FailingProvider();
        _factory = new TestWebApplicationFactory(
            _handler,
            configureTestServices: services =>
            {
                services.AddSingleton<ResponsesProvider>(_provider);
                services.AddSingleton<ResponsesCancellationSignalProvider>(_provider.AsCancellationProvider());
                services.AddSingleton<ResponsesStreamProvider>(_provider.AsStreamProvider());
            });
        _client = _factory.CreateClient();
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Non-streaming, non-background: terminal persistence failure →
    // re-throw original storage exception (avoids dangling response ID)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task NonStreaming_PersistenceFailure_RethrowsOriginalStorageError()
    {
        // Arrange: provider always throws on Create (ResponsesApiException 500)
        _provider.CreateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST (non-streaming, non-bg)
        var json = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);

        // Assert: HTTP 500 with the original storage error — no dangling response ID.
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("storage_error"));
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Service unavailable"));
    }

    [Test]
    public async Task NonStreaming_NonRetryableError_RethrowsOriginalBadRequest()
    {
        // Arrange: provider returns BadRequest (non-retryable) — fails immediately
        var callCount = 0;
        _provider.CreateBehavior = _ =>
        {
            Interlocked.Increment(ref callCount);
            throw new BadRequestException("Invalid data", "invalid_request", null);
        };

        // Act: POST (non-streaming, non-bg)
        var json = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);

        // Assert: HTTP 400 with original error (BadRequestException maps to 400)
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_request"));

        // Assert: only 1 call (no application-level retry — Azure.Core handles retries at transport level)
        Assert.That(callCount, Is.EqualTo(1));
    }

    [Test]
    public async Task NonStreaming_TransientError_RethrowsOriginalStorageError()
    {
        // Arrange: provider returns a transient server error (5xx) — no application-level retry,
        // because Azure.Core's pipeline already retried at the transport level before we see it.
        var callCount = 0;
        _provider.CreateBehavior = _ =>
        {
            Interlocked.Increment(ref callCount);
            throw new ResponsesApiException(new Error("storage_error", "Temporary"), 500);
        };

        // Act: POST (non-streaming, non-bg)
        var json = JsonSerializer.Serialize(new { model = "test" });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);

        // Assert: HTTP 500 with original error
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("storage_error"));

        // Assert: only 1 call (no retry at this layer)
        Assert.That(callCount, Is.EqualTo(1));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Streaming, non-background: terminal persistence failure →
    // response.completed replaced with response.failed
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Streaming_PersistenceFailure_EmitsFailedTerminalEvent()
    {
        // Arrange: provider always throws on Create (simulates persist-before-terminal-yield)
        _provider.CreateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST streaming (non-bg)
        var json = JsonSerializer.Serialize(new { model = "test", stream = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Read SSE events
        var sseBody = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(sseBody);

        // Must have response.created first (spec: B8 event ordering)
        Assert.That(events.Any(e => e.EventType == "response.created"), Is.True,
            "Expected response.created event");
        // Terminal must be response.failed, NOT response.completed
        Assert.That(events.Any(e => e.EventType == "response.completed"), Is.False,
            "Should NOT have response.completed when persistence fails");
        Assert.That(events.Any(e => e.EventType == "response.failed"), Is.True,
            "Expected response.failed terminal event");

        // The failed event should contain the storage error
        var failedEvent = events.First(e => e.EventType == "response.failed");
        using var failedDoc = JsonDocument.Parse(failedEvent.Data);
        Assert.That(failedDoc.RootElement.GetProperty("response").GetProperty("status").GetString(),
            Is.EqualTo("failed"));
        Assert.That(failedDoc.RootElement.GetProperty("response").GetProperty("error").GetProperty("code").GetString(),
            Is.EqualTo("storage_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Background, non-streaming: Phase 2 (Update) failure → GET returns
    // failed from tracker (not evicted)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Background_UpdateFailure_GetReturnsFailedFromTracker()
    {
        // Arrange: Create succeeds (Phase 1), Update always fails (Phase 2 terminal)
        _provider.UpdateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST bg (non-streaming)
        var json = JsonSerializer.Serialize(new { model = "test", background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = await _client.PostAsync("/responses", content);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await JsonDocument.ParseAsync(await postResponse.Content.ReadAsStreamAsync());
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for background finalization to complete — the response initially shows
        // "in_progress" from handler, then transitions to "failed" when persistence fails.
        await WaitForSpecificStatusAsync(responseId, "failed");

        // Act: GET — should return failed from in-memory tracker (not 404)
        var getResponse = await _client.GetAsync($"/responses/{responseId}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var getDoc = await JsonDocument.ParseAsync(await getResponse.Content.ReadAsStreamAsync());
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("failed"));
        Assert.That(getDoc.RootElement.GetProperty("error").GetProperty("code").GetString(), Is.EqualTo("storage_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Background+streaming, Phase 1 (CreateResponseAsync) failure →
    // Standalone "error" SSE event (no response.created per spec)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task Background_UpdateFailure_DeleteCleansUpStorageAndTracker()
    {
        // Arrange: Create succeeds (Phase 1), Update always fails (Phase 2 terminal)
        _provider.UpdateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST bg (non-streaming) — Phase 1 creates in storage
        var json = JsonSerializer.Serialize(new { model = "test", background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var postResponse = await _client.PostAsync("/responses", content);
        Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var postDoc = await JsonDocument.ParseAsync(await postResponse.Content.ReadAsStreamAsync());
        var responseId = postDoc.RootElement.GetProperty("id").GetString()!;

        // Wait for finalization to mark persistence as failed
        await WaitForSpecificStatusAsync(responseId, "failed");

        // Act: DELETE — should clean up from both tracker AND storage
        var deleteResponse = await _client.DeleteAsync($"/responses/{responseId}");
        Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var deleteDoc = await JsonDocument.ParseAsync(await deleteResponse.Content.ReadAsStreamAsync());
        Assert.That(deleteDoc.RootElement.GetProperty("id").GetString(), Is.EqualTo(responseId));
        Assert.That(deleteDoc.RootElement.GetProperty("deleted").GetBoolean(), Is.True);

        // Verify provider saw the delete (cleanup of Phase 1 storage)
        Assert.That(_provider.Calls, Does.Contain("DeleteResponseAsync"));

        // GET should now 404 — evicted from tracker AND deleted from storage
        var getResponse = await _client.GetAsync($"/responses/{responseId}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task BackgroundStreaming_Phase1Failure_EmitsStandaloneErrorEvent()
    {
        // Arrange: Phase 1 CreateResponseAsync fails (before response.created is
        // yielded to the client). Per spec, this is a pre-creation error and must
        // emit a standalone "error" event, NOT response.failed.
        _provider.CreateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST bg+streaming
        var json = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Read SSE events
        var sseBody = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(sseBody);

        // Spec B8: Pre-creation error → standalone "error" event, no response.created
        Assert.That(events.Any(e => e.EventType == "response.created"), Is.False,
            "response.created must NOT be emitted when Phase 1 persistence fails");
        Assert.That(events.Any(e => e.EventType == "error"), Is.True,
            "Expected standalone 'error' event for pre-creation failure");

        // Verify the error event has the storage error code
        var errorEvent = events.First(e => e.EventType == "error");
        using var errorDoc = JsonDocument.Parse(errorEvent.Data);
        Assert.That(errorDoc.RootElement.GetProperty("code").GetString(), Is.EqualTo("storage_error"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Background+streaming, Phase 2 (Update) failure → terminal event is
    // response.failed (response.created already delivered)
    // ═══════════════════════════════════════════════════════════════════════

    [Test]
    public async Task BackgroundStreaming_Phase2Failure_EmitsResponseFailed()
    {
        // Arrange: Create succeeds (Phase 1), Update fails (Phase 2 terminal)
        _provider.UpdateBehavior = _ => throw new ResponsesApiException(
            new Error("storage_error", "Service unavailable"), 500);

        // Act: POST bg+streaming
        var json = JsonSerializer.Serialize(new { model = "test", stream = true, background = true });
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Read SSE events
        var sseBody = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(sseBody);

        // Should have response.created (Phase 1 succeeded) then response.failed
        Assert.That(events.Any(e => e.EventType == "response.created"), Is.True,
            "Expected response.created event (Phase 1 succeeded)");
        Assert.That(events.Any(e => e.EventType == "response.completed"), Is.False,
            "Should NOT have response.completed when Phase 2 persistence fails");
        Assert.That(events.Any(e => e.EventType == "response.failed"), Is.True,
            "Expected response.failed terminal event");
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Polls GET until the response reaches a terminal status or timeout.
    /// Uses explicit polling with timeout instead of blind Task.Delay.
    /// </summary>
    private async Task WaitForTerminalStatusAsync(string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(10));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await _client.GetAsync($"/responses/{responseId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
                if (doc.RootElement.TryGetProperty("status", out var statusProp))
                {
                    var status = statusProp.GetString();
                    if (status is "completed" or "failed" or "incomplete" or "cancelled")
                        return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response {responseId} did not reach terminal status within timeout");
    }

    /// <summary>
    /// Polls GET until the response reaches a specific status or timeout.
    /// Used when we need to wait for finalization to complete (e.g. persistence failure
    /// transitions from "completed" to "failed").
    /// </summary>
    private async Task WaitForSpecificStatusAsync(string responseId, string expectedStatus, TimeSpan? timeout = null)
    {
        var deadline = DateTimeOffset.UtcNow + (timeout ?? TimeSpan.FromSeconds(10));
        while (DateTimeOffset.UtcNow < deadline)
        {
            var response = await _client.GetAsync($"/responses/{responseId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
                if (doc.RootElement.TryGetProperty("status", out var statusProp))
                {
                    if (statusProp.GetString() == expectedStatus)
                        return;
                }
            }

            await Task.Delay(100);
        }

        Assert.Fail($"Response {responseId} did not reach status '{expectedStatus}' within timeout");
    }

    private static List<SseEvent> ParseSseEvents(string body)
    {
        var events = new List<SseEvent>();
        string? currentEvent = null;
        var dataLines = new List<string>();

        foreach (var line in body.Split('\n'))
        {
            if (line.StartsWith("event: "))
            {
                currentEvent = line["event: ".Length..].Trim();
            }
            else if (line.StartsWith("data: "))
            {
                dataLines.Add(line["data: ".Length..]);
            }
            else if (line.Trim() == "" && currentEvent is not null)
            {
                events.Add(new SseEvent(currentEvent, string.Join("\n", dataLines)));
                currentEvent = null;
                dataLines.Clear();
            }
        }

        return events;
    }

    private record SseEvent(string EventType, string Data);

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        _provider.Dispose();
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Failing provider — configurable failure behavior per operation
    // ═══════════════════════════════════════════════════════════════════════

    private sealed class FailingProvider : ResponsesProvider, IDisposable
    {
        private readonly InMemoryResponsesProvider _inner = new(
            Options.Create(new InMemoryProviderOptions()), TimeProvider.System);
        private readonly ConcurrentBag<string> _calls = new();

        /// <summary>
        /// Func invoked before CreateResponseAsync — throw to simulate failure.
        /// Receives call count (1-based). If null or does not throw, delegates to inner.
        /// </summary>
        public Action<int>? CreateBehavior { get; set; }

        /// <summary>
        /// Func invoked before UpdateResponseAsync — throw to simulate failure.
        /// Receives call count (1-based). If null or does not throw, delegates to inner.
        /// </summary>
        public Action<int>? UpdateBehavior { get; set; }

        private int _createCallCount;
        private int _updateCallCount;

        public IReadOnlyCollection<string> Calls => _calls;

        public override async Task CreateResponseAsync(
            CreateResponseRequest request, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            _calls.Add("CreateResponseAsync");
            var count = Interlocked.Increment(ref _createCallCount);
            CreateBehavior?.Invoke(count);
            await _inner.CreateResponseAsync(request, isolation, cancellationToken);
        }

        public override async Task<Models.ResponseObject> GetResponseAsync(
            string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            _calls.Add("GetResponseAsync");
            return await _inner.GetResponseAsync(responseId, isolation, cancellationToken);
        }

        public override async Task UpdateResponseAsync(
            Models.ResponseObject response, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            _calls.Add("UpdateResponseAsync");
            var count = Interlocked.Increment(ref _updateCallCount);
            UpdateBehavior?.Invoke(count);
            await _inner.UpdateResponseAsync(response, isolation, cancellationToken);
        }

        public override async Task DeleteResponseAsync(
            string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
        {
            _calls.Add("DeleteResponseAsync");
            await _inner.DeleteResponseAsync(responseId, isolation, cancellationToken);
        }

        public override async Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
            string responseId, IsolationContext isolation, int limit = 20, bool ascending = false,
            string? after = null, string? before = null, CancellationToken cancellationToken = default)
            => await _inner.GetInputItemsAsync(responseId, isolation, limit, ascending, after, before, cancellationToken);

        public override async Task<IEnumerable<OutputItem?>> GetItemsAsync(
            IEnumerable<string> itemIds, IsolationContext isolation, CancellationToken cancellationToken = default)
            => await _inner.GetItemsAsync(itemIds, isolation, cancellationToken);

        public override async Task<IEnumerable<string>> GetHistoryItemIdsAsync(
            string? previousResponseId, string? conversationId, int limit, IsolationContext isolation,
            CancellationToken cancellationToken = default)
            => await _inner.GetHistoryItemIdsAsync(previousResponseId, conversationId, limit, isolation, cancellationToken);

        internal ResponsesCancellationSignalProvider AsCancellationProvider() => new CancellationAdapter(_inner);
        internal ResponsesStreamProvider AsStreamProvider() => new StreamAdapter(_inner);

        private sealed class CancellationAdapter(InMemoryResponsesProvider inner) : ResponsesCancellationSignalProvider
        {
            public override Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
                => inner.CancelResponseAsync(responseId, cancellationToken);
            public override Task<CancellationToken> GetResponseCancellationTokenAsync(string responseId, CancellationToken cancellationToken = default)
                => inner.GetResponseCancellationTokenAsync(responseId, cancellationToken);
        }

        private sealed class StreamAdapter(InMemoryResponsesProvider inner) : ResponsesStreamProvider
        {
            public override Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, CancellationToken cancellationToken = default)
                => inner.CreateEventPublisherAsync(responseId, cancellationToken);
            public override Task<IAsyncDisposable> SubscribeToEventsAsync(string responseId, IAsyncObserver<ResponseStreamEvent> observer, long? cursor = null, CancellationToken cancellationToken = default)
                => inner.SubscribeToEventsAsync(responseId, observer, cursor, cancellationToken);
        }

        public void Dispose()
        {
            _inner.Dispose();
        }
    }
}
