// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses.Tests.Endpoints;

public sealed class TaskStreamAdoptionTests
{
    [Test]
    public async Task ResilientStreamingPost_UsesSharedTaskBoundStream()
    {
        using var registry = new CountingEventStreamRegistry();
        using var factory = new TestWebApplicationFactory(
            configureTestServices: services =>
                services.AddSingleton<AgentEventStreamRegistry>(registry));
        using var client = factory.CreateClient();

        var body = JsonSerializer.Serialize(new
        {
            model = "test",
            stream = true,
            background = true,
        });
        using var response = await client.PostAsync(
            "/responses",
            new StringContent(body, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var sse = await response.Content.ReadAsStringAsync();
        Assert.That(sse, Does.Contain("event: response.created"));
        Assert.That(sse, Does.Contain("event: response.completed"));
        Assert.That(registry.TaskGetOrCreateCallCount, Is.EqualTo(1),
            "TaskContext.Stream and TaskRun.Stream must share Core's lazy task stream; " +
            "producer and consumer must materialize one task-owned stream.");
        Assert.That(registry.GetOrCreateCallCount, Is.Zero,
            "Resilient POST streaming must not fall back to the unowned registry path.");
    }

    private sealed class CountingEventStreamRegistry :
        AgentEventStreamRegistry,
        ITaskEventStreamRegistry,
        IDisposable
    {
        private readonly ServiceProvider _provider;
        private readonly AgentEventStreamRegistry _inner;
        private readonly ITaskEventStreamRegistry _taskInner;
        private int _getOrCreateCallCount;
        private int _taskGetOrCreateCallCount;

        public CountingEventStreamRegistry()
        {
            var services = new ServiceCollection();
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
            _provider = services.BuildServiceProvider();
            _inner = _provider.GetRequiredService<AgentEventStreamRegistry>();
            _taskInner = (ITaskEventStreamRegistry)_inner;
        }

        public int GetOrCreateCallCount => Volatile.Read(ref _getOrCreateCallCount);

        public int TaskGetOrCreateCallCount => Volatile.Read(ref _taskGetOrCreateCallCount);

        public override ValueTask<AgentEventStream> GetAsync(
            string id,
            CancellationToken cancellationToken = default)
            => _inner.GetAsync(id, cancellationToken);

        public override ValueTask<AgentEventStream> GetOrCreateAsync(
            string id,
            CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _getOrCreateCallCount);
            return _inner.GetOrCreateAsync(id, cancellationToken);
        }

        public override ValueTask DeleteAsync(
            string id,
            CancellationToken cancellationToken = default)
            => _inner.DeleteAsync(id, cancellationToken);

        public ValueTask<AgentEventStream?> GetTaskStreamAsync(
            string taskId,
            string inputId,
            CancellationToken cancellationToken = default)
            => _taskInner.GetTaskStreamAsync(taskId, inputId, cancellationToken);

        public ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(
            string taskId,
            string inputId,
            CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _taskGetOrCreateCallCount);
            return _taskInner.GetOrCreateTaskStreamAsync(taskId, inputId, cancellationToken);
        }

        public void Dispose() => _provider.Dispose();
    }
}
