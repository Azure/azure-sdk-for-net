// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Thrown when a task ultimately fails — either because the handler raised an
/// unretried exception or because it exhausted its retry budget. The structured
/// <see cref="Error"/> carries the failure detail; the original handler
/// exception (when available) is preserved as
/// <see cref="System.Exception.InnerException"/>.
/// </summary>
public sealed class TaskFailedException : TaskException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskFailedException"/> class.
    /// </summary>
    /// <param name="error">The structured failure detail.</param>
    /// <param name="innerException">The original handler exception, when available.</param>
    public TaskFailedException(TaskFailureDetail error, Exception? innerException = null)
        : base(error?.Message ?? "The task failed.", innerException)
    {
        Error = error ?? throw new ArgumentNullException(nameof(error));
    }

    /// <summary>The structured detail describing why the task failed.</summary>
    public TaskFailureDetail Error { get; }
}
