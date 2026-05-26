// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// DI-friendly wrapper around <see cref="ActivitySource"/> that supports
/// extensible activity creation for distributed tracing.
/// <para>
/// The default implementation sets GenAI semantic convention tags, Core-parity
/// tags (<c>azure.ai.agentserver.responses.*</c>), and namespaced baggage items.
/// Subclass to customize tracing — you do <strong>not</strong> need to replicate the
/// entire method. Because <see cref="Activity.SetTag"/> replaces existing values
/// and <see cref="Activity.AddBaggage"/> prepends (so
/// <see cref="Activity.GetBaggageItem"/> returns the most recently added value),
/// you can call <c>base</c> first and then selectively override:
/// </para>
/// <code>
/// class MyActivitySource : ResponsesActivitySource
/// {
///     public override Activity? StartCreateResponseActivity(
///         CreateResponse request, string responseId, IHeaderDictionary headers)
///     {
///         var activity = base.StartCreateResponseActivity(request, responseId, headers);
///         activity?.SetTag("gen_ai.provider.name", "my-service");   // replaces default
///         activity?.SetTag("service.namespace", "my.ns");           // adds new tag
///         return activity;
///     }
/// }
///
/// // Register before AddResponsesServer so TryAddSingleton skips the default:
/// services.AddSingleton&lt;ResponsesActivitySource, MyActivitySource&gt;();
/// services.AddResponsesServer();
/// </code>
/// </summary>
internal class ResponsesActivitySource
{
    /// <summary>
    /// The default <see cref="ActivitySource"/> name: <c>"Azure.AI.AgentServer.Responses"</c>.
    /// </summary>
    public const string DefaultName = "Azure.AI.AgentServer.Responses";

    /// <summary>
    /// The default service name used for the <c>service.name</c> tag:
    /// <c>"azure.ai.agentserver"</c>. Matches the Core package for tracing parity.
    /// </summary>
    public const string DefaultServiceName = ResponsesTracingConstants.ServiceName;

    /// <summary>
    /// The default provider name used for the <c>gen_ai.provider.name</c> tag:
    /// <c>"AzureAI Hosted Agents"</c>. Matches the Core package for tracing parity.
    /// </summary>
    public const string DefaultProviderName = ResponsesTracingConstants.ProviderName;

    private readonly ActivitySource _source;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/>
    /// using <see cref="DefaultName"/> as the <see cref="ActivitySource"/> name.
    /// </summary>
    public ResponsesActivitySource() : this(null) { }

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesActivitySource"/>.
    /// </summary>
    /// <param name="name">
    /// The name for the underlying <see cref="ActivitySource"/>.
    /// Falls back to <see cref="DefaultName"/> if null, empty, or whitespace.
    /// </param>
    protected ResponsesActivitySource(string? name)
    {
        var resolvedName = string.IsNullOrWhiteSpace(name) ? DefaultName : name;
        _source = new ActivitySource(resolvedName);
    }

    /// <summary>
    /// Gets the underlying <see cref="ActivitySource"/> instance.
    /// Subclasses may use this to call <see cref="ActivitySource.StartActivity(string, ActivityKind)"/>.
    /// </summary>
    protected ActivitySource Source => _source;

    /// <summary>
    /// Gets the name of the underlying <see cref="ActivitySource"/>.
    /// Useful for configuring <c>AddSource</c> on an OpenTelemetry tracing builder.
    /// </summary>
    public string Name => _source.Name;

    /// <summary>
    /// Starts and configures a distributed tracing <see cref="Activity"/> for a
    /// <c>POST /responses</c> request.
    /// <para>
    /// The default implementation sets GenAI semantic convention tags
    /// (<c>gen_ai.response.id</c>, <c>gen_ai.provider.name</c>,
    /// <c>gen_ai.operation.name</c>, <c>gen_ai.request.model</c>,
    /// <c>gen_ai.conversation.id</c>, <c>gen_ai.agent.*</c>, <c>service.name</c>),
    /// Core-parity tags (<c>azure.ai.agentserver.responses.response_id</c>,
    /// <c>azure.ai.agentserver.responses.conversation_id</c>,
    /// <c>azure.ai.agentserver.responses.streaming</c>), and namespaced baggage items.
    /// </para>
    /// <para>
    /// Override to customize. Call <c>base</c> first, then use
    /// <see cref="Activity.SetTag"/> to replace or add tags — <c>SetTag</c>
    /// replaces the value when the key already exists.
    /// <see cref="Activity.AddBaggage"/> prepends, so
    /// <see cref="Activity.GetBaggageItem"/> returns the most recently added value.
    /// </para>
    /// </summary>
    /// <param name="request">The deserialized create-response request.</param>
    /// <param name="responseId">The generated response ID.</param>
    /// <param name="headers">
    /// The HTTP request headers. The default implementation reads
    /// <c>X-Request-Id</c>; subclasses can read any header they need.
    /// </param>
    /// <returns>
    /// A started <see cref="Activity"/>, or <c>null</c> if no listener is sampling.
    /// <b>Ownership / lifetime:</b> For streaming requests the caller transfers
    /// ownership to <see cref="Internal.SseResult"/>, which disposes the activity
    /// when the SSE stream completes. For non-streaming requests the caller
    /// disposes the activity in a <c>try/finally</c> block.
    /// Subclasses that override this method should <b>not</b> dispose the returned
    /// activity — disposal is always handled by the endpoint handler.
    /// </returns>
    public virtual Activity? StartCreateResponseActivity(
        CreateResponse request,
        string responseId,
        IHeaderDictionary headers)
    {
        // Derive mode flags from request
        var isStreaming = request.Stream == true;
        var isBackground = request.Background == true;

        // Span display name per spec §7.1: invoke_agent {Model}
        var activityName = string.IsNullOrEmpty(request.Model)
            ? "invoke_agent"
            : $"invoke_agent {request.Model}";

        var activity = _source.StartActivity(activityName, ActivityKind.Server);
        if (activity is null)
        {
            return null;
        }

        // --- Core-parity tags (must match HostedAgentTelemetry exactly) ---
        activity.SetTag(ResponsesTracingConstants.Tags.ServiceName, DefaultServiceName);
        activity.SetTag(ResponsesTracingConstants.Tags.ProviderName, DefaultProviderName);
        activity.SetTag(ResponsesTracingConstants.Tags.ResponseId, responseId);

        // Agent ID: Core emits "" when agent is null, "{Name}:{Version}" when present
        var agent = request.AgentReference ?? request.Agent;
        var agentId = agent is not null && !string.IsNullOrEmpty(agent.Name)
            ? (string.IsNullOrEmpty(agent.Version) ? $"{agent.Name}" : $"{agent.Name}:{agent.Version}")
            : string.Empty;
        activity.SetTag(ResponsesTracingConstants.Tags.AgentId, agentId);

        // Namespaced parity tags (match Core's SetResponsesTag pattern)
        var conversationId = request.GetConversationId() ?? string.Empty;
        activity.SetTag(ResponsesTracingConstants.Tags.NamespacedResponseId, responseId);
        activity.SetTag(ResponsesTracingConstants.Tags.NamespacedConversationId, conversationId);
        activity.SetTag(ResponsesTracingConstants.Tags.NamespacedStreaming, isStreaming);
        activity.SetTag(ResponsesTracingConstants.Tags.FoundryProjectId, Core.FoundryEnvironment.ProjectArmId ?? string.Empty);

        // --- GenAI semantic convention tags (Responses-specific additions) ---
        activity.SetTag(ResponsesTracingConstants.Tags.OperationName, ResponsesTracingConstants.OperationName);

        if (!string.IsNullOrEmpty(request.Model))
        {
            activity.SetTag(ResponsesTracingConstants.Tags.RequestModel, request.Model);
        }

        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetTag(ResponsesTracingConstants.Tags.ConversationId, conversationId);
        }

        if (agent is not null && !string.IsNullOrEmpty(agent.Name))
        {
            activity.SetTag(ResponsesTracingConstants.Tags.AgentName, agent.Name);
            if (!string.IsNullOrEmpty(agent.Version))
            {
                activity.SetTag(ResponsesTracingConstants.Tags.AgentVersion, agent.Version);
            }
        }

        // X-Request-Id header — read and truncate for baggage (no span tag)
        string? xRequestId = null;
        if (headers.TryGetValue("X-Request-Id", out var xRequestIdValues)
            && !string.IsNullOrEmpty(xRequestIdValues))
        {
            xRequestId = xRequestIdValues.ToString();
            if (xRequestId.Length > 256)
            {
                xRequestId = xRequestId[..256];
            }
        }

        // --- Namespaced baggage items (parity with Core's Baggage.SetBaggage) ---
        activity.AddBaggage(ResponsesTracingConstants.Baggage.ResponseId, responseId);
        activity.AddBaggage(ResponsesTracingConstants.Baggage.ConversationId, conversationId);
        activity.AddBaggage(ResponsesTracingConstants.Baggage.Streaming, isStreaming.ToString());

        if (!string.IsNullOrEmpty(xRequestId))
        {
            activity.AddBaggage(ResponsesTracingConstants.Baggage.RequestId, xRequestId);
        }

        return activity;
    }
}
