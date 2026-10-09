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
    public void Shutdown_Token_IsSignaled_WhenSignalShutdownCalled()
    {
        var context = new ResponseContext("resp_signal");

        context.SignalShutdown();

        Assert.That(context.IsShutdownRequested, Is.True);
        Assert.That(context.Shutdown.IsCancellationRequested, Is.True);
    }

    [Test]
    public void ConveniencePropertiesUseVirtualCancellationTokens()
    {
        using var context = new OverriddenTokenContext();

        context.SignalOverrides();

        Assert.Multiple(() =>
        {
            Assert.That(context.IsShutdownRequested, Is.True);
            Assert.That(context.IsClientCancelled, Is.True);
        });
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

        context.SignalShutdown();

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

    private sealed class OverriddenTokenContext : ResponseContext, IDisposable
    {
        private readonly CancellationTokenSource _shutdown = new();
        private readonly CancellationTokenSource _clientCancellation = new();

        public OverriddenTokenContext()
            : base("resp_overridden_tokens")
        {
        }

        public override CancellationToken Shutdown => _shutdown.Token;

        public override CancellationToken ClientCancellation => _clientCancellation.Token;

        public void SignalOverrides()
        {
            _shutdown.Cancel();
            _clientCancellation.Cancel();
        }

        public void Dispose()
        {
            _shutdown.Dispose();
            _clientCancellation.Dispose();
        }
    }
}
