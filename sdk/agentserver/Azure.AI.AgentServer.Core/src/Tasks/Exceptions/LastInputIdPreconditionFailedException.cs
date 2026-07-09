// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when a run was submitted with an <c>IfLastInputId</c> precondition
/// that did not match the task's actual last input id — an optimistic-concurrency
/// guard for multi-turn chains.
/// </summary>
public sealed class LastInputIdPreconditionFailedException : TaskException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LastInputIdPreconditionFailedException"/> class.
    /// </summary>
    /// <param name="actualLastInputId">The task's actual last input id, when known.</param>
    /// <param name="message">An optional description of the precondition failure.</param>
    public LastInputIdPreconditionFailedException(string? actualLastInputId, string? message = null)
        : base(message ?? "The task's last input id did not match the supplied precondition.")
    {
        ActualLastInputId = actualLastInputId;
    }

    /// <summary>The task's actual last input id at the time of the precondition check, when known.</summary>
    public string? ActualLastInputId { get; }
}
