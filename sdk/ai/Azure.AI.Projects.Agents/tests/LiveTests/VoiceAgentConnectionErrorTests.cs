// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE connection-failure tests for Voice Agent WebSocket streaming — mirrors the pattern used
// by sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/ErrorTests.cs, adapted to
// VoiceAgentSession's realtime protocol surface. Covers the failure path when starting a
// session against a nonexistent agent.

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001

namespace Azure.AI.Projects.Agents.Tests.LiveTests;

public class VoiceAgentConnectionErrorTests : VoiceAgentLiveTestBase
{
    public VoiceAgentConnectionErrorTests(bool isAsync) : base(isAsync)
    {
    }

    // -----------------------------------------------------------------------
    // Verifies: starting a session against a nonexistent agent surfaces the
    // failed handshake as a WebSocketException rather than hanging or
    // succeeding.
    // -----------------------------------------------------------------------
    [Test]
    [AsyncOnly]
    public async Task StartSessionThrowsForUnknownAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));
        VoiceAgentWebSocket realtimeClient = agentsClient.GetVoiceAgentWebSocket();

        WebSocketException exception = null;
        try
        {
            await using VoiceAgentSession session = await realtimeClient.StartSessionAsync(
                "cs-e2e-tests-nonexistent-agent",
                cancellationToken: timeout.Token);
        }
        catch (WebSocketException ex)
        {
            exception = ex;
        }

        Assert.That(exception, Is.Not.Null, "Expected StartSessionAsync to throw a WebSocketException for an unknown agent.");
    }
}
