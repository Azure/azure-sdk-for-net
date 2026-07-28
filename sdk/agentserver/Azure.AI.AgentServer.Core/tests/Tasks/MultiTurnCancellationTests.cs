// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnCancellationTests
{
    [Test]
    public async Task CancellingMultiTurnTurnParksChainAtSuspended()
    {
        // Spec §16: a multi-turn turn cancelled mid-flight surfaces TaskCancelledException to the
        // caller, but the chain itself stays alive (parked at suspended), never dangling in_progress.
        using var host = TaskTestHost.Create();
        var started = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddMultiTurnTask<string, string>("mt-cancel", async (ctx, ct) =>
        {
            started.SetResult(true);
            await Task.Delay(Timeout.Infinite, ct);
            return ctx.Input;
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "mt-cancel", "v", new RunOptions { TaskId = "mtc-1" });

        await started.Task;
        await handle.CancelAsync();

        Assert.ThrowsAsync<TaskCancelledException>(async () => await handle);

        // The chain remains alive at suspended (not in_progress, not deleted).
        var record = await host.WaitForStatusAsync("mtc-1", "suspended", TimeSpan.FromSeconds(5));
        Assert.That(record.Status, Is.EqualTo("suspended"));
    }
}
