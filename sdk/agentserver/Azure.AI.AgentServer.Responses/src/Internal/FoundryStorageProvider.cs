// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// HTTP-backed implementation of <see cref="ResponsesProvider"/> that persists
/// state to the Azure AI Foundry storage API using an Azure.Core
/// <see cref="HttpPipeline"/> for retry, authentication, telemetry, and tracing.
/// </summary>
internal sealed class FoundryStorageProvider : ResponsesProvider
{
    private const string ApiVersion = "v1";
    private const string JsonContentType = "application/json; charset=utf-8";

    private readonly HttpPipeline _pipeline;
    private readonly Uri _storageBaseUri;

    /// <summary>
    /// Initializes a new instance of <see cref="FoundryStorageProvider"/>.
    /// </summary>
    /// <param name="pipeline">The Azure.Core HTTP pipeline (includes retry, auth, telemetry).</param>
    /// <param name="storageBaseUri">The base URI for the Foundry storage API (e.g. <c>https://host/storage/</c>).</param>
    public FoundryStorageProvider(HttpPipeline pipeline, Uri storageBaseUri)
    {
        _pipeline = pipeline;
        _storageBaseUri = storageBaseUri;
    }

    /// <summary>
    /// Creates an <see cref="HttpMessage"/> with the given method and path,
    /// applying the <c>api-version</c> query parameter.
    /// </summary>
    private HttpMessage CreateRequest(RequestMethod method, string path, string? extraQuery = null)
    {
        var message = _pipeline.CreateMessage();
        var request = message.Request;
        request.Method = method;

        var uri = new RequestUriBuilder();
        uri.Reset(_storageBaseUri);
        uri.AppendPath(path, escape: false);
        uri.AppendQuery("api-version", ApiVersion, escapeValue: true);

        if (extraQuery is not null)
        {
            // Extra query is pre-formatted (e.g. "limit=20&order=desc")
            foreach (var pair in extraQuery.Split('&'))
            {
                var eqIdx = pair.IndexOf('=');
                if (eqIdx > 0)
                {
                    uri.AppendQuery(pair[..eqIdx], pair[(eqIdx + 1)..], escapeValue: false);
                }
            }
        }

        request.Uri = uri;
        return message;
    }

    /// <summary>
    /// Applies isolation key headers to an outbound HTTP request when present.
    /// </summary>
    private static void ApplyIsolationHeaders(Request request, IsolationContext isolation)
    {
        if (ReferenceEquals(isolation, IsolationContext.Empty))
        {
            return;
        }

        if (isolation.UserIsolationKey is not null)
        {
            request.Headers.SetValue(PlatformHeaders.UserIsolationKey, isolation.UserIsolationKey);
        }

        if (isolation.ChatIsolationKey is not null)
        {
            request.Headers.SetValue(PlatformHeaders.ChatIsolationKey, isolation.ChatIsolationKey);
        }
    }

    /// <inheritdoc/>
    public override async Task CreateResponseAsync(
        CreateResponseRequest request,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var body = StorageEnvelopeSerializer.SerializeCreateRequest(request);
        using var message = CreateRequest(RequestMethod.Post, "responses");
        message.Request.Content = RequestContent.Create(body);
        message.Request.Headers.SetValue("Content-Type", JsonContentType);
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);
    }

    /// <inheritdoc/>
    public override async Task<Models.ResponseObject> GetResponseAsync(
        string responseId,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        using var message = CreateRequest(RequestMethod.Get, $"responses/{Uri.EscapeDataString(responseId)}");
        message.Request.Headers.SetValue("Accept", "application/json");
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);

        var body = message.Response.Content.ToString();
        return StorageEnvelopeSerializer.DeserializeResponse(body);
    }

    /// <inheritdoc/>
    public override async Task UpdateResponseAsync(
        Models.ResponseObject response,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var body = StorageEnvelopeSerializer.SerializeResponse(response);
        using var message = CreateRequest(RequestMethod.Post, $"responses/{Uri.EscapeDataString(response.Id)}");
        message.Request.Content = RequestContent.Create(body);
        message.Request.Headers.SetValue("Content-Type", JsonContentType);
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);
    }

    /// <inheritdoc/>
    public override async Task DeleteResponseAsync(
        string responseId,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        using var message = CreateRequest(RequestMethod.Delete, $"responses/{Uri.EscapeDataString(responseId)}");
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);
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

        using var message = CreateRequest(RequestMethod.Get, $"responses/{Uri.EscapeDataString(responseId)}/input_items", query);
        message.Request.Headers.SetValue("Accept", "application/json");
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);

        var body = message.Response.Content.ToString();
        return StorageEnvelopeSerializer.DeserializePagedItems(body);
    }

    /// <inheritdoc/>
    public override async Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        IsolationContext isolation,
        CancellationToken cancellationToken = default)
    {
        var ids = itemIds.ToList();
        var content = StorageEnvelopeSerializer.SerializeBatchRequest(ids);
        using var message = CreateRequest(RequestMethod.Post, "items/batch/retrieve");
        message.Request.Content = RequestContent.Create(content);
        message.Request.Headers.SetValue("Content-Type", JsonContentType);
        message.Request.Headers.SetValue("Accept", "application/json");
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);

        var body = message.Response.Content.ToString();
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

        using var message = CreateRequest(RequestMethod.Get, "history/item_ids", query);
        message.Request.Headers.SetValue("Accept", "application/json");
        ApplyIsolationHeaders(message.Request, isolation);

        await _pipeline.SendAsync(message, cancellationToken);
        StorageErrorMapper.ThrowIfError(message.Response);

        var body = message.Response.Content.ToString();
        return StorageEnvelopeSerializer.DeserializeHistoryIds(body);
    }
}
