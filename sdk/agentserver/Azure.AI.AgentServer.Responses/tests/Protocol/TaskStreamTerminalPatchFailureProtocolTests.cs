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
        bool multiTurn, bool delayReplay)
    {
        string root = Path.Combine(
            Path.GetTempPath(),
            "agentserver-terminal-patch-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        string? previousStateRoot = Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT");
        Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", root);

        try
        {
            bool terminalPatchFailed = false;
            using var delayedRegistry = delayReplay ? new DelayedReplayRegistry(() => Volatile.Read(ref terminalPatchFailed)) : null;
            var store = new SpyTaskStore(new LocalTaskStore(Path.Combine(root, "tasks")))
            {
                ThrowOnPatch = new IOException("Injected terminal task patch failure."),
                PatchFailurePredicate = patch =>
                {
                    bool terminal = string.Equals(
                        patch.Status,
                        multiTurn ? TaskWireKeys.StatusSuspended : TaskWireKeys.StatusCompleted,
                        StringComparison.Ordinal);
                    if (terminal)
                    {
                        Volatile.Write(ref terminalPatchFailed, true);
                    }
                    return terminal;
                },
            };
            var logger = new CapturingLogger<ResponseEndpointHandler>();

            using var factory = new TestWebApplicationFactory(
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
            using HttpClient client = factory.CreateClient();
            string responseId = IdGenerator.NewResponseId();
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

            using HttpResponseMessage response = await client.SendAsync(
                request,
                HttpCompletionOption.ResponseHeadersRead);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string body = await response.Content.ReadAsStringAsync()
                .WaitAsync(TimeSpan.FromSeconds(10));
            Assert.That(body, Does.Contain("event: response.created"));
            Assert.That(body.IndexOf("event: response.created", StringComparison.Ordinal),
                Is.LessThan(body.IndexOf("event: error", StringComparison.Ordinal)));
            Assert.That(body, Does.Contain("event: error"),
                "The relay must surface the task completion failure instead of waiting forever for EOF.");
            Assert.That(logger.LastException, Is.InstanceOf<ResilientTaskException>(),
                "SseResult must handle the task completion fault, not a concurrent enumerator cleanup error.");

            var registry =
                (ITaskEventStreamRegistry)factory.Services.GetRequiredService<AgentEventStreamRegistry>();
            string taskId = store.LastCreateRequest!.Id!;
            AgentEventStream? taskStream = await registry.GetTaskStreamAsync(taskId, responseId);
            Assert.That(taskStream, Is.Not.Null);
            int lastSequence = int.Parse((await taskStream!.GetLastEventIdAsync())!, System.Globalization.CultureInfo.InvariantCulture);
            var events = Helpers.SseParser.Parse(body);
            Assert.That(events.Last().EventType, Is.EqualTo("error"));
            var deliveredSequences = events.Take(events.Count - 1).Select(item =>
            {
                using var document = JsonDocument.Parse(item.Data);
                return document.RootElement.GetProperty("sequence_number").GetInt32();
            }).ToArray();
            Assert.That(deliveredSequences, Is.EqualTo(Enumerable.Range(0, lastSequence + 1)),
                "Every retained event must reach the client in order before the terminal task error.");
            Assert.DoesNotThrowAsync(async () =>
                await taskStream!.EmitAsync(
                    new SseItem<string>("recovery-probe") { EventId = "recovery-probe" }));
            await taskStream!.CloseAsync();
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

    private sealed class DelayedReplayRegistry : AgentEventStreamRegistry, ITaskEventStreamRegistry, IDisposable
    {
        private readonly ServiceProvider _provider;
        private readonly AgentEventStreamRegistry _inner;
        private readonly ITaskEventStreamRegistry _taskInner;
        private readonly Func<bool> _terminalPatchFailed;
        private readonly TaskCompletionSource _releaseReplay = new(TaskCreationOptions.RunContinuationsAsynchronously);

        public DelayedReplayRegistry(Func<bool> terminalPatchFailed)
        {
            var services = new ServiceCollection();
            services.AddAgentEventStreams(options => options.UseInMemoryReplay());
            _provider = services.BuildServiceProvider();
            _inner = _provider.GetRequiredService<AgentEventStreamRegistry>();
            _taskInner = (ITaskEventStreamRegistry)_inner;
            _terminalPatchFailed = terminalPatchFailed;
        }

        public override ValueTask<AgentEventStream> GetAsync(string id, CancellationToken cancellationToken = default)
            => _inner.GetAsync(id, cancellationToken);

        public override ValueTask<AgentEventStream> GetOrCreateAsync(string id, CancellationToken cancellationToken = default)
            => _inner.GetOrCreateAsync(id, cancellationToken);

        public override ValueTask DeleteAsync(string id, CancellationToken cancellationToken = default)
            => _inner.DeleteAsync(id, cancellationToken);

        public ValueTask<AgentEventStream?> GetTaskStreamAsync(string taskId, string inputId, CancellationToken cancellationToken = default)
            => _taskInner.GetTaskStreamAsync(taskId, inputId, cancellationToken);

        public async ValueTask<AgentEventStream> GetOrCreateTaskStreamAsync(
            string taskId, string inputId, CancellationToken cancellationToken = default)
            => new DelayedReplayStream(
                await _taskInner.GetOrCreateTaskStreamAsync(taskId, inputId, cancellationToken), this);

        public Task<int> CloseOrphanTaskStreamsAsync(
            Func<string, string, ValueTask<bool>> shouldClose, CancellationToken cancellationToken = default)
            => _taskInner.CloseOrphanTaskStreamsAsync(shouldClose, cancellationToken);

        public void Dispose() => _provider.Dispose();

        private sealed class DelayedReplayStream(AgentEventStream inner, DelayedReplayRegistry owner) : AgentEventStream
        {
            public override ValueTask EmitAsync(SseItem<string> item, bool close = false, CancellationToken cancellationToken = default)
                => inner.EmitAsync(item, close, cancellationToken);

            public override ValueTask CloseAsync(CancellationToken cancellationToken = default)
                => inner.CloseAsync(cancellationToken);

            public override ValueTask<string?> GetLastEventIdAsync(CancellationToken cancellationToken = default)
            {
                if (owner._terminalPatchFailed())
                {
                    owner._releaseReplay.TrySetResult();
                }
                return inner.GetLastEventIdAsync(cancellationToken);
            }

            public override async IAsyncEnumerable<SseItem<string>> Subscribe(
                string? afterEventId = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
            {
                // Force the terminal fault to win before the asynchronous replay read can return.
                await owner._releaseReplay.Task.WaitAsync(cancellationToken);
                await foreach (var item in inner.Subscribe(afterEventId, cancellationToken))
                {
                    await Task.Yield();
                    yield return item;
                }
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
