// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class RetryTests
{
    [Test]
    public async Task NoRetryPolicyConfigured_FailsOnFirstRaise()
    {
        // Retry is opt-in (spec §15): with no configured TaskRetryPolicy the handler must fail on the
        // first raise (a single attempt), matching the Python reference — NOT silently retry 3x.
        using TaskTestHost host = TaskTestHost.Create();
        var attempts = new List<int>();

        host.Builder.AddTask<string, string>(
            "no-retry",
            (ctx, ct) =>
            {
                attempts.Add(ctx.RetryAttempt);
                throw new InvalidOperationException("boom");
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "no-retry", "in", new RunOptions { TaskId = "t1" });

        ResilientTaskException ex = Assert.ThrowsAsync<ResilientTaskException>(async () => await run.Completion);
        Assert.That(ex.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.HandlerError));
        Assert.That(ex.Failure!.Kind, Is.EqualTo(TaskFailureKind.HandlerError));
        Assert.That(attempts, Is.EqualTo(new[] { 0 }));
    }

    [Test]
    public async Task RetriesWithConfiguredAttemptsThenExhausts()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var attempts = new List<int>();

        host.Builder.AddTask<string, string>(
            "flaky",
            (ctx, ct) =>
            {
                attempts.Add(ctx.RetryAttempt);
                throw new InvalidOperationException("always fails");
            },
            configure: o => o.Retry = new TaskRetryPolicy { MaxAttempts = 3, Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromMilliseconds(1)) });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "flaky", "in", new RunOptions { TaskId = "t1" });

        ResilientTaskException ex = Assert.ThrowsAsync<ResilientTaskException>(async () => await run.Completion);
        Assert.That(ex.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.ExhaustedRetries));
        Assert.That(ex.Failure!.Kind, Is.EqualTo(TaskFailureKind.ExhaustedRetries));
        Assert.That(ex.Failure!.Attempts, Is.EqualTo(3));
        Assert.That(attempts, Is.EqualTo(new[] { 0, 1, 2 }));
    }

    [Test]
    public async Task CrashMidRetryDoesNotConsumeBudget()
    {
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);
        var lifetime1Attempts = new List<int>();

        // Attempts 0 and 1 raise (persisting _retry_attempt=1 then =2); attempt 2 simulates a
        // crash via ExitForRecovery, leaving the record in_progress with _retry_attempt=2.
        host1.Builder.AddTask<string, string>(
            "flaky",
            async (ctx, ct) =>
            {
                lifetime1Attempts.Add(ctx.RetryAttempt);
                if (ctx.RetryAttempt < 2)
                {
                    throw new InvalidOperationException("retry me");
                }

                await ctx.ExitForRecoveryAsync(ct);
                return "unreached";
            },
            configure: o => o.Retry = new TaskRetryPolicy { MaxAttempts = 5, Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromMilliseconds(1)) });

        // ExitForRecovery is gated on graceful shutdown — signal it before dispatch so the crash
        // simulation (Fresh turn bailing for recovery) is the documented production path.
        host1.SignalShutdown();
        TaskRun<string> run = await host1.Invoker.StartAsync<string, string>(
            "flaky", "in", new RunOptions { TaskId = "t1" });
        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(run.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(run.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");
        Assert.That(lifetime1Attempts, Is.EqualTo(new[] { 0, 1, 2 }));

        // Restart and recover: the recovered turn must resume at attempt 2 (the crash did not
        // reset or consume budget), not restart at 0.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);
        var recovered = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        host2.Builder.AddTask<string, string>(
            "flaky",
            (ctx, ct) =>
            {
                recovered.TrySetResult(ctx.RetryAttempt);
                return Task.FromResult("ok");
            },
            configure: o => o.Retry = new TaskRetryPolicy { MaxAttempts = 5, Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromMilliseconds(1)) });

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        int resumedAttempt = await recovered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(resumedAttempt, Is.EqualTo(2));
    }
}
