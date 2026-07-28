// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class OneShotCancellationTests
{
    [Test]
    public async Task CancelAsyncPublishesCauseBeforeSignallingToken()
    {
        using var host = TaskTestHost.Create();
        var started = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        bool sawCause = false;

        host.Builder.AddTask<string, string>("cancellable", async (ctx, ct) =>
        {
            started.SetResult(true);
            try
            {
                await Task.Delay(Timeout.Infinite, ct);
            }
            catch (OperationCanceledException)
            {
                // A handler waking on cancellation must always observe a cause (C-CAN-2).
                sawCause = ctx.CancelRequested;
                throw;
            }

            return ctx.Input;
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "cancellable", "v", new RunOptions { TaskId = "cancel-1" });

        await started.Task;
        await handle.CancelAsync();

        Assert.ThrowsAsync<TaskCancelledException>(async () => await handle);
        Assert.That(sawCause, Is.True, "handler must observe CancelRequested on cancellation");
    }
}
