// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.ClientModel.Primitives;

/// <summary>
/// Extensions for <see cref="Activity"/> and <see cref="ActivitySource"/> that provide
/// common Open Telemetry tracing functionality for clients built on System.ClientModel.
/// </summary>
/// <remarks>These APIs should only be used by client library authors and should not
/// be used by consuming applications. Applications should use the System.Diagnostics package
/// to implement distributed tracing.</remarks>
public static class ActivityExtensions
{
    private const string ScmScopeLabel = "scm.sdk.scope";
    private static readonly object ScmScopeValue = bool.TrueString;

    /// <summary>
    /// Creates and starts a new <see cref="Activity"/> if there are active listeners and if distributed
    /// tracing is enabled. Creates the Activity using the specified name, kind, parent activity context, and tags.
    /// </summary>
    /// <remarks>This extension method is intended to be used by client library authors only. Applications
    /// should use one of the overloads of <see cref="ActivitySource.StartActivity(string, ActivityKind)"/>
    /// to create and start <see cref="Activity"/> instances.</remarks>
    /// <param name="activitySource">The <see cref="ActivitySource"/> to use to create the <see cref="Activity"/>.</param>
    /// <param name="options">The options used to configure the client pipeline.</param>
    /// <param name="name">The operation name of the activity.</param>
    /// <param name="kind">The activity kind.</param>
    /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
    /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
    public static Activity? StartClientActivity(this ActivitySource activitySource,
                                                ClientPipelineOptions options,
                                                string name,
                                                ActivityKind kind = ActivityKind.Internal,
                                                ActivityContext parentContext = default,
                                                IEnumerable<KeyValuePair<string, object?>>? tags = null)
    {
        if (options.EnableDistributedTracing == false)
        {
            return null;
        }

        bool shouldSuppressNested = kind == ActivityKind.Client || kind == ActivityKind.Internal;
        bool isInnerSpan = ScmScopeValue.Equals(Activity.Current?.GetCustomProperty(ScmScopeLabel));
        if (shouldSuppressNested && isInnerSpan)
        {
            return null;
        }

        Activity? activity = activitySource.StartActivity(name, kind, parentContext, tags);

        if (shouldSuppressNested)
        {
            activity?.SetCustomProperty(ScmScopeLabel, ScmScopeValue);
        }

        return activity;
    }

    /// <summary>
    /// Marks the <paramref name="activity"/> as failed.
    /// </summary>
    /// <remarks>This method should only be used by client library authors and should not
    /// be used by consuming applications. Applications should use the System.Diagnostics package
    /// to implement distributed tracing.</remarks>
    /// <param name="activity">The activity to mark as failed.</param>
    /// <param name="exception">The <see cref="Exception"/> encountered during the operation.</param>
    public static Activity MarkClientActivityFailed(this Activity activity, Exception? exception)
    {
        // See: https://opentelemetry.io/docs/specs/semconv/general/recording-errors/

        // SHOULD set the span status code to error
        // When the operation fails with an exception the span status description SHOULD be set to the
        // exception message
        activity.SetStatus(ActivityStatusCode.Error, exception?.Message);

        // SHOULD set error.type see https://opentelemetry.io/docs/specs/semconv/attributes-registry/error/#error-type
        // This instrumentation uses [HTTP status code] or [full name of the exception type] or [_OTHER] in that order
        string? errorCode = null;
        if (exception is ClientResultException clientResultException)
        {
            errorCode = clientResultException.Status.ToString();
        }
        errorCode ??= exception?.GetType().FullName;
        errorCode ??= "_OTHER";

        activity.SetTag("error.type", errorCode);

        return activity;
    }
}
