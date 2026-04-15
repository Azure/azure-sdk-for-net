// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Extension methods that centralize all mutations to the <see cref="Response"/> object,
/// ensuring consistent terminal state regardless of delivery mode.
/// </summary>
internal static class ResponseMutations
{
    /// <summary>
    /// Transitions the response to <see cref="ResponseStatus.Completed"/>.
    /// Sets <c>CompletedAt</c> and <c>Usage</c> (if provided).
    /// </summary>
    internal static void SetCompleted(this Models.ResponseObject response, ResponseUsage? usage = null)
    {
        response.Status = ResponseStatus.Completed;
        response.CompletedAt = DateTimeOffset.UtcNow;

        if (usage is not null)
        {
            response.Usage = usage;
        }
    }

    /// <summary>
    /// Transitions the response to <see cref="ResponseStatus.Cancelled"/>.
    /// Clears <c>Output</c> to an empty list.
    /// Does NOT set <c>CompletedAt</c> (cancelled responses have no completion timestamp).
    /// </summary>
    internal static void SetCancelled(this Models.ResponseObject response, ResponseUsage? usage = null)
    {
        response.Status = ResponseStatus.Cancelled;
        response.Output.Clear();

        if (usage is not null)
        {
            response.Usage = usage;
        }
    }

    /// <summary>
    /// Transitions the response to <see cref="ResponseStatus.Failed"/>.
    /// Sets <c>Error</c> with the given code and message,
    /// and <c>Usage</c> (if provided).
    /// </summary>
    internal static void SetFailed(
        this Models.ResponseObject response,
        ResponseErrorCode code = ResponseErrorCode.ServerError,
        string message = ApiErrorFactory.GenericServerErrorMessage,
        ResponseUsage? usage = null)
    {
        response.Status = ResponseStatus.Failed;
        response.Error = new Models.ResponseErrorInfo(code, message);

        if (usage is not null)
        {
            response.Usage = usage;
        }
    }

    /// <summary>
    /// Transitions the response to <see cref="ResponseStatus.Failed"/> using the
    /// error details from the given exception. Delegates to
    /// <see cref="ApiErrorFactory.ToResponseError"/> for exception → error mapping.
    /// </summary>
    internal static void SetFailed(this Models.ResponseObject response, Exception exception, ResponseUsage? usage = null)
    {
        response.Status = ResponseStatus.Failed;
        response.Error = ApiErrorFactory.ToResponseError(exception);

        if (usage is not null)
        {
            response.Usage = usage;
        }
    }

    /// <summary>
    /// Transitions the response to <see cref="ResponseStatus.Incomplete"/>.
    /// Sets <c>IncompleteDetails</c> if a reason is provided
    /// and <c>Usage</c> (if provided).
    /// Does NOT set <c>CompletedAt</c> — per B6, only <c>completed</c> status has a non-null <c>CompletedAt</c>.
    /// </summary>
    internal static void SetIncomplete(
        this Models.ResponseObject response,
        ResponseIncompleteDetailsReason? reason = null,
        ResponseUsage? usage = null)
    {
        response.Status = ResponseStatus.Incomplete;

        if (reason is not null)
        {
            response.IncompleteDetails = new ResponseIncompleteDetails { Reason = reason };
        }

        if (usage is not null)
        {
            response.Usage = usage;
        }
    }

    /// <summary>
    /// Updates the response from a handler-yielded event. Handles output item
    /// accumulation via <see cref="SetOutputItemAtIndex"/> for <c>output_item.*</c>
    /// events only. The SDK does not auto-set terminal status or <c>CompletedAt</c>;
    /// the handler is the sole source of truth for all non-SDK-managed properties.
    /// </summary>
    /// <remarks>
    /// Non-output field copying for <c>response.*</c> events is handled by
    /// <see cref="ReplaceResponse"/> (full replacement — B37). Terminal status
    /// consistency is enforced by validation in the orchestrator pipeline.
    /// </remarks>
    internal static void UpdateFromEvent(this Models.ResponseObject response, ResponseStreamEvent evt)
    {
        switch (evt)
        {
            case ResponseOutputItemAddedEvent itemAdded when itemAdded.Item is not null:
                response.Output.SetOutputItemAtIndex((int)itemAdded.OutputIndex, itemAdded.Item);
                break;
            case ResponseOutputItemDoneEvent itemDone when itemDone.Item is not null:
                response.Output.SetOutputItemAtIndex((int)itemDone.OutputIndex, itemDone.Item);
                break;
        }
    }

    /// <summary>
    /// Copies non-output mutable fields from <paramref name="source"/> to
    /// <paramref name="target"/>. Used for SDK-driven terminal mutations
    /// (cancel, failure, shutdown) where the SDK constructs a terminal response
    /// without an event's embedded <see cref="Response"/> to replace with.
    /// </summary>
    /// <remarks>
    /// Not used by <see cref="UpdateFromEvent"/> — handler-yielded <c>response.*</c>
    /// events use <see cref="ReplaceResponse"/> for full replacement (B37).
    /// </remarks>
    internal static void CopyTerminalFields(Models.ResponseObject source, Models.ResponseObject target)
    {
        target.CompletedAt = source.CompletedAt;
        target.Error = source.Error;
        target.IncompleteDetails = source.IncompleteDetails;
        target.Usage = source.Usage;
    }

    /// <summary>
    /// Replaces <see cref="ResponseExecution.Response"/> with a snapshot (deep clone) of the
    /// <see cref="Response"/> carried by any <c>response.*</c> event, making the handler's
    /// event the single source of truth. Snapshotting breaks shared references between
    /// handler-owned and SDK-owned Response objects.
    /// </summary>
    internal static void ReplaceResponse(ResponseExecution execution, ResponseStreamEvent evt)
    {
        var response = evt switch
        {
            ResponseCreatedEvent created => created.Response,
            ResponseInProgressEvent inProgress => inProgress.Response,
            ResponseCompletedEvent completed => completed.Response,
            ResponseFailedEvent failed => failed.Response,
            ResponseIncompleteEvent incomplete => incomplete.Response,
            ResponseQueuedEvent queued => queued.Response,
            _ => null,
        };

        if (response is not null)
        {
            execution.Response = response.Snapshot();
        }
    }

    /// <summary>
    /// Stamps the SDK-managed <c>AgentReference</c> property (B21) on
    /// <see cref="ResponseExecution.Response"/> after a <see cref="ReplaceResponse"/>
    /// call. This is the only property the SDK auto-stamps on the Response;
    /// all other properties (Model, Status, Metadata, Instructions) are owned
    /// by the handler.
    /// </summary>
    internal static void StampAgentReference(ResponseExecution execution, CreateResponse request)
    {
        if (request.AgentReference is not null)
        {
            execution.Response!.AgentReference = request.AgentReference;
        }
    }

    /// <summary>
    /// Stamps the resolved <c>AgentSessionId</c> on the response after a
    /// <see cref="ReplaceResponse"/> call. The session ID is resolved during
    /// request processing (B39): request payload → environment variable → generated UUID.
    /// </summary>
    internal static void StampAgentSessionId(ResponseExecution execution, CreateResponse request)
    {
        if (!string.IsNullOrEmpty(request.AgentSessionId))
        {
            execution.Response!.AgentSessionId = request.AgentSessionId;
        }
    }

    /// <summary>
    /// Re-stamps the request echo-through fields (<c>Background</c>,
    /// <c>PreviousResponseId</c>, <c>Conversation</c>) on the response after
    /// a <see cref="ReplaceResponse"/> call (S-040). The handler's
    /// <c>ReplaceResponse</c> may construct the response object any way it
    /// wants, so the SDK must guarantee these fields always reflect the
    /// original request values.
    /// </summary>
    internal static void StampRequestEchoFields(ResponseExecution execution, CreateResponse request)
    {
        execution.Response!.Background = request.Background;
        execution.Response!.PreviousResponseId = request.PreviousResponseId;

        var conversationId = request.GetConversationId();
        execution.Response!.Conversation = conversationId != null
            ? new ConversationReference(conversationId)
            : null;
    }

    /// <summary>
    /// Sets an output item at the given index, padding the list with nulls if needed.
    /// </summary>
    internal static void SetOutputItemAtIndex(this IList<OutputItem> output, int index, OutputItem item)
    {
        while (output.Count <= index)
        {
            output.Add(null!);
        }

        output[index] = item;
    }

    /// <summary>
    /// Auto-stamps <c>ResponseId</c> and <c>AgentReference</c> on output items
    /// carried by <see cref="ResponseOutputItemAddedEvent"/> and
    /// <see cref="ResponseOutputItemDoneEvent"/> events (Layer 2 stamping).
    /// Idempotent — if Layer 1 already stamped, this is a no-op.
    /// </summary>
    internal static void ApplyOutputItemAutoStamps(
        ResponseStreamEvent evt,
        string responseId,
        AgentReference? agentReference)
    {
        var item = evt switch
        {
            ResponseOutputItemAddedEvent added => added.Item,
            ResponseOutputItemDoneEvent done => done.Item,
            _ => null,
        };

        if (item is null)
        {
            return;
        }

        if (string.IsNullOrEmpty(item.ResponseId))
        {
            item.ResponseId = responseId;
        }

        if (item.AgentReference is null && agentReference is not null)
        {
            item.AgentReference = agentReference;
        }
    }
}
