// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnGetActiveRunTests
{
    [Test]
    public async Task GetActiveRunReturnsInFlightTurnThenNull()
    {
        using var host = TaskTestHost.Create();
        var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var started = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        host.Builder.AddMultiTurnTask<string, string>("introspect", async (ctx, ct) =>
        {
            started.TrySetResult(true);
            await release.Task;
            return ctx.Input;
        });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "introspect", "a", new RunOptions { TaskId = "i-1", InputId = "in-1" });
        await started.Task;

        TaskRun<string>? active = await host.Invoker.GetActiveRunAsync<string>("introspect", "i-1", "in-1");
        Assert.That(active, Is.Not.Null);

        // A mismatched inputId does not match the in-flight turn.
        TaskRun<string>? mismatch = await host.Invoker.GetActiveRunAsync<string>("introspect", "i-1", "other");
        Assert.That(mismatch, Is.Null);

        release.TrySetResult(true);
        await run;

        TaskRun<string>? afterDone = await host.Invoker.GetActiveRunAsync<string>("introspect", "i-1", "in-1");
        Assert.That(afterDone, Is.Null);
    }

    [Test]
    public async Task OneShotOverloadAgainstMultiTurnTaskIsArgumentError()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("mt", (ctx, ct) => Task.FromResult(ctx.Input));

        await Task.Yield();
        Assert.ThrowsAsync<ArgumentException>(async () =>
            await host.Invoker.GetActiveRunAsync<string>("mt", "x"));
    }
}
