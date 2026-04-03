// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// HTTP-backed implementation of <see cref="ResponsesProvider"/> that persists
/// state to the Azure AI Foundry storage API.
/// The storage base URL is derived from <c>FOUNDRY_PROJECT_ENDPOINT</c> + <c>/storage</c>
/// (rewritten by <see cref="BaseUrlRewriteHandler"/>).
/// </summary>
internal sealed class FoundryStorageProvider : ResponsesProvider
{
    internal const string HttpClientName = "FoundryStorage";
    private const string ApiVersion = "v1";

    /// <summary>
    /// Sentinel base URL used as a placeholder in outbound requests.
    /// <see cref="BaseUrlRewriteHandler"/> replaces this with the actual storage base URL.
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
    /// The placeholder base URL is rewritten by <see cref="BaseUrlRewriteHandler"/>.
    /// </summary>
    private string Url(string path, string? extraQuery = null)
    {
        var sep = path.Contains('?') ? '&' : '?';
        var url = $"{PlaceholderBaseUrl}{path}{sep}api-version={Uri.EscapeDataString(ApiVersion)}";
        return extraQuery is not null ? $"{url}&{extraQuery}" : url;
    }

    /// <summary>
    /// Applies isolation key headers to an outbound HTTP request when present.
    /// </summary>
    private static void ApplyIsolationHeaders(HttpRequestMessage request, IsolationContext isolation)
    {
        if (ReferenceEquals(isolation, IsolationContext.Empty))
        {
            return;
        }

        if (isolation.UserIsolationKey is not null)
        {
            request.Headers.TryAddWithoutValidation(IsolationContext.UserIsolationKeyHeaderName, isolation.UserIsolationKey);
        }

        if (isolation.ChatIsolationKey is not null)
        {
            request.Headers.TryAddWithoutValidation(IsolationContext.ChatIsolationKeyHeaderName, isolation.ChatIsolationKey);
        }
    }

    /// <inheritdoc/>
    public override async Task CreateResponseAsync(
        CreateResponseRequest request,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        using var content = StorageEnvelopeSerializer.SerializeCreateRequest(request);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Post, Url("responses")) { Content = content };
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
    }

    /// <inheritdoc/>
    public override async Task<Models.ResponseObject> GetResponseAsync(
        string responseId,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Get, Url($"responses/{Uri.EscapeDataString(responseId)}"));
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return StorageEnvelopeSerializer.DeserializeResponse(body);
    }

    /// <inheritdoc/>
    public override async Task UpdateResponseAsync(
        Models.ResponseObject response,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        using var content = StorageEnvelopeSerializer.SerializeResponse(response);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Post, Url($"responses/{Uri.EscapeDataString(response.Id)}")) { Content = content };
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
    }

    /// <inheritdoc/>
    public override async Task DeleteResponseAsync(
        string responseId,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Delete, Url($"responses/{Uri.EscapeDataString(responseId)}"));
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
    }

    /// <inheritdoc/>
    public override async Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        IsolationContext isolation,
        int limit = 20,
        bool ascending = false,
        string? after = null,
        string? before = null,
        CancellationToken cancellationToken = default)
    {
        var order = ascending ? "asc" : "desc";
        var query = $"limit={limit}&order={order}";
        if (after is not null)
            query += $"&after={Uri.EscapeDataString(after)}";
        if (before is not null)
            query += $"&before={Uri.EscapeDataString(before)}";

        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Get, Url($"responses/{Uri.EscapeDataString(responseId)}/input_items", query));
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return StorageEnvelopeSerializer.DeserializePagedItems(body);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var ids = itemIds.ToList();
        using var content = StorageEnvelopeSerializer.SerializeBatchRequest(ids);
        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Post, Url("items/batch/retrieve")) { Content = content };
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return StorageEnvelopeSerializer.DeserializeItemsArray(body);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var query = $"limit={limit}";
        if (previousResponseId is not null)
            query += $"&previous_response_id={Uri.EscapeDataString(previousResponseId)}";
        if (conversationId is not null)
            query += $"&conversation_id={Uri.EscapeDataString(conversationId)}";

        var http = _httpClientFactory.CreateClient(HttpClientName);
        using var msg = new HttpRequestMessage(HttpMethod.Get, Url("history/item_ids", query));
        ApplyIsolationHeaders(msg, isolation);
        using var httpResponse = await http.SendAsync(msg, cancellationToken);
        await StorageErrorMapper.ThrowIfErrorAsync(httpResponse, cancellationToken);
        var body = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        return StorageEnvelopeSerializer.DeserializeHistoryIds(body);
    }
}
