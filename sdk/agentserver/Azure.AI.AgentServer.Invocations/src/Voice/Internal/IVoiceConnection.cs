// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Connection-scoped protocol operations consumed by the public response and
/// session helpers. Implementations serialize state transitions before writing.
/// </summary>
internal interface IVoiceConnection
{
    bool Ending { get; }

    Task SendResponseFrameAsync(
        VoiceResponse response,
        string messageType,
        IReadOnlyDictionary<string, object?> fields,
        Action commit,
        bool terminal,
        string? terminalKind,
        CancellationToken cancellationToken);

    Task<bool> OpenResponseAsync(
        VoiceResponse response,
        IReadOnlyList<string>? inReplyTo,
        CancellationToken cancellationToken);

    Task DeclineResponseAsync(
        VoiceResponse response,
        IReadOnlyList<string> inReplyTo,
        string? reason,
        CancellationToken cancellationToken);

    Task<Task<ResponseCancellationOutcome>> BeginCancelAsync(
        VoiceResponse response,
        string? reason,
        CancellationToken cancellationToken);

    Task EndCallAsync(string reason, string mode, CancellationToken cancellationToken);

    Task<VoiceResponse> StartProactiveResponseAsync(
        int admissionTimeoutMs,
        string? supersedeKey,
        CancellationToken cancellationToken);

    Task ReportSessionErrorAsync(string code, string message, CancellationToken cancellationToken);
}
