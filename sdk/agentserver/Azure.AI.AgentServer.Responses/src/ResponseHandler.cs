// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Defines the contract for handling response creation requests.
/// Override this class and register it in DI to provide your agent logic.
/// </summary>
public abstract class ResponseHandler
{
    /// <summary>
    /// Processes a response creation request and yields the full event stream.
    /// </summary>
    /// <param name="request">
    /// The pre-processed creation request. Mode flags (<c>stream</c>, <c>background</c>)
    /// have been consumed by the SDK and are not present.
    /// </param>
    /// <param name="context">
    /// Provides the response identifier via <see cref="ResponseContext.ResponseId"/>.
    /// Use <see cref="ResponseEventStream"/> to build and emit events.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that is triggered on client disconnect (in non-background mode)
    /// or explicit cancel request.
    /// </param>
    /// <returns>
    /// An async enumerable of events comprising the full response event stream,
    /// including both lifecycle events and content events.
    /// </returns>
    public abstract IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken);
}
