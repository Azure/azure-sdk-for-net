// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Verifies the typed <see cref="TaskDefinition{TInput, TOutput}"/> handle returned by
/// registration. The name and its input/output types are bound once at registration, so
/// invocation is strongly typed against the same engine the DI container builds.
/// </summary>
[TestFixture]
public sealed class TaskDefinitionTests
{
    [Test]
    public async Task DefinitionCanBeSubstitutedForUnitTests()
    {
        var definition = new StubTaskDefinition();

        Assert.That(definition.Name, Is.EqualTo("stub"));
        Assert.That(await definition.RunAsync("input"), Is.EqualTo("result:input"));
        Assert.That(await (await definition.StartAsync("started")).Completion, Is.EqualTo("started"));
        Assert.That(await definition.GetActiveRunAsync("task"), Is.Null);
        Assert.That(await definition.GetActiveRunAsync("task", "input"), Is.Null);

        await definition.DeleteAsync("deleted-task");
        Assert.That(definition.DeletedTaskId, Is.EqualTo("deleted-task"));
    }

    [Test]
    public void RegistrationReturnsDefinitionCarryingTheName()
    {
        using var host = TaskTestHost.Create();

        TaskDefinition<string, int> def = host.Builder.AddTask<string, int>(
            "echo-len", (ctx, ct) => Task.FromResult(ctx.Input.Length));

        Assert.That(def, Is.Not.Null);
        Assert.That(def.Name, Is.EqualTo("echo-len"));
    }

    [Test]
    public async Task RunAsyncBindsTypesAndReturnsTypedResult()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<string, int> def = host.Builder.AddTask<string, int>(
            "len", (ctx, ct) => Task.FromResult(ctx.Input.Length));

        int result = await def.RunAsync("hello");

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public async Task StartAsyncReturnsHandleAndAwaitYieldsResult()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<int, int> def = host.Builder.AddTask<int, int>(
            "double", (ctx, ct) => Task.FromResult(ctx.Input * 2));

        TaskRun<int> run = await def.StartAsync(21);

        Assert.That(run.TaskId, Is.Not.Null.And.Not.Empty);
        Assert.That(await run.Completion, Is.EqualTo(42));
    }

    [Test]
    public async Task GetActiveRunAsyncReturnsNullOnceOneShotHasCompleted()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<string, string> def = host.Builder.AddTask<string, string>(
            "echo", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> run = await def.StartAsync("x", new RunOptions { TaskId = "t-1" });
        await run.Completion;

        TaskRun<string>? active = await def.GetActiveRunAsync("t-1");

        Assert.That(active, Is.Null);
    }

    [Test]
    public async Task DeleteAsyncEndsMultiTurnChain()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<string, string> def = host.Builder.AddMultiTurnTask<string, string>(
            "chat", (ctx, ct) => Task.FromResult($"reply: {ctx.Input}"));

        TaskRun<string> turn = await def.StartAsync("hi", new RunOptions { TaskId = "chain-1" });
        await turn.Completion;

        await def.DeleteAsync("chain-1");

        await host.WaitUntilDeletedAsync("chain-1", System.TimeSpan.FromSeconds(5));
        Assert.That(await host.Store.GetAsync("chain-1"), Is.Null);
    }

    [Test]
    public async Task DeleteAsyncRejectsTaskOwnedByDifferentDefinition()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<string, string> owner = host.Builder.AddMultiTurnTask<string, string>(
            "owner", (ctx, ct) => Task.FromResult(ctx.Input));
        TaskDefinition<string, string> other = host.Builder.AddMultiTurnTask<string, string>(
            "other", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> turn = await owner.StartAsync(
            "hi",
            new RunOptions { TaskId = "owned-chain" });
        await turn.Completion;

        ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await other.DeleteAsync("owned-chain"))!;

        Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.That(await host.Store.GetAsync("owned-chain"), Is.Not.Null);

        await owner.DeleteAsync("owned-chain");
    }

    [Test]
    public async Task MultiTurnChainConvergesOnTheSameTaskIdAcrossTurns()
    {
        using var host = TaskTestHost.Create();
        TaskDefinition<string, string> def = host.Builder.AddMultiTurnTask<string, string>(
            "chat", (ctx, ct) => Task.FromResult($"reply: {ctx.Input}"));

        TaskRun<string> turn1 = await def.StartAsync("hi", new RunOptions { TaskId = "chain-2" });
        await turn1.Completion;
        TaskRun<string> turn2 = await def.StartAsync("again", new RunOptions { TaskId = "chain-2" });
        await turn2.Completion;

        Assert.That(turn2.TaskId, Is.EqualTo("chain-2"));
        Assert.That(turn2.InputId, Is.Not.EqualTo(turn1.InputId));
    }

    private sealed class StubTaskDefinition : TaskDefinition<string, string>
    {
        public string? DeletedTaskId { get; private set; }

        public override string Name => "stub";

        public override Task<string> RunAsync(
            string input,
            RunOptions? options = null,
            CancellationToken cancellationToken = default)
            => Task.FromResult($"result:{input}");

        public override Task<TaskRun<string>> StartAsync(
            string input,
            RunOptions? options = null,
            CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRun<string>>(new StubTaskRun(input));

        public override Task<TaskRun<string>?> GetActiveRunAsync(
            string taskId,
            CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRun<string>?>(null);

        public override Task<TaskRun<string>?> GetActiveRunAsync(
            string taskId,
            string inputId,
            CancellationToken cancellationToken = default)
            => Task.FromResult<TaskRun<string>?>(null);

        public override Task DeleteAsync(
            string taskId,
            CancellationToken cancellationToken = default)
        {
            DeletedTaskId = taskId;
            return Task.CompletedTask;
        }
    }

    private sealed class StubTaskRun : TaskRun<string>
    {
        private readonly string _result;

        public StubTaskRun(string result) => _result = result;

        public override Task<string> Completion => Task.FromResult(_result);
    }
}
