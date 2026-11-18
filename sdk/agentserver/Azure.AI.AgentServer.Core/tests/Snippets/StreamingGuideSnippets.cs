// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Compiled code snippets backing <c>docs/streaming-guide.md</c>. These compile against
    /// the real public surface so the developer guide cannot drift from the shipped API.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent doc rot; they are not executed.")]
    public class StreamingGuideSnippets
    {
        private sealed record MyEvent(int Sequence, string Token);

        // 5-minute getting started — produce + consume.
        public static async Task GettingStarted(IServiceCollection services, AgentEventStreamRegistry registry, string streamId)
        {
            services.AddAgentEventStreams();

            AgentEventStream stream = await registry.GetOrCreateAsync(streamId);
            await stream.EmitAsync(new SseItem<string>(JsonSerializer.Serialize(new { token = "Hello" })) { EventId = "1" });
            await stream.EmitAsync(new SseItem<string>(JsonSerializer.Serialize(new { token = " world" })) { EventId = "2" });
            await stream.CloseAsync();

            await foreach (SseItem<string> evt in stream.Subscribe())
            {
                _ = evt.Data;
            }
        }

        // Choosing a backing — configurator signatures.
        public static void Backings(IServiceCollection services)
        {
            services.AddAgentEventStreams(o => o.UseFileBackedReplay(
                storageDirectory: "/var/streams",
                ttl: TimeSpan.FromHours(1)));
        }

        #region Snippet:StreamingGuide_ConfigBinding

        public static IHostApplicationBuilder ConfigureStreams(
            IHostApplicationBuilder builder)
        {
            return builder.AddAgentEventStreams("ResilientTasks:Streams");
        }

        #endregion

        #region Snippet:StreamingGuide_TaskBoundStreams

        public static ValueTask EmitTaskProgress(
            TaskContext<string> context,
            CancellationToken cancellationToken)
        {
            return context.Stream.EmitAsync(
                new SseItem<string>("working", "progress") { EventId = "1" },
                cancellationToken);
        }

        public static async Task ConsumeTaskProgress(
            TaskDefinition<string, string> task,
            CancellationToken cancellationToken)
        {
            TaskRun<string> run = await task.StartAsync(
                "input",
                cancellationToken: cancellationToken);

            await foreach (SseItem<string> item in
                run.Stream.Subscribe(cancellationToken: cancellationToken))
            {
                _ = item.Data;
            }

            _ = await run.Completion;
        }

        #endregion

        // Subscribe-before-start — Pattern 1.
        public static async Task SubscribeBeforeStart(
            AgentEventStreamRegistry registry,
            string id,
            Func<AgentEventStream, Task> consumeAsync,
            Func<string, Task> startProducerAsync)
        {
            AgentEventStream stream = await registry.GetOrCreateAsync(id);
            Task consume = consumeAsync(stream);
            await startProducerAsync(id);
            await consume;
        }

        // Recovery & resumption — reconnect after an event id.
        public static async Task CursoredReconnect(AgentEventStream stream)
        {
            await foreach (SseItem<string> evt in stream.Subscribe(afterEventId: "42"))
            {
                _ = evt.Data;
            }

            string? last = await stream.GetLastEventIdAsync();
            _ = last;
        }

        // Registry surface.
        public static async Task RegistryUsage(AgentEventStreamRegistry registry, string id)
        {
            AgentEventStream created = await registry.GetOrCreateAsync(id);
            AgentEventStream existing = await registry.GetAsync(id);
            await registry.DeleteAsync(id);
            _ = (created, existing);
        }

        [Test]
        public void Snippets_Compile()
        {
            Assert.That(typeof(StreamingGuideSnippets), Is.Not.Null);
        }
    }
}
