// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal.Resilience;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Enhanced implementation of <see cref="ResponseContext"/> that resolves
/// input items and conversation history from the request, using lazy-cached async resolution.
/// Inline items are returned as their <see cref="Item"/> subtypes;
/// item references are resolved via <see cref="ResponsesProvider.GetItemsAsync"/>
/// and converted back to <see cref="Item"/>.
/// </summary>
internal sealed class ResponseContextImpl : ResponseContext
{
    private readonly ResponsesProvider _provider;
    private readonly CreateResponse _request;
    private readonly int _historyLimit;
    private readonly Lazy<Task<IReadOnlyList<Item>>> _inputItemsResolved;
    private readonly Lazy<Task<IReadOnlyList<Item>>> _inputItemsUnresolved;
    private readonly Lazy<Task<IReadOnlyList<string>>> _historyItemIds;
    private readonly Lazy<Task<IReadOnlyList<OutputItem>>> _history;
    private readonly BinaryData? _rawBody;
    private readonly IReadOnlyDictionary<string, string> _clientHeaders;
    private readonly IReadOnlyDictionary<string, StringValues> _queryParameters;
    private readonly PlatformContext _platformContext;
    private readonly bool _steerable;
    private readonly bool _resilientBackground;
    private readonly bool _isRecovery;
    private readonly bool _isSteeredTurn;
    private readonly Func<int>? _pendingInputCountProvider;
    private readonly ResponseObject? _persistedResponse;
    private readonly Lazy<string> _conversationChainId;
    private ConversationChainMetadata _conversationChainMetadata = null!;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseContextImpl"/>.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="provider">The responses provider for resolving item references.</param>
    /// <param name="request">The create-response request containing input items.</param>
    /// <param name="options">Server options for configuration values like history limit.</param>
    /// <param name="rawBody">The full raw JSON request body, or <see langword="null"/> if not available.</param>
    /// <param name="clientHeaders">Forwarded <c>x-client-*</c> headers, or <c>null</c> for empty.</param>
    /// <param name="queryParameters">Query parameters from the request, or <c>null</c> for empty.</param>
    /// <param name="platformContext">The platform context, or <c>null</c> for <see cref="PlatformContext.Empty"/>.</param>
    /// <param name="isRecovery">Whether this is a recovery re-invocation of a previously interrupted background response.</param>
    /// <param name="persistedResponse">The last durable response snapshot from the prior lifetime, exposed via <see cref="ResponseContext.PersistedResponse"/> during recovery.</param>
    /// <param name="isSteeredTurn">Whether this invocation is the drain re-entry following a steering input.</param>
    /// <param name="pendingInputCountProvider">Live provider for the count of queued steering inputs behind this turn, or <c>null</c> when steering is not in effect.</param>
    /// <param name="conversationChainMetadata">The chain-metadata facade to expose; defaults to a fresh in-memory (non-durable) facade when <c>null</c>.</param>
    public ResponseContextImpl(
        string responseId,
        ResponsesProvider provider,
        CreateResponse request,
        IOptions<ResponsesServerOptions>? options = null,
        BinaryData? rawBody = null,
        IReadOnlyDictionary<string, string>? clientHeaders = null,
        IReadOnlyDictionary<string, StringValues>? queryParameters = null,
        PlatformContext? platformContext = null,
        bool isRecovery = false,
        ResponseObject? persistedResponse = null,
        bool isSteeredTurn = false,
        Func<int>? pendingInputCountProvider = null,
        ConversationChainMetadata? conversationChainMetadata = null)
        : base(responseId)
    {
        _rawBody = rawBody;
        _clientHeaders = clientHeaders ?? new Dictionary<string, string>();
        _queryParameters = queryParameters ?? new Dictionary<string, StringValues>();
        _platformContext = platformContext ?? PlatformContext.Empty;
        _provider = provider;
        _request = request;
        _isRecovery = isRecovery;
        _persistedResponse = persistedResponse;
        _isSteeredTurn = isSteeredTurn;
        _pendingInputCountProvider = pendingInputCountProvider;
        _historyLimit = options?.Value.DefaultFetchHistoryCount ?? ResponsesServerOptions.DefaultFetchHistoryCountValue;
        _steerable = options?.Value.SteerableConversations ?? false;
        _resilientBackground = options?.Value.ResilientBackground ?? false;
        _conversationChainId = new Lazy<string>(DeriveConversationChainId);
        _conversationChainMetadata = conversationChainMetadata ?? new ConversationChainMetadata();
        _inputItemsResolved = new Lazy<Task<IReadOnlyList<Item>>>(() => ResolveInputItemsAsync(resolveReferences: true));
        _inputItemsUnresolved = new Lazy<Task<IReadOnlyList<Item>>>(() => ResolveInputItemsAsync(resolveReferences: false));
        _historyItemIds = new Lazy<Task<IReadOnlyList<string>>>(ResolveHistoryItemIdsAsync);
        _history = new Lazy<Task<IReadOnlyList<OutputItem>>>(ResolveHistoryAsync);
    }

    /// <inheritdoc/>
    public override bool IsRecovery => _isRecovery;

    /// <inheritdoc/>
    public override bool IsSteeredTurn => _isSteeredTurn;

    /// <inheritdoc/>
    public override int PendingInputCount => _pendingInputCountProvider?.Invoke() ?? 0;

    /// <inheritdoc/>
    public override ResponseObject? PersistedResponse => _persistedResponse;

    /// <inheritdoc/>
    public override BinaryData? RawBody => _rawBody;

    /// <inheritdoc/>
    public override PlatformContext PlatformContext => _platformContext;

    /// <inheritdoc/>
    public override IReadOnlyDictionary<string, string> ClientHeaders => _clientHeaders;

    /// <inheritdoc/>
    public override IReadOnlyDictionary<string, StringValues> QueryParameters => _queryParameters;

    /// <inheritdoc/>
    public override string ConversationChainId => _conversationChainId.Value;

    /// <inheritdoc/>
    public override ConversationChainMetadata ConversationChainMetadata => _conversationChainMetadata;

    /// <summary>
    /// Swaps in a durable, Core-<c>TaskMetadata</c>-backed metadata facade before the handler runs.
    /// Used by the resilient one-shot path where the endpoint pre-created this context (with a plain,
    /// non-durable facade) for the <c>response.created</c> bridge: the running task owns the durable
    /// checkpoint store, so the handler attaches it here so <see cref="ConversationChainMetadata.FlushAsync"/>
    /// actually persists into the task record. Safe because it runs before any handler write.
    /// </summary>
    internal void AttachDurableConversationChainMetadata(Core.Tasks.TaskMetadata metadata)
    {
        _conversationChainMetadata = new Resilience.DurableConversationChainMetadata(metadata);
    }

    private string DeriveConversationChainId()
    {
        string? conversationId = _request.GetConversationId();
        string? previousResponseId = _request.PreviousResponseId;
        AgentReference? agentReference = _request.AgentReference ?? _request.Agent;
        string agentName = agentReference?.Name is { Length: > 0 } name ? name : "server-default-agent";
        string sessionId = _request.AgentSessionId is { Length: > 0 } sid
            ? sid
            : SessionIdDerivation.Derive(conversationId, previousResponseId, agentReference);

        return ConversationChainIdDerivation.Derive(
            conversationId,
            previousResponseId,
            ResponseId,
            agentName,
            sessionId,
            _steerable);
    }

    /// <inheritdoc/>
    public override Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
        => resolveReferences ? _inputItemsResolved.Value : _inputItemsUnresolved.Value;

    /// <inheritdoc/>
    public override Task ExitForRecoveryAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // A store=false response has no durable state to recover to, so deferral is impossible.
        // Mirror Python's RuntimeError (spec req b): throw rather than silently no-op. This is a
        // hard programming error the orchestrator surfaces as a failure.
        if (_request.Store == false)
        {
            throw new InvalidOperationException(
                "ExitForRecoveryAsync() cannot be called on a store=false response — there is no durable state to recover.");
        }

        // Deferral only applies to resilient background responses (ResilientBackground=true +
        // background=true + store!=false). For any other configuration there is no next-lifetime
        // recovery to defer to, so completing without deferring matches the base no-op contract.
        var isResilientBackground = _resilientBackground
            && _request.Background == true
            && _request.Store != false;

        if (!isResilientBackground)
        {
            return Task.CompletedTask;
        }

        // Record the deferral request BEFORE throwing so that even if a handler wraps this call in a
        // broad catch (swallowing the ResponseExitForRecovery signal), the orchestrator can still
        // observe the intent on a normal handler return and defer identically (FR-036). Mirrors the
        // non-swallowable nature of Python's ResponseExitForRecovery(BaseException).
        DeferralRequested = true;

        // Raise the control signal; the orchestrator catches it, marks the execution deferred, and
        // preserves the last checkpoint snapshot (FR-036). Never returns to the handler.
        throw new ResponseExitForRecovery();
    }

    /// <summary>
    /// Set to <see langword="true"/> by <see cref="ExitForRecoveryAsync"/> on a resilient background
    /// response immediately before it raises <see cref="ResponseExitForRecovery"/>. The orchestrator
    /// checks this on a normal handler return so a handler that swallows the deferral signal with a
    /// broad <c>catch</c> still results in the same durable deferral outcome (in_progress, recovery
    /// entry retained, no pre-terminal overwrite). Mirrors the non-swallowable semantics of Python's
    /// <c>ResponseExitForRecovery(BaseException)</c>.
    /// </summary>
    internal bool DeferralRequested { get; private set; }

    /// <inheritdoc/>
    public override Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
        => _history.Value;

    /// <summary>
    /// Returns the input items as <see cref="OutputItem"/> for persistence.
    /// The orchestrator needs output items when creating the stored response.
    /// </summary>
    internal async Task<IReadOnlyList<OutputItem>> GetInputItemsForPersistenceAsync()
    {
        var items = await GetInputItemsAsync(resolveReferences: true).ConfigureAwait(false);
        return items
            .Select(item => ItemConversion.ToOutputItem(item, ResponseId))
            .Where(item => item is not null)
            .Select(item => item!)
            .ToList();
    }

    /// <summary>
    /// Gets the cached history item IDs. Used by the orchestrator to pass IDs
    /// to <see cref="ResponsesProvider.CreateResponseAsync"/> without duplicating storage.
    /// </summary>
    internal Task<IReadOnlyList<string>> GetHistoryItemIdsAsync()
        => _historyItemIds.Value;

    private async Task<IReadOnlyList<Item>> ResolveInputItemsAsync(bool resolveReferences)
    {
        var input = _request.GetInputExpanded();
        if (input.Count == 0)
        {
            return Array.Empty<Item>();
        }

        if (!resolveReferences)
        {
            // Return items as-is (including ItemReferenceParam)
            return input;
        }

        var results = new List<Item>();

        // Collect item references for batch resolution
        var referenceIds = new List<string>();
        var referencePositions = new List<int>(); // track insertion positions

        int position = 0;
        foreach (var item in input)
        {
            if (item is ItemReferenceParam reference)
            {
                referenceIds.Add(reference.Id);
                referencePositions.Add(position);
                results.Add(null!); // placeholder
            }
            else
            {
                results.Add(item);
            }

            position++;
        }

        // Batch-resolve references if any
        if (referenceIds.Count > 0)
        {
            var resolved = (await _provider.GetItemsAsync(referenceIds, _platformContext)).ToList();

            for (int i = 0; i < referencePositions.Count; i++)
            {
                var pos = referencePositions[i];
                if (i < resolved.Count && resolved[i] is not null)
                {
                    var converted = ItemConversion.ToItem(resolved[i]!);
                    if (converted is not null)
                    {
                        results[pos] = converted;
                    }
                }
            }

            // Remove unresolved placeholders (nulls remaining from failed references)
            results.RemoveAll(r => r is null);
        }

        return results;
    }

    private async Task<IReadOnlyList<string>> ResolveHistoryItemIdsAsync()
    {
        var previousResponseId = _request.PreviousResponseId;
        var conversationId = _request.GetConversationId();

        if (string.IsNullOrEmpty(previousResponseId) && string.IsNullOrEmpty(conversationId))
        {
            return Array.Empty<string>();
        }

        var ids = await _provider.GetHistoryItemIdsAsync(previousResponseId, conversationId, _historyLimit, _platformContext);
        return ids.ToList();
    }

    private async Task<IReadOnlyList<OutputItem>> ResolveHistoryAsync()
    {
        var ids = await _historyItemIds.Value;
        if (ids.Count == 0)
        {
            return Array.Empty<OutputItem>();
        }

        var items = await _provider.GetItemsAsync(ids, _platformContext);
        return items
            .Where(item => item is not null)
            .Select(item => item!)
            .ToList();
    }
}
