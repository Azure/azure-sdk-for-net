// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public class ConcurrentTaskStartTests
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(10);

    [TestCase(false)]
    [TestCase(true)]
    public async Task ConcurrentFirstInputsHaveTheirOwnHandlesAndExecuteOnce(bool afterCreate)
    {
        await using var host = new StartHost(afterCreate);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b");
        host.Store.Release.TrySetResult();

        TaskRun<string>[] runs = await Task.WhenAll(first, second).WaitAsync(Timeout);
        Assert.That(runs.Select(run => run.InputId), Is.EqualTo(new[] { "a", "b" }));
        Assert.That(runs[0].IsQueued, Is.False);
        Assert.That(runs[1].IsQueued, Is.True);
        Assert.That(host.Store.Creates, Is.EqualTo(1));
        host.ReleaseHandler.TrySetResult();
        Assert.That(await Task.WhenAll(runs.Select(run => run.Completion)).WaitAsync(Timeout),
            Is.EqualTo(new[] { "a", "b" }));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a", "b" }));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ConcurrentNonSteerableStartConflictsWithoutBorrowingFirstHandle(bool afterCreate)
    {
        await using var host = new StartHost(afterCreate, steerable: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b");
        host.Store.Release.TrySetResult();
        TaskRun<string> run = await first.WaitAsync(Timeout);
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await second.WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.That(run.InputId, Is.EqualTo("a"));
        Assert.That(host.Store.Creates, Is.EqualTo(1));
    }

    [Test]
    public async Task ConcurrentDefinitionCannotTakeOwnership()
    {
        await using var host = new StartHost(afterCreate: false);
        host.Register("other", steerable: true);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> other = host.Start("b", name: "other");
        host.Store.Release.TrySetResult();
        _ = await first.WaitAsync(Timeout);
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await other.WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.That(error.Message, Does.Contain("belongs to registered task"));
    }

    [Test]
    public async Task IndependentTaskDoesNotWaitForBlockedStart()
    {
        await using var host = new StartHost(afterCreate: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        TaskRun<string> independent = await host.Start("b", taskId: "independent").WaitAsync(Timeout);
        Assert.That(independent.TaskId, Is.EqualTo("independent"));
        Assert.That(first.IsCompleted, Is.False);
    }

    [Test]
    public async Task CancelledWaiterDoesNotCancelOrReplaceOwner()
    {
        await using var host = new StartHost(afterCreate: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        using var cancellation = new CancellationTokenSource();
        Task<TaskRun<string>> second = host.Start("b", cancellationToken: cancellation.Token);
        cancellation.Cancel();
        Assert.That(async () => await second.WaitAsync(Timeout), Throws.InstanceOf<OperationCanceledException>());
        host.Store.Release.TrySetResult();
        TaskRun<string> run = await first.WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        Assert.That(await run.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task WaitingStartRechecksInputPreconditionBeforeSteering()
    {
        await using var host = new StartHost(afterCreate: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b", ifLastInputId: "not-a");
        host.Store.Release.TrySetResult();
        _ = await first.WaitAsync(Timeout);
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await second.WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.PreconditionFailed));
        Assert.That(error.ActualLastInputId, Is.EqualTo("a"));
        host.ReleaseHandler.TrySetResult();
        Assert.That(await (await first).Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task MatchingInputPreconditionAllowsWaitingInput()
    {
        await using var host = new StartHost(afterCreate: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b", ifLastInputId: "a");
        host.Store.Release.TrySetResult();
        TaskRun<string>[] runs = await Task.WhenAll(first, second).WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        Assert.That(await Task.WhenAll(runs.Select(run => run.Completion)).WaitAsync(Timeout),
            Is.EqualTo(new[] { "a", "b" }));
    }

    [Test]
    public async Task RecoveryDoesNotMistakeUnpublishedStartForAbandonedTask()
    {
        await using var host = new StartHost(afterCreate: true);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        TaskRecord record = (await host.Store.GetAsync("chain"))!;
        await host.Recover(record).WaitAsync(Timeout);
        Assert.That(host.Engine.IsActive("chain"), Is.False);
        host.Store.Release.TrySetResult();
        TaskRun<string> run = await first.WaitAsync(Timeout);
        Assert.That((await host.Store.GetAsync("chain"))!.Lease!.Generation, Is.Zero);
        host.ReleaseHandler.TrySetResult();
        Assert.That(await run.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task FailedInitialStartFailsWaitersWithoutAcceptingTheirInputs(bool afterCreate)
    {
        await using var host = new StartHost(afterCreate);
        var failure = new IOException("create failed");
        host.Store.CreateFailure = failure;
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b");
        host.Store.Release.TrySetResult();
        Assert.That(Assert.ThrowsAsync<IOException>(async () => await first.WaitAsync(Timeout)), Is.SameAs(failure));
        Assert.That(Assert.ThrowsAsync<IOException>(async () => await second.WaitAsync(Timeout)), Is.SameAs(failure));
        Assert.That(host.Executed, Is.Empty);

        host.Store.CreateFailure = null;
        TaskRun<string> retry = await host.Start("a").WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        Assert.That(await retry.Completion.WaitAsync(Timeout), Is.EqualTo("a"));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task OneShotStartsStillConvergeOnOneInput()
    {
        await using var host = new StartHost(afterCreate: true, multiTurn: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>> second = host.Start("b");
        host.Store.Release.TrySetResult();
        TaskRun<string>[] runs = await Task.WhenAll(first, second).WaitAsync(Timeout);
        Assert.That(runs.Select(run => run.InputId), Is.EqualTo(new[] { "a", "a" }));
        Assert.That(host.Store.Creates, Is.EqualTo(1));
        host.ReleaseHandler.TrySetResult();
        Assert.That(await Task.WhenAll(runs.Select(run => run.Completion)).WaitAsync(Timeout),
            Is.EqualTo(new[] { "a", "a" }));
        Assert.That(host.Executed, Is.EqualTo(new[] { "a" }));
    }

    [Test]
    public async Task SteeringCallbackCanSubmitAnotherInput()
    {
        await using var host = new StartHost(afterCreate: false);
        var started = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        Task<TaskRun<string>>? nested = null;
        host.OnExecute = context =>
        {
            if (context.Input == "a")
            {
                context.Cancellation.Register(() =>
                {
                    nested = host.Start("c");
                    Assert.That(nested.IsCompletedSuccessfully, Is.True,
                        "A callback must not be blocked by the admission of the input that signalled it.");
                });
                started.TrySetResult();
            }
        };
        host.Store.Release.TrySetResult();
        TaskRun<string> first = await host.Start("a").WaitAsync(Timeout);
        await started.Task.WaitAsync(Timeout);
        TaskRun<string> second = await host.Start("b").WaitAsync(Timeout);
        Assert.That(nested, Is.Not.Null);
        TaskRun<string> third = await nested!.WaitAsync(Timeout);
        host.ReleaseHandler.TrySetResult();
        Assert.That(await Task.WhenAll(first.Completion, second.Completion, third.Completion).WaitAsync(Timeout),
            Is.EqualTo(new[] { "a", "b", "c" }));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task ExternalDuplicateCreateIsADomainConflictAndDoesNotRecoverAnotherInput(bool completed)
    {
        await using var host = new StartHost(afterCreate: false);
        host.Store.Release.TrySetResult();
        host.Store.BeforeCreate = async request =>
        {
            request.LeaseOwner = "another-owner";
            request.LeaseInstanceId = "another-instance";
            TaskRecord created = await host.Store.Inner.CreateAsync(request);
            if (completed)
            {
                _ = await host.Store.Inner.PatchAsync(request.Id!,
                    new TaskPatchRequest { Status = TaskWireKeys.StatusCompleted }, created.Etag);
            }
        };
        ResilientTaskException? error = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await host.Start("a").WaitAsync(Timeout));
        Assert.That(error!.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.Conflict));
        Assert.That(error.CurrentStatus, Is.EqualTo(completed ? TaskRunStatus.Completed : TaskRunStatus.InProgress));
        Assert.That(host.Executed, Is.Empty);
    }

    [TestCase(TaskStoreException.CodeLeaseHeld, 409)]
    [TestCase(TaskStoreException.CodeInvalidRequest, 400)]
    [TestCase(TaskStoreException.CodeInternalError, 500)]
    public async Task OtherCreateFailuresAreNotRetriedOrReclassified(string code, int status)
    {
        await using var host = new StartHost(afterCreate: false);
        host.Store.Release.TrySetResult();
        var failure = new TaskStoreException(code, status, "storage failure", "chain");
        host.Store.CreateFailure = failure;
        Assert.That(Assert.ThrowsAsync<TaskStoreException>(
            async () => await host.Start("a").WaitAsync(Timeout)), Is.SameAs(failure));
        Assert.That(host.Store.Creates, Is.EqualTo(1));
        Assert.That(host.Executed, Is.Empty);
    }

    [TestCase(9)]
    [TestCase(10)]
    public async Task ConcurrentInitialWaitersPreserveDistinctInputsAndQueueCapacity(int waiters)
    {
        await using var host = new StartHost(afterCreate: false);
        Task<TaskRun<string>> first = host.Start("a");
        await host.Store.Entered.Task.WaitAsync(Timeout);
        Task<TaskRun<string>>[] pending = Enumerable.Range(0, waiters)
            .Select(index => host.Start($"b-{index}")).ToArray();
        host.Store.Release.TrySetResult();
        var accepted = new List<TaskRun<string>> { await first.WaitAsync(Timeout) };
        int rejected = 0;
        foreach (Task<TaskRun<string>> start in pending)
        {
            try
            {
                accepted.Add(await start.WaitAsync(Timeout));
            }
            catch (ResilientTaskException exception)
            {
                Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.QueueFull));
                rejected++;
            }
        }

        Assert.That(rejected, Is.EqualTo(waiters - 9));
        Assert.That(accepted.Select(run => run.InputId).Distinct().Count(), Is.EqualTo(10));
        Assert.That(host.Store.Creates, Is.EqualTo(1));
        host.ReleaseHandler.TrySetResult();
        Assert.That(await Task.WhenAll(accepted.Select(run => run.Completion)).WaitAsync(Timeout),
            Is.EqualTo(accepted.Select(run => run.InputId)));
        Assert.That(host.Executed, Is.EquivalentTo(accepted.Select(run => run.InputId)));
    }

    private sealed class StartHost : IAsyncDisposable
    {
        private readonly string _root = Path.Combine(
            Environment.GetEnvironmentVariable("AGENTSERVER_STATE_ROOT") ?? Path.GetTempPath(),
            "concurrent-start-" + Guid.NewGuid().ToString("N"));
        private readonly TaskRegistry _registry = new();
        private readonly AgentEventStreamRegistry _streams = new InMemoryEventStreamRegistry(new AgentEventStreamOptions());
        private readonly List<Task<TaskRun<string>>> _starts = new();

        public StartHost(bool afterCreate, bool steerable = true, bool multiTurn = true)
        {
            Directory.CreateDirectory(_root);
            Store = new GatedStore(new LocalTaskStore(_root), afterCreate);
            Engine = new TaskEngine(Store, _registry, "agent", "session", _streams);
            Register("chat", steerable, multiTurn);
        }

        public GatedStore Store { get; }
        public TaskEngine Engine { get; }
        public TaskCompletionSource ReleaseHandler { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public List<string> Executed { get; } = new();
        public Action<TaskContext<string>>? OnExecute { get; set; }

        public Task Recover(TaskRecord record) => Engine.RecoverAsync<string, string>(_registry.Get("chat"), record);

        public void Register(string name, bool steerable, bool multiTurn = true)
        {
            var options = new JsonSerializerOptions { TypeInfoResolver = new DefaultJsonTypeInfoResolver() };
            _registry.Add(new TaskRegistration(name, typeof(string), typeof(string),
                (Func<TaskContext<string>, CancellationToken, Task<string>>)(async (context, token) =>
                {
                    lock (Executed)
                    {
                        Executed.Add(context.Input);
                    }
                    OnExecute?.Invoke(context);
                    await ReleaseHandler.Task.WaitAsync(Timeout);
                    return context.Input;
                }),
                requiresServiceScope: false, multiTurn, () => steerable, options: null,
                inputTypeInfo: options.GetTypeInfo(typeof(string))));
        }

        public Task<TaskRun<string>> Start(
            string input, string taskId = "chain", string name = "chat",
            string? ifLastInputId = null, CancellationToken cancellationToken = default)
        {
            Task<TaskRun<string>> start = Engine.StartAsync<string, string>(name, input,
                new RunOptions { TaskId = taskId, InputId = input, IfLastInputId = ifLastInputId }, cancellationToken);
            lock (_starts)
            {
                _starts.Add(start);
            }
            return start;
        }

        public async ValueTask DisposeAsync()
        {
            Store.Release.TrySetResult();
            ReleaseHandler.TrySetResult();
            foreach (Task<TaskRun<string>> start in _starts)
            {
                try
                {
                    TaskRun<string> run = await start.WaitAsync(Timeout);
                    _ = await run.Completion.WaitAsync(Timeout);
                }
                catch (Exception exception) when (exception is TaskStoreException or ResilientTaskException or OperationCanceledException or IOException)
                {
                    TestContext.WriteLine($"Observed failed test operation during cleanup: {exception.GetType().Name}");
                }
            }
            Engine.Dispose();
            (_streams as IDisposable)?.Dispose();
            Directory.Delete(_root, recursive: true);
        }
    }

    private sealed class GatedStore(ITaskStore inner, bool afterCreate) : ITaskStore
    {
        private int _reads;
        private int _creates;
        public TaskCompletionSource Entered { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource Release { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public int Creates => Volatile.Read(ref _creates);
        public ITaskStore Inner => inner;
        public Exception? CreateFailure { get; set; }
        public Func<TaskCreateRequest, Task>? BeforeCreate { get; set; }

        public async Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
        {
            TaskRecord? snapshot = await inner.GetAsync(taskId, cancellationToken);
            if (!afterCreate && Interlocked.Increment(ref _reads) == 1)
            {
                Entered.TrySetResult();
                await Release.Task.WaitAsync(Timeout, cancellationToken);
            }
            return snapshot;
        }

        public async Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
        {
            int call = Interlocked.Increment(ref _creates);
            if (!afterCreate && CreateFailure is { } failure)
            {
                throw failure;
            }
            if (BeforeCreate is { } before)
            {
                await before(request);
            }
            TaskRecord record = await inner.CreateAsync(request, cancellationToken);
            if (afterCreate && call == 1)
            {
                Entered.TrySetResult();
                await Release.Task.WaitAsync(Timeout, cancellationToken);
            }
            if (afterCreate && CreateFailure is { } committedFailure)
            {
                throw committedFailure;
            }
            return record;
        }

        public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
            => inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);
        public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
            => inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);
        public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
            => inner.ListAsync(query, cancellationToken);
    }
}
