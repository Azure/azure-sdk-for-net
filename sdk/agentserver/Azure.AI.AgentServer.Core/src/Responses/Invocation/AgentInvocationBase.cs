// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.CompilerServices;

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation.Stream;
using Microsoft.Extensions.Azure;

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Base class for agent invocations that provides common functionality for executing agents.
/// </summary>
public abstract class AgentInvocationBase : IAgentInvocation
{
    /// <summary>
    /// Executes the agent invocation with streaming support.
    /// </summary>
    /// <param name="context">
    /// The agent run context containing the request, user information, tools, and ID generation.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A tuple containing the stream event generator for the response and an action to perform after invocation.
    /// </returns>
    protected abstract Task<(INestedStreamEventGenerator<Contracts.Generated.Responses.Response> Generator, Func<CancellationToken, Task> PostInvoke)> DoInvokeStreamAsync(
        AgentRunContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Invokes the agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="context">
    /// The agent run context containing the request, user information, tools, and ID generation.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    public abstract Task<Contracts.Generated.Responses.Response> InvokeAsync(
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
    public async IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(
        AgentRunContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var (generator, postInvoke) = await DoInvokeStreamAsync(context, cancellationToken).ConfigureAwait(false);
        await foreach (var group in generator.Generate().WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            await foreach (var e in group.Events.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return e;
            }
        }
        await postInvoke(cancellationToken).ConfigureAwait(false);
    }
}
