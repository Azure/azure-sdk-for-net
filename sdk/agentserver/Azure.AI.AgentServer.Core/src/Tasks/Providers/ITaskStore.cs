// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>Parameters for creating a task record.</summary>
internal sealed class TaskCreateRequest
{
    public string? Id { get; set; }

    public string AgentName { get; set; } = string.Empty;

    public string SessionId { get; set; } = string.Empty;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public JsonObject? Payload { get; set; }

    public IDictionary<string, string>? Tags { get; set; }

    public JsonObject? Source { get; set; }

    public JsonObject? Attachments { get; set; }

    public string? LeaseOwner { get; set; }

    public string? LeaseInstanceId { get; set; }

    public int? LeaseDurationSeconds { get; set; }
}

/// <summary>
/// Parameters for patching a task record. A <see langword="null"/> property is
/// "not supplied"; the merge semantics for supplied properties follow
/// contracts/foundry-task-storage-http.md.
/// </summary>
internal sealed class TaskPatchRequest
{
    /// <summary>Status to transition to, when supplied.</summary>
    public string? Status { get; set; }

    /// <summary>Payload merge node (object → shallow merge null-as-value; non-object → replace).</summary>
    public JsonNode? Payload { get; set; }

    /// <summary>Whether <see cref="Payload"/> was explicitly supplied (distinguishes "no-op" from "merge").</summary>
    public bool PayloadSupplied { get; set; }

    /// <summary>Tag merge (null value = delete key).</summary>
    public IDictionary<string, JsonNode?>? Tags { get; set; }

    /// <summary>Attachment merge (null value = delete key; an explicit empty object clears all).</summary>
    public JsonObject? Attachments { get; set; }

    /// <summary>Whether <see cref="Attachments"/> clears all (top-level clear).</summary>
    public bool ClearAllAttachments { get; set; }

    /// <summary>Server-set error detail.</summary>
    public JsonNode? Error { get; set; }

    /// <summary>Suspension reason set on transition to suspended.</summary>
    public string? SuspensionReason { get; set; }

    /// <summary>Lease owner (sent with the instance id and duration triple).</summary>
    public string? LeaseOwner { get; set; }

    /// <summary>Lease instance id.</summary>
    public string? LeaseInstanceId { get; set; }

    /// <summary>Lease duration in seconds (0 = force-expire; or [10,3600]).</summary>
    public int? LeaseDurationSeconds { get; set; }
}

/// <summary>Filters for listing task records (all optional, server-side).</summary>
internal sealed class TaskListQuery
{
    public string? AgentName { get; set; }

    public string? SessionId { get; set; }

    public bool? HasError { get; set; }

    public bool? LeaseExpired { get; set; }

    public string? LeaseOwner { get; set; }

    public IReadOnlyList<KeyValuePair<string, string>>? Tags { get; set; }

    public string? SourceType { get; set; }

    public string? Status { get; set; }

    public string? After { get; set; }

    public int Limit { get; set; } = 20;

    public bool Ascending { get; set; }

    public bool OmitAttachmentValues { get; set; }
}

/// <summary>A page of task records returned by <see cref="ITaskStore.ListAsync"/>.</summary>
internal sealed class TaskListResult
{
    public IReadOnlyList<TaskRecordRef> Items { get; set; } = System.Array.Empty<TaskRecordRef>();

    public string? NextAfter { get; set; }
}

/// <summary>A listed task record paired with its source path/cursor token.</summary>
internal sealed class TaskRecordRef
{
    public TaskRecordRef(Serialization.TaskRecord record, string cursor)
    {
        Record = record;
        Cursor = cursor;
    }

    public Serialization.TaskRecord Record { get; }

    public string Cursor { get; }
}

/// <summary>
/// Abstraction over the task storage backend (Local file store or Hosted HTTP
/// store). All writes carry an optional <c>If-Match</c> ETag and return the
/// refreshed record (whose <see cref="Serialization.TaskRecord.Etag"/> the
/// caller tracks). CRUDL + lease + patch semantics conform to
/// contracts/foundry-task-storage-http.md.
/// </summary>
internal interface ITaskStore
{
    /// <summary>Creates a new task record; the store stamps timestamps and ETag.</summary>
    System.Threading.Tasks.Task<Serialization.TaskRecord> CreateAsync(
        TaskCreateRequest request, System.Threading.CancellationToken cancellationToken = default);

    /// <summary>Gets a task record by id, or <see langword="null"/> if it does not exist.</summary>
    System.Threading.Tasks.Task<Serialization.TaskRecord?> GetAsync(
        string taskId, System.Threading.CancellationToken cancellationToken = default);

    /// <summary>Applies a patch, honoring <paramref name="ifMatch"/> for optimistic concurrency.</summary>
    System.Threading.Tasks.Task<Serialization.TaskRecord> PatchAsync(
        string taskId, TaskPatchRequest patch, string? ifMatch, System.Threading.CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a task record (the only write that omits <c>If-Match</c> by
    /// default). <paramref name="force"/> permits deleting a non-terminal task
    /// (releasing any active lease). <paramref name="cascade"/> requests that the
    /// backing service also delete dependent tasks; it is forwarded to the hosted
    /// service and is a no-op for the local file store (mirroring the Python
    /// provider, which accepts <c>cascade</c> but does not act on it locally).
    /// </summary>
    System.Threading.Tasks.Task DeleteAsync(
        string taskId, string? ifMatch = null, bool force = false, bool cascade = false, System.Threading.CancellationToken cancellationToken = default);

    /// <summary>Lists task records matching the supplied filters.</summary>
    System.Threading.Tasks.Task<TaskListResult> ListAsync(
        TaskListQuery query, System.Threading.CancellationToken cancellationToken = default);
}
