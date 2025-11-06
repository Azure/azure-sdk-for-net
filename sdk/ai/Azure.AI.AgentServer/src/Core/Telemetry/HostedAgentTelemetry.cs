using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Telemetry;

/// <summary>
/// Provides telemetry and activity tracking for hosted agent operations.
/// </summary>
public static class HostedAgentTelemetry
{
    /// <summary>
    /// Gets the activity source for agent server telemetry.
    /// </summary>
    public static readonly ActivitySource Source = new("Azure.AI.AgentServer");

    internal static IDisposable StartActivity(this AgentInvocationContext context, ILogger logger, CreateResponseRequest request)
    {
        var logging = logger.BeginScope(new Dictionary<string, object?>
        {
            ["ResponseId"] = context.ResponseId,
            ["ConversationId"] = context.ConversationId,
            ["Streaming"] = request.Stream ?? false,
        });

        var span = Source.StartActivity($"ContainerAgentsAdapter-{context.ResponseId}",
            ActivityKind.Server);

        span?.SetServiceTag()
            .SetResponsesTag("response_id", context.ResponseId)
            .SetResponsesTag("conversation_id", context.ConversationId)
            .SetResponsesTag("streaming", request.Stream ?? false);

        return new CompositeDisposable(logging, span);
    }

    /// <summary>
    /// Sets the service tag on the activity.
    /// </summary>
    /// <param name="activity">The activity to tag.</param>
    /// <returns>The activity for chaining.</returns>
    public static Activity SetServiceTag(this Activity activity)
    {
        activity.SetTag($"service.name", "azure.ai.agentserver");
        return activity;
    }

    /// <summary>
    /// Sets the service namespace tag on the activity.
    /// </summary>
    /// <param name="activity">The activity to tag.</param>
    /// <param name="serviceNamespace">The service namespace value.</param>
    /// <returns>The activity for chaining.</returns>
    public static Activity SetServiceNamespace(this Activity activity, string serviceNamespace)
    {
        activity.SetTag($"service.namespace", $"azure.ai.agentserver.{serviceNamespace}");
        return activity;
    }

    /// <summary>
    /// Sets a response-related tag on the activity.
    /// </summary>
    /// <param name="activity">The activity to tag.</param>
    /// <param name="key">The tag key.</param>
    /// <param name="value">The tag value.</param>
    /// <returns>The activity for chaining.</returns>
    public static Activity SetResponsesTag(this Activity activity, string key, object? value)
    {
        activity.SetTag($"azure.ai.agentserver.responses.{key}", value);
        return activity;
    }
}
