// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class TaskHandlerActivationTests
{
    [Test]
    public async Task ClassHandlerResolvesConstructorDependencies()
    {
        await using var host = new ActivationTestHost();
        host.Services.AddSingleton(new PrefixService("resolved:"));
        TaskDefinition<string, string> definition =
            host.Services.AddResilientTask<string, string, InjectedHandler>("injected");
        await host.BuildAsync();

        string result = await definition.RunAsync(
            "input",
            new RunOptions { TaskId = "injected-1" });

        Assert.That(result, Is.EqualTo("resolved:input"));
    }

    [Test]
    public async Task PreRegisteredHandlerInterfaceReplacesDefaultConcreteHandler()
    {
        await using var host = new ActivationTestHost();
        host.Services.AddKeyedScoped<
            IResilientTaskHandler<string, string>,
            ReplacementHandler>("replaceable");
        TaskDefinition<string, string> definition =
            host.Services.AddResilientTask<string, string, InjectedHandler>("replaceable");
        await host.BuildAsync();

        string result = await definition.RunAsync(
            "input",
            new RunOptions { TaskId = "replaceable-1" });

        Assert.That(result, Is.EqualTo("replacement:input"));
    }

    [Test]
    public async Task RetryCreatesAndDisposesFreshScopePerAttempt()
    {
        await using var host = new ActivationTestHost();
        var tracker = new AttemptTracker();
        host.Services.AddSingleton(tracker);
        host.Services.AddScoped<AttemptDependency>();
        TaskDefinition<string, string> definition =
            host.Services.AddResilientTask<string, string, RetryingHandler>(
                "retrying",
                configure: options => options.Retry = new TaskRetryPolicy
                {
                    MaxAttempts = 3,
                    Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero),
                });
        await host.BuildAsync();

        string result = await definition.RunAsync(
            "input",
            new RunOptions { TaskId = "retrying-1" });

        Assert.That(result, Is.EqualTo("ok"));
        Assert.That(tracker.AttemptIds, Has.Count.EqualTo(3));
        Assert.That(tracker.AttemptIds, Is.Unique);
        Assert.That(tracker.DisposedIds, Is.EquivalentTo(tracker.AttemptIds));
    }

    [Test]
    public async Task ExplicitCancellationDisposesAttemptScope()
    {
        await using var host = new ActivationTestHost();
        var tracker = new AttemptTracker();
        host.Services.AddSingleton(tracker);
        host.Services.AddScoped<AttemptDependency>();
        TaskDefinition<string, string> definition =
            host.Services.AddResilientTask<string, string, BlockingHandler>("blocking");
        await host.BuildAsync();

        TaskRun<string> run = await definition.StartAsync(
            "input",
            new RunOptions { TaskId = "blocking-1" });
        await tracker.Started.Task.WaitAsync(TimeSpan.FromSeconds(5));
        await run.RequestCancellationAsync();

        Assert.ThrowsAsync<OperationCanceledException>(
            async () => await run.Completion);
        Assert.That(tracker.DisposedIds, Is.EquivalentTo(tracker.AttemptIds));
    }

    [Test]
    public async Task RecoveredAttemptUsesFreshScope()
    {
        string sharedDir =
            Path.Combine(Path.GetTempPath(), "agentserver-di-recovery-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(sharedDir);
        var tracker = new AttemptTracker();

        try
        {
            await using (var host1 = new ActivationTestHost(sharedDir))
            {
                host1.Services.AddSingleton(tracker);
                host1.Services.AddScoped<AttemptDependency>();
                TaskDefinition<string, string> definition =
                    host1.Services.AddResilientTask<string, string, RecoveryHandler>("recover");
                await host1.BuildAsync();

                host1.Engine.SignalShutdown();
                TaskRun<string> run = await definition.StartAsync(
                    "input",
                    new RunOptions { TaskId = "recover-1" });
                await host1.WaitUntilInactiveAsync(run.TaskId);
                Assert.That(run.Completion.IsCompleted, Is.False);
            }

            await using (var host2 = new ActivationTestHost(sharedDir))
            {
                host2.Services.AddSingleton(tracker);
                host2.Services.AddScoped<AttemptDependency>();
                host2.Services.AddResilientTask<string, string, RecoveryHandler>("recover");
                await host2.BuildAsync();

                int dispatched = await host2.Engine.ScanAndRecoverAsync();
                Assert.That(dispatched, Is.EqualTo(1));
                await tracker.Recovered.Task.WaitAsync(TimeSpan.FromSeconds(5));
            }

            Assert.That(tracker.AttemptIds, Has.Count.EqualTo(2));
            Assert.That(tracker.AttemptIds, Is.Unique);
            Assert.That(tracker.DisposedIds, Is.EquivalentTo(tracker.AttemptIds));
        }
        finally
        {
            try
            {
                Directory.Delete(sharedDir, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }

    [Test]
    public async Task HandlerActivationFailureUsesRetryPolicy()
    {
        await using var host = new ActivationTestHost();
        TaskDefinition<string, string> definition =
            host.Services.AddResilientTask<string, string, MissingDependencyHandler>(
                "missing-dependency",
                configure: options => options.Retry = new TaskRetryPolicy
                {
                    MaxAttempts = 2,
                    Delay = DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero),
                });
        await host.BuildAsync();

        ResilientTaskException exception = Assert.ThrowsAsync<ResilientTaskException>(
            async () => await definition.RunAsync(
                "input",
                new RunOptions { TaskId = "missing-dependency-1" }));

        Assert.That(exception.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.ExhaustedRetries));
        Assert.That(exception.Failure!.Attempts, Is.EqualTo(2));
    }

    private sealed class PrefixService
    {
        public PrefixService(string value) => Value = value;

        public string Value { get; }
    }

    private sealed class InjectedHandler : IResilientTaskHandler<string, string>
    {
        private readonly PrefixService _prefix;

        public InjectedHandler(PrefixService prefix) => _prefix = prefix;

        public Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
            => Task.FromResult(_prefix.Value + context.Input);
    }

    private sealed class AttemptTracker
    {
        public List<Guid> AttemptIds { get; } = new();

        public List<Guid> DisposedIds { get; } = new();

        public TaskCompletionSource Started { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource Recovered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);
    }

    private sealed class ReplacementHandler : IResilientTaskHandler<string, string>
    {
        public Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
            => Task.FromResult("replacement:" + context.Input);
    }

    private sealed class AttemptDependency : IAsyncDisposable
    {
        private readonly AttemptTracker _tracker;

        public AttemptDependency(AttemptTracker tracker) => _tracker = tracker;

        public Guid Id { get; } = Guid.NewGuid();

        public ValueTask DisposeAsync()
        {
            _tracker.DisposedIds.Add(Id);
            return ValueTask.CompletedTask;
        }
    }

    private sealed class RetryingHandler : IResilientTaskHandler<string, string>
    {
        private readonly AttemptDependency _attempt;
        private readonly AttemptTracker _tracker;

        public RetryingHandler(AttemptDependency attempt, AttemptTracker tracker)
        {
            _attempt = attempt;
            _tracker = tracker;
        }

        public Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
        {
            _tracker.AttemptIds.Add(_attempt.Id);
            if (context.RetryAttempt < 2)
            {
                throw new InvalidOperationException("retry");
            }

            return Task.FromResult("ok");
        }
    }

    private sealed class BlockingHandler : IResilientTaskHandler<string, string>
    {
        private readonly AttemptDependency _attempt;
        private readonly AttemptTracker _tracker;
        private readonly TaskCompletionSource _never =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public BlockingHandler(AttemptDependency attempt, AttemptTracker tracker)
        {
            _attempt = attempt;
            _tracker = tracker;
        }

        public async Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
        {
            _tracker.AttemptIds.Add(_attempt.Id);
            _tracker.Started.TrySetResult();
            await _never.Task.WaitAsync(cancellationToken);
            return "unreachable";
        }
    }

    private sealed class RecoveryHandler : IResilientTaskHandler<string, string>
    {
        private readonly AttemptDependency _attempt;
        private readonly AttemptTracker _tracker;

        public RecoveryHandler(AttemptDependency attempt, AttemptTracker tracker)
        {
            _attempt = attempt;
            _tracker = tracker;
        }

        public async Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
        {
            _tracker.AttemptIds.Add(_attempt.Id);
            if (context.EntryMode == EntryMode.Fresh)
            {
                await context.ExitForRecoveryAsync(cancellationToken);
                return "deferred";
            }

            _tracker.Recovered.TrySetResult();
            return "recovered";
        }
    }

    private sealed class MissingDependencyHandler : IResilientTaskHandler<string, string>
    {
        public MissingDependencyHandler(UnregisteredDependency dependency)
        {
        }

        public Task<string> RunAsync(
            TaskContext<string> context,
            CancellationToken cancellationToken)
            => Task.FromResult(context.Input);
    }

    private sealed class UnregisteredDependency
    {
    }

    private sealed class ActivationTestHost : IAsyncDisposable
    {
        private readonly bool _ownsTempDir;
        private readonly string _tempDir;
        private ServiceProvider? _provider;

        public ActivationTestHost(string? sharedDir = null)
        {
            _ownsTempDir = sharedDir is null;
            _tempDir = sharedDir
                ?? Path.Combine(Path.GetTempPath(), "agentserver-di-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_tempDir);
            Services.AddSingleton<ITaskStore>(new LocalTaskStore(_tempDir));
        }

        public ServiceCollection Services { get; } = new();

        public TaskEngine Engine { get; private set; } = null!;

        public Task BuildAsync()
        {
            _provider = Services.BuildServiceProvider();
            Engine = _provider.GetRequiredService<TaskEngine>();
            return Task.CompletedTask;
        }

        public async Task WaitUntilInactiveAsync(string taskId)
        {
            var timeout = TimeSpan.FromSeconds(5);
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            while (stopwatch.Elapsed < timeout)
            {
                if (!Engine.IsActive(taskId))
                {
                    return;
                }

                await Task.Delay(20);
            }

            throw new TimeoutException($"Task '{taskId}' remained active after {timeout}.");
        }

        public async ValueTask DisposeAsync()
        {
            if (_provider is not null)
            {
                await _provider.DisposeAsync();
            }

            if (!_ownsTempDir)
            {
                return;
            }

            try
            {
                Directory.Delete(_tempDir, recursive: true);
            }
            catch (IOException)
            {
            }
        }
    }
}
