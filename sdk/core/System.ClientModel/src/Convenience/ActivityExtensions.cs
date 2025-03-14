// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;

namespace System.ClientModel.Primitives;

/// <summary>
/// Extensions for <see cref="Activity"/> and <see cref="ActivitySource"/> that provide
/// common Open Telemetry tracing functionality for clients built on System.ClientModel.
/// </summary>
/// <remarks>These APIs should only be used by client library authors and should not
/// be used by consuming applications. Applications should only use methods on
/// <see cref="Activity"/> and <see cref="ActivitySource"/> for tracing.</remarks>
public static class ActivityExtensions
{
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly object ScmScopeValue = bool.TrueString;

    /// <summary>
    /// Creates and starts a new <see cref="Activity"/> with the specified name and kind.
    /// </summary>
    /// <param name="activitySource"></param>
    /// <param name="isDistributedTracingEnabled"></param>
    /// <param name="name"></param>
    /// <param name="kind"></param>
    /// <param name="context"></param>
    /// <param name="tags"></param>
    /// <returns></returns>
    public static Activity? StartClientActivity(this ActivitySource activitySource,
                                                bool isDistributedTracingEnabled,
                                                string name,
                                                ActivityKind kind = ActivityKind.Internal,
                                                ActivityContext context = default,
                                                IEnumerable<KeyValuePair<string, object?>>? tags = null)
    {
        if (!isDistributedTracingEnabled)
        {
            return null;
        }

        bool isInnerSpan = ScmScopeValue.Equals(Activity.Current?.GetCustomProperty(ScmScopeLabel));
        if (isInnerSpan)
        {
            return null;
        }

        Activity? activity = activitySource.StartActivity(name, kind, context, tags);

        if (activity?.IsAllDataRequested == true)
        {
            activity.SetCustomProperty(ScmScopeLabel, ScmScopeValue);
        }

        return activity;
    }

    /// <summary>
    /// Marks the <paramref name="activity"/> as failed.
    /// </summary>
    /// <param name="activity"></param>
    /// <param name="exception"></param>
    public static void MarkFailed(this Activity activity, Exception? exception)
    {
        if (activity == null)
        {
            return;
        }
        activity.SetTag("error.type", exception?.GetType().FullName);
        activity.SetStatus(ActivityStatusCode.Error, exception?.Message);
    }
}
