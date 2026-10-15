// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class TaskNameOwnershipTests
{
    [Test]
    public async Task ActiveOneShotRunCannotBeConvergedByDifferentDefinition()
    {
        using var host = TaskTestHost.Create();
        var started = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var release = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string> owner = host.Builder.AddTask<string, string>(
            "owner",
            async (context, cancellationToken) =>
            {
                started.TrySetResult();
                await release.Task;
                return "owner:" + context.Input;
            });
        TaskDefinition<string, string> other = host.Builder.AddTask<string, string>(
            "other",
            (context, cancellationToken) => Task.FromResult("other:" + context.Input));

        try
        {
            TaskRun<string> run = await owner.StartAsync(
                "input",
                new RunOptions { TaskId = "shared-active-one-shot" });
            await started.Task.WaitAsync(System.TimeSpan.FromSeconds(5));

            Assert.That(
                await other.GetActiveRunAsync("shared-active-one-shot"),
                Is.Null);
            ResilientTaskException conflict =
                Assert.ThrowsAsync<ResilientTaskException>(async () =>
                    await other.StartAsync(
                        "input",
                        new RunOptions { TaskId = "shared-active-one-shot" }))!;
            Assert.That(
                conflict.ErrorCode,
                Is.EqualTo(ResilientTaskErrorCode.Conflict));

            release.TrySetResult();
            Assert.That(await run.Completion, Is.EqualTo("owner:input"));
        }
        finally
        {
            release.TrySetResult();
        }
    }

    [Test]
    public async Task PersistedOneShotRunCannotBeReclaimedByDifferentDefinition()
    {
        using var host = TaskTestHost.Create();
        var otherStarted = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseOther = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        int otherInvocations = 0;
        TaskDefinition<string, string> owner = host.Builder.AddTask<string, string>(
            "owner",
            async (context, cancellationToken) =>
            {
                await context.ExitForRecoveryAsync(cancellationToken);
                return "deferred";
            });
        TaskDefinition<string, string> other = host.Builder.AddTask<string, string>(
            "other",
            async (context, cancellationToken) =>
            {
                Interlocked.Increment(ref otherInvocations);
                otherStarted.TrySetResult();
                await releaseOther.Task;
                return "other";
            });

        try
        {
            host.SignalShutdown();
            _ = await owner.StartAsync(
                "input",
                new RunOptions { TaskId = "shared-persisted-one-shot" });
            await host.WaitUntilInactiveAsync(
                "shared-persisted-one-shot",
                System.TimeSpan.FromSeconds(5));

            Assert.That(
                await other.GetActiveRunAsync("shared-persisted-one-shot"),
                Is.Null);
            Assert.That(otherStarted.Task.IsCompleted, Is.False);
            Assert.That(Volatile.Read(ref otherInvocations), Is.Zero);

            ResilientTaskException conflict =
                Assert.ThrowsAsync<ResilientTaskException>(async () =>
                    await other.StartAsync(
                        "input",
                        new RunOptions { TaskId = "shared-persisted-one-shot" }))!;
            Assert.That(
                conflict.ErrorCode,
                Is.EqualTo(ResilientTaskErrorCode.Conflict));

            var record = await host.Store.GetAsync("shared-persisted-one-shot");
            Assert.That(record?.Source?.Name, Is.EqualTo("owner"));
            Assert.That(Volatile.Read(ref otherInvocations), Is.Zero);
        }
        finally
        {
            releaseOther.TrySetResult();
        }
    }

    [Test]
    public async Task MultiTurnChainCannotBeAccessedOrResumedByDifferentDefinition()
    {
        using var host = TaskTestHost.Create();
        var started = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        var release = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        int otherInvocations = 0;
        TaskDefinition<string, string> owner =
            host.Builder.AddMultiTurnTask<string, string>(
                "owner",
                async (context, cancellationToken) =>
                {
                    started.TrySetResult();
                    await release.Task;
                    return "owner:" + context.Input;
                });
        TaskDefinition<string, string> other =
            host.Builder.AddMultiTurnTask<string, string>(
                "other",
                (context, cancellationToken) =>
                {
                    Interlocked.Increment(ref otherInvocations);
                    return Task.FromResult("other:" + context.Input);
                });

        try
        {
            TaskRun<string> run = await owner.StartAsync(
                "first",
                new RunOptions
                {
                    TaskId = "shared-multi-turn",
                    InputId = "owner-input",
                });
            await started.Task.WaitAsync(System.TimeSpan.FromSeconds(5));

            Assert.That(
                await other.GetActiveRunAsync(
                    "shared-multi-turn",
                    "owner-input"),
                Is.Null);
            Assert.ThrowsAsync<ResilientTaskException>(async () =>
                await other.StartAsync(
                    "second",
                    new RunOptions { TaskId = "shared-multi-turn" }));

            release.TrySetResult();
            Assert.That(await run.Completion, Is.EqualTo("owner:first"));
            await host.WaitForStatusAsync(
                "shared-multi-turn",
                "suspended",
                System.TimeSpan.FromSeconds(5));

            ResilientTaskException persistedConflict =
                Assert.ThrowsAsync<ResilientTaskException>(async () =>
                    await other.StartAsync(
                        "second",
                        new RunOptions { TaskId = "shared-multi-turn" }))!;
            Assert.That(
                persistedConflict.ErrorCode,
                Is.EqualTo(ResilientTaskErrorCode.Conflict));
            Assert.That(Volatile.Read(ref otherInvocations), Is.Zero);

            await owner.DeleteAsync("shared-multi-turn");
        }
        finally
        {
            release.TrySetResult();
        }
    }
}
