// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Microsoft.Extensions.DependencyInjection;
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
        public static async Task GettingStarted(IServiceCollection services, EventStreamRegistry registry, string streamId)
        {
            services.AddEventStreams();

            EventStream stream = await registry.GetOrCreateAsync(streamId);
            await stream.EmitAsync(new { token = "Hello" });
            await stream.EmitAsync(new { token = " world" });
            await stream.CloseAsync();

            await foreach (object evt in stream.Subscribe())
            {
                _ = evt;
            }
        }

        // Choosing a backing — configurator signatures.
        public static void Backings(IServiceCollection services)
        {
            services.AddEventStreams(o => o.UseInMemoryLive());

            services.AddEventStreams(o => o.UseInMemoryReplay(
                cursor: payload => ((MyEvent)payload).Sequence,
                ttl: TimeSpan.FromMinutes(10)));

            // Typed file-backed replay: storage directory (~/.agentserver/streams), a 10-minute
            // TTL, and JSON serialization all default, so only the cursor is required.
            services.AddEventStreams(o => o.UseFileBackedReplay<MyEvent>(
                cursor: e => e.Sequence));

            // The non-generic overload is for custom serialization: supply serializer/deserializer
            // whenever the cursor casts the payload to a CLR type, because the default JSON path
            // rehydrates objects as JsonNode and a typed cursor would otherwise throw after restart.
            services.AddEventStreams(o => o.UseFileBackedReplay(
                storageDirectory: "/var/streams",
                cursor: payload => ((MyEvent)payload).Sequence,
                ttl: TimeSpan.FromHours(1),
                serializer: payload => System.Text.Json.JsonSerializer.Serialize((MyEvent)payload),
                deserializer: json => System.Text.Json.JsonSerializer.Deserialize<MyEvent>(json)!));
        }

        // Subscribe-before-start — Pattern 1.
        public static async Task SubscribeBeforeStart(
            EventStreamRegistry registry,
            string id,
            Func<EventStream, Task> consumeAsync,
            Func<string, Task> startProducerAsync)
        {
            EventStream stream = await registry.GetOrCreateAsync(id);
            Task consume = consumeAsync(stream);
            await startProducerAsync(id);
            await consume;
        }

        // Recovery & resumption — cursored reconnect.
        public static async Task CursoredReconnect(EventStream stream)
        {
            await foreach (object evt in stream.Subscribe(after: 42))
            {
                _ = evt;
            }

            int? last = await stream.GetLastCursorAsync();
            _ = last;
        }

        // Registry surface.
        public static async Task RegistryUsage(EventStreamRegistry registry, string id)
        {
            EventStream created = await registry.GetOrCreateAsync(id);
            EventStream existing = await registry.GetAsync(id);
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
