// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

[TestFixture]
[NonParallelizable]
public class VoiceTurnTracingRedTests
{
    private static readonly TimeSpan TestTimeout = TimeSpan.FromSeconds(2);
    private const string ActivitySourceName = "Azure.AI.AgentServer.Invocations";
    private const string CustomerSourceName = "VoiceTurnTracingRedTests.Customer";
    private static readonly ActivityTraceId s_connectionTraceId =
        ActivityTraceId.CreateFromString("1234567890abcdef1234567890abcdef".AsSpan());
    private static readonly ActivitySpanId s_connectionSpanId =
        ActivitySpanId.CreateFromString("1234567890abcdef".AsSpan());

    [Test]
    public void StartTurn_UsesExplicitConnectionParentAndRestoresAmbientActivity()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        using var ambientSource = new ActivitySource("VoiceTurnTracingRedTests.Ambient");
        using var ambient = ambientSource.StartActivity("ambient")!;
        var session = CreateSession(CreateConnectionContext(recorded: true));

        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 2);
        var activity = activities.Single(IsTargetTurn);

        Assert.Multiple(() =>
        {
            Assert.That(Activity.Current, Is.SameAs(ambient));
            Assert.That(activity.TraceId, Is.EqualTo(s_connectionTraceId));
            Assert.That(activity.ParentSpanId, Is.EqualTo(s_connectionSpanId));
            Assert.That(activity.TraceStateString, Is.EqualTo("vendor=value"));
            Assert.That(activity.Kind, Is.EqualTo(ActivityKind.Internal));
            Assert.That(activity.GetTagItem("gen_ai.operation.name"), Is.EqualTo("invoke_agent"));
            Assert.That(activity.GetTagItem("turn.origin"), Is.EqualTo("user"));
            Assert.That(activity.GetTagItem("bridge.input.count"), Is.EqualTo(2));
        });
    }

    [Test]
    public async Task BackgroundTask_OutlivesActivationScope_TargetSpanRemainsParent()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        using var customerSource = new ActivitySource(CustomerSourceName);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        Task<ActivitySpanId> childParent;
        using (turn.Activate())
        {
            childParent = Task.Run(() =>
            {
                using var child = customerSource.StartActivity("customer.model")!;
                return child.ParentSpanId;
            });
        }

        var target = activities.Single(IsTargetTurn);
        Assert.That(await childParent, Is.EqualTo(target.SpanId));
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
    }

    [Test]
    public async Task ConcurrentCompletion_DefersStopUntilActivationIsReleased()
    {
        var started = new ConcurrentQueue<Activity>();
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(started, stopped);
        using var customerSource = new ActivitySource(CustomerSourceName);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        var activationEntered = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var continueAfterCompletion = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);

        var activatedWork = Task.Run(async () =>
        {
            using (turn.Activate())
            {
                activationEntered.TrySetResult();
                await continueAfterCompletion.Task;
                var ambientWasRunning = Activity.Current?.Duration == TimeSpan.Zero;
                using var child = customerSource.StartActivity("customer.after-completion")!;
                return (AmbientWasRunning: ambientWasRunning, child.ParentSpanId);
            }
        });

        await activationEntered.Task.WaitAsync(TestTimeout);
        var target = started.Single(IsTargetTurn);
        await Task.Run(() => turn.Complete(
            new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0)));
        var stoppedBeforeRelease = stopped.Any(IsTargetTurn);
        continueAfterCompletion.TrySetResult();
        var observation = await activatedWork.WaitAsync(TestTimeout);

        Assert.Multiple(() =>
        {
            Assert.That(stoppedBeforeRelease, Is.False);
            Assert.That(observation.AmbientWasRunning, Is.True);
            Assert.That(observation.ParentSpanId, Is.EqualTo(target.SpanId));
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
        });
    }

    [Test]
    public void Completion_WaitsForEveryActivationLease()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        using var outerActivation = turn.Activate();
        using var innerActivation = turn.Activate();

        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        Assert.That(stopped.Any(IsTargetTurn), Is.False);

        innerActivation.Dispose();
        Assert.That(stopped.Any(IsTargetTurn), Is.False);

        outerActivation.Dispose();
        Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
    }

    [Test]
    public void CustomerSpanWithoutStartTurn_DoesNotCreateOrInheritTargetTurn()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        using var customerSource = new ActivitySource(CustomerSourceName);
        _ = CreateSession(CreateConnectionContext(recorded: true));

        using var child = customerSource.StartActivity("customer.model")!;

        Assert.Multiple(() =>
        {
            Assert.That(activities.Any(IsTargetTurn), Is.False);
            Assert.That(child.ParentSpanId, Is.Not.EqualTo(s_connectionSpanId));
        });
    }

    [Test]
    public void Complete_FirstApplicationResultWinsAndStopsExactlyOnce()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 3);

        turn.Complete(new VoiceTurnResult(
            VoiceTurnOutcome.Response,
            outputItemCount: 2,
            responseId: "response_real"));
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        turn.Dispose();

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo("response"));
            Assert.That(activity.GetTagItem("bridge.output.item_count"), Is.EqualTo(2));
            Assert.That(activity.GetTagItem("gen_ai.response.id"), Is.EqualTo("response_real"));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Unset));
        });
    }

    [TestCase(VoiceTurnOutcome.Response)]
    [TestCase(VoiceTurnOutcome.None)]
    [TestCase(VoiceTurnOutcome.Cancelled)]
    [TestCase(VoiceTurnOutcome.EndCall)]
    public void SuccessfulCompletion_DoesNotOverwriteExistingErrorStatus(
        VoiceTurnOutcome outcome)
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        using (turn.Activate())
        {
            Assert.That(Activity.Current?.OperationName, Is.EqualTo("invoke_agent"));
            Activity.Current!.SetStatus(
                ActivityStatusCode.Error,
                "downstream instrumentation failure");
        }
        var result = outcome switch
        {
            VoiceTurnOutcome.Response => new VoiceTurnResult(outcome, 1, "response_after_error"),
            VoiceTurnOutcome.None => new VoiceTurnResult(outcome, 0),
            _ => new VoiceTurnResult(outcome),
        };
        turn.Complete(result);
        var expectedOutcome = outcome switch
        {
            VoiceTurnOutcome.Response => "response",
            VoiceTurnOutcome.None => "none",
            VoiceTurnOutcome.Cancelled => "cancelled",
            VoiceTurnOutcome.EndCall => "end_call",
            _ => throw new ArgumentOutOfRangeException(nameof(outcome)),
        };

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(
                activity.StatusDescription,
                Is.EqualTo("downstream instrumentation failure"));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo(expectedOutcome));
        });
    }

    [TestCase(VoiceTurnOutcome.Error, "error")]
    [TestCase(VoiceTurnOutcome.Timeout, "timeout")]
    [TestCase(VoiceTurnOutcome.TransportError, "transport_error")]
    [TestCase(VoiceTurnOutcome.Abandoned, "abandoned")]
    public void ErrorCompletion_PreservesExistingStatusDescription(
        VoiceTurnOutcome outcome,
        string expectedOutcome)
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        using (turn.Activate())
        {
            Activity.Current!.SetStatus(
                ActivityStatusCode.Error,
                "downstream instrumentation failure");
        }
        turn.Complete(new VoiceTurnResult(outcome));
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(
                activity.StatusDescription,
                Is.EqualTo("downstream instrumentation failure"));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo(expectedOutcome));
            Assert.That(activity.GetTagItem("error.type"), Is.EqualTo(expectedOutcome));
        });
    }

    [TestCase(VoiceTurnOutcome.Error, "error")]
    [TestCase(VoiceTurnOutcome.Timeout, "timeout")]
    [TestCase(VoiceTurnOutcome.TransportError, "transport_error")]
    [TestCase(VoiceTurnOutcome.Abandoned, "abandoned")]
    public void ErrorCompletion_WithoutExistingStatusDescription_DoesNotCreateOne(
        VoiceTurnOutcome outcome,
        string expectedOutcome)
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        turn.Complete(new VoiceTurnResult(outcome));
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
            Assert.That(activity.StatusDescription, Is.Null);
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo(expectedOutcome));
            Assert.That(activity.GetTagItem("error.type"), Is.EqualTo(expectedOutcome));
        });
    }

    [Test]
    public void DisposeWithoutCompletion_RecordsAbandonedOnce()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        var turn = session.StartTurn(VoiceTurnOrigin.NoInput, inputCount: 1);

        turn.Dispose();
        turn.Dispose();

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo("abandoned"));
            Assert.That(activity.GetTagItem("error.type"), Is.EqualTo("abandoned"));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        });
    }

    [Test]
    public void UnsampledConnection_DoesNotForceRecording()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(
            activities,
            sample: static (ref ActivityCreationOptions<ActivityContext> options) =>
                (options.Parent.TraceFlags & ActivityTraceFlags.Recorded) != 0
                    ? ActivitySamplingResult.AllDataAndRecorded
                    : ActivitySamplingResult.PropagationData);
        var session = CreateSession(CreateConnectionContext(recorded: false));
        using var turn = session.StartTurn(VoiceTurnOrigin.Proactive, inputCount: 0);
        var activity = activities.Single(IsTargetTurn);

        Assert.Multiple(() =>
        {
            Assert.That(activity.Recorded, Is.False);
            Assert.That(activity.IsAllDataRequested, Is.False);
            Assert.That(activity.TraceId, Is.EqualTo(s_connectionTraceId));
            Assert.That(activity.ParentSpanId, Is.EqualTo(s_connectionSpanId));
        });
    }

    [Test]
    public void ListenerAvailability_StartActivateCompleteAndDisposeAreSafe()
    {
        using var ambient = new Activity("ambient").Start();
        var session = CreateSession(CreateConnectionContext(recorded: true));

        var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        using (turn.Activate())
        {
            Assert.That(
                ReferenceEquals(Activity.Current, ambient) ||
                Activity.Current?.OperationName == "invoke_agent",
                Is.True);
        }
        Assert.That(Activity.Current, Is.SameAs(ambient));
        Assert.That(
            () => turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0)),
            Throws.Nothing);
        Assert.That(() => turn.Dispose(), Throws.Nothing);

        Assert.That(Activity.Current, Is.SameAs(ambient));
    }

    [Test]
    public void PublicTurnTypes_AreMockable()
    {
        var session = new MockVoiceSession();

        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        using var activation = turn.Activate();
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        Assert.Multiple(() =>
        {
            Assert.That(session.StartCount, Is.EqualTo(1));
            Assert.That(((MockVoiceTurnTrace)turn).ActivationCount, Is.EqualTo(1));
            Assert.That(((MockVoiceTurnTrace)turn).CompletionCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void ActivationScope_RestoresItsOwnPreviousAmbientAfterCompletion()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        using var ambientSource = new ActivitySource("VoiceTurnTracingRedTests.AmbientRestore");
        using var creationAmbient = ambientSource.StartActivity("creation-ambient")!;
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        using var activationAmbient = ambientSource.StartActivity("activation-ambient")!;

        using (turn.Activate())
        {
            turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        }

        Assert.That(Activity.Current, Is.SameAs(activationAmbient));
    }

    [Test]
    public void InvalidEnums_FailLoudBeforeTelemetryStarts()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        var session = CreateSession(CreateConnectionContext(recorded: true));

        Assert.Multiple(() =>
        {
            Assert.That(
                () => session.StartTurn((VoiceTurnOrigin)int.MaxValue, inputCount: 1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new VoiceTurnResult((VoiceTurnOutcome)int.MaxValue),
                Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(activities.Any(IsTargetTurn), Is.False);
        });
    }

    [Test]
    public void VoiceTurnResult_RejectsContradictoryApplicationFacts()
    {
        Assert.Multiple(() =>
        {
            Assert.That(
                () => new VoiceTurnResult(VoiceTurnOutcome.Error, outputItemCount: -1),
                Throws.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(
                () => new VoiceTurnResult(VoiceTurnOutcome.Error, responseId: " "),
                Throws.TypeOf<ArgumentException>());
            Assert.That(
                () => new VoiceTurnResult(VoiceTurnOutcome.Response, outputItemCount: 1),
                Throws.TypeOf<ArgumentException>());
            Assert.That(
                () => new VoiceTurnResult(
                    VoiceTurnOutcome.Response,
                    outputItemCount: 0,
                    responseId: "response_invalid"),
                Throws.TypeOf<ArgumentException>());
            Assert.That(
                () => new VoiceTurnResult(
                    VoiceTurnOutcome.None,
                    outputItemCount: 0,
                    responseId: "response_invalid"),
                Throws.TypeOf<ArgumentException>());
            Assert.That(
                () => new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 1),
                Throws.TypeOf<ArgumentException>());
        });
    }

    [Test]
    public void VoiceTurnResult_NoneAcceptsUnknownOrZeroOutputItemCount()
    {
        var unknown = new VoiceTurnResult(VoiceTurnOutcome.None);
        var zero = new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0);

        Assert.Multiple(() =>
        {
            Assert.That(unknown.Outcome, Is.EqualTo(VoiceTurnOutcome.None));
            Assert.That(unknown.OutputItemCount, Is.Null);
            Assert.That(unknown.ResponseId, Is.Null);
            Assert.That(zero.OutputItemCount, Is.Zero);
            Assert.That(zero.ResponseId, Is.Null);
        });
    }

    [Test]
    public void Complete_NoneWithUnknownOutputItemCount_OmitsCountTag()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None));
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo("none"));
            Assert.That(activity.GetTagItem("bridge.output.item_count"), Is.Null);
            Assert.That(activity.GetTagItem("gen_ai.response.id"), Is.Null);
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Unset));
        });
    }

    [Test]
    public async Task OrdinarySendAsync_DoesNotCompleteOrMutateTargetTurn()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        using var webSocket = new TurnTerminationWebSocket();
        var connection = new InvocationsWebSocketConnection(webSocket);
        var session = new VoiceSession(
            connection,
            CreateInvocationContext(),
            CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);

        await session.SendAsync(new VoiceResponseNoneMessage(new[] { "in_real" }, "application_fact"));

        Assert.That(stopped.Any(IsTargetTurn), Is.False);
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo("none"));
            Assert.That(activity.GetTagItem("gen_ai.response.id"), Is.Null);
            Assert.That(activity.GetTagItem("bridge.output.item_count"), Is.EqualTo(0));
        });
    }

    [Test]
    public void ConcurrentDuplicateCompletion_StopsExactlyOnce()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        var result = new VoiceTurnResult(
            VoiceTurnOutcome.Response,
            outputItemCount: 1,
            responseId: "response_concurrent");

        Parallel.For(0, 32, _ => turn.Complete(result));

        Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
    }

    [Test]
    public void ActivateAfterCompletion_IsNoOpAndPreservesAmbient()
    {
        var activities = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(activities);
        using var ambientSource = new ActivitySource("VoiceTurnTracingRedTests.LateActivation");
        using var ambient = ambientSource.StartActivity("ambient")!;
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        turn.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        using var activation = turn.Activate();

        Assert.That(Activity.Current, Is.SameAs(ambient));
    }

    [Test]
    public void NestedStart_SampleFailureDoesNotAdoptOuterTurnAndRetrySucceeds()
    {
        var started = new ConcurrentQueue<Activity>();
        var stopped = new ConcurrentQueue<Activity>();
        using var captureListener = CreateListener(started, stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var outer = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        var outerActivity = started.Single(IsTargetTurn);

        using (outer.Activate())
        {
            using (var throwingListener = new ActivityListener
            {
                ShouldListenTo = static source => source.Name == ActivitySourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                    throw new InvalidOperationException("injected Sample failure"),
            })
            {
                ActivitySource.AddActivityListener(throwingListener);
                using var failedInner = session.StartTurn(VoiceTurnOrigin.Proactive, inputCount: 0);
                failedInner.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
            }

            Assert.Multiple(() =>
            {
                Assert.That(Activity.Current, Is.SameAs(outerActivity));
                Assert.That(started.Count(IsTargetTurn), Is.EqualTo(1));
                Assert.That(stopped.Any(IsTargetTurn), Is.False);
                Assert.That(outerActivity.Duration, Is.EqualTo(default(TimeSpan)));
                Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.Null);
                Assert.That(outerActivity.GetTagItem("bridge.output.item_count"), Is.Null);
                Assert.That(outerActivity.GetTagItem("gen_ai.response.id"), Is.Null);
            });

            using var retry = session.StartTurn(VoiceTurnOrigin.Proactive, inputCount: 0);
            var retryActivity = started.Single(activity =>
                IsTargetTurn(activity) && !ReferenceEquals(activity, outerActivity));
            retry.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

            Assert.Multiple(() =>
            {
                Assert.That(Activity.Current, Is.SameAs(outerActivity));
                Assert.That(stopped.Single(IsTargetTurn), Is.SameAs(retryActivity));
                Assert.That(outerActivity.Duration, Is.EqualTo(default(TimeSpan)));
                Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.Null);
            });
        }

        outer.Complete(new VoiceTurnResult(
            VoiceTurnOutcome.Response,
            outputItemCount: 1,
            responseId: "outer_after_retry"));

        var targets = stopped.Where(IsTargetTurn).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(targets, Has.Length.EqualTo(2));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, outerActivity)), Is.EqualTo(1));
            Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.EqualTo("response"));
            Assert.That(outerActivity.GetTagItem("gen_ai.response.id"), Is.EqualTo("outer_after_retry"));
        });
    }

    [Test]
    public void NestedStart_SampleFailureDoesNotAdoptReentrantTurn()
    {
        var started = new ConcurrentQueue<Activity>();
        var stopped = new ConcurrentQueue<Activity>();
        using var captureListener = CreateListener(started, stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var outer = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        var outerActivity = started.Single(IsTargetTurn);
        VoiceTurnTrace? reentrant = null;
        var sampleCount = 0;

        using (outer.Activate())
        {
            using (var throwingListener = new ActivityListener
            {
                ShouldListenTo = static source => source.Name == ActivitySourceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> _) =>
                {
                    if (Interlocked.Increment(ref sampleCount) == 1)
                    {
                        reentrant = session.StartTurn(VoiceTurnOrigin.Recovery, inputCount: 0);
                        throw new InvalidOperationException("injected Sample failure after reentrant start");
                    }
                    return ActivitySamplingResult.AllDataAndRecorded;
                },
            })
            {
                ActivitySource.AddActivityListener(throwingListener);
                using var failedInner = session.StartTurn(VoiceTurnOrigin.Proactive, inputCount: 0);
                failedInner.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
            }

            var reentrantActivity = started.Single(activity =>
                IsTargetTurn(activity) && !ReferenceEquals(activity, outerActivity));
            Assert.Multiple(() =>
            {
                Assert.That(reentrant, Is.Not.Null);
                Assert.That(sampleCount, Is.EqualTo(2));
                Assert.That(Activity.Current, Is.SameAs(outerActivity));
                Assert.That(started.Count(IsTargetTurn), Is.EqualTo(2));
                Assert.That(stopped.Any(IsTargetTurn), Is.False);
                Assert.That(reentrantActivity.Duration, Is.EqualTo(default(TimeSpan)));
                Assert.That(reentrantActivity.GetTagItem("bridge.outcome"), Is.Null);
                Assert.That(outerActivity.Duration, Is.EqualTo(default(TimeSpan)));
                Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.Null);
            });

            reentrant!.Complete(new VoiceTurnResult(
                VoiceTurnOutcome.Response,
                outputItemCount: 1,
                responseId: "reentrant_response"));

            Assert.Multiple(() =>
            {
                Assert.That(Activity.Current, Is.SameAs(outerActivity));
                Assert.That(stopped.Single(IsTargetTurn), Is.SameAs(reentrantActivity));
                Assert.That(reentrantActivity.GetTagItem("bridge.outcome"), Is.EqualTo("response"));
                Assert.That(
                    reentrantActivity.GetTagItem("gen_ai.response.id"),
                    Is.EqualTo("reentrant_response"));
                Assert.That(outerActivity.Duration, Is.EqualTo(default(TimeSpan)));
                Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.Null);
            });
        }

        outer.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var targets = stopped.Where(IsTargetTurn).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(targets, Has.Length.EqualTo(2));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, outerActivity)), Is.EqualTo(1));
            Assert.That(outerActivity.GetTagItem("bridge.outcome"), Is.EqualTo("none"));
        });
    }

    [Test]
    public void CurrentChangedFailure_DoesNotLeakTargetOrBlockLaterTurn()
    {
        var started = new ConcurrentQueue<Activity>();
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(started, stopped);
        using var ambientSource = new ActivitySource("VoiceTurnTracingRedTests.CurrentChangedFailure");
        using var ambient = ambientSource.StartActivity("ambient")!;
        var session = CreateSession(CreateConnectionContext(recorded: true));
        Activity? failedTarget = null;
        EventHandler<ActivityChangedEventArgs> throwingHandler = (_, args) =>
        {
            if (IsTargetTurn(args.Current))
            {
                failedTarget ??= args.Current;
                throw new InvalidOperationException("injected CurrentChanged failure");
            }
        };
        Activity.CurrentChanged += throwingHandler;
        VoiceTurnTrace? first = null;
        try
        {
            Assert.That(
                () => first = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1),
                Throws.Nothing);
            Assert.That(() => first!.Complete(
                new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0)), Throws.Nothing);
        }
        finally
        {
            Activity.CurrentChanged -= throwingHandler;
        }

        using var second = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        second.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        var retryTarget = started.Single(activity =>
            IsTargetTurn(activity) && !ReferenceEquals(activity, failedTarget));

        var targets = stopped.Where(IsTargetTurn).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(Activity.Current, Is.SameAs(ambient));
            Assert.That(failedTarget, Is.Not.Null);
            Assert.That(targets, Has.Length.EqualTo(2));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, failedTarget)), Is.EqualTo(1));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, retryTarget)), Is.EqualTo(1));
            Assert.That(retryTarget, Is.Not.SameAs(failedTarget));
            Assert.That(targets.All(activity => activity.Duration != default), Is.True);
        });
    }

    [Test]
    public void ActivityCallbackFailures_AreObservationalAndLaterTurnSucceeds()
    {
        var started = new ConcurrentQueue<Activity>();
        using var captureListener = CreateListener(started);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using (var throwingListener = new ActivityListener
        {
            ShouldListenTo = static source => source.Name == ActivitySourceName,
            Sample = SampleAllDataAndRecorded,
            ActivityStarted = activity =>
            {
                if (IsTargetTurn(activity))
                {
                    throw new InvalidOperationException("injected ActivityStarted failure");
                }
            },
            ActivityStopped = activity =>
            {
                if (IsTargetTurn(activity))
                {
                    throw new InvalidOperationException("injected ActivityStopped failure");
                }
            },
        })
        {
            ActivitySource.AddActivityListener(throwingListener);
            VoiceTurnTrace? first = null;
            Assert.That(
                () => first = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1),
                Throws.Nothing);
            Assert.That(() => first!.Complete(
                new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0)), Throws.Nothing);
        }

        using var second = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        second.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var targets = started.Where(IsTargetTurn).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(targets, Has.Length.EqualTo(2));
            Assert.That(targets.All(activity => activity.Duration != default), Is.True);
        });
    }

    [Test]
    public void CurrentChangedMutationToPriorTarget_DoesNotAdoptOrReopenPriorActivity()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        var session = CreateSession(CreateConnectionContext(recorded: true));
        using var prior = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        prior.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));
        var priorActivity = stopped.Single(IsTargetTurn);
        Activity? currentActivity = null;
        var mutationCount = 0;
        EventHandler<ActivityChangedEventArgs> hostile = (_, args) =>
        {
            if (IsTargetTurn(args.Current) &&
                !ReferenceEquals(args.Current, priorActivity) &&
                Interlocked.Increment(ref mutationCount) == 1)
            {
                currentActivity = args.Current;
                Activity.Current = priorActivity;
                throw new InvalidOperationException("injected prior-target mutation");
            }
        };
        Activity.CurrentChanged += hostile;
        VoiceTurnTrace? current = null;
        try
        {
            Assert.That(
                () => current = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1),
                Throws.Nothing);
            Assert.That(() => current!.Complete(new VoiceTurnResult(
                VoiceTurnOutcome.Response,
                outputItemCount: 1,
                responseId: "response_after_mutation")), Throws.Nothing);
        }
        finally
        {
            Activity.CurrentChanged -= hostile;
            Activity.Current = null;
        }

        using var later = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        later.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        var targets = stopped.Where(IsTargetTurn).ToArray();
        Assert.Multiple(() =>
        {
            Assert.That(mutationCount, Is.EqualTo(1));
            Assert.That(currentActivity, Is.Not.Null);
            Assert.That(targets, Has.Length.EqualTo(3));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, priorActivity)), Is.EqualTo(1));
            Assert.That(targets.Count(activity => ReferenceEquals(activity, currentActivity)), Is.EqualTo(1));
            Assert.That(targets.Select(activity => activity.SpanId).Distinct().ToArray(), Has.Length.EqualTo(3));
            Assert.That(priorActivity.GetTagItem("bridge.outcome"), Is.EqualTo("none"));
            Assert.That(currentActivity!.GetTagItem("gen_ai.response.id"), Is.EqualTo("response_after_mutation"));
            Assert.That(currentActivity, Is.Not.SameAs(priorActivity));
        });
    }

    [Test]
    public void UnsampledCurrentChangedFailure_StopsExactActivityAndLaterTurnSucceeds()
    {
        using var ambient = new Activity("ambient").Start();
        var session = CreateSession(CreateConnectionContext(recorded: false));
        Activity? failedTarget = null;
        EventHandler<ActivityChangedEventArgs> hostile = (_, args) =>
        {
            if (args.Current?.OperationName == "invoke_agent" && failedTarget is null)
            {
                failedTarget = args.Current;
                throw new InvalidOperationException("injected unsampled CurrentChanged failure");
            }
        };
        Activity.CurrentChanged += hostile;
        VoiceTurnTrace? first = null;
        try
        {
            Assert.That(
                () => first = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1),
                Throws.Nothing);
            Assert.That(() => first!.Complete(
                new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0)), Throws.Nothing);
        }
        finally
        {
            Activity.CurrentChanged -= hostile;
        }

        using var later = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
        using (later.Activate())
        {
            Assert.That(Activity.Current?.OperationName, Is.EqualTo("invoke_agent"));
        }
        later.Complete(new VoiceTurnResult(VoiceTurnOutcome.None, outputItemCount: 0));

        Assert.Multiple(() =>
        {
            Assert.That(failedTarget, Is.Not.Null);
            Assert.That(failedTarget?.Duration, Is.Not.EqualTo(default(TimeSpan)));
            Assert.That(Activity.Current, Is.SameAs(ambient));
        });
    }

    [Test]
    public async Task ConnectionTermination_DoesNotCompleteTurn_ApplicationCanCompleteAfterward()
    {
        var stopped = new ConcurrentQueue<Activity>();
        using var listener = CreateListener(stoppedActivities: stopped);
        using var webSocket = new TurnTerminationWebSocket(
            SessionStartFrame(),
            ReceiveFrame.Close(WebSocketCloseStatus.NormalClosure, "done"));
        var connection = new InvocationsWebSocketConnection(webSocket);
        var handler = new TurnOwningHandler();

        _ = await handler.HandleWebSocketConnectionAsync(
            connection,
            CreateInvocationContext(),
            CreateConnectionContext(recorded: true),
            CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(handler.TerminationCount, Is.EqualTo(1));
            Assert.That(handler.Turn, Is.Not.Null);
            Assert.That(stopped.Any(IsTargetTurn), Is.False);
        });

        handler.Turn!.Complete(new VoiceTurnResult(
            VoiceTurnOutcome.TransportError,
            outputItemCount: null,
            responseId: null));

        var activity = stopped.Single(IsTargetTurn);
        Assert.Multiple(() =>
        {
            Assert.That(stopped.Count(IsTargetTurn), Is.EqualTo(1));
            Assert.That(activity.GetTagItem("bridge.outcome"), Is.EqualTo("transport_error"));
            Assert.That(activity.GetTagItem("error.type"), Is.EqualTo("transport_error"));
            Assert.That(activity.Status, Is.EqualTo(ActivityStatusCode.Error));
        });
        handler.Turn.Dispose();
    }

    private static VoiceSession CreateSession(ActivityContext connectionContext) =>
        new(CreateInvocationContext(), connectionContext);

    private static InvocationContext CreateInvocationContext() =>
        new(
            invocationId: "invocation_turn_trace",
            sessionId: "session_turn_trace",
            clientHeaders: new Dictionary<string, string>(),
            queryParameters: new Dictionary<string, StringValues>(),
            platformContext: PlatformContext.Empty);

    private static ActivityContext CreateConnectionContext(bool recorded) =>
        new(
            s_connectionTraceId,
            s_connectionSpanId,
            recorded ? ActivityTraceFlags.Recorded : ActivityTraceFlags.None,
            traceState: "vendor=value");

    private static ReceiveFrame SessionStartFrame() => new(
        Encoding.UTF8.GetBytes("""
            {"type":"session.start","id":"m_1","ts":"2026-08-13T00:00:00.000Z","protocol_version":"1.0","reconnect":false,"response_timeouts":{"first_output_ms":1,"idle_ms":2,"max_duration_ms":3}}
            """),
        WebSocketMessageType.Text,
        EndOfMessage: true);

    private static ActivityListener CreateListener(
        ConcurrentQueue<Activity>? startedActivities = null,
        ConcurrentQueue<Activity>? stoppedActivities = null,
        SampleActivity<ActivityContext>? sample = null)
    {
        var listener = new ActivityListener
        {
            ShouldListenTo = static source =>
                source.Name == ActivitySourceName ||
                source.Name.StartsWith("VoiceTurnTracingRedTests.", StringComparison.Ordinal),
            Sample = sample ?? SampleAllDataAndRecorded,
            ActivityStarted = activity => startedActivities?.Enqueue(activity),
            ActivityStopped = activity => stoppedActivities?.Enqueue(activity),
        };
        ActivitySource.AddActivityListener(listener);
        return listener;
    }

    private static ActivitySamplingResult SampleAllDataAndRecorded(
        ref ActivityCreationOptions<ActivityContext> _) =>
        ActivitySamplingResult.AllDataAndRecorded;

    private static bool IsTargetTurn(Activity activity) =>
        activity.Source.Name == ActivitySourceName &&
        activity.OperationName == "invoke_agent";

    private sealed class MockVoiceSession : VoiceSession
    {
        public int StartCount { get; private set; }

        public override VoiceTurnTrace StartTurn(VoiceTurnOrigin origin, int inputCount)
        {
            StartCount++;
            return new MockVoiceTurnTrace();
        }
    }

    private sealed class MockVoiceTurnTrace : VoiceTurnTrace
    {
        public int ActivationCount { get; private set; }

        public int CompletionCount { get; private set; }

        public override IDisposable Activate()
        {
            ActivationCount++;
            return new MockActivation();
        }

        public override void Complete(VoiceTurnResult result) => CompletionCount++;

        private sealed class MockActivation : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }

    private sealed class TurnOwningHandler : VoiceHandler
    {
        public VoiceTurnTrace? Turn { get; private set; }

        public int TerminationCount { get; private set; }

        protected override Task OnSessionStartAsync(
            VoiceSession session,
            VoiceSessionStartEvent start,
            CancellationToken cancellationToken)
        {
            Turn = session.StartTurn(VoiceTurnOrigin.User, inputCount: 1);
            return Task.CompletedTask;
        }

        protected override void OnConnectionTerminating(VoiceSession session) => TerminationCount++;
    }

    private readonly record struct ReceiveFrame(
        byte[] Payload,
        WebSocketMessageType MessageType,
        bool EndOfMessage,
        WebSocketCloseStatus? CloseStatus = null,
        string? CloseReason = null)
    {
        public static ReceiveFrame Close(WebSocketCloseStatus status, string? reason) =>
            new(Array.Empty<byte>(), WebSocketMessageType.Close, EndOfMessage: true, status, reason);
    }

    private sealed class TurnTerminationWebSocket : WebSocket
    {
        private readonly Queue<ReceiveFrame> _frames;
        private WebSocketState _state = WebSocketState.Open;
        private WebSocketCloseStatus? _closeStatus;
        private string? _closeReason;

        public TurnTerminationWebSocket(params ReceiveFrame[] frames) =>
            _frames = new Queue<ReceiveFrame>(frames);

        public override WebSocketCloseStatus? CloseStatus => _closeStatus;

        public override string? CloseStatusDescription => _closeReason;

        public override WebSocketState State => _state;

        public override string? SubProtocol => null;

        public override void Abort() => _state = WebSocketState.Aborted;

        public override Task CloseAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken) =>
            CloseOutputAsync(closeStatus, statusDescription, cancellationToken);

        public override Task CloseOutputAsync(
            WebSocketCloseStatus closeStatus,
            string? statusDescription,
            CancellationToken cancellationToken)
        {
            _state = WebSocketState.CloseSent;
            return Task.CompletedTask;
        }

        public override Task<WebSocketReceiveResult> ReceiveAsync(
            ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            var frame = _frames.Dequeue();
            frame.Payload.AsSpan().CopyTo(buffer.AsSpan());
            if (frame.MessageType == WebSocketMessageType.Close)
            {
                _closeStatus = frame.CloseStatus;
                _closeReason = frame.CloseReason;
                _state = WebSocketState.CloseReceived;
            }
            return Task.FromResult(new WebSocketReceiveResult(
                frame.Payload.Length,
                frame.MessageType,
                frame.EndOfMessage,
                frame.CloseStatus,
                frame.CloseReason));
        }

        public override Task SendAsync(
            ArraySegment<byte> buffer,
            WebSocketMessageType messageType,
            bool endOfMessage,
            CancellationToken cancellationToken) => Task.CompletedTask;

        public override void Dispose() => _state = WebSocketState.Closed;
    }
}
