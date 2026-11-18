// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using Azure.AI.AgentServer.Core.Internal;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
[NonParallelizable]
public sealed class SnapshotTaskActivationTests
{
    private const string SnapshotEnabledVariable = "FOUNDRY_MEMORY_SNAPSHOT_ENABLED";
    private const string SessionIdVariable = "FOUNDRY_AGENT_SESSION_ID";

    private readonly Dictionary<string, string?> _originalEnvironment = new(StringComparer.Ordinal);
    private readonly List<string> _directories = new();

    [SetUp]
    public void SetUp()
    {
        RememberEnvironment(SnapshotEnabledVariable);
        RememberEnvironment(SessionIdVariable);
        Environment.SetEnvironmentVariable(SessionIdVariable, null);
        FoundryEnvironment.Reload();
    }

    [TearDown]
    public void TearDown()
    {
        foreach (KeyValuePair<string, string?> pair in _originalEnvironment)
        {
            Environment.SetEnvironmentVariable(pair.Key, pair.Value);
        }

        _originalEnvironment.Clear();
        FoundryEnvironment.Reload();
        foreach (string directory in _directories)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive: true);
            }
        }

        _directories.Clear();
    }

    [Test]
    public async Task SnapshotEnabledStartupDoesNotConstructTaskStore()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, " TrUe ");
        int storeFactoryCalls = 0;

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(_ =>
            {
                storeFactoryCalls++;
                throw new AssertionException("Capture startup constructed the task store.");
            });
            services.AddResilientTask<string, string>(
                "capture-safe",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostJsonAsync(client, "/_agent/before-snapshot", "{}");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(storeFactoryCalls, Is.Zero);
        });
    }

    [TestCase(" ")]
    [TestCase("yes")]
    [TestCase("1")]
    public void InvalidSnapshotFlagFailsStartup(string value)
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, value);

        InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () =>
            {
                await using WebApplication app = await StartAppAsync(services =>
                {
                    services.SetResilientTasksEnabled();
                    services.AddSingleton<ITaskStore>(new LocalTaskStore(CreateDirectory()));
                    services.AddResilientTask<string, string>(
                        "invalid-flag",
                        (context, cancellationToken) => Task.FromResult(context.Input));
                });
            })!;

        Assert.That(exception.Message, Does.Contain(SnapshotEnabledVariable));
    }

    [Test]
    public void EmptySnapshotFlagValueFailsValidation()
    {
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => MemorySnapshotSettings.Parse(string.Empty))!;

        Assert.That(exception.Message, Does.Contain(SnapshotEnabledVariable));
    }

    [Test]
    public async Task RestorePreparesTaskRuntimeBeforeCallbackAndRecoversAfterCallback()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new ObservingStore(new LocalTaskStore(CreateDirectory()));
        var handlerRelease = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (context, cancellationToken) =>
            {
                Assert.That(store.ListCalls, Is.Zero);
                TaskRun<string> run = await definition!.StartAsync(
                    context.SessionId,
                    cancellationToken: cancellationToken);
                Assert.That(run, Is.Not.Null);
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                definition = services.AddResilientTask<string, string>(
                    "restore-start",
                    async (context, cancellationToken) =>
                    {
                        await handlerRelease.Task.WaitAsync(cancellationToken);
                        return context.Input;
                    });
            },
            lifecycle);

        Assert.That(store.ListCalls, Is.Zero);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostJsonAsync(
            client,
            "/_agent/after-restore",
            """
            {
              "session_context": {
                "session_id": "restored-session",
                "restore_id": "restore-1"
              }
            }
            """);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(store.LastCreate?.SessionId, Is.EqualTo("restored-session"));
            Assert.That(store.ListCalls, Is.EqualTo(1));
        });

        handlerRelease.TrySetResult();
    }

    [Test]
    public async Task TaskAccessOutsideRestoreCallbackFailsUntilRuntimeIsReady()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        TaskDefinition<string, string>? definition = null;

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(new LocalTaskStore(CreateDirectory()));
            definition = services.AddResilientTask<string, string>(
                "not-ready",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
            async () => await definition!.StartAsync("payload"))!;

        Assert.That(exception.Message, Does.Contain("not ready"));
    }

    [TestCase(false)]
    [TestCase(true)]
    public async Task FailedCallbackPreservesAcceptedTaskAndRetryRecoversIt(
        bool multiTurn)
    {
        const string callbackVariable = "AGENTSERVER_SNAPSHOT_CALLBACK_VALUE";
        RememberEnvironment(callbackVariable);
        Environment.SetEnvironmentVariable(callbackVariable, "capture");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");

        var store = new ObservingStore(new LocalTaskStore(CreateDirectory()));
        var firstHandlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var firstHandlerCleanup =
            new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);
        var recoveredHandlerCompleted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        int callbackCount = 0;
        int handlerCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (context, cancellationToken) =>
            {
                int attempt = Interlocked.Increment(ref callbackCount);
                if (attempt == 1)
                {
                    await definition!.StartAsync(
                        "original-input",
                        new RunOptions { TaskId = "rollback-task" },
                        cancellationToken);
                    await firstHandlerStarted.Task.WaitAsync(cancellationToken);
                    throw new InvalidOperationException("fail after task acceptance");
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                Func<TaskContext<string>, CancellationToken, Task<string>> handler =
                    async (context, cancellationToken) =>
                    {
                        int invocation = Interlocked.Increment(ref handlerCount);
                        Assert.That(
                            Environment.GetEnvironmentVariable(callbackVariable),
                            Is.EqualTo("restored"));
                        Assert.That(context.Input, Is.EqualTo("original-input"));
                        if (invocation == 1)
                        {
                            firstHandlerStarted.TrySetResult();
                            try
                            {
                                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                            }
                            finally
                            {
                                firstHandlerCleanup.TrySetResult(
                                    Environment.GetEnvironmentVariable(callbackVariable));
                            }
                        }

                        recoveredHandlerCompleted.TrySetResult();
                        return context.Input;
                    };
                definition = multiTurn
                    ? services.AddResilientMultiTurnTask<string, string>(
                        "rollback",
                        handler)
                    : services.AddResilientTask<string, string>(
                        "rollback",
                        handler);
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreWithOverrideAsync(
            client,
            callbackVariable,
            "restored");

        TaskRecord? retained = await store.GetAsync("rollback-task");
        string? cleanupEnvironment =
            await firstHandlerCleanup.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(Environment.GetEnvironmentVariable(callbackVariable), Is.EqualTo("capture"));
            Assert.That(cleanupEnvironment, Is.EqualTo("restored"));
            Assert.That(retained, Is.Not.Null);
            Assert.That(retained!.Status, Is.EqualTo(TaskWireKeys.StatusInProgress));
        });

        using HttpResponseMessage retry = await PostRestoreWithOverrideAsync(
            client,
            callbackVariable,
            "restored");
        await recoveredHandlerCompleted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(retry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(callbackCount, Is.EqualTo(2));
            Assert.That(handlerCount, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task FailedCallbackPreservesQueuedSteeringInputForRetryRecovery()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new LocalTaskStore(CreateDirectory());
        var firstHandlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var queuedInputCompleted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var observedInputs = new List<string>();
        TaskDefinition<string, string>? definition = null;
        int handlerCount = 0;
        int callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                if (Interlocked.Increment(ref callbackCount) != 1)
                {
                    return;
                }

                await definition!.StartAsync(
                    "first",
                    new RunOptions { TaskId = "steering-rollback" },
                    cancellationToken);
                await firstHandlerStarted.Task.WaitAsync(cancellationToken);
                await definition.StartAsync(
                    "second",
                    new RunOptions { TaskId = "steering-rollback" },
                    cancellationToken);
                throw new InvalidOperationException("fail with queued steering");
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "steering-rollback",
                    async (context, cancellationToken) =>
                    {
                        lock (observedInputs)
                        {
                            observedInputs.Add(context.Input);
                        }

                        if (Interlocked.Increment(ref handlerCount) == 1)
                        {
                            firstHandlerStarted.TrySetResult();
                            try
                            {
                                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                            }
                            catch (OperationCanceledException)
                                when (!context.Shutdown.IsCancellationRequested)
                            {
                                await Task.Delay(
                                    Timeout.InfiniteTimeSpan,
                                    context.Shutdown);
                            }
                        }

                        if (context.Input == "second")
                        {
                            queuedInputCompleted.TrySetResult();
                        }

                        return context.Input;
                    },
                    steerable: true);
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreAsync(client);
        using HttpResponseMessage retry = await PostRestoreAsync(client);
        await queuedInputCompleted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        string[] inputs;
        lock (observedInputs)
        {
            inputs = observedInputs.ToArray();
        }

        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(retry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inputs, Is.EqualTo(new[] { "first", "first", "second" }));
        });
    }

    [Test]
    public async Task RollbackStagesPromotedSteeringInputWithoutDispatchingIt()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new LocalTaskStore(CreateDirectory());
        var firstHandlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var rollbackStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseFirstHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var secondFreshSeen =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var secondRecovered =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        int callbackCount = 0;
        int secondHandlerCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                if (Interlocked.Increment(ref callbackCount) != 1)
                {
                    return;
                }

                await definition!.StartAsync(
                    "first",
                    new RunOptions { TaskId = "rollback-promotion" },
                    cancellationToken);
                await firstHandlerStarted.Task.WaitAsync(cancellationToken);
                await definition.StartAsync(
                    "second",
                    new RunOptions { TaskId = "rollback-promotion" },
                    cancellationToken);
                throw new InvalidOperationException("trigger rollback promotion");
            },
        };

        WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "rollback-promotion",
                    async (context, cancellationToken) =>
                    {
                        if (context.Input == "first")
                        {
                            using CancellationTokenRegistration registration =
                                context.Shutdown.Register(
                                    () => rollbackStarted.TrySetResult());
                            firstHandlerStarted.TrySetResult();
                            await releaseFirstHandler.Task;
                            return context.Input;
                        }

                        Interlocked.Increment(ref secondHandlerCount);
                        if (context.EntryMode == EntryMode.Recovered)
                        {
                            secondRecovered.TrySetResult();
                            return context.Input;
                        }

                        secondFreshSeen.TrySetResult();
                        await Task.Delay(
                            Timeout.InfiniteTimeSpan,
                            cancellationToken);
                        return context.Input;
                    },
                    steerable: true);
            },
            lifecycle);

        try
        {
            using HttpClient client = app.GetTestClient();
            Task<HttpResponseMessage> restore = PostRestoreAsync(client);
            await rollbackStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
            releaseFirstHandler.TrySetResult();

            Task winner = await Task.WhenAny(
                restore,
                secondFreshSeen.Task).WaitAsync(TimeSpan.FromSeconds(5));
            HttpResponseMessage failed;
            if (ReferenceEquals(winner, secondFreshSeen.Task))
            {
                app.Services.GetRequiredService<TaskEngine>().SignalShutdown();
                failed = await restore.WaitAsync(TimeSpan.FromSeconds(5));
            }
            else
            {
                failed = await restore;
            }

            using (failed)
            {
                Assert.That(
                    failed.StatusCode,
                    Is.EqualTo(HttpStatusCode.InternalServerError));
            }

            if (!secondFreshSeen.Task.IsCompleted)
            {
                using HttpResponseMessage retry = await PostRestoreAsync(client);
                await secondRecovered.Task.WaitAsync(TimeSpan.FromSeconds(5));
                Assert.That(retry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }

            Assert.Multiple(() =>
            {
                Assert.That(secondFreshSeen.Task.IsCompleted, Is.False);
                Assert.That(secondHandlerCount, Is.EqualTo(1));
            });
        }
        finally
        {
            await app.DisposeAsync();
        }
    }

    [Test]
    public async Task RecoveryFailureRetryDoesNotRepeatCompletedCallback()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new FailFirstListStore(new LocalTaskStore(CreateDirectory()));
        int callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                Interlocked.Increment(ref callbackCount);
                return Task.CompletedTask;
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                services.AddResilientTask<string, string>(
                    "recovery-retry",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreAsync(client);
        using HttpResponseMessage retry = await PostRestoreAsync(client);

        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(retry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(callbackCount, Is.EqualTo(1));
            Assert.That(store.ListCalls, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task NewRestoreIdRechecksRecoveryAndRotatesIdleLeaseInstance()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new ObservingStore(new LocalTaskStore(CreateDirectory()));
        int callbackCount = 0;
        IServiceProvider? root = null;
        var callbackInstances = new List<string>();
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                Interlocked.Increment(ref callbackCount);
                callbackInstances.Add(
                    root!.GetRequiredService<TaskEngine>().InstanceId);
                return Task.CompletedTask;
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                services.AddResilientTask<string, string>(
                    "restore-identity",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);
        root = app.Services;

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreAsync(client, "restore-1");
        TaskEngine engine = app.Services.GetRequiredService<TaskEngine>();
        string firstInstance = engine.InstanceId;
        using HttpResponseMessage duplicate = await PostRestoreAsync(client, "restore-1");
        string duplicateInstance = engine.InstanceId;
        using HttpResponseMessage second = await PostRestoreAsync(client, "restore-2");

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(duplicate.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(callbackCount, Is.EqualTo(2));
            Assert.That(store.ListCalls, Is.EqualTo(2));
            Assert.That(duplicateInstance, Is.EqualTo(firstInstance));
            Assert.That(engine.InstanceId, Is.Not.EqualTo(firstInstance));
            Assert.That(callbackInstances[0], Is.EqualTo(firstInstance));
            Assert.That(callbackInstances[1], Is.Not.EqualTo(firstInstance));
        });
    }

    [Test]
    public async Task NewRestoreIdKeepsLeaseInstanceWhileTaskWorkIsActive()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new ObservingStore(new LocalTaskStore(CreateDirectory()));
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        int callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                Interlocked.Increment(ref callbackCount);
                return Task.CompletedTask;
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                definition = services.AddResilientTask<string, string>(
                    "active-restore-identity",
                    async (context, cancellationToken) =>
                    {
                        handlerStarted.TrySetResult();
                        await releaseHandler.Task.WaitAsync(cancellationToken);
                        return context.Input;
                    });
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreAsync(client, "restore-1");
        TaskRun<string> run = await definition!.StartAsync(
            "active",
            new RunOptions { TaskId = "active-restore-task" });
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
        TaskEngine engine = app.Services.GetRequiredService<TaskEngine>();
        string firstInstance = engine.InstanceId;

        using HttpResponseMessage second = await PostRestoreAsync(client, "restore-2");

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(callbackCount, Is.EqualTo(2));
            Assert.That(store.ListCalls, Is.EqualTo(2));
            Assert.That(engine.InstanceId, Is.EqualTo(firstInstance));
        });

        releaseHandler.TrySetResult();
        Assert.That(
            await run.Completion.WaitAsync(TimeSpan.FromSeconds(5)),
            Is.EqualTo("active"));
    }

    [Test]
    public async Task IncompatibleLiveBindingIsRejectedBeforeEnvironmentPublication()
    {
        const string AgentNameVariable = "FOUNDRY_AGENT_NAME";
        const string SessionGuidVariable = "FOUNDRY_AGENT_SESSION_GUID";
        const string OriginalAgent = "captured-agent";
        const string RestoredAgent = "different-agent";
        const string OriginalGuid = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        const string RestoredGuid = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        RememberEnvironment(AgentNameVariable);
        RememberEnvironment(SessionGuidVariable);
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        Environment.SetEnvironmentVariable(AgentNameVariable, OriginalAgent);
        Environment.SetEnvironmentVariable(SessionGuidVariable, OriginalGuid);
        FoundryEnvironment.Reload();

        var probe = new ProspectiveBindingProbe(restoreId: "restore-2");
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.AddSingleton<ISnapshotLifecycleParticipant>(probe);
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(new LocalTaskStore(CreateDirectory()));
            definition = services.AddResilientTask<string, string>(
                "binding-observer",
                async (context, cancellationToken) =>
                {
                    handlerStarted.TrySetResult();
                    await probe.InspectRequested.Task.WaitAsync(cancellationToken);
                    probe.ObservedEnvironment.TrySetResult(
                        (
                            Environment.GetEnvironmentVariable(AgentNameVariable),
                            Environment.GetEnvironmentVariable(SessionGuidVariable)));
                    await releaseHandler.Task.WaitAsync(cancellationToken);
                    return context.Input;
                });
        });

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreWithBindingAsync(
            client,
            "restore-1",
            OriginalAgent,
            OriginalGuid);
        TaskRun<string> run = await definition!.StartAsync(
            "active",
            new RunOptions { TaskId = "binding-observer-task" });
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        using HttpResponseMessage rejected = await PostRestoreWithBindingAsync(
            client,
            "restore-2",
            RestoredAgent,
            RestoredGuid);
        (string? AgentName, string? SessionGuid) observed =
            await probe.ObservedEnvironment.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(rejected.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(observed.AgentName, Is.EqualTo(OriginalAgent));
            Assert.That(observed.SessionGuid, Is.EqualTo(OriginalGuid));
            Assert.That(FoundryEnvironment.AgentName, Is.EqualTo(OriginalAgent));
            Assert.That(
                Environment.GetEnvironmentVariable(SessionGuidVariable),
                Is.EqualTo(OriginalGuid));
        });

        releaseHandler.TrySetResult();
        Assert.That(
            await run.Completion.WaitAsync(TimeSpan.FromSeconds(5)),
            Is.EqualTo("active"));
    }

    [Test]
    public async Task FailedOwnedStoreCloseIsRetriedBeforeRestoreReactivation()
    {
        const string RestoreVariable = "AGENTSERVER_CLOSE_RETRY_VALUE";
        RememberEnvironment(RestoreVariable);
        Environment.SetEnvironmentVariable(RestoreVariable, "captured");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");

        var firstStore = new DisposableStore(
            new LocalTaskStore(CreateDirectory()),
            failFirstDispose: true);
        var secondStore = new DisposableStore(
            new LocalTaskStore(CreateDirectory()),
            failFirstDispose: false);
        var stores = new Queue<ITaskStore>(new ITaskStore[]
        {
            firstStore,
            secondStore,
        });
        int callbackCount = 0;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
            {
                if (Interlocked.Increment(ref callbackCount) == 1)
                {
                    throw new InvalidOperationException("trigger owned-store cleanup");
                }

                return Task.CompletedTask;
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddSingleton(
                    new TaskStoreFactory(
                        () => (stores.Dequeue(), true)));
                services.SetResilientTasksEnabled();
                services.AddResilientTask<string, string>(
                    "close-retry",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreWithOverrideAsync(
            client,
            RestoreVariable,
            "restored");

        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(firstStore.DisposeAttempts, Is.EqualTo(1));
            Assert.That(
                Environment.GetEnvironmentVariable(RestoreVariable),
                Is.EqualTo("restored"));
        });

        using HttpResponseMessage retry = await PostRestoreWithOverrideAsync(
            client,
            RestoreVariable,
            "restored");

        Assert.Multiple(() =>
        {
            Assert.That(retry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(firstStore.DisposeAttempts, Is.EqualTo(2));
            Assert.That(callbackCount, Is.EqualTo(2));
            Assert.That(stores, Is.Empty);
        });
    }

    [Test]
    public async Task InjectedTaskStoreRemainsCallerOwnedAfterRollback()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new DisposableStore(
            new LocalTaskStore(CreateDirectory()),
            failFirstDispose: false);
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
                throw new InvalidOperationException("trigger rollback"),
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                services.AddResilientTask<string, string>(
                    "injected-ownership",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreAsync(client);

        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(store.DisposeAttempts, Is.Zero);
        });
    }

    [Test]
    public async Task DefaultLocalStoreUsesRestoredSessionAndConfiguredStateRoot()
    {
        const string StateRootVariable = "AGENTSERVER_STATE_ROOT";
        const string HostingVariable = "FOUNDRY_HOSTING_ENVIRONMENT";
        RememberEnvironment(StateRootVariable);
        RememberEnvironment(HostingVariable);
        string stateRoot = CreateDirectory();
        Environment.SetEnvironmentVariable(StateRootVariable, stateRoot);
        Environment.SetEnvironmentVariable(HostingVariable, null);
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        FoundryEnvironment.Reload();

        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "default-local",
                    new RunOptions { TaskId = "default-local-task" },
                    cancellationToken);
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "default-local",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);
        string recordPath = Path.Combine(
            stateRoot,
            "tasks",
            TaskEngineConstants.DefaultAgentName,
            "restored-session",
            "default-local-task.json");

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(File.Exists(recordPath), Is.True);
        });
    }

    [Test]
    public async Task HostShutdownInterruptsBlockedInitialRecovery()
    {
        const string restoreVariable = "AGENTSERVER_BLOCKED_RESTORE_VALUE";
        RememberEnvironment(restoreVariable);
        Environment.SetEnvironmentVariable(restoreVariable, "captured");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new BlockingListStore(new LocalTaskStore(CreateDirectory()));
        WebApplication app = await StartAppAsync(services =>
        {
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(store);
            services.AddResilientTask<string, string>(
                "blocked-recovery",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        try
        {
            using HttpClient client = app.GetTestClient();
            Task<HttpResponseMessage> restore = PostRestoreWithOverrideAsync(
                client,
                restoreVariable,
                "restored");
            await store.ListEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

            await app.StopAsync().WaitAsync(TimeSpan.FromSeconds(5));
            using HttpResponseMessage response =
                await restore.WaitAsync(TimeSpan.FromSeconds(5));
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(
                    Environment.GetEnvironmentVariable(restoreVariable),
                    Is.EqualTo("captured"));
            });
        }
        finally
        {
            await app.DisposeAsync();
        }
    }

    [Test]
    public async Task HostStopDuringCallbackWaitsForRollbackCleanupBeforeEnvironmentRestore()
    {
        const string RestoreVariable = "AGENTSERVER_PENDING_CALLBACK_VALUE";
        RememberEnvironment(RestoreVariable);
        Environment.SetEnvironmentVariable(RestoreVariable, "captured");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");

        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var runtimeStopSignaled =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var cleanupStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseCleanup =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var cleanupEnvironment =
            new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "pending",
                    new RunOptions { TaskId = "pending-callback-task" },
                    cancellationToken);
                await handlerStarted.Task.WaitAsync(cancellationToken);
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            },
        };

        WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "pending-callback",
                    async (context, cancellationToken) =>
                    {
                        using CancellationTokenRegistration registration =
                            context.Shutdown.Register(
                                () => runtimeStopSignaled.TrySetResult());
                        handlerStarted.TrySetResult();
                        try
                        {
                            await Task.Delay(
                                Timeout.InfiniteTimeSpan,
                                cancellationToken);
                        }
                        finally
                        {
                            cleanupStarted.TrySetResult();
                            cleanupEnvironment.TrySetResult(
                                Environment.GetEnvironmentVariable(
                                    RestoreVariable));
                            await releaseCleanup.Task;
                        }

                        return context.Input;
                    });
            },
            lifecycle);

        try
        {
            using HttpClient client = app.GetTestClient();
            Task<HttpResponseMessage> restore = PostRestoreWithOverrideAsync(
                client,
                RestoreVariable,
                "restored");
            await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

            SnapshotTaskRuntime runtime =
                app.Services.GetRequiredService<SnapshotTaskRuntime>();
            Task stop = runtime.StopAsync(CancellationToken.None);
            await runtimeStopSignaled.Task.WaitAsync(TimeSpan.FromSeconds(5));
            app.Services
                .GetRequiredService<IHostApplicationLifetime>()
                .StopApplication();

            bool cleanupBeganPromptly;
            try
            {
                await cleanupStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
                cleanupBeganPromptly = true;
            }
            catch (TimeoutException)
            {
                cleanupBeganPromptly = false;
                app.Services.GetRequiredService<TaskEngine>().SignalShutdown();
                await cleanupStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));
            }

            string? observedCleanupEnvironment =
                await cleanupEnvironment.Task.WaitAsync(TimeSpan.FromSeconds(5));

            Assert.Multiple(() =>
            {
                Assert.That(cleanupBeganPromptly, Is.True);
                Assert.That(stop.IsCompleted, Is.False);
                Assert.That(
                    Environment.GetEnvironmentVariable(RestoreVariable),
                    Is.EqualTo("restored"));
                Assert.That(
                    observedCleanupEnvironment,
                    Is.EqualTo("restored"));
            });

            releaseCleanup.TrySetResult();
            await stop.WaitAsync(TimeSpan.FromSeconds(5));
            using HttpResponseMessage response =
                await restore.WaitAsync(TimeSpan.FromSeconds(5));

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
                Assert.That(
                    Environment.GetEnvironmentVariable(RestoreVariable),
                    Is.EqualTo("captured"));
            });
        }
        finally
        {
            releaseCleanup.TrySetResult();
            await app.DisposeAsync();
        }
    }

    [Test]
    public async Task StopAfterPendingActivationSettlesStillDisposesCommittedRuntime()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(
                new LocalTaskStore(CreateDirectory()));
            services.AddResilientTask<string, string>(
                "pending-stop-commit",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        System.Reflection.FieldInfo activationPending =
            typeof(SnapshotTaskRuntime).GetField(
                "_activationPending",
                System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.NonPublic)
            ?? throw new InvalidOperationException(
                "Snapshot runtime activation state field was not found.");
        activationPending.SetValue(runtime, true);

        using var stopCts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await runtime.StopAsync(stopCts.Token);

        bool unavailable;
        try
        {
            runtime.RequireEngine();
            unavailable = false;
        }
        catch (InvalidOperationException)
        {
            unavailable = true;
        }

        if (!unavailable)
        {
            activationPending.SetValue(runtime, false);
            await runtime.StopAsync(CancellationToken.None);
        }

        Assert.That(unavailable, Is.True);
    }

    [TestCase(null)]
    [TestCase("false")]
    [TestCase("true")]
    public async Task ResponsesOnlyRuntimeDoesNotGrantUnscopedTaskOperations(
        string? snapshotValue)
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, snapshotValue);
        TaskDefinition<string, string>? definition = null;
        IServiceProvider? root = null;
        const string TaskId = "responses-owned";
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                using (root!.EnterResilientTaskScope("responses"))
                {
                    await definition!.StartAsync(
                        "restored",
                        new RunOptions { TaskId = TaskId },
                        cancellationToken);
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddResilientTasks();
                services.RegisterResilientTaskProtocol("responses", () => true);
                services.Configure<ResilientTaskOptions>(options => options.Enabled = true);
                services.AddSingleton<ITaskStore>(new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "responses-owned",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);
        root = app.Services;

        if (snapshotValue == "true")
        {
            using HttpClient client = app.GetTestClient();
            using HttpResponseMessage response = await PostRestoreAsync(client);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        else
        {
            using (root.EnterResilientTaskScope("responses"))
            {
                await definition!.StartAsync(
                    "cold",
                    new RunOptions { TaskId = TaskId });
            }
        }

        ResilientTaskException statusException =
            Assert.ThrowsAsync<ResilientTaskException>(
                async () => await definition!.GetStatusAsync(TaskId))!;
        ResilientTaskException activeException =
            Assert.ThrowsAsync<ResilientTaskException>(
                async () => await definition!.GetActiveRunAsync(TaskId, TaskId))!;
        ResilientTaskException deleteException =
            Assert.ThrowsAsync<ResilientTaskException>(
                async () => await definition!.DeleteAsync(TaskId))!;

        Assert.Multiple(() =>
        {
            Assert.That(statusException.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
            Assert.That(activeException.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
            Assert.That(deleteException.ErrorCode, Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
        });

        using (root.EnterResilientTaskScope("responses"))
        {
            await definition!.DeleteAsync(TaskId);
        }
    }

    [Test]
    public async Task ResponsesOnlySnapshotRuntimeAllowsCallbackButNotDisabledInvocationsScope()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        TaskDefinition<string, string>? definition = null;
        IServiceProvider? root = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.RunAsync("callback", cancellationToken: cancellationToken);
                using (root!.EnterResilientTaskScope("responses"))
                {
                    await definition.RunAsync("responses", cancellationToken: cancellationToken);
                }

                using (root.EnterResilientTaskScope("invocations", enabled: false))
                {
                    ResilientTaskException exception =
                        Assert.ThrowsAsync<ResilientTaskException>(
                            async () => await definition.RunAsync(
                                "invocations",
                                cancellationToken: cancellationToken))!;
                    Assert.That(
                        exception.ErrorCode,
                        Is.EqualTo(ResilientTaskErrorCode.NotEnabled));
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddResilientTasks();
                services.RegisterResilientTaskProtocol("responses", () => true);
                services.Configure<ResilientTaskOptions>(options => options.Enabled = true);
                services.AddSingleton<ITaskStore>(new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "protocol-matrix",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);
        root = app.Services;

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    private async Task<WebApplication> StartAppAsync(
        Action<IServiceCollection> configureServices,
        IAgentSnapshotLifecycle? lifecycle = null)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        configureServices(builder.Services);
        if (lifecycle is not null)
        {
            builder.Services.AddSingleton(lifecycle);
        }

        WebApplication app = builder.Build();
        app.UseAgentServerCore();
        await app.StartAsync();
        return app;
    }

    private static Task<HttpResponseMessage> PostJsonAsync(
        HttpClient client,
        string path,
        string body) =>
        client.PostAsync(path, new StringContent(body, Encoding.UTF8, "application/json"));

    private static Task<HttpResponseMessage> PostRestoreAsync(
        HttpClient client,
        string restoreId = "restore-1") =>
        PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "restored-session",
                "restore_id": "{{restoreId}}"
              }
            }
            """);

    private static Task<HttpResponseMessage> PostRestoreWithOverrideAsync(
        HttpClient client,
        string variable,
        string value) =>
        PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "restored-session",
                "restore_id": "restore-1",
                "session_env_overrides": {
                  "{{variable}}": "{{value}}"
                }
              }
            }
            """);

    private static Task<HttpResponseMessage> PostRestoreWithBindingAsync(
        HttpClient client,
        string restoreId,
        string agentName,
        string sessionGuid) =>
        PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "restored-session",
                "restore_id": "{{restoreId}}",
                "session_env_overrides": {
                  "FOUNDRY_AGENT_NAME": "{{agentName}}",
                  "FOUNDRY_AGENT_SESSION_GUID": "{{sessionGuid}}"
                }
              }
            }
            """);

    private string CreateDirectory()
    {
        string directory = Path.Combine(
            Path.GetTempPath(),
            "agentserver-snapshot-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        _directories.Add(directory);
        return directory;
    }

    private void RememberEnvironment(string name)
    {
        _originalEnvironment[name] = Environment.GetEnvironmentVariable(name);
    }

    private sealed class TestSnapshotLifecycle : IAgentSnapshotLifecycle
    {
        public Func<AgentRestoreContext, CancellationToken, Task>? AfterRestore { get; init; }

        public Task BeforeSnapshotAsync(CancellationToken cancellationToken = default) =>
            Task.CompletedTask;

        public Task AfterRestoreAsync(
            AgentRestoreContext context,
            CancellationToken cancellationToken = default) =>
            AfterRestore?.Invoke(context, cancellationToken) ?? Task.CompletedTask;
    }

    private sealed class ObservingStore(ITaskStore inner) : ITaskStore
    {
        private int _listCalls;

        public int ListCalls => Volatile.Read(ref _listCalls);

        public TaskCreateRequest? LastCreate { get; private set; }

        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default)
        {
            LastCreate = request;
            return inner.CreateAsync(request, cancellationToken);
        }

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default) =>
            inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default) =>
            inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default) =>
            inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
        {
            Interlocked.Increment(ref _listCalls);
            return inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class FailFirstListStore(ITaskStore inner) : ITaskStore
    {
        private int _listCalls;

        public int ListCalls => Volatile.Read(ref _listCalls);

        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default) =>
            inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default) =>
            inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default) =>
            inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default) =>
            inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
        {
            if (Interlocked.Increment(ref _listCalls) == 1)
            {
                throw new IOException("Injected initial recovery failure.");
            }

            return inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class BlockingListStore(ITaskStore inner) : ITaskStore
    {
        public TaskCompletionSource ListEntered { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default) =>
            inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default) =>
            inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default) =>
            inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default) =>
            inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public async Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
        {
            ListEntered.TrySetResult();
            await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
            return await inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class ProspectiveBindingProbe(
        string restoreId) : ISnapshotLifecycleParticipant
    {
        public TaskCompletionSource InspectRequested { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource<(string? AgentName, string? SessionGuid)>
            ObservedEnvironment
        { get; } =
                new(TaskCreationOptions.RunContinuationsAsynchronously);

        public async Task ValidateAfterRestoreAsync(
            AgentRestoreContext context,
            IReadOnlyDictionary<string, string?> prospectiveEnvironment,
            CancellationToken cancellationToken)
        {
            if (context.RestoreId == restoreId)
            {
                InspectRequested.TrySetResult();
                await ObservedEnvironment.Task.WaitAsync(cancellationToken);
            }
        }

        public async Task PrepareAfterRestoreAsync(
            AgentRestoreContext context,
            CancellationToken cancellationToken)
        {
            if (context.RestoreId == restoreId && !InspectRequested.Task.IsCompleted)
            {
                InspectRequested.TrySetResult();
                await ObservedEnvironment.Task.WaitAsync(cancellationToken);
            }
        }

        public IDisposable EnterAfterRestoreCallbackScope() =>
            NoOpDisposable.Instance;

        public Task CompleteAfterRestoreAsync(
            AgentRestoreContext context,
            CancellationToken cancellationToken) =>
            Task.CompletedTask;

        public Task RollbackAfterRestoreAsync(
            AgentRestoreContext context,
            CancellationToken cancellationToken) =>
            Task.CompletedTask;
    }

    private sealed class DisposableStore(
        ITaskStore inner,
        bool failFirstDispose) : ITaskStore, IAsyncDisposable
    {
        private int _disposeAttempts;

        public int DisposeAttempts => Volatile.Read(ref _disposeAttempts);

        public Task<TaskRecord> CreateAsync(
            TaskCreateRequest request,
            CancellationToken cancellationToken = default) =>
            inner.CreateAsync(request, cancellationToken);

        public Task<TaskRecord?> GetAsync(
            string taskId,
            CancellationToken cancellationToken = default) =>
            inner.GetAsync(taskId, cancellationToken);

        public Task<TaskRecord> PatchAsync(
            string taskId,
            TaskPatchRequest patch,
            string? ifMatch,
            CancellationToken cancellationToken = default) =>
            inner.PatchAsync(taskId, patch, ifMatch, cancellationToken);

        public Task DeleteAsync(
            string taskId,
            string? ifMatch = null,
            bool force = false,
            bool cascade = false,
            CancellationToken cancellationToken = default) =>
            inner.DeleteAsync(taskId, ifMatch, force, cascade, cancellationToken);

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default) =>
            inner.ListAsync(query, cancellationToken);

        public ValueTask DisposeAsync()
        {
            if (Interlocked.Increment(ref _disposeAttempts) == 1
                && failFirstDispose)
            {
                throw new IOException("Injected owned-store close failure.");
            }

            return ValueTask.CompletedTask;
        }
    }

    private sealed class NoOpDisposable : IDisposable
    {
        public static NoOpDisposable Instance { get; } = new();

        public void Dispose()
        {
        }
    }
}
