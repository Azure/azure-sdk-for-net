// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class MultiTurnHandlerRaiseTests
{
    [Test]
    public async Task PerTurnRaiseSurfacesTypedFailureAndChainStaysSuspendedWithoutError()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("boom", (ctx, ct) =>
            throw new InvalidOperationException("turn failed"),
            configure: o => o.Retry = RetryPolicy.ExponentialBackoff(maxAttempts: 1));

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "boom", "a", new RunOptions { TaskId = "b-1" });

        Assert.ThrowsAsync<TaskFailedException>(async () => await run);

        // The chain remains alive (parked at suspended), and no per-turn `error` is persisted.
        var record = await host.WaitForStatusAsync("b-1", "suspended", TimeSpan.FromSeconds(5));
        Assert.That(record.Error, Is.Null);
    }

    [Test]
    public async Task SingleAttemptRaiseIsHandlerErrorWithoutAttemptCount()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("he", (ctx, ct) =>
            throw new InvalidOperationException("nope"),
            configure: o => o.Retry = RetryPolicy.ExponentialBackoff(maxAttempts: 1));

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "he", "a", new RunOptions { TaskId = "he-1" });

        var ex = Assert.ThrowsAsync<TaskFailedException>(async () => await run);
        Assert.That(ex!.Error.Kind, Is.EqualTo(TaskFailureKind.HandlerError));
        Assert.That(ex.Error.ErrorType, Is.EqualTo(nameof(InvalidOperationException)));
        Assert.That(ex.Error.Attempts, Is.Null);
    }

    [Test]
    public async Task HandlerErrorPopulatesTracebackForParity()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("tb", (ctx, ct) =>
            throw new InvalidOperationException("kaboom"),
            configure: o => o.Retry = RetryPolicy.ExponentialBackoff(maxAttempts: 1));

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "tb", "a", new RunOptions { TaskId = "tb-1" });

        var ex = Assert.ThrowsAsync<TaskFailedException>(async () => await run);
        Assert.That(ex!.Error.Traceback, Is.Not.Null.And.Contains(nameof(InvalidOperationException)));
    }

    [Test]
    public async Task ExhaustedRetriesReportsAttemptCount()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddMultiTurnTask<string, string>("ex", (ctx, ct) =>
            throw new InvalidOperationException("again"),
            configure: o => o.Retry = new RetryPolicy
            {
                MaxAttempts = 3,
                InitialDelay = TimeSpan.Zero,
                MaxDelay = TimeSpan.Zero,
                Jitter = false,
            });

        TaskRun<string> run = await host.Invoker.StartAsync<string, string>(
            "ex", "a", new RunOptions { TaskId = "ex-1" });

        var ex = Assert.ThrowsAsync<TaskFailedException>(async () => await run);
        Assert.That(ex!.Error.Kind, Is.EqualTo(TaskFailureKind.ExhaustedRetries));
        Assert.That(ex.Error.Attempts, Is.EqualTo(3));
        Assert.That(ex.Error.LastErrorType, Is.EqualTo(nameof(InvalidOperationException)));
    }
}
