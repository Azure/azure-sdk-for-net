// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

internal sealed record AotInput(string Value, int Count);

[JsonSerializable(typeof(AotInput))]
internal sealed partial class AotJsonContext : JsonSerializerContext
{
}

[TestFixture]
public sealed class TaskAotRegistrationTests
{
    [Test]
    public async Task RegisteredWithJsonTypeInfoRoundTripsInputThroughSourceGenMetadata()
    {
        // Registering with the source-generated JsonTypeInfo overload must serialize the input on
        // start (persisting it to the store) and deserialize it on recovery through that metadata
        // rather than the reflection-based serializer. The recovered handler observing the exact
        // input proves both directions ran through the supplied JsonTypeInfo.
        var registry1 = new TaskRegistry();
        using var host1 = TaskTestHost.Create(sharedRegistry: registry1);

        host1.Builder.AddTask<AotInput, string>(
            "aot",
            async (ctx, ct) =>
            {
                if (ctx.EntryMode == EntryMode.Fresh)
                {
                    await ctx.ExitForRecoveryAsync(ct);
                }

                return $"{ctx.Input.Value}:{ctx.Input.Count}";
            },
            AotJsonContext.Default.AotInput);

        host1.SignalShutdown();
        TaskRun<string> handle = await host1.Invoker.StartAsync<AotInput, string>(
            "aot", new AotInput("hello", 42), new RunOptions { TaskId = "aot-1" });

        // Recovery deferral is an internal lifecycle handoff: it never surfaces on the run handle.
        // Wait for the engine to release the run, then confirm Completion stays pending.
        await host1.WaitUntilInactiveAsync(handle.TaskId, TimeSpan.FromSeconds(5));
        Assert.That(handle.Completion.IsCompleted, Is.False, "deferral must not complete the run handle");

        // Restart with the same source-gen registration and recover: the recovered handler must see
        // the input deserialized from the store via the JsonTypeInfo.
        var registry2 = new TaskRegistry();
        using var host2 = host1.Restart(registry2);

        var recovered = new TaskCompletionSource<AotInput>(TaskCreationOptions.RunContinuationsAsynchronously);
        host2.Builder.AddTask<AotInput, string>(
            "aot",
            (ctx, ct) =>
            {
                recovered.TrySetResult(ctx.Input);
                return Task.FromResult($"{ctx.Input.Value}:{ctx.Input.Count}");
            },
            AotJsonContext.Default.AotInput);

        int dispatched = await host2.Engine.ScanAndRecoverAsync();
        Assert.That(dispatched, Is.EqualTo(1));

        AotInput seen = await recovered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(seen.Value, Is.EqualTo("hello"));
        Assert.That(seen.Count, Is.EqualTo(42));
    }

    [Test]
    public void RegisteringWithNullJsonTypeInfoThrows()
    {
        using var host = TaskTestHost.Create();
        Assert.Throws<ArgumentNullException>(() =>
            host.Builder.AddTask<AotInput, string>(
                "aot-null",
                (ctx, ct) => Task.FromResult(ctx.Input.Value),
                inputTypeInfo: null!));
    }
}
