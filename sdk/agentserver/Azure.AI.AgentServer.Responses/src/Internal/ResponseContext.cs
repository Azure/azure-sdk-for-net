using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Internal implementation of <see cref="IResponseContext"/>.
/// Exposes only the response identifier — the mutable <c>Response</c> object
/// is not accessible through this type.
/// </summary>
internal sealed class ResponseContext : IResponseContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResponseContext"/> with the given response ID.
    /// </summary>
    /// <param name="responseId">The unique response identifier.</param>
    public ResponseContext(string responseId)
    {
        ResponseId = responseId;
    }

    /// <inheritdoc/>
    public string ResponseId { get; }

    /// <inheritdoc/>
    public bool IsShutdownRequested { get; set; }

    /// <inheritdoc/>
    public JsonElement RawBody => default;

    /// <inheritdoc/>
    public Task<IReadOnlyList<OutputItem>> GetInputItemsAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());

    /// <inheritdoc/>
    public Task<IReadOnlyList<OutputItem>> GetHistoryAsync(CancellationToken cancellationToken = default)
        => Task.FromResult<IReadOnlyList<OutputItem>>(Array.Empty<OutputItem>());
}
