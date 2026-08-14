// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;
using OpenTelemetry.Context.Propagation;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal sealed class VoiceConnectionTelemetry
{
    private const string ConnectionOperationName = "agentserver.connection";
    private static readonly ActivitySource s_activitySource = new(InvocationsActivitySource.DefaultName);
    private static readonly Meter s_meter = new(InvocationsActivitySource.DefaultName);
    private static readonly AsyncLocal<object?> s_connectionStartToken = new();
    private static readonly Counter<long> s_propagationFailures = s_meter.CreateCounter<long>(
        "azure.ai.agentserver.trace_context.propagation_failures");

    private readonly Activity? _activity;
    private readonly ActivityContext _context;
    private readonly Activity? _previousActivity;
    private bool _requestCancelled;
    private int _completed;

    private VoiceConnectionTelemetry(
        Activity? activity,
        ActivityContext context,
        Activity? previousActivity)
    {
        _activity = activity;
        _context = context;
        _previousActivity = previousActivity;
    }

    internal ActivityContext Context => _context;

    internal static VoiceConnectionTelemetry Start(IHeaderDictionary headers)
    {
        var previousActivity = Activity.Current;
        var previousStartToken = s_connectionStartToken.Value;
        var startToken = new object();
        s_connectionStartToken.Value = startToken;
        Activity? activity = null;
        Activity? startedActivity = null;
        ActivityContext extractedContext = default;
        EventHandler<ActivityChangedEventArgs> captureStartedActivity = (_, args) =>
        {
            if (!ReferenceEquals(s_connectionStartToken.Value, startToken))
            {
                return;
            }

            var candidate = IsConnectionActivity(args.Current)
                ? args.Current
                : IsConnectionActivity(args.Previous)
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
            var hasTraceparent = headers.ContainsKey(PlatformHeaders.TraceParent);
            var propagationContext = Propagators.DefaultTextMapPropagator.Extract(
                default,
                headers,
                static (carrier, key) => carrier.TryGetValue(key, out var values)
                    ? values
                    : Array.Empty<string>());
            extractedContext = propagationContext.ActivityContext;
            if (propagationContext.ActivityContext == default)
            {
                RecordPropagationFailure(hasTraceparent ? "invalid" : "missing");
            }

            TrySetCurrent(null);
            try
            {
                activity = s_activitySource.StartActivity(
                    ConnectionOperationName,
                    ActivityKind.Server,
                    propagationContext.ActivityContext);
            }
            catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
            {
                activity = startedActivity ?? Activity.Current;
                if (!IsConnectionActivity(activity))
                {
                    activity = null;
                }
            }
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
            activity = null;
        }
        finally
        {
            Activity.CurrentChanged -= captureStartedActivity;
            s_connectionStartToken.Value = previousStartToken;
            TrySetCurrent(previousActivity);
        }

        var connectionContext = activity?.Context ??
            CreateUnsampledChildContext(extractedContext);
        return new VoiceConnectionTelemetry(activity, connectionContext, previousActivity);
    }

    internal bool TryMarkRequestCancellation(CancellationToken requestCancellation)
    {
        if (!requestCancellation.IsCancellationRequested)
        {
            return false;
        }

        _requestCancelled = true;
        return true;
    }

    internal void MarkRequestCancelled() => _requestCancelled = true;

    internal void ObserveHandlerOutcome(
        InvocationsWebSocketCloseResult outcome,
        CancellationToken requestCancellation)
    {
        _requestCancelled = requestCancellation.IsCancellationRequested &&
            outcome.Code == 1006 &&
            outcome.Exception is null;
    }

    internal void EmitStructuredLog(Action emitLog)
    {
        var current = Activity.Current;
        try
        {
            TrySetCurrent(null);
            TryInvokeTelemetry(emitLog);
        }
        finally
        {
            TrySetCurrent(current);
        }
    }

    internal void Complete(
        string sessionId,
        int closeCode,
        string? errorCode,
        InvocationsWebSocketCloseResult? handlerOutcome,
        long durationMs)
    {
        if (_activity is null || Interlocked.Exchange(ref _completed, 1) != 0)
        {
            return;
        }

        _activity.SetTag(InvocationsWebSocketConstants.AttrSpanSessionId, sessionId);
        _activity.SetTag(InvocationsWebSocketConstants.AttrSpanCloseCode, closeCode);
        _activity.SetTag(InvocationsWebSocketConstants.AttrSpanDurationMs, durationMs);
        if (handlerOutcome?.CloseException is not null)
        {
            _activity.SetTag("bridge.close.outcome", "close_error");
        }

        var outcome = GetConnectionOutcome(closeCode, errorCode, handlerOutcome);
        _activity.SetTag("bridge.outcome", outcome);
        if (outcome is not "completed" and not "cancelled")
        {
            _activity.SetStatus(ActivityStatusCode.Error);
            _activity.SetTag("error.type", outcome);
        }

        TrySetCurrent(_previousActivity);
        try
        {
            TryInvokeTelemetry(_activity.Stop);
        }
        finally
        {
            TrySetCurrent(_previousActivity);
        }
    }

    private string GetConnectionOutcome(
        int closeCode,
        string? errorCode,
        InvocationsWebSocketCloseResult? handlerOutcome)
    {
        if (_requestCancelled)
        {
            return "cancelled";
        }
        if (errorCode == InvocationsWebSocketConstants.ErrorCodeAcceptFailed)
        {
            return "accept_error";
        }
        if (errorCode == "protocol_error")
        {
            return "protocol_error";
        }
        if (handlerOutcome?.Exception is not null)
        {
            return handlerOutcome.Value.Status is null
                ? "transport_error"
                : "callback_error";
        }
        if (handlerOutcome is { Exception: null } &&
            closeCode is not InvocationsWebSocketConstants.CloseNormal and not 1001)
        {
            return closeCode is 1002 or 1003 or 1007 or 1008 or 1009 or 1010
                ? "protocol_error"
                : "transport_error";
        }
        return closeCode is InvocationsWebSocketConstants.CloseNormal or 1001
            ? "completed"
            : "callback_error";
    }

    private static void RecordPropagationFailure(string reason)
    {
        try
        {
            s_propagationFailures.Add(1, new KeyValuePair<string, object?>("reason", reason));
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
    }

    private static bool IsConnectionActivity(Activity? activity) =>
        activity?.Source.Name == InvocationsActivitySource.DefaultName &&
        activity.OperationName == ConnectionOperationName;

    private static ActivityContext CreateUnsampledChildContext(ActivityContext parent) =>
        parent != default && (parent.TraceFlags & ActivityTraceFlags.Recorded) == 0
            ? new ActivityContext(
                parent.TraceId,
                ActivitySpanId.CreateRandom(),
                parent.TraceFlags,
                parent.TraceState,
                isRemote: false)
            : default;

    private static void TrySetCurrent(Activity? activity)
    {
        try
        {
            Activity.Current = activity;
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
        }
    }

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
