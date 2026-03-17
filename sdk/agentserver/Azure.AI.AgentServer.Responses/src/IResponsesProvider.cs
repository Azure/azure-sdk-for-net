// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides pluggable response state persistence for the Responses API server.
/// </summary>
/// <remarks>
/// <para>
/// The SDK delegates all response state operations to the registered
/// <see cref="IResponsesProvider"/>. Consumers implement this interface
/// to support custom backends (e.g., Redis, SQL) for
/// multi-instance deployments.
/// </para>
/// <para>
/// For event streaming, implement <see cref="IResponsesStreamProvider"/>.
/// For cancellation signalling, implement <see cref="IResponsesCancellationSignalProvider"/>.
/// </para>
/// <para>
/// When no custom implementation is registered, the SDK provides an
/// in-memory default that is automatically registered by
/// <c>AddResponsesServer()</c>.
/// </para>
/// </remarks>
public interface IResponsesProvider
{
    // --- State ---

    /// <summary>
    /// Persists a newly created response along with its resolved input items and history item IDs.
    /// </summary>
    /// <param name="response">The response snapshot to store.</param>
    /// <param name="inputItems">The resolved input items for this response, or <c>null</c> if none.</param>
    /// <param name="historyItemIds">The resolved history item IDs, or <c>null</c> if none.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task CreateResponseAsync(
        Response response,
        IEnumerable<OutputItem>? inputItems,
        IEnumerable<string>? historyItemIds,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a response by its identifier.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="ResourceNotFoundException">Thrown when the response does not exist.</exception>
    Task<Response> GetResponseAsync(string responseId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists an updated response snapshot. Handles all state transitions
    /// including completion — there is no separate mark-completed operation.
    /// </summary>
    /// <param name="response">The updated response snapshot.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task UpdateResponseAsync(Response response, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a response envelope by its identifier.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ResourceNotFoundException">Thrown when the response does not exist.</exception>
    Task DeleteResponseAsync(string responseId, CancellationToken cancellationToken = default);

    // --- Input Items ---

    /// <summary>
    /// Retrieves a paginated list of input items stored for a response.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="limit">Maximum number of items to return (1–100, default 20).</param>
    /// <param name="ascending">If <c>true</c>, return items in ascending order; otherwise descending.</param>
    /// <param name="after">Cursor: return items after this item ID.</param>
    /// <param name="before">Cursor: return items before this item ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A paged result of output items.</returns>
    /// <exception cref="ResourceNotFoundException">Thrown when the response was never created.</exception>
    /// <exception cref="BadRequestException">Thrown when the response has been deleted.</exception>
    Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        int limit = 20,
        bool ascending = false,
        string? after = null,
        string? before = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves output items by their identifiers (batch lookup).
    /// Items not found are returned as <c>null</c> entries.
    /// </summary>
    /// <param name="itemIds">The item identifiers to look up.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Output items matching the requested IDs (null for missing).</returns>
    Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of history item IDs for a conversation chain,
    /// starting from a previous response and/or conversation ID.
    /// </summary>
    /// <param name="previousResponseId">The previous response ID to look up history from, or <c>null</c>.</param>
    /// <param name="conversationId">The conversation ID to scope history, or <c>null</c>.</param>
    /// <param name="limit">Maximum number of history item IDs to return.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An enumerable of history item IDs.</returns>
    Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        CancellationToken cancellationToken = default);
}
