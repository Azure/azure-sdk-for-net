// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Enhanced implementation of <see cref="IResponseContext"/> that resolves
/// input items and conversation history from the request, using lazy-cached async resolution.
/// Inline items are converted via <see cref="ItemConversion"/>; item
/// references are resolved via <see cref="IResponsesProvider.GetItemsAsync"/>.
/// </summary>
internal sealed class ResponseContextImpl : IResponseContext
{
    private readonly IResponsesProvider _provider;
    private readonly CreateResponse _request;
    private readonly int _historyLimit;
    private readonly Lazy<Task<IReadOnlyList<OutputItem>>> _inputItems;
    private readonly Lazy<Task<IReadOnlyList<string>>> _historyItemIds;
    private readonly Lazy<Task<IReadOnlyList<OutputItem>>> _history;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponseContextImpl"/>.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="provider">The responses provider for resolving item references.</param>
    /// <param name="request">The create-response request containing input items.</param>
    /// <param name="options">Server options for configuration values like history limit.</param>
    /// <param name="rawBody">The full raw JSON request body, or <c>default</c> if not available.</param>
    /// <param name="clientHeaders">Forwarded <c>x-client-*</c> headers, or <c>null</c> for empty.</param>
    /// <param name="queryParameters">Query parameters from the request, or <c>null</c> for empty.</param>
    public ResponseContextImpl(
        string responseId,
        IResponsesProvider provider,
        CreateResponse request,
        IOptions<ResponsesServerOptions>? options = null,
        JsonElement rawBody = default,
        IReadOnlyDictionary<string, string>? clientHeaders = null,
        IReadOnlyDictionary<string, StringValues>? queryParameters = null)
    {
        ResponseId = responseId;
        RawBody = rawBody;
        ClientHeaders = clientHeaders ?? new Dictionary<string, string>();
        QueryParameters = queryParameters ?? new Dictionary<string, StringValues>();
        _provider = provider;
        _request = request;
        _historyLimit = options?.Value.DefaultFetchHistoryCount ?? ResponsesServerOptions.DefaultFetchHistoryCountValue;
        _inputItems = new Lazy<Task<IReadOnlyList<OutputItem>>>(ResolveInputItemsAsync);
        _historyItemIds = new Lazy<Task<IReadOnlyList<string>>>(ResolveHistoryItemIdsAsync);
        _history = new Lazy<Task<IReadOnlyList<OutputItem>>>(ResolveHistoryAsync);
    }

    /// <inheritdoc/>
    public string ResponseId { get; }

    /// <inheritdoc/>
    public JsonElement RawBody { get; }

    /// <inheritdoc/>
    public bool IsShutdownRequested { get; set; }

    /// <inheritdoc/>
    public IReadOnlyDictionary<string, string> ClientHeaders { get; }

    /// <inheritdoc/>
    public IReadOnlyDictionary<string, StringValues> QueryParameters { get; }

    /// <inheritdoc/>
    public Task<IReadOnlyList<OutputItem>> GetInputItemsAsync(CancellationToken cancellationToken = default)
        => _inputItems.Value;

    /// <inheritdoc/>
    public Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
        => _history.Value;

    /// <summary>
    /// Gets the cached history item IDs. Used by the orchestrator to pass IDs
    /// to <see cref="IResponsesProvider.CreateResponseAsync"/> without duplicating storage.
    /// </summary>
    internal Task<IReadOnlyList<string>> GetHistoryItemIdsAsync()
        => _historyItemIds.Value;

    private async Task<IReadOnlyList<OutputItem>> ResolveInputItemsAsync()
    {
        var input = _request.GetInputExpanded();
        if (input.Count == 0)
        {
            return Array.Empty<OutputItem>();
        }

        var results = new List<OutputItem>();

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
                var output = ItemConversion.ToOutputItem(item, ResponseId);
                if (output is not null)
                {
                    results.Add(output);
                }
            }

            position++;
        }

        // Batch-resolve references if any
        if (referenceIds.Count > 0)
        {
            var resolved = (await _provider.GetItemsAsync(referenceIds)).ToList();

            for (int i = 0; i < referencePositions.Count; i++)
            {
                var pos = referencePositions[i];
                if (i < resolved.Count && resolved[i] is not null)
                {
                    results[pos] = resolved[i]!;
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

        var ids = await _provider.GetHistoryItemIdsAsync(previousResponseId, conversationId, _historyLimit);
        return ids.ToList();
    }

    private async Task<IReadOnlyList<OutputItem>> ResolveHistoryAsync()
    {
        var ids = await _historyItemIds.Value;
        if (ids.Count == 0)
        {
            return Array.Empty<OutputItem>();
        }

        var items = await _provider.GetItemsAsync(ids);
        return items
            .Where(item => item is not null)
            .Select(item => item!)
            .ToList();
    }
}
