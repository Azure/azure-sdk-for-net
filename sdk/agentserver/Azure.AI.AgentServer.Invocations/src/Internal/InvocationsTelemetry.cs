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
    private static readonly ObservableCounter<long> CloseEventsDroppedDeadline = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations_ws.close_events.dropped_deadline",
        () => Interlocked.Read(ref _closeEventDroppedDeadlineCount));
    private static readonly ObservableCounter<long> CloseEventsDroppedDispatcher = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations_ws.close_events.dropped_dispatcher",
        () => Interlocked.Read(ref _closeEventDroppedDispatcherCount));
    private static readonly ObservableCounter<long> CloseEventSinkFailures = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations_ws.close_events.sink_faulted",
        () => Interlocked.Read(ref _closeEventSinkFaultedCount));
    private static readonly ObservableCounter<long> WebSocketFinalCloseCodes = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations_ws.final_close_codes",
        ObserveFinalCloseCodes);
    private static readonly ObservableCounter<long> WebSocketCloseOutcomes = Meter.CreateObservableCounter(
        "azure.ai.agentserver.invocations_ws.close_outcomes",
        ObserveCloseOutcomes);
    private static long _droppedCallbackCount;
    private static long _closeEventDroppedDeadlineCount;
    private static long _closeEventDroppedDispatcherCount;
    private static long _closeEventSinkFaultedCount;
    private static readonly long[] FinalCloseCodeCounts = new long[5000];
    private static readonly long[] CloseOutcomeCounts = new long[Enum.GetValues<WebSocketTerminationOutcome>().Length];

    public const string SourceName = "Azure.AI.AgentServer.Invocations";

    public static readonly ActivitySource ActivitySource = new(SourceName);

    internal static long DroppedCallbackCount => Interlocked.Read(ref _droppedCallbackCount);

    internal static long CloseEventDroppedDeadlineCount =>
        Interlocked.Read(ref _closeEventDroppedDeadlineCount);

    internal static long CloseEventDroppedDispatcherCount =>
        Interlocked.Read(ref _closeEventDroppedDispatcherCount);

    internal static long CloseEventSinkFaultedCount =>
        Interlocked.Read(ref _closeEventSinkFaultedCount);

    public static void QueueCallback(TelemetryCallbackDispatcher dispatcher, Action callback) =>
        dispatcher.TryQueue(callback);

    public static bool QueueCriticalCallback(TelemetryCallbackDispatcher dispatcher, Action callback) =>
        dispatcher.TryQueueCritical(callback);

    public static ValueTask<CriticalTelemetryEnqueueResult> QueueCriticalCallbackAsync(
        TelemetryCallbackDispatcher dispatcher,
        Action callback,
        CancellationToken cancellationToken) =>
        dispatcher.QueueCriticalAsync(callback, cancellationToken);

    internal static void RecordDroppedCallback() => Interlocked.Increment(ref _droppedCallbackCount);

    internal static void RecordCloseEventEnqueueResult(CriticalTelemetryEnqueueResult result)
    {
        if (result == CriticalTelemetryEnqueueResult.DeadlineExpired)
        {
            Interlocked.Increment(ref _closeEventDroppedDeadlineCount);
        }
        else if (result == CriticalTelemetryEnqueueResult.DispatcherCompleted)
        {
            Interlocked.Increment(ref _closeEventDroppedDispatcherCount);
        }
    }

    internal static Action CreateCloseEventCallback(Action callback)
    {
        ArgumentNullException.ThrowIfNull(callback);
        return () =>
        {
            try
            {
                callback();
            }
            catch
            {
                Interlocked.Increment(ref _closeEventSinkFaultedCount);
                throw;
            }
        };
    }

    internal static void RecordWebSocketTermination(WebSocketTerminationResult termination)
    {
        if ((uint)termination.FinalCloseCode >= FinalCloseCodeCounts.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(termination));
        }

        Interlocked.Increment(ref FinalCloseCodeCounts[termination.FinalCloseCode]);
        Interlocked.Increment(ref CloseOutcomeCounts[(int)termination.Outcome]);
    }

    private static IEnumerable<Measurement<long>> ObserveFinalCloseCodes()
    {
        for (var code = 0; code < FinalCloseCodeCounts.Length; code++)
        {
            var count = Interlocked.Read(ref FinalCloseCodeCounts[code]);
            if (count != 0)
            {
                yield return new Measurement<long>(
                    count,
                    new KeyValuePair<string, object?>("code", code));
            }
        }
    }

    private static IEnumerable<Measurement<long>> ObserveCloseOutcomes()
    {
        foreach (var outcome in Enum.GetValues<WebSocketTerminationOutcome>())
        {
            var count = Interlocked.Read(ref CloseOutcomeCounts[(int)outcome]);
            if (count != 0)
            {
                yield return new Measurement<long>(
                    count,
                    new KeyValuePair<string, object?>(
                        "outcome",
                        WebSocketTerminationResult.GetOutcomeName(outcome)));
            }
        }
    }

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

                    activity.SetCustomProperty(
                        DispatcherReservationKey,
                        new ActivityReservation(dispatcher));
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
        if (activity.GetCustomProperty(DispatcherReservationKey) is not ActivityReservation reservation)
        {
            return QueueCallbackAsync(dispatcher, stopCallback);
        }

        var reservationDispatcher = reservation.Dispatcher;
        if (reservationDispatcher is null)
        {
            return reservation.StopCompletion;
        }

        if (!reservation.TryClaimStop())
        {
            return reservation.StopCompletion;
        }

        if (!reservationDispatcher.TryQueueActivityStop(() =>
        {
            try
            {
                stopCallback();
            }
            finally
            {
                reservationDispatcher.ReleaseActivity();
                reservation.CompleteStop();
            }
        }))
        {
            reservationDispatcher.ReleaseActivity();
            reservation.CompleteStop();
        }

        return reservation.StopCompletion;
    }

    private sealed class ActivityReservation
    {
        private readonly TaskCompletionSource _stopCompletion =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
        private TelemetryCallbackDispatcher? _dispatcher;
        private int _stopClaimed;

        public ActivityReservation(TelemetryCallbackDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public TelemetryCallbackDispatcher? Dispatcher => Volatile.Read(ref _dispatcher);

        public Task StopCompletion => _stopCompletion.Task;

        public bool TryClaimStop() => Interlocked.Exchange(ref _stopClaimed, 1) == 0;

        public void CompleteStop()
        {
            Interlocked.Exchange(ref _dispatcher, null);
            _stopCompletion.TrySetResult();
        }
    }
}
