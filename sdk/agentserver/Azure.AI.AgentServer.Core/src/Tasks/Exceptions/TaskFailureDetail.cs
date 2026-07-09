// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Structured detail describing why a task failed. Projects the cross-language
/// failure record (handler error vs. exhausted retries) into typed members.
/// </summary>
/// <remarks>
/// The original handler exception is also preserved as
/// <see cref="System.Exception.InnerException"/> on the
/// <see cref="TaskFailedException"/>. <see cref="Traceback"/> captures the same
/// formatted stack trace as a string for cross-language parity with the persisted
/// failure record.
/// </remarks>
public sealed class TaskFailureDetail
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskFailureDetail"/> class.
    /// </summary>
    /// <param name="kind">Whether this was a direct handler error or exhausted retries.</param>
    /// <param name="errorType">The exception type name (or <c>"exhausted_retries"</c>).</param>
    /// <param name="message">A human-readable summary of the failure.</param>
    /// <param name="attempts">For exhausted-retries failures, the number of attempts made.</param>
    /// <param name="lastError">For exhausted-retries failures, the message of the final error.</param>
    /// <param name="lastErrorType">For exhausted-retries failures, the type name of the final error.</param>
    /// <param name="traceback">The formatted stack trace of the underlying exception, when available.</param>
    public TaskFailureDetail(
        TaskFailureKind kind,
        string errorType,
        string message,
        int? attempts = null,
        string? lastError = null,
        string? lastErrorType = null,
        string? traceback = null)
    {
        Kind = kind;
        ErrorType = errorType;
        Message = message;
        Attempts = attempts;
        LastError = lastError;
        LastErrorType = lastErrorType;
        Traceback = traceback;
    }

    /// <summary>Whether the failure was a direct handler error or exhausted retries.</summary>
    public TaskFailureKind Kind { get; }

    /// <summary>The exception type name, or <c>"exhausted_retries"</c> for retry exhaustion.</summary>
    public string ErrorType { get; }

    /// <summary>A human-readable summary of the failure.</summary>
    public string Message { get; }

    /// <summary>For exhausted-retries failures, the number of attempts made; otherwise <see langword="null"/>.</summary>
    public int? Attempts { get; }

    /// <summary>For exhausted-retries failures, the message of the final error; otherwise <see langword="null"/>.</summary>
    public string? LastError { get; }

    /// <summary>For exhausted-retries failures, the type name of the final error; otherwise <see langword="null"/>.</summary>
    public string? LastErrorType { get; }

    /// <summary>
    /// The formatted stack trace of the underlying exception (parity with the persisted
    /// failure record's <c>traceback</c>), or <see langword="null"/> when unavailable.
    /// </summary>
    public string? Traceback { get; }
}
