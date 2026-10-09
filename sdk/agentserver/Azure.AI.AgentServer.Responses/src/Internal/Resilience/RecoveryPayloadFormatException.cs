// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Thrown when a resilient recovery payload cannot be serialized or is missing/malformed
/// required fields on deserialization. This is a fail-closed signal: the recovery pipeline
/// marks the affected response failed rather than re-invoking a handler with partial or
/// corrupt input.
/// </summary>
internal sealed class RecoveryPayloadFormatException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RecoveryPayloadFormatException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public RecoveryPayloadFormatException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RecoveryPayloadFormatException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The underlying cause.</param>
    public RecoveryPayloadFormatException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
