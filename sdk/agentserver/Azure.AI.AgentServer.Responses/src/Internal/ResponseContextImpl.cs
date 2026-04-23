// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
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
    private readonly IsolationContext _isolation;

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
    /// <param name="isolation">The platform isolation context, or <c>null</c> for <see cref="IsolationContext.Empty"/>.</param>
    public ResponseContextImpl(
        string responseId,
        ResponsesProvider provider,
        CreateResponse request,
        IOptions<ResponsesServerOptions>? options = null,
        BinaryData? rawBody = null,
        IReadOnlyDictionary<string, string>? clientHeaders = null,
        IReadOnlyDictionary<string, StringValues>? queryParameters = null,
        IsolationContext? isolation = null)
        : base(responseId)
    {
        _rawBody = rawBody;
        _clientHeaders = clientHeaders ?? new Dictionary<string, string>();
        _queryParameters = queryParameters ?? new Dictionary<string, StringValues>();
        _isolation = isolation ?? IsolationContext.Empty;
        _provider = provider;
        _request = request;
        _historyLimit = options?.Value.DefaultFetchHistoryCount ?? ResponsesServerOptions.DefaultFetchHistoryCountValue;
        _inputItemsResolved = new Lazy<Task<IReadOnlyList<Item>>>(() => ResolveInputItemsAsync(resolveReferences: true));
        _inputItemsUnresolved = new Lazy<Task<IReadOnlyList<Item>>>(() => ResolveInputItemsAsync(resolveReferences: false));
        _historyItemIds = new Lazy<Task<IReadOnlyList<string>>>(ResolveHistoryItemIdsAsync);
        _history = new Lazy<Task<IReadOnlyList<OutputItem>>>(ResolveHistoryAsync);
    }

    /// <inheritdoc/>
    public override BinaryData? RawBody => _rawBody;

    /// <inheritdoc/>
    public override IsolationContext Isolation => _isolation;

    /// <inheritdoc/>
    public override IReadOnlyDictionary<string, string> ClientHeaders => _clientHeaders;

    /// <inheritdoc/>
    public override IReadOnlyDictionary<string, StringValues> QueryParameters => _queryParameters;

    /// <inheritdoc/>
    public override Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
        => resolveReferences ? _inputItemsResolved.Value : _inputItemsUnresolved.Value;

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
            var resolved = (await _provider.GetItemsAsync(referenceIds, _isolation)).ToList();

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

        var ids = await _provider.GetHistoryItemIdsAsync(previousResponseId, conversationId, _historyLimit, _isolation);
        return ids.ToList();
    }

    private async Task<IReadOnlyList<OutputItem>> ResolveHistoryAsync()
    {
        var ids = await _historyItemIds.Value;
        if (ids.Count == 0)
        {
            return Array.Empty<OutputItem>();
        }

        var items = await _provider.GetItemsAsync(ids, _isolation);
        return items
            .Where(item => item is not null)
            .Select(item => item!)
            .ToList();
    }
}
