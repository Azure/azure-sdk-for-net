// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Voice.Internal;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Read-only per-call context and session-scoped controls exposed to voice
/// callbacks. This is not a control-plane resource and never exposes session
/// create, read, update, or delete operations.
/// </summary>
public class VoiceSession
{
    private readonly IVoiceConnection _connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="VoiceSession"/> class for mocking.
    /// </summary>
    protected VoiceSession()
    {
        _connection = null!;
        StartEvent = null!;
    }

    internal VoiceSession(IVoiceConnection connection, SessionStartEvent startEvent)
    {
        _connection = connection;
        StartEvent = startEvent;
    }

    /// <summary>Gets the immutable <c>session.start</c> event for this call.</summary>
    public virtual SessionStartEvent StartEvent { get; }

    /// <summary>Gets a value indicating whether this activation reattached an existing session.</summary>
    public virtual bool Reconnect => StartEvent.Reconnect;

    /// <summary>Gets the optional bridge-owned greeting.</summary>
    public virtual string? Greeting => StartEvent.Greeting;

    /// <summary>Gets the optional, untrusted caller metadata.</summary>
    public virtual IReadOnlyDictionary<string, object?>? Caller => StartEvent.Caller;

    /// <summary>Gets the optional caller-silence threshold.</summary>
    public virtual int? NoInputTimeoutMs => StartEvent.NoInputTimeoutMs;

    /// <summary>Gets the effective response deadlines selected by the bridge.</summary>
    public virtual ResponseTimeouts ResponseTimeouts => StartEvent.ResponseTimeouts;

    /// <summary>
    /// Requests proactive admission and returns only after the bridge accepts
    /// the response. No output can be sent before acceptance.
    /// </summary>
    /// <param name="admissionTimeoutMs">A positive admission wait of at most 60,000 milliseconds.</param>
    /// <param name="supersedeKey">An optional non-empty logical notification key.</param>
    /// <param name="cancellationToken">A token that abandons this admission request.</param>
    /// <returns>The accepted, writable response.</returns>
    /// <exception cref="VoiceProactiveResponseDroppedException">The bridge did not admit the request.</exception>
    public virtual Task<VoiceResponse> StartProactiveResponseAsync(
        int admissionTimeoutMs = 60000,
        string? supersedeKey = null,
        CancellationToken cancellationToken = default)
    {
        if (admissionTimeoutMs is < 1 or > 60000)
        {
            throw new ArgumentOutOfRangeException(
                nameof(admissionTimeoutMs),
                "The admission timeout must be between 1 and 60000 milliseconds.");
        }

        if (supersedeKey is not null && supersedeKey.Length == 0)
        {
            throw new ArgumentException("The supersede key must be non-empty when provided.", nameof(supersedeKey));
        }

        return _connection.StartProactiveResponseAsync(admissionTimeoutMs, supersedeKey, cancellationToken);
    }

    /// <summary>
    /// Requests call termination.
    /// </summary>
    /// <param name="reason">A non-empty open-enum reason.</param>
    /// <param name="mode"><c>drain</c> queued audio, or end immediately with <c>immediate</c>.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task EndCallAsync(string reason, string mode = "drain", CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(reason))
        {
            throw new ArgumentException("The reason must be a non-empty string.", nameof(reason));
        }

        if (mode is not ("drain" or "immediate"))
        {
            throw new ArgumentException("The mode must be 'drain' or 'immediate'.", nameof(mode));
        }

        return _connection.EndCallAsync(reason, mode, cancellationToken);
    }

    /// <summary>Explicitly cancels one pending or active DTMF collection.</summary>
    /// <param name="collectionId">The SDK-allocated <c>dc_</c> collection ID.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task CancelDtmfCollectionAsync(
        string collectionId,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(collectionId);
        if (!collectionId.StartsWith("dc_", StringComparison.Ordinal) || collectionId.Length <= 3)
        {
            throw new ArgumentException("The collection ID must start with dc_.", nameof(collectionId));
        }

        return _connection.CancelDtmfCollectionAsync(collectionId, cancellationToken);
    }

    /// <summary>Reports a terminal session-scoped agent failure.</summary>
    /// <param name="code">A bounded machine-readable open-enum code.</param>
    /// <param name="message">Sanitized diagnostic detail that must not contain sensitive content.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public virtual Task ReportErrorAsync(
        string code,
        string message,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(code);
        ArgumentNullException.ThrowIfNull(message);
        return _connection.ReportSessionErrorAsync(
            VoiceValidation.SafeCode(code, "agent_error"),
            VoiceValidation.SafeMessage(message, "Voice session failed"),
            cancellationToken);
    }
}
