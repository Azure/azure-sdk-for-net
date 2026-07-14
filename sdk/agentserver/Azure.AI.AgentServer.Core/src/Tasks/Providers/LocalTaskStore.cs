// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>
/// Filesystem-backed task store for local development. Persists each task as a
/// JSON file under <c>&lt;stateRoot&gt;/tasks/&lt;agent&gt;/&lt;session&gt;/&lt;task&gt;.json</c>
/// (<c>stateRoot</c> defaults to <c>~/.agentserver</c>, overridable via
/// <c>AGENTSERVER_STATE_ROOT</c>) and reproduces the hosted protocol's lease,
/// ETag, validation, patch-merge, and status side-effects so the full framework
/// is testable with no hosted deployment (FR-019a / SC-011).
/// </summary>
internal sealed class LocalTaskStore : ITaskStore
{
    private readonly string _baseDir;

    /// <summary>Initializes a new instance of the <see cref="LocalTaskStore"/> class.</summary>
    /// <param name="baseDir">Override for the <c>tasks</c> root directory; resolved from config when null.</param>
    public LocalTaskStore(string? baseDir = null)
    {
        _baseDir = baseDir ?? AgentServerStatePaths.TasksRoot();
    }

    private string TaskDir(string agentName, string sessionId) => Path.Combine(_baseDir, agentName, sessionId);

    private string TaskPath(string agentName, string sessionId, string taskId)
        => Path.Combine(TaskDir(agentName, sessionId), taskId + ".json");

    private string? FindTaskPath(string taskId)
    {
        if (!Directory.Exists(_baseDir))
        {
            return null;
        }

        foreach (var agentDir in Directory.EnumerateDirectories(_baseDir))
        {
            foreach (var sessionDir in Directory.EnumerateDirectories(agentDir))
            {
                var path = Path.Combine(sessionDir, taskId + ".json");
                if (File.Exists(path))
                {
                    return path;
                }
            }
        }

        return null;
    }

    private static TaskRecord? ReadTask(string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }

        try
        {
            var text = File.ReadAllText(path, Encoding.UTF8);
            var node = JsonNode.Parse(text);
            return node is JsonObject obj ? TaskRecord.FromJson(obj) : null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private void WriteTask(TaskRecord task)
    {
        var dir = TaskDir(task.AgentName, task.SessionId);
        Directory.CreateDirectory(dir);
        task.Etag = GenerateEtag(task);
        var json = task.ToJson().ToJsonString(new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(TaskPath(task.AgentName, task.SessionId, task.Id), json, new UTF8Encoding(false));
    }

    private static string GenerateEtag(TaskRecord task)
    {
        // Self-consistent provider-internal token over the record (excluding the
        // etag itself), computed from canonical bytes.
        var obj = task.ToJson();
        obj.Remove(TaskWireKeys.Etag);
        var element = JsonSerializer.SerializeToElement(obj);
        var bytes = CanonicalJson.SerializeToUtf8Bytes(element);
        var hex = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        return "local-" + hex[..16];
    }

    private static string NowIso() => DateTimeOffset.UtcNow.ToString("o", CultureInfo.InvariantCulture);

    private static string ExpiresAt(int durationSeconds)
        => DateTimeOffset.UtcNow.AddSeconds(durationSeconds).ToString("o", CultureInfo.InvariantCulture);

    private static bool IsLeaseExpired(Lease? lease)
    {
        if (lease is null || string.IsNullOrEmpty(lease.ExpiresAt))
        {
            return true;
        }

        return !DateTimeOffset.TryParse(
                   lease.ExpiresAt, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var expires)
               || DateTimeOffset.UtcNow >= expires;
    }

    private static bool LeaseMatches(Lease? lease, string owner, string instanceId)
        => lease is not null && lease.Owner == owner && lease.InstanceId == instanceId;

    /// <inheritdoc/>
    public Task<TaskRecord> CreateAsync(TaskCreateRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(request);

        string now = NowIso();
        string taskId = request.Id ?? ("task-" + Convert.ToHexString(RandomNumberGenerator.GetBytes(8)).ToLowerInvariant());

        TaskRecordValidation.ValidateTaskId(taskId);
        TaskRecordValidation.ValidateRequiredString(request.AgentName, TaskWireKeys.AgentName, TaskRecordValidation.MaxAgentNameLen, taskId);
        TaskRecordValidation.ValidateRequiredString(request.SessionId, TaskWireKeys.SessionId, TaskRecordValidation.MaxSessionIdLen, taskId);
        TaskRecordValidation.ValidateRequiredString(request.Title, TaskWireKeys.Title, TaskRecordValidation.MaxTitleLen, taskId);
        TaskRecordValidation.ValidateOptionalString(request.Description, TaskWireKeys.Description, TaskRecordValidation.MaxDescriptionLen, taskId);
        TaskRecordValidation.ValidateTags(request.Tags, taskId);
        TaskRecordValidation.ValidatePayloadSize(request.Payload, taskId);
        TaskRecordValidation.ValidateSource(request.Source, taskId);
        TaskRecordValidation.ValidateAttachments(request.Attachments, taskId);

        string status = TaskRecordValidation.ValidateCreateStatus(request.Status, taskId);
        var leaseRequest = TaskRecordValidation.ValidateLeaseParams(
            request.LeaseOwner, request.LeaseInstanceId, request.LeaseDurationSeconds, taskId);

        if (status == TaskWireKeys.StatusPending && leaseRequest is not null)
        {
            throw TaskStoreException.InvalidRequest(
                "Lease parameters must not be provided when status is pending.", taskId);
        }

        if (FindTaskPath(taskId) is not null)
        {
            throw new TaskStoreException(
                TaskStoreException.CodeTaskAlreadyExists, 409, $"Task '{taskId}' already exists.", taskId);
        }

        Lease? lease = null;
        string? startedAt = null;
        string? completedAt = status == TaskWireKeys.StatusCompleted ? now : null;

        if (leaseRequest is not null)
        {
            var (owner, instanceId, duration) = leaseRequest.Value;
            lease = new Lease
            {
                Owner = owner,
                InstanceId = instanceId,
                Generation = 0,
                ExpiresAt = ExpiresAt(duration),
                ExpiryCount = 0,
                HeartbeatAt = now,
            };
            if (status == TaskWireKeys.StatusInProgress)
            {
                startedAt = now;
            }
        }

        var record = new TaskRecord
        {
            Id = taskId,
            AgentName = request.AgentName,
            SessionId = request.SessionId,
            Status = status,
            Title = request.Title,
            Description = request.Description,
            Lease = lease,
            Payload = request.Payload ?? new JsonObject(),
            Source = request.Source is null ? null : Source.FromJson(request.Source),
            Attachments = NonNullAttachments(request.Attachments),
            CreatedAt = now,
            UpdatedAt = now,
            StartedAt = startedAt,
            CompletedAt = completedAt,
        };

        if (request.Tags is not null)
        {
            foreach (var kvp in request.Tags)
            {
                record.Tags[kvp.Key] = kvp.Value;
            }
        }

        WriteTask(record);
        return Task.FromResult(record);
    }

    private static JsonObject? NonNullAttachments(JsonObject? attachments)
    {
        if (attachments is null)
        {
            return null;
        }

        var result = new JsonObject();
        foreach (var kvp in attachments)
        {
            if (kvp.Value is not null)
            {
                result[kvp.Key] = kvp.Value.DeepClone();
            }
        }

        return result.Count > 0 ? result : null;
    }

    /// <inheritdoc/>
    public Task<TaskRecord?> GetAsync(string taskId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var path = FindTaskPath(taskId);
        return Task.FromResult(path is null ? null : ReadTask(path));
    }

    /// <inheritdoc/>
    public Task<TaskRecord> PatchAsync(string taskId, TaskPatchRequest patch, string? ifMatch, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(patch);

        var path = FindTaskPath(taskId);
        var task = path is null ? null : ReadTask(path);
        if (task is null)
        {
            throw new TaskStoreException(TaskStoreException.CodeTaskNotFound, 404, $"Task '{taskId}' not found.", taskId);
        }

        if (ifMatch is not null && ifMatch != task.Etag)
        {
            throw TaskStoreException.EtagMismatch(taskId);
        }

        string? normalizedStatus = TaskRecordValidation.ValidatePatchStatus(patch.Status, taskId);
        var leaseRequest = TaskRecordValidation.ValidateLeaseParams(
            patch.LeaseOwner, patch.LeaseInstanceId, patch.LeaseDurationSeconds, taskId);

        TaskRecordValidation.ValidateError(patch.Error, taskId);
        TaskRecordValidation.ValidateOptionalString(patch.SuspensionReason, TaskWireKeys.SuspensionReason, TaskRecordValidation.MaxSuspensionReasonLen, taskId);

        if (patch.ClearAllAttachments && patch.Attachments is not null)
        {
            throw TaskStoreException.InvalidRequest("Clear-all attachments cannot be combined with an attachments patch.", taskId);
        }

        string targetStatus = normalizedStatus ?? task.Status;
        if (patch.SuspensionReason is not null && targetStatus != TaskWireKeys.StatusSuspended)
        {
            throw TaskStoreException.InvalidRequest("suspension_reason is only allowed when target status is suspended.", taskId);
        }

        // Terminal immutability with same-status no-op.
        if (task.Status == TaskWireKeys.StatusCompleted)
        {
            if (PatchIsCompletedNoop(patch, normalizedStatus, leaseRequest))
            {
                return Task.FromResult(task);
            }

            throw new TaskStoreException("task_immutable", 409, "Completed tasks are immutable.", taskId);
        }

        bool statusChange = normalizedStatus is not null && normalizedStatus != task.Status;
        if (statusChange)
        {
            TaskRecordValidation.ValidateTransition(task.Status, targetStatus, taskId);
        }

        ValidateLeaseRules(task, targetStatus, statusChange, leaseRequest);

        string now = NowIso();
        if (statusChange)
        {
            task.Status = targetStatus;
            if (targetStatus == TaskWireKeys.StatusPending)
            {
                task.Lease = null;
                task.SuspensionReason = null;
            }
            else if (targetStatus == TaskWireKeys.StatusInProgress)
            {
                if (leaseRequest is not null)
                {
                    ApplyLeaseAcquisition(task, leaseRequest.Value, now);
                }

                task.StartedAt ??= now;
                task.SuspensionReason = null;
                task.CompletedAt = null;
            }
            else if (targetStatus == TaskWireKeys.StatusCompleted)
            {
                task.Lease = null;
                task.SuspensionReason = null;
                task.CompletedAt ??= now;
            }
            else if (targetStatus == TaskWireKeys.StatusSuspended)
            {
                task.Lease = null;
                task.SuspensionReason = patch.SuspensionReason;
                task.CompletedAt = null;
            }
        }
        else if (leaseRequest is not null)
        {
            var (_, _, duration) = leaseRequest.Value;
            if (duration == 0)
            {
                if (task.Lease is not null)
                {
                    task.Lease.ExpiresAt = now;
                    task.Lease.HeartbeatAt = now;
                }
            }
            else
            {
                ApplyLeaseAcquisition(task, leaseRequest.Value, now);
            }
        }

        ApplyPayloadPatch(task, patch);
        if (patch.Tags is not null)
        {
            ApplyTagsPatch(task, patch.Tags);
        }

        ApplyAttachmentsPatch(task, patch);

        if (patch.Error is not null)
        {
            task.Error = TaskRecordValidation.NormalizeError(patch.Error);
        }

        if (!statusChange && patch.SuspensionReason is not null)
        {
            task.SuspensionReason = patch.SuspensionReason;
        }

        task.UpdatedAt = now;
        WriteTask(task);
        return Task.FromResult(task);
    }

    private static bool PatchIsCompletedNoop(TaskPatchRequest patch, string? normalizedStatus, (string, string, int)? leaseRequest)
        => (normalizedStatus is null || normalizedStatus == TaskWireKeys.StatusCompleted)
           && !patch.PayloadSupplied
           && patch.Tags is null
           && patch.Error is null
           && patch.SuspensionReason is null
           && leaseRequest is null
           && patch.Attachments is null
           && !patch.ClearAllAttachments;

    private static void ApplyLeaseAcquisition(TaskRecord task, (string Owner, string InstanceId, int DurationSeconds) leaseRequest, string now)
    {
        var (owner, instanceId, duration) = leaseRequest;
        var current = task.Lease;
        long generation = 0;
        long expiryCount = 0;

        if (current is not null)
        {
            bool expired = IsLeaseExpired(current);
            expiryCount = current.ExpiryCount;
            if (current.Owner == owner && current.InstanceId == instanceId)
            {
                generation = current.Generation;
            }
            else if (current.Owner == owner)
            {
                generation = current.Generation + 1;
                if (expired)
                {
                    expiryCount = current.ExpiryCount + 1;
                }
            }
            else if (expired)
            {
                generation = current.Generation + 1;
                expiryCount = current.ExpiryCount + 1;
            }
            else
            {
                throw TaskStoreException.LeaseHeld(task.Id);
            }
        }

        task.Lease = new Lease
        {
            Owner = owner,
            InstanceId = instanceId,
            Generation = generation,
            ExpiresAt = ExpiresAt(duration),
            ExpiryCount = expiryCount,
            HeartbeatAt = now,
        };
    }

    private static void ValidateLeaseRules(TaskRecord task, string targetStatus, bool statusChange, (string Owner, string InstanceId, int DurationSeconds)? leaseRequest)
    {
        if (leaseRequest is null)
        {
            if (statusChange && task.Status == TaskWireKeys.StatusInProgress && targetStatus == TaskWireKeys.StatusPending)
            {
                throw TaskStoreException.LeaseHeld(task.Id);
            }

            return;
        }

        var (owner, instanceId, duration) = leaseRequest.Value;

        if (statusChange && duration == 0)
        {
            throw TaskStoreException.InvalidRequest("Force-expire cannot be combined with a status change.", task.Id);
        }

        if (statusChange && (targetStatus == TaskWireKeys.StatusCompleted || targetStatus == TaskWireKeys.StatusSuspended))
        {
            throw TaskStoreException.InvalidRequest($"Lease parameters cannot be supplied when transitioning to {targetStatus}.", task.Id);
        }

        if (statusChange && task.Status == TaskWireKeys.StatusInProgress && targetStatus == TaskWireKeys.StatusPending
            && !LeaseMatches(task.Lease, owner, instanceId))
        {
            throw TaskStoreException.LeaseHeld(task.Id);
        }

        if (!statusChange && duration > 0 && task.Status != TaskWireKeys.StatusInProgress)
        {
            throw TaskStoreException.InvalidRequest("Lease renewal is only allowed when current status is in_progress.", task.Id);
        }

        if (duration == 0)
        {
            if (task.Lease is null)
            {
                throw TaskStoreException.InvalidRequest("No lease is available to force-expire.", task.Id);
            }

            if (!IsLeaseExpired(task.Lease) && !LeaseMatches(task.Lease, owner, instanceId))
            {
                throw TaskStoreException.LeaseHeld(task.Id);
            }
        }
        else if (task.Lease is not null && task.Lease.Owner != owner && !IsLeaseExpired(task.Lease))
        {
            throw TaskStoreException.LeaseHeld(task.Id);
        }
    }

    private static void ApplyPayloadPatch(TaskRecord task, TaskPatchRequest patch)
    {
        if (!patch.PayloadSupplied || patch.Payload is null)
        {
            return;
        }

        if (patch.Payload is JsonObject patchObj)
        {
            // Object patch → shallow-merge into the current payload (guarding the case where the
            // current payload is not an object, matching Python's `current = ... if dict else {}`).
            var merged = task.Payload is JsonObject current
                ? (JsonObject)current.DeepClone()
                : new JsonObject();
            foreach (var kvp in patchObj)
            {
                merged[kvp.Key] = kvp.Value?.DeepClone();
            }

            TaskRecordValidation.ValidatePayloadSize(merged, task.Id);
            task.Payload = merged;
        }
        else
        {
            // Any non-object JSON value (array/string/number) full-replaces the payload (spec §F1).
            JsonNode replacement = patch.Payload.DeepClone();
            TaskRecordValidation.ValidatePayloadSize(replacement, task.Id);
            task.Payload = replacement;
        }
    }

    private static void ApplyTagsPatch(TaskRecord task, IDictionary<string, JsonNode?> tags)
    {
        foreach (var kvp in tags)
        {
            if (kvp.Value is null)
            {
                task.Tags.Remove(kvp.Key);
            }
            else
            {
                task.Tags[kvp.Key] = (string?)kvp.Value ?? string.Empty;
            }
        }

        TaskRecordValidation.ValidateTags(task.Tags, task.Id);
    }

    private static void ApplyAttachmentsPatch(TaskRecord task, TaskPatchRequest patch)
    {
        if (patch.ClearAllAttachments)
        {
            task.Attachments = null;
            return;
        }

        if (patch.Attachments is null)
        {
            return;
        }

        var merged = task.Attachments is null ? new JsonObject() : (JsonObject)task.Attachments.DeepClone();
        foreach (var kvp in patch.Attachments)
        {
            if (kvp.Value is null)
            {
                merged.Remove(kvp.Key);
            }
            else
            {
                merged[kvp.Key] = kvp.Value.DeepClone();
            }
        }

        TaskRecordValidation.ValidateAttachments(merged, task.Id);
        task.Attachments = merged.Count > 0 ? merged : null;
    }

    /// <inheritdoc/>
    public Task DeleteAsync(string taskId, string? ifMatch = null, bool force = false, bool cascade = false, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        // `cascade` is accepted for interface parity with the hosted store but is a no-op locally,
        // matching the Python provider (the library does not track task dependencies).
        _ = cascade;

        var path = FindTaskPath(taskId);
        var task = path is null ? null : ReadTask(path);
        if (task is null || path is null)
        {
            throw new TaskStoreException(TaskStoreException.CodeTaskNotFound, 404, $"Task '{taskId}' not found.", taskId);
        }

        if (ifMatch is not null && ifMatch != task.Etag)
        {
            throw TaskStoreException.EtagMismatch(taskId);
        }

        // Non-terminal tasks require force=true, mirroring the local provider contract. The SOT
        // task-and-streaming spec §24.3 (authoritative for provider behavior) rejects this as
        // invalid_request (400) — NOT a conflict (409); the service moved 409 -> 400. The local
        // provider raises _invalid_request for identical accept/reject parity.
        if (task.Status != TaskWireKeys.StatusCompleted && !force)
        {
            throw TaskStoreException.InvalidRequest(
                $"Task '{taskId}' is not terminal; deletion requires force=true.", taskId);
        }

        File.Delete(path);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<TaskListResult> ListAsync(TaskListQuery query, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(query);

        int pageSize = query.Limit <= 0 ? 20 : Math.Min(query.Limit, 100);
        string? normalizedStatus = TaskRecordValidation.NormalizeLegacyStatus(query.Status);

        var results = new List<TaskRecord>();
        foreach (var path in IterTaskPaths(query.AgentName, query.SessionId))
        {
            var task = ReadTask(path);
            if (task is null)
            {
                continue;
            }

            if (query.AgentName is not null && task.AgentName != query.AgentName)
            {
                continue;
            }

            if (query.SessionId is not null && task.SessionId != query.SessionId)
            {
                continue;
            }

            if (normalizedStatus is not null && task.Status != normalizedStatus)
            {
                continue;
            }

            if (query.LeaseOwner is not null && (task.Lease is null || task.Lease.Owner != query.LeaseOwner))
            {
                continue;
            }

            if (query.Tags is not null && !query.Tags.All(t => task.Tags.TryGetValue(t.Key, out var v) && v == t.Value))
            {
                continue;
            }

            if (query.SourceType is not null && (task.Source is null || task.Source.Type != query.SourceType))
            {
                continue;
            }

            if (query.HasError is not null && (task.Error is not null) != query.HasError)
            {
                continue;
            }

            if (query.LeaseExpired is not null && IsLeaseExpired(task.Lease) != query.LeaseExpired)
            {
                continue;
            }

            results.Add(task);
        }

        results.Sort((a, b) => string.CompareOrdinal(a.CreatedAt ?? string.Empty, b.CreatedAt ?? string.Empty));
        if (!query.Ascending)
        {
            results.Reverse();
        }

        if (query.After is not null)
        {
            int idx = results.FindIndex(t => t.Id == query.After);
            results = idx >= 0 ? results.Skip(idx + 1).ToList() : new List<TaskRecord>();
        }

        var page = results.Take(pageSize).ToList();
        if (query.OmitAttachmentValues)
        {
            foreach (var task in page)
            {
                if (task.Attachments is not null)
                {
                    var nulled = new JsonObject();
                    foreach (var kvp in task.Attachments)
                    {
                        nulled[kvp.Key] = null;
                    }

                    task.Attachments = nulled;
                }
            }
        }

        var refs = page.Select(t => new TaskRecordRef(t, t.Id)).ToList();
        string? nextAfter = page.Count == pageSize && page.Count > 0 ? page[^1].Id : null;
        return Task.FromResult(new TaskListResult { Items = refs, NextAfter = nextAfter });
    }

    private IEnumerable<string> IterTaskPaths(string? agentName, string? sessionId)
    {
        if (!Directory.Exists(_baseDir))
        {
            yield break;
        }

        if (agentName is not null && sessionId is not null)
        {
            var dir = TaskDir(agentName, sessionId);
            if (Directory.Exists(dir))
            {
                foreach (var p in Directory.EnumerateFiles(dir, "*.json"))
                {
                    yield return p;
                }
            }

            yield break;
        }

        IEnumerable<string> agentDirs = agentName is not null
            ? (Directory.Exists(Path.Combine(_baseDir, agentName)) ? new[] { Path.Combine(_baseDir, agentName) } : Array.Empty<string>())
            : Directory.EnumerateDirectories(_baseDir);

        foreach (var agentDir in agentDirs)
        {
            foreach (var sessionDir in Directory.EnumerateDirectories(agentDir))
            {
                if (sessionId is not null && Path.GetFileName(sessionDir) != sessionId)
                {
                    continue;
                }

                foreach (var p in Directory.EnumerateFiles(sessionDir, "*.json"))
                {
                    yield return p;
                }
            }
        }
    }
}
