// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Records exceptions on the current <see cref="Activity"/> span with
/// <c>ERROR</c> status and an exception event.
/// </summary>
internal static class InvocationsExceptionFilter
{
    /// <summary>
    /// Records an exception on the given activity.
    /// </summary>
    internal static void RecordException(Activity? activity, Exception exception)
    {
        if (activity is null)
        {
            return;
        }

        activity.SetStatus(ActivityStatusCode.Error, exception.Message);

        // Error tags per invocation protocol spec §4.2 / §4.4
        activity.SetTag("azure.ai.agentserver.invocations.error.code", exception.GetType().FullName);
        activity.SetTag("azure.ai.agentserver.invocations.error.message", exception.Message);

        // Add exception event per OTel semantic conventions
        var tags = new ActivityTagsCollection
        {
            { "exception.type", exception.GetType().FullName! },
            { "exception.message", exception.Message },
            { "exception.stacktrace", exception.ToString() },
        };
        activity.AddEvent(new ActivityEvent("exception", tags: tags));
    }
}
