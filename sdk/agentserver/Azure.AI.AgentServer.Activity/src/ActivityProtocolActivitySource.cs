// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Attaches the OpenTelemetry correlation baggage for Activity protocol tracing.
/// </summary>
/// <remarks>
/// <para>
/// This sets exactly the two baggage keys that the core stack's <c>FoundryEnrichmentProcessor</c>
/// reads and promotes onto every span (and the core log enrichment onto logs) — the session id and
/// the conversation id.
/// </para>
/// </remarks>
internal class ActivityProtocolActivitySource
{
    // Baggage keys read by Azure.AI.AgentServer.Core's FoundryEnrichmentProcessor to enrich
    // spans (and by the core log enrichment). These strings must match the core stack exactly.
    private const string BaggageSessionId = "azure.ai.agentserver.session_id";
    private const string BaggageConversationId = "azure.ai.agentserver.conversation_id";

    /// <summary>
    /// Attaches the session/conversation correlation baggage onto the current
    /// <see cref="System.Diagnostics.Activity"/> (the ASP.NET Core request activity) so the core
    /// enrichment processor stamps them onto every span. No-ops when there is no current activity.
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

        if (!string.IsNullOrEmpty(conversationId))
        {
            activity.SetBaggage(BaggageConversationId, conversationId);
        }
    }
}
