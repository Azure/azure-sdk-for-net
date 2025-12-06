using System.Diagnostics;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent;
using Azure.AI.AgentServer.Core.Telemetry;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Invocation;

internal class AgentInvoker(
    IAgentInvocation agentInvocation,
    ILogger<AgentInvoker> logger)
{
    /// <summary>
    /// Invokes the agent to create a response based on the request and context.
    /// </summary>
    /// <param name="requestId">The optional request ID for tracing.</param>
    /// <param name="request">The create response request.</param>
    /// <param name="context">The agent invocation context.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An IResult representing the response or streaming updates.</returns>
    public async Task<IResult> InvokeAsync(string? requestId,
        CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken ct = default)
    {
        logger.LogInformation($"Processing CreateResponse request: response_id={context.ResponseId}, "
                              + $"conversation_id={context.ConversationId}, streaming={request.Stream ?? false}, "
                              + $"request_id={requestId}.");
        try
        {
            if (request.Stream ?? false)
            {
                logger.LogInformation("Invoking agent to create streaming response.");
                return InvokeStreamAsync(request, context, ct);
            }

            logger.LogInformation("Invoking agent to create response.");
            return await InvokeNonStreamAsync(request, context, ct).ConfigureAwait(false);
        }
        finally
        {
            logger.LogInformation($"End of processing CreateResponse request: response_id={context.ResponseId}, "
                                  + $"conversation_id={context.ConversationId}, streaming={request.Stream ?? false}, "
                                  + $"request_id={requestId}.");
        }
    }

    private async Task<IResult> InvokeNonStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken ct)
    {
        try
        {
            var response = await agentInvocation.InvokeAsync(request, context, ct).ConfigureAwait(false);
            return Results.Json(response);
        }
        catch (Exception e)
        {
            Activity.Current?.AddException(e);
            Contracts.Generated.OpenAI.ResponseError err = null!;

            if (e is AgentInvocationException aie)
            {
                err = aie.Error;
            }
            else
            {
                err = new Contracts.Generated.OpenAI.ResponseError(
                    code: ResponseErrorCode.ServerError, message: e.Message);
            }

            Activity.Current?.SetResponsesTag("error.code", err.Code)
                .SetResponsesTag("error.message", err.Message);

            return Results.Json(err);
        }
    }

    private SseResult InvokeStreamAsync(CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken ct)
    {
        var updates = agentInvocation.InvokeStreamAsync(request, context, ct);
        return ReadUpdates(updates, ct).ToSseResult(
            e => SseFrame.Of(name: e.Type.ToString(), data: e),
            logger,
            ct);

        async IAsyncEnumerable<ResponseStreamEvent> ReadUpdates(IAsyncEnumerable<ResponseStreamEvent> source,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var seq = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using var _ = enumerator.ConfigureAwait(false);

            while (true)
            {
                ResponseStreamEvent streamEvent = null!;
                try
                {
                    if (!await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        break;
                    }
                    ++seq;
                    streamEvent = enumerator.Current;
                }
                catch (Exception e)
                {
                    Activity.Current?.AddException(e);
                    var code = nameof(ResponseErrorCode.ServerError);
                    var message = e.Message;

                    if (e is AgentInvocationException aie)
                    {
                        code = nameof(aie.Error.Code);
                        message = aie.Error.Message;
                    }

                    Activity.Current?.SetResponsesTag("error.code", code)
                        .SetResponsesTag("error.message", message);

                    streamEvent = new ResponseErrorEvent(seq, code, message, string.Empty);
                }

                yield return streamEvent;

                if (streamEvent is ResponseErrorEvent)
                {
                    break;
                }
            }
        }
    }
}
