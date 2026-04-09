// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Primitives;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides the handler with the response identifier, raw body, input items,
/// conversation history, and forwarded client metadata.
/// The handler communicates state exclusively through events yielded from
/// <see cref="ResponseEventStream"/>; the mutable <c>Response</c> object is
/// not exposed.
/// </summary>
public class ResponseContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResponseContext"/> with the given response ID.
    /// All other properties use safe defaults (empty body, empty collections).
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    public ResponseContext(string responseId)
    {
        Argument.AssertNotNull(responseId, nameof(responseId));
        ResponseId = responseId;
    }

    /// <summary>Gets the unique response identifier.</summary>
    public string ResponseId { get; }

    /// <summary>
    /// Gets or sets whether the server is shutting down.
    /// Handlers can use this to distinguish shutdown from explicit cancel or client disconnect.
    /// </summary>
    public bool IsShutdownRequested { get; set; }

    /// <summary>
    /// Gets the full raw JSON request body as a <see cref="BinaryData"/>.
    /// Allows handlers to access custom or extension fields that are not part of the typed model.
    /// Returns <see langword="null"/> when no raw body is available (e.g., test-constructed contexts).
    /// </summary>
    public virtual BinaryData? RawBody => null;

    /// <summary>
    /// Resolves and returns the input items for the current request.
    /// Inline items are returned as their <see cref="Item"/> subtypes;
    /// item references are optionally resolved via the provider and converted
    /// to <see cref="Item"/> subtypes. Results are cached after the first call
    /// for each <paramref name="resolveReferences"/> mode.
    /// </summary>
    /// <param name="resolveReferences">
    /// When <c>true</c> (the default), <see cref="Models.ItemReferenceParam"/> items
    /// are resolved via the provider and returned as their concrete <see cref="Item"/> subtype.
    /// When <c>false</c>, item references are left as <see cref="Models.ItemReferenceParam"/>
    /// in the returned list.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The resolved input items.</returns>
    public virtual Task<IReadOnlyList<Item>> GetInputItemsAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<Item>>(Array.Empty<Item>());

    /// <summary>
    /// Resolves and returns the conversation history items for the current request.
    /// History is fetched from the provider using <c>previous_response_id</c> and/or
    /// <c>conversation</c> context. Items are returned in ascending (chronological) order.
    /// Results are cached after the first call.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The resolved history items, or an empty list if no conversation context exists.</returns>
    public virtual Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());

    /// <summary>
    /// Resolves input items and extracts all text content as a single string.
    /// Filters for <see cref="Models.ItemMessage"/> items, expands their content,
    /// and joins all text values with newline separators.
    /// </summary>
    /// <param name="resolveReferences">
    /// When <c>true</c> (the default), item references are resolved before extracting text.
    /// </param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>
    /// The combined text content, or an empty string if no text content is found.
    /// </returns>
    public virtual async Task<string> GetInputTextAsync(bool resolveReferences = true, CancellationToken cancellationToken = default)
    {
        var items = await GetInputItemsAsync(resolveReferences, cancellationToken).ConfigureAwait(false);
        return items.GetInputText();
    }

    /// <summary>
    /// Gets the platform-injected isolation keys for this request.
    /// Handlers use these opaque partition keys to scope user-private and
    /// conversation-shared state. Returns <see cref="IsolationContext.Empty"/>
    /// when the platform headers are absent (e.g., local development).
    /// </summary>
    public virtual IsolationContext Isolation { get; } = IsolationContext.Empty;

    /// <summary>
    /// Gets the forwarded client headers (those prefixed with <c>x-client-</c>)
    /// from the original HTTP request.
    /// </summary>
    public virtual IReadOnlyDictionary<string, string> ClientHeaders { get; }
        = new Dictionary<string, string>();

    /// <summary>
    /// Gets the query parameters from the original HTTP request.
    /// </summary>
    public virtual IReadOnlyDictionary<string, StringValues> QueryParameters { get; }
        = new Dictionary<string, StringValues>();
}
