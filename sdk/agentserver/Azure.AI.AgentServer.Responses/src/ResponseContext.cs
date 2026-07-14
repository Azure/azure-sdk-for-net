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
    /// Gets the platform-injected identity context for this request.
    /// Handlers use the user ID key to scope per-user state, and the SDK forwards
    /// the per-request call ID to Foundry platform services. Returns
    /// <see cref="PlatformContext.Empty"/> when the platform headers are absent
    /// (e.g., local development).
    /// </summary>
    public virtual PlatformContext PlatformContext { get; } = PlatformContext.Empty;

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

    /// <summary>
    /// Gets whether this handler invocation is a recovery re-invocation of a previously
    /// interrupted background response (only possible when
    /// <see cref="ResponsesServerOptions.ResilientBackground"/> is enabled). When
    /// <see langword="true"/>, <see cref="PersistedResponse"/> carries the last durable
    /// snapshot from the prior lifetime and request-scoped inputs are restored from the
    /// persisted recovery payload. When <see langword="false"/> (the default), this is a
    /// fresh invocation.
    /// </summary>
    public virtual bool IsRecovery => false;

    /// <summary>
    /// Gets the last durable response snapshot persisted before the current lifetime, or
    /// <see langword="null"/> when this is not a recovery invocation
    /// (<see cref="IsRecovery"/> is <see langword="false"/>). Handlers can use this to
    /// resume from the last checkpointed watermark rather than restarting work.
    /// </summary>
    public virtual ResponseObject? PersistedResponse => null;

    /// <summary>
    /// Gets the stable conversation-chain identifier for this response. The value is stable
    /// across turns of the same conversation and across recovery re-invocations, allowing
    /// handlers to scope durable per-conversation state.
    /// </summary>
    public virtual string ConversationChainId => ResponseId;

    /// <summary>
    /// Gets the named-namespace metadata facade for durable, explicitly-flushed
    /// per-conversation-chain metadata. Values are buffered until
    /// <see cref="ConversationChainMetadata.FlushAsync"/> is called, at which point they are
    /// persisted into the response snapshot so they survive crash/recovery. Names and keys
    /// beginning with <c>_</c> are reserved and rejected.
    /// </summary>
    public virtual ConversationChainMetadata ConversationChainMetadata { get; } = new ConversationChainMetadata();

    /// <summary>
    /// Gets whether the current invocation is draining steering input (additional input that
    /// arrived mid-turn for the same conversation) rather than starting a fresh turn. Only
    /// meaningful when <see cref="ResponsesServerOptions.SteerableConversations"/> is enabled.
    /// </summary>
    public virtual bool IsSteeredTurn => false;

    /// <summary>
    /// Gets the number of steering input envelopes currently queued for the running handler
    /// to drain. Zero when steering is disabled or no additional input is pending.
    /// </summary>
    public virtual int PendingInputCount => 0;

    /// <summary>
    /// Gets whether the client has explicitly cancelled this response. Distinct from
    /// <see cref="IsShutdownRequested"/> (server shutting down) and client disconnect;
    /// handlers can use this to stop work in response to an explicit cancel request.
    /// </summary>
    public virtual bool ClientCancelled => false;

    /// <summary>
    /// Defers the current handler invocation for recovery instead of failing. Used during a
    /// graceful shutdown (Path B) or cooperative hand-off so that a resilient background
    /// response is re-invoked in a subsequent process lifetime with its durable snapshot and
    /// checkpoint watermark preserved, rather than transitioning to a failed terminal state.
    /// Has an effect only for resilient background responses; for non-resilient responses it
    /// completes without deferring.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that completes once the deferral has been recorded.</returns>
    public virtual Task ExitForRecoveryAsync(CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
