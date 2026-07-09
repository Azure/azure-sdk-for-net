// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class ShutdownSignalTests
{
    [Test]
    public async Task ShutdownWakesHandlerBlockedOnCancellationAndDefersForRecovery()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        bool observedShutdownCause = false;

        host.Builder.AddTask<string, string>("graceful", async (ctx, ct) =>
        {
            entered.SetResult();
            try
            {
                // Block on the cooperative cancellation token only — shutdown must still wake it.
                await Task.Delay(Timeout.Infinite, ct).ConfigureAwait(false);
                return "completed";
            }
            catch (OperationCanceledException)
            {
                // The cause is conveyed via the Shutdown token (not CancelRequested).
                observedShutdownCause = ctx.Shutdown.IsCancellationRequested;
                await ctx.ExitForRecoveryAsync(CancellationToken.None).ConfigureAwait(false);
                return "unreached";
            }
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "graceful", "payload", new RunOptions { TaskId = "shut-1" });
        await entered.Task;
        await host.WaitForStatusAsync("shut-1", "in_progress", TimeSpan.FromSeconds(5));

        host.Engine.SignalShutdown();

        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);
        Assert.That(observedShutdownCause, Is.True);

        TaskRecord? record = await host.Store.GetAsync("shut-1");
        Assert.That(record!.Status, Is.EqualTo("in_progress"));
    }

    [Test]
    public async Task ShutdownPropagatingFromHandlerDefersForRecoveryNotFailure()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // Handler does NOT catch the cooperative cancel — it lets the OperationCanceledException
        // propagate. A shutdown-induced cancel must be classified as abandon-for-recovery (Deferred),
        // never as a terminal handler failure.
        host.Builder.AddTask<string, string>("graceful-raise", async (ctx, ct) =>
        {
            entered.SetResult();
            await Task.Delay(Timeout.Infinite, ct).ConfigureAwait(false);
            return "unreached";
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "graceful-raise", "payload", new RunOptions { TaskId = "shut-2" });
        await entered.Task;
        await host.WaitForStatusAsync("shut-2", "in_progress", TimeSpan.FromSeconds(5));

        host.Engine.SignalShutdown();

        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);

        TaskRecord? record = await host.Store.GetAsync("shut-2");
        Assert.That(record!.Status, Is.EqualTo("in_progress"));
        Assert.That(record.Error, Is.Null);
    }

    [Test]
    public async Task GracefulShutdownForceExpiresLeaseOfStragglerSoRestartReclaimsImmediately()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var entered = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        // A "straggler": the handler waits on the cooperative token only and never watches
        // ctx.Shutdown, so it does NOT checkpoint during the grace window. Graceful shutdown must
        // force-expire its lease (duration=0 => ExpiresAt collapses to ~now) so a restarted process
        // reclaims the still-in_progress record immediately instead of waiting the full lease TTL.
        host.Builder.AddTask<string, string>("straggler", async (ctx, ct) =>
        {
            entered.SetResult();
            await Task.Delay(Timeout.Infinite, ct).ConfigureAwait(false);
            return "unreached";
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "straggler", "payload", new RunOptions { TaskId = "shut-3" });
        await entered.Task;
        TaskRecord live = await host.WaitForStatusAsync("shut-3", "in_progress", TimeSpan.FromSeconds(5));

        // Sanity: while running the lease is held into the future (~60s TTL).
        DateTimeOffset liveExpiry = DateTimeOffset.Parse(
            live.Lease!.ExpiresAt, null, System.Globalization.DateTimeStyles.RoundtripKind);
        Assert.That(liveExpiry, Is.GreaterThan(DateTimeOffset.UtcNow.AddSeconds(5)));

        // A short grace: the straggler will not checkpoint, so it is force-expired.
        await host.Engine.ShutdownAsync(TimeSpan.FromMilliseconds(200));

        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);

        TaskRecord? record = await host.Store.GetAsync("shut-3");
        Assert.That(record!.Status, Is.EqualTo("in_progress"));
        DateTimeOffset expiresAt = DateTimeOffset.Parse(
            record.Lease!.ExpiresAt, null, System.Globalization.DateTimeStyles.RoundtripKind);
        Assert.That(expiresAt, Is.LessThanOrEqualTo(DateTimeOffset.UtcNow.AddSeconds(2)),
            "shutdown must force-expire the straggler's lease so recovery is immediate");
    }

    [Test]
    public async Task OneShotStartStampsTurnStartedAtForCrashProofTimeout()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddTask<string, string>("one-shot", async (ctx, ct) =>
        {
            await gate.Task.ConfigureAwait(false);
            return "done:" + ctx.Input;
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "one-shot", "payload", new RunOptions { TaskId = "os-1" });
        await host.WaitForStatusAsync("os-1", "in_progress", TimeSpan.FromSeconds(5));

        // A one-shot start is a turn-start boundary: the timeout anchor must be persisted so crash
        // recovery cannot reset the clock (FR-015).
        TaskRecord? record = await host.Store.GetAsync("os-1");
        Assert.That((string?)record!.Payload[TaskWireKeys.PayloadTurnStartedAt], Is.Not.Null.And.Not.Empty);

        gate.SetResult();
        Assert.That(await handle.GetResultAsync(), Is.EqualTo("done:payload"));
    }
}
