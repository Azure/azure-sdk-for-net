// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;

namespace Azure.AI.AgentServer.Invocations.Internal;

internal enum WebSocketCloseAttemptApi
{
    None,
    CloseAsync,
    CloseOutputAsync,
}

internal enum WebSocketTerminationOutcome
{
    NoSocket,
    PeerClosed,
    LocalCloseCompleted,
    LocalCloseOutputCompleted,
    InternalFailure,
    Aborted,
    AlreadyClosed,
}

/// <summary>
/// Immutable connection-terminal truth shared by final activities, logs, and
/// metrics. Selected and attempted codes are diagnostic stages; only
/// <see cref="FinalCloseCode"/> is the endpoint's final transport classification.
/// </summary>
internal sealed record WebSocketTerminationResult(
    string SessionId,
    int? SelectedCloseCode,
    int? AttemptedCloseCode,
    int FinalCloseCode,
    WebSocketCloseAttemptApi AttemptApi,
    WebSocketTerminationOutcome Outcome,
    string? ErrorCode,
    long DurationMs,
    DateTime EndTimeUtc)
{
    public string OutcomeName => GetOutcomeName(Outcome);

    internal static string GetOutcomeName(WebSocketTerminationOutcome outcome) => outcome switch
    {
        WebSocketTerminationOutcome.NoSocket => "no_socket",
        WebSocketTerminationOutcome.PeerClosed => "peer_closed",
        WebSocketTerminationOutcome.LocalCloseCompleted => "local_close_completed",
        WebSocketTerminationOutcome.LocalCloseOutputCompleted => "local_close_output_completed",
        WebSocketTerminationOutcome.InternalFailure => "internal_failure",
        WebSocketTerminationOutcome.Aborted => "aborted",
        _ => "already_closed",
    };

    public static WebSocketTerminationResult Create(
        string sessionId,
        int? selectedCloseCode,
        int? attemptedCloseCode,
        WebSocketCloseAttemptApi attemptApi,
        int? peerCloseCode,
        bool localCloseInitiated,
        bool wasAborted,
        bool closeOperationSucceeded,
        WebSocketState socketState,
        string? errorCode,
        long durationMs,
        DateTime endTimeUtc)
    {
        ArgumentException.ThrowIfNullOrEmpty(sessionId);

        int finalCloseCode;
        WebSocketTerminationOutcome outcome;
        if (socketState == WebSocketState.None && attemptedCloseCode is null)
        {
            finalCloseCode = selectedCloseCode ?? InvocationsWebSocketConstants.CloseInternalError;
            outcome = WebSocketTerminationOutcome.NoSocket;
        }
        else if (wasAborted || socketState == WebSocketState.Aborted)
        {
            finalCloseCode = 1006;
            outcome = WebSocketTerminationOutcome.Aborted;
        }
        else if (errorCode == InvocationsWebSocketConstants.ErrorCodeInternalError)
        {
            finalCloseCode = InvocationsWebSocketConstants.CloseInternalError;
            outcome = WebSocketTerminationOutcome.InternalFailure;
        }
        else if (localCloseInitiated &&
            closeOperationSucceeded &&
            attemptedCloseCode is int attemptedCode)
        {
            finalCloseCode = attemptedCode;
            outcome = attemptApi == WebSocketCloseAttemptApi.CloseOutputAsync
                ? WebSocketTerminationOutcome.LocalCloseOutputCompleted
                : WebSocketTerminationOutcome.LocalCloseCompleted;
        }
        else if (peerCloseCode is int peerCode)
        {
            finalCloseCode = peerCode;
            outcome = WebSocketTerminationOutcome.PeerClosed;
        }
        else if (socketState is WebSocketState.Closed or WebSocketState.CloseSent)
        {
            finalCloseCode = attemptedCloseCode ?? 1006;
            outcome = WebSocketTerminationOutcome.AlreadyClosed;
        }
        else
        {
            finalCloseCode = 1006;
            outcome = WebSocketTerminationOutcome.Aborted;
        }

        return new WebSocketTerminationResult(
            sessionId,
            selectedCloseCode,
            attemptedCloseCode,
            finalCloseCode,
            attemptApi,
            outcome,
            errorCode,
            durationMs,
            endTimeUtc);
    }

    public static int MapWireCloseCode(int closeCode) =>
        closeCode is >= 1000 and <= 4999 &&
        closeCode is not (1004 or 1005 or 1006 or 1015)
            ? closeCode
            : InvocationsWebSocketConstants.CloseInternalError;
}
