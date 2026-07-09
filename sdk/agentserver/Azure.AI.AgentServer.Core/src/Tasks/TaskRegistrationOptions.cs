// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Per-task registration options. Maps the public keyword arguments of Python's
/// <c>@task(...)</c> minus <c>name</c>/<c>steerable</c> (which are method parameters).
/// Backend selection, lease durations, and the local state root are framework
/// internals, not options here (Python parity).
/// </summary>
public sealed class TaskRegistrationOptions
{
    /// <summary>
    /// A static title for the task. Defaults to the task <c>name</c> when the record is
    /// created. Only a constant string is supported (no factory).
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// The cap on how long a <b>single turn</b> (one handler invocation) may run uninterrupted.
    /// Defaults to <b>1 day</b> when unset, which is also a <b>hard ceiling</b>: a supplied value
    /// lowers the budget but can never raise it above 1 day (larger values, and negative values, are
    /// rejected at registration with <see cref="System.ArgumentOutOfRangeException"/>). This is
    /// <b>per turn, not per task</b> and does <b>not</b>
    /// limit how long a multi-turn task can live — a multi-turn task may stay alive indefinitely
    /// across many turns. A task's overall lifetime is governed separately by the platform's 30-day
    /// sliding TTL (a task is cleaned up only after 30 days with no new turns).
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    /// <summary>The retry policy for handler failures. <see langword="null"/> uses the framework default.</summary>
    public RetryPolicy? Retry { get; set; }
}
