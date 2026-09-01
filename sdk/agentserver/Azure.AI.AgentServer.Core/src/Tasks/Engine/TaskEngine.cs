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

        // In-process convergence. One-shot: a second start on an in-flight task returns the same
        // handle (idempotent converge). Multi-turn: an in-flight chain never attaches on a start —
        // it queues the input as the next steered turn (steerable) or conflicts (Python routes an
        // active steerable chain straight to the steering queue regardless of input_id; a
        // non-steerable active chain raises TaskConflictError). Attaching to a specific in-flight
        // turn is done explicitly via GetActiveRunAsync(name, taskId, inputId).
        if (_activeRuns.TryGetValue(taskId, out IActiveRun? existing))
        {
            if (existing.DeleteRequested)
            {
                throw CreateDeletingConflict(taskId);
            }

            if (!multiTurn)
            {
                return existing.GetHandle<TOutput>();
            }

            // A steerable chain queues a concurrent start as the next turn instead of rejecting it.
            if (existing.Steerable)
            {
                return await EnqueueSteeringAsync<TInput, TOutput>(existing, input, inputId, persistInputId, registration, cancellationToken)
                    .ConfigureAwait(false);
            }

            throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                $"Task '{taskId}' already has a turn in progress.")
            { CurrentStatus = TaskRunStatus.InProgress };
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
            if (current.Status == TaskWireKeys.StatusCompleted)
            {
                throw new ResilientTaskException(ResilientTaskErrorCode.Conflict,
                    $"Task '{taskId}' has already completed.")
                { CurrentStatus = TaskRunStatus.Completed };
            }

            // Not terminal: reclaim and re-invoke as a recovered run.
            record = current;
            entryMode = EntryMode.Recovered;
            inputId = (string?)current.Payload[TaskWireKeys.PayloadLastInputId] ?? inputId;
            input = ResolveInput<TInput>(current, registration);
        }

        TaskRunState<TOutput> runState =
            CreateRunState<TOutput>(taskId, inputId, isQueued: false);
        var activeRun = new ActiveRun<TOutput>(
            runState,
            exception => _logger.StreamCloseFailure(taskId, inputId, exception.GetType().Name));
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
            return _activeRuns[taskId].GetHandle<TOutput>();
        }

        var handlerCts = new CancellationTokenSource();
        activeRun.HandlerCts = handlerCts;

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
                handlerCts.Dispose();
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
                [TaskWireKeys.PayloadTurnStartedAt] = nowIso,
                [TaskWireKeys.PayloadSchemaVersion] = TaskWireKeys.SchemaVersionValue,
            };
            if (persistInputId)
            {
                payload[TaskWireKeys.PayloadLastInputId] = inputId;
            }
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
            entryMode = EntryMode.Fresh;
        }
        else
        {
            // ifLastInputId precondition (FR-006).
            if (options?.IfLastInputId is { } expected)
            {
                string? actual = (string?)current.Payload[TaskWireKeys.PayloadLastInputId];
                if (!string.Equals(actual, expected, StringComparison.Ordinal))
                {
                    throw new ResilientTaskException(ResilientTaskErrorCode.PreconditionFailed) { ActualLastInputId = actual };
                }
            }

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
                inputId = (string?)current.Payload[TaskWireKeys.PayloadLastInputId] ?? inputId;
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
        var activeRun = new ActiveRun<TOutput>(
            runState,
            exception => _logger.StreamCloseFailure(taskId, inputId, exception.GetType().Name))
        {
            Steerable = registration.Steerable,
        };
        if (registration.Steerable && HasPersistedSteering(record))
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
            return _activeRuns[taskId].GetHandle<TOutput>();
        }

        var handlerCts = new CancellationTokenSource();
        activeRun.HandlerCts = handlerCts;

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
            }

            // Fresh: the atomic create already established our lease — nothing more to acquire here.
        }
        catch (Exception ex)
        {
            _activeRuns.TryRemove(taskId, out _);
            _serializer.Remove(taskId);
            handlerCts.Dispose();
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
        QueuedInput<TOutput> queued,
        TaskRunState<TOutput> runState)
    {
        if (!run.DeleteRequested)
        {
            return;
        }

        run.Steering.Remove(queued);
        await CloseStreamAsync(runState).ConfigureAwait(false);
        throw CreateDeletingConflict(run.TaskId);
    }

    private static ResilientTaskException CreateDeletingConflict(string taskId)
        => new(ResilientTaskErrorCode.Conflict, $"Task '{taskId}' is being deleted.")
        {
            CurrentStatus = TaskRunStatus.InProgress,
        };

    // Patches the next-turn input + ids + re-stamps _turn_started_at, clears the prior
    // turn's retry counter, and re-acquires the lease (→ in_progress) in one write.
    private Task<TaskRecord> DriveTurnAsync(
        string taskId, JsonNode? inputSlot, string inputId, bool persistInputId, JsonObject? attachments, string nowIso,
        CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            [TaskWireKeys.PayloadInput] = inputSlot,
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
    private async Task<TaskRun<TOutput>> EnqueueSteeringAsync<TInput, TOutput>(
        IActiveRun existing, TInput input, string inputId, bool persistInputId, TaskRegistration registration, CancellationToken cancellationToken)
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
        var queued = new QueuedInput<TOutput>(inputSlot, inputAttachments, inputId, persistInputId, runState);

        // A queued caller can cancel before promotion: drop the slot, re-persist the trimmed
        // queue, and resolve the handle as cancelled. If the slot was already promoted/drained,
        // Remove returns false and we route to the active-turn cancel path — either immediately
        // (if the promoted turn is already current) or deferred until SetCurrent rewires it, so a
        // cancel arriving inside the promotion window is never silently dropped.
        runState.Cancel = async () =>
        {
            if (!run.Steering.Remove(queued))
            {
                await run.CancelPromotedAsync(runState).ConfigureAwait(false);
                return;
            }

            await _serializer.UpdateAsync(
                taskId,
                _ => new TaskPatchRequest
                {
                    Payload = new JsonObject { [TaskWireKeys.PayloadSteering] = run.Steering.ToPayload() },
                    PayloadSupplied = true,
                    // Delete this cancelled input's promoted attachment (if any) in the same trim
                    // PATCH so a cancelled oversized input never leaves an orphan (Python parity:
                    // _cancel_queued_steering_input nulls the _steering_input_<seq> attachment).
                    Attachments = DeletionPatch(queued.Attachments),
                },
                WriteIntent.SteeringAppend,
                CancellationToken.None).ConfigureAwait(false);

            await CloseStreamAsync(runState).ConfigureAwait(false);
            runState.SetException(new OperationCanceledException(
                $"Task '{taskId}' input '{inputId}' was cancelled before the queued input was promoted."));
        };

        // Capacity is enforced here (throws ResilientTaskException/QueueFull before any persist).
        run.Steering.Enqueue(queued);
        await RejectQueuedInputIfDeletingAsync(run, queued, runState).ConfigureAwait(false);

        try
        {
            await _serializer.UpdateAsync(
                taskId,
                _ => new TaskPatchRequest
                {
                    Payload = new JsonObject { [TaskWireKeys.PayloadSteering] = run.Steering.ToPayload() },
                    PayloadSupplied = true,
                    // Persist the promoted attachment (if any) atomically with the queue append so a
                    // crash after this PATCH can still resolve the ref (Python parity).
                    Attachments = queued.Attachments,
                },
                WriteIntent.SteeringAppend,
                cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            run.Steering.Remove(queued);
            throw;
        }

        await RejectQueuedInputIfDeletingAsync(run, queued, runState).ConfigureAwait(false);

        // Cause-before-cancel (C-CAN-2): bump the pending count, then nudge the running turn.
        await run.SignalSteeringAsync().ConfigureAwait(false);

        return runState.ToHandle();
    }

    // Promotes a queued steering input into the next turn: pops the FIFO head, advances
    // next_input_seq, re-stamps _turn_started_at, resets the retry counter, clears the
    // drain markers, and re-acquires the lease (→ in_progress) in one write.
    private async Task<(QueuedInput<TOutput> Input, string NowIso)?> DriveSteeredTurnAsync<TOutput>(
        ActiveRun<TOutput> run, CancellationToken cancellationToken)
    {
        if (run.Steering.Promote() is not { } queued)
        {
            return null;
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
        JsonObject steeringPayload = run.Steering.ToPayload();

        var payload = new JsonObject();
        payload[TaskWireKeys.PayloadInput] = rawValue?.DeepClone();
        if (queued.PersistInputId)
        {
            payload[TaskWireKeys.PayloadLastInputId] = queued.InputId;
        }
        payload[TaskWireKeys.PayloadTurnStartedAt] = nowIso;
        payload[TaskWireKeys.PayloadRetryAttempt] = null;
        payload[TaskWireKeys.PayloadSteering] = steeringPayload;

        await _serializer.UpdateAsync(
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
                TurnOutcome<TOutput> outcome = await RunTurnAsync(
                    registration, handler, scopedHandler, retry, activeRun, currentRun, currentInput, taskId, currentInputId,
                    currentMode, steered, TaskEngineConstants.ResolveTaskTimeout(registration.Options?.Timeout), currentCts).ConfigureAwait(false);

                if (activeRun.DeleteRequested)
                {
                    await CompleteDeletedRunAsync(taskId, multiTurn, currentRun).ConfigureAwait(false);
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
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
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
                    (QueuedInput<TOutput> Input, string NowIso)? cancelDrained =
                        await DriveSteeredTurnAsync(activeRun, CancellationToken.None).ConfigureAwait(false);

                    if (cancelDrained is { } cancelPromotion)
                    {
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
                        currentRun.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));

                        var nextCts = new CancellationTokenSource();
                        currentRun = cancelPromotion.Input.RunState;
                        currentInput = cancelPromotion.Input.Slot is null
                            ? default!
                            : DeserializeInput<TInput>(cancelPromotion.Input.Slot, registration);
                        currentInputId = cancelPromotion.Input.InputId;
                        currentMode = EntryMode.Resumed;
                        steered = true;

                        activeRun.SetCurrent(currentRun);
                        activeRun.HandlerCts = nextCts;
                        currentCts.Dispose();
                        currentCts = nextCts;
                        continue;
                    }

                    bool suspended = false;
                    try
                    {
                        await SuspendAsync(taskId, activeRun.Steering.HasState ? activeRun.Steering.ToPayload() : null, CancellationToken.None).ConfigureAwait(false);
                        suspended = true;
                    }
                    catch (Exception suspendEx)
                    {
                        _logger.HandlerFailure(taskId, 0, suspendEx.GetType().Name);
                    }

                    if (suspended)
                    {
                        await CloseStreamAsync(currentRun).ConfigureAwait(false);
                    }

                    FinishTurn(taskId, multiTurn);
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
                (QueuedInput<TOutput> Input, string NowIso)? drained =
                    await DriveSteeredTurnAsync(activeRun, CancellationToken.None).ConfigureAwait(false);

                if (drained is { } promotion)
                {
                    await CloseStreamAsync(currentRun).ConfigureAwait(false);
                    ResolveOutcome(currentRun, outcome);

                    var nextCts = new CancellationTokenSource();
                    currentRun = promotion.Input.RunState;
                    currentInput = promotion.Input.Slot is null
                        ? default!
                        : DeserializeInput<TInput>(promotion.Input.Slot, registration);
                    currentInputId = promotion.Input.InputId;
                    currentMode = EntryMode.Resumed;
                    steered = true;

                    activeRun.SetCurrent(currentRun);
                    activeRun.HandlerCts = nextCts;
                    currentCts.Dispose();
                    currentCts = nextCts;
                    continue;
                }

                // No queued input: park the chain at suspended (a per-turn raise persists NO
                // error per FR-007/AS-6) and surface the outcome to the caller.
                try
                {
                    await SuspendAsync(taskId, activeRun.Steering.HasState ? activeRun.Steering.ToPayload() : null, CancellationToken.None).ConfigureAwait(false);
                }
                catch (Exception suspendEx)
                {
                    // Durable suspend failed: the record stays in_progress, so a recovery scan could
                    // re-run this turn. Surface the failure rather than reporting the turn outcome as
                    // durably suspended.
                    _logger.HandlerFailure(taskId, 0, suspendEx.GetType().Name);
                    FinishTurn(taskId, multiTurn);
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

                await CloseStreamAsync(currentRun).ConfigureAwait(false);
                FinishTurn(taskId, multiTurn);
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

                await CompleteDeletedRunAsync(taskId, multiTurn, currentRun).ConfigureAwait(false);
                return;
            }

            FinishTurn(taskId, multiTurn);
            currentRun.SetException(fatal);
        }
        finally
        {
            currentCts.Dispose();
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
        activeRun.PublishCancelCause = () => ctxState.CancelRequested = true;
        activeRun.PublishPendingInputCount = count => ctxState.PendingInputCount = count;

        // Reconcile any cause that landed between this turn's launch and the publisher wiring:
        // a steering nudge bumps the count, an explicit cancel sets CancelRequested. Mirrors the
        // line-628 snapshot but closes the start-up race so neither cause is silently dropped.
        ctxState.PendingInputCount = activeRun.SteeringCount;
        if (activeRun.CancelRequested)
        {
            ctxState.CancelRequested = true;
            handlerCts.Cancel();
        }

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
            _ => new TaskPatchRequest { Status = TaskWireKeys.StatusCompleted },
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
    private async Task SuspendAsync(
        string taskId, JsonObject? steeringPayload, CancellationToken cancellationToken)
    {
        var payload = new JsonObject
        {
            [TaskWireKeys.PayloadInput] = null,
            [TaskWireKeys.PayloadRetryAttempt] = null,
        };
        if (steeringPayload is not null)
        {
            payload[TaskWireKeys.PayloadSteering] = steeringPayload;
        }

        await _serializer.UpdateAsync(
            taskId,
            _ => new TaskPatchRequest
            {
                Status = TaskWireKeys.StatusSuspended,
                SuspensionReason = TaskWireKeys.SuspensionReasonRunCompletion,
                Payload = payload,
                PayloadSupplied = true,
                Attachments = new JsonObject { [AttachmentPromoter.InputAttachmentKey] = null },
            },
            WriteIntent.Suspend,
            cancellationToken).ConfigureAwait(false);
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
        TaskRecord? record = await _store.GetAsync(taskId, cancellationToken).ConfigureAwait(false);
        if (expectedTaskName is not null)
        {
            if (record is not null
                && !string.Equals(record.Source?.Name, expectedTaskName, StringComparison.Ordinal))
            {
                throw new ResilientTaskException(
                    ResilientTaskErrorCode.Conflict,
                    $"Task '{taskId}' belongs to registered task '{record.Source?.Name ?? string.Empty}', " +
                    $"not '{expectedTaskName}'.");
            }
        }

        // Cancel an in-flight turn and resolve its caller as cancelled.
        _activeRuns.TryGetValue(taskId, out IActiveRun? run);
        if (run is not null)
        {
            run.RequestDeletion();
            await run.CancelAsync().ConfigureAwait(false);
        }

        _serializer.Remove(taskId);

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

        if (run is not null)
        {
            // The executor normally owns active-stream closure after the handler unwinds. If it
            // detached this exact run while deletion was acquiring it, the handler has already
            // unwound and the delete path must close the captured stream instead.
            if (!_activeRuns.TryGetValue(taskId, out IActiveRun? current)
                || !ReferenceEquals(current, run))
            {
                try
                {
                    await run.CloseCurrentStreamAsync().ConfigureAwait(false);
                }
                catch (Exception closeException)
                {
                    _logger.StreamCloseFailure(
                        taskId,
                        run.InputId,
                        closeException.GetType().Name);
                }
            }
        }
        else if (record?.Payload[TaskWireKeys.PayloadLastInputId] is JsonValue inputIdNode
            && inputIdNode.TryGetValue(out string? inputId)
            && !string.IsNullOrEmpty(inputId))
        {
            await ClosePersistedStreamAsync(taskId, inputId).ConfigureAwait(false);
        }
    }

    private async Task CompleteDeletedRunAsync<TOutput>(
        string taskId,
        bool multiTurn,
        TaskRunState<TOutput> runState)
    {
        await CloseStreamAsync(runState).ConfigureAwait(false);
        FinishTurn(taskId, multiTurn);
        runState.SetException(new OperationCanceledException($"Task '{taskId}' was cancelled."));
    }

    private void FinishTurn(string taskId, bool multiTurn)
    {
        _activeRuns.TryRemove(taskId, out _);
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

    private async Task CloseStreamAsync<TOutput>(TaskRunState<TOutput> runState)
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
        }
    }

    private async Task ClosePersistedStreamAsync(string taskId, string inputId)
    {
        try
        {
            AgentEventStream? stream;
            if (_streams is ITaskEventStreamRegistry taskRegistry)
            {
                stream = await taskRegistry
                    .GetTaskStreamAsync(taskId, inputId, CancellationToken.None)
                    .ConfigureAwait(false);
            }
            else
            {
                try
                {
                    stream = await _streams
                        .GetAsync(inputId, CancellationToken.None)
                        .ConfigureAwait(false);
                }
                catch (AgentEventStreamNotFoundException)
                {
                    stream = null;
                }
            }

            if (stream is null)
            {
                return;
            }

            await stream.CloseAsync(CancellationToken.None).ConfigureAwait(false);
        }
        catch (Exception closeException)
        {
            _logger.StreamCloseFailure(taskId, inputId, closeException.GetType().Name);
        }
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
    // recovered turn keeps its `ctx.InputId` and advances `last_input_id` exactly as it would have
    // without a crash (recovery is transparent). When that array is absent or length-mismatched (an
    // older or cross-language record that only persisted slots) the recovered turn falls back to
    // inheriting the current `last_input_id` without advancing it.
    private void RehydratePendingInputs<TOutput>(SteeringQueue<TOutput> queue, TaskRecord record, string taskId)
    {
        if (record.Payload[TaskWireKeys.PayloadSteering] is not JsonObject steering
            || steering[TaskWireKeys.SteeringPendingInputs] is not JsonArray pending
            || pending.Count == 0)
        {
            return;
        }

        string inheritedInputId = string.Empty;
        if (record.Payload[TaskWireKeys.PayloadLastInputId] is JsonValue idValue
            && idValue.TryGetValue(out string? persistedId)
            && persistedId is not null)
        {
            inheritedInputId = persistedId;
        }

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
                // The durably-persisted per-turn id: restore it and re-enable the chain-head advance
                // so the recovered turn is indistinguishable from the non-crash drain.
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

        if (_activeRuns.TryGetValue(taskId, out IActiveRun? run))
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
        if (record.Source?.Type != TaskWireKeys.SourceTypeValue)
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
        return recovered;
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
        string taskId = record.Id;
        if (_activeRuns.ContainsKey(taskId) || _terminatedOneShot.ContainsKey(taskId))
        {
            return;
        }

        // On recovery, reconstruct context.input_id from the persisted last_input_id, defaulting to
        // the task_id when absent (Python parity: `input_id=(payload or {}).get("last_input_id")`
        // with TaskContext defaulting a missing id to task_id). Never fabricate an input-<guid>.
        string inputId = (string?)record.Payload[TaskWireKeys.PayloadLastInputId] ?? taskId;
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
        var activeRun = new ActiveRun<TOutput>(
            runState,
            exception => _logger.StreamCloseFailure(taskId, inputId, exception.GetType().Name))
        {
            Steerable = registration.Steerable,
        };
        if (registration.Steerable && HasPersistedSteering(record))
        {
            SeedSteeringSeq(activeRun.Steering, record);
            RehydratePendingInputs(activeRun.Steering, record, taskId);
        }
        if (!_activeRuns.TryAdd(taskId, activeRun))
        {
            return;
        }

        _serializer.Track(record);

        var handlerCts = new CancellationTokenSource();
        activeRun.HandlerCts = handlerCts;

        try
        {
            // Reclaim the lease (same owner, new instance id, generation++ at the store).
            // Recovery reclaim must use WriteIntent.Reclaim so a 412 is treated as definitive race-loss
            // (abandon) instead of retrying like heartbeat writes.
            TaskRecord reclaimed = await _lease.ReclaimAsync(taskId, _owner, TaskEngineConstants.LeaseDurationSeconds).ConfigureAwait(false);
            // recovery_count mirrors the POST-reclaim lease generation (spec §22).
            runState.RecoveryCount = (int)(reclaimed.Lease?.Generation ?? runState.RecoveryCount);
            // Operator-facing observability parity across runtimes: a crashed/
            // abandoned task's lease has just been taken over by this instance.
            _logger.StaleTaskReclaimed(taskId);
        }
        catch (Exception)
        {
            _activeRuns.TryRemove(taskId, out _);
            _serializer.Remove(taskId);
            handlerCts.Dispose();
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

        return dispatched;
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

    private interface IActiveRun
    {
        string TaskId { get; }

        string InputId { get; }

        bool Steerable { get; }

        int SteeringCount { get; }

        bool DeleteRequested { get; }

        void RequestDeletion();

        Task CancelAsync();

        Task CloseCurrentStreamAsync();

        void CancelForShutdown();

        void StopRenewal();

        TaskRun<TOutput> GetHandle<TOutput>();
    }

    private sealed class ActiveRun<TOutput> : IActiveRun
    {
        private readonly object _gate = new();
        private readonly Action<Exception> _streamCloseFailed;
        private TaskRunState<TOutput> _state;
        private TaskRunState<TOutput>? _pendingCancel;

        public ActiveRun(
            TaskRunState<TOutput> state,
            Action<Exception> streamCloseFailed)
        {
            _state = state;
            _streamCloseFailed = streamCloseFailed;
            WireCancel(state);
        }

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

        /// <summary>Set by the executor to publish the cancel cause onto the live context state.</summary>
        public Action? PublishCancelCause { get; set; }

        /// <summary>Set by the executor to publish the pending-input count onto the live context state.</summary>
        public Action<int>? PublishPendingInputCount { get; set; }

        /// <summary>Whether a cancel was requested (honored even if it raced the executor launch).</summary>
        public volatile bool CancelRequested;

        private int _deleteRequested;

        public bool DeleteRequested => Volatile.Read(ref _deleteRequested) != 0;

        public CancellationTokenSource? HandlerCts { get; set; }

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
            bool honorPending;
            lock (_gate)
            {
                _state = state;
                WireCancel(state);
                honorPending = ReferenceEquals(_pendingCancel, state);
                if (honorPending)
                {
                    _pendingCancel = null;
                }
            }

            // A queued caller that cancelled inside the promotion window (after its slot was
            // popped but before this rewire) is honored now via the active-turn cancel path.
            if (honorPending)
            {
                _ = state.RequestCancellationAsync();
            }
        }

        /// <summary>
        /// Routes a cancel for an already-promoted input to the active-turn cancel path. If the
        /// promoted handle is already current it cancels immediately; otherwise the cancel is
        /// deferred until <see cref="SetCurrent"/> rewires it (closing the promotion-window race).
        /// </summary>
        public Task CancelPromotedAsync(TaskRunState<TOutput> state)
        {
            lock (_gate)
            {
                if (!ReferenceEquals(_state, state))
                {
                    _pendingCancel = state;
                    return Task.CompletedTask;
                }
            }

            return state.RequestCancellationAsync();
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

        // Cancels the current turn's cooperative token, re-signalling across any concurrent turn
        // transition that swaps HandlerCts. Reading the source once and cancelling it lets a
        // transition install a NEW source in between, leaving the turn that is now current
        // unsignalled — so a steering nudge or cancel could complete against a superseded (and maybe
        // disposed) source while the running handler never wakes. Re-read after each cancel and
        // signal the replacement too, until the source is unchanged; bounded by the finite number of
        // turn transitions.
        private async Task CancelCurrentHandlerAsync()
        {
            CancellationTokenSource? signalled = null;
            while (HandlerCts is { } cts && !ReferenceEquals(cts, signalled))
            {
                try
                {
                    await cts.CancelAsync().ConfigureAwait(false);
                }
                catch (ObjectDisposedException)
                {
                    // This source was replaced and disposed by a concurrent transition after we read
                    // it; loop to signal the source that replaced it (the now-current turn).
                }

                signalled = cts;
            }
        }

        public async Task CancelAsync()
        {
            // Resolve every still-queued caller as cancelled, then cancel the active turn.
            await DrainQueuedAsCancelledAsync().ConfigureAwait(false);
            await _state.RequestCancellationAsync().ConfigureAwait(false);
        }

        public void RequestDeletion() => Interlocked.Exchange(ref _deleteRequested, 1);

        public Task CloseCurrentStreamAsync()
            => _state.StreamState.CloseAsync().AsTask();

        /// <summary>
        /// Wakes the running handler on graceful shutdown by signalling its cooperative
        /// cancellation token (FR-017). The shutdown cause is conveyed via the already-signalled
        /// <c>ctx.Shutdown</c> token, so this does NOT set <see cref="CancelRequested"/> — a handler
        /// distinguishes shutdown from caller-cancel by inspecting <c>ctx.Shutdown</c>.
        /// </summary>
        public void CancelForShutdown()
        {
            try
            {
                if (HandlerCts is { } cts && !cts.IsCancellationRequested)
                {
                    cts.Cancel();
                }
            }
            catch (ObjectDisposedException)
            {
                // The turn completed and disposed its token source concurrently with shutdown
                // signalling; there is nothing left to wake. Teardown must not surface this race.
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

        private async Task DrainQueuedAsCancelledAsync()
        {
            while (Steering.Promote() is { } promoted)
            {
                promoted.RunState.SetException(
                    new OperationCanceledException($"Task '{TaskId}' was cancelled before the queued input was promoted."));
                try
                {
                    await promoted.RunState.StreamState.CloseAsync().ConfigureAwait(false);
                }
                catch (Exception closeException)
                {
                    _streamCloseFailed(closeException);
                }

                Steering.CompleteDrain();
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

        private void WireCancel(TaskRunState<TOutput> state)
        {
            state.Cancel = async () =>
            {
                // Publish the cause before signalling the token so a handler that wakes on
                // cancellation always observes CancelRequested (C-CAN-2 ordering).
                CancelRequested = true;
                PublishCancelCause?.Invoke();
                await CancelCurrentHandlerAsync().ConfigureAwait(false);
            };
        }
    }
}
