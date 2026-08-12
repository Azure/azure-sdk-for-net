// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// The persisted task record — the byte-compatible wire shape shared across
/// language implementations. The flexible <see cref="Payload"/>,
/// <see cref="Tags"/>, and <see cref="Attachments"/> are kept as JSON nodes so
/// passthrough (caller-controlled) keys survive read/modify/write cycles
/// untouched, exactly like the Python dict-based model.
/// </summary>
internal sealed class TaskRecord
{
    /// <summary>The envelope discriminator; always <c>task</c>.</summary>
    public string Object { get; set; } = TaskWireKeys.ObjectValue;

    /// <summary>The task id (equals the developer-supplied or generated task id).</summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>The owning agent name (immutable after create).</summary>
    public string AgentName { get; set; } = string.Empty;

    /// <summary>The owning session id (immutable after create).</summary>
    public string SessionId { get; set; } = string.Empty;

    /// <summary>An optional human-readable title (≤256 chars).</summary>
    public string? Title { get; set; }

    /// <summary>An optional human-readable description.</summary>
    public string? Description { get; set; }

    /// <summary>The wire status string (<c>pending</c>/<c>in_progress</c>/<c>suspended</c>/<c>completed</c>).</summary>
    public string Status { get; set; } = TaskWireKeys.StatusPending;

    /// <summary>The lease, when one is held; otherwise <see langword="null"/>.</summary>
    public Lease? Lease { get; set; }

    /// <summary>
    /// The flexible payload (reserved keys plus caller passthrough). Normally a
    /// <see cref="JsonObject"/>; a raw PATCH may full-replace it with any JSON value
    /// (array/string/number) per the payload PATCH contract (spec §F1).
    /// </summary>
    public JsonNode Payload { get; set; } = new JsonObject();

    /// <summary>Tags (framework + caller); <c>_task_name</c> reserved.</summary>
    public IDictionary<string, string> Tags { get; set; } = new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>The task source (recovery routing anchor).</summary>
    public Source? Source { get; set; }

    /// <summary>Promoted attachment blobs keyed by attachment key, or <see langword="null"/>.</summary>
    public JsonObject? Attachments { get; set; }

    /// <summary>Server-set terminal error detail (never written for per-turn handler raises).</summary>
    public JsonNode? Error { get; set; }

    /// <summary>Reason set by the server when transitioning to <c>suspended</c>.</summary>
    public string? SuspensionReason { get; set; }

    /// <summary>ISO-8601 UTC creation instant.</summary>
    public string? CreatedAt { get; set; }

    /// <summary>ISO-8601 UTC last-update instant.</summary>
    public string? UpdatedAt { get; set; }

    /// <summary>ISO-8601 UTC instant execution first started (set once).</summary>
    public string? StartedAt { get; set; }

    /// <summary>ISO-8601 UTC completion instant.</summary>
    public string? CompletedAt { get; set; }

    /// <summary>The optimistic-concurrency token issued by the store.</summary>
    public string? Etag { get; set; }

    /// <summary>Parses a <see cref="TaskRecord"/> from its JSON object form.</summary>
    /// <param name="obj">The JSON object holding the record.</param>
    /// <returns>The parsed record.</returns>
    public static TaskRecord FromJson(JsonObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var record = new TaskRecord
        {
            Object = (string?)obj[TaskWireKeys.Object] ?? TaskWireKeys.ObjectValue,
            Id = (string?)obj[TaskWireKeys.Id] ?? string.Empty,
            AgentName = (string?)obj[TaskWireKeys.AgentName] ?? string.Empty,
            SessionId = (string?)obj[TaskWireKeys.SessionId] ?? string.Empty,
            Title = (string?)obj[TaskWireKeys.Title],
            Description = (string?)obj[TaskWireKeys.Description],
            Status = (string?)obj[TaskWireKeys.Status] ?? TaskWireKeys.StatusPending,
            Lease = Lease.FromJson(obj[TaskWireKeys.Lease]),
            Source = Source.FromJson(obj[TaskWireKeys.Source]),
            Error = obj[TaskWireKeys.Error]?.DeepClone(),
            SuspensionReason = (string?)obj[TaskWireKeys.SuspensionReason],
            CreatedAt = WireValue.AsString(obj[TaskWireKeys.CreatedAt]),
            UpdatedAt = WireValue.AsString(obj[TaskWireKeys.UpdatedAt]),
            StartedAt = WireValue.AsString(obj[TaskWireKeys.StartedAt]),
            CompletedAt = WireValue.AsString(obj[TaskWireKeys.CompletedAt]),
            Etag = (string?)obj[TaskWireKeys.Etag],
        };

        // Normalize legacy "done" alias to "completed".
        if (string.Equals(record.Status, TaskWireKeys.StatusDoneAlias, StringComparison.Ordinal))
        {
            record.Status = TaskWireKeys.StatusCompleted;
        }

        if (obj[TaskWireKeys.Payload] is { } payload)
        {
            record.Payload = payload.DeepClone();
        }

        if (obj[TaskWireKeys.Tags] is JsonObject tags)
        {
            foreach (var kvp in tags)
            {
                record.Tags[kvp.Key] = (string?)kvp.Value ?? string.Empty;
            }
        }

        if (obj[TaskWireKeys.Attachments] is JsonObject attachments)
        {
            record.Attachments = (JsonObject)attachments.DeepClone();
        }

        return record;
    }

    /// <summary>
    /// Projects this record to its JSON object form. Absent optional fields are
    /// omitted (matching the cross-language <c>to_dict</c> convention).
    /// </summary>
    /// <returns>A <see cref="JsonObject"/> representing the record.</returns>
    public JsonObject ToJson()
    {
        var obj = new JsonObject
        {
            [TaskWireKeys.Object] = Object,
            [TaskWireKeys.Id] = Id,
            [TaskWireKeys.AgentName] = AgentName,
            [TaskWireKeys.SessionId] = SessionId,
            [TaskWireKeys.Status] = Status,
            [TaskWireKeys.Payload] = Payload.DeepClone(),
        };

        if (Title is not null)
        {
            obj[TaskWireKeys.Title] = Title;
        }

        if (Description is not null)
        {
            obj[TaskWireKeys.Description] = Description;
        }

        // Lease is always present in the wire form (explicit null when absent), matching the
        // cross-language to_dict convention so a record written by another language round-trips
        // with the same key set.
        obj[TaskWireKeys.Lease] = Lease is not null ? Lease.ToJson() : null;

        if (Tags.Count > 0)
        {
            var tagsObj = new JsonObject();
            foreach (var kvp in Tags)
            {
                tagsObj[kvp.Key] = kvp.Value;
            }

            obj[TaskWireKeys.Tags] = tagsObj;
        }

        if (Source is not null)
        {
            obj[TaskWireKeys.Source] = Source.ToJson();
        }

        if (Attachments is not null && Attachments.Count > 0)
        {
            obj[TaskWireKeys.Attachments] = Attachments.DeepClone();
        }

        if (Error is not null)
        {
            obj[TaskWireKeys.Error] = Error.DeepClone();
        }

        if (SuspensionReason is not null)
        {
            obj[TaskWireKeys.SuspensionReason] = SuspensionReason;
        }

        // etag / created_at / updated_at are always present (empty string when unset), and
        // started_at / completed_at are always present (explicit null when unset), matching the
        // cross-language to_dict convention (every record carries these fields).
        obj[TaskWireKeys.CreatedAt] = CreatedAt ?? string.Empty;
        obj[TaskWireKeys.UpdatedAt] = UpdatedAt ?? string.Empty;
        obj[TaskWireKeys.StartedAt] = StartedAt;
        obj[TaskWireKeys.CompletedAt] = CompletedAt;
        obj[TaskWireKeys.Etag] = Etag ?? string.Empty;

        return obj;
    }
}
