// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// HTTP-backed implementation of <see cref="IResponsesProvider"/> that persists
/// state to the Azure AI Foundry storage API.
/// The actual storage URL is provided per-request via the
/// <c>x-agent-storage-callback-url</c> header (rewritten by <see cref="BaseUrlRewriteHandler"/>).
/// </summary>
internal sealed class FoundryStorageProvider : IResponsesProvider
{
    private const string HttpClientName = "FoundryStorage";
    private const string ApiVersion = "1.0";

    /// <summary>
    /// Sentinel base URL used as a placeholder in outbound requests.
    /// <see cref="BaseUrlRewriteHandler"/> replaces this with the per-request header value.
    /// </summary>
    internal const string PlaceholderBaseUrl = "https://placeholder.invalid/";

    private readonly IHttpClientFactory _httpClientFactory;

    /// <summary>
    /// Initializes a new instance of <see cref="FoundryStorageProvider"/>.
    /// </summary>
    public FoundryStorageProvider(
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    /// <summary>
    /// Builds a full URL with the <c>api-version</c> query parameter appended.
    /// The placeholder base URL is rewritten per-request by <see cref="BaseUrlRewriteHandler"/>.
    /// </summary>
    private string Url(string path, string? extraQuery = null)
    {
        var sep = path.Contains('?') ? '&' : '?';
        var url = $"{PlaceholderBaseUrl}{path}{sep}api-version={Uri.EscapeDataString(ApiVersion)}";
        return extraQuery is not null ? $"{url}&{extraQuery}" : url;
    }

    /// <inheritdoc/>
    public async Task CreateResponseAsync(
        CreateResponseRequest request,
        CancellationToken cancellationToken = default)
    {
        var content = StorageEnvelopeSerializer.SerializeCreateRequest(request);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.PostAsync(Url("storage/responses"), content, cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Models.Response> GetResponseAsync(
        string responseId,
        CancellationToken cancellationToken = default)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.GetAsync(
            Url($"storage/responses/{Uri.EscapeDataString(responseId)}"),
            cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return StorageEnvelopeSerializer.DeserializeResponse(body);
    }

    /// <inheritdoc/>
    public async Task UpdateResponseAsync(
        Models.Response response,
        CancellationToken cancellationToken = default)
    {
        var content = StorageEnvelopeSerializer.SerializeResponse(response);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.PostAsync(
            Url($"storage/responses/{Uri.EscapeDataString(response.Id)}"),
            content, cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task DeleteResponseAsync(
        string responseId,
        CancellationToken cancellationToken = default)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.DeleteAsync(
            Url($"storage/responses/{Uri.EscapeDataString(responseId)}"),
            cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        int limit = 20,
        bool ascending = false,
        string? after = null,
        string? before = null,
        CancellationToken cancellationToken = default)
    {
        var order = ascending ? "asc" : "desc";
        var query = $"limit={limit}&order={order}";
        if (after is not null) query += $"&after={Uri.EscapeDataString(after)}";
        if (before is not null) query += $"&before={Uri.EscapeDataString(before)}";

        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.GetAsync(
            Url($"storage/responses/{Uri.EscapeDataString(responseId)}/input_items", query),
            cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return StorageEnvelopeSerializer.DeserializePagedItems(body);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        CancellationToken cancellationToken = default)
    {
        var ids = itemIds.ToList();
        var content = StorageEnvelopeSerializer.SerializeBatchRequest(ids);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.PostAsync(Url("storage/items/batch/retrieve"), content, cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return StorageEnvelopeSerializer.DeserializeItemsArray(body);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        CancellationToken cancellationToken = default)
    {
        var query = $"limit={limit}";
        if (previousResponseId is not null) query += $"&previous_response_id={Uri.EscapeDataString(previousResponseId)}";
        if (conversationId is not null) query += $"&conversation_id={Uri.EscapeDataString(conversationId)}";

        var http = _httpClientFactory.CreateClient(HttpClientName);
        var httpResponse = await http.GetAsync(
            Url("storage/history/item_ids", query), cancellationToken).ConfigureAwait(false);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken).ConfigureAwait(false);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return StorageEnvelopeSerializer.DeserializeHistoryIds(body);
    }
}
