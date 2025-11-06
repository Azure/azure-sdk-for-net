using System.Diagnostics;
using System.Runtime.CompilerServices;

using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Telemetry;
using Azure.AI.AgentServer.Responses.Invocation.Stream;

namespace Azure.AI.AgentServer.Responses.Invocation;

/// <summary>
/// Base class for agent invocations that provides common functionality for executing agents.
/// </summary>
public abstract class AgentInvocationBase : IAgentInvocation
{
    /// <summary>
    /// Executes the agent invocation asynchronously.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    protected abstract Task<Contracts.Generated.Responses.Response> DoInvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Executes the agent invocation with streaming support.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A stream event generator for the response.</returns>
    protected abstract INestedStreamEventGenerator<Contracts.Generated.Responses.Response> DoInvokeStreamAsync(
        CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken);

    /// <summary>
    /// Invokes the agent asynchronously and returns a complete response.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The response from the agent.</returns>
    public async Task<Contracts.Generated.Responses.Response> InvokeAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            return await DoInvokeAsync(request, context, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Activity.Current?.AddException(e);

            if (e is AgentInvocationException aie)
            {
                Activity.Current?.SetResponsesTag("error.code", aie.Error.Code)
                    .SetResponsesTag("error.message", aie.Error.Message);
                throw;
            }

            throw new AgentInvocationException(new Contracts.Generated.OpenAI.ResponseError(
                code: ResponseErrorCode.ServerError, message: e.Message));
        }
    }

    /// <summary>
    /// Invokes the agent asynchronously with streaming support.
    /// </summary>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>An async enumerable of response stream events.</returns>
    public async IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var generator = DoInvokeStreamAsync(request, context, cancellationToken);
        await foreach (var group in generator.Generate().WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            await foreach (var e in group.Events.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return e;
            }
        }
    }
}
