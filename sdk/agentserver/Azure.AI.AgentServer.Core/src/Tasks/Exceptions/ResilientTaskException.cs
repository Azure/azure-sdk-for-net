// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// The single exception type raised by the resilient-task framework. The
/// <see cref="ErrorCode"/> identifies the failure category; code-specific data is exposed
/// through nullable properties (<see cref="CurrentStatus"/>, <see cref="ActualLastInputId"/>,
/// <see cref="Failure"/>) that are populated only for the corresponding code.
/// </summary>
/// <remarks>
/// Catch this single type to handle any task-framework protocol failure. Argument validation
/// surfaces as <see cref="ArgumentException"/> and cancellation as
/// <see cref="OperationCanceledException"/>; recovery deferral is an internal lifecycle handoff
/// and is never surfaced as an exception.
/// </remarks>
public sealed class ResilientTaskException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="ResilientTaskException"/> class.</summary>
    /// <param name="errorCode">The failure category.</param>
    /// <param name="message">An optional description; a code-specific default is used when omitted.</param>
    /// <param name="innerException">The underlying cause, when available.</param>
    public ResilientTaskException(ResilientTaskErrorCode errorCode, string? message = null, Exception? innerException = null)
        : base(message ?? DefaultMessage(errorCode), innerException)
    {
        ErrorCode = errorCode;
    }

    /// <summary>The failure category.</summary>
    public ResilientTaskErrorCode ErrorCode { get; }

    /// <summary>
    /// For <see cref="ResilientTaskErrorCode.Conflict"/>, the task status the store reported at the
    /// time of the conflict; otherwise <see langword="null"/>.
    /// </summary>
    public TaskRunStatus? CurrentStatus { get; init; }

    /// <summary>
    /// For <see cref="ResilientTaskErrorCode.PreconditionFailed"/>, the task's actual last input id
    /// when known; otherwise <see langword="null"/>.
    /// </summary>
    public string? ActualLastInputId { get; init; }

    /// <summary>
    /// For <see cref="ResilientTaskErrorCode.HandlerError"/> and
    /// <see cref="ResilientTaskErrorCode.ExhaustedRetries"/>, the structured failure detail; otherwise
    /// <see langword="null"/>. The original handler exception (when available) is also preserved as
    /// <see cref="Exception.InnerException"/>.
    /// </summary>
    public TaskFailureDetail? Failure { get; init; }

    private static string DefaultMessage(ResilientTaskErrorCode errorCode) => errorCode switch
    {
        ResilientTaskErrorCode.HandlerError => "The task handler failed.",
        ResilientTaskErrorCode.ExhaustedRetries => "The task exhausted its retry budget.",
        ResilientTaskErrorCode.Conflict => "The task operation conflicts with the task's current state.",
        ResilientTaskErrorCode.PreconditionFailed => "The task's last input id did not match the supplied precondition.",
        ResilientTaskErrorCode.QueueFull => "The task steering queue is full.",
        _ => "The resilient task operation failed.",
    };
}
