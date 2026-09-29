// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

/// <summary>
/// Internal protocol-level error raised by a task store (Local or Hosted) to
/// signal a typed failure with the cross-language protocol error code and HTTP
/// status. The engine maps these to the public task exception taxonomy. This
/// mirrors the Python provider's <c>_HostedConflict</c> so both stores classify
/// failures identically (FR-019a / SC-011).
/// </summary>
internal sealed class TaskStoreException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="TaskStoreException"/> class.</summary>
    /// <param name="code">The protocol error code (e.g. <c>invalid_request</c>, <c>conflict</c>, <c>etag_mismatch</c>).</param>
    /// <param name="statusCode">The associated HTTP status code.</param>
    /// <param name="message">A human-readable description.</param>
    /// <param name="taskId">The task id the error pertains to, when known.</param>
    public TaskStoreException(string code, int statusCode, string message, string? taskId = null)
        : base(message)
    {
        Code = code;
        StatusCode = statusCode;
        TaskId = taskId;
    }

    /// <summary>The protocol error code.</summary>
    public string Code { get; }

    /// <summary>The HTTP status code associated with this error.</summary>
    public int StatusCode { get; }

    /// <summary>The task id the error pertains to, when known.</summary>
    public string? TaskId { get; }

    // Common protocol error codes.
    public const string CodeInvalidRequest = "invalid_request";
    public const string CodeTaskNotFound = "task_not_found";
    public const string CodeTaskAlreadyExists = "task_already_exists";
    public const string CodeConflict = "conflict";
    public const string CodeEtagMismatch = "etag_mismatch";
    public const string CodeLeaseHeld = "lease_held_by_another";
    public const string CodeBindingMismatch = "binding_mismatch";
    public const string CodeLeaseOwnershipChanged = "lease_ownership_changed";
    public const string CodePreconditionFailed = "precondition_failed";
    public const string CodeRateLimited = "rate_limit_exceeded";
    public const string CodeInternalError = "internal_error";

    /// <summary>Creates an <c>invalid_request</c> (HTTP 400) store error.</summary>
    public static TaskStoreException InvalidRequest(string message, string? taskId = null)
        => new(CodeInvalidRequest, 400, message, taskId);

    /// <summary>Creates a <c>conflict</c> (HTTP 409) store error.</summary>
    public static TaskStoreException Conflict(string message, string? taskId = null)
        => new(CodeConflict, 409, message, taskId);

    /// <summary>Creates an <c>etag_mismatch</c> (HTTP 412) store error.</summary>
    public static TaskStoreException EtagMismatch(string? taskId = null)
        => new(CodeEtagMismatch, 412, "ETag mismatch.", taskId);

    /// <summary>Creates a <c>lease_held_by_another</c> (HTTP 409) store error.</summary>
    public static TaskStoreException LeaseHeld(string? taskId = null)
        => new(CodeLeaseHeld, 409, "Lease is held by another owner or instance.", taskId);
}
