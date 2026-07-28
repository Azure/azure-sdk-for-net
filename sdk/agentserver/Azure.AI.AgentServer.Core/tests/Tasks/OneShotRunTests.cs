// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class OneShotRunTests
{
    [Test]
    public async Task RunAsyncPersistsInputThenReturnsTypedOutput()
    {
        using var host = TaskTestHost.Create();
        string? observedInput = null;
        host.Builder.AddTask<string, int>("echo-len", (ctx, ct) =>
        {
            observedInput = ctx.Input;
            return Task.FromResult(ctx.Input.Length);
        });

        int result = await host.Invoker.RunAsync<string, int>("echo-len", "hello");

        Assert.That(result, Is.EqualTo(5));
        Assert.That(observedInput, Is.EqualTo("hello"));
    }

    [Test]
    public async Task StartAsyncReturnsPopulatedHandleAndAwaitYieldsSameResult()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<int, int>("double", (ctx, ct) => Task.FromResult(ctx.Input * 2));

        TaskRun<int> handle = await host.Invoker.StartAsync<int, int>("double", 21);

        Assert.That(handle.TaskId, Is.Not.Null.And.Not.Empty);
        Assert.That(handle.InputId, Is.Not.Null.And.Not.Empty);
        int viaAwait = await handle;
        int viaGet = await handle.GetResultAsync();
        Assert.That(viaAwait, Is.EqualTo(42));
        Assert.That(viaGet, Is.EqualTo(42));
    }

    [Test]
    public async Task OneShotInputIdDefaultsToTaskId()
    {
        using var host = TaskTestHost.Create();
        string? observedInputId = null;
        host.Builder.AddTask<string, string>("id-default", (ctx, ct) =>
        {
            observedInputId = ctx.InputId;
            return Task.FromResult(ctx.Input);
        });

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>(
            "id-default", "x", new RunOptions { TaskId = "one-shot-id" });

        // Spec §33 one-shot 1:1 invariant: input_id defaults to task_id (no random id).
        Assert.That(handle.InputId, Is.EqualTo("one-shot-id"));
        await handle;
        Assert.That(observedInputId, Is.EqualTo("one-shot-id"));
    }

    [Test]
    public async Task OneShotWithGeneratedTaskIdUsesSameValueForInputId()
    {
        using var host = TaskTestHost.Create();
        host.Builder.AddTask<string, string>("id-gen", (ctx, ct) => Task.FromResult(ctx.Input));

        TaskRun<string> handle = await host.Invoker.StartAsync<string, string>("id-gen", "x");

        Assert.That(handle.InputId, Is.EqualTo(handle.TaskId));
        await handle;
    }
}
