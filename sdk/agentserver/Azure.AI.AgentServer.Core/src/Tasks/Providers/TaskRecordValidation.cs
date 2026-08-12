// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Azure.AI.AgentServer.Core.Tasks.Serialization;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>
/// Shared field-budget and state validation rules applied identically by the
/// Local and Hosted task stores, so both produce the same accept/reject
/// decisions (FR-019a / SC-011). Sizes are measured as canonical-JSON UTF-8
/// byte length.
/// </summary>
internal static class TaskRecordValidation
{
    public const int MaxPayloadBytes = 1 * 1024 * 1024;
    public const int MaxErrorBytes = 64 * 1024;
    public const int MaxSourceBytes = 4 * 1024;
    public const int MaxTags = 16;
    public const int MaxTagKeyLen = 64;
    public const int MaxTagValueLen = 256;
    public const int MaxTitleLen = 256;
    public const int MaxDescriptionLen = 1024;
    public const int MaxAgentNameLen = 128;
    public const int MaxSessionIdLen = 128;
    public const int MinLeaseDurationSeconds = 10;
    public const int MaxLeaseDurationSeconds = 3600;
    public const int MaxSuspensionReasonLen = 256;
    public const int MaxLeaseIdentityLen = 256;

    private static readonly Regex TaskIdPattern = new("^[a-zA-Z0-9_-]{1,128}$", RegexOptions.Compiled);
    private static readonly Regex TagKeyPattern = new("^[a-zA-Z0-9_.-]{1,64}$", RegexOptions.Compiled);
    private static readonly Regex AttachmentKeyPattern = new(@"^[a-zA-Z0-9_.\-]{1,64}$", RegexOptions.Compiled);

    // Statuses that may appear anywhere on a task record.
    private static readonly HashSet<string> LegalStatuses = new(StringComparer.Ordinal)
    {
        TaskWireKeys.StatusPending,
        TaskWireKeys.StatusInProgress,
        TaskWireKeys.StatusSuspended,
        TaskWireKeys.StatusCompleted,
    };

    // Statuses permitted on CREATE (foundry-task-storage-protocol-spec §7.1:
    // "status: pending (default) or in_progress").
    private static readonly HashSet<string> ValidCreateStatuses = new(StringComparer.Ordinal)
    {
        TaskWireKeys.StatusPending,
        TaskWireKeys.StatusInProgress,
    };

    // Allowed status transitions for an existing (non-terminal) task
    // (foundry-task-storage-protocol-spec §7.3 State Mutability table).
    private static readonly HashSet<(string From, string To)> ValidTransitions = new()
    {
        (TaskWireKeys.StatusPending, TaskWireKeys.StatusInProgress),
        (TaskWireKeys.StatusPending, TaskWireKeys.StatusCompleted),
        (TaskWireKeys.StatusInProgress, TaskWireKeys.StatusCompleted),
        (TaskWireKeys.StatusInProgress, TaskWireKeys.StatusSuspended),
        (TaskWireKeys.StatusInProgress, TaskWireKeys.StatusPending),
        (TaskWireKeys.StatusSuspended, TaskWireKeys.StatusInProgress),
        (TaskWireKeys.StatusSuspended, TaskWireKeys.StatusPending),
        (TaskWireKeys.StatusSuspended, TaskWireKeys.StatusCompleted),
    };

    /// <summary>Normalizes a legacy/loose status value (e.g. <c>done</c> → <c>completed</c>), or <see langword="null"/>.</summary>
    /// <param name="status">The status value to normalize.</param>
    /// <returns>The normalized status, or <see langword="null"/> when not supplied.</returns>
    public static string? NormalizeLegacyStatus(string? status)
    {
        if (string.IsNullOrEmpty(status))
        {
            return null;
        }

        return string.Equals(status, TaskWireKeys.StatusDoneAlias, StringComparison.Ordinal)
            ? TaskWireKeys.StatusCompleted
            : status;
    }

    /// <summary>Validates and normalizes a patch-time status; rejects the reserved <c>failed</c> input status.</summary>
    /// <param name="status">The requested status.</param>
    /// <param name="taskId">The owning task id.</param>
    /// <returns>The normalized status, or <see langword="null"/> when not supplied.</returns>
    public static string? ValidatePatchStatus(string? status, string? taskId = null)
    {
        string? normalized = NormalizeLegacyStatus(status);
        if (normalized is null)
        {
            return null;
        }

        if (string.Equals(normalized, TaskWireKeys.StatusFailed, StringComparison.Ordinal))
        {
            throw TaskStoreException.InvalidRequest("'failed' is not a valid patch status.", taskId);
        }

        if (!LegalStatuses.Contains(normalized))
        {
            throw TaskStoreException.InvalidRequest($"Invalid patch status '{status}'.", taskId);
        }

        return normalized;
    }

    /// <summary>Validates a status transition is permitted; raises a conflict otherwise.</summary>
    /// <param name="from">The current status.</param>
    /// <param name="to">The target status.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateTransition(string from, string to, string? taskId = null)
    {
        if (string.Equals(from, to, StringComparison.Ordinal))
        {
            return;
        }

        if (!ValidTransitions.Contains((from, to)))
        {
            throw TaskStoreException.Conflict($"Invalid status transition from '{from}' to '{to}'.", taskId);
        }
    }

    /// <summary>Validates the stored task id format.</summary>
    /// <param name="taskId">The task id to validate.</param>
    public static void ValidateTaskId(string taskId)
    {
        if (string.IsNullOrEmpty(taskId) || !TaskIdPattern.IsMatch(taskId))
        {
            throw TaskStoreException.InvalidRequest(
                $"Task id '{taskId}' must match ^[a-zA-Z0-9_-]{{1,128}}$.", taskId);
        }
    }

    /// <summary>Validates the input id format (same rules as a task id).</summary>
    /// <param name="inputId">The input id to validate.</param>
    /// <param name="taskId">The owning task id (for error messages).</param>
    public static void ValidateInputId(string inputId, string? taskId = null)
    {
        if (string.IsNullOrEmpty(inputId) || !TaskIdPattern.IsMatch(inputId))
        {
            throw TaskStoreException.InvalidRequest(
                $"Input id '{inputId}' must match ^[a-zA-Z0-9_-]{{1,128}}$.", taskId);
        }
    }

    /// <summary>Validates a required string field against a maximum length.</summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="field">The field name (for error messages).</param>
    /// <param name="maxLen">The maximum allowed length.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateRequiredString(string? value, string field, int maxLen, string? taskId = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw TaskStoreException.InvalidRequest($"{field} is required.", taskId);
        }

        if (value.Trim().Length > maxLen)
        {
            throw TaskStoreException.InvalidRequest($"{field} exceeds the maximum length of {maxLen}.", taskId);
        }
    }

    /// <summary>Validates an optional string field against a maximum length.</summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="field">The field name (for error messages).</param>
    /// <param name="maxLen">The maximum allowed length.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateOptionalString(string? value, string field, int maxLen, string? taskId = null)
    {
        if (value is not null && value.Trim().Length > maxLen)
        {
            throw TaskStoreException.InvalidRequest($"{field} exceeds the maximum length of {maxLen}.", taskId);
        }
    }

    /// <summary>Validates the tag count and per-key/value length limits.</summary>
    /// <param name="tags">The tags to validate.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateTags(IDictionary<string, string>? tags, string? taskId = null)
    {
        if (tags is null)
        {
            return;
        }

        if (tags.Count > MaxTags)
        {
            throw TaskStoreException.InvalidRequest($"A task may have at most {MaxTags} tags.", taskId);
        }

        foreach (var kvp in tags)
        {
            if (!TagKeyPattern.IsMatch(kvp.Key))
            {
                throw TaskStoreException.InvalidRequest(
                    $"Tag key '{kvp.Key}' must match [a-zA-Z0-9_.-] and be {MaxTagKeyLen} chars or fewer.", taskId);
            }

            if (kvp.Value.Length > MaxTagValueLen)
            {
                throw TaskStoreException.InvalidRequest($"Tag value for '{kvp.Key}' exceeds {MaxTagValueLen} chars.", taskId);
            }
        }
    }

    /// <summary>Validates the payload does not exceed the canonical byte budget.</summary>
    /// <param name="payload">The payload object.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidatePayloadSize(JsonNode? payload, string? taskId = null)
    {
        if (payload is null)
        {
            return;
        }

        int size = AttachmentPromoter.MeasureBytes(payload);
        if (size > MaxPayloadBytes)
        {
            throw TaskStoreException.InvalidRequest(
                $"Payload is {size} bytes, exceeding the maximum of {MaxPayloadBytes} bytes.", taskId);
        }
    }

    /// <summary>Validates the source object size.</summary>
    /// <param name="source">The source node.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateSource(JsonNode? source, string? taskId = null)
    {
        if (source is null)
        {
            return;
        }

        int size = AttachmentPromoter.MeasureBytes(source);
        if (size > MaxSourceBytes)
        {
            throw TaskStoreException.InvalidRequest(
                $"Source is {size} bytes, exceeding the maximum of {MaxSourceBytes} bytes.", taskId);
        }

        // A source object must carry a non-empty `type` discriminator
        // (foundry-task-storage-protocol-spec §7.1: "Must contain type").
        if (source is not JsonObject sourceObj
            || sourceObj[TaskWireKeys.SourceType] is not JsonValue typeValue
            || typeValue.GetValueKind() != System.Text.Json.JsonValueKind.String
            || string.IsNullOrWhiteSpace(typeValue.GetValue<string>()))
        {
            throw TaskStoreException.InvalidRequest("source.type must be a non-empty string.", taskId);
        }
    }

    /// <summary>
    /// Validates a server-set error object (C-VAL-6 / C-VAL-8): size &lt;= 64 KB and, when present,
    /// a non-empty <c>message</c> and non-empty <c>type</c> string.
    /// </summary>
    /// <param name="error">The error node.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateError(JsonNode? error, string? taskId = null)
    {
        if (error is null)
        {
            return;
        }

        if (error is not JsonObject errorObj)
        {
            throw TaskStoreException.InvalidRequest("error must be an object.", taskId);
        }

        int size = AttachmentPromoter.MeasureBytes(error);
        if (size > MaxErrorBytes)
        {
            throw TaskStoreException.InvalidRequest(
                $"Error is {size} bytes, exceeding the maximum of {MaxErrorBytes} bytes.", taskId);
        }

        if (errorObj[TaskWireKeys.ErrorMessage] is not JsonValue messageValue
            || messageValue.GetValueKind() != System.Text.Json.JsonValueKind.String
            || string.IsNullOrWhiteSpace(messageValue.GetValue<string>()))
        {
            throw TaskStoreException.InvalidRequest("error.message must be a non-empty string.", taskId);
        }

        if (errorObj[TaskWireKeys.ErrorType] is not JsonValue typeValue
            || typeValue.GetValueKind() != System.Text.Json.JsonValueKind.String
            || string.IsNullOrWhiteSpace(typeValue.GetValue<string>()))
        {
            throw TaskStoreException.InvalidRequest("error.type must be a non-empty string.", taskId);
        }
    }

    /// <summary>
    /// Canonicalizes an error object (C-VAL-8): returns a copy with <c>code</c> defaulted to
    /// <c>"error"</c> when missing or empty. Returns <see langword="null"/> when the error is null.
    /// </summary>
    /// <param name="error">The error node to canonicalize, or <see langword="null"/>.</param>
    /// <returns>The canonicalized error, or <see langword="null"/>.</returns>
    public static JsonNode? NormalizeError(JsonNode? error)
    {
        if (error is null)
        {
            return null;
        }

        JsonNode clone = error.DeepClone();
        if (clone is JsonObject obj)
        {
            bool hasCode = obj[TaskWireKeys.ErrorCode] is JsonValue codeValue
                && codeValue.GetValueKind() == System.Text.Json.JsonValueKind.String
                && !string.IsNullOrEmpty(codeValue.GetValue<string>());
            if (!hasCode)
            {
                obj[TaskWireKeys.ErrorCode] = "error";
            }
        }

        return clone;
    }

    /// <summary>
    /// Validates the lease parameter triple (all-or-nothing) and duration bounds,
    /// returning the parsed triple or <see langword="null"/> when none are supplied.
    /// </summary>
    /// <param name="owner">The lease owner.</param>
    /// <param name="instanceId">The lease instance id.</param>
    /// <param name="durationSeconds">The lease duration in seconds.</param>
    /// <param name="taskId">The owning task id.</param>
    /// <returns>The validated triple, or <see langword="null"/>.</returns>
    public static (string Owner, string InstanceId, int DurationSeconds)? ValidateLeaseParams(
        string? owner, string? instanceId, int? durationSeconds, string? taskId = null)
    {
        bool any = owner is not null || instanceId is not null || durationSeconds is not null;
        if (!any)
        {
            return null;
        }

        if (owner is null || instanceId is null || durationSeconds is null)
        {
            throw TaskStoreException.InvalidRequest(
                "lease_owner, lease_instance_id, and lease_duration_seconds must be provided together.", taskId);
        }

        if (owner.Length > MaxLeaseIdentityLen)
        {
            throw TaskStoreException.InvalidRequest(
                $"lease_owner exceeds the maximum length of {MaxLeaseIdentityLen}.", taskId);
        }

        if (instanceId.Length > MaxLeaseIdentityLen)
        {
            throw TaskStoreException.InvalidRequest(
                $"lease_instance_id exceeds the maximum length of {MaxLeaseIdentityLen}.", taskId);
        }

        int d = durationSeconds.Value;
        if (d != 0 && (d < MinLeaseDurationSeconds || d > MaxLeaseDurationSeconds))
        {
            throw TaskStoreException.InvalidRequest(
                $"lease_duration_seconds must be 0 or within [{MinLeaseDurationSeconds}, {MaxLeaseDurationSeconds}].", taskId);
        }

        return (owner, instanceId, d);
    }

    /// <summary>Validates and normalizes a create-time status value.</summary>
    /// <param name="status">The requested status.</param>
    /// <param name="taskId">The owning task id.</param>
    /// <returns>The normalized status.</returns>
    public static string ValidateCreateStatus(string? status, string? taskId = null)
    {
        if (string.IsNullOrEmpty(status))
        {
            return TaskWireKeys.StatusPending;
        }

        string normalized = string.Equals(status, TaskWireKeys.StatusDoneAlias, StringComparison.Ordinal)
            ? TaskWireKeys.StatusCompleted
            : status;

        if (!ValidCreateStatuses.Contains(normalized))
        {
            throw TaskStoreException.InvalidRequest($"Invalid create status '{status}'.", taskId);
        }

        return normalized;
    }

    /// <summary>Validates the attachment count and per-attachment sizes.</summary>
    /// <param name="attachments">The attachments object.</param>
    /// <param name="taskId">The owning task id.</param>
    public static void ValidateAttachments(JsonObject? attachments, string? taskId = null)
    {
        if (attachments is null)
        {
            return;
        }

        int count = 0;
        foreach (var kvp in attachments)
        {
            // Attachment keys MUST be non-empty after trimming and match ^[a-zA-Z0-9_.-]{1,64}$
            // against the trimmed key (C-ATT-8 / Python validate_attachment_key, which matches
            // key.strip()). Trim only for the match decision so the accept/reject set is identical
            // to Python's.
            if (string.IsNullOrWhiteSpace(kvp.Key) || !AttachmentKeyPattern.IsMatch(kvp.Key.Trim()))
            {
                throw TaskStoreException.InvalidRequest(
                    $"Attachment key '{kvp.Key}' must match [a-zA-Z0-9_.-] and be 64 characters or fewer.", taskId);
            }

            if (kvp.Value is null)
            {
                continue;
            }

            count++;
            int size = AttachmentPromoter.MeasureBytes(kvp.Value);
            if (size > AttachmentPromoter.MaxAttachmentValueBytes)
            {
                throw TaskStoreException.InvalidRequest(
                    $"Attachment '{kvp.Key}' is {size} bytes, exceeding {AttachmentPromoter.MaxAttachmentValueBytes}.", taskId);
            }
        }

        if (count > AttachmentPromoter.MaxAttachmentsPerTask)
        {
            throw TaskStoreException.InvalidRequest(
                $"A task may have at most {AttachmentPromoter.MaxAttachmentsPerTask} attachments.", taskId);
        }
    }
}
