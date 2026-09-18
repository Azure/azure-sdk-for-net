// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// LIVE connection-failure tests for Voice Agent realtime streaming -- mirrors the pattern used by
// sdk/voicelive/Azure.AI.VoiceLive/tests/LiveTests/ErrorTests.cs, adapted to
// ProjectsRealtimeSessionClient's realtime protocol surface. Covers the failure path when starting
// a session against a nonexistent agent.

using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP002

namespace Azure.AI.Projects.Tests.LiveTests;

public class ProjectsRealtimeConnectionErrorTests : ProjectsRealtimeLiveTestBase
{
    public ProjectsRealtimeConnectionErrorTests(bool isAsync) : base(isAsync)
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
        AIProjectClient client = GetLiveClient();
        using CancellationTokenSource timeout = new(TimeSpan.FromMinutes(1));

        WebSocketException exception = null;
        try
        {
            using ProjectsRealtimeSessionClient session = await client.GetProjectsRealtimeSessionClientAsync(
                "cs-e2e-tests-nonexistent-agent",
                cancellationToken: timeout.Token);
        }
        catch (WebSocketException ex)
        {
            exception = ex;
        }

        Assert.That(exception, Is.Not.Null, "Expected GetProjectsRealtimeSessionClientAsync to throw a WebSocketException for an unknown agent.");
    }
}
