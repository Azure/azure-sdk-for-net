// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class TimeoutTests
{
    [Test]
    public async Task PerTurnTimeoutSetsTimeoutCauseAndCancels()
    {
        using TaskTestHost host = TaskTestHost.Create();
        var observedTimeout = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        host.Builder.AddTask<string, string>(
            "slow",
            async (ctx, ct) =>
            {
                try
                {
                    // Block until the per-turn watchdog fires the cooperative cancellation.
                    await Task.Delay(Timeout.Infinite, ct).ConfigureAwait(false);
                    return "completed";
                }
                catch (OperationCanceledException)
                {
                    // The timeout cause must already be visible when the signal is observed.
                    observedTimeout.TrySetResult(ctx.TimeoutExceeded);
                    throw;
                }
            },
            configure: o =>
            {
                o.Timeout = TimeSpan.FromMilliseconds(150);
                o.Retry = RetryPolicy.NoRetry();
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "slow", "in", new RunOptions { TaskId = "t1" });

        bool sawCause = await observedTimeout.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(sawCause, Is.True, "TimeoutExceeded must be set before the cancellation signal.");
        Assert.ThrowsAsync<TaskCancelledException>(async () => await run.GetResultAsync());
    }
}
