// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

/// <summary>
/// Unit tests for the dedicated graceful-shutdown signal on <see cref="ResponseContext"/>.
/// Mirrors the task-primitive <c>TaskContext.Shutdown</c> and the Python <c>context.shutdown</c>
/// event: a separate, awaitable/linkable <see cref="CancellationToken"/> so handlers can react
/// to shutdown specifically rather than inferring it from a generic cancellation.
/// </summary>
public class ShutdownSignalTests
{
    [Test]
    public void Shutdown_FreshContext_NotSignaled()
    {
        var context = new ResponseContext("resp_fresh");

        Assert.That(context.IsShutdownRequested, Is.False);
        Assert.That(context.Shutdown.IsCancellationRequested, Is.False);
        Assert.That(context.Shutdown.CanBeCanceled, Is.True);
    }

    [Test]
    public void Shutdown_Token_IsSignaled_WhenIsShutdownRequestedSet()
    {
        var context = new ResponseContext("resp_signal");

        context.IsShutdownRequested = true;

        Assert.That(context.IsShutdownRequested, Is.True);
        Assert.That(context.Shutdown.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task Shutdown_Token_WakesHandlerAwaitingIt()
    {
        var context = new ResponseContext("resp_wake");
        var woke = new TaskCompletionSource();

        // A handler parked on the shutdown signal (not the generic cancellation token).
        var handler = Task.Run(async () =>
        {
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, context.Shutdown);
            }
            catch (OperationCanceledException)
            {
                woke.TrySetResult();
            }
        });

        context.IsShutdownRequested = true;

        await woke.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await handler;
        Assert.That(context.Shutdown.IsCancellationRequested, Is.True);
    }

    [Test]
    public async Task Shutdown_Token_IsSignaled_ByTrackerStopAsync()
    {
        using var tracker = new ResponseExecutionTracker(NullLogger<ResponseExecutionTracker>.Instance);
        await tracker.StartAsync(CancellationToken.None);

        var execution = tracker.Create("resp_tracker_shutdown");
        var context = new ResponseContext("resp_tracker_shutdown");
        execution.Context = context;

        Assert.That(context.Shutdown.IsCancellationRequested, Is.False);

        await tracker.StopAsync(CancellationToken.None);

        Assert.That(context.IsShutdownRequested, Is.True);
        Assert.That(context.Shutdown.IsCancellationRequested, Is.True);
    }
}
