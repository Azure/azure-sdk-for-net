// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Internal;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

internal sealed class SnapshotTaskRuntime :
    IHostedService,
    ISnapshotLifecycleParticipant
{
    private readonly IServiceProvider _services;
    private readonly ResilientTaskEnablementState _enablement;
    private readonly TaskEngineAccessor _accessor;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly object _activationStateGate = new();
    private TaskDurabilityService? _durability;
    private TaskEngine? _engine;
    private ITaskStore? _store;
    private bool _ownsStore;
    private RuntimeBinding? _binding;
    private bool _deferred;
    private bool _activationPending;
    private TaskCompletionSource _activationSettled = CompletedSignal();

    public SnapshotTaskRuntime(
        IServiceProvider services,
        ResilientTaskEnablementState enablement,
        TaskEngineAccessor accessor)
    {
        _services = services;
        _enablement = enablement;
        _accessor = accessor;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _deferred = true;
        _enablement.MarkStopped();
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Task? pendingActivation;
        lock (_activationStateGate)
        {
            pendingActivation = _activationPending
                ? _activationSettled.Task
                : null;
        }

        if (pendingActivation is not null)
        {
            _durability?.SignalRollbackStop();
            await pendingActivation.WaitAsync(cancellationToken).ConfigureAwait(false);
        }

        _durability?.SignalStop();
        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_durability is not null)
            {
                await _durability.StopAsync(cancellationToken).ConfigureAwait(false);
                await DisposeRuntimeAsync().ConfigureAwait(false);
            }
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task PrepareAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken)
    {
        if (!_deferred || !_enablement.IsConfigured)
        {
            return;
        }

        BeginActivation();
        try
        {
            await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                RuntimeBinding binding = RuntimeBinding.Current(
                    _services.GetRequiredService<TaskHostEnvironment>());
                if (_binding is not null && _binding != binding)
                {
                    if (_durability?.IsStarted == true)
                    {
                        throw new InvalidOperationException(
                            "Cannot change the resilient-task runtime binding while recovery workers are running.");
                    }

                    if (_engine is not null)
                    {
                        _accessor.Unbind(_engine);
                        _engine.Dispose();
                        await DisposeOwnedStoreAsync().ConfigureAwait(false);
                    }

                    _durability?.DisposeAfterShutdown();
                    _durability = null;
                    _engine = null;
                    _store = null;
                    _binding = null;
                }

                if (_durability is null)
                {
                    TaskStoreFactory storeFactory =
                        _services.GetRequiredService<TaskStoreFactory>();
                    ITaskStore store = storeFactory.Create(out bool ownsStore);
                    _store = store;
                    _ownsStore = ownsStore;
                    TaskRegistry registry = _services.GetRequiredService<TaskRegistry>();
                    ILoggerFactory? loggerFactory = _services.GetService<ILoggerFactory>();
                    ILogger logger = loggerFactory?.CreateLogger(TaskTelemetry.Category)
                        ?? NullLogger.Instance;
                    string agentName = string.IsNullOrEmpty(FoundryEnvironment.AgentName)
                        ? TaskEngineConstants.DefaultAgentName
                        : FoundryEnvironment.AgentName!;
                    string sessionId = string.IsNullOrEmpty(FoundryEnvironment.SessionId)
                        ? TaskEngineConstants.DefaultSessionId
                        : FoundryEnvironment.SessionId!;
                    _engine = new TaskEngine(
                        store,
                        registry,
                        agentName,
                        sessionId,
                        _services.GetRequiredService<AgentEventStreamRegistry>(),
                        logger,
                        _services.GetRequiredService<IServiceScopeFactory>(),
                        _enablement);
                    _accessor.Bind(_engine);
                    _durability = new TaskDurabilityService(
                        new RecoveryScanner(_engine),
                        _engine,
                        scanInterval: null,
                        shutdownGrace: null,
                        logger,
                        _enablement);
                    _binding = binding;
                }

                await _durability.PrepareAfterRestoreAsync(
                    context.RestoreId,
                    cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                _gate.Release();
            }
        }
        catch
        {
            CompleteActivation();
            throw;
        }
    }

    public Task ValidateAfterRestoreAsync(
        AgentRestoreContext context,
        IReadOnlyDictionary<string, string?> prospectiveEnvironment,
        CancellationToken cancellationToken)
    {
        if (!_deferred || !_enablement.IsConfigured || _binding is null)
        {
            return Task.CompletedTask;
        }

        RuntimeBinding prospectiveBinding = RuntimeBinding.FromEnvironment(
            prospectiveEnvironment,
            _services.GetRequiredService<TaskHostEnvironment>());
        if (_binding != prospectiveBinding && _durability?.IsStarted == true)
        {
            throw new InvalidOperationException(
                "Cannot change the resilient-task runtime binding while recovery workers are running.");
        }

        return Task.CompletedTask;
    }

    public IDisposable EnterAfterRestoreCallbackScope()
        => _engine is null
            ? NoOpScope.Instance
            : TaskEngineAccessor.EnterInitializationHandlerScope(_engine);

    public async Task CompleteAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken)
    {
        if (!_deferred || !_enablement.IsConfigured)
        {
            return;
        }

        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            if (_durability is null)
            {
                throw new InvalidOperationException(
                    "The resilient-task runtime was not prepared before restore completion.");
            }

            await _durability.ActivateAfterRestoreAsync(
                context.RestoreId,
                cancellationToken).ConfigureAwait(false);
            if (!_enablement.IsReady && cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException(cancellationToken);
            }

            CompleteActivation();
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task RollbackAfterRestoreAsync(
        AgentRestoreContext context,
        CancellationToken cancellationToken)
    {
        if (!_deferred)
        {
            return;
        }

        await _gate.WaitAsync(CancellationToken.None).ConfigureAwait(false);
        try
        {
            TaskDurabilityService? durability = _durability;
            if (durability is null)
            {
                CompleteActivation();
                return;
            }

            await durability.RollbackAsync().ConfigureAwait(false);
            await DisposeRuntimeAsync().ConfigureAwait(false);
            CompleteActivation();
        }
        finally
        {
            _gate.Release();
        }
    }

    private sealed class NoOpScope : IDisposable
    {
        public static NoOpScope Instance { get; } = new();

        public void Dispose()
        {
        }
    }

    internal TaskEngine RequireEngine()
        => _engine ?? throw new InvalidOperationException(
            "The task engine is not available until snapshot restore activation prepares it.");

    private async Task DisposeRuntimeAsync()
    {
        if (_engine is not null)
        {
            _accessor.Unbind(_engine);
            _engine.Dispose();
        }

        await DisposeOwnedStoreAsync().ConfigureAwait(false);
        _durability?.DisposeAfterShutdown();
        _durability = null;
        _engine = null;
        _store = null;
        _binding = null;
    }

    private async Task DisposeOwnedStoreAsync()
    {
        if (!_ownsStore || _store is null)
        {
            return;
        }

        if (_store is IAsyncDisposable asyncDisposable)
        {
            await asyncDisposable.DisposeAsync().ConfigureAwait(false);
        }
        else if (_store is IDisposable disposable)
        {
            disposable.Dispose();
        }

        _ownsStore = false;
    }

    private void BeginActivation()
    {
        lock (_activationStateGate)
        {
            _activationSettled = new TaskCompletionSource(
                TaskCreationOptions.RunContinuationsAsynchronously);
            _activationPending = true;
        }
    }

    private void CompleteActivation()
    {
        TaskCompletionSource activationSettled;
        lock (_activationStateGate)
        {
            _activationPending = false;
            activationSettled = _activationSettled;
        }

        activationSettled.TrySetResult();
    }

    private static TaskCompletionSource CompletedSignal()
    {
        var completion = new TaskCompletionSource(
            TaskCreationOptions.RunContinuationsAsynchronously);
        completion.SetResult();
        return completion;
    }

    private sealed record RuntimeBinding(
        string AgentName,
        string SessionId,
        string? SessionInstanceId,
        bool IsHosted,
        string? Endpoint,
        string? StateRoot)
    {
        public static RuntimeBinding Current(TaskHostEnvironment environment)
        {
            var currentEnvironment = new Dictionary<string, string?>(
                EnvironmentVariableNames.Comparer);
            foreach (System.Collections.DictionaryEntry variable in
                Environment.GetEnvironmentVariables())
            {
                currentEnvironment.Add(
                    (string)variable.Key,
                    (string?)variable.Value);
            }

            return FromEnvironment(currentEnvironment, environment);
        }

        public static RuntimeBinding FromEnvironment(
            IReadOnlyDictionary<string, string?> environmentVariables,
            TaskHostEnvironment environment)
        {
            string? Get(string name) =>
                environmentVariables.GetValueOrDefault(name);

            return new(
                string.IsNullOrEmpty(Get("FOUNDRY_AGENT_NAME"))
                    ? TaskEngineConstants.DefaultAgentName
                    : Get("FOUNDRY_AGENT_NAME")!,
                string.IsNullOrEmpty(Get("FOUNDRY_AGENT_SESSION_ID"))
                    ? TaskEngineConstants.DefaultSessionId
                    : Get("FOUNDRY_AGENT_SESSION_ID")!,
                Get("FOUNDRY_AGENT_SESSION_GUID"),
                !string.IsNullOrEmpty(Get("FOUNDRY_HOSTING_ENVIRONMENT")),
                environment.Endpoint?.AbsoluteUri
                    ?? Get("FOUNDRY_PROJECT_ENDPOINT"),
                ResolveTasksRoot(Get("AGENTSERVER_STATE_ROOT")));
        }

        private static string ResolveTasksRoot(string? stateRoot)
        {
            string root = string.IsNullOrEmpty(stateRoot)
                ? Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    ".agentserver")
                : stateRoot;
            string resolved = Path.GetFullPath(Path.Combine(root, "tasks"));
            return OperatingSystem.IsWindows()
                ? resolved.ToUpperInvariant()
                : resolved;
        }
    }
}
