// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnDeleteTests
{
    [Test]
    public async Task DeleteRemovesSuspendedChainAndIsIdempotent()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("del", (ctx, ct) => Task.FromResult(ctx.Input));

        await host.Invoker.StartAsync<string, string>("del", "a", new RunOptions { TaskId = "d-1" });
        await host.WaitForStatusAsync("d-1", "suspended", TimeSpan.FromSeconds(5));

        await host.Engine.DeleteAsync("d-1");
        Assert.That(await host.Store.GetAsync("d-1"), Is.Null);

        // Repeat delete on an absent chain is a no-op.
        Assert.DoesNotThrowAsync(async () => await host.Engine.DeleteAsync("d-1"));
    }

    [Test]
    public async Task DeleteCancelsAnInFlightTurn()
    {
        using var host = TaskTestHost.Create();
        var started = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddMultiTurnTask<string, string>("del2", async (ctx, ct) =>
        {
            started.TrySetResult(true);
            await Task.Delay(Timeout.Infinite, ctx.Cancellation);
            return ctx.Input;
        });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "del2", "a", new RunOptions { TaskId = "d-2" });
        await started.Task;

        await host.Engine.DeleteAsync("d-2");

        Assert.ThrowsAsync<TaskCancelledException>(async () => await run);
        Assert.That(await host.Store.GetAsync("d-2"), Is.Null);
    }
}
