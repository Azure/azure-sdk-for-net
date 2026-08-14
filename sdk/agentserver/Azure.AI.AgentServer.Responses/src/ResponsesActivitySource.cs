// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// DI-friendly class that propagates response correlation baggage onto the
/// current <see cref="Activity"/> without creating an additional <c>invoke_agent</c> span.
/// W3C trace context propagation is handled automatically by ASP.NET Core, so
/// framework spans are parented directly under the caller's span.
/// <para>
/// The default implementation sets namespaced baggage items (response_id,
/// conversation_id, streaming, x-request-id) so downstream spans inherit them.
/// </para>
/// </summary>
internal class ResponsesActivitySource
{
    /// <summary>
    /// The default <see cref="ActivitySource"/> name (retained for listener registration compatibility).
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Responses";

    /// <summary>
    /// The default service name: <c>"azure.ai.agentserver"</c>.
    /// </summary>
    public const string DefaultServiceName = ResponsesTracingConstants.ServiceName;

    /// <summary>
    /// The default provider name: <c>"AzureAI Hosted Agents"</c>.
    /// </summary>
    public const string DefaultProviderName = ResponsesTracingConstants.ProviderName;

    private readonly string _name;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/>.
    /// </summary>
    public ResponsesActivitySource()
    {
        _name = DefaultName;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/> (for subclass testability).
    /// </summary>
    protected ResponsesActivitySource(string? name)
    {
        _name = string.IsNullOrWhiteSpace(name) ? DefaultName : name;
    }

    /// <summary>
    /// Gets the activity source name (for listener registration compatibility).
    /// </summary>
    public string Name => _name;

    /// <summary>
    /// Propagates response correlation baggage onto the current <see cref="Activity"/>
    /// (the ASP.NET Core request activity) without creating an additional span.
    /// </summary>
    /// <param name="request">The deserialized create-response request.</param>
    /// <param name="responseId">The generated response ID.</param>
    /// <param name="headers">The HTTP request headers (for x-request-id).</param>
    public virtual void PropagateResponseBaggage(
        CreateResponse request,
        string responseId,
        IHeaderDictionary headers)
    {
        var activity = Activity.Current;
        if (activity is null)
        {
            return;
        }

        var conversationId = request.GetConversationId() ?? string.Empty;
        var isStreaming = request.Stream == true;

        // Namespaced baggage items for downstream correlation
        activity.AddBaggage(ResponsesTracingConstants.Baggage.ResponseId, responseId);
        activity.AddBaggage(ResponsesTracingConstants.Baggage.ConversationId, conversationId);
        activity.AddBaggage(ResponsesTracingConstants.Baggage.Streaming, isStreaming.ToString());

        // x-request-id propagation
        if (headers.TryGetValue("X-Request-Id", out var xRequestIdValues)
            && !string.IsNullOrEmpty(xRequestIdValues))
        {
            var xRequestId = xRequestIdValues.ToString();
            if (xRequestId.Length > 256)
            {
                xRequestId = xRequestId[..256];
            }
            activity.AddBaggage(ResponsesTracingConstants.Baggage.RequestId, xRequestId);
        }
    }
}
