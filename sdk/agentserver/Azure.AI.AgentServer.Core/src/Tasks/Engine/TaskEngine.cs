// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Streaming.Backings;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

/// <summary>
/// The in-process orchestrator for resilient task runs. Owns the create → persist
/// input → lease → invoke handler → terminal lifecycle, identity convergence,
/// one-shot auto-cleanup, input-size enforcement, and crash recovery re-invocation.
/// Task runs are surfaced to callers through the typed <see cref="TaskDefinition{TInput, TOutput}"/>
/// returned at registration.
/// </summary>
internal sealed partial class TaskEngine : IDisposable
{
    private readonly ITaskStore _store;
    private readonly TaskWriteSerializer _serializer;
    private readonly LeaseManager _lease;
    private readonly TaskRegistry _registry;
    private readonly AgentEventStreamRegistry _streams;
    private readonly ILogger _logger;
    private readonly IServiceScopeFactory? _scopeFactory;
    private readonly string _agentName;
    private readonly string _sessionId;
    private readonly string _owner;
    private readonly ConcurrentDictionary<string, TaskCompletionSource> _pendingStarts = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, byte> _pendingDeletes = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, TaskDeletionState> _deletionCleanup = new(StringComparer.Ordinal);
    // Delete operations this process is still handling (journaled but not yet drained/closed). The
    // periodic recovery sweep skips these so it never closes a stream whose producer is still
    // unwinding in-process; only crash-orphaned entries (absent from this set) are reconciled.
    private readonly ConcurrentDictionary<string, byte> _liveDeletions = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, IActiveRun> _activeRuns = new(StringComparer.Ordinal);
    private readonly ConcurrentDictionary<string, long> _terminatedOneShot = new(StringComparer.Ordinal);
    private readonly CancellationTokenSource _shutdownCts = new();

    // Spec §21 source.server_version: "<sdk_name>/<sdk_version> (<runtime>/<version>)".
    // Built once from this assembly's informational version (mirrors Python's
    // per-runtime provenance string; the value differs by language/runtime by design).
    private static readonly string ServerVersionValue =
        ServerVersionRegistry.BuildIdentityString("Azure.AI.AgentServer.Core", typeof(TaskEngine).Assembly);

    public TaskEngine(
        ITaskStore store,
        TaskRegistry registry,
        string agentName,
        string sessionId,
        AgentEventStreamRegistry streams,
        ILogger? logger = null,
        IServiceScopeFactory? scopeFactory = null)
    {
        _store = store ?? throw new ArgumentNullException(nameof(store));
        _registry = registry ?? throw new ArgumentNullException(nameof(registry));
        _streams = streams ?? throw new ArgumentNullException(nameof(streams));
        _agentName = agentName;
        _sessionId = sessionId;
        _owner = LeaseManager.FormatOwner(agentName, sessionId);
        _logger = logger ?? NullLogger.Instance;
        _scopeFactory = scopeFactory;
        _serializer = new TaskWriteSerializer(store);
        _lease = new LeaseManager(_serializer);
    }

    internal string Owner => _owner;

    internal bool IsActive(string taskId) => _activeRuns.ContainsKey(taskId);

    internal string InstanceId => _lease.InstanceId;

    internal LeaseManager Lease => _lease;

    internal TaskWriteSerializer Serializer => _serializer;

    /// <summary>Starts a task and awaits it to completion, returning the typed result.</summary>
    public async Task<TOutput> RunAsync<TInput, TOutput>(
        string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
    {
        TaskRun<TOutput> handle = await StartAsync<TInput, TOutput>(name, input, options, cancellationToken)
            .ConfigureAwait(false);
        return await handle.Completion.WaitAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>Starts a task and returns an awaitable handle once the creation round-trip succeeds.</summary>
    public async Task<TaskRun<TOutput>> StartAsync<TInput, TOutput>(
        string name, TInput input, RunOptions? options = null, CancellationToken cancellationToken = default)
    {
        TaskRegistration registration = _registry.Get(name);
        bool multiTurn = registration.MultiTurn;

        // Identity rules enforced BEFORE any network round-trip (FR-005 / FR-006 / C-ID-1).
        string? explicitTaskId = options?.TaskId;
        if (multiTurn && string.IsNullOrEmpty(explicitTaskId))
        {
            throw new ArgumentException(
                "A multi-turn task requires an explicit RunOptions.TaskId (the chain id).", nameof(options));
        }

        string taskId = explicitTaskId ?? GenerateId("task");
        TaskRecordValidation.ValidateTaskId(taskId);

        if (options?.IfLastInputId is not null && string.IsNullOrEmpty(options.InputId))
        {
            throw new ArgumentException(
                "RunOptions.IfLastInputId requires an explicit RunOptions.InputId.", nameof(options));
        }

        // Identity of the input within the task (spec FR-005):
        //   * one-shot  → input_id defaults to task_id (1:1 — one input, one run).
        //   * multi-turn→ each turn gets its OWN input_id: caller-supplied, else a unique
        //                 auto-generated per-turn GUID. The chain head (last_input_id) advances
        //                 every turn, so it is ALWAYS persisted for multi-turn (and can be read
        //                 back from TaskRun.InputId / TaskContext.InputId). For one-shot the head
        //                 is persisted only when the caller supplied an explicit input_id.
        bool inputIdSupplied = !string.IsNullOrEmpty(options?.InputId);
        string inputId = inputIdSupplied
            ? options!.InputId!
            : (multiTurn ? GenerateId("input") : taskId);
        bool persistInputId = inputIdSupplied || multiTurn;
        TaskRecordValidation.ValidateInputId(inputId, taskId);

        while (true)
        {
            if (_pendingDeletes.ContainsKey(taskId))
            {
                throw CreateDeletingConflict(taskId);
            }

            TaskCompletionSource admission = await AcquireStartAsync(taskId, cancellationToken).ConfigureAwait(false);
            try
            {
                if (_activeRuns.TryGetValue(taskId, out IActiveRun? existing))
                {
                    // Cancellation callbacks may submit another input. Release startup admission
                    // before signalling, and preserve this input's identity if suspension wins.
                    ReleaseStart(taskId, admission);
                    TaskRun<TOutput>? accepted = await TryStartActiveRunAsync<TInput, TOutput>(
                        existing, registration, taskId, inputId, persistInputId, input, options, cancellationToken)
                        .ConfigureAwait(false);
                    if (accepted is not null)
                    {
                        return accepted;
                    }
                    continue;
                }

                if (!multiTurn && _terminatedOneShot.ContainsKey(taskId))
                {
                    throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                        $"Task '{taskId}' has already completed.")
                    { CurrentStatus = TaskRunStatus.Completed };
                }

                return multiTurn
                    ? await StartMultiTurnAsync<TInput, TOutput>(registration, name, taskId, inputId, persistInputId, input, options, cancellationToken)
                        .ConfigureAwait(false)
                    : await StartOneShotAsync<TInput, TOutput>(registration, name, taskId, inputId, persistInputId, input, cancellationToken)
                        .ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                FailStart(admission, exception);
                throw;
            }
            finally
            {
                ReleaseStart(taskId, admission);
            }
        }
    }

    private async Task<TaskRun<TOutput>?> TryStartActiveRunAsync<TInput, TOutput>(
        IActiveRun existing, TaskRegistration registration, string taskId, string inputId,
        bool persistInputId, TInput input, RunOptions? options, CancellationToken cancellationToken)
    {
        EnsureTaskName(existing.Name, registration.Name, taskId);
        if (existing.DeleteRequested)
        {
            throw CreateDeletingConflict(taskId);
        }
        RunAdmission admission = existing.Admission;
        if (admission == RunAdmission.Suspended)
        {
            return null;
        }
        if (admission != RunAdmission.Accepting)
        {
            throw CreateUnavailableRunConflict(taskId);
        }

        if (!registration.MultiTurn)
        {
            return existing.GetHandle<TOutput>();
        }

        if (existing.Steerable)
        {
            return await EnqueueSteeringAsync<TInput, TOutput>(
                existing, input, inputId, persistInputId, registration, options?.IfLastInputId, cancellationToken)
                .ConfigureAwait(false);
        }

        throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
            $"Task '{taskId}' already has a turn in progress.")
        { CurrentStatus = TaskRunStatus.InProgress };
    }

    private async Task<TaskCompletionSource> AcquireStartAsync(string taskId, CancellationToken cancellationToken)
    {
        var admission = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            TaskCompletionSource current = _pendingStarts.GetOrAdd(taskId, admission);
            if (ReferenceEquals(current, admission))
            {
                return admission;
            }

            await current.Task.WaitAsync(cancellationToken).ConfigureAwait(false);
        }
    }

    private void ReleaseStart(string taskId, TaskCompletionSource admission)
    {
        _pendingStarts.TryRemove(new System.Collections.Generic.KeyValuePair<string, TaskCompletionSource>(taskId, admission));
        admission.TrySetResult();
    }

    private static void FailStart(TaskCompletionSource admission, Exception exception)
    {
        if (admission.TrySetException(exception))
        {
            // The initiating caller also receives the exception. Observe the shared task even
            // when no other caller was waiting for this start.
            _ = admission.Task.Exception;
        }
    }

    // Cross-language parity (title resolution): a task with no explicit title defaults to
    // "<name>:<task_id[:8]>". The [:8] slice on a shorter id simply yields the whole id.
    private static string DefaultTitle(string name, string taskId)
    {
        string suffix = taskId.Length <= 8 ? taskId : taskId.Substring(0, 8);
        return $"{name}:{suffix}";
    }

    private TaskRunState<TOutput> CreateRunState<TOutput>(
        string taskId,
        string inputId,
        bool isQueued)
        => new(
            taskId,
            inputId,
            isQueued,
            new TaskStreamState(_streams, taskId, inputId));

    private static bool TaskNameMatches(TaskRecord record, string expectedName)
        => string.Equals(record.Source?.Name, expectedName, StringComparison.Ordinal);

    private static void EnsureTaskName(string? actualName, string expectedName, string taskId)
    {
        if (!string.Equals(actualName, expectedName, StringComparison.Ordinal))
        {
            throw new ResilientTaskException(
                ResilientTaskErrorCode.Conflict,
                $"Task '{taskId}' belongs to registered task '{actualName ?? string.Empty}', " +
                $"not '{expectedName}'.");
        }
    }

    private async Task<TaskRun<TOutput>> StartOneShotAsync<TInput, TOutput>(
        TaskRegistration registration, string name, string taskId, string inputId, bool persistInputId, TInput input,
        CancellationToken cancellationToken)
    {
        // Serialize + size-check input BEFORE network (FR-011); promotion keeps payload small.
        JsonNode? inputNode = SerializeInput(input, registration);
        var payload = new JsonObject();
        (JsonNode? inputSlot, JsonObject? attachments) = AttachmentPromoter.Promote(
            attachments: null,
            value: inputNode,
            attachmentKey: AttachmentPromoter.InputAttachmentKey,
            thresholdBytes: AttachmentPromoter.InputThresholdBytes);
        payload[TaskWireKeys.PayloadInput] = inputSlot;
        // Persist last_input_id when the framework advances the chain head: for one-shot only when
        // the caller supplied an explicit input_id (an omitted one-shot input_id logically equals
        // the task_id and nothing is stamped).
        if (persistInputId)
        {
            payload[TaskWireKeys.PayloadLastInputId] = inputId;
        }
        // Anchor the per-run timeout to a persisted boundary so crash recovery cannot reset the
        // clock (FR-015). A one-shot start is a turn-start boundary; recovery leaves it untouched.
        payload[TaskWireKeys.PayloadTurnStartedAt] = DateTimeOffset.UtcNow.ToString("O");
        // Stamp the schema version at create (spec §20/§38). Its presence is REQUIRED: a stale
        // in_progress record lacking it is legacy and deleted (not recovered) by the recovery scan.
        payload[TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue;

        EntryMode entryMode = EntryMode.Fresh;
        TaskRecord record;
        try
        {
            // Atomic create-with-lease: the fresh record is born in_progress holding OUR lease, so a
            // crash immediately after create still leaves a recoverable in_progress record (the scan
            // only lists in_progress) rather than an orphaned lease-less pending record.
            record = await _store.CreateAsync(new TaskCreateRequest
            {
                Id = taskId,
                AgentName = _agentName,
                SessionId = _sessionId,
                Title = registration.Options?.Title ?? DefaultTitle(name, taskId),
                Status = TaskWireKeys.StatusInProgress,
                LeaseOwner = _owner,
                LeaseInstanceId = _lease.InstanceId,
                LeaseDurationSeconds = TaskEngineConstants.LeaseDurationSeconds,
                Payload = payload,
                Attachments = attachments,
                Source = BuildSource(name),
                Tags = BuildTags(name),
            }, cancellationToken).ConfigureAwait(false);
        }
        catch (TaskStoreException ex) when (ex.StatusCode == 409 && ex.Code != TaskStoreException.CodeLeaseHeld)
        {
            // The record already exists: converge or conflict.
            TaskRecord? current = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false)
                ?? throw new ResilientTaskException(ResilientTaskErrorCode.Conflict, $"Task '{taskId}' is gone.") { CurrentStatus = TaskRunStatus.Completed };
            EnsureTaskName(current.Source?.Name, name, taskId);
            if (current.Status == TaskWireKeys.StatusCompleted)
            {
                throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                    $"Task '{taskId}' has already completed.")
                { CurrentStatus = TaskRunStatus.Completed };
            }

            // Not terminal: reclaim and re-invoke as a recovered run.
            record = current;
            entryMode = EntryMode.Recovered;
            inputId = TaskInputIdentity.Active(current, inputId);
            input = ResolveInput<TInput>(current, registration);
        }

        TaskRunState<TOutput> runState =
            CreateRunState<TOutput>(taskId, inputId, isQueued: false);
        var activeRun = new ActiveRun<TOutput>(name, runState);
        runState.RecoveryCount = (int)(record.Lease?.Generation ?? 0);
        if (entryMode == EntryMode.Fresh)
        {
            // The atomic create already established our lease; seed the write-serializer identity so
            // takeover fencing works without a redundant lease-acquiring PATCH.
            _serializer.SeedLease(record);
        }
        else
        {
            _serializer.Track(record);
        }

        if (!_activeRuns.TryAdd(taskId, activeRun))
        {
            IActiveRun concurrent = _activeRuns[taskId];
            EnsureTaskName(concurrent.Name, name, taskId);
            return concurrent.GetHandle<TOutput>();
        }

        CancellationTokenSource handlerCts = runState.Cancellation.Source;

        if (entryMode == EntryMode.Recovered)
        {
            // A converged (already-existing) record: take/renew the lease before dispatching.
            try
            {
                TaskRecord reclaimed = await _lease.AcquireAsync(taskId, _owner, TaskEngineConstants.LeaseDurationSeconds, cancellationToken)
                    .ConfigureAwait(false);
                // recovery_count mirrors the POST-reclaim lease generation (spec §22).
                runState.RecoveryCount = (int)(reclaimed.Lease?.Generation ?? runState.RecoveryCount);
            }
            catch (Exception ex)
            {
                _activeRuns.TryRemove(taskId, out _);
                _serializer.Remove(taskId);
                runState.SetException(ex);
                throw;
            }
        }

        _ = Task.Run(
            () => ExecuteAsync(registration, runState, activeRun, input, taskId, inputId, entryMode, multiTurn: false, handlerCts),
            CancellationToken.None);

        return runState.ToHandle();
    }

    private async Task<TaskRun<TOutput>> StartMultiTurnAsync<TInput, TOutput>(
        TaskRegistration registration, string name, string taskId, string inputId, bool persistInputId, TInput input,
        RunOptions? options, CancellationToken cancellationToken)
    {
        // Serialize + size-check input BEFORE network (FR-011).
        JsonNode? inputNode = SerializeInput(input, registration);
        (JsonNode? inputSlot, JsonObject? attachments) = AttachmentPromoter.Promote(
            attachments: null,
            value: inputNode,
            attachmentKey: AttachmentPromoter.InputAttachmentKey,
            thresholdBytes: AttachmentPromoter.InputThresholdBytes);

        TaskRecord? current = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
        string nowIso = DateTimeOffset.UtcNow.ToString("O");

        EntryMode entryMode;
        TaskRecord record;
        bool recoveredSteeredTurn = false;
        if (current is null)
        {
            // First turn of the chain: create the record. A multi-turn turn always carries a
            // per-turn input_id (caller-supplied or auto-generated), so the chain head is always
            // stamped at create (persistInputId is always true for multi-turn).
            var payload = new JsonObject
            {
                [TaskWireKeys.PayloadInput] = inputSlot,
                [TaskWireKeys.PayloadActiveInputId] = inputId,
                [TaskWireKeys.PayloadTurnStartedAt] = nowIso,
                [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
            };
            if (persistInputId)
            {
                payload[TaskWireKeys.PayloadLastInputId] = inputId;
            }
            try
            {
                record = await _store.CreateAsync(new TaskCreateRequest
                {
                    Id = taskId,
                    AgentName = _agentName,
                    SessionId = _sessionId,
                    Title = registration.Options?.Title ?? DefaultTitle(name, taskId),
                    Status = TaskWireKeys.StatusInProgress,
                    LeaseOwner = _owner,
                    LeaseInstanceId = _lease.InstanceId,
                    LeaseDurationSeconds = TaskEngineConstants.LeaseDurationSeconds,
                    Payload = payload,
                    Attachments = attachments,
                    Source = BuildSource(name),
                    Tags = BuildTags(name),
                }, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskStoreException exception) when (
                exception.StatusCode == 409 && exception.Code == TaskStoreException.CodeTaskAlreadyExists)
            {
                // Local starts share admission. A remaining create collision belongs to another
                // lifetime: report its state without reclaiming it or discarding this caller's input.
                TaskRecord? observed = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
                if (observed is not null)
                {
                    EnsureTaskName(observed.Source?.Name, name, taskId);
                    CheckInputPrecondition(observed, options?.IfLastInputId);
                }

                throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                    $"Task '{taskId}' was created by a concurrent start.", exception)
                {
                    CurrentStatus = observed?.Status switch
                    {
                        TaskWireKeys.StatusPending => TaskRunStatus.Pending,
                        TaskWireKeys.StatusInProgress => TaskRunStatus.InProgress,
                        TaskWireKeys.StatusSuspended => TaskRunStatus.Suspended,
                        TaskWireKeys.StatusCompleted => TaskRunStatus.Completed,
                        _ => null,
                    },
                };
            }
            entryMode = EntryMode.Fresh;
        }
        else
        {
            EnsureTaskName(current.Source?.Name, name, taskId);

            // ifLastInputId precondition (FR-006).
            CheckInputPrecondition(current, options?.IfLastInputId);

            if (current.Status == TaskWireKeys.StatusCompleted)
            {
                throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                    $"Task '{taskId}' has already completed.")
                { CurrentStatus = TaskRunStatus.Completed };
            }

            if (current.Status == TaskWireKeys.StatusInProgress)
            {
                // A record is in_progress but there is no in-memory active entry for it (the
                // caller in StartAsync returns early when one exists), so this process is NOT
                // actively executing it. Decide whether the lease is dead and reclaimable by us,
                // mirroring the one-shot converge path and Python's _lease_is_dead (spec §22):
                //   * owner == our owner (or empty)  -> previous-lifetime crash, reclaim inline.
                //   * foreign owner                  -> live elsewhere, surface the conflict.
                string? leaseOwner = current.Lease?.Owner;
                bool reclaimableByUs = string.IsNullOrEmpty(leaseOwner)
                    || string.Equals(leaseOwner, _owner, StringComparison.Ordinal);
                if (!reclaimableByUs)
                {
                    throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                        $"Task '{taskId}' already has a turn in progress.")
                    { CurrentStatus = TaskRunStatus.InProgress };
                }

                // Dead lease owned by us: recover the in-flight turn rather than starting a new
                // one. Use the persisted turn input/input_id and leave the timeout anchor
                // (turn_started_at) untouched so recovery cannot reset the per-turn clock.
                record = current;
                entryMode = EntryMode.Recovered;
                inputId = TaskInputIdentity.Active(current, inputId);
                input = ResolveInput<TInput>(current, registration);

                // Mid-drain steering recovery (FR-023a): re-enter as a steered turn using the
                // persisted active_input when the crash happened mid-drain.
                if (current.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
                    && steering[TaskWireKeys.SteeringDrainInProgress] is JsonValue drainFlag
                    && drainFlag.TryGetValue(out bool draining)
                    && draining)
                {
                    JsonNode? resolvedActive = AttachmentPromoter.Resolve(
                        steering[TaskWireKeys.SteeringActiveInput], current.Attachments);
                    if (resolvedActive is not null)
                    {
                        input = DeserializeInput<TInput>(resolvedActive, registration);
                        recoveredSteeredTurn = true;
                    }
                }
            }
            else
            {
                // Suspended (or pending): drive the next turn.
                record = current;
                entryMode = EntryMode.Resumed;
            }
        }

        TaskRunState<TOutput> runState =
            CreateRunState<TOutput>(taskId, inputId, isQueued: false);
        runState.RecoveryCount = (int)(record.Lease?.Generation ?? 0);
        bool steerable = registration.Steerable;
        var activeRun = new ActiveRun<TOutput>(name, runState)
        {
            Steerable = steerable,
        };
        if (steerable && HasPersistedSteering(record))
        {
            SeedSteeringSeq(activeRun.Steering, record);
            RehydratePendingInputs(activeRun.Steering, record, taskId);
        }

        if (entryMode == EntryMode.Fresh)
        {
            // The atomic create already established our lease; seed the write-serializer identity.
            _serializer.SeedLease(record);
        }
        else
        {
            _serializer.Track(record);
        }
        if (!_activeRuns.TryAdd(taskId, activeRun))
        {
            IActiveRun concurrent = _activeRuns[taskId];
            EnsureTaskName(concurrent.Name, name, taskId);
            return concurrent.GetHandle<TOutput>();
        }

        CancellationTokenSource handlerCts = runState.Cancellation.Source;

        try
        {
            if (entryMode == EntryMode.Resumed)
            {
                await DriveTurnAsync(taskId, inputSlot, inputId, persistInputId, attachments, nowIso, cancellationToken)
                    .ConfigureAwait(false);
            }
            else if (entryMode == EntryMode.Recovered)
            {
                // Reclaim the dead lease (same owner, new instance id, generation++ at the store)
                // before re-invoking the in-flight turn; recovery_count mirrors the post-reclaim
                // generation (spec §22).
                TaskRecord reclaimed = await _lease
                    .AcquireAsync(taskId, _owner, TaskEngineConstants.LeaseDurationSeconds, cancellationToken)
                    .ConfigureAwait(false);
                runState.RecoveryCount = (int)(reclaimed.Lease?.Generation ?? runState.RecoveryCount);
                await MigrateLegacyInputIdentityAsync(reclaimed, cancellationToken).ConfigureAwait(false);
            }

            // Fresh: the atomic create already established our lease — nothing more to acquire here.
        }
        catch (Exception ex)
        {
            _activeRuns.TryRemove(taskId, out _);
            _serializer.Remove(taskId);
            runState.SetException(ex);
            throw;
        }

        _ = Task.Run(
            () => ExecuteAsync(registration, runState, activeRun, input, taskId, inputId, entryMode, multiTurn: true, handlerCts, recoveredSteeredTurn),
            CancellationToken.None);

        return runState.ToHandle();
    }

    private async Task RejectQueuedInputIfDeletingAsync<TOutput>(
        ActiveRun<TOutput> run,
        QueuedInput<TOutput> queued)
    {
        if (!run.DeleteRequested)
        {
            return;
        }

        await run.RejectDeletedInputAsync(queued).ConfigureAwait(false);
        throw CreateDeletingConflict(run.TaskId);
    }

    private static ResilientTaskException CreateDeletingConflict(string taskId)
        => new(ResilientTaskErrorCode.Conflict, $"Task '{taskId}' is being deleted.")
        {
            CurrentStatus = TaskRunStatus.InProgress,
        };

    private static ResilientTaskException CreateUnavailableRunConflict(string taskId)
        => new(ResilientTaskErrorCode.Conflict, $"Task '{taskId}' is no longer accepting inputs in this execution.");

    // Patches the next-turn input + ids + re-stamps _turn_started_at, clears the prior
    // turn's retry counter, and re-acquires the lease (→ in_progress) in one write.
    private Task<TaskRecord> DriveTurnAsync(
        string taskId, JsonNode? inputSlot, string inputId, bool persistInputId, JsonObject? attachments, string nowIso,
        CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            [TaskWireKeys.PayloadInput] = inputSlot,
            [TaskWireKeys.PayloadActiveInputId] = inputId,
            [TaskWireKeys.PayloadTurnStartedAt] = nowIso,
            [TaskWireKeys.PayloadRetryAttempt] = null,
        };
        // Advance last_input_id to this turn's id. A multi-turn resume always carries a per-turn
        // input_id (caller-supplied or auto-generated), so the chain head advances every turn.
        if (persistInputId)
        {
            payload[TaskWireKeys.PayloadLastInputId] = inputId;
        }

        return _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Status = TaskWireKeys.StatusInProgress,
                LeaseOwner = _owner,
                LeaseInstanceId = _lease.InstanceId,
                LeaseDurationSeconds = TaskEngineConstants.LeaseDurationSeconds,
                Payload = payload,
                PayloadSupplied = true,
                Attachments = attachments,
            },
            WriteIntent.LeaseHeartbeat,
            cancellationToken);
    }

    // Serializes a steering input, queues it in-process, durably appends it to the
    // record's _steering.pending_inputs, then nudges the running turn to wind down.
    private async Task<TaskRun<TOutput>?> EnqueueSteeringAsync<TInput, TOutput>(
        IActiveRun existing, TInput input, string inputId, bool persistInputId, TaskRegistration registration,
        string? ifLastInputId, CancellationToken cancellationToken)
    {
        var run = (ActiveRun<TOutput>)existing;
        string taskId = run.TaskId;
        if (run.DeleteRequested)
        {
            throw CreateDeletingConflict(taskId);
        }

        // Promote oversized steering inputs (> 20 KiB) to a `_steering_input_<seq>` attachment at
        // APPEND time, leaving only a tiny ref slot in pending_inputs (Python parity:
        // _append_steering_input routes through _resolve_input_storage). This keeps the persisted
        // `payload._steering` bounded no matter how many large inputs are queued, so the queue can
        // never blow the 1 MiB payload cap, and keeps the wire schema cross-language compatible.
        JsonNode? inputNode = SerializeInput(input, registration);
        (JsonNode? inputSlot, JsonObject? inputAttachments) = run.Steering.PromoteInput(seq =>
            AttachmentPromoter.Promote(
                attachments: null,
                value: inputNode,
                attachmentKey: $"{AttachmentPromoter.SteeringAttachmentKeyPrefix}{seq}",
                thresholdBytes: AttachmentPromoter.SteeringThresholdBytes));

        TaskRunState<TOutput> runState =
            CreateRunState<TOutput>(taskId, inputId, isQueued: true);
        var queued = new QueuedInput<TOutput>(inputSlot, inputAttachments, inputId, persistInputId, runState, accepted: false);

        // Keep this route stable after promotion. An in-flight removal is shared, not mistaken
        // for promotion; a promoted input signals its own source, including before dispatch.
        var cancelGate = new object();
        TaskCompletionSource? removal = null;
        runState.Cancel = async () =>
        {
            bool remove = false;
            TaskCompletionSource? pending;
            lock (cancelGate)
            {
                if (runState.ResultTask.IsCompleted)
                {
                    return;
                }

                if (removal is null && run.Steering.Remove(queued))
                {
                    removal = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
                    remove = true;
                }

                pending = removal;
            }

            if (pending is null)
            {
                await runState.Cancellation.RequestAsync().ConfigureAwait(false);
                return;
            }

            if (remove)
            {
                try
                {
                    await _serializer.UpdateAsync(
                        taskId,
                        record =>
                        {
                            var payload = new JsonObject { [TaskWireKeys.PayloadSteering] = run.Steering.ToPayload() };
                            TaskInputIdentity.PreserveLegacy(record, payload, taskId);
                            // Crash repair: cancelling a queued input removes it from the durable
                            // queue and closes its stream right after. Record the close intent
                            // atomically so a crash in that window is reconciled to EOF on restart.
                            MarkStreamPendingClose(record, payload, inputId);
                            return new TaskPatchRequest
                            {
                                Payload = payload,
                                PayloadSupplied = true,
                                Attachments = DeletionPatch(queued.Attachments),
                            };
                        },
                        WriteIntent.SteeringAppend,
                        CancellationToken.None).ConfigureAwait(false);

                    await CloseStreamAsync(runState).ConfigureAwait(false);
                    runState.SetException(new OperationCanceledException(
                        $"Task '{taskId}' input '{inputId}' was cancelled before the queued input was promoted."));
                    run.ForgetInput(runState);
                    pending.TrySetResult();
                }
                catch (Exception exception)
                {
                    pending.TrySetException(exception);
                }
            }

            await pending.Task.ConfigureAwait(false);
        };

        bool enqueued = false;
        bool reroute = false;
        void RejectAdmission()
        {
            if (!enqueued || run.Steering.Remove(queued))
            {
                runState.Cancellation.Retire();
                run.ForgetInput(runState);
            }
            queued.Reject();
        }
        try
        {
            await _serializer.UpdateAndPublishAsync(
                taskId,
                record =>
                {
                    EnsureTaskName(record.Source?.Name, registration.Name, taskId);
                    if (run.DeleteRequested)
                    {
                        throw CreateDeletingConflict(taskId);
                    }
                    RunAdmission admission = run.Admission;
                    if (admission == RunAdmission.Suspended)
                    {
                        reroute = true;
                        return null;
                    }
                    if (admission != RunAdmission.Accepting)
                    {
                        throw CreateUnavailableRunConflict(taskId);
                    }
                    CheckInputPrecondition(record, ifLastInputId);

                    JsonObject steering = enqueued ? run.SnapshotSteering() : run.Enqueue(queued);
                    enqueued = true;
                    var payload = new JsonObject { [TaskWireKeys.PayloadSteering] = steering };
                    TaskInputIdentity.PreserveLegacy(record, payload, taskId);
                    if (persistInputId)
                    {
                        payload[TaskWireKeys.PayloadLastInputId] = inputId;
                    }

                    return new TaskPatchRequest
                    {
                        Payload = payload,
                        PayloadSupplied = true,
                        Attachments = queued.Attachments,
                    };
                },
                WriteIntent.SteeringAppend,
                () =>
                {
                    if (reroute)
                    { queued.Reject(); }
                    else
                    { queued.Accept(); }
                },
                RejectAdmission,
                cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            if (!queued.Admission.IsCompleted)
            {
                RejectAdmission();
            }
            throw;
        }

        if (reroute)
        {
            runState.Cancellation.Retire();
            return null;
        }

        await RejectQueuedInputIfDeletingAsync(run, queued).ConfigureAwait(false);

        // Cause-before-cancel (C-CAN-2): bump the pending count, then nudge the running turn.
        await run.SignalSteeringAsync().ConfigureAwait(false);

        return runState.ToHandle();
    }

    private static void CheckInputPrecondition(TaskRecord record, string? expected)
    {
        if (expected is not null)
        {
            string? actual = TaskInputIdentity.Accepted(record);
            // A missing head seeds the chain; only a recorded predecessor can conflict.
            if (actual is not null && !string.Equals(actual, expected, StringComparison.Ordinal))
            {
                throw new ResilientTaskException(ResilientTaskErrorCode.PreconditionFailed) { ActualLastInputId = actual };
            }
        }
    }

    private async Task MigrateLegacyInputIdentityAsync(TaskRecord record, CancellationToken cancellationToken)
    {
        if (!TaskInputIdentity.NeedsMigration(record))
        {
            return;
        }
        await _serializer.UpdateAsync(
            record.Id,
            current =>
            {
                if (!TaskInputIdentity.NeedsMigration(current))
                {
                    return null;
                }
                var payload = new JsonObject();
                TaskInputIdentity.PreserveLegacy(current, payload, record.Id);
                return new TaskPatchRequest { Payload = payload, PayloadSupplied = true };
            },
            WriteIntent.Generic,
            cancellationToken).ConfigureAwait(false);
    }

    // Promotes a queued steering input into the next turn: pops the FIFO head, advances
    // next_input_seq, re-stamps _turn_started_at, resets the retry counter, clears the
    // drain markers, and re-acquires the lease (→ in_progress) in one write.
    private async Task<(QueuedInput<TOutput> Input, string NowIso)?> DriveSteeredTurnAsync<TOutput>(
        ActiveRun<TOutput> run, CancellationToken cancellationToken)
    {
        QueuedInput<TOutput>? queued;
        while (true)
        {
            queued = run.PromoteNext();
            if (queued is null)
            {
                return null;
            }
            if (await queued.Admission.WaitAsync(cancellationToken).ConfigureAwait(false))
            {
                break;
            }
            run.AbandonPromotion(queued);
        }

        string taskId = run.TaskId;
        string nowIso = DateTimeOffset.UtcNow.ToString("O");

        // The head was already promoted at APPEND time, so its slot may be a `_steering_input_<seq>`
        // ref. Resolve it back to the raw value here (the in-process QueuedInput carries the
        // attachment content). The drained turn's input is inlined as `active_input` (bounded to a
        // single input's size) and the consumed attachment is deleted in this same drain PATCH,
        // matching Python (_try_drain_steering: active_input = raw, attachments_patch[ref] = None).
        JsonNode? rawValue = queued.Attachments is not null
            ? AttachmentPromoter.Resolve(queued.Slot, queued.Attachments)
            : queued.Slot;
        JsonObject? attachments = DeletionPatch(queued.Attachments);

        // Persist drain_in_progress=true + active_input=<raw value> for the duration of the steered
        // turn so a crash mid-turn recovers as a steered turn (FR-023a/C-REC-5). The markers are
        // cleared on the record at the next turn-start (next drain) or at suspend.
        run.Steering.SetActiveInput(rawValue);

        var payload = new JsonObject();
        payload[TaskWireKeys.PayloadInput] = rawValue?.DeepClone();
        payload[TaskWireKeys.PayloadTurnStartedAt] = nowIso;
        payload[TaskWireKeys.PayloadRetryAttempt] = null;

        await _serializer.UpdateAsync(
            taskId,
            record =>
            {
                var turnPayload = (JsonObject)payload.DeepClone();
                turnPayload[TaskWireKeys.PayloadSteering] = run.SnapshotSteering();
                // Crash repair: promotion retires the preceding active input; its stream is closed
                // right after this drain commits. Record that predecessor's close intent atomically
                // (never the just-promoted input) so a crash in the window is reconciled on restart.
                string retired = TaskInputIdentity.Active(record, taskId);
                if (!string.Equals(retired, queued.InputId, StringComparison.Ordinal))
                {
                    MarkStreamPendingClose(record, turnPayload, retired);
                }
                TaskInputIdentity.PreserveLegacy(record, turnPayload, taskId);
                turnPayload[TaskWireKeys.PayloadActiveInputId] = queued.InputId;
                return new TaskPatchRequest
                {
                    Status = TaskWireKeys.StatusInProgress,
                    LeaseOwner = _owner,
                    LeaseInstanceId = _lease.InstanceId,
                    LeaseDurationSeconds = TaskEngineConstants.LeaseDurationSeconds,
                    Payload = turnPayload,
                    PayloadSupplied = true,
                    Attachments = attachments,
                };
            },
            WriteIntent.SteeringDrain,
            cancellationToken).ConfigureAwait(false);

        // Clear the in-process markers now that the steered turn has started; the record keeps
        // the persisted true markers until the next turn boundary writes _steering again.
        run.Steering.CompleteDrain();

        // Return the head with its slot resolved to the raw value so the turn loop can deserialize
        // the input directly (the ref + attachment have already been consumed above).
        return (new QueuedInput<TOutput>(rawValue, attachments: null, queued.InputId, queued.PersistInputId, queued.RunState), nowIso);
    }

    // Orchestrates a multi-turn chain across drained steering turns: runs a turn, then either
    // promotes the next queued steering input as a steered turn (in_progress, no suspend) or
    // parks the chain at suspended. One-shot tasks run exactly one turn.
    private async Task ExecuteAsync<TInput, TOutput>(
        TaskRegistration registration,
        TaskRunState<TOutput> runState,
        ActiveRun<TOutput> activeRun,
        TInput input,
        string taskId,
        string inputId,
        EntryMode entryMode,
        bool multiTurn,
        CancellationTokenSource handlerCts,
        bool isSteeredTurn = false)
    {
        var handler = registration.RequiresServiceScope
            ? null
            : (Func<TaskContext<TInput>, CancellationToken, Task<TOutput>>)registration.Handler;
        var scopedHandler = registration.RequiresServiceScope
            ? (Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>>)registration.Handler
            : null;
        // Retry is opt-in (spec §15): a handler with no configured TaskRetryPolicy fails on the first
        // raise, matching the Python reference (retry only applies when a policy is supplied).
        TaskRetryPolicy retry = registration.Options?.Retry ?? new TaskRetryPolicy { MaxAttempts = 1 };

        TaskRunState<TOutput> currentRun = runState;
        TInput currentInput = input;
        string currentInputId = inputId;
        EntryMode currentMode = entryMode;
        bool steered = isSteeredTurn;
        CancellationTokenSource currentCts = handlerCts;

        try
        {
            while (true)
            {
                if (activeRun.DeleteRequested)
                {
                    CompleteDeletedRun(taskId, multiTurn, currentRun, activeRun);
                    return;
                }

                TurnOutcome<TOutput> outcome = await RunTurnAsync(
                    registration, handler, scopedHandler, retry, activeRun, currentRun, currentInput, taskId, currentInputId,
                    currentMode, steered, TaskEngineConstants.ResolveTaskTimeout(registration.Options?.Timeout), currentCts).ConfigureAwait(false);
                currentRun.Cancellation.Seal();

                if (activeRun.DeleteRequested)
                {
                    CompleteDeletedRun(taskId, multiTurn, currentRun, activeRun);
                    return;
                }

                if (outcome.Kind == TurnOutcomeKind.Deferred)
                {
                    // Exit-for-recovery: lease already released, record stays in_progress. Deferral is
                    // an internal lifecycle handoff — the run handle's Completion is intentionally left
                    // pending (never faulted) so the durable run can resume in a future process. A
                    // caller that does not want to wait can bail via Completion.WaitAsync(token).
                    _activeRuns.TryRemove(taskId, out _);
                    _serializer.Remove(taskId);
                    if (activeRun.DeleteRequested)
                    {
                        currentRun.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));
                    }

                    return;
                }

                if (outcome.Kind == TurnOutcomeKind.Cancelled)
                {
                    if (!multiTurn)
                    {
                        // One-shot cancel: remove the record so the recovery scanner
                        // does not re-invoke a cancelled handler.
                        bool deleted = await TryDeleteAsync(taskId).ConfigureAwait(false);
                        if (deleted)
                        {
                            await CloseStreamAsync(currentRun).ConfigureAwait(false);
                        }

                        FinishTurn(taskId, multiTurn);
                        currentRun.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));
                        return;
                    }

                    // Multi-turn cancel: the chain stays alive (SOT §16 — a multi-turn
                    // CancelledError transitions the chain to `suspended`). Drain any
                    // queued steerer to take over the next turn; otherwise park the
                    // chain at `suspended` so it is not left dangling as `in_progress`.
                    bool suspended = false;
                    (QueuedInput<TOutput> Input, string NowIso)? cancelDrained;
                    while ((cancelDrained = await DriveSteeredTurnAsync(activeRun, CancellationToken.None).ConfigureAwait(false)) is null)
                    {
                        try
                        {
                            suspended = await TrySuspendAsync(taskId, activeRun, CancellationToken.None).ConfigureAwait(false);
                            if (suspended)
                            { break; }
                        }
                        catch (Exception suspendEx)
                        {
                            _logger.HandlerFailure(taskId, 0, suspendEx.GetType().Name);
                            break;
                        }
                    }

                    if (cancelDrained is { } cancelPromotion)
                    {
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
                        currentRun.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));

                        currentRun = cancelPromotion.Input.RunState;
                        currentInput = cancelPromotion.Input.Slot is null
                            ? default!
                            : DeserializeInput<TInput>(cancelPromotion.Input.Slot, registration);
                        currentInputId = cancelPromotion.Input.InputId;
                        currentMode = EntryMode.Resumed;
                        steered = true;

                        activeRun.SetCurrent(currentRun);
                        currentCts = currentRun.Cancellation.Source;
                        continue;
                    }

                    if (suspended)
                    {
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
                    }

                    FinishTurn(taskId, multiTurn, activeRun);
                    currentRun.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));
                    return;
                }

                if (!multiTurn)
                {
                    // One-shot terminal. The durable completion write must succeed before the caller
                    // observes success: if CompleteAsync fails the record stays in_progress and a
                    // later recovery scan could re-run the turn, so surface the failure to the caller
                    // instead of reporting a completion that is not durable.
                    bool durablyCompleted = false;
                    if (outcome.Kind == TurnOutcomeKind.Completed)
                    {
                        try
                        {
                            await CompleteAsync(taskId, CancellationToken.None).ConfigureAwait(false);
                        }
                        catch (Exception completionEx)
                        {
                            _logger.HandlerFailure(taskId, 0, completionEx.GetType().Name);
                            FinishTurn(taskId, multiTurn);
                            currentRun.SetException(new ResilientTaskException(
                                ResilientTaskErrorCode.HandlerError,
                                $"Task '{taskId}' completed its handler but the durable completion write failed.",
                                completionEx)
                            {
                                Failure = new TaskFailureDetail(
                                    TaskFailureKind.HandlerError,
                                    completionEx.GetType().Name,
                                    $"Task '{taskId}' completed its handler but the durable completion write failed."),
                            });
                            return;
                        }

                        durablyCompleted = true;
                    }

                    // The record is now durably completed (or the outcome was not a completion). The
                    // delete is best-effort cleanup — a failure here leaves a completed record that
                    // recovery will not re-run, so it must not fail the caller.
                    bool deleted = false;
                    try
                    {
                        deleted = await TryDeleteAsync(taskId).ConfigureAwait(false);
                    }
                    catch (Exception deleteEx)
                    {
                        _logger.HandlerFailure(taskId, 0, deleteEx.GetType().Name);
                    }

                    if (durablyCompleted || deleted)
                    {
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
                    }

                    FinishTurn(taskId, multiTurn);
                    ResolveOutcome(currentRun, outcome);
                    return;
                }

                // Multi-turn: a completed turn or a per-turn raise both keep the chain alive.
                // Drain the next queued steering input if any; otherwise park at suspended.
                (QueuedInput<TOutput> Input, string NowIso)? drained;
                while ((drained = await DriveSteeredTurnAsync(activeRun, CancellationToken.None).ConfigureAwait(false)) is null)
                {
                    try
                    {
                        if (await TrySuspendAsync(taskId, activeRun, CancellationToken.None).ConfigureAwait(false))
                        {
                            break;
                        }
                    }
                    catch (Exception suspendEx)
                    {
                        if (activeRun.DeleteRequested)
                        {
                            CompleteDeletedRun(taskId, multiTurn, currentRun, activeRun);
                            return;
                        }
                        _logger.HandlerFailure(taskId, 0, suspendEx.GetType().Name);
                        FinishTurn(taskId, multiTurn, activeRun);
                        currentRun.SetException(new ResilientTaskException(
                            ResilientTaskErrorCode.HandlerError,
                            $"Task '{taskId}' finished its turn but the durable suspend write failed.",
                            suspendEx)
                        {
                            Failure = new TaskFailureDetail(
                                TaskFailureKind.HandlerError,
                                suspendEx.GetType().Name,
                                $"Task '{taskId}' finished its turn but the durable suspend write failed."),
                        });
                        return;
                    }
                }

                if (drained is { } promotion)
                {
                    await CloseStreamAsync(currentRun).ConfigureAwait(false);
                    ResolveOutcome(currentRun, outcome);

                    currentRun = promotion.Input.RunState;
                    currentInput = promotion.Input.Slot is null
                        ? default!
                        : DeserializeInput<TInput>(promotion.Input.Slot, registration);
                    currentInputId = promotion.Input.InputId;
                    currentMode = EntryMode.Resumed;
                    steered = true;

                    activeRun.SetCurrent(currentRun);
                    currentCts = currentRun.Cancellation.Source;
                    continue;
                }

                // Suspension and retirement are committed; closure belongs to this old input.
                await CloseStreamAsync(currentRun).ConfigureAwait(false);
                FinishTurn(taskId, multiTurn, activeRun);
                ResolveOutcome(currentRun, outcome);
                return;
            }
        }
        catch (Exception fatal)
        {
            if (activeRun.DeleteRequested)
            {
                if (fatal is not OperationCanceledException)
                {
                    _logger.HandlerFailure(taskId, 0, fatal.GetType().Name);
                }

                CompleteDeletedRun(taskId, multiTurn, currentRun, activeRun);
                return;
            }

            activeRun.RetireAdmission(RunAdmission.Unavailable, () => FinishTurn(taskId, multiTurn, activeRun));
            currentRun.SetException(fatal);
        }
        finally
        {
            currentRun.Cancellation.Retire();
            await activeRun.ProducerUnwoundAsync().ConfigureAwait(false);
        }
    }

    // Runs a single turn's retry loop and returns its raw outcome WITHOUT any store write,
    // handle resolution, or active-run cleanup (the orchestrator owns those).
    private async Task<TurnOutcome<TOutput>> RunTurnAsync<TInput, TOutput>(
        TaskRegistration registration,
        Func<TaskContext<TInput>, CancellationToken, Task<TOutput>>? handler,
        Func<IServiceProvider, TaskContext<TInput>, CancellationToken, Task<TOutput>>? scopedHandler,
        TaskRetryPolicy retry,
        ActiveRun<TOutput> activeRun,
        TaskRunState<TOutput> runState,
        TInput input,
        string taskId,
        string inputId,
        EntryMode entryMode,
        bool isSteeredTurn,
        TimeSpan? timeout,
        CancellationTokenSource handlerCts)
    {
        var ctxState = new TaskContextState<TInput>(
            input,
            taskId,
            inputId,
            runState.StreamState)
        {
            EntryMode = entryMode,
            RecoveryCount = runState.RecoveryCount,
            IsSteeredTurn = isSteeredTurn,
            PendingInputCount = activeRun.SteeringCount,
            Cancellation = handlerCts.Token,
            Shutdown = _shutdownCts.Token,
        };
        ctxState.ExitForRecovery = async ct =>
        {
            if (!_shutdownCts.IsCancellationRequested)
            {
                // Misuse-as-failed: exit-for-recovery is only valid during graceful shutdown.
                // Calling it otherwise is a handler bug — surface it loudly as a failure so it
                // shows up in operator logs rather than silently deferring (mirrors Python's
                // RuntimeError that ends the task in `failed`).
                throw new InvalidOperationException(
                    "ExitForRecovery may only be called when ctx.Shutdown is signaled.");
            }

            // Graceful shutdown: force-expire the lease (duration 0, status stays in_progress),
            // and mark the turn for recovery. Queued steering inputs remain
            // in the persisted state; the next process re-enters the handler with
            // EntryMode.Recovered. This sets a post-return signal (no throw) that the engine
            // reconciles once the handler returns — deferral is a lifecycle handoff, not a fault.
            await _lease.ReleaseAsync(taskId, _owner, ct).ConfigureAwait(false);
            ctxState.DeferredForRecovery = true;
        };

        // Publish causes (C-CAN-2) so a handler waking on the cancelled token always observes
        // a cause (an explicit cancel) or a positive pending-input count (a steering nudge).
        runState.Cancellation.BindCause(() => ctxState.CancelRequested = true);
        activeRun.PublishPendingInputCount = count => ctxState.PendingInputCount = count;

        // Reconcile any cause that landed between this turn's launch and the publisher wiring:
        // a steering nudge bumps the count. BindCause reconciles explicit pre-dispatch cancellation
        // against this exact input's source, rather than the previous turn's cancellation flag.
        ctxState.PendingInputCount = activeRun.SteeringCount;

        // Read the persisted turn-start + retry budget so the timeout deadline and retry counter
        // survive crashes (a recovered turn reads the same absolute deadline and resumes at the
        // same attempt; the crash itself does not consume budget — FR-014/FR-015).
        TaskRecord? persisted = await _store.GetAsync(taskId).ConfigureAwait(false);
        DateTimeOffset turnStartedAt = ParseTurnStartedAt(persisted) ?? DateTimeOffset.UtcNow;
        int startAttempt = ParseRetryAttempt(persisted) ?? 0;

        await using TimeoutWatchdog? watchdog = TimeoutWatchdog.Start(
            turnStartedAt, timeout, () => ctxState.TimeoutExceeded = true, handlerCts);

        Exception? lastError = null;
        bool retriedToExhaustion = false;
        int attempt = 0;
        // MaxAttempts is validated in [1, MaxRetryAttempts] at TaskRetryPolicy construction.
        int maxAttempts = retry.MaxAttempts;

        // Renew the lease for the WHOLE turn — across handler execution AND every inter-attempt
        // backoff delay — so a long backoff cannot let the lease lapse and allow another worker to
        // reclaim and re-invoke the same turn concurrently. Renewing only around the handler (and
        // not the Task.Delay below) would break the no-double-execution invariant once a configured
        // backoff exceeds the lease duration.
        using var renewCts = new CancellationTokenSource();
        var leaseLost = new StrongBox<bool>(false);
        Task renewLoop = RenewLeaseLoopAsync(taskId, handlerCts, leaseLost, renewCts.Token);
        // Publish the renewal source so graceful shutdown can stop renewal directly (after
        // force-expiring the lease) rather than relying on the handler unwinding to trigger the
        // finally below — a hung handler must not be able to re-extend a force-expired lease.
        activeRun.RenewalCts = renewCts;
        try
        {
            for (attempt = startAttempt; attempt < maxAttempts; attempt++)
            {
                ctxState.RetryAttempt = attempt;
                try
                {
                    FoundryAgentRequestContext ambientRequestContext = FoundryAgentRequestContext.Current;
                    FoundryAgentRequestContext? previousRequestContext =
                        FoundryAgentRequestContext.Exchange(new FoundryAgentRequestContext
                        {
                            CallId = ExtractCallId(ctxState.Input, registration) ?? ambientRequestContext.CallId,
                        });
                    TOutput result;
                    try
                    {
                        var context = new TaskContext<TInput>(ctxState);
                        if (scopedHandler is null)
                        {
                            result = await handler!(
                                context, handlerCts.Token).ConfigureAwait(false);
                        }
                        else
                        {
                            if (_scopeFactory is null)
                            {
                                throw new InvalidOperationException(
                                    "The task engine cannot activate a class handler because no service scope factory is available.");
                            }

                            await using AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
                            result = await scopedHandler(
                                scope.ServiceProvider, context, handlerCts.Token).ConfigureAwait(false);
                        }
                    }
                    finally
                    {
                        FoundryAgentRequestContext.Exchange(previousRequestContext);
                    }

                    if (ctxState.DeferredForRecovery)
                    {
                        // The handler voluntarily yielded for recovery (ExitForRecovery set a
                        // post-return signal). Reconcile it as a deferral, ignoring any returned value.
                        return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Deferred };
                    }

                    return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Completed, Result = result };
                }
                catch (OperationCanceledException) when (handlerCts.IsCancellationRequested && leaseLost.Value)
                {
                    // The lease renewal loop lost the lease (takeover/eviction) and cancelled the
                    // handler. We no longer own the task, so abandon the turn for recovery — the new
                    // lease holder owns the outcome. Writing terminal state here would clobber it.
                    return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Deferred };
                }
                catch (OperationCanceledException) when (handlerCts.IsCancellationRequested
                    && _shutdownCts.IsCancellationRequested
                    && !ctxState.CancelRequested && !ctxState.TimeoutExceeded)
                {
                    // Graceful shutdown interrupted the running handler with no explicit cancel/timeout
                    // cause. Abandon the turn for recovery (leave the record in_progress) rather than
                    // recording a terminal failure — the next lifetime's recovery scan resumes it. This
                    // mirrors the mid-backoff shutdown branch below.
                    return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Deferred };
                }
                catch (OperationCanceledException) when (handlerCts.IsCancellationRequested
                    && (ctxState.CancelRequested || ctxState.TimeoutExceeded))
                {
                    // A genuine cancel cause (caller cancel / timeout / shutdown) was raised. A bare
                    // steering nudge (pending-only, no cause) is NOT a cancel — the handler is
                    // expected to return cooperatively, which lands on the Completed path above.
                    return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Cancelled };
                }
                catch (Exception ex)
                {
                    lastError = ex;
                    _logger.HandlerFailure(taskId, attempt, ex.GetType().Name);
                    bool retryable = retry.RetryOn?.Invoke(ex) ?? true;
                    if (!retryable || attempt + 1 >= maxAttempts)
                    {
                        retriedToExhaustion = retryable && maxAttempts > 1;
                        break;
                    }

                    // Durably advance the retry counter BEFORE backing off so a crash during the
                    // delay resumes at the next attempt rather than restarting the budget (FR-014).
                    await PersistRetryAttemptAsync(taskId, attempt + 1).ConfigureAwait(false);
                    try
                    {
                        // Back off with the handler's cooperative token so shutdown, timeout,
                        // explicit cancel, a steering nudge, or lease loss interrupt the wait
                        // immediately — mirroring Python's cancellable `asyncio.sleep(delay)`. An
                        // uncancellable delay would otherwise hold the turn (and its lease) for the
                        // full backoff even after the turn has been told to stop.
                        await Task.Delay(ComputeDelay(retry, attempt), handlerCts.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException) when (handlerCts.IsCancellationRequested)
                    {
                        if (leaseLost.Value)
                        {
                            // Lease lost mid-backoff: abandon for recovery (the new holder owns it).
                            return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Deferred };
                        }

                        if (_shutdownCts.IsCancellationRequested)
                        {
                            // Graceful shutdown mid-backoff: abandon the turn for recovery without
                            // consuming budget or writing a terminal state (the record stays
                            // in_progress for the next lifetime to resume).
                            return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Deferred };
                        }

                        if (ctxState.CancelRequested || ctxState.TimeoutExceeded)
                        {
                            return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Cancelled };
                        }

                        // A bare steering nudge cancelled the backoff (no cancel cause). Stop
                        // retrying — the post-turn drain promotes the queued steering input as the
                        // next turn (multi-turn) just as Python breaks the retry loop on a
                        // cancelled sleep and drains.
                        break;
                    }
                }
            }
        }
        finally
        {
            // Detach the renewal source before disposing it so a concurrent shutdown StopRenewal()
            // cannot race a disposed CTS; the cancel below then stops the loop deterministically.
            activeRun.RenewalCts = null;
            renewCts.Cancel();
            try
            {
                await renewLoop.ConfigureAwait(false);
            }
            catch
            {
                // Renewal failures are non-fatal to the turn outcome.
            }
        }

        TaskFailureDetail detail;
        if (lastError is null)
        {
            detail = new TaskFailureDetail(
                TaskFailureKind.ExhaustedRetries, "exhausted_retries", "Task failed.", attempt + 1, null, null);
        }
        else if (retriedToExhaustion)
        {
            detail = new TaskFailureDetail(
                TaskFailureKind.ExhaustedRetries,
                "exhausted_retries",
                lastError.Message,
                attempt + 1,
                lastError.Message,
                lastError.GetType().Name,
                lastError.ToString());
        }
        else
        {
            detail = new TaskFailureDetail(
                TaskFailureKind.HandlerError,
                lastError.GetType().Name,
                lastError.Message,
                traceback: lastError.ToString());
        }

        return new TurnOutcome<TOutput> { Kind = TurnOutcomeKind.Failed, Detail = detail, Error = lastError };
    }

    private static void ResolveOutcome<TOutput>(TaskRunState<TOutput> runState, TurnOutcome<TOutput> outcome)
    {
        if (outcome.Kind == TurnOutcomeKind.Completed)
        {
            runState.SetResult(outcome.Result);
        }
        else
        {
            TaskFailureDetail detail = outcome.Detail!;
            ResilientTaskErrorCode code = detail.Kind == TaskFailureKind.ExhaustedRetries
                ? ResilientTaskErrorCode.ExhaustedRetries
                : ResilientTaskErrorCode.HandlerError;
            runState.SetException(new ResilientTaskException(code, detail.Message, outcome.Error) { Failure = detail });
        }
    }

    private enum TurnOutcomeKind
    {
        Completed,
        Failed,
        Cancelled,
        Deferred,
    }

    private sealed class TurnOutcome<TOutput>
    {
        public TurnOutcomeKind Kind { get; set; }

        public TOutput Result { get; set; } = default!;

        public TaskFailureDetail? Detail { get; set; }

        public Exception? Error { get; set; }
    }

    private async Task RenewLeaseLoopAsync(
        string taskId, CancellationTokenSource handlerCts, StrongBox<bool> leaseLost, CancellationToken stopToken)
    {
        const int MaxConsecutiveFailures = 3;
        int consecutiveFailures = 0;
        TimeSpan interval = TimeSpan.FromSeconds(TaskEngineConstants.LeaseRenewSeconds);
        ActiveTaskEntry entry = _serializer.GetOrAddEntry(taskId);
        try
        {
            while (!stopToken.IsCancellationRequested)
            {
                await Task.Delay(interval, stopToken).ConfigureAwait(false);

                // Every lease-bearing write (payload/steering PATCH) refreshes the lease as a side
                // effect. Skip a redundant heartbeat when a more-recent refresh happened within the
                // renewal interval, waiting only the remainder before re-checking (Python parity:
                // lease_renewal_loop's last-refresh shadow).
                DateTimeOffset lastRefresh = entry.LastRefreshUtc;
                if (lastRefresh > DateTimeOffset.MinValue)
                {
                    TimeSpan age = DateTimeOffset.UtcNow - lastRefresh;
                    if (age < interval)
                    {
                        await Task.Delay(interval - age, stopToken).ConfigureAwait(false);
                        continue;
                    }
                }

                try
                {
                    await _lease.HeartbeatAsync(taskId, _owner, TaskEngineConstants.LeaseDurationSeconds, stopToken)
                        .ConfigureAwait(false);
                    consecutiveFailures = 0;
                }
                catch (WriteAbandonedException)
                {
                    // The lease was taken over or evicted (a peer reclaimed it). We no longer own the
                    // task, so the handler must stop immediately rather than keep executing — and keep
                    // its terminal writes — against a lease we lost. Signal loss and cancel the turn so
                    // it abandons for recovery instead of finishing under a stolen lease (FR-016).
                    leaseLost.Value = true;
                    _logger.LeaseLost(taskId);
                    CancelQuietly(handlerCts);
                    return;
                }
                catch (OperationCanceledException) when (stopToken.IsCancellationRequested)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    // Transient renewal failure (e.g. a store blip). Tolerate a few in a row, but once
                    // the lease can no longer be presumed held, treat it as lost and cancel the turn.
                    _logger.HandlerFailure(taskId, 0, ex.GetType().Name);
                    if (++consecutiveFailures >= MaxConsecutiveFailures)
                    {
                        leaseLost.Value = true;
                        _logger.LeaseLost(taskId);
                        CancelQuietly(handlerCts);
                        return;
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            // Expected on handler completion.
        }
        catch (Exception ex)
        {
            _logger.HandlerFailure(taskId, 0, ex.GetType().Name);
        }
    }

    private static void CancelQuietly(CancellationTokenSource cts)
    {
        try
        {
            cts.Cancel();
        }
        catch (ObjectDisposedException)
        {
            // The turn already finished and disposed its handler CTS — nothing to cancel.
        }
    }

    private async Task CompleteAsync(string taskId, CancellationToken cancellationToken)
    {
        await _serializer.UpdateAsync(
            taskId,
            record =>
            {
                // Crash repair: a completed one-shot deletes its record and closes its stream
                // right after this write. Record the close intent atomically so a crash between
                // the completion commit and the stream close is reconciled to EOF on restart.
                var payload = new JsonObject();
                MarkStreamPendingClose(record, payload, TaskInputIdentity.Active(record, taskId));
                return new TaskPatchRequest
                {
                    Status = TaskWireKeys.StatusCompleted,
                    Payload = payload,
                    PayloadSupplied = true,
                };
            },
            WriteIntent.Complete,
            cancellationToken).ConfigureAwait(false);
    }

    // Parks a multi-turn chain: clears the turn's input/promoted-attachment/retry counter and
    // transitions to suspended, preserving
    // _last_input_id and writing no output/error (FR-007/C-SUS-1/4). The _steering object is
    // written ONLY when the chain carries steering state (cross-language parity: suspend
    // preserves an existing steering block with drain markers false and next_input_seq intact, but
    // omits the key entirely for a never-steered chain — an absent block reads back as
    // drain_in_progress=false, so a future lifetime cannot mistake it for a mid-drain crash).
    private Task<bool> TrySuspendAsync<TOutput>(
        string taskId, ActiveRun<TOutput> run, CancellationToken cancellationToken)
    {
        return _serializer.ExecuteAsync(taskId, async () =>
        {
            if (!run.TrySnapshotEmpty(out JsonObject? steeringPayload))
            {
                return false;
            }
            try
            {
                await _serializer.UpdateLockedAsync(
                    taskId,
                    record =>
                    {
                        var payload = new JsonObject
                        {
                            [TaskWireKeys.PayloadInput] = null,
                            [TaskWireKeys.PayloadRetryAttempt] = null,
                        };
                        if (steeringPayload is not null)
                        {
                            payload[TaskWireKeys.PayloadSteering] = steeringPayload.DeepClone();
                        }
                        TaskInputIdentity.PreserveLegacy(record, payload, taskId);
                        // Crash repair: the finished turn's stream is closed right after this
                        // suspend commits. Record the close intent atomically so a crash in that
                        // window is reconciled to EOF on restart (saved-state reconciliation).
                        MarkStreamPendingClose(record, payload, TaskInputIdentity.Active(record, taskId));
                        return new TaskPatchRequest
                        {
                            Status = TaskWireKeys.StatusSuspended,
                            SuspensionReason = TaskWireKeys.SuspensionReasonRunCompletion,
                            Payload = payload,
                            PayloadSupplied = true,
                            Attachments = new JsonObject { [AttachmentPromoter.InputAttachmentKey] = null },
                        };
                    },
                    WriteIntent.Suspend,
                    cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                run.RetireAdmission(RunAdmission.Unavailable, () => FinishTurn(taskId, multiTurn: true, run));
                throw;
            }

            // Publish retirement before the gate opens to a waiting append. Stream cleanup
            // happens afterward and must not detach a subsequently resumed execution.
            run.RetireAdmission(RunAdmission.Suspended, () => FinishTurn(taskId, multiTurn: true, run));
            return true;
        }, cancellationToken);
    }

    /// <summary>Ends a multi-turn chain: cancels any in-flight turn, resolves queued callers as cancelled, and removes the record.</summary>
    public Task DeleteAsync(string taskId, CancellationToken cancellationToken = default)
        => DeleteCoreAsync(expectedTaskName: null, taskId, cancellationToken);

    /// <summary>Ends a multi-turn chain after validating its registered task name.</summary>
    public Task DeleteAsync(
        string expectedTaskName,
        string taskId,
        CancellationToken cancellationToken = default)
        => DeleteCoreAsync(expectedTaskName, taskId, cancellationToken);

    private async Task DeleteCoreAsync(
        string? expectedTaskName,
        string taskId,
        CancellationToken cancellationToken)
    {
        TaskCompletionSource admission = await AcquireStartAsync(taskId, cancellationToken).ConfigureAwait(false);
        _pendingDeletes.TryAdd(taskId, 0);
        try
        {
            await DeleteAdmittedAsync(expectedTaskName, taskId, cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _pendingDeletes.TryRemove(taskId, out _);
            ReleaseStart(taskId, admission);
        }
    }

    private async Task DeleteAdmittedAsync(
        string? expectedTaskName,
        string taskId,
        CancellationToken cancellationToken)
    {
        TaskRecord? record = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
        if (expectedTaskName is not null)
        {
            if (record is not null)
            {
                EnsureTaskName(record.Source?.Name, expectedTaskName, taskId);
            }
        }

        // Cancel an in-flight turn and resolve its caller as cancelled.
        _activeRuns.TryGetValue(taskId, out IActiveRun? run);
        if (run is not null && expectedTaskName is not null)
        {
            EnsureTaskName(run.Name, expectedTaskName, taskId);
        }
        TaskDeletionState cleanup = _deletionCleanup.GetOrAdd(taskId,
            _ => new TaskDeletionState((id, exception) => _logger.StreamCloseFailure(taskId, id, exception.GetType().Name)));
        if (run is not null)
        {
            _ = ObserveDeletionCancellationAsync(taskId, run.RequestDeletionAsync(cleanup));
        }
        else if (record is not null)
        {
            foreach (string inputId in GetDeletedRecordInputIds(record))
            {
                cleanup.Track(new TaskStreamState(_streams, taskId, inputId), inputId, Task.CompletedTask);
            }
        }

        // Crash repair: a hard delete removes the record that names the streams still owing EOF, so
        // the close intent is journaled durably before the provider delete. The journal names the
        // inputs the deletion actually captured (including any appended concurrently after the record
        // was read), carries a per-operation identity, and is registered as a live in-process
        // operation so the periodic sweep never reconciles a deletion this process is still handling.
        string operationId = Guid.NewGuid().ToString("N");
        IReadOnlyCollection<string> journaledInputs = cleanup.TrackedInputIds;
        bool journaled = journaledInputs.Count > 0 && _streams is ITaskEventStreamRegistry journalRegistry;
        if (journaled)
        {
            _liveDeletions.TryAdd(operationId, 0);
            ((ITaskEventStreamRegistry)_streams).RecordPendingDeletion(taskId, operationId, journaledInputs);
        }

        try
        {
            // Framework chains are typically non-terminal (suspended/in_progress),
            // so force the delete to release any active lease (Python parity: the
            // public multi-turn delete calls provider.delete(force=True)).
            await _store.DeleteAsync(taskId, ifMatch: null, force: true, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        catch (TaskStoreException ex) when (ex.StatusCode == 404)
        {
            // Idempotent: deleting an absent chain is a no-op.
        }

        _serializer.Remove(taskId);
        await cleanup.ConfirmAsync().ConfigureAwait(false);
        _deletionCleanup.TryRemove(taskId, out _);

        // The delete committed. Remove the durable journal only after the streams are actually sealed
        // — including closures deferred until a running producer unwinds — so a crash before a
        // deferred close still finds the journal and reconciles on restart. Removal is scoped to this
        // operation id so a later delete reusing the same task id is untouched. This never blocks
        // DeleteAsync on a non-cooperative handler: if the close does not complete in this lifetime
        // the operation stays live and the journal persists for the next restart; a failed close
        // retains the journal but releases the live guard so the sweep can retry once the producer
        // has unwound.
        if (journaled)
        {
            _ = RemovePendingDeletionAfterDrainAsync(cleanup, (ITaskEventStreamRegistry)_streams, taskId, operationId);
        }
    }

    private async Task RemovePendingDeletionAfterDrainAsync(
        TaskDeletionState cleanup, ITaskEventStreamRegistry registry, string taskId, string operationId)
    {
        try
        {
            await cleanup.DrainAsync().ConfigureAwait(false);
        }
        catch
        {
            // The producer unwound but a close failed; keep the journal for retry and release the
            // live guard so a later sweep (or restart) can reconcile the still-open stream.
            _liveDeletions.TryRemove(operationId, out _);
            return;
        }

        try
        {
            registry.RemovePendingDeletion(taskId, operationId);
        }
        catch (Exception ex)
        {
            // A transient failure removing the journal file is harmless: the stream is already
            // sealed, and a later scan (or restart) removes the now-stale entry idempotently.
            _logger.StreamCloseFailure(taskId, operationId, ex.GetType().Name);
        }
        finally
        {
            _liveDeletions.TryRemove(operationId, out _);
        }
    }

    private async Task ObserveDeletionCancellationAsync(string taskId, Task cancellation)
    {
        try
        {
            await cancellation.ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            _logger.HandlerFailure(taskId, 0, exception.GetType().Name);
        }
    }

    private HashSet<string> GetDeletedRecordInputIds(TaskRecord record)
    {
        var inputIds = new HashSet<string>(StringComparer.Ordinal);
        if (record.Payload[TaskWireKeys.PayloadActiveInputId] is JsonValue active
            && active.TryGetValue(out string? activeInputId)
            && !string.IsNullOrEmpty(activeInputId))
        {
            inputIds.Add(activeInputId);
        }
        if (record.Payload[TaskWireKeys.PayloadLastInputId] is JsonValue head
            && head.TryGetValue(out string? inputId)
            && !string.IsNullOrEmpty(inputId))
        {
            inputIds.Add(inputId);
        }
        else if (_registry.TryGet(record.Source?.Name ?? string.Empty, out TaskRegistration registration)
            && !registration.MultiTurn)
        {
            inputIds.Add(record.Id);
        }

        if (record.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringPendingInputIds] is JsonArray pendingIds)
        {
            foreach (JsonNode? pending in pendingIds)
            {
                if (pending is JsonValue value && value.TryGetValue(out string? pendingId)
                    && !string.IsNullOrEmpty(pendingId))
                {
                    inputIds.Add(pendingId);
                }
            }
        }

        return inputIds;
    }

    private void CompleteDeletedRun<TOutput>(
        string taskId,
        bool multiTurn,
        TaskRunState<TOutput> runState,
        IActiveRun activeRun)
    {
        FinishTurn(taskId, multiTurn, activeRun);
        runState.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));
    }

    private void FinishTurn(string taskId, bool multiTurn, IActiveRun? expectedRun = null)
    {
        if (expectedRun is not null)
        {
            if (!_activeRuns.TryRemove(new KeyValuePair<string, IActiveRun>(taskId, expectedRun)))
            {
                return;
            }
        }
        else
        {
            _activeRuns.TryRemove(taskId, out _);
        }
        if (!multiTurn)
        {
            _terminatedOneShot[taskId] = DateTime.UtcNow.Ticks;
            EvictTerminatedOneShot();
        }

        _serializer.Remove(taskId);
    }

    // The terminated set only converts in-process re-starts of an already-terminal one-shot
    // into a conflict for a short window. Evict stale entries so it can't grow unbounded in
    // a long-lived host that runs many one-shot tasks.
    private void EvictTerminatedOneShot()
    {
        if (_terminatedOneShot.Count <= TaskEngineConstants.TerminatedOneShotMaxEntries)
        {
            return;
        }

        long cutoff = DateTime.UtcNow.AddSeconds(-TaskEngineConstants.TerminatedOneShotTtlSeconds).Ticks;
        foreach (var pair in _terminatedOneShot)
        {
            if (pair.Value < cutoff)
            {
                _terminatedOneShot.TryRemove(pair.Key, out _);
            }
        }
    }

    private async Task<bool> TryDeleteAsync(string taskId)
    {
        try
        {
            // Best-effort cleanup of a cancelled/completed one-shot; force the
            // delete so an in_progress record (cancelled mid-flight) is removed
            // rather than left for the recovery scanner (Python parity).
            await _store.DeleteAsync(taskId, force: true).ConfigureAwait(false);
            return true;
        }
        catch (TaskStoreException exception) when (exception.StatusCode == 404)
        {
            return true;
        }
        catch (TaskStoreException)
        {
            // Best-effort one-shot cleanup.
            return false;
        }
    }

    private async Task<bool> CloseStreamAsync<TOutput>(TaskRunState<TOutput> runState)
    {
        try
        {
            await runState.StreamState.CloseAsync().ConfigureAwait(false);
        }
        catch (Exception closeException)
        {
            _logger.StreamCloseFailure(
                runState.TaskId,
                runState.InputId,
                closeException.GetType().Name);
            return false;
        }

        // The stream is durably closed; drop its close intent so the saved marker shrinks (best
        // effort — a stale marker is idempotently re-closed by reconciliation).
        await ClearStreamPendingCloseAsync(runState.TaskId, runState.InputId).ConfigureAwait(false);
        return true;
    }

    // Records a crash-repair close intent atomically with a durable transition: the raw input id
    // whose file-backed stream still owes an end-of-stream marker once the transition commits. The
    // id is merged with any intents still outstanding on the record so a delayed/failed earlier close
    // is never dropped by a later retirement (each id is cleared only after its own close succeeds).
    private static void MarkStreamPendingClose(TaskRecord record, JsonObject payload, string inputId)
    {
        var merged = new JsonArray();
        var seen = new HashSet<string>(StringComparer.Ordinal);
        if (record.Payload?[TaskWireKeys.PayloadStreamsPendingClose] is JsonArray existing)
        {
            foreach (JsonNode? node in existing)
            {
                if (node is JsonValue value && value.TryGetValue(out string? id) && id is not null && seen.Add(id))
                {
                    merged.Add(JsonValue.Create(id));
                }
            }
        }

        if (seen.Add(inputId))
        {
            merged.Add(JsonValue.Create(inputId));
        }

        payload[TaskWireKeys.PayloadStreamsPendingClose] = merged;
    }

    // Removes a single input id from a record's outstanding close intents after its stream is
    // durably closed. Best effort: a missing record or transient failure leaves a stale intent that
    // reconciliation later re-closes idempotently.
    private async Task ClearStreamPendingCloseAsync(string taskId, string inputId)
    {
        try
        {
            await _serializer.UpdateAsync(
                taskId,
                record =>
                {
                    if (record.Payload is not JsonObject payload
                        || payload[TaskWireKeys.PayloadStreamsPendingClose] is not JsonArray pending
                        || pending.Count == 0)
                    {
                        return null;
                    }

                    var remaining = new JsonArray();
                    bool removed = false;
                    foreach (JsonNode? node in pending)
                    {
                        if (node is JsonValue value && value.TryGetValue(out string? id)
                            && string.Equals(id, inputId, StringComparison.Ordinal))
                        {
                            removed = true;
                            continue;
                        }

                        remaining.Add(node?.DeepClone());
                    }

                    if (!removed)
                    {
                        return null;
                    }

                    return new TaskPatchRequest
                    {
                        Payload = new JsonObject { [TaskWireKeys.PayloadStreamsPendingClose] = remaining },
                        PayloadSupplied = true,
                    };
                },
                WriteIntent.Generic,
                CancellationToken.None).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.StreamCloseFailure(taskId, inputId, ex.GetType().Name);
        }
    }

    // Saved-state reconciliation: closes the streams named by a record's crash-repair close intent,
    // skipping any input that is still live (the executing input, or a durably queued input). The
    // stream is opened existing-only and closed idempotently, so an already-closed or absent
    // backing is a no-op and a reused live input is never sealed. Returns true only if every
    // eligible stream closed; a successfully closed intent is cleared from the record.
    private async Task<bool> ReconcilePendingClosesAsync(TaskRecord record, CancellationToken cancellationToken)
    {
        if (record.Payload is not JsonObject payload
            || payload[TaskWireKeys.PayloadStreamsPendingClose] is not JsonArray pending
            || pending.Count == 0)
        {
            return true;
        }

        var live = new HashSet<string>(StringComparer.Ordinal);
        if (record.Status == TaskWireKeys.StatusInProgress)
        {
            live.Add(TaskInputIdentity.Active(record, record.Id));
        }

        if (payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringPendingInputIds] is JsonArray queuedIds)
        {
            foreach (JsonNode? node in queuedIds)
            {
                if (node is JsonValue queuedValue && queuedValue.TryGetValue(out string? queuedId) && queuedId is not null)
                {
                    live.Add(queuedId);
                }
            }
        }

        bool allClosed = true;
        foreach (JsonNode? node in pending)
        {
            if (node is not JsonValue value || !value.TryGetValue(out string? inputId) || inputId is null)
            {
                continue;
            }

            if (live.Contains(inputId))
            {
                continue;
            }

            try
            {
                // Existing-only + idempotent: never creates a missing backing, never re-emits EOF.
                await new TaskStreamState(_streams, record.Id, inputId).CloseAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Ownership conflict, missing backing, or I/O error must not abort the sweep; retain
                // the close intent so a later scan retries rather than reporting a false success.
                allClosed = false;
                _logger.StreamCloseFailure(record.Id, inputId, ex.GetType().Name);
                continue;
            }

            await ClearStreamPendingCloseAsync(record.Id, inputId).ConfigureAwait(false);
        }

        return allClosed;
    }

    // Reconciles crash-orphaned streams for records that have durably left in_progress: suspended
    // chains (a finished turn whose close was interrupted) and completed one-shots (whose ephemeral
    // record delete was interrupted). Completed records are deleted after their streams are sealed,
    // finishing the interrupted cleanup. These records are not re-dispatched as work.
    private async Task ReconcileRetiredRecordsAsync(string status, bool deleteAfter, CancellationToken cancellationToken)
    {
        string? after = null;
        do
        {
            TaskListResult listed = await _store.ListAsync(new TaskListQuery
            {
                AgentName = _agentName,
                SessionId = _sessionId,
                Status = status,
                After = after,
            }, cancellationToken).ConfigureAwait(false);

            foreach (TaskRecordRef item in listed.Items)
            {
                TaskRecord record = item.Record;
                if (record.Source?.Type != TaskWireKeys.SourceTypeValue)
                {
                    continue;
                }

                if (record.Lease is not null && !string.Equals(record.Lease.Owner, _owner, StringComparison.Ordinal))
                {
                    continue;
                }

                // A task this process is actively running owns its own close lifecycle; leave its
                // streams to the live run rather than reconciling them from a periodic sweep.
                if (_activeRuns.ContainsKey(record.Id))
                {
                    continue;
                }

                bool allClosed = await ReconcilePendingClosesAsync(record, cancellationToken).ConfigureAwait(false);

                // Finish the interrupted ephemeral cleanup only once every stream is durably closed;
                // deleting the record while a close still owes EOF would discard its last reference.
                if (deleteAfter && allClosed)
                {
                    try
                    {
                        await _store.DeleteAsync(record.Id, force: true, cancellationToken: cancellationToken)
                            .ConfigureAwait(false);
                    }
                    catch (TaskStoreException)
                    {
                        // Best-effort: a concurrent delete or transient failure is retried next scan.
                    }
                }
            }

            after = listed.NextAfter;
        }
        while (after is not null);
    }

    private JsonObject BuildSource(string name) => new()
    {
        [TaskWireKeys.SourceType] = TaskWireKeys.SourceTypeValue,
        [TaskWireKeys.SourceName] = name,
        [TaskWireKeys.SourceServerVersion] = ServerVersionValue,
        // Immutable creation provenance (spec §21): always written, empty string in local/dev.
        [TaskWireKeys.SourceHostingEnvironment] =
            Environment.GetEnvironmentVariable("FOUNDRY_HOSTING_ENVIRONMENT") ?? string.Empty,
    };

    private static Dictionary<string, string> BuildTags(string name) => new(StringComparer.Ordinal)
    {
        [TaskWireKeys.TagTaskName] = name,
    };

    private static JsonNode? SerializeInput<TInput>(TInput input, TaskRegistration registration)
    {
        if (input is null)
        {
            return null;
        }

        // Use the caller-supplied source-generated metadata when present (Native-AOT / trimming
        // path), otherwise fall back to the reflection-based serializer.
        byte[] bytes = registration.InputTypeInfo is JsonTypeInfo<TInput> typeInfo
            ? JsonSerializer.SerializeToUtf8Bytes(input, typeInfo)
            : JsonSerializer.SerializeToUtf8Bytes(input);
        return JsonNode.Parse(bytes);
    }

    private static string? ExtractCallId<TInput>(TInput input, TaskRegistration registration)
    {
        if (SerializeInput(input, registration) is not JsonObject inputObject)
        {
            return null;
        }

        JsonNode? value = inputObject["call_id"] ?? inputObject["CallId"];
        return value is JsonValue jsonValue
            && jsonValue.TryGetValue(out string? callId)
            && !string.IsNullOrEmpty(callId)
                ? callId
                : null;
    }

    // Deserializes a task input node through the registration's source-generated metadata when
    // present (Native-AOT / trimming path), otherwise via the reflection-based serializer.
    private static TInput DeserializeInput<TInput>(JsonNode node, TaskRegistration registration)
        => registration.InputTypeInfo is JsonTypeInfo<TInput> typeInfo
            ? node.Deserialize(typeInfo)!
            : node.Deserialize<TInput>()!;

    // Builds an attachments patch that DELETES every key present in <paramref name="attachments"/>
    // (a null value per key is the store's delete sentinel). Returns null when there is nothing to
    // delete, so the enclosing PATCH omits the attachments field entirely.
    private static JsonObject? DeletionPatch(JsonObject? attachments)
    {
        if (attachments is null || attachments.Count == 0)
        {
            return null;
        }

        var patch = new JsonObject();
        foreach (KeyValuePair<string, JsonNode?> kvp in attachments)
        {
            patch[kvp.Key] = null;
        }

        return patch;
    }

    private static TInput ResolveInput<TInput>(TaskRecord record, TaskRegistration registration)
    {
        JsonNode? slot = record.Payload[TaskWireKeys.PayloadInput];
        JsonNode? resolved = AttachmentPromoter.Resolve(slot, record.Attachments);
        if (resolved is null)
        {
            return default!;
        }

        return DeserializeInput<TInput>(resolved, registration);
    }

    // Restores the monotonic steering seq from a persisted record so attachment keys stay
    // unique across suspend/resume and recovery (FR-029d).
    private static void SeedSteeringSeq<TOutput>(SteeringQueue<TOutput> queue, TaskRecord record)
    {
        if (record.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringNextInputSeq] is JsonValue seqValue
            && seqValue.TryGetValue(out int seq))
        {
            queue.SeedNextSeq(seq);
            // The record already carries a steering block, so a later suspend must preserve it
            // (Python parity: `if existing_steering:`), even if the queue has drained back to empty.
            queue.MarkPersistedSteering();
        }
    }

    // Rehydrates the in-process steering FIFO from the persisted `pending_inputs` on recovery so
    // inputs that were queued-but-not-drained when the process crashed survive and still drain,
    // instead of stranding in the record forever. Python is record-driven (the queue lives in the
    // record and every drain reads `pending_inputs` fresh), so it needs no equivalent step; the C#
    // drain pops from this in-memory queue, which is empty after a restart unless we repopulate it.
    //
    // Recovered inputs are caller-less: the process that awaited each handle is gone, so the steered
    // turn advances the conversation and resolves a detached handle that nobody observes (Python
    // parity: `_pending_steering_futures` is likewise lost on crash and the input drains on its data
    // alone). Each entry's per-turn id is restored from the parallel `pending_input_ids` array so the
    // recovered turn keeps its `ctx.InputId` independently of the accepted chain head.
    // When that array is absent or length-mismatched (an
    // older or cross-language record that only persisted slots) the recovered turn falls back to
    // inheriting the active input identity without advancing the accepted head.
    private void RehydratePendingInputs<TOutput>(SteeringQueue<TOutput> queue, TaskRecord record, string taskId)
    {
        if (record.Payload[TaskWireKeys.PayloadSteering] is not JsonObject steering
            || steering[TaskWireKeys.SteeringPendingInputs] is not JsonArray pending
            || pending.Count == 0)
        {
            return;
        }

        string inheritedInputId = TaskInputIdentity.Active(record, taskId);

        // Only trust the parallel id array when it lines up 1:1 with the slots; otherwise fall back
        // to the inherited chain head so a skewed/older record degrades to the prior behavior.
        JsonArray? pendingIds = steering[TaskWireKeys.SteeringPendingInputIds] as JsonArray;
        bool idsUsable = pendingIds is not null && pendingIds.Count == pending.Count;

        var restored = new List<QueuedInput<TOutput>>(pending.Count);
        for (int i = 0; i < pending.Count; i++)
        {
            JsonNode? slotClone = pending[i]?.DeepClone();

            // For an oversized queued input the slot is a `_steering_input_<seq>` ref whose content
            // lives in the record's attachments. Carry that content on the QueuedInput exactly as
            // the append path did, so the existing drain (DriveSteeredTurnAsync) resolves the ref and
            // deletes the consumed attachment unchanged. A dangling ref (missing attachment) is left
            // as-is and fails loud at drain, matching how any corrupt record is treated.
            JsonObject? attachments = null;
            if (AttachmentRef.TryParse(slotClone, out AttachmentRef? attachmentRef)
                && record.Attachments is { } recordAttachments
                && recordAttachments.TryGetPropertyValue(attachmentRef!.Key, out JsonNode? content))
            {
                attachments = new JsonObject { [attachmentRef.Key] = content?.DeepClone() };
            }

            string inputId = inheritedInputId;
            bool persistInputId = false;
            if (idsUsable
                && pendingIds![i] is JsonValue entryIdValue
                && entryIdValue.TryGetValue(out string? entryId)
                && !string.IsNullOrEmpty(entryId))
            {
                // Restore this turn's persisted identity, not the most recently accepted input.
                inputId = entryId;
                persistInputId = true;
            }

            TaskRunState<TOutput> runState =
                CreateRunState<TOutput>(taskId, inputId, isQueued: true);
            restored.Add(new QueuedInput<TOutput>(slotClone, attachments, inputId, persistInputId, runState));
        }

        queue.SeedPendingInputs(restored);
    }

    /// <summary>Whether the persisted record already carries steering state worth restoring.
    /// Lets the engine defer allocating a steering queue until a task is genuinely steered.</summary>
    private static bool HasPersistedSteering(TaskRecord record)
        => record.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringNextInputSeq] is JsonValue seqValue
            && seqValue.TryGetValue(out int _);

    private static DateTimeOffset? ParseTurnStartedAt(TaskRecord? record)
    {
        if (record?.Payload[TaskWireKeys.PayloadTurnStartedAt] is JsonValue value
            && value.TryGetValue(out string? iso)
            && DateTimeOffset.TryParse(iso, out DateTimeOffset parsed))
        {
            return parsed;
        }

        return null;
    }

    private static int? ParseRetryAttempt(TaskRecord? record)
    {
        if (record?.Payload[TaskWireKeys.PayloadRetryAttempt] is JsonValue value
            && value.TryGetValue(out int attempt))
        {
            return attempt;
        }

        return null;
    }

    // Durably advances _retry_attempt as a last-writer-wins bookkeeping write so a crash during
    // a backoff delay resumes at the next attempt instead of restarting the budget (FR-014).
    private Task PersistRetryAttemptAsync(string taskId, int attempt)
        => _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Payload = new JsonObject { [TaskWireKeys.PayloadRetryAttempt] = attempt },
                PayloadSupplied = true,
            },
            WriteIntent.Generic,
            CancellationToken.None);

    private static string GenerateId(string prefix)
        => $"{prefix}-{Guid.NewGuid():N}";

    private static TimeSpan ComputeDelay(TaskRetryPolicy retry, int attempt)
        // Delegate to the policy's DelayStrategy (retry number is 1-based). The strategy owns jitter
        // and max-delay clamping; the backoff itself is awaited under the handler's cooperative token
        // so shutdown/cancel/timeout still interrupt a long delay.
        => retry.Delay.GetNextDelay(null, attempt + 1);

    /// <summary>Returns the in-flight run for a one-shot task keyed by <paramref name="taskId"/>, or null.</summary>
    public async Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
        string name, string taskId, CancellationToken cancellationToken = default)
    {
        TaskRegistration registration = _registry.Get(name);
        if (registration.MultiTurn)
        {
            throw new ArgumentException($"Task '{name}' is multi-turn; the (name, taskId, inputId) overload is required.", nameof(name));
        }

        if (_activeRuns.TryGetValue(taskId, out IActiveRun? run)
            && string.Equals(run.Name, name, StringComparison.Ordinal))
        {
            return run.GetHandle<TOutput>();
        }

        // Not active in this process: consult the store. A persisted in_progress record with a
        // dead lease owned by us is a previous-lifetime crash — inline-reclaim and re-invoke it
        // as recovered so the caller observes the still-live task (spec §22, E7).
        IActiveRun? recovered = await TryReclaimStaleFromStoreAsync(name, taskId, cancellationToken)
            .ConfigureAwait(false);
        return recovered?.GetHandle<TOutput>();
    }

    /// <summary>Returns the in-flight run for a multi-turn task keyed by <paramref name="taskId"/> and <paramref name="inputId"/>, or null.</summary>
    public async Task<TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(
        string name, string taskId, string inputId, CancellationToken cancellationToken = default)
    {
        TaskRegistration registration = _registry.Get(name);
        if (!registration.MultiTurn)
        {
            throw new ArgumentException($"Task '{name}' is one-shot; the (name, taskId) overload is required.", nameof(name));
        }

        if (_activeRuns.TryGetValue(taskId, out IActiveRun? run) &&
            string.Equals(run.Name, name, StringComparison.Ordinal) &&
            string.Equals(run.InputId, inputId, StringComparison.Ordinal))
        {
            return run.GetHandle<TOutput>();
        }

        // Consult the store and inline-reclaim a stale in_progress turn (E7). Recovery re-enters
        // the persisted in-flight turn, so only surface it when its input_id matches the request.
        IActiveRun? recovered = await TryReclaimStaleFromStoreAsync(name, taskId, cancellationToken)
            .ConfigureAwait(false);
        if (recovered is not null && string.Equals(recovered.InputId, inputId, StringComparison.Ordinal))
        {
            return recovered.GetHandle<TOutput>();
        }

        return null;
    }

    /// <summary>
    /// Consults the store for a persisted <c>in_progress</c> record and, when its lease is dead
    /// and reclaimable by this owner, inline-reclaims and re-invokes it as recovered. Returns the
    /// resulting in-memory run, or <see langword="null"/> when there is nothing to recover (record
    /// absent/terminal, foreign owner, non-framework record, or a lost reclaim race).
    /// </summary>
    private async Task<IActiveRun?> TryReclaimStaleFromStoreAsync(
        string name, string taskId, CancellationToken cancellationToken)
    {
        if (!_registry.TryGet(name, out TaskRegistration registration) || registration.RecoverDispatch is null)
        {
            return null;
        }

        TaskRecord? record = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
        if (record is null || record.Status != TaskWireKeys.StatusInProgress)
        {
            return null;
        }

        // Only our reserved framework records are recoverable — never adopt a foreign record that
        // happens to share the (agent, session) scope.
        if (record.Source?.Type != TaskWireKeys.SourceTypeValue
            || !TaskNameMatches(record, name))
        {
            return null;
        }

        // NOTE: no pre-schema legacy gate on the inline-reclaim path. Python's `get_active_run`
        // reclaims a stale in_progress record without consulting `schema_version`; the one-time
        // pre-schema legacy cleanup lives only on the startup/periodic scan path
        // (`ScanAndRecoverAsync` / Python `_recover_stale_tasks`), which always runs first and
        // deletes any pre-schema record before an inline reclaim could observe it. Keeping the
        // gate here too would be a stricter-than-Python divergence with no observable benefit.

        // Foreign lease owner: live elsewhere — must not reclaim (spec §22 / _lease_is_dead).
        string? leaseOwner = record.Lease?.Owner;
        bool reclaimableByUs = string.IsNullOrEmpty(leaseOwner)
            || string.Equals(leaseOwner, _owner, StringComparison.Ordinal);
        if (!reclaimableByUs)
        {
            return null;
        }

        try
        {
            await registration.RecoverDispatch(this, record).ConfigureAwait(false);
        }
        catch (TaskStoreException)
        {
            // Lost the reclaim race to another process: same shape as "not active here".
            return null;
        }

        _activeRuns.TryGetValue(taskId, out IActiveRun? recovered);
        return recovered is not null
            && string.Equals(recovered.Name, name, StringComparison.Ordinal)
                ? recovered
                : null;
    }

    /// <summary>
    /// Resumes a persisted <c>in_progress</c> record (cold-start recovery), reclaiming the
    /// lease and re-invoking the handler with <see cref="EntryMode.Recovered"/>. No caller
    /// awaits the result; the run cleans up on terminal.
    /// </summary>
    /// <typeparam name="TInput">The task input type.</typeparam>
    /// <typeparam name="TOutput">The task output type.</typeparam>
    /// <param name="registration">The task registration.</param>
    /// <param name="record">The persisted record to resume.</param>
    /// <returns>A task that completes when recovery dispatch has started.</returns>
    internal async Task RecoverAsync<TInput, TOutput>(TaskRegistration registration, TaskRecord record)
    {
        var admission = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        if (!_pendingStarts.TryAdd(record.Id, admission))
        {
            // A start that has persisted its record but not yet published its run is not abandoned.
            return;
        }

        try
        {
            await RecoverCoreAsync<TInput, TOutput>(registration, record).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            FailStart(admission, exception);
            throw;
        }
        finally
        {
            ReleaseStart(record.Id, admission);
        }
    }

    private async Task RecoverCoreAsync<TInput, TOutput>(TaskRegistration registration, TaskRecord record)
    {
        string taskId = record.Id;
        if (_activeRuns.TryGetValue(taskId, out IActiveRun? existing))
        {
            EnsureTaskName(existing.Name, registration.Name, taskId);
            return;
        }

        if (_terminatedOneShot.ContainsKey(taskId))
        {
            return;
        }

        // The accepted head may name a queued input. Recover the identity paired with payload.input,
        // falling back to the legacy head only when no separate active identity was persisted.
        string inputId = TaskInputIdentity.Active(record, taskId);
        TInput input = ResolveInput<TInput>(record, registration);

        // FR-023a recovery mid-drain: if the crash happened after popping a steering input
        // but before the steered turn finished, re-enter the handler as a steered turn using
        // the persisted active_input rather than the prior turn's input.
        bool isSteeredTurn = false;
        if (record.Payload[TaskWireKeys.PayloadSteering] is JsonObject steering
            && steering[TaskWireKeys.SteeringDrainInProgress] is JsonValue drainFlag
            && drainFlag.TryGetValue(out bool draining)
            && draining)
        {
            JsonNode? activeSlot = steering[TaskWireKeys.SteeringActiveInput];
            JsonNode? resolved = AttachmentPromoter.Resolve(activeSlot, record.Attachments);
            if (resolved is not null)
            {
                input = DeserializeInput<TInput>(resolved, registration);
                isSteeredTurn = true;
            }
        }

        TaskRunState<TOutput> runState =
            CreateRunState<TOutput>(taskId, inputId, isQueued: false);
        runState.RecoveryCount = (int)(record.Lease?.Generation ?? 0);
        bool steerable = registration.Steerable;
        var activeRun = new ActiveRun<TOutput>(registration.Name, runState)
        {
            Steerable = steerable,
        };
        if (steerable && HasPersistedSteering(record))
        {
            SeedSteeringSeq(activeRun.Steering, record);
            RehydratePendingInputs(activeRun.Steering, record, taskId);
        }
        if (!_activeRuns.TryAdd(taskId, activeRun))
        {
            EnsureTaskName(_activeRuns[taskId].Name, registration.Name, taskId);
            return;
        }

        _serializer.Track(record);

        CancellationTokenSource handlerCts = runState.Cancellation.Source;

        try
        {
            // Reclaim the lease (same owner, new instance id, generation++ at the store).
            // Recovery reclaim must use WriteIntent.Reclaim so a 412 is treated as definitive race-loss
            // (abandon) instead of retrying like heartbeat writes.
            TaskRecord reclaimed = await _lease.ReclaimAsync(taskId, _owner, TaskEngineConstants.LeaseDurationSeconds).ConfigureAwait(false);
            // recovery_count mirrors the POST-reclaim lease generation (spec §22).
            runState.RecoveryCount = (int)(reclaimed.Lease?.Generation ?? runState.RecoveryCount);
            if (registration.MultiTurn)
            {
                await MigrateLegacyInputIdentityAsync(reclaimed, CancellationToken.None).ConfigureAwait(false);
            }
            // Operator-facing observability parity across runtimes: a crashed/
            // abandoned task's lease has just been taken over by this instance.
            _logger.StaleTaskReclaimed(taskId);
        }
        catch (Exception)
        {
            _activeRuns.TryRemove(taskId, out _);
            _serializer.Remove(taskId);
            runState.Cancellation.Retire();
            throw;
        }

        _logger.TaskRecovered(taskId, (int)(record.Lease?.Generation ?? 0));

        _ = Task.Run(
            () => ExecuteAsync(registration, runState, activeRun, input, taskId, inputId, EntryMode.Recovered, registration.MultiTurn, handlerCts, isSteeredTurn),
            CancellationToken.None);
    }

    /// <summary>
    /// Scans the store for this owner's <c>in_progress</c> tasks (filtered to the reserved
    /// framework <c>sourceType</c>) and re-invokes their handlers as recovered runs.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The number of tasks dispatched for recovery.</returns>
    internal async Task<int> ScanAndRecoverAsync(CancellationToken cancellationToken = default)
    {
        int dispatched = 0;
        var candidates = new List<TaskRecordRef>();
        string? after = null;
        do
        {
            TaskListResult listed = await _store.ListAsync(new TaskListQuery
            {
                AgentName = _agentName,
                SessionId = _sessionId,
                Status = TaskWireKeys.StatusInProgress,
                After = after,
            }, cancellationToken).ConfigureAwait(false);

            candidates.AddRange(listed.Items);
            after = listed.NextAfter;
        }
        while (after is not null);

        foreach (TaskRecordRef item in candidates)
        {
            TaskRecord record = item.Record;
            // Only dispatch records owned by this stable lease owner and stamped with our
            // reserved sourceType — never foreign records sharing the (agent, session) scope.
            if (record.Source?.Type != TaskWireKeys.SourceTypeValue)
            {
                continue;
            }

            // One-time legacy cleanup (spec §20/§38): a stale in_progress record that lacks
            // payload.schema_version is a pre-schema record with the old wire format and cannot
            // be recovered — delete it (force past the live lease) instead of re-invoking.
            // Key-presence check matches Python's `schema_version in payload`.
            if (record.Payload is not JsonObject scanPayload
                || !scanPayload.ContainsKey(TaskWireKeys.PayloadSchemaVersion))
            {
                try
                {
                    await _store.DeleteAsync(record.Id, force: true, cancellationToken: cancellationToken)
                        .ConfigureAwait(false);
                }
                catch (TaskStoreException)
                {
                    // Best-effort cleanup: a concurrent delete or transient failure is non-fatal.
                }

                continue;
            }

            if (record.Lease is not null && !string.Equals(record.Lease.Owner, _owner, StringComparison.Ordinal))
            {
                continue;
            }

            // Saved-state crash repair: close any stream this record retired (a promoted-away
            // predecessor or a cancelled queued input) before re-dispatching its live work. The
            // executing/queued inputs are excluded, so recovery of the live turn is unaffected. Skip
            // a task this process is already running: its live run owns its own close lifecycle.
            if (!_activeRuns.ContainsKey(record.Id))
            {
                await ReconcilePendingClosesAsync(record, cancellationToken).ConfigureAwait(false);
            }

            string name = record.Source?.Name ?? string.Empty;
            if (!_registry.TryGet(name, out TaskRegistration registration) || registration.RecoverDispatch is null)
            {
                continue;
            }

            try
            {
                await registration.RecoverDispatch(this, record).ConfigureAwait(false);
                dispatched++;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch (Exception ex)
            {
                // Per-record isolation: one malformed/faulting recovery candidate must not abort
                // the full sweep. The periodic durability loop retries this record on later scans.
                _logger.RecoveryScanFailed(ex.GetType().Name);
            }
        }

        // Saved-state crash repair for records that durably left in_progress: suspended chains whose
        // finished turn's stream close was interrupted, and completed one-shots whose ephemeral
        // delete was interrupted. These are reconciled (and completed records deleted) but never
        // re-dispatched, so the recovered work count reflects live work only.
        await ReconcileRetiredRecordsAsync(TaskWireKeys.StatusSuspended, deleteAfter: false, cancellationToken)
            .ConfigureAwait(false);
        await ReconcileRetiredRecordsAsync(TaskWireKeys.StatusCompleted, deleteAfter: true, cancellationToken)
            .ConfigureAwait(false);
        await ReconcileDeletionJournalAsync(cancellationToken).ConfigureAwait(false);

        return dispatched;
    }

    // Saved-state crash repair for hard deletions: a deleted record cannot carry a close intent, so
    // the intent was journaled durably before the provider delete. Entries this process is still
    // handling (live operations) are left to their in-process confirmed-delete/producer-unwind
    // coordination and never reconciled here. For a crash-orphaned entry, a confirmed-gone record has
    // its streams sealed (existing-only, idempotent) and the entry removed only when every close
    // succeeded; a still-present record is discarded without closing (uncommitted or reused-id delete
    // never seals a recoverable stream); an uncertain store read or a failed close leaves the entry
    // for a later scan.
    private async Task ReconcileDeletionJournalAsync(CancellationToken cancellationToken)
    {
        if (_streams is not ITaskEventStreamRegistry journal)
        {
            return;
        }

        foreach (PendingStreamDeletion pending in journal.ListPendingDeletions())
        {
            // A deletion this process is still handling owns its own close lifecycle; the sweep must
            // not close a stream whose producer is still unwinding, nor discard a live journal entry.
            if (_liveDeletions.ContainsKey(pending.OperationId))
            {
                continue;
            }

            TaskRecord? record;
            try
            {
                record = await _store.GetAsync(pending.TaskId, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskStoreException)
            {
                continue;
            }

            if (record is not null)
            {
                journal.RemovePendingDeletion(pending.TaskId, pending.OperationId);
                continue;
            }

            bool allClosed = true;
            foreach (string inputId in pending.InputIds)
            {
                try
                {
                    await new TaskStreamState(_streams, pending.TaskId, inputId).CloseAsync().ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    // The journal is the only durable reference to this orphan; retain it and retry
                    // on a later scan rather than removing it with a stream still open.
                    allClosed = false;
                    _logger.StreamCloseFailure(pending.TaskId, inputId, ex.GetType().Name);
                }
            }

            if (allClosed)
            {
                journal.RemovePendingDeletion(pending.TaskId, pending.OperationId);
            }
        }
    }

    internal CancellationToken ShutdownToken => _shutdownCts.Token;

    /// <summary>
    /// Signals cooperative shutdown to in-flight handlers (FR-017): the context's <c>Shutdown</c>
    /// token is signalled first (cause), then each active handler's cooperative cancellation token
    /// is cancelled so handlers blocked on <c>ctx.Cancellation</c> also wake and can release their
    /// leases for recovery before the process exits.
    /// </summary>
    internal void SignalShutdown()
    {
        SignalShutdownToken();
        CancelActiveHandlers();
    }

    /// <summary>Fires the shutdown cause (<c>ctx.Shutdown</c>) without waking handlers blocked on
    /// their cooperative token, so a handler polling <c>ctx.Shutdown</c> can checkpoint / exit-for-
    /// recovery on its own terms during the graceful-shutdown grace window.</summary>
    private void SignalShutdownToken()
    {
        if (!_shutdownCts.IsCancellationRequested)
        {
            _shutdownCts.Cancel();
        }
    }

    /// <summary>Wakes every in-flight handler by cancelling its cooperative token so a handler
    /// blocked on <c>ctx.Cancellation</c> unwinds and defers its turn for recovery.</summary>
    private void CancelActiveHandlers()
    {
        foreach (IActiveRun run in _activeRuns.Values)
        {
            run.CancelForShutdown();
        }
    }

    /// <summary>
    /// Graceful async shutdown (FR-017), mirroring Python's <c>TaskManager.shutdown()</c> so a
    /// restarted process reclaims in-flight work immediately instead of waiting the lease TTL:
    /// <list type="number">
    /// <item>signal the shutdown cause so cooperative handlers can <c>ExitForRecovery</c>;</item>
    /// <item>wait up to <paramref name="grace"/> for active turns to checkpoint (poll, not sleep);</item>
    /// <item>force-expire the leases of any turns still active after the grace window so their
    /// <c>in_progress</c> records are reclaimable at once (Python <c>lease_duration_seconds=0</c>);</item>
    /// <item>cancel the remaining handlers so they unwind and defer for recovery.</item>
    /// </list>
    /// The records stay <c>in_progress</c>; the next lifetime's cold-start scan / inline reclaim
    /// resumes them.
    /// </summary>
    /// <param name="grace">Maximum time to wait for in-flight turns to checkpoint before
    /// force-expiring their leases.</param>
    /// <param name="cancellationToken">A token that bounds the grace wait (e.g. the host's
    /// shutdown-timeout token); force-expiry still runs on cancellation.</param>
    internal async Task ShutdownAsync(TimeSpan grace, CancellationToken cancellationToken = default)
    {
        // (1) Fire the shutdown cause only — leave handlers running so they can cooperatively
        //     checkpoint / exit-for-recovery within the grace window.
        SignalShutdownToken();

        // (2) Wait up to `grace` for active turns to drain. Cooperative exits remove themselves
        //     from _activeRuns; poll so shutdown returns promptly once everything has checkpointed.
        if (!_activeRuns.IsEmpty)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            while (!_activeRuns.IsEmpty && sw.Elapsed < grace && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(50), cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        // (3) Force-expire the leases of turns that did not checkpoint in time so a restarted
        //     process (or another instance) reclaims the still-`in_progress` record immediately
        //     rather than waiting the lease TTL. This MUST run even if the host shutdown token has
        //     already fired (a cancelled token must not skip the write that makes recovery fast), so
        //     the release uses CancellationToken.None. Snapshot first: releasing must not depend on
        //     the handler still being registered when the write lands.
        IActiveRun[] stragglers = _activeRuns.Values.ToArray();
        foreach (IActiveRun run in stragglers)
        {
            try
            {
                await _lease.ReleaseAsync(run.TaskId, _owner, CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Best-effort: a lost race / transient store failure leaves the lease to lapse on
                // TTL. Never let one straggler block the shutdown of the others.
                _logger.LeaseForceExpireFailed(run.TaskId, ex.GetType().Name);
            }

            // Stop this turn's renewal loop right after force-expiry so a handler that ignores
            // cancellation cannot let renewal re-extend the lease before it unwinds (Python parity:
            // renewal tasks are cancelled after force-expiry).
            run.StopRenewal();
        }

        // (4) Wake the stragglers so they unwind and defer their turn (record stays in_progress).
        CancelActiveHandlers();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        SignalShutdown();
        _serializer.Dispose();
        _shutdownCts.Dispose();
    }

    private enum RunAdmission
    {
        Accepting,
        Suspended,
        Unavailable,
    }

    private interface IActiveRun
    {
        string Name { get; }

        string TaskId { get; }

        string InputId { get; }

        bool Steerable { get; }

        int SteeringCount { get; }

        bool DeleteRequested { get; }

        RunAdmission Admission { get; }

        Task RequestDeletionAsync(TaskDeletionState deletion);

        void CancelForShutdown();

        void StopRenewal();

        TaskRun<TOutput> GetHandle<TOutput>();
    }

    private sealed class ActiveRun<TOutput> : IActiveRun
    {
        private readonly object _gate = new();
        private TaskRunState<TOutput> _state;
        private TaskRunState<TOutput>? _promoting;
        private readonly HashSet<TaskRunState<TOutput>> _inputs = new();
        private TaskDeletionState? _deletion;
        private readonly TaskCompletionSource _producerStopped = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private RunAdmission _admission;

        public ActiveRun(string name, TaskRunState<TOutput> state)
        {
            Name = name;
            _state = state;
            _inputs.Add(state);
        }

        public string Name { get; }

        /// <summary>The in-process steering coordinator. Lazily created on first access so a
        /// non-steerable task never allocates a steering queue (pay-for-what-you-use, FR-038).
        /// Initialized atomically so concurrent steering starts converge on a single queue
        /// instead of racing and dropping an enqueue.</summary>
        public SteeringQueue<TOutput> Steering
        {
            get
            {
                SteeringQueue<TOutput>? existing = _steering;
                if (existing is not null)
                {
                    return existing;
                }

                var created = new SteeringQueue<TOutput>();
                return Interlocked.CompareExchange(ref _steering, created, null) ?? created;
            }
        }

        private SteeringQueue<TOutput>? _steering;

        /// <summary>Whether a steering queue has actually been allocated for this run.</summary>
        public bool HasSteering => _steering is not null;

        public bool Steerable { get; set; }

        public int SteeringCount => _steering?.Count ?? 0;

        /// <summary>Set by the executor to publish the pending-input count onto the live context state.</summary>
        public Action<int>? PublishPendingInputCount { get; set; }

        private int _deleteRequested;

        public bool DeleteRequested => Volatile.Read(ref _deleteRequested) != 0;

        public RunAdmission Admission
        {
            get { lock (_gate) { return _admission; } }
        }

        public void RetireAdmission(RunAdmission state, Action detach)
        {
            lock (_gate)
            {
                _admission = state;
                detach();
            }
        }

        public bool TrySnapshotEmpty(out JsonObject? steering)
        {
            lock (_gate)
            {
                if (DeleteRequested)
                {
                    throw CreateDeletingConflict(TaskId);
                }
                if (_admission != RunAdmission.Accepting)
                {
                    throw CreateUnavailableRunConflict(TaskId);
                }
                if (Steering.Count != 0)
                {
                    steering = null;
                    return false;
                }
                steering = Steering.HasState ? Steering.ToPayload() : null;
                return true;
            }
        }

        /// <summary>The current turn's lease-renewal cancellation source, published so graceful
        /// shutdown can stop renewal directly after force-expiring the lease (mirroring Python's
        /// "cancel renewal after force-expiry"), so a handler that ignores cancellation cannot let
        /// the renewal loop re-extend a lease we just force-expired. Cleared when the turn ends.</summary>
        public CancellationTokenSource? RenewalCts { get; set; }

        public string TaskId => _state.TaskId;

        public string InputId => _state.InputId;

        /// <summary>The handle for the currently-running (or most-recently-promoted) turn.</summary>
        public TaskRunState<TOutput> Current => _state;

        /// <summary>Swaps the live turn to a promoted (steered) input's handle.</summary>
        public void SetCurrent(TaskRunState<TOutput> state)
        {
            lock (_gate)
            {
                if (_state.ResultTask.IsCompleted)
                {
                    _inputs.Remove(_state);
                }
                _state = state;
                _inputs.Add(state);
                _promoting = null;
                _deletion?.Track(state.StreamState, state.InputId, _producerStopped.Task);
            }
        }

        public JsonObject Enqueue(QueuedInput<TOutput> input)
        {
            lock (_gate)
            {
                if (DeleteRequested)
                {
                    throw CreateDeletingConflict(TaskId);
                }
                if (_admission != RunAdmission.Accepting)
                {
                    throw CreateUnavailableRunConflict(TaskId);
                }
                Steering.Enqueue(input);
                _inputs.Add(input.RunState);
                return Steering.ToPayload();
            }
        }

        public JsonObject SnapshotSteering()
        {
            lock (_gate)
            {
                if (DeleteRequested)
                {
                    throw CreateDeletingConflict(TaskId);
                }
                return Steering.ToPayload();
            }
        }

        public void ForgetInput(TaskRunState<TOutput> state)
        {
            lock (_gate)
            {
                _inputs.Remove(state);
            }
        }

        public QueuedInput<TOutput>? PromoteNext()
        {
            lock (_gate)
            {
                if (DeleteRequested)
                {
                    return null;
                }
                QueuedInput<TOutput>? input = Steering.Promote();
                _promoting = input?.RunState;
                if (input is not null)
                {
                    _inputs.Add(input.RunState);
                }
                return input;
            }
        }

        public void AbandonPromotion(QueuedInput<TOutput> input)
        {
            lock (_gate)
            {
                if (ReferenceEquals(_promoting, input.RunState))
                {
                    _promoting = null;
                    Steering.CompleteDrain();
                }
                _inputs.Remove(input.RunState);
            }
            input.RunState.Cancellation.Retire();
        }

        /// <summary>
        /// Increments the running turn's pending-input count and then signals its cooperative
        /// cancellation token (cause-before-cancel ordering, C-CAN-2). A steering nudge does NOT
        /// set <c>CancelRequested</c>; the handler distinguishes it via a positive pending count.
        /// </summary>
        public async Task SignalSteeringAsync()
        {
            PublishPendingInputCount?.Invoke(Steering.Count);
            await CancelCurrentHandlerAsync().ConfigureAwait(false);
        }

        // Only steering follows turn transitions. An explicit handle cancellation always stays
        // bound to its own input. Both paths pin their source while callbacks run outside locks.
        private async Task CancelCurrentHandlerAsync()
        {
            TaskRunCancellation? signalled = null;
            while (true)
            {
                TaskRunCancellation current;
                lock (_gate)
                {
                    current = _state.Cancellation;
                }

                if (ReferenceEquals(current, signalled))
                {
                    return;
                }

                await current.SignalAsync().ConfigureAwait(false);
                signalled = current;
            }
        }

        public Task RequestDeletionAsync(TaskDeletionState deletion)
        {
            HashSet<TaskRunState<TOutput>> queued;
            TaskRunState<TOutput> current;
            lock (_gate)
            {
                if (DeleteRequested)
                {
                    return Task.CompletedTask;
                }

                Volatile.Write(ref _deleteRequested, 1);
                _deletion = deletion;
                current = _state;
                _deletion.Track(current.StreamState, current.InputId, _producerStopped.Task);
                queued = new HashSet<TaskRunState<TOutput>>(_inputs);
                queued.Remove(current);
                if (_promoting is { } promoting && !ReferenceEquals(promoting, current))
                {
                    queued.Add(promoting);
                }
                while (Steering.Promote() is { } pending)
                {
                    queued.Add(pending.RunState);
                }
                foreach (TaskRunState<TOutput> state in queued)
                {
                    _deletion.Track(state.StreamState, state.InputId,
                        ReferenceEquals(state, _promoting) ? _producerStopped.Task : Task.CompletedTask);
                }
                Steering.CompleteDrain();
            }

            foreach (TaskRunState<TOutput> state in queued)
            {
                state.SetException(new OperationCanceledException($"Task '{TaskId}' was cancelled before the queued input was promoted."));
            }
            return current.Cancellation.RequestAsync();
        }

        public Task ProducerUnwoundAsync()
        {
            lock (_gate)
            {
                _producerStopped.TrySetResult();
            }
            return Task.CompletedTask;
        }

        public Task RejectDeletedInputAsync(QueuedInput<TOutput> input)
        {
            TaskDeletionState deletion;
            bool isCurrent;
            lock (_gate)
            {
                deletion = _deletion ?? throw new InvalidOperationException("Deletion has not been requested.");
                isCurrent = ReferenceEquals(_state, input.RunState);
                if (Steering.Remove(input))
                {
                    deletion.Track(input.RunState.StreamState, input.InputId, Task.CompletedTask);
                }
            }
            if (!isCurrent)
            {
                input.RunState.SetException(new OperationCanceledException($"Task '{TaskId}' is being deleted."));
            }
            return deletion.CloseReadyAsync();
        }

        /// <summary>
        /// Wakes the running handler on graceful shutdown by signalling its cooperative
        /// cancellation token (FR-017). The shutdown cause is conveyed via the already-signalled
        /// <c>ctx.Shutdown</c> token, so this does NOT set the caller-cancel cause — a handler
        /// distinguishes shutdown from caller-cancel by inspecting <c>ctx.Shutdown</c>.
        /// </summary>
        public void CancelForShutdown()
        {
            try
            {
                TaskRunCancellation current;
                lock (_gate)
                {
                    current = _state.Cancellation;
                }

                current.Signal();
            }
            catch (AggregateException)
            {
                // A synchronous cancellation callback threw while we were waking the handler for
                // shutdown; the handler is already being torn down, so swallow on this path.
            }
        }

        /// <summary>
        /// Stops the current turn's lease-renewal loop (graceful shutdown, after force-expiry) so a
        /// handler that ignores cancellation cannot let renewal re-extend the lease we just
        /// force-expired. No-op once the turn has ended and cleared its renewal source.
        /// </summary>
        public void StopRenewal()
        {
            try
            {
                if (RenewalCts is { } cts && !cts.IsCancellationRequested)
                {
                    cts.Cancel();
                }
            }
            catch (ObjectDisposedException)
            {
                // The turn ended and disposed its renewal source concurrently; renewal already
                // stopped, so there is nothing left to cancel.
            }
            catch (AggregateException)
            {
                // A synchronous cancellation callback threw during teardown; swallow on this path.
            }
        }

        public TaskRun<TTarget> GetHandle<TTarget>()
        {
            if (_state is TaskRunState<TTarget> typed)
            {
                return typed.ToHandle();
            }

            throw new InvalidOperationException(
                $"Active run for task '{_state.TaskId}' has a different output type than requested.");
        }
    }
}
