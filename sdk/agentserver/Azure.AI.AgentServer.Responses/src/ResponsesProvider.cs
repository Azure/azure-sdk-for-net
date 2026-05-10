// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides pluggable response state persistence for the Responses API server.
/// </summary>
/// <remarks>
/// <para>
/// The SDK delegates all response state operations to the registered
/// <see cref="ResponsesProvider"/>. Consumers extend this class
/// to support custom backends (e.g., Redis, SQL) for
/// multi-instance deployments.
/// </para>
/// <para>
/// For event streaming, extend <see cref="ResponsesStreamProvider"/>.
/// For cancellation signalling, extend <see cref="ResponsesCancellationSignalProvider"/>.
/// </para>
/// <para>
/// When no custom implementation is registered, the SDK provides an
/// in-memory default that is automatically registered by
/// <c>AddResponsesServer()</c>.
/// </para>
/// </remarks>
public abstract class ResponsesProvider
{
    // --- State ---

    /// <summary>
    /// Persists a newly created response along with its resolved input items and history item IDs.
    /// </summary>
    /// <param name="request">The create-response request containing the response snapshot, input items, and history item IDs.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public abstract Task CreateResponseAsync(
        CreateResponseRequest request,
        IsolationContext isolation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a response by its identifier.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The response.</returns>
    /// <exception cref="ResourceNotFoundException">Thrown when the response does not exist.</exception>
    public abstract Task<Models.ResponseObject> GetResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Persists an updated response snapshot. Handles all state transitions
    /// including completion — there is no separate mark-completed operation.
    /// </summary>
    /// <param name="response">The updated response snapshot.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    public abstract Task UpdateResponseAsync(Models.ResponseObject response, IsolationContext isolation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a response envelope by its identifier.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <exception cref="ResourceNotFoundException">Thrown when the response does not exist.</exception>
    public abstract Task DeleteResponseAsync(string responseId, IsolationContext isolation, CancellationToken cancellationToken = default);

    // --- Input Items ---

    /// <summary>
    /// Retrieves a paginated list of input items stored for a response.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="limit">Maximum number of items to return (1–100, default 20).</param>
    /// <param name="ascending">If <c>true</c>, return items in ascending order; otherwise descending.</param>
    /// <param name="after">Cursor: return items after this item ID.</param>
    /// <param name="before">Cursor: return items before this item ID.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A paged result of output items.</returns>
    /// <exception cref="ResourceNotFoundException">Thrown when the response was never created.</exception>
    /// <exception cref="BadRequestException">Thrown when the response has been deleted.</exception>
    public abstract Task<AgentsPagedResultOutputItem> GetInputItemsAsync(
        string responseId,
        IsolationContext isolation,
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
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>Output items matching the requested IDs (null for missing).</returns>
    public abstract Task<IEnumerable<OutputItem?>> GetItemsAsync(
        IEnumerable<string> itemIds,
        IsolationContext isolation,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the list of history item IDs for a conversation chain,
    /// starting from a previous response and/or conversation ID.
    /// </summary>
    /// <param name="previousResponseId">The previous response ID to look up history from, or <c>null</c>.</param>
    /// <param name="conversationId">The conversation ID to scope history, or <c>null</c>.</param>
    /// <param name="limit">Maximum number of history item IDs to return.</param>
    /// <param name="isolation">The platform isolation context. Use <see cref="IsolationContext.Empty"/> when not applicable.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>An enumerable of history item IDs.</returns>
    public abstract Task<IEnumerable<string>> GetHistoryItemIdsAsync(
        string? previousResponseId,
        string? conversationId,
        int limit,
        IsolationContext isolation,
        CancellationToken cancellationToken = default);
}
