// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Records exceptions on the current <see cref="Activity"/> span with
/// <c>ERROR</c> status and an exception event.
/// </summary>
internal static class ActivityExceptionFilter
{
    /// <summary>
    /// Records an exception on the given activity.
    /// </summary>
    internal static void RecordException(System.Diagnostics.Activity? activity, Exception exception)
    {
        if (activity is null || exception is null)
        {
            return;
        }

        activity.SetStatus(ActivityStatusCode.Error, exception.Message);

        // Error tags per activity protocol spec
        string errorCode = exception.GetType().FullName!;
        string errorMessage = exception.Message;
        activity.SetTag("azure.ai.agentserver.activity.error.code", errorCode);
        activity.SetTag("azure.ai.agentserver.activity.error.message", errorMessage);

        // OTel semantic convention attributes
        activity.SetTag("error.type", errorCode);
        activity.SetTag("otel.status_description", errorMessage);

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
