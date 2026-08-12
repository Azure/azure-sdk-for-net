// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Raised when a bridge frame violates the typed Voice Live Bridge Protocol.
/// </summary>
public sealed class VoiceBridgeProtocolException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceBridgeProtocolException"/> class.
    /// </summary>
    /// <param name="message">A safe diagnostic message that never includes transcript or personally identifiable information.</param>
    /// <param name="closeCode">The RFC 6455 close code to use for the violation.</param>
    public VoiceBridgeProtocolException(string message, int closeCode = VoiceProtocolConstants.CloseProtocolError)
        : base(message)
    {
        CloseCode = closeCode;
    }

    /// <summary>Gets the RFC 6455 close code associated with the violation.</summary>
    public int CloseCode { get; }
}

/// <summary>
/// Raised when customer code uses a terminal response or a closed connection.
/// </summary>
public sealed class VoiceBridgeConnectionClosedException : InvalidOperationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceBridgeConnectionClosedException"/> class.
    /// </summary>
    /// <param name="message">A safe diagnostic message.</param>
    public VoiceBridgeConnectionClosedException(string message)
        : base(message)
    {
    }

    internal VoiceBridgeConnectionClosedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

/// <summary>
/// Raised when the bridge terminates a proactive admission request before it
/// becomes writable.
/// </summary>
public sealed class VoiceProactiveResponseDroppedException : InvalidOperationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceProactiveResponseDroppedException"/> class.
    /// </summary>
    /// <param name="responseId">The terminal proactive response ID.</param>
    /// <param name="reason">The bounded open-enum drop reason.</param>
    public VoiceProactiveResponseDroppedException(string responseId, string reason)
        : base($"Proactive response was dropped: {reason}")
    {
        ResponseId = responseId;
        Reason = reason;
    }

    /// <summary>Gets the terminal proactive response ID.</summary>
    public string ResponseId { get; }

    /// <summary>Gets the open-enum drop reason supplied by the bridge.</summary>
    public string Reason { get; }
}
