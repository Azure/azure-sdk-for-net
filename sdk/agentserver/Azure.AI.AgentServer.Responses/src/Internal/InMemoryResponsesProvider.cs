// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Default in-memory implementation of <see cref="ResponsesProvider"/>,
/// with cancellation and streaming capabilities exposed via
/// <see cref="InMemoryCancellationSignalProvider"/> and <see cref="InMemoryStreamProvider"/> adapters.
/// Stores responses, event streams, and cancellation tokens in concurrent dictionaries.
/// </summary>
/// <remarks>
/// <para>
/// This implementation is suitable for single-instance deployments.
/// For multi-instance or distributed deployments, consumers should extend
/// the provider abstract classes with a distributed backend (e.g., Redis, SQL).
/// </para>
/// <para>
/// Response data (envelopes, items, history, conversation membership) is retained
/// indefinitely. Event stream replay uses per-event TTL — each event expires individually
/// from its emission time via the underlying <see cref="SeekableReplaySubject"/>.
/// The subject container and cancellation token source are disposed after the TTL
/// window fully elapses since the last event was emitted.
/// </para>
/// <para>
/// Event streaming uses <see cref="SeekableReplaySubject"/> which provides
/// replay buffering with time-based eviction and cursor-based seeking.
/// </para>
/// </remarks>
internal sealed class InMemoryResponsesProvider : ResponsesProvider, IDisposable
{
    // --- Response envelopes ---
    private readonly ConcurrentDictionary<string, Models.ResponseObject> _responses = new();

    // --- Chat isolation keys (response ID → creation-time chat isolation key) ---
    private readonly ConcurrentDictionary<string, string> _chatIsolationKeys = new();

    // --- Item store (all items by ID) ---
    private readonly ConcurrentDictionary<string, OutputItem> _itemStore = new();

    // --- Per-response ordered ID lists ---
    private readonly ConcurrentDictionary<string, IReadOnlyList<string>> _inputItemIds = new();
    private readonly ConcurrentDictionary<string, IReadOnlyList<string>> _outputItemIds = new();
    private readonly ConcurrentDictionary<string, IReadOnlyList<string>> _historyItemIds = new();

    // --- Conversation tracking (conversation ID → ordered response IDs) ---
    private readonly ConcurrentDictionary<string, List<string>> _conversationResponses = new();

    // --- Deletion tracking ---
    private readonly HashSet<string> _deletedResponseIds = new();

    // --- Streaming & cancellation ---
    private readonly ConcurrentDictionary<string, SeekableReplaySubject> _subjects = new();
    private readonly ConcurrentDictionary<string, CancellationTokenSource> _cancellationTokenSources = new();

    /// <summary>
    /// Tracks when each response's last event was approximately emitted (terminal status time).
    /// Used to GC the subject container after the per-event TTL window has fully elapsed.
    /// The <see cref="SeekableReplaySubject"/> handles per-event expiry internally;
    /// this timestamp determines when to dispose the empty subject shell.
    /// </summary>
    private readonly ConcurrentDictionary<string, DateTimeOffset> _lastEventEmittedAt = new();

    private readonly TimeSpan _eventStreamTtl;
    private readonly TimeProvider _timeProvider;
    private readonly ITimer _evictionTimer;

    /// <summary>
    /// Initializes a new instance of <see cref="InMemoryResponsesProvider"/>.
    /// </summary>
    /// <param name="options">In-memory provider options containing TTL configuration.</param>
    /// <param name="timeProvider">Time provider for clock and timer operations.</param>
    public InMemoryResponsesProvider(IOptions<InMemoryProviderOptions> options, TimeProvider timeProvider)
    {
        _eventStreamTtl = options.Value.EventStreamTtl;
        _timeProvider = timeProvider;

        var evictionInterval = TimeSpan.FromSeconds(Math.Max(Math.Min(_eventStreamTtl.TotalSeconds / 4, 30), 1));
        _evictionTimer = _timeProvider.CreateTimer(
            _ => EvictExpired(), null, evictionInterval, evictionInterval);
    }

    /// <inheritdoc/>
    public override Task CreateResponseAsync(
        CreateResponseRequest request,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var response = request.Response;
        var inputItems = request.InputItems;
        var historyItemIds = request.HistoryItemIds;

        if (!_responses.TryAdd(response.Id, response))
        {
            throw new InvalidOperationException($"Response '{response.Id}' already exists.");
        }

        // Record the creation-time chat isolation key for enforcement on subsequent operations
        if (isolation.ChatIsolationKey is not null)
        {
            _chatIsolationKeys[response.Id] = isolation.ChatIsolationKey;
        }

        // Store input items in the item store and track their ordered IDs
        var inputIds = new List<string>();
        foreach (var item in inputItems)
        {
            var id = GetItemId(item);
            if (id is not null)
            {
                _itemStore[id] = item;
                inputIds.Add(id);
            }
        }

        _inputItemIds[response.Id] = inputIds;

        // Track history item IDs (items already exist in _itemStore from prior responses)
        _historyItemIds[response.Id] = historyItemIds.ToList();

        // Store output items from Response.Output (non-bg mode has them populated at create time)
        StoreOutputItems(response);

        // Track conversation membership
        AddToConversation(response);

        // Track terminal timestamp for event stream GC (non-bg responses are persisted at terminal state)
        if (response.Status.HasValue && IsTerminal(response.Status.Value))
        {
            _lastEventEmittedAt.TryAdd(response.Id, _timeProvider.GetUtcNow());
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
    {
        // Deleted response → 404 (spec: post-deletion, response not found)
        bool isDeleted;
        lock (_deletedResponseIds)
        {
            isDeleted = _deletedResponseIds.Contains(responseId);
        }

        if (isDeleted)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        if (!_responses.TryGetValue(responseId, out var response))
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceChatIsolation(responseId, isolation);

        return Task.FromResult(response);
    }

    /// <inheritdoc/>
    public override Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken cancellationToken = default)
    {
        _responses[response.Id] = response;

        // Detect new output items and store them
        StoreOutputItems(response);

        // Track conversation membership for new output items
        AddOutputToConversation(response);

        if (response.Status.HasValue && IsTerminal(response.Status.Value))
        {
            _lastEventEmittedAt.TryAdd(response.Id, _timeProvider.GetUtcNow());
        }

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public override Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default)
    {
        // Check existence first (before isolation) to maintain consistent 404 for unknown IDs
        if (!_responses.ContainsKey(responseId))
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceChatIsolation(responseId, isolation);

        if (!_responses.TryRemove(responseId, out _))
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        // Track deletion so GetInputItemsAsync can distinguish deleted vs never-existed.
        // Items, history, and conversation membership are intentionally retained.
        lock (_deletedResponseIds)
        {
            _deletedResponseIds.Add(responseId);
        }

        // Clean up isolation key tracking
        _chatIsolationKeys.TryRemove(responseId, out _);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Enforces chat isolation key for persisted responses.
    /// If the response was created with a chat isolation key, the caller must
    /// provide the same key; mismatches are treated as "not found" to prevent
    /// cross-chat information leakage.
    /// </summary>
    private void EnforceChatIsolation(string responseId, IsolationContext isolation)
    {
        if (_chatIsolationKeys.TryGetValue(responseId, out var expectedKey)
            && !string.Equals(expectedKey, isolation.ChatIsolationKey, StringComparison.Ordinal))
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }
    }

    private static bool IsTerminal(ResponseStatus status) =>
        status is ResponseStatus.Completed or ResponseStatus.Failed
              or ResponseStatus.Cancelled or ResponseStatus.Incomplete;

    /// <inheritdoc/>
    public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        IsolationContext isolation,
        int limit = 20,
        bool ascending = false,
        string? after = null,
        string? before = null,
        CancellationToken cancellationToken = default)
    {
        // Deleted response → 404
        bool isDeleted;
        lock (_deletedResponseIds)
        {
            isDeleted = _deletedResponseIds.Contains(responseId);
        }

        if (isDeleted)
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        // Never existed → 404
        if (!_responses.ContainsKey(responseId) && !_inputItemIds.ContainsKey(responseId))
        {
            throw new ResourceNotFoundException($"Response '{responseId}' not found.");
        }

        EnforceChatIsolation(responseId, isolation);

        // Combine history + current input items by resolving IDs from the item store
        var allItems = new List<OutputItem>();

        // 1. Resolve history items
        if (_historyItemIds.TryGetValue(responseId, out var historyIds))
        {
            foreach (var id in historyIds)
            {
                if (_itemStore.TryGetValue(id, out var item))
                {
                    allItems.Add(item);
                }
            }
        }

        // 2. Resolve current input items
        if (_inputItemIds.TryGetValue(responseId, out var inputIds))
        {
            foreach (var id in inputIds)
            {
                if (_itemStore.TryGetValue(id, out var item))
                {
                    allItems.Add(item);
                }
            }
        }

        // Apply ordering (ascending = history first, then current; descending = reversed)
        var ordered = ascending ? allItems : Enumerable.Reverse(allItems).ToList();
        var list = ordered.ToList();

        // Apply cursor-based pagination
        if (after is not null)
        {
            var idx = list.FindIndex(i => GetItemId(i) == after);
            if (idx >= 0)
            {
                list = list.Skip(idx + 1).ToList();
            }
        }

        if (before is not null)
        {
            var idx = list.FindIndex(i => GetItemId(i) == before);
            if (idx >= 0)
            {
                list = list.Take(idx).ToList();
            }
        }

        var hasMore = list.Count > limit;
        var page = list.Take(limit).ToList();

        var firstId = page.Count > 0 ? GetItemId(page[0]) : null;
        var lastId = page.Count > 0 ? GetItemId(page[^1]) : null;

        var result = ResponsesModelFactory.AgentsPagedResultOutputItem(
            data: page,
            firstId: firstId!,
            lastId: lastId!,
            hasMore: hasMore);
        return Task.FromResult(result);
    }

    /// <inheritdoc/>
    public override Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var results = itemIds.Select(id => _itemStore.TryGetValue(id, out var item) ? item : null);
        return Task.FromResult(results);
    }

    /// <inheritdoc/>
    public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        // previousResponseId path: return history + input + output of the previous response
        if (previousResponseId is not null)
        {
            var allIds = new List<string>();

            if (_historyItemIds.TryGetValue(previousResponseId, out var historyIds))
            {
                allIds.AddRange(historyIds);
            }

            if (_inputItemIds.TryGetValue(previousResponseId, out var inputIds))
            {
                allIds.AddRange(inputIds);
            }

            if (_outputItemIds.TryGetValue(previousResponseId, out var outputIds))
            {
                allIds.AddRange(outputIds);
            }

            return Task.FromResult(allIds.Take(limit).AsEnumerable());
        }

        // conversationId path: return all item IDs from all responses in the conversation
        if (conversationId is not null && _conversationResponses.TryGetValue(conversationId, out var responseIds))
        {
            var allIds = new List<string>();
            lock (responseIds)
            {
                foreach (var respId in responseIds)
                {
                    if (_inputItemIds.TryGetValue(respId, out var inputIds))
                    {
                        allIds.AddRange(inputIds);
                    }

                    if (_outputItemIds.TryGetValue(respId, out var outputIds))
                    {
                        allIds.AddRange(outputIds);
                    }
                }
            }

            return Task.FromResult(allIds.Take(limit).AsEnumerable());
        }

        return Task.FromResult(Enumerable.Empty<string>());
    }

    private static string? GetItemId(OutputItem item)
    {
        try
        {
            return item.GetId();
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    /// <summary>
    /// Extracts output items from <see cref="Models.ResponseObject.Output"/>, stores new ones in the item store,
    /// and updates the output item ID list for the response.
    /// </summary>
    private void StoreOutputItems(Models.ResponseObject response)
    {
        if (response.Output.Count == 0)
        {
            return;
        }

        var outputIds = new List<string>();
        foreach (var item in response.Output)
        {
            var id = GetItemId(item);
            if (id is not null)
            {
                _itemStore[id] = item;
                outputIds.Add(id);
            }
        }

        if (outputIds.Count > 0)
        {
            _outputItemIds[response.Id] = outputIds;
        }
    }

    /// <summary>
    /// Adds input and output item IDs to the conversation if the response has a conversation ID.
    /// Called on <see cref="CreateResponseAsync"/>.
    /// </summary>
    private void AddToConversation(Models.ResponseObject response)
    {
        var conversationId = response.Conversation?.Id;
        if (conversationId is null)
        {
            return;
        }

        var responseList = _conversationResponses.GetOrAdd(conversationId, _ => new List<string>());
        lock (responseList)
        {
            if (!responseList.Contains(response.Id))
            {
                responseList.Add(response.Id);
            }
        }
    }

    /// <summary>
    /// Adds new output items to the conversation on <see cref="UpdateResponseAsync"/>.
    /// The response should already have been added to the conversation via
    /// <see cref="AddToConversation"/> during create.
    /// </summary>
    private void AddOutputToConversation(Models.ResponseObject response)
    {
        var conversationId = response.Conversation?.Id;
        if (conversationId is null)
        {
            return;
        }

        // Ensure the response is tracked in the conversation
        AddToConversation(response);
    }

    // --- Streaming ---

    /// <summary>
    /// Creates an event publisher backed by a <see cref="SeekableReplaySubject"/>.
    /// </summary>
    public Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(
        string responseId, CancellationToken cancellationToken = default)
    {
        var subject = _subjects.GetOrAdd(responseId, _ => new SeekableReplaySubject(_eventStreamTtl));
        return Task.FromResult(subject.GetPublisher());
    }

    /// <summary>
    /// Subscribes to events by seeking into the <see cref="SeekableReplaySubject"/>.
    /// </summary>
    public async Task<IAsyncDisposable> SubscribeToEventsAsync(
        string responseId,
        IAsyncObserver<ResponseStreamEvent> observer,
        long? cursor = null,
        CancellationToken cancellationToken = default)
    {
        if (!_subjects.TryGetValue(responseId, out var subject))
        {
            throw new BadRequestException($"Event stream is not available for response '{responseId}'.");
        }

        // Wrap the caller's observer in an adapter that unwraps the (SeqNo, Event) tuple
        var adapter = new UnwrappingObserver(observer);
        return await subject.SubscribeAsync(adapter, cursor).ConfigureAwait(false);
    }

    /// <summary>
    /// Removes the event stream for the specified response, freeing buffer memory.
    /// After deletion, <see cref="SubscribeToEventsAsync"/> will throw for this response ID.
    /// </summary>
    public Task DeleteEventStreamAsync(string responseId)
    {
        if (_subjects.TryRemove(responseId, out var subject))
        {
            subject.Dispose();
        }

        return Task.CompletedTask;
    }

    // --- Cancellation ---

    /// <summary>
    /// Signals cancellation via the per-response <see cref="CancellationTokenSource"/>.
    /// </summary>
    public Task CancelResponseAsync(string responseId, CancellationToken cancellationToken = default)
    {
        if (_cancellationTokenSources.TryGetValue(responseId, out var cts))
        {
            try
            {
                cts.Cancel();
            }
            catch (ObjectDisposedException)
            {
                // Already disposed — no-op
            }
        }

        // Unknown ID or already cancelled — no-op (fire-and-forget)
        return Task.CompletedTask;
    }

    /// <summary>
    /// Returns a token linked to the per-response <see cref="CancellationTokenSource"/>.
    /// </summary>
    public Task<CancellationToken> GetResponseCancellationTokenAsync(
        string responseId, CancellationToken cancellationToken = default)
    {
        var cts = _cancellationTokenSources.GetOrAdd(responseId, _ => new CancellationTokenSource());
        return Task.FromResult(cts.Token);
    }

    // --- Eviction ---

    /// <summary>
    /// GC pass for event stream infrastructure.
    /// The <see cref="SeekableReplaySubject"/> handles per-event TTL internally
    /// (each event expires individually from its emission time). This method
    /// disposes the subject container and CTS once the TTL window has fully
    /// elapsed since the last event was emitted (i.e. the response reached
    /// terminal status), meaning all buffered events have individually expired.
    /// </summary>
    private void EvictExpired()
    {
        var now = _timeProvider.GetUtcNow();

        foreach (var (id, lastEmitted) in _lastEventEmittedAt)
        {
            var elapsed = now - lastEmitted;

            if (elapsed > _eventStreamTtl)
            {
                if (_subjects.TryRemove(id, out var subject))
                {
                    subject.Dispose();
                }

                if (_cancellationTokenSources.TryRemove(id, out var cts))
                {
                    cts.Dispose();
                }

                _lastEventEmittedAt.TryRemove(id, out _);
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _evictionTimer.Dispose();

        foreach (var subject in _subjects.Values)
        {
            subject.Dispose();
        }
        _subjects.Clear();

        foreach (var cts in _cancellationTokenSources.Values)
        {
            cts.Dispose();
        }
        _cancellationTokenSources.Clear();

        _responses.Clear();
        _lastEventEmittedAt.Clear();
        _itemStore.Clear();
        _inputItemIds.Clear();
        _outputItemIds.Clear();
        _historyItemIds.Clear();
        _conversationResponses.Clear();

        lock (_deletedResponseIds)
        {
            _deletedResponseIds.Clear();
        }
    }

    /// <summary>
    /// Adapter observer that unwraps <c>(long SeqNo, ResponseStreamEvent Event)</c> tuples
    /// from the <see cref="SeekableReplaySubject"/> into bare <see cref="ResponseStreamEvent"/>
    /// values for the external subscriber.
    /// </summary>
    private sealed class UnwrappingObserver : IAsyncObserver<(long SeqNo, ResponseStreamEvent Event)>
    {
        private readonly IAsyncObserver<ResponseStreamEvent> _inner;

        public UnwrappingObserver(IAsyncObserver<ResponseStreamEvent> inner)
        {
            _inner = inner;
        }

        public async ValueTask OnNextAsync((long SeqNo, ResponseStreamEvent Event) value)
        {
            await _inner.OnNextAsync(value.Event).ConfigureAwait(false);
        }

        public ValueTask OnErrorAsync(Exception error) => _inner.OnErrorAsync(error);

        public ValueTask OnCompletedAsync() => _inner.OnCompletedAsync();
    }
}
