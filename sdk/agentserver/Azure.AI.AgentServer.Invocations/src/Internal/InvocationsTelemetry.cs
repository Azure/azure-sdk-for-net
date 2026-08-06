// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>Shared tracing scope registered by the default AgentServer host.</summary>
internal static class InvocationsTelemetry
{
    private const string DispatcherReservationKey = "Azure.AI.AgentServer.Invocations.TelemetryDispatcher";
    private static readonly Meter Meter = new(SourceName);
    private static readonly ObservableCounter<long> DroppedCallbacks = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations.telemetry.callbacks.dropped",
        () => Interlocked.Read(ref _droppedCallbackCount));
    private static long _droppedCallbackCount;

    public const string SourceName = "Azure.AI.AgentServer.Invocations";

    public static readonly ActivitySource ActivitySource = new(SourceName);

    internal static long DroppedCallbackCount => Interlocked.Read(ref _droppedCallbackCount);

    public static void QueueCallback(TelemetryCallbackDispatcher dispatcher, Action callback) =>
        dispatcher.TryQueue(callback);

    public static bool QueueCriticalCallback(TelemetryCallbackDispatcher dispatcher, Action callback) =>
        dispatcher.TryQueueCritical(callback);

    public static ValueTask<bool> QueueCriticalCallbackAsync(
        TelemetryCallbackDispatcher dispatcher,
        Action callback,
        CancellationToken cancellationToken) =>
        dispatcher.QueueCriticalAsync(callback, cancellationToken);

    internal static void RecordDroppedCallback() => Interlocked.Increment(ref _droppedCallbackCount);

    public static Task QueueCallbackAsync(TelemetryCallbackDispatcher dispatcher, Action callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        var completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!dispatcher.TryQueue(() =>
        {
            try
            {
                callback();
            }
            finally
            {
                completion.TrySetResult();
            }
        }))
        {
            completion.TrySetResult();
        }

        return completion.Task;
    }

    public static Task<Activity?> StartActivityAsync(
        TelemetryCallbackDispatcher dispatcher,
        string name,
        ActivityKind kind,
        ActivityContext parentContext,
        ActivityTagsCollection? tags = null,
        IEnumerable<KeyValuePair<string, string?>>? baggage = null,
        DateTime startTimeUtc = default,
        Action<Activity>? activityStarted = null)
    {
        if (!ActivitySource.HasListeners())
        {
            return Task.FromResult<Activity?>(null);
        }

        if (!dispatcher.TryReserveActivity())
        {
            return Task.FromResult<Activity?>(null);
        }

        var baggageSnapshot = baggage?.ToArray();
        var completion = new TaskCompletionSource<Activity?>(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!dispatcher.TryQueue(() =>
        {
            try
            {
                var activity = startTimeUtc == default
                    ? ActivitySource.StartActivity(name, kind, parentContext, tags)
                    : ActivitySource.StartActivity(
                        name,
                        kind,
                        parentContext,
                        tags,
                        links: null,
                        startTime: startTimeUtc);
                if (activity is null)
                {
                    dispatcher.ReleaseActivity();
                }
                else
                {
                    if (baggageSnapshot is not null)
                    {
                        foreach (var item in baggageSnapshot)
                        {
                            activity.AddBaggage(item.Key, item.Value);
                        }
                    }

                    activity.SetCustomProperty(DispatcherReservationKey, dispatcher);
                    activityStarted?.Invoke(activity);
                }

                completion.TrySetResult(activity);
            }
#pragma warning disable CA1031 // Telemetry listeners must not fault protocol work.
            catch (Exception)
#pragma warning restore CA1031
            {
                dispatcher.ReleaseActivity();
                completion.TrySetResult(null);
            }
        }))
        {
            dispatcher.ReleaseActivity();
            completion.TrySetResult(null);
        }

        return completion.Task;
    }

    public static Task StopActivityAsync(
        TelemetryCallbackDispatcher dispatcher,
        Activity activity,
        Action stopCallback)
    {
        ArgumentNullException.ThrowIfNull(activity);
        ArgumentNullException.ThrowIfNull(stopCallback);
        if (!ReferenceEquals(activity.GetCustomProperty(DispatcherReservationKey), dispatcher))
        {
            return QueueCallbackAsync(dispatcher, stopCallback);
        }

        var completion = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!dispatcher.TryQueueActivityStop(() =>
        {
            try
            {
                stopCallback();
            }
            finally
            {
                activity.SetCustomProperty(DispatcherReservationKey, null);
                dispatcher.ReleaseActivity();
                completion.TrySetResult();
            }
        }))
        {
            activity.SetCustomProperty(DispatcherReservationKey, null);
            dispatcher.ReleaseActivity();
            completion.TrySetResult();
        }

        return completion.Task;
    }
}
