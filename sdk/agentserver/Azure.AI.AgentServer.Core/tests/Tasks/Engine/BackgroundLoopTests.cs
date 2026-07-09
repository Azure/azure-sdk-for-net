// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Engine;

[TestFixture]
public sealed class BackgroundLoopTests
{
    [Test]
    public async Task PeriodicScanReclaimsAbandonedTaskWithoutColdRestart()
    {
        using TaskTestHost host = TaskTestHost.Create();

        // The Fresh attempt exits for recovery (releasing the lease, leaving the record in_progress);
        // a later Recovered entry completes. No process restart occurs — only the periodic sweep.
        host.Builder.AddTask<string, string>("resumable", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"done:{ctx.Input}";
        });

        // ExitForRecovery is gated on graceful shutdown — signal it before dispatch so the Fresh
        // turn may bail out for recovery (the documented production pattern; tasks-guide.md §4.11).
        host.SignalShutdown();
        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "resumable", "payload", new RunOptions { TaskId = "abandoned-1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);

        TaskRecord? mid = await host.Store.GetAsync("abandoned-1");
        Assert.That(mid!.Status, Is.EqualTo("in_progress"));

        var scanner = new RecoveryScanner(host.Engine);
        await using var durability = new TaskDurabilityService(scanner, host.Engine, TimeSpan.FromMilliseconds(100));
        await durability.StartAsync();

        // The standing sweep re-invokes the interrupted task as Recovered; the one-shot then
        // auto-deletes on completion — proving recovery happened without a cold restart.
        await host.WaitUntilDeletedAsync("abandoned-1", TimeSpan.FromSeconds(5));

        await durability.StopAsync();
    }

    [Test]
    public async Task StartupScanRunsImmediatelyNotAfterFullInterval()
    {
        using TaskTestHost host = TaskTestHost.Create();

        host.Builder.AddTask<string, string>("resumable", async (ctx, ct) =>
        {
            if (ctx.EntryMode == EntryMode.Fresh)
            {
                await ctx.ExitForRecoveryAsync(ct);
            }

            return $"done:{ctx.Input}";
        });

        host.SignalShutdown();
        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "resumable", "payload", new RunOptions { TaskId = "startup-1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);
        Assert.That((await host.Store.GetAsync("startup-1"))!.Status, Is.EqualTo("in_progress"));

        // A deliberately long interval: recovery must still happen promptly because the loop scans
        // immediately on startup (matching the Python reference), rather than sleeping one interval
        // before its first sweep. If the first scan were gated on the interval this would time out.
        var scanner = new RecoveryScanner(host.Engine);
        await using var durability = new TaskDurabilityService(scanner, host.Engine, TimeSpan.FromMinutes(10));
        await durability.StartAsync();

        await host.WaitUntilDeletedAsync("startup-1", TimeSpan.FromSeconds(5));

        await durability.StopAsync();
    }

    [Test]
    public async Task LeaseRenewalExtendsActiveTurnLeaseWithoutDisturbingIt()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var gate = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddTask<string, string>("long-running", async (ctx, ct) =>
        {
            await gate.Task.ConfigureAwait(false);
            return "done:" + ctx.Input;
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "long-running", "payload", new RunOptions { TaskId = "lease-1" });
        TaskRecord before = await host.WaitForStatusAsync("lease-1", "in_progress", TimeSpan.FromSeconds(5));

        string ownerBefore = before.Lease!.Owner;
        DateTimeOffset expiresBefore = ParseIso(before.Lease.ExpiresAt);

        // One renewal tick (the engine's per-active-task loop uses this same primitive on a 30s
        // cadence) must extend the deadline while preserving ownership of the running turn.
        await host.Engine.Lease.HeartbeatAsync(
            "lease-1", host.Engine.Owner, TaskEngineConstants.LeaseDurationSeconds);

        TaskRecord after = (await host.Store.GetAsync("lease-1"))!;
        Assert.That(after.Lease!.Owner, Is.EqualTo(ownerBefore));
        Assert.That(ParseIso(after.Lease.ExpiresAt), Is.GreaterThanOrEqualTo(expiresBefore));
        Assert.That(after.Status, Is.EqualTo("in_progress"));

        gate.SetResult();
        Assert.That(await handle.GetResultAsync(), Is.EqualTo("done:payload"));
    }

    private static DateTimeOffset ParseIso(string iso)
        => DateTimeOffset.Parse(iso, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
}
