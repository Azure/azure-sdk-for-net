// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Engine;

/// <summary>
/// Verifies the resilient-task engine emits the operator-facing observability markers that the
/// Python reference logs (azure-ai-agentserver-core <c>tasks/_manager.py</c>): a startup line
/// carrying the stable lease <c>worker-…</c> instance id (so a cross-process restart is visible as
/// a NEW instance) and a "Reclaimed stale task" line when a crashed/abandoned task's lease is
/// taken over. These are what the hosted crash-recovery verifier (battery/verify_crash.py) greps
/// for to PROVE recovery from logs; without them the .NET agent recovers silently and the proof
/// is impossible. Parity guard for that divergence.
/// </summary>
[TestFixture]
public sealed class RecoveryObservabilityTests
{
    // Mirrors the Python lease instance-id format worker-{pid}-{hex}-{epoch} that verify_crash.py greps.
    private static readonly Regex WorkerInstance = new(@"worker-\d+-[a-f0-9]+-\d+", RegexOptions.Compiled);

    [Test]
    public async Task StartupLogsTaskManagerStartingWithWorkerInstanceId()
    {
        var logger = new CapturingLogger();
        using TaskTestHost host = TaskTestHost.Create(logger: logger);

        var scanner = new RecoveryScanner(host.Engine);
        await using var durability = new TaskDurabilityService(scanner, host.Engine, TimeSpan.FromMinutes(10), logger: logger);
        await durability.StartAsync();

        CapturedLog? startup = logger.Entries
            .FirstOrDefault(e => e.Message.Contains("TaskManager starting", StringComparison.Ordinal));

        Assert.That(startup, Is.Not.Null, "expected a 'TaskManager starting' startup log");
        Assert.That(WorkerInstance.IsMatch(startup!.Message), Is.True,
            $"startup log must carry a worker-<pid>-<hex>-<epoch> instance id; got: {startup.Message}");
        Assert.That(startup.Message, Does.Contain(host.AgentName),
            "startup log should carry the owner (agent name)");

        await durability.StopAsync();
    }

    [Test]
    public async Task ReclaimingAbandonedTaskLogsReclaimedStaleTask()
    {
        var logger = new CapturingLogger();
        using TaskTestHost host = TaskTestHost.Create(logger: logger);

        // Fresh entry exits for recovery (releases lease, leaves record in_progress); a later
        // Recovered entry reclaims the lease and completes.
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
            "resumable", "payload", new RunOptions { TaskId = "reclaim-1" });
        Assert.ThrowsAsync<TaskDeferredException>(async () => await handle);
        Assert.That((await host.Store.GetAsync("reclaim-1"))!.Status, Is.EqualTo("in_progress"));

        var scanner = new RecoveryScanner(host.Engine);
        await using var durability = new TaskDurabilityService(scanner, host.Engine, TimeSpan.FromMilliseconds(100), logger: logger);
        await durability.StartAsync();

        // The sweep re-invokes the interrupted task as Recovered; it reclaims the lease then
        // completes (one-shot auto-deletes on completion).
        await host.WaitUntilDeletedAsync("reclaim-1", TimeSpan.FromSeconds(5));
        await durability.StopAsync();

        bool reclaimLogged = logger.Entries.Any(e =>
            Regex.IsMatch(e.Message, "[Rr]eclaim.*stale|stale task") && e.Message.Contains("reclaim-1", StringComparison.Ordinal));
        Assert.That(reclaimLogged, Is.True,
            "expected a 'Reclaimed stale task reclaim-1' log when the abandoned lease is taken over");
    }
}
