// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.AgentServer.Core.Responses.Conversations;

/// <summary>
/// Client for fetching conversation items from the Foundry Conversations API.
/// </summary>
#pragma warning disable AZC0003, AZC0004, AZC0005, AZC0007, AZC0015
public sealed class ConversationItemsClient
{
    private readonly HttpPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly ConversationItemsClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="ConversationItemsClient"/> class.
    /// </summary>
    /// <param name="endpoint">The Foundry project endpoint.</param>
    /// <param name="credential">The credential used for authentication.</param>
    public ConversationItemsClient(
        Uri endpoint,
        TokenCredential credential)
        : this(endpoint, credential, new ConversationItemsClientOptions())
    {
    }

    internal ConversationItemsClient(
        Uri endpoint,
        TokenCredential credential,
        ConversationItemsClientOptions options)
    {
        ArgumentNullException.ThrowIfNull(endpoint);
        ArgumentNullException.ThrowIfNull(credential);
        ArgumentNullException.ThrowIfNull(options);

        _endpoint = EnsureTrailingSlash(endpoint);
        _options = options;
        _pipeline = HttpPipelineBuilder.Build(
            _options,
            Array.Empty<HttpPipelinePolicy>(),
            [
                new BearerTokenAuthenticationPolicy(credential, _options.CredentialScopes.ToArray())
            ],
            new ResponseClassifier());
    }

    /// <summary>
    /// Lists conversation items for the specified conversation.
    /// </summary>
    /// <param name="conversationId">The conversation ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Conversation items ordered by the service response.</returns>
    /// <exception cref="RequestFailedException">Thrown when the service returns an error response.</exception>
    public async Task<IReadOnlyList<ItemResource>> ListItemsAsync(
        string conversationId,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(conversationId);

        using var message = CreateListItemsMessage(conversationId, cancellationToken);
        await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);

        if (message.Response.IsError)
        {
            throw new RequestFailedException(message.Response);
        }

        return await ParseListItemsResponseAsync(message.Response, cancellationToken).ConfigureAwait(false);
    }

    private HttpMessage CreateListItemsMessage(
        string conversationId,
        CancellationToken cancellationToken)
    {
        var relativeUri =
            $"openai/conversations/{Uri.EscapeDataString(conversationId)}/items?api-version={Uri.EscapeDataString(_options.ApiVersion)}";

        var message = _pipeline.CreateMessage(CreateRequestContext(cancellationToken));
        var request = message.Request;
        request.Method = RequestMethod.Get;
        request.Uri.Reset(new Uri(_endpoint, relativeUri));
        request.Headers.Add("Accept", "application/json");
        return message;
    }

    private static async Task<IReadOnlyList<ItemResource>> ParseListItemsResponseAsync(
        Response response,
        CancellationToken cancellationToken)
    {
        if (response.ContentStream == null)
        {
            return Array.Empty<ItemResource>();
        }

        using var document = await JsonDocument.ParseAsync(
                response.ContentStream,
                cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        var root = document.RootElement;
        var itemsElement = root;
        if (root.ValueKind != JsonValueKind.Array && !TryResolveItemsArray(root, out itemsElement))
        {
            return Array.Empty<ItemResource>();
        }

        var items = new List<ItemResource>();
        foreach (var itemElement in itemsElement.EnumerateArray())
        {
            var item = ItemResource.DeserializeItemResource(itemElement);
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }

    private static bool TryResolveItemsArray(JsonElement root, out JsonElement items)
    {
        if (root.TryGetProperty("data", out items) && items.ValueKind == JsonValueKind.Array)
        {
            return true;
        }

        if (root.TryGetProperty("items", out items) && items.ValueKind == JsonValueKind.Array)
        {
            return true;
        }

        items = default;
        return false;
    }

    private static RequestContext? CreateRequestContext(CancellationToken cancellationToken)
    {
        return cancellationToken.CanBeCanceled
            ? new RequestContext { CancellationToken = cancellationToken }
            : null;
    }

    private static Uri EnsureTrailingSlash(Uri endpoint)
    {
        var endpointText = endpoint.ToString();
        return endpointText.EndsWith("/", StringComparison.Ordinal)
            ? endpoint
            : new Uri(endpointText + "/", UriKind.Absolute);
    }
}
#pragma warning restore AZC0003, AZC0004, AZC0005, AZC0007, AZC0015
