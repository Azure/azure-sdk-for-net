// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Categorizes why a task ultimately failed.
/// </summary>
public enum TaskFailureKind
{
    /// <summary>The handler threw an exception that was not retried (or retries were disabled).</summary>
    HandlerError,

    /// <summary>The handler exhausted its configured retry budget.</summary>
    ExhaustedRetries,
}
