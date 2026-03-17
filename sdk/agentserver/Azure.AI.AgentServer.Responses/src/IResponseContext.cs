using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Provides the handler with the response identifier and ID-generation helpers.
/// The handler communicates state exclusively through events yielded from
/// <see cref="ResponseEventStream"/>; the mutable <c>Response</c> object is
/// not exposed.
/// </summary>
public interface IResponseContext
{
    /// <summary>Gets the unique response identifier.</summary>
    string ResponseId { get; }

    /// <summary>
    /// Gets or sets whether the server is shutting down.
    /// Handlers can use this to distinguish shutdown from explicit cancel or client disconnect.
    /// </summary>
    bool IsShutdownRequested { get; set; }

    /// <summary>
    /// Gets the full raw JSON request body as a <see cref="JsonElement"/>.
    /// Allows handlers to access custom or extension fields that are not part of the typed model.
    /// Returns <c>default(JsonElement)</c> when no raw body is available (e.g., test-constructed contexts).
    /// </summary>
    JsonElement RawBody { get; }

    /// <summary>
    /// Resolves and returns the input items for the current request.
    /// Inline items are converted to <see cref="OutputItem"/> instances;
    /// item references are resolved via the provider. Results are cached
    /// after the first call.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The resolved input items.</returns>
    Task<IReadOnlyList<OutputItem>> GetInputItemsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resolves and returns the conversation history items for the current request.
    /// History is fetched from the provider using <c>previous_response_id</c> and/or
    /// <c>conversation</c> context. Items are returned in ascending (chronological) order.
    /// Results are cached after the first call.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The resolved history items, or an empty list if no conversation context exists.</returns>
    Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default);
}
