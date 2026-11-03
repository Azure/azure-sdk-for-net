// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.ServerSentEvents;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

[TestFixture]
[NonParallelizable]
public class TaskStreamTerminalPatchFailureProtocolTests
{
    [TestCase(false, false)]
    [TestCase(true, false)]
    [TestCase(false, true)]
    [TestCase(true, true)]
    public async Task StreamingTerminalTaskPatchFailure_EmitsErrorAndLeavesRecoverableStreamOpen(
        bool multiTurn, bool delayedSubscription)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-terminal-patch-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        string? previousStateRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);

        try
        {
            var store = new SpyTaskStore(new LocalTaskStore(Path.Combine(root, "tasks")))
            {
                ThrowOnPatch = new IOException("Injected terminal task patch failure."),
                PatchFailurePredicate = patch => string.Equals(
                    patch.Status,
                    multiTurn ? TaskWireKeys.StatusSuspended : TaskWireKeys.StatusCompleted,
                    StringComparison.Ordinal),
            };
            var logger = new CapturingLogger<ResponseEndpointHandler>();
            using var delayedRegistry = delayedSubscription ? new DelayedEventStreamRegistry() : null;
            string responseId = IdGenerator.NewResponseId();
            var handler = new TestHandler();
            if (delayedRegistry is not null)
            {
                handler.EventFactory = Events;
            }

            using var factory = new TestWebApplicationFactory(
                handler: handler,
                configureOptions: options => options.ResilientBackground = true,
                configureTestServices: services =>
                {
                    services.AddSingleton<ITaskStore>(store);
                    services.AddSingleton<ILogger<ResponseEndpointHandler>>(logger);
                    if (delayedRegistry is not null)
                    {
                        services.AddSingleton<AgentEventStreamRegistry>(delayedRegistry);
                    }
                });
            if (delayedRegistry is not null)
            {
                delayedRegistry.OnSubscribe = () =>
                {
                    var tracker = factory.Services.GetRequiredService<ResponseExecutionTracker>();
                    Assert.That(tracker.TryGet(responseId, out var execution), Is.True);
                    return execution!.ExecutionTask!;
                };
            }
            using HttpClient client = factory.CreateClient();
            var payload = new Dictionary<string, object?>
            {
                ["model"] = "test",
                ["stream"] = true,
                ["background"] = true,
                ["store"] = true,
            };
            if (multiTurn)
            {
                payload["conversation"] = new { id = "conv_terminal_patch_failure" };
            }

            using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(payload),
                    Encoding.UTF8,
                    "application/json"),
            };
            request.Headers.Add("x-agent-response-id", responseId);

            Task<HttpResponseMessage> pendingResponse = client.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead);
            if (delayedRegistry is not null)
            {
                try
                {
                    Task completion = await delayedRegistry.SubscriptionStarted.Task.WaitAsync(TimeSpan.FromSeconds(10));
                    Assert.ThrowsAsync<ResilientTaskException>(async () =>
                        await completion.WaitAsync(TimeSpan.FromSeconds(10)));
                }
                finally
                {
                    delayedRegistry.ReleaseRead.TrySetResult();
                }
            }
            using HttpResponseMessage response = await pendingResponse.WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string body = await response.Content.ReadAsStringAsync()
                .WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(body, Does.Contain("event: response.created"));
            Assert.That(body, Does.Contain("event: response.completed"));
            Assert.That(body, Does.Contain("event: error"),
                "The relay must surface the task completion failure instead of waiting forever for EOF.");
            Assert.That(body.IndexOf("event: response.created", StringComparison.Ordinal),
                Is.LessThan(body.IndexOf("event: response.completed", StringComparison.Ordinal)));
            Assert.That(body.IndexOf("event: response.completed", StringComparison.Ordinal),
                Is.LessThan(body.IndexOf("event: error", StringComparison.Ordinal)));
            Assert.That(logger.LastException, Is.InstanceOf<ResilientTaskException>(),
                "SseResult must handle the task completion fault, not a concurrent enumerator cleanup error.");

            var registry =
                (ITaskEventStreamRegistry)factory.Services.GetRequiredService<AgentEventStreamRegistry>();
            string taskId = store.LastCreateRequest!.Id!;
            AgentEventStream? taskStream = await registry.GetTaskStreamAsync(taskId, responseId);
            Assert.That(taskStream, Is.Not.Null);
            Assert.DoesNotThrowAsync(async () =>
                await taskStream!.EmitAsync(
                    new SseItem<string>("recovery-probe") { EventId = "recovery-probe" }));
            await taskStream!.CloseAsync();

            async IAsyncEnumerable<ResponseStreamEvent> Events(
                CreateResponse createRequest, ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var result = new ResponseObject(context.ResponseId, createRequest.Model ?? "test");
                yield return new ResponseCreatedEvent(0, result);
                await delayedRegistry!.SubscriptionStarted.Task.WaitAsync(cancellationToken);
                result.SetCompleted();
                yield return new ResponseCompletedEvent(0, result);
            }
        }
        finally
        {
            Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", previousStateRoot);
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    private sealed class DelayedEventStreamRegistry : AgentEventStreamRegistry, ITaskEventStreamRegistry, IDisposable
    {
        private readonly ServiceProvider _provider;
        private readonly AgentEventStreamRegistry _inner;
        private readonly ITaskEventStreamRegistry _taskInner;
        private AgentEventStream? _delayedStream;

        public DelayedEventStreamRegistry()
        {
            var services = new ServiceCollection();
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
            _provider = services.BuildServiceProvider();
            _inner = _provider.GetRequiredService<AgentEventStreamRegistry>();
            _taskInner = (ITaskEventStreamRegistry)_inner;
        }

        public Func<Task>? OnSubscribe { get; set; }
        public TaskCompletionSource<Task> SubscriptionStarted { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ReleaseRead { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default) =>
            _inner.GetAsync(id, cancellationToken);

        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default) =>
            _inner.GetOrCreateAsync(id, cancellationToken);

        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default) =>
            _inner.DeleteAsync(id, cancellationToken);

        public ValueTask<AgentEventStream?> GetTaskStreamAsync(
            string taskId, string inputId, CancellationToken cancellationToken = default) =>
            _taskInner.GetTaskStreamAsync(taskId, inputId, cancellationToken);

        public async ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(
            string taskId, string inputId, CancellationToken cancellationToken = default)
        {
            var stream = await _taskInner.GetOrCreateTaskStreamAsync(taskId, inputId, cancellationToken);
            return _delayedStream ??= new DelayedSubscriptionStream(stream, this);
        }

        public Task<int> CloseOrphanTaskStreamsAsync(
            Func<string, string, ValueTask<bool>> shouldClose, CancellationToken cancellationToken = default) =>
            _taskInner.CloseOrphanTaskStreamsAsync(shouldClose, cancellationToken);

        public void Dispose() => _provider.Dispose();
    }

    private sealed class DelayedSubscriptionStream(AgentEventStream inner, DelayedEventStreamRegistry owner) : AgentEventStream
    {
        public override ValueTask EmitAsync(
            SseItem<string> item, bool close = false, CancellationToken cancellationToken = default) =>
            inner.EmitAsync(item, close, cancellationToken);

        public override ValueTask CloseAsync(CancellationToken cancellationToken = default) =>
            inner.CloseAsync(cancellationToken);

        public override ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default) =>
            inner.GetLastEventIdAsync(cancellationToken);

        public override async IAsyncEnumerable<SseItem<string>> Subscribe(
            string? afterEventId = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            owner.SubscriptionStarted.TrySetResult(owner.OnSubscribe!());
            await owner.ReleaseRead.Task.WaitAsync(cancellationToken);
            await foreach (var item in inner.Subscribe(afterEventId, cancellationToken))
            {
                await Task.Yield();
                yield return item;
            }
        }
    }

    private sealed class CapturingLogger<T> : ILogger<T>
    {
        private Exception? _lastException;

        public Exception? LastException => Volatile.Read(ref _lastException);

        public IDisposable? BeginScope<TState>(TState state)
            where TState : notnull
            => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (exception is not null)
            {
                Volatile.Write(ref _lastException, exception);
            }
        }
    }
}
