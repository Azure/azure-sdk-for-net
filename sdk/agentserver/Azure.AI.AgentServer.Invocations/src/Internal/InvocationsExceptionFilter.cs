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
        if (activity is null || exception is null)
        {
            return;
        }

        activity.SetStatus(ActivityStatusCode.Error, exception.Message);

        // Error tags per invocation protocol spec
        string errorCode = exception.GetType().FullName!;
        string errorMessage = exception.Message;
        activity.SetTag("azure.ai.agentserver.invocations.error.code", errorCode);
        activity.SetTag("azure.ai.agentserver.invocations.error.message", errorMessage);

        // OTel semantic convention attributes
        // https://opentelemetry.io/docs/specs/semconv/registry/attributes/error/#error-type
        activity.SetTag("error.type", errorCode);
        // https://opentelemetry.io/docs/specs/semconv/registry/attributes/otel/#otel-status-description
        activity.SetTag("otel.status_description", errorMessage);

        // Add exception event per OTel semantic conventions
        // https://opentelemetry.io/docs/specs/semconv/exceptions/
        var tags = new ActivityTagsCollection
        {
            { "exception.type", exception.GetType().FullName! },
            { "exception.message", exception.Message },
            { "exception.stacktrace", exception.ToString() },
        };
        activity.AddEvent(new ActivityEvent("exception", tags: tags));
    }
}
