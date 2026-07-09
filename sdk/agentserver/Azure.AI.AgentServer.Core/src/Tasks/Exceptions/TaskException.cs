// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Base type for all resilient-task exceptions. Catch this to handle any
/// task-framework failure with a single <c>catch (TaskException)</c> clause.
/// </summary>
public class TaskException : Exception
{
    /// <summary>Initializes a new instance of the <see cref="TaskException"/> class.</summary>
    public TaskException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TaskException"/> class with a message.</summary>
    /// <param name="message">A description of the failure.</param>
    public TaskException(string message)
        : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="TaskException"/> class with a message and inner exception.</summary>
    /// <param name="message">A description of the failure.</param>
    /// <param name="innerException">The underlying cause.</param>
    public TaskException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
