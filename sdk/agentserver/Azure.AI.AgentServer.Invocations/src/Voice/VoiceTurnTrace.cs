// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>Identifies the application-owned origin of a target-agent decision.</summary>
[Experimental("AAAS001")]
public enum VoiceTurnOrigin
{
    /// <summary>A user input initiated the decision.</summary>
    User,

    /// <summary>A no-input event initiated the decision.</summary>
    NoInput,

    /// <summary>Accepted proactive work initiated the decision.</summary>
    Proactive,

    /// <summary>A recovery workflow initiated the decision.</summary>
    Recovery,
}

/// <summary>Identifies the immutable terminal outcome of a target-agent decision.</summary>
[Experimental("AAAS001")]
public enum VoiceTurnOutcome
{
    /// <summary>The application produced a response.</summary>
    Response,

    /// <summary>The application intentionally produced no response.</summary>
    None,

    /// <summary>The decision timed out.</summary>
    Timeout,

    /// <summary>The decision failed.</summary>
    Error,

    /// <summary>The decision was cancelled.</summary>
    Cancelled,

    /// <summary>The decision ended the call.</summary>
    EndCall,

    /// <summary>The application classified the decision as a transport failure.</summary>
    TransportError,

    /// <summary>The application disposed the trace without supplying a result.</summary>
    Abandoned,
}

/// <summary>Contains application-owned terminal facts for one target-agent decision.</summary>
[Experimental("AAAS001")]
public sealed class VoiceTurnResult
{
    /// <summary>Initializes an immutable target-agent decision result.</summary>
    /// <param name="outcome">The sanitized terminal outcome.</param>
    /// <param name="outputItemCount">The number of successfully completed output items, or <see langword="null"/> when unknown.</param>
    /// <param name="responseId">The real response identifier, when one exists.</param>
    public VoiceTurnResult(
        VoiceTurnOutcome outcome,
        int? outputItemCount = null,
        string? responseId = null)
    {
        if (!Enum.IsDefined(outcome))
        {
            throw new ArgumentOutOfRangeException(nameof(outcome));
        }
        if (outputItemCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputItemCount));
        }
        if (responseId is not null && string.IsNullOrWhiteSpace(responseId))
        {
            throw new ArgumentException("The response ID cannot be empty.", nameof(responseId));
        }
        if (outcome == VoiceTurnOutcome.Response &&
            (responseId is null || outputItemCount is null or < 1))
        {
            throw new ArgumentException(
                "A response outcome requires a response ID and at least one completed output item.",
                nameof(outcome));
        }
        if (outcome == VoiceTurnOutcome.None &&
            (responseId is not null || outputItemCount is > 0))
        {
            throw new ArgumentException(
                "A none outcome requires no response ID and, when known, zero completed output items.",
                nameof(outcome));
        }

        Outcome = outcome;
        OutputItemCount = outputItemCount;
        ResponseId = responseId;
    }

    /// <summary>Gets the sanitized terminal outcome.</summary>
    public VoiceTurnOutcome Outcome { get; }

    /// <summary>Gets the number of successfully completed output items, when known.</summary>
    public int? OutputItemCount { get; }

    /// <summary>Gets the real response identifier, when one exists.</summary>
    public string? ResponseId { get; }
}

/// <summary>
/// Application-owned tracing handle for one target-agent decision.
/// </summary>
/// <remarks>
/// The application owns this handle, activates it around model/tool work, and supplies one
/// immutable terminal result. Voice transport termination does not complete the handle.
/// </remarks>
[Experimental("AAAS001")]
public class VoiceTurnTrace : IDisposable
{
    private const string OperationName = "invoke_agent";
    private static readonly ActivitySource s_activitySource = new("Azure.AI.AgentServer.Invocations");
    private static readonly AsyncLocal<object?> s_startToken = new();
    private readonly object _gate = new();
    private Activity? _activity;
    private int _activeActivations;
    private int _completed;

    /// <summary>Initializes a mockable no-op turn trace.</summary>
    protected VoiceTurnTrace()
    {
    }

    private VoiceTurnTrace(Activity? activity) => _activity = activity;

    /// <summary>
    /// Activates this turn as the lexical parent for customer model, tool, retrieval, and custom spans.
    /// </summary>
    /// <returns>A scope that restores the exact previous ambient activity when disposed.</returns>
    public virtual IDisposable Activate()
    {
        Activity? activity;
        lock (_gate)
        {
            activity = _activity;
            if (activity is null || _completed != 0 || activity.Duration != default)
            {
                return VoiceActivityScope.Empty;
            }
            _activeActivations++;
        }

        var activation = VoiceActivityScope.Activate(activity);
        if (!activation.IsActive)
        {
            ReleaseActivation();
            return VoiceActivityScope.Empty;
        }
        return new VoiceTurnActivation(this, activation);
    }

    /// <summary>Completes the turn with the first immutable application-supplied result.</summary>
    /// <param name="result">The application-owned terminal facts.</param>
    /// <remarks>
    /// Completion rejects later activations and stops the turn after every active
    /// scope returned by <see cref="Activate"/> has been disposed.
    /// </remarks>
    public virtual void Complete(VoiceTurnResult result)
    {
        ArgumentNullException.ThrowIfNull(result);
        Activity? activityToStop = null;
        lock (_gate)
        {
            if (_completed != 0)
            {
                return;
            }
            _completed = 1;

            var activity = _activity;
            if (activity is null)
            {
                return;
            }

            TryInvokeTelemetry(() => ApplyResult(activity, result));
            if (_activeActivations == 0)
            {
                _activity = null;
                activityToStop = activity;
            }
        }

        if (activityToStop is not null)
        {
            StopActivity(activityToStop);
        }
    }

    private void ReleaseActivation()
    {
        Activity? activityToStop = null;
        lock (_gate)
        {
            _activeActivations--;
            if (_activeActivations == 0 && _completed != 0)
            {
                activityToStop = _activity;
                _activity = null;
            }
        }

        if (activityToStop is not null)
        {
            StopActivity(activityToStop);
        }
    }

    private static void StopActivity(Activity activity)
    {
        var current = Activity.Current;
        TryInvokeTelemetry(activity.Stop);
        if (!ReferenceEquals(current, activity))
        {
            VoiceActivityScope.TrySetCurrent(current);
        }
    }

    /// <summary>
    /// Completes an unfinished turn as <see cref="VoiceTurnOutcome.Abandoned"/>.
    /// </summary>
    public virtual void Dispose() =>
        Complete(new VoiceTurnResult(VoiceTurnOutcome.Abandoned));

    internal static VoiceTurnTrace Start(
        ActivityContext connectionContext,
        VoiceTurnOrigin origin,
        int inputCount) =>
        Start(new VoiceTraceContext(connectionContext, default), origin, inputCount);

    internal static VoiceTurnTrace Start(
        VoiceTraceContext traceContext,
        VoiceTurnOrigin origin,
        int inputCount)
    {
        if (inputCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(inputCount));
        }
        if (!Enum.IsDefined(origin))
        {
            throw new ArgumentOutOfRangeException(nameof(origin));
        }
        if (traceContext.ActivityContext == default)
        {
            return new VoiceTurnTrace(activity: null);
        }

        var previous = Activity.Current;
        var previousStartToken = s_startToken.Value;
        var startToken = new object();
        Activity? activity = null;
        Activity? startedActivity = null;
        Activity? propagationActivity = null;
        // ActivityListener callbacks are cooperative diagnostics hooks. Recovery excludes the
        // caller's prior turn and stopped activities; callbacks must not substitute unrelated
        // live activities through Activity.Current during this synchronous creation window.
        bool IsStartCandidate(Activity? candidate) =>
            candidate?.Id is not null &&
            candidate.Duration == default &&
            !ReferenceEquals(candidate, previous) &&
            ReferenceEquals(candidate.Source, s_activitySource) &&
            IsTargetTurn(candidate);
        EventHandler<ActivityChangedEventArgs> captureStartedActivity = (_, args) =>
        {
            if (!ReferenceEquals(s_startToken.Value, startToken) || startedActivity is not null)
            {
                return;
            }
            if (IsStartCandidate(args.Current))
            {
                startedActivity = args.Current;
            }
            else if (IsStartCandidate(args.Previous))
            {
                startedActivity = args.Previous;
            }
        };
        try
        {
            // Isolate the caller's turn so a pre-creation listener failure cannot transfer it
            // to the handle returned by this start attempt.
            VoiceActivityScope.TrySetCurrent(null);
            s_startToken.Value = startToken;
            Activity.CurrentChanged += captureStartedActivity;
            var tags = new ActivityTagsCollection
            {
                ["gen_ai.operation.name"] = OperationName,
                ["gen_ai.system"] = "azure.ai.agentserver",
                ["gen_ai.provider.name"] = "AzureAI Hosted Agents",
                ["turn.origin"] = ToTagValue(origin),
                ["bridge.input.count"] = inputCount,
            };
            traceContext.CorrelationBaggage.AddStartTags(tags);
            activity = s_activitySource.StartActivity(
                OperationName,
                ActivityKind.Internal,
                traceContext.ActivityContext,
                tags);
            if (activity is null)
            {
                propagationActivity = new Activity(OperationName)
                    .SetParentId(
                        traceContext.ActivityContext.TraceId,
                        traceContext.ActivityContext.SpanId,
                        traceContext.ActivityContext.TraceFlags);
                propagationActivity.TraceStateString = traceContext.ActivityContext.TraceState;
                foreach (var tag in tags)
                {
                    propagationActivity.SetTag(tag.Key, tag.Value);
                }
                activity = propagationActivity.Start();
            }
        }
        catch (Exception exception) when (!ContainsOutOfMemoryException(exception))
        {
            // StartActivity may throw after creating an activity when a listener callback fails.
            // Retain only a candidate surfaced during this invocation's synchronous start window.
            activity = propagationActivity?.Id is not null
                ? propagationActivity
                : startedActivity;
            if (activity is null && IsStartCandidate(Activity.Current))
            {
                activity = Activity.Current;
            }
            if (!IsTargetTurn(activity))
            {
                activity = ReferenceEquals(activity, propagationActivity)
                    ? activity
                    : null;
            }
        }
        finally
        {
            Activity.CurrentChanged -= captureStartedActivity;
            try
            {
                // Keep this token installed while restoring ambient state so an outer observer
                // cannot claim a reentrant activity during the CurrentChanged notification.
                VoiceActivityScope.TrySetCurrent(previous);
            }
            finally
            {
                s_startToken.Value = previousStartToken;
            }
        }
        traceContext.ApplyBaggage(activity);
        return new VoiceTurnTrace(activity);
    }

    private static void ApplyResult(Activity activity, VoiceTurnResult result)
    {
        var outcome = ToTagValue(result.Outcome);
        activity.SetTag("bridge.outcome", outcome);
        if (result.OutputItemCount is not null)
        {
            activity.SetTag("bridge.output.item_count", result.OutputItemCount.Value);
        }
        if (result.ResponseId is not null)
        {
            activity.SetTag("gen_ai.response.id", result.ResponseId);
        }

        if (result.Outcome is not VoiceTurnOutcome.Response and
            not VoiceTurnOutcome.None and
            not VoiceTurnOutcome.Cancelled and
            not VoiceTurnOutcome.EndCall)
        {
            activity.SetStatus(ActivityStatusCode.Error, activity.StatusDescription);
            activity.SetTag("error.type", outcome);
        }
    }

    private static string ToTagValue(VoiceTurnOrigin origin) => origin switch
    {
        VoiceTurnOrigin.User => "user",
        VoiceTurnOrigin.NoInput => "no_input",
        VoiceTurnOrigin.Proactive => "proactive",
        VoiceTurnOrigin.Recovery => "recovery",
        _ => throw new ArgumentOutOfRangeException(nameof(origin)),
    };

    private static string ToTagValue(VoiceTurnOutcome outcome) => outcome switch
    {
        VoiceTurnOutcome.Response => "response",
        VoiceTurnOutcome.None => "none",
        VoiceTurnOutcome.Timeout => "timeout",
        VoiceTurnOutcome.Error => "error",
        VoiceTurnOutcome.Cancelled => "cancelled",
        VoiceTurnOutcome.EndCall => "end_call",
        VoiceTurnOutcome.TransportError => "transport_error",
        VoiceTurnOutcome.Abandoned => "abandoned",
        _ => throw new ArgumentOutOfRangeException(nameof(outcome)),
    };

    private static bool IsTargetTurn(Activity? activity) =>
        activity?.Source.Name == "Azure.AI.AgentServer.Invocations" &&
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

    private sealed class VoiceTurnActivation : IDisposable
    {
        private VoiceTurnTrace? _owner;
        private IDisposable? _activation;

        internal VoiceTurnActivation(VoiceTurnTrace owner, IDisposable activation)
        {
            _owner = owner;
            _activation = activation;
        }

        public void Dispose()
        {
            var activation = Interlocked.Exchange(ref _activation, null);
            if (activation is null)
            {
                return;
            }

            try
            {
                activation.Dispose();
            }
            finally
            {
                Interlocked.Exchange(ref _owner, null)?.ReleaseActivation();
            }
        }
    }
}
