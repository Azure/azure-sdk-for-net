// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal sealed class VoiceCallbackTrace : IDisposable
{
    private const string OperationName = "voice.callback";
    private static readonly ActivitySource s_activitySource = new(InvocationsActivitySource.DefaultName);
    private static readonly AsyncLocal<object?> s_startToken = new();
    private Activity? _activity;
    private int _disposed;

    private VoiceCallbackTrace(Activity? activity) => _activity = activity;

    internal static VoiceCallbackTrace Start(
        ActivityContext connectionContext,
        string eventType) =>
        Start(
            connectionContext,
            eventType,
            static (context, tags) => s_activitySource.StartActivity(
                OperationName,
                ActivityKind.Internal,
                context,
                tags));

    internal static VoiceCallbackTrace Start(
        ActivityContext connectionContext,
        string eventType,
        Func<ActivityContext, ActivityTagsCollection, Activity?> startActivity)
    {
        ArgumentNullException.ThrowIfNull(startActivity);
        if (connectionContext == default)
        {
            return new VoiceCallbackTrace(activity: null);
        }

        var previousActivity = Activity.Current;
        var previousStartToken = s_startToken.Value;
        var startToken = new object();
        s_startToken.Value = startToken;
        Activity? activity = null;
        Activity? startedActivity = null;
        Activity? propagationActivity = null;
        EventHandler<ActivityChangedEventArgs> captureStartedActivity = (_, args) =>
        {
            if (!ReferenceEquals(s_startToken.Value, startToken))
            {
                return;
            }

            var candidate = IsCallbackActivity(args.Current)
                ? args.Current
                : IsCallbackActivity(args.Previous)
                    ? args.Previous
                    : null;
            if (candidate is not null)
            {
                startedActivity = candidate;
            }
        };
        Activity.CurrentChanged += captureStartedActivity;
        try
        {
            var tags = new ActivityTagsCollection
            {
                ["voice.event.type"] = eventType,
            };
            VoiceActivityScope.TrySetCurrent(null);
            try
            {
                activity = startActivity(connectionContext, tags);
                if (activity is null)
                {
                    propagationActivity = new Activity(OperationName)
                        .SetParentId(
                            connectionContext.TraceId,
                            connectionContext.SpanId,
                            connectionContext.TraceFlags);
                    propagationActivity.TraceStateString = connectionContext.TraceState;
                    foreach (var tag in tags)
                    {
                        propagationActivity.SetTag(tag.Key, tag.Value);
                    }
                    activity = propagationActivity.Start();
                }
            }
            catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
            {
                activity = propagationActivity?.Id is not null
                    ? propagationActivity
                    : startedActivity ?? Activity.Current;
                if (!IsCallbackActivity(activity))
                {
                    activity = ReferenceEquals(activity, propagationActivity)
                        ? activity
                        : null;
                }
            }
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
            activity = propagationActivity?.Id is not null
                ? propagationActivity
                : null;
        }
        finally
        {
            Activity.CurrentChanged -= captureStartedActivity;
            s_startToken.Value = previousStartToken;
            VoiceActivityScope.TrySetCurrent(previousActivity);
        }
        return new VoiceCallbackTrace(activity);
    }

    internal IDisposable Activate() => VoiceActivityScope.Activate(_activity);

    internal void RecordFailure(Exception exception)
    {
        var activity = Volatile.Read(ref _activity);
        if (activity is null)
        {
            return;
        }

        TryInvokeTelemetry(() => activity.SetStatus(ActivityStatusCode.Error));
        TryInvokeTelemetry(() => activity.SetTag("error.type", exception.GetType().FullName));
    }

    public void Dispose()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
        {
            return;
        }

        var activity = Interlocked.Exchange(ref _activity, null);
        if (activity is null)
        {
            return;
        }

        var current = Activity.Current;
        TryInvokeTelemetry(activity.Stop);
        if (!ReferenceEquals(current, activity))
        {
            VoiceActivityScope.TrySetCurrent(current);
        }
    }

    private static bool IsCallbackActivity(Activity? activity) =>
        activity?.Source.Name == InvocationsActivitySource.DefaultName &&
        activity.OperationName == OperationName;

    private static void TryInvokeTelemetry(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
    }

    private static bool ContainsOutOfMemoryException(Exception exception)
    {
        if (exception is OutOfMemoryException)
        {
            return true;
        }
        return exception is AggregateException aggregateException &&
            aggregateException.InnerExceptions.Any(ContainsOutOfMemoryException);
    }
}
