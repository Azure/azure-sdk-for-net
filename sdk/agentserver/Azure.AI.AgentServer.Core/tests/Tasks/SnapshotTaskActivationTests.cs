// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.ServerSentEvents;
using System.Text;
using Azure.AI.AgentServer.Core.Internal;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Engine;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

    [Test]
    public async Task SnapshotRuntimeIsAsyncDisposableWithoutHostStop()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var handlerCleaned =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "dispose",
                    new RunOptions { TaskId = "dispose-runtime-task" },
                    cancellationToken);
                await handlerStarted.Task.WaitAsync(cancellationToken);
            },
        };

        WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "dispose-runtime",
                    async (context, cancellationToken) =>
                    {
                        handlerStarted.TrySetResult();
                        try
                        {
                            await Task.Delay(
                                Timeout.InfiniteTimeSpan,
                                cancellationToken);
                        }
                        finally
                        {
                            handlerCleaned.TrySetResult();
                        }

                        return context.Input;
                    });
            },
            lifecycle);

        try
        {
            using HttpClient client = app.GetTestClient();
            using HttpResponseMessage response = await PostRestoreAsync(client);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            SnapshotTaskRuntime runtime =
                app.Services.GetRequiredService<SnapshotTaskRuntime>();
            Assert.That(runtime, Is.InstanceOf<IAsyncDisposable>());
            Task dispose = runtime.DisposeAsync().AsTask();
            bool disposedPromptly;
            try
            {
                await dispose.WaitAsync(TimeSpan.FromSeconds(2));
                disposedPromptly = true;
            }
            catch (TimeoutException)
            {
                disposedPromptly = false;
                app.Services.GetRequiredService<TaskEngine>().SignalShutdown();
                await dispose.WaitAsync(TimeSpan.FromSeconds(5));
            }

            await handlerCleaned.Task.WaitAsync(TimeSpan.FromSeconds(5));
            Assert.That(disposedPromptly, Is.True);
        }
        finally
        {
            await app.DisposeAsync();
        }
    }

    [Test]
    public async Task StopRetriesRetainedOwnedStoreCleanupWithoutAnotherRestore()
    {
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
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
                throw new InvalidOperationException("retain failed cleanup"),
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddSingleton(
                    new TaskStoreFactory(
                        () => (stores.Dequeue(), true)));
                services.SetResilientTasksEnabled();
                services.AddResilientTask<string, string>(
                    "stop-cleanup-retry",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage failed = await PostRestoreAsync(client);
        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();

        bool stopped;
        using (var stopCts = new CancellationTokenSource(TimeSpan.FromSeconds(2)))
        {
            try
            {
                await runtime.StopAsync(stopCts.Token);
                stopped = true;
            }
            catch (OperationCanceledException)
            {
                stopped = false;
            }
        }

        if (!stopped)
        {
            using HttpResponseMessage cleanupRetry = await PostRestoreAsync(client);
            Assert.That(
                cleanupRetry.StatusCode,
                Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        Assert.Multiple(() =>
        {
            Assert.That(failed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(stopped, Is.True);
            Assert.That(firstStore.DisposeAttempts, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task NewRestorePausesRecoveryScansUntilCallbackCompletes()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new SignalingListStore(new LocalTaskStore(CreateDirectory()));
        var callbackEntered =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseCallback =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (context, cancellationToken) =>
            {
                if (context.RestoreId == "restore-2")
                {
                    callbackEntered.TrySetResult();
                    await releaseCallback.Task.WaitAsync(cancellationToken);
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                services.AddResilientTask<string, string>(
                    "scan-pause",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreAsync(client, "restore-1");
        Task<HttpResponseMessage> second = PostRestoreAsync(client, "restore-2");
        await callbackEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        TaskDurabilityService durability = GetDurability(runtime);
        Task<int> manualScan = durability.ScanOnceAsync();
        bool scanEnteredDuringCallback;
        try
        {
            await store.SecondListEntered.Task.WaitAsync(TimeSpan.FromSeconds(1));
            scanEnteredDuringCallback = true;
        }
        catch (TimeoutException)
        {
            scanEnteredDuringCallback = false;
        }

        releaseCallback.TrySetResult();
        using HttpResponseMessage restored =
            await second.WaitAsync(TimeSpan.FromSeconds(5));
        await manualScan.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(restored.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(scanEnteredDuringCallback, Is.False);
        });
    }

    [Test]
    public async Task ResponsesWorkerRetainsResolvedProtocolAfterCallbackScopeEnds()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var allowNested =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var nestedOutcome =
            new TaskCompletionSource<Exception?>(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? outer = null;
        TaskDefinition<string, string>? nested = null;
        IServiceProvider? root = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await outer!.StartAsync(
                    "outer",
                    new RunOptions { TaskId = "responses-worker" },
                    cancellationToken);
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddResilientTasks();
                services.RegisterResilientTaskProtocol("responses", () => true);
                services.Configure<ResilientTaskOptions>(options => options.Enabled = true);
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                nested = services.AddResilientTask<string, string>(
                    "nested-responses",
                    (context, cancellationToken) => Task.FromResult(context.Input));
                outer = services.AddResilientTask<string, string>(
                    "outer-responses",
                    async (context, cancellationToken) =>
                    {
                        await allowNested.Task.WaitAsync(cancellationToken);
                        try
                        {
                            await nested.RunAsync(
                                "nested",
                                cancellationToken: cancellationToken);
                            nestedOutcome.TrySetResult(null);
                        }
                        catch (Exception exception)
                        {
                            nestedOutcome.TrySetResult(exception);
                        }

                        return context.Input;
                    });
            },
            lifecycle);
        root = app.Services;

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);
        allowNested.TrySetResult();
        Exception? outcome =
            await nestedOutcome.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(outcome, Is.Null);
        });

        using (root.EnterResilientTaskScope("responses"))
        {
            await outer!.DeleteAsync("responses-worker");
        }
    }

    [Test]
    public async Task NewRestoreClosesExternalAdmissionUntilRecoveryCompletes()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var callbackEntered =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseCallback =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (context, cancellationToken) =>
            {
                if (context.RestoreId == "restore-2")
                {
                    callbackEntered.TrySetResult();
                    await releaseCallback.Task.WaitAsync(cancellationToken);
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "external-admission",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreAsync(client, "restore-1");
        Task<HttpResponseMessage> second = PostRestoreAsync(client, "restore-2");
        await callbackEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

        InvalidOperationException? rejected =
            Assert.ThrowsAsync<InvalidOperationException>(
                async () => await definition!.StartAsync("outside"))!;

        releaseCallback.TrySetResult();
        using HttpResponseMessage restored =
            await second.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(restored.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(rejected.Message, Does.Contain("not ready"));
        });
    }

    [TestCase(null)]
    [TestCase("false")]
    public async Task ColdModeFailureKeepsRestoredEnvironmentForAcceptedWorker(
        string? snapshotValue)
    {
        const string RestoreVariable = "AGENTSERVER_COLD_FAILURE_VALUE";
        RememberEnvironment(RestoreVariable);
        Environment.SetEnvironmentVariable(RestoreVariable, "captured");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, snapshotValue);
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var handlerFinallyEnvironment =
            new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "cold",
                    new RunOptions { TaskId = "cold-failure-task" },
                    cancellationToken);
                await handlerStarted.Task.WaitAsync(cancellationToken);
                throw new InvalidOperationException("cold callback failure");
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "cold-failure",
                    async (context, cancellationToken) =>
                    {
                        handlerStarted.TrySetResult();
                        try
                        {
                            await releaseHandler.Task;
                        }
                        finally
                        {
                            handlerFinallyEnvironment.TrySetResult(
                                Environment.GetEnvironmentVariable(RestoreVariable));
                        }

                        return context.Input;
                    });
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreWithOverrideAsync(
            client,
            RestoreVariable,
            "restored");
        string? environmentWhileWorkerRuns =
            Environment.GetEnvironmentVariable(RestoreVariable);
        releaseHandler.TrySetResult();
        string? environmentInFinally =
            await handlerFinallyEnvironment.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(environmentWhileWorkerRuns, Is.EqualTo("restored"));
            Assert.That(environmentInFinally, Is.EqualTo("restored"));
        });
    }

    [Test]
    public async Task LocalInjectedStoreIgnoresProjectEndpointChanges()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.SetResilientTasksEnabled();
            services.AddSingleton<ITaskStore>(
                new LocalTaskStore(CreateDirectory()));
            services.AddResilientTask<string, string>(
                "local-endpoint",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreWithOverrideAsync(
            client,
            "FOUNDRY_PROJECT_ENDPOINT",
            "https://first.example.invalid/project");
        using HttpResponseMessage second = await PostRestoreWithOverrideAsync(
            client,
            "FOUNDRY_PROJECT_ENDPOINT",
            "https://second.example.invalid/project",
            restoreId: "restore-2");

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        });
    }

    [Test]
    public async Task OwnedHostedBindingNormalizesEndpointAndRejectsActualChange()
    {
        const string HostingVariable = "FOUNDRY_HOSTING_ENVIRONMENT";
        RememberEnvironment(HostingVariable);
        Environment.SetEnvironmentVariable(HostingVariable, "hosted");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        FoundryEnvironment.Reload();

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.AddSingleton(
                new TaskStoreFactory(
                    () => (
                        new LocalTaskStore(CreateDirectory()),
                        true)));
            services.SetResilientTasksEnabled();
            services.AddResilientTask<string, string>(
                "hosted-endpoint",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreWithOverrideAsync(
            client,
            "FOUNDRY_PROJECT_ENDPOINT",
            "https://example.invalid/project");
        using HttpResponseMessage equivalent = await PostRestoreWithOverrideAsync(
            client,
            "FOUNDRY_PROJECT_ENDPOINT",
            "https://example.invalid/project/",
            restoreId: "restore-2");
        using HttpResponseMessage changed = await PostRestoreWithOverrideAsync(
            client,
            "FOUNDRY_PROJECT_ENDPOINT",
            "https://other.invalid/project",
            restoreId: "restore-3");

        Assert.Multiple(() =>
        {
            Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(equivalent.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(changed.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        });
    }

    [Test]
    public async Task ImplicitFileReplayDirectoryUsesRestoredStateRoot()
    {
        const string StateRootVariable = "AGENTSERVER_STATE_ROOT";
        RememberEnvironment(StateRootVariable);
        string capturedRoot = CreateDirectory();
        string restoredRoot = CreateDirectory();
        Environment.SetEnvironmentVariable(StateRootVariable, capturedRoot);
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var emitted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "stream",
                    new RunOptions { TaskId = "restored-stream-task" },
                    cancellationToken);
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddAgentEventStreams(
                    options => options.UseFileBackedReplay());
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "restored-stream",
                    async (context, cancellationToken) =>
                    {
                        await context.Stream.EmitAsync(
                            new SseItem<string>("progress")
                            {
                                EventId = "1",
                            },
                            cancellationToken);
                        emitted.TrySetResult();
                        return context.Input;
                    });
            },
            lifecycle);

        _ = app.Services.GetRequiredService<AgentEventStreamRegistry>();
        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreWithOverrideAsync(
            client,
            StateRootVariable,
            restoredRoot.Replace("\\", "\\\\", StringComparison.Ordinal));
        await emitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        string capturedStreams = Path.Combine(capturedRoot, "streams");
        string restoredStreams = Path.Combine(restoredRoot, "streams");
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                Directory.Exists(capturedStreams)
                    && Directory.EnumerateFiles(capturedStreams, "*.jsonl").Any(),
                Is.False);
            Assert.That(
                Directory.Exists(restoredStreams)
                    && Directory.EnumerateFiles(restoredStreams, "*.jsonl").Any(),
                Is.True);
        });
    }

    [Test]
    public async Task ExplicitFileReplayDirectoryRemainsFixedAfterRestore()
    {
        const string StateRootVariable = "AGENTSERVER_STATE_ROOT";
        RememberEnvironment(StateRootVariable);
        string capturedRoot = CreateDirectory();
        string restoredRoot = CreateDirectory();
        string explicitStreams = CreateDirectory();
        Environment.SetEnvironmentVariable(StateRootVariable, capturedRoot);
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var emitted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "stream",
                    new RunOptions { TaskId = "explicit-stream-task" },
                    cancellationToken);
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.AddAgentEventStreams(
                    options => options.UseFileBackedReplay(explicitStreams));
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientMultiTurnTask<string, string>(
                    "explicit-stream",
                    async (context, cancellationToken) =>
                    {
                        await context.Stream.EmitAsync(
                            new SseItem<string>("progress")
                            {
                                EventId = "1",
                            },
                            cancellationToken);
                        emitted.TrySetResult();
                        return context.Input;
                    });
            },
            lifecycle);

        _ = app.Services.GetRequiredService<AgentEventStreamRegistry>();
        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreWithOverrideAsync(
            client,
            StateRootVariable,
            restoredRoot.Replace("\\", "\\\\", StringComparison.Ordinal));
        await emitted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(
                Directory.EnumerateFiles(explicitStreams, "*.jsonl").Any(),
                Is.True);
            Assert.That(
                Directory.Exists(Path.Combine(restoredRoot, "streams")),
                Is.False);
        });
    }

    [Test]
    public async Task NonCooperativeRollbackIsBoundedAndRetriedAfterWorkerStops()
    {
        const string RestoreVariable = "AGENTSERVER_BOUNDED_ROLLBACK_VALUE";
        RememberEnvironment(RestoreVariable);
        Environment.SetEnvironmentVariable(RestoreVariable, "captured");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        TaskDefinition<string, string>? definition = null;
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
                    "bounded",
                    new RunOptions { TaskId = "bounded-rollback-task" },
                    cancellationToken);
                await handlerStarted.Task.WaitAsync(cancellationToken);
                throw new InvalidOperationException("bounded rollback");
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.Configure<AgentHostOptions>(
                    options => options.ShutdownTimeout = TimeSpan.FromMilliseconds(200));
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "bounded-rollback",
                    async (context, cancellationToken) =>
                    {
                        handlerStarted.TrySetResult();
                        await releaseHandler.Task;
                        return context.Input;
                    });
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        Task<HttpResponseMessage> firstRequest = PostRestoreWithOverrideAsync(
            client,
            RestoreVariable,
            "restored");
        await handlerStarted.Task.WaitAsync(TimeSpan.FromSeconds(5));

        HttpResponseMessage? first = null;
        bool firstBounded;
        try
        {
            first = await firstRequest.WaitAsync(TimeSpan.FromSeconds(1));
            firstBounded = true;
        }
        catch (TimeoutException)
        {
            firstBounded = false;
        }

        if (!firstBounded)
        {
            releaseHandler.TrySetResult();
            first = await firstRequest.WaitAsync(TimeSpan.FromSeconds(5));
        }

        using (first)
        {
            Assert.That(firstBounded, Is.True);
            Assert.That(first!.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        using HttpResponseMessage pendingRetry =
            await PostRestoreWithOverrideAsync(
                client,
                RestoreVariable,
                "restored").WaitAsync(TimeSpan.FromSeconds(1));
        Assert.That(
            pendingRetry.StatusCode,
            Is.EqualTo(HttpStatusCode.InternalServerError));
        Assert.That(
            Environment.GetEnvironmentVariable(RestoreVariable),
            Is.EqualTo("restored"));

        releaseHandler.TrySetResult();
        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        using (var cleanupCts =
            new CancellationTokenSource(TimeSpan.FromSeconds(5)))
        {
            await runtime.StopAsync(cleanupCts.Token);
        }

        using HttpResponseMessage successfulRetry =
            await PostRestoreWithOverrideAsync(
                client,
                RestoreVariable,
                "restored").WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Multiple(() =>
        {
            Assert.That(successfulRetry.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(callbackCount, Is.EqualTo(2));
        });
    }

    [Test]
    public async Task DisposeTimeoutDoesNotPreventOtherServicesFromDisposing()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var handlerStarted =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseHandler =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var handlerStopped =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var disposeProbe = new DisposeProbe();
        var loggerProvider = new RecordingLoggerProvider();
        TaskDefinition<string, string>? definition = null;
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (_, cancellationToken) =>
            {
                await definition!.StartAsync(
                    "dispose-timeout",
                    new RunOptions { TaskId = "dispose-timeout-task" },
                    cancellationToken);
                await handlerStarted.Task.WaitAsync(cancellationToken);
            },
        };

        WebApplication app = await StartAppAsync(
            services =>
            {
                services.Configure<AgentHostOptions>(
                    options => options.ShutdownTimeout = TimeSpan.FromMilliseconds(200));
                services.AddLogging(
                    logging => logging.AddProvider(loggerProvider));
                services.AddSingleton(disposeProbe);
                services.AddSingleton<IHostedService>(
                    provider => provider.GetRequiredService<DisposeProbe>());
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                definition = services.AddResilientTask<string, string>(
                    "dispose-timeout",
                    async (context, cancellationToken) =>
                    {
                        handlerStarted.TrySetResult();
                        try
                        {
                            await releaseHandler.Task;
                        }
                        finally
                        {
                            handlerStopped.TrySetResult();
                        }

                        return context.Input;
                    });
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.DisposeAsync().AsTask().WaitAsync(TimeSpan.FromSeconds(2));
        Assert.Multiple(() =>
        {
            Assert.That(disposeProbe.Disposed.Task.IsCompleted, Is.True);
            Assert.That(
                loggerProvider.Messages.Count(
                    message => message.Contains(
                        "disposal timed out",
                        StringComparison.OrdinalIgnoreCase)),
                Is.EqualTo(1));
        });

        releaseHandler.TrySetResult();
        await handlerStopped.Task.WaitAsync(TimeSpan.FromSeconds(5));
    }

    [Test]
    public async Task DisposedRuntimeRejectsLaterActivationWithoutCreatingStore()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        int storeCreations = 0;

        await using WebApplication app = await StartAppAsync(services =>
        {
            services.AddSingleton(
                new TaskStoreFactory(
                    () =>
                    {
                        Interlocked.Increment(ref storeCreations);
                        return (
                            (ITaskStore)new LocalTaskStore(CreateDirectory()),
                            true);
                    }));
            services.SetResilientTasksEnabled();
            services.AddResilientTask<string, string>(
                "disposed-activation",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        await Task.WhenAll(
            runtime.DisposeAsync().AsTask(),
            runtime.DisposeAsync().AsTask(),
            runtime.DisposeAsync().AsTask());

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreAsync(client);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(storeCreations, Is.Zero);
        });
    }

    [Test]
    public async Task DisposeLogsOwnedStoreFailureAndAllowsOtherServicesToDispose()
    {
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new DisposableStore(
            new LocalTaskStore(CreateDirectory()),
            failFirstDispose: true);
        var disposeProbe = new DisposeProbe();
        var loggerProvider = new RecordingLoggerProvider();

        WebApplication app = await StartAppAsync(services =>
        {
            services.AddLogging(
                logging => logging.AddProvider(loggerProvider));
            services.AddSingleton(disposeProbe);
            services.AddSingleton<IHostedService>(
                provider => provider.GetRequiredService<DisposeProbe>());
            services.AddSingleton(
                new TaskStoreFactory(() => (store, true)));
            services.SetResilientTasksEnabled();
            services.AddResilientTask<string, string>(
                "dispose-failure",
                (context, cancellationToken) => Task.FromResult(context.Input));
        });

        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        try
        {
            using HttpClient client = app.GetTestClient();
            using HttpResponseMessage response = await PostRestoreAsync(client);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.DoesNotThrowAsync(
                async () => await app.DisposeAsync().AsTask());
            Assert.That(disposeProbe.Disposed.Task.IsCompleted, Is.True);
            Assert.That(store.DisposeAttempts, Is.EqualTo(1));

            using var stopCts =
                new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await runtime.StopAsync(stopCts.Token);
            Assert.That(store.DisposeAttempts, Is.EqualTo(2));
            Assert.That(
                loggerProvider.Messages.Any(
                    message => message.Contains(
                        "cleanup failure",
                        StringComparison.OrdinalIgnoreCase)),
                Is.True);
        }
        finally
        {
            await app.DisposeAsync();
        }
    }

    [Test]
    public async Task InflightRecoveryScanDrainsBeforeRestoredEnvironmentIsPublished()
    {
        const string RestoreVariable = "AGENTSERVER_SCAN_DRAIN_VALUE";
        RememberEnvironment(RestoreVariable);
        Environment.SetEnvironmentVariable(RestoreVariable, "old");
        Environment.SetEnvironmentVariable(SnapshotEnabledVariable, "true");
        var store = new ControllableListStore(
            new LocalTaskStore(CreateDirectory()));
        var callbackEntered =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var releaseCallback =
            new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = async (context, cancellationToken) =>
            {
                if (context.RestoreId == "restore-2")
                {
                    callbackEntered.TrySetResult();
                    await releaseCallback.Task.WaitAsync(cancellationToken);
                }
            },
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(store);
                services.AddResilientTask<string, string>(
                    "scan-drain",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage first = await PostRestoreAsync(client);
        Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        store.BlockNextList();
        SnapshotTaskRuntime runtime =
            app.Services.GetRequiredService<SnapshotTaskRuntime>();
        Task<int> inflightScan = GetDurability(runtime).ScanOnceAsync();
        await store.ListEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Task<HttpResponseMessage> second = PostRestoreWithOverrideAsync(
            client,
            RestoreVariable,
            "new",
            restoreId: "restore-2");
        Assert.That(
            Environment.GetEnvironmentVariable(RestoreVariable),
            Is.EqualTo("old"));
        Assert.That(callbackEntered.Task.IsCompleted, Is.False);

        store.ReleaseList.TrySetResult();
        await inflightScan.WaitAsync(TimeSpan.FromSeconds(5));
        await callbackEntered.Task.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(
            Environment.GetEnvironmentVariable(RestoreVariable),
            Is.EqualTo("new"));

        releaseCallback.TrySetResult();
        using HttpResponseMessage restored =
            await second.WaitAsync(TimeSpan.FromSeconds(5));
        Assert.That(restored.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [TestCase("true", "false", "true")]
    [TestCase("false", "true", "true")]
    public async Task RestoreRollbackModeIsPinnedToStartupMode(
        string startupValue,
        string overrideValue,
        string expectedAfterFailure)
    {
        Environment.SetEnvironmentVariable(
            SnapshotEnabledVariable,
            startupValue);
        var lifecycle = new TestSnapshotLifecycle
        {
            AfterRestore = (_, _) =>
                throw new InvalidOperationException("mode pinning failure"),
        };

        await using WebApplication app = await StartAppAsync(
            services =>
            {
                services.SetResilientTasksEnabled();
                services.AddSingleton<ITaskStore>(
                    new LocalTaskStore(CreateDirectory()));
                services.AddResilientTask<string, string>(
                    "mode-pinning",
                    (context, cancellationToken) => Task.FromResult(context.Input));
            },
            lifecycle);

        using HttpClient client = app.GetTestClient();
        using HttpResponseMessage response = await PostRestoreWithOverrideAsync(
            client,
            SnapshotEnabledVariable,
            overrideValue);

        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(
                Environment.GetEnvironmentVariable(SnapshotEnabledVariable),
                Is.EqualTo(expectedAfterFailure));
        });
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
        string value,
        string restoreId = "restore-1") =>
        PostJsonAsync(
            client,
            "/_agent/after-restore",
            $$"""
            {
              "session_context": {
                "session_id": "restored-session",
                "restore_id": "{{restoreId}}",
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

    private static TaskDurabilityService GetDurability(
        SnapshotTaskRuntime runtime)
    {
        System.Reflection.FieldInfo field =
            typeof(SnapshotTaskRuntime).GetField(
                "_durability",
                System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.NonPublic)
            ?? throw new InvalidOperationException(
                "Snapshot runtime durability field was not found.");
        return (TaskDurabilityService?)field.GetValue(runtime)
            ?? throw new InvalidOperationException(
                "Snapshot runtime durability service is not prepared.");
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

    private sealed class SignalingListStore(ITaskStore inner) : ITaskStore
    {
        private int _listCalls;

        public TaskCompletionSource SecondListEntered { get; } =
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

        public Task<TaskListResult> ListAsync(
            TaskListQuery query,
            CancellationToken cancellationToken = default)
        {
            if (Interlocked.Increment(ref _listCalls) == 2)
            {
                SecondListEntered.TrySetResult();
            }

            return inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class ControllableListStore(ITaskStore inner) : ITaskStore
    {
        private int _blockNext;

        public TaskCompletionSource ListEntered { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public TaskCompletionSource ReleaseList { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public void BlockNextList()
        {
            ListEntered = new TaskCompletionSource(
                TaskCreationOptions.RunContinuationsAsynchronously);
            ReleaseList = new TaskCompletionSource(
                TaskCreationOptions.RunContinuationsAsynchronously);
            Volatile.Write(ref _blockNext, 1);
        }

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
            if (Interlocked.Exchange(ref _blockNext, 0) != 0)
            {
                ListEntered.TrySetResult();
                await ReleaseList.Task.WaitAsync(cancellationToken);
            }

            return await inner.ListAsync(query, cancellationToken);
        }
    }

    private sealed class ProspectiveBindingProbe(
        string restoreId) : ISnapshotLifecycleParticipant
    {
        public bool UsesTransactionalRestore => false;

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

        public Task CancelAfterRestoreValidationAsync() =>
            Task.CompletedTask;

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

    private sealed class DisposeProbe : IHostedService, IAsyncDisposable
    {
        public TaskCompletionSource Disposed { get; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public Task StartAsync(CancellationToken cancellationToken) =>
            Task.CompletedTask;

        public Task StopAsync(CancellationToken cancellationToken) =>
            Task.CompletedTask;

        public ValueTask DisposeAsync()
        {
            Disposed.TrySetResult();
            return ValueTask.CompletedTask;
        }
    }

    private sealed class RecordingLoggerProvider : ILoggerProvider
    {
        private readonly List<string> _messages = new();

        public IReadOnlyList<string> Messages
        {
            get
            {
                lock (_messages)
                {
                    return _messages.ToArray();
                }
            }
        }

        public ILogger CreateLogger(string categoryName) =>
            new RecordingLogger(_messages);

        public void Dispose()
        {
        }

        private sealed class RecordingLogger(
            List<string> messages) : ILogger
        {
            public IDisposable? BeginScope<TState>(TState state)
                where TState : notnull =>
                null;

            public bool IsEnabled(LogLevel logLevel) => true;

            public void Log<TState>(
                LogLevel logLevel,
                EventId eventId,
                TState state,
                Exception? exception,
                Func<TState, Exception?, string> formatter)
            {
                lock (messages)
                {
                    messages.Add(formatter(state, exception));
                }
            }
        }
    }
}
