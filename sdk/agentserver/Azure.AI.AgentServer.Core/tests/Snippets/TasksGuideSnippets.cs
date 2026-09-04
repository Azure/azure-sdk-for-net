// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        // §3 Hello world — one-shot registration returns a typed TaskDefinition.
        public static async Task<string> OneShotHelloWorld()
        {
            #region Snippet:Core_TasksGuide_OneShotHelloWorld

            var builder = AgentHost.CreateBuilder();

            TaskDefinition<string, string> echo = builder.Services.AddResilientTask<string, string>(
                "echo", async (ctx, ct) =>
                {
                    await Task.Yield();
                    return $"you said: {ctx.Input}";
                });

            var app = builder.Build();
            await app.App.StartAsync();

            string result = await echo.RunAsync("hello");
            // result == "you said: hello"

            await app.App.StopAsync();

            #endregion

            return result;
        }

        // §3 Hello world — resolving a registered task later (e.g. in a request handler), instead
        // of capturing the handle returned at registration time.
        public static async Task<string> ResolveRegisteredTaskLater(IServiceCollection services)
        {
            services.AddResilientTask<string, string>("echo", async (ctx, ct) =>
            {
                await Task.Yield();
                return $"you said: {ctx.Input}";
            });

            await using ServiceProvider provider = services.BuildServiceProvider();
            await StartHostedServicesAsync(provider);

            // Elsewhere — e.g. a request handler resolved from DI — get the same task by name.
            TaskDefinition<string, string> echo = provider.GetResilientTask<string, string>("echo");
            return await echo.RunAsync("hello again");
        }

        #region Snippet:TasksGuide_ScopedHandler

        internal sealed class GreetingPrefix
        {
            public string Value => "injected: ";
        }

        internal sealed class ScopedEchoHandler(
            GreetingPrefix prefix)
            : IResilientTaskHandler<string, string>
        {
            public Task<string> RunAsync(
                TaskContext<string> context,
                CancellationToken cancellationToken)
                => Task.FromResult(prefix.Value + context.Input);
        }

        public static TaskDefinition<string, string> RegisterScopedHandler(
            IServiceCollection services)
        {
            services.AddScoped<GreetingPrefix>();
            return services.AddResilientTask<string, string, ScopedEchoHandler>(
                "scoped-echo");
        }

        #endregion

        // §3 Hello world — multi-turn chain.
        public static async Task MultiTurnChain(IServiceCollection services)
        {
            TaskDefinition<string, string> chat = services.AddResilientMultiTurnTask<string, string>(
                "chat", async (ctx, ct) =>
                {
                    await Task.Yield();
                    return $"reply to: {ctx.Input}";
                });

            await using ServiceProvider provider = services.BuildServiceProvider();
            await StartHostedServicesAsync(provider);

            // A multi-turn chain REQUIRES an explicit TaskId (the chain id) that you own — reuse it
            // across turns to continue the same chain.
            string chatId = "chat-1";
            TaskRun<string> turn1 = await chat.StartAsync(
                "hi", new RunOptions { TaskId = chatId });
            string a1 = await turn1.Completion;

            TaskRun<string> turn2 = await chat.StartAsync(
                "and again",
                new RunOptions { TaskId = chatId });
            string a2 = await turn2.Completion;

            await chat.DeleteAsync(chatId);
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

        // §4.6 The result handle.
        public static async Task ResultHandle(TaskDefinition<string, string> echo)
        {
            TaskRun<string> run = await echo.StartAsync("hi");

            _ = run.TaskId;
            _ = run.InputId;
            _ = run.IsQueued;
            _ = run.Stream;
            string r = await run.Completion;
            string r2 = await run.Completion;
            await run.RequestCancellationAsync();
            _ = (r, r2);
        }

        // §4.7 Steering (multi-turn only).
        public static async Task Steering(
            IServiceCollection services,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            TaskDefinition<string, string> assistant = services.AddResilientMultiTurnTask<string, string>(
                "assistant", handler, steerable: true);

            await using ServiceProvider provider = services.BuildServiceProvider();
            await StartHostedServicesAsync(provider);

            // Both inputs use the SAME explicit chain id, so the second one steers the running turn
            // instead of starting a new chain.
            string chatId = "assistant-1";
            TaskRun<string> r1 = await assistant.StartAsync(
                "write a long essay", new RunOptions { TaskId = chatId });
            TaskRun<string> r2 = await assistant.StartAsync(
                "actually, just one sentence",
                new RunOptions { TaskId = chatId });
            _ = r2;
        }

        // §4.8 Retry policy.
        public static void RetryConfiguration(
            IServiceCollection services,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            // Retries compose an Azure.Core DelayStrategy — exponential is the default.
            TaskRetryPolicy policy = new() { MaxAttempts = 5 };
            services.AddResilientTask<string, string>("charge", handler, o => o.Retry = policy);

            _ = new TaskRetryPolicy { MaxAttempts = 3, Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.FromSeconds(1)) };
            _ = new TaskRetryPolicy { MaxAttempts = 3, Delay = DelayStrategy.CreateExponentialDelayStrategy(TimeSpan.FromSeconds(1)) };
            _ = new TaskRetryPolicy { MaxAttempts = 1 }; // no retries
        }

        // §4.10 Timeout.
        public static void TimeoutConfiguration(
            IServiceCollection services,
            Func<TaskContext<string>, CancellationToken, Task<string>> handler)
        {
            services.AddResilientTask<string, string>("summarize", handler, o => o.Timeout = TimeSpan.FromMinutes(2));
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

        // Starts the host's IHostedServices, which constructs the TaskEngine (the durability
        // service depends on it) and late-binds it into every TaskDefinition handle so invocation
        // works. In a real app the host does this for you; the snippets call it explicitly because
        // they register and invoke in one method rather than across startup and request handling.
        private static async Task StartHostedServicesAsync(IServiceProvider provider)
        {
            foreach (IHostedService hosted in provider.GetServices<IHostedService>())
            {
                await hosted.StartAsync(CancellationToken.None);
            }
        }

        [Test]
        public void Snippets_Compile()
        {
            // Compilation is the assertion; this guard keeps the fixture discoverable.
            Assert.That(typeof(TasksGuideSnippets), Is.Not.Null);
        }
    }
}
