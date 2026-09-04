// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

/// <summary>
/// Pay-for-what-you-use / decoupling verifications (SC-009 / FR-038): task APIs do not expose
/// raw streaming primitives, and a non-steerable task allocates no steering queue. Lazy stream
/// backing allocation is behavior-tested by <see cref="TaskStreamTests"/>.
/// </summary>
[TestFixture]
public sealed class PayForUseTests
{
    private const string StreamingNamespace = "Azure.AI.AgentServer.Core.Streaming";

    [Test]
    public void TaskTypes_DoNotExposeRawStreamingPrimitives()
    {
        // Task-bound reader/writer capabilities intentionally couple the engine to streaming, but
        // the raw registry and stream types remain advanced implementation details. Public task
        // surfaces must reference only types in the Tasks namespace.
        Type[] taskTypes =
        {
            typeof(TaskContext<string>),
            typeof(TaskRun<string>),
            typeof(TaskStream),
            typeof(TaskStreamWriter),
            typeof(RunOptions),
        };

        foreach (Type type in taskTypes)
        {
            MemberInfo[] members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public);
            foreach (MemberInfo member in members)
            {
                Type? referencedType = member switch
                {
                    PropertyInfo property => property.PropertyType,
                    MethodInfo method => method.ReturnType,
                    _ => null,
                };
                if (referencedType is null)
                {
                    continue;
                }

                Assert.That(
                    ReferencesStreaming(referencedType),
                    Is.False,
                    $"{type.Name}.{member.Name} ({referencedType.Name}) must not expose raw streaming.");
            }
        }
    }

    [Test]
    public async Task NonSteerableOneShot_AllocatesNoSteeringQueue()
    {
        using var host = TaskTestHost.Create();

        bool hasSteering = true;
        int steeringCount = -1;

        host.Builder.AddTask<string, string>("plain", async (ctx, ct) =>
        {
            await Task.Yield();
            (hasSteering, steeringCount) = InspectSteering(host.Engine, ctx.TaskId);
            return "ok";
        });

        string result = await host.Invoker.RunAsync<string, string>("plain", "hi");

        Assert.That(result, Is.EqualTo("ok"));
        Assert.That(hasSteering, Is.False,
            "A non-steerable one-shot task must not allocate a steering queue.");
        Assert.That(steeringCount, Is.EqualTo(0));
    }

    [Test]
    public async Task SteerableTask_AllocatesSteeringQueueOnlyWhenSteered()
    {
        // Control case: a steerable task that is never steered also stays lean until a
        // steering input actually arrives — the queue is created on first steering use.
        using var host = TaskTestHost.Create();

        bool hasSteering = true;

        host.Builder.AddMultiTurnTask<string, string>("chat", async (ctx, ct) =>
        {
            await Task.Yield();
            (hasSteering, _) = InspectSteering(host.Engine, ctx.TaskId);
            return "ok";
        }, steerable: true);

        string result = await host.Invoker.RunAsync<string, string>(
            "chat", "hi", new RunOptions { TaskId = "chat-1" });

        Assert.That(result, Is.EqualTo("ok"));
        Assert.That(hasSteering, Is.False,
            "A steerable task that has not been steered yet must not pre-allocate the queue.");
    }

    private static bool ReferencesStreaming(Type type)
    {
        if (type.Namespace is not null
            && type.Namespace.StartsWith(StreamingNamespace, StringComparison.Ordinal))
        {
            return true;
        }

        return type.IsGenericType
            && type.GetGenericArguments().Any(ReferencesStreaming);
    }

    private static (bool HasSteering, int SteeringCount) InspectSteering(TaskEngine engine, string taskId)
    {
        FieldInfo activeRunsField = typeof(TaskEngine).GetField(
            "_activeRuns", BindingFlags.Instance | BindingFlags.NonPublic)
            ?? throw new InvalidOperationException("_activeRuns field not found.");

        object activeRuns = activeRunsField.GetValue(engine)!;
        object? activeRun = ((IEnumerable)activeRuns)
            .Cast<object>()
            .Select(kvp => kvp.GetType().GetProperty("Value")!.GetValue(kvp))
            .FirstOrDefault(run =>
                (string)run!.GetType().GetProperty("TaskId")!.GetValue(run)! == taskId);

        Assert.That(activeRun, Is.Not.Null, $"No active run found for task '{taskId}'.");

        bool hasSteering = (bool)activeRun!.GetType()
            .GetProperty("HasSteering")!.GetValue(activeRun)!;
        int steeringCount = (int)activeRun.GetType()
            .GetProperty("SteeringCount")!.GetValue(activeRun)!;

        return (hasSteering, steeringCount);
    }
}
