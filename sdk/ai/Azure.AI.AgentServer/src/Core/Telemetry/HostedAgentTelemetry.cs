using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Core.Common;
using Azure.AI.AgentServer.Responses.Invocation;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Core.Telemetry;

public static class HostedAgentTelemetry
{
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

    public static Activity SetServiceTag(this Activity activity)
    {
        activity.SetTag($"service.name", "azure.ai.agentserver");
        return activity;
    }

    public static Activity SetServiceNamespace(this Activity activity, string serviceNamespace)
    {
        activity.SetTag($"service.namespace", $"azure.ai.agentserver.{serviceNamespace}");
        return activity;
    }

    public static Activity SetResponsesTag(this Activity activity, string key, object? value)
    {
        activity.SetTag($"azure.ai.agentserver.responses.{key}", value);
        return activity;
    }
}
