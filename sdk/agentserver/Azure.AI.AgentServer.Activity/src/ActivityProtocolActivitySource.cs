// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Emits the per-turn <c>invoke_agent</c> span and attaches the OpenTelemetry correlation baggage
/// for Activity protocol tracing.
/// </summary>
/// <remarks>
/// <para>
/// The <c>invoke_agent</c> span is the per-turn root span the Foundry trace UI lists as a row. The
/// core stack's <c>FoundryEnrichmentProcessor</c> stamps the agent identity (<c>gen_ai.agent.*</c>)
/// and project id (<c>microsoft.foundry.project.id</c>) onto every span from its environment, so
/// this type only needs to start the span with the operation attributes and the resolved
/// session/conversation correlation ids. In Foundry-hosted (Agent365-only) mode the ASP.NET Core
/// request-activity instrumentation is disabled, so without this span there is no per-turn root for
/// the UI to list — the model/tool child spans would have no parent turn to attach to.
/// </para>
/// <para>
/// The session id and conversation id are set both as span tags (so they are present on the
/// <c>invoke_agent</c> span itself, whose enrichment <c>OnStart</c> runs before any baggage would be
/// available) and as baggage (so the core enrichment stamps them onto every downstream child span).
/// </para>
/// </remarks>
internal class ActivityProtocolActivitySource
{
    // Baggage keys read by Azure.AI.AgentServer.Core's FoundryEnrichmentProcessor to enrich
    // spans (and by the core log enrichment). These strings must match the core stack exactly.
    private const string BaggageSessionId = "azure.ai.agentserver.session_id";
    private const string BaggageConversationId = "azure.ai.agentserver.conversation_id";

    // Span tag keys — parity with the core FoundryEnrichmentProcessor and the OTel GenAI
    // semantic conventions. Set directly on the invoke_agent span so the turn carries them even
    // when it is the trace root (no parent request activity to inherit baggage from).
    private const string TagOperationName = "gen_ai.operation.name";
    private const string TagSystem = "gen_ai.system";
    private const string TagResponseId = "azure.ai.agentserver.response_id";
    private const string TagSessionId = "microsoft.session.id";
    private const string TagConversationId = "gen_ai.conversation.id";

    // Well-known values.
    private const string SpanName = "invoke_agent";
    private const string OperationNameValue = "invoke_agent";
    private const string SystemValue = "activity";

    // The ActivitySource name for the Activity protocol's per-turn span. Registered with the
    // tracer provider from the Activity package itself (see ActivityBuilderExtensions via
    // AgentHostBuilder.ConfigureTracing), so no change to the core telemetry wiring is needed.
    public const string SourceName = "Azure.AI.AgentServer.Activity";

    private static readonly ActivitySource Source = new(SourceName);

    /// <summary>
    /// Starts the per-turn <c>invoke_agent</c> span. Returns <c>null</c> when no listener is
    /// registered (tracing disabled); the caller should treat a <c>null</c> return as a no-op.
    /// </summary>
    /// <param name="sessionId">The resolved session id (stamped as a tag and baggage when non-empty).</param>
    /// <param name="conversationId">The resolved conversation id, if any (stamped as a tag and baggage).</param>
    /// <param name="responseId">The per-turn id (the sanitized activity id), if any.</param>
    /// <returns>The started <see cref="System.Diagnostics.Activity"/>, or <c>null</c> when tracing is off.</returns>
    public virtual System.Diagnostics.Activity? StartInvokeAgentSpan(
        string sessionId,
        string? conversationId = null,
        string? responseId = null)
    {
        // Started as an Internal span (not Server): the Foundry gateway already emits the
        // turn-level Server request span, and the platform's observability pipeline recognizes the
        // agent invocation from an Internal gen_ai span (matching the Python host, whose
        // invoke_agent span is Internal). A Server-kind span here is treated as a plain HTTP
        // request and is not promoted into the agent run list.
        var activity = Source.StartActivity(SpanName, ActivityKind.Internal);
        if (activity is null)
        {
            return null;
        }

        activity.SetTag(TagOperationName, OperationNameValue);
        activity.SetTag(TagSystem, SystemValue);

        if (!string.IsNullOrEmpty(responseId))
        {
            activity.SetTag(TagResponseId, responseId);
        }

        if (!string.IsNullOrEmpty(sessionId))
        {
            activity.SetTag(TagSessionId, sessionId);
            activity.SetBaggage(BaggageSessionId, sessionId);
        }

        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetTag(TagConversationId, conversationId);
            activity.SetBaggage(BaggageConversationId, conversationId);
        }

        return activity;
    }

    /// <summary>
    /// Attaches the session/conversation correlation baggage onto the current
    /// <see cref="System.Diagnostics.Activity"/> so the core enrichment processor stamps them onto
    /// every span. Also sets them as direct tags so the current span carries them even when its
    /// enrichment already ran. No-ops when there is no current activity.
    /// </summary>
    /// <param name="sessionId">The resolved session id.</param>
    /// <param name="conversationId">The resolved conversation id, if any.</param>
    public virtual void PropagateActivityBaggage(string sessionId, string? conversationId = null)
    {
        var activity = System.Diagnostics.Activity.Current;
        if (activity is null)
        {
            return;
        }

        activity.SetBaggage(BaggageSessionId, sessionId ?? string.Empty);
        if (!string.IsNullOrEmpty(sessionId))
        {
            activity.SetTag(TagSessionId, sessionId);
        }

        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetBaggage(BaggageConversationId, conversationId);
            activity.SetTag(TagConversationId, conversationId);
        }
    }
}
