// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.ServerSentEvents;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI.Responses;
using Research = Azure.AI.AgentServer.Invocations.Tests.Snippets.SampleResilientResearchSnippets;

#pragma warning disable OPENAI001

namespace Azure.AI.AgentServer.Invocations.Tests;

public partial class SampleEndToEndTests
{
    [Test]
    [NonParallelizable]
    public async Task TaskStreamQueuedCancellationFinishesPostAndGetSse(
        [Values(false, true)] bool fileBacked,
        [Values(false, true)] bool getBeforeCancel)
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> post = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        Task<string>? get = getBeforeCancel ? probe.ReadSseAsync("b") : null;
        using HttpResponseMessage cancel = await probe.CancelAsync("b");
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(await post.WaitAsync(TimeSpan.FromSeconds(3)), Does.Contain("event: done"));
        get ??= probe.ReadSseAsync("b");
        Assert.That(await get.WaitAsync(TimeSpan.FromSeconds(3)), Does.Contain("event: done"));
        Assert.That(await probe.ReadSseAsync("b").WaitAsync(TimeSpan.FromSeconds(3)), Does.Contain("event: done"));
        Assert.That(probe.Starts.ContainsKey("b"), Is.False);
        Assert.That(probe.Contexts["a"].CancelRequested, Is.False);
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamUnmaterializedCancellationDoesNotAllocateStream([Values(false, true)] bool fileBacked)
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        await probe.PostAsync("b");
        Assert.That(async () => await probe.Registry.GetAsync(probe.Id("b")), Throws.TypeOf<AgentEventStreamNotFoundException>());
        using HttpResponseMessage cancel = await probe.CancelAsync("b");
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        using HttpResponseMessage get = await probe.GetResponseAsync("b");
        Assert.That(get.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(FileBackedReplayEventStream.Exists(probe.Id("b"), probe.StreamDirectory), Is.False);
        Assert.That(probe.Starts.ContainsKey("b"), Is.False);
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamPromotionPreservesProducerTerminalEvent([Values(false, true)] bool fileBacked)
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> post = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        probe.Backend.FirstRelease.TrySetResult();
        await probe.Backend.SecondEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        using HttpResponseMessage cancel = await probe.CancelAsync("b");
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(probe.Finishes.ContainsKey("b"), Is.False);
        await probe.AssertStreamStillOpenAsync("b");
        probe.Backend.SecondRelease.TrySetResult();
        string body = await post.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(ParseSseEvents(body).Count(e => e.Type == "run_failed"), Is.EqualTo(1));
        Assert.That(body.LastIndexOf("event: done", StringComparison.Ordinal),
            Is.GreaterThan(body.IndexOf("event: run_failed", StringComparison.Ordinal)));
        Assert.That(await probe.ReadSseAsync("b").WaitAsync(TimeSpan.FromSeconds(3)), Is.EqualTo(body));
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamFailedSuspendLeavesStreamOpen()
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked: true);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> post = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        probe.Backend.FirstRelease.TrySetResult();
        await probe.Backend.SecondEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        probe.Store.FailSuspensions = true;
        using HttpResponseMessage cancel = await probe.CancelAsync("b");
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        probe.Backend.SecondRelease.TrySetResult();
        await probe.WaitUntilInactiveAsync();
        Assert.That(probe.Store.SuspendFailures, Is.EqualTo(1));
        Assert.That((await probe.Store.GetAsync(probe.TaskId))!.Status, Is.EqualTo("in_progress"));
        await probe.AssertStreamStillOpenAsync("b");
        Assert.That(post.IsCompleted, Is.False);
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamFailedQueueRemovalDoesNotClose()
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked: true);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> post = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        probe.Store.FailQueueWrites = true;
        try
        {
            Assert.That(async () =>
            {
                using HttpResponseMessage response = await probe.CancelAsync("b");
            }, Throws.InstanceOf<IOException>());
            Assert.That(probe.Store.QueueFailures, Is.EqualTo(1));
            TaskRecord record = (await probe.Store.GetAsync(probe.TaskId))!;
            Assert.That(record.Payload[TaskWireKeys.PayloadSteering]![TaskWireKeys.SteeringPendingInputs]!.AsArray().Count, Is.EqualTo(1));
            await probe.AssertStreamStillOpenAsync("b");
            Assert.That(post.IsCompleted, Is.False);
        }
        finally
        {
            probe.Store.FailQueueWrites = false;
        }
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamCancellationPreservesOtherQueuedTurn()
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked: false);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> b = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        Task<string> c = probe.PostSseAsync("c");
        await probe.WaitForStreamAsync("c");
        using HttpResponseMessage cancel = await probe.CancelAsync("b");
        Assert.That(cancel.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(await b.WaitAsync(TimeSpan.FromSeconds(3)), Does.Contain("event: done"));
        Assert.That(probe.Contexts["a"].CancelRequested, Is.False);
        await probe.AssertStreamStillOpenAsync("c");
        probe.Backend.FirstRelease.TrySetResult();
        await probe.Backend.SecondEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Assert.That(probe.Starts.ContainsKey("c"), Is.True);
        Assert.That(probe.Starts.ContainsKey("b"), Is.False);
        probe.Backend.SecondRelease.TrySetResult();
        Assert.That(await c.WaitAsync(TimeSpan.FromSeconds(5)), Does.Contain("event: done"));
    }

    [Test]
    [NonParallelizable]
    public async Task TaskStreamShutdownDeferralPreservesMaterializedQueuedStream()
    {
        await using var probe = await CoreStreamHost.CreateAsync(fileBacked: true);
        await probe.PostAsync("a");
        await probe.Backend.FirstEntered.Task.WaitAsync(TimeSpan.FromSeconds(10));
        Task<string> post = probe.PostSseAsync("b");
        await probe.WaitForStreamAsync("b");
        probe.Engine.SignalShutdown();
        probe.Backend.FirstRelease.TrySetResult();
        await probe.WaitUntilInactiveAsync();
        Assert.That(probe.Starts.ContainsKey("b"), Is.False);
        await probe.AssertStreamStillOpenAsync("b");
        Assert.That(post.IsCompleted, Is.False);
    }

    private sealed class CoreStreamHost : IAsyncDisposable
    {
        private readonly Dictionary<string, string?> _environment = new();
        private readonly string _root = Path.Combine(Directory.GetCurrentDirectory(), "artifacts", "task-stream-tests", Guid.NewGuid().ToString("N"));
        private readonly CancellationTokenSource _httpStop = new(TimeSpan.FromSeconds(30));
        private readonly List<Task<string>> _requests = new();
        private TestEnv _env = null!;
        private HttpClient? _modelTransport;

        private CoreStreamHost()
        {
            foreach (string key in new[] { "AGENTSERVER_STATE_ROOT", "FOUNDRY_HOSTING_ENVIRONMENT", "FOUNDRY_PROJECT_ENDPOINT" })
            {
                _environment[key] = Environment.GetEnvironmentVariable(key);
            }
        }

        public string Session { get; } = "task-stream-" + Guid.NewGuid().ToString("N");
        public string TaskId => "research-" + Session;
        public string Id(string turn) => Session + "-" + turn;
        public string StreamDirectory => Path.Combine(_root, "streams");
        public CoreGatedBackend Backend { get; } = new();
        public CoreFaultingTaskStore Store { get; private set; } = null!;
        public AgentEventStreamRegistry Registry => _env.Services.GetRequiredService<AgentEventStreamRegistry>();
        public TaskEngine Engine => _env.Services.GetRequiredService<TaskEngine>();
        public ConcurrentDictionary<string, bool> Starts { get; } = new();
        public ConcurrentDictionary<string, bool> Finishes { get; } = new();
        public ConcurrentDictionary<string, TaskContext<Research.ResearchRequest>> Contexts { get; } = new();

        public static async Task<CoreStreamHost> CreateAsync(bool fileBacked)
        {
            var probe = new CoreStreamHost();
            try
            {
                Environment.SetEnvironmentVariable("AGENTSERVER_STATE_ROOT", probe._root);
                Environment.SetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT", null);
                Environment.SetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT", null);
                FoundryEnvironment.Reload();
                probe.Store = new CoreFaultingTaskStore(new LocalTaskStore());
                probe._modelTransport = new HttpClient(probe.Backend);
                var model = new ResponsesClient(new ApiKeyCredential("unused-key"),
                    new ResponsesClientOptions
                    {
                        Endpoint = new Uri("http://mock-openai-backend"),
                        Transport = new HttpClientPipelineTransport(probe._modelTransport),
                    });
                probe._env = await CreateTestServerAsync<Research.ResilientResearchHandler>(
                    services =>
                    {
                        services.AddAgentEventStreams(options =>
                        {
                            if (fileBacked)
                            {
                                options.UseFileBackedReplay(probe.StreamDirectory);
                            }
                            else
                            {
                                options.UseInMemoryReplay(ttl: TimeSpan.FromMinutes(5));
                            }
                        });
                        services.AddSingleton<ITaskStore>(probe.Store);
                        services.AddResilientMultiTurnTask<Research.ResearchRequest, Research.ResearchResult>(
                            "research",
                            async (context, token) =>
                            {
                                string turn = context.Input.Topic;
                                probe.Starts[turn] = true;
                                probe.Contexts[turn] = context;
                                try
                                {
                                    return await Research.RunResearchAsync(model, "test-model", context,
                                        numPhases: 1, callsPerPhase: 1,
                                        interPhaseCooldown: TimeSpan.Zero, intraPhaseCooldown: TimeSpan.Zero, ct: token);
                                }
                                finally
                                {
                                    probe.Finishes[turn] = true;
                                }
                            },
                            steerable: true);
                    });
                Assert.That(probe.Registry, Is.TypeOf<InMemoryEventStreamRegistry>());
                Assert.That(probe.Registry, Is.InstanceOf<ITaskEventStreamRegistry>());
                return probe;
            }
            catch
            {
                await probe.DisposeAsync();
                throw;
            }
        }

        public async Task PostAsync(string turn)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "/invocations?agent_session_id=" + Session);
            request.Headers.Add("x-agent-invocation-id", Id(turn));
            request.Content = new StringContent(JsonSerializer.Serialize(new { Topic = turn }), Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await _env.Client.SendAsync(request, _httpStop.Token);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        }

        public Task<string> PostSseAsync(string turn) => Track(ReadHttpAsync(HttpMethod.Post, turn));
        public Task<string> ReadSseAsync(string turn) => Track(ReadHttpAsync(HttpMethod.Get, turn));
        private Task<string> Track(Task<string> request)
        {
            _requests.Add(request);
            return request;
        }

        private async Task<string> ReadHttpAsync(HttpMethod method, string turn)
        {
            string path = method == HttpMethod.Post ? "/invocations" : "/invocations/" + Id(turn);
            using var request = new HttpRequestMessage(method, path + "?agent_session_id=" + Session);
            request.Headers.Accept.ParseAdd("text/event-stream");
            if (method == HttpMethod.Post)
            {
                request.Headers.Add("x-agent-invocation-id", Id(turn));
                request.Content = new StringContent(JsonSerializer.Serialize(new { Topic = turn }), Encoding.UTF8, "application/json");
            }

            using HttpResponseMessage response = await _env.Client.SendAsync(request, _httpStop.Token);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            return await response.Content.ReadAsStringAsync(_httpStop.Token);
        }

        public Task<HttpResponseMessage> GetResponseAsync(string turn) =>
            _env.Client.GetAsync($"/invocations/{Id(turn)}?agent_session_id={Session}", _httpStop.Token);
        public Task<HttpResponseMessage> CancelAsync(string turn) =>
            _env.Client.PostAsync($"/invocations/{Id(turn)}/cancel?agent_session_id={Session}", null, _httpStop.Token);

        public async Task<AgentEventStream> WaitForStreamAsync(string turn)
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            while (true)
            {
                try
                {
                    return await Registry.GetAsync(Id(turn), timeout.Token);
                }
                catch (AgentEventStreamNotFoundException)
                {
                    await Task.Delay(20, timeout.Token);
                }
            }
        }

        public async Task AssertStreamStillOpenAsync(string turn)
        {
            AgentEventStream stream = await Registry.GetAsync(Id(turn));
            string? last = await stream.GetLastEventIdAsync();
            using var stop = new CancellationTokenSource();
            await using IAsyncEnumerator<SseItem<string>> reader = stream.Subscribe(last, stop.Token).GetAsyncEnumerator();
            Task<bool> next = reader.MoveNextAsync().AsTask();
            try
            {
                Assert.That(next.IsCompleted, Is.False, "With no events after the current cursor, a closed stream would already be at EOF.");
            }
            finally
            {
                stop.Cancel();
                try
                {
                    await next;
                }
                catch (OperationCanceledException) when (stop.IsCancellationRequested)
                {
                }
            }
        }

        public async Task WaitUntilInactiveAsync()
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            while (Engine.IsActive(TaskId))
            {
                await Task.Delay(20, timeout.Token);
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (Store is not null)
            {
                Store.FailQueueWrites = false;
                Store.FailSuspensions = false;
            }
            if (_env is not null)
            {
                Engine.SignalShutdown();
            }
            Backend.FirstRelease.TrySetResult();
            Backend.SecondRelease.TrySetResult();
            _httpStop.Cancel();
            try
            {
                try
                {
                    await Task.WhenAll(_requests.Select(ObserveRequestAsync)).WaitAsync(TimeSpan.FromSeconds(10));
                }
                finally
                {
                    if (_env is not null)
                    {
                        await _env.DisposeAsync();
                    }
                }
            }
            finally
            {
                foreach (var pair in _environment)
                {
                    Environment.SetEnvironmentVariable(pair.Key, pair.Value);
                }
                FoundryEnvironment.Reload();
                _modelTransport?.Dispose();
                if (_modelTransport is null)
                {
                    Backend.Dispose();
                }
                _httpStop.Dispose();
                if (Directory.Exists(_root))
                {
                    Directory.Delete(_root, recursive: true);
                }
            }
        }

        private async Task ObserveRequestAsync(Task<string> request)
        {
            try
            {
                await request;
            }
            catch (OperationCanceledException) when (_httpStop.IsCancellationRequested)
            {
            }
        }
    }

    private sealed class CoreGatedBackend : DelegatingHandler
    {
        public CoreGatedBackend() : base(new MockStreamingBackendHandler()) { }
        public TaskCompletionSource FirstEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource FirstRelease { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource SecondEntered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource SecondRelease { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private int _calls;
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int call = Interlocked.Increment(ref _calls);
            // Hold producer wind-down after cancellation until the test explicitly releases it.
            if (call == 1)
            {
                FirstEntered.TrySetResult();
                await FirstRelease.Task;
            }
            else if (call == 2)
            {
                SecondEntered.TrySetResult();
                await SecondRelease.Task;
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }

    private sealed class CoreFaultingTaskStore(ITaskStore inner) : ITaskStore
    {
        public bool FailSuspensions { get; set; }
        public bool FailQueueWrites { get; set; }
        public int SuspendFailures { get; private set; }
        public int QueueFailures { get; private set; }
        public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
            => inner.CreateAsync(request, cancellationToken);
        public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
            => inner.GetAsync(taskId, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
        public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
        {
            if (FailSuspensions && patch.Status == "suspended")
            {
                SuspendFailures++;
                throw new IOException("Injected durable suspend failure.");
            }
            if (FailQueueWrites && patch.Payload is System.Text.Json.Nodes.JsonObject payload && payload.ContainsKey(TaskWireKeys.PayloadSteering))
            {
                QueueFailures++;
                throw new IOException("Injected durable queue write failure.");
            }
            return inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        }
    }
}
