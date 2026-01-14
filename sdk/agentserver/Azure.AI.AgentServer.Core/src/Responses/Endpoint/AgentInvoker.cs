// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.AgentRun;
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
    /// Invokes the agent to create a response based on the context from middleware.
    /// </summary>
    /// <param name="httpContext">The HTTP context containing the AgentRunContext.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>An IResult representing the response or streaming updates.</returns>
    public async Task<IResult> InvokeAsync(HttpContext httpContext, CancellationToken ct = default)
    {
        // Retrieve context from middleware
        var context = httpContext.Items["AgentRunContext"] as AgentRunContext
            ?? throw new InvalidOperationException("AgentRunContext not found in HttpContext. Ensure AgentRunContextMiddleware is registered.");

        // Extract request ID from headers if present
        var requestId = httpContext.Request.Headers.TryGetValue("X-Request-Id", out var value) ? value.ToString() : null;

        logger.LogInformation($"Processing CreateResponse request: response_id={context.ResponseId}, "
                              + $"conversation_id={context.ConversationId}, streaming={context.Stream}, "
                              + $"request_id={requestId}.");
        try
        {
            if (context.Stream)
            {
                logger.LogInformation("Invoking agent to create streaming response.");
                return InvokeStreamAsync(context, ct);
            }

            logger.LogInformation("Invoking agent to create response.");
            return await InvokeNonStreamAsync(context, ct).ConfigureAwait(false);
        }
        finally
        {
            logger.LogInformation($"End of processing CreateResponse request: response_id={context.ResponseId}, "
                                  + $"conversation_id={context.ConversationId}, streaming={context.Stream}, "
                                  + $"request_id={requestId}.");
        }
    }

    private async Task<IResult> InvokeNonStreamAsync(AgentRunContext context, CancellationToken ct)
    {
        try
        {
            var response = await agentInvocation.InvokeAsync(context, ct).ConfigureAwait(false);
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

    private SseResult InvokeStreamAsync(AgentRunContext context, CancellationToken ct)
    {
        var updates = agentInvocation.InvokeStreamAsync(context, ct);
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
