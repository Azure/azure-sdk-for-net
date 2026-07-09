// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Compiled code snippets backing <c>docs/tasks-guide.md</c>. These compile against the
    /// real public surface so the developer guide cannot drift from the shipped API.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent doc rot; they are not executed.")]
    public class TasksGuideSnippets
    {
        // §3 Hello world — one-shot registration + RunAsync.
        public static async Task<string> OneShotHelloWorld(IServiceCollection services, ITaskInvoker invoker)
        {
            services
                .AddResilientTasks()
                .AddTask<string, string>("echo", async (ctx, ct) =>
                {
                    await Task.Yield();
                    return $"you said: {ctx.Input}";
                });

            string result = await invoker.RunAsync<string, string>("echo", "hello");
            return result;
        }

        // §3 Hello world — multi-turn chain.
        public static async Task MultiTurnChain(IServiceCollection services, ITaskInvoker invoker, IMultiTurnTask multiTurn)
        {
            services
                .AddResilientTasks()
                .AddMultiTurnTask<string, string>("chat", async (ctx, ct) =>
                {
                    await Task.Yield();
                    return $"reply to: {ctx.Input}";
                });

            TaskRun<string> turn1 = await invoker.StartAsync<string, string>("chat", "hi");
            string a1 = await turn1;

            TaskRun<string> turn2 = await invoker.StartAsync<string, string>(
                "chat", "and again",
                new RunOptions { TaskId = turn1.TaskId });
            string a2 = await turn2;

            await multiTurn.DeleteAsync(turn1.TaskId);
            _ = (a1, a2);
        }

        // §4.2 Entry mode.
        public static bool InspectEntryMode(TaskContext<string> ctx)
        {
            return ctx.EntryMode switch
            {
                EntryMode.Fresh => true,
                EntryMode.Resumed => true,
                EntryMode.Recovered => true,
                _ => false,
            };
        }

        // §4.5 Metadata — durable idempotency marker.
        public static void MetadataIdempotency(TaskContext<string> ctx)
        {
            ctx.Metadata["charged"] = BinaryData.FromObjectAsJson(true);

            if (ctx.Metadata.TryGetValue("charged", out var raw) && raw.ToObjectFromJson<bool>())
            {
                // already done — skip the side effect.
            }

            TaskMetadata billing = ctx.Metadata.Namespace("billing");
            _ = billing;
        }

        // §4.6 The result handle.
        public static async Task ResultHandle(ITaskInvoker invoker)
        {
            TaskRun<string> run = await invoker.StartAsync<string, string>("echo", "hi");

            _ = run.TaskId;
            _ = run.InputId;
            _ = run.IsQueued;
            string r = await run;
            string r2 = await run.GetResultAsync();
            await run.CancelAsync();
            _ = (r, r2);
        }

        // §4.7 Steering (multi-turn only).
        public static async Task Steering(
            IServiceCollection services,
            ITaskInvoker invoker,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            services.AddResilientTasks()
                .AddMultiTurnTask<string, string>("assistant", handler, steerable: true);

            TaskRun<string> r1 = await invoker.StartAsync<string, string>("assistant", "write a long essay");
            TaskRun<string> r2 = await invoker.StartAsync<string, string>(
                "assistant", "actually, just one sentence",
                new RunOptions { TaskId = r1.TaskId });
            _ = r2;
        }

        // §4.8 Retry policy.
        public static void RetryConfiguration(
            IServiceCollection services,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            RetryPolicy policy = RetryPolicy.ExponentialBackoff(maxAttempts: 5);
            services.AddResilientTasks()
                .AddTask<string, string>("charge", handler, o => o.Retry = policy);

            _ = RetryPolicy.FixedDelay(maxAttempts: 3, delay: TimeSpan.FromSeconds(1));
            _ = RetryPolicy.LinearBackoff(maxAttempts: 3, initialDelay: TimeSpan.FromSeconds(1));
            _ = RetryPolicy.NoRetry();
        }

        // §4.10 Timeout.
        public static void TimeoutConfiguration(
            IServiceCollection services,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            services.AddResilientTasks()
                .AddTask<string, string>("summarize", handler, o => o.Timeout = TimeSpan.FromMinutes(2));
        }

        // §4.11 Shutdown — leave the work resumable.
        public static async Task ShutdownExit(TaskContext<string> ctx)
        {
            if (ctx.Shutdown.IsCancellationRequested)
            {
                await ctx.ExitForRecoveryAsync();
            }
        }

        // §5.5 RunOptions.
        public static RunOptions BuildRunOptions()
        {
            return new RunOptions
            {
                TaskId = "task-1",
                InputId = "input-1",
                IfLastInputId = "input-0",
            };
        }

        [Test]
        public void Snippets_Compile()
        {
            // Compilation is the assertion; this guard keeps the fixture discoverable.
            Assert.That(typeof(TasksGuideSnippets), Is.Not.Null);
        }
    }
}
