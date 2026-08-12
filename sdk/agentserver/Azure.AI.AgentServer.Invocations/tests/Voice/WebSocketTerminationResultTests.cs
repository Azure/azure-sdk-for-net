// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.WebSockets;
using Azure.AI.AgentServer.Invocations.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Voice;

public class WebSocketTerminationResultTests
{
    [Test]
    public void AbortOverridesSelectedAndAttemptedCloseCodes()
    {
        var result = WebSocketTerminationResult.Create(
            sessionId: "session",
            selectedCloseCode: 1008,
            attemptedCloseCode: 1008,
            attemptApi: WebSocketCloseAttemptApi.CloseAsync,
            peerCloseCode: null,
            localCloseInitiated: true,
            wasAborted: true,
            closeOperationSucceeded: false,
            socketState: WebSocketState.Aborted,
            errorCode: null,
            durationMs: 12,
            endTimeUtc: DateTime.UtcNow);

        Assert.Multiple(() =>
        {
            Assert.That(result.SelectedCloseCode, Is.EqualTo(1008));
            Assert.That(result.AttemptedCloseCode, Is.EqualTo(1008));
            Assert.That(result.FinalCloseCode, Is.EqualTo(1006));
            Assert.That(result.Outcome, Is.EqualTo(WebSocketTerminationOutcome.Aborted));
        });
    }

    [Test]
    public void PeerCloseWinsWhenTransportWasNotAborted()
    {
        var result = WebSocketTerminationResult.Create(
            sessionId: "session",
            selectedCloseCode: null,
            attemptedCloseCode: null,
            attemptApi: WebSocketCloseAttemptApi.None,
            peerCloseCode: 1001,
            localCloseInitiated: false,
            wasAborted: false,
            closeOperationSucceeded: false,
            socketState: WebSocketState.Closed,
            errorCode: null,
            durationMs: 12,
            endTimeUtc: DateTime.UtcNow);

        Assert.Multiple(() =>
        {
            Assert.That(result.FinalCloseCode, Is.EqualTo(1001));
            Assert.That(result.Outcome, Is.EqualTo(WebSocketTerminationOutcome.PeerClosed));
        });
    }

    [Test]
    public void CloseOutputRemainsHalfCloseOutcome()
    {
        var result = WebSocketTerminationResult.Create(
            sessionId: "session",
            selectedCloseCode: 1008,
            attemptedCloseCode: 1008,
            attemptApi: WebSocketCloseAttemptApi.CloseOutputAsync,
            peerCloseCode: null,
            localCloseInitiated: true,
            wasAborted: false,
            closeOperationSucceeded: true,
            socketState: WebSocketState.CloseSent,
            errorCode: null,
            durationMs: 12,
            endTimeUtc: DateTime.UtcNow);

        Assert.Multiple(() =>
        {
            Assert.That(result.FinalCloseCode, Is.EqualTo(1008));
            Assert.That(result.Outcome, Is.EqualTo(WebSocketTerminationOutcome.LocalCloseOutputCompleted));
        });
    }

    [Test]
    public void InternalFailureIntentIsNotOverriddenByEarlierSelectedCode()
    {
        var result = WebSocketTerminationResult.Create(
            sessionId: "session",
            selectedCloseCode: 1000,
            attemptedCloseCode: 1011,
            attemptApi: WebSocketCloseAttemptApi.CloseAsync,
            peerCloseCode: null,
            localCloseInitiated: true,
            wasAborted: false,
            closeOperationSucceeded: true,
            socketState: WebSocketState.CloseSent,
            errorCode: InvocationsWebSocketConstants.ErrorCodeInternalError,
            durationMs: 12,
            endTimeUtc: DateTime.UtcNow);

        Assert.That(result.FinalCloseCode, Is.EqualTo(1011));
    }

    [Test]
    public void LocalCloseAttemptWinsOverPeerAcknowledgementCode()
    {
        var result = WebSocketTerminationResult.Create(
            sessionId: "session",
            selectedCloseCode: 1011,
            attemptedCloseCode: 1011,
            attemptApi: WebSocketCloseAttemptApi.CloseAsync,
            peerCloseCode: 1000,
            localCloseInitiated: true,
            wasAborted: false,
            closeOperationSucceeded: true,
            socketState: WebSocketState.Closed,
            errorCode: null,
            durationMs: 12,
            endTimeUtc: DateTime.UtcNow);

        Assert.Multiple(() =>
        {
            Assert.That(result.FinalCloseCode, Is.EqualTo(1011));
            Assert.That(result.Outcome, Is.EqualTo(WebSocketTerminationOutcome.LocalCloseCompleted));
        });
    }
}
