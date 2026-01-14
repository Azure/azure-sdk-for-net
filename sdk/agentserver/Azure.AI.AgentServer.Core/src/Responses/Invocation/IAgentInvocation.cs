// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Core.AgentRun;

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Defines the contract for agent invocation implementations.
/// </summary>
public interface IAgentInvocation
{
    /// <summary>
    /// Invokes the agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="context">
    /// The agent run context containing the request, user information, tools, and ID generation.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    Task<Contracts.Generated.Responses.Response> InvokeAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Invokes the agent asynchronously with streaming support.
    /// </summary>
    /// <param name="context">
    /// The agent run context containing the request, user information, tools, and ID generation.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An async enumerable of response stream events.</returns>
    IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(
        AgentRunContext context,
        CancellationToken cancellationToken = default);
}
