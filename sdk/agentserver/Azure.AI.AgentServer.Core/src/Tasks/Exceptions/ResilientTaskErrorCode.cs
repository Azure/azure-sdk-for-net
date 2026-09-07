// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Identifies the category of a <see cref="ResilientTaskException"/>. This is an
/// <b>extensible</b> enum (a string-backed value type following the Azure SDK pattern): new
/// protocol reasons can be introduced without a breaking change, and an unrecognized value round-trips
/// rather than failing to parse. Argument validation and cancellation are represented by the standard
/// <see cref="ArgumentException"/> and <see cref="OperationCanceledException"/> instead of a code.
/// </summary>
public readonly partial struct ResilientTaskErrorCode : IEquatable<ResilientTaskErrorCode>
{
    private readonly string _value;

    private const string HandlerErrorValue = "HandlerError";
    private const string ExhaustedRetriesValue = "ExhaustedRetries";
    private const string ConflictValue = "Conflict";
    private const string PreconditionFailedValue = "PreconditionFailed";
    private const string QueueFullValue = "QueueFull";

    /// <summary>Initializes a new instance of the <see cref="ResilientTaskErrorCode"/> struct.</summary>
    /// <param name="value">The underlying string value.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    public ResilientTaskErrorCode(string value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>The handler threw an exception that was not retried (or retries were disabled).</summary>
    public static ResilientTaskErrorCode HandlerError { get; } = new ResilientTaskErrorCode(HandlerErrorValue);

    /// <summary>The handler exhausted its configured retry budget.</summary>
    public static ResilientTaskErrorCode ExhaustedRetries { get; } = new ResilientTaskErrorCode(ExhaustedRetriesValue);

    /// <summary>
    /// An operation conflicted with the task's current state — for example, starting a task whose
    /// turn is already in progress elsewhere, or mutating a task that has reached a terminal state.
    /// </summary>
    public static ResilientTaskErrorCode Conflict { get; } = new ResilientTaskErrorCode(ConflictValue);

    /// <summary>
    /// A run was submitted with an <c>IfLastInputId</c> precondition that did not match the task's
    /// actual last input id (an optimistic-concurrency guard for multi-turn chains).
    /// </summary>
    public static ResilientTaskErrorCode PreconditionFailed { get; } = new ResilientTaskErrorCode(PreconditionFailedValue);

    /// <summary>A steerable multi-turn task already holds the maximum number of pending steering inputs.</summary>
    public static ResilientTaskErrorCode QueueFull { get; } = new ResilientTaskErrorCode(QueueFullValue);

    /// <summary>Determines if two <see cref="ResilientTaskErrorCode"/> values are the same.</summary>
    /// <param name="left">The left value to compare.</param>
    /// <param name="right">The right value to compare.</param>
    public static bool operator ==(ResilientTaskErrorCode left, ResilientTaskErrorCode right) => left.Equals(right);

    /// <summary>Determines if two <see cref="ResilientTaskErrorCode"/> values are not the same.</summary>
    /// <param name="left">The left value to compare.</param>
    /// <param name="right">The right value to compare.</param>
    public static bool operator !=(ResilientTaskErrorCode left, ResilientTaskErrorCode right) => !left.Equals(right);

    /// <summary>Converts a string to a <see cref="ResilientTaskErrorCode"/>.</summary>
    /// <param name="value">The value.</param>
    public static implicit operator ResilientTaskErrorCode(string value) => new ResilientTaskErrorCode(value);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => obj is ResilientTaskErrorCode other && Equals(other);

    /// <inheritdoc/>
    public bool Equals(ResilientTaskErrorCode other) => string.Equals(_value, other._value, StringComparison.Ordinal);

    /// <inheritdoc/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _value != null ? StringComparer.Ordinal.GetHashCode(_value) : 0;

    /// <inheritdoc/>
    public override string ToString() => _value;
}
