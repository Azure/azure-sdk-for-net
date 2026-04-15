// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for session ID resolution (B39).
/// Priority: request payload <c>agent_session_id</c> → <c>FOUNDRY_AGENT_SESSION_ID</c> env var → generated UUID.
/// The resolved session ID MUST be auto-stamped on the <c>ResponseObject.AgentSessionId</c>.
/// </summary>
public class SessionIdResolutionTests : ProtocolTestBase
{
    // ── Tier 1: Payload agent_session_id takes priority ──

    [Test]
    public async Task POST_Default_PayloadAgentSessionId_IsStampedOnResponse()
    {
        const string sessionId = "my-session-from-payload";
        var response = await PostResponsesAsync(new { model = "test", agent_session_id = sessionId });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(
            doc.RootElement.GetProperty("agent_session_id").GetString(),
            Is.EqualTo(sessionId));
    }

    [Test]
    public async Task POST_Streaming_PayloadAgentSessionId_IsStampedOnResponse()
    {
        const string sessionId = "streaming-session-xyz";
        var response = await PostResponsesAsync(new { model = "test", stream = true, agent_session_id = sessionId });
        var events = await ParseSseAsync(response);

        // Check response.created event
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var createdDoc = JsonDocument.Parse(createdEvent.Data);
        Assert.That(
            createdDoc.RootElement.GetProperty("response").GetProperty("agent_session_id").GetString(),
            Is.EqualTo(sessionId));

        // Check response.completed event
        var completedEvent = events.First(e => e.EventType == "response.completed");
        using var completedDoc = JsonDocument.Parse(completedEvent.Data);
        Assert.That(
            completedDoc.RootElement.GetProperty("response").GetProperty("agent_session_id").GetString(),
            Is.EqualTo(sessionId));
    }

    [Test]
    public async Task POST_Background_PayloadAgentSessionId_IsStampedOnResponse()
    {
        const string sessionId = "bg-session-abc";
        var response = await PostResponsesAsync(new { model = "test", background = true, agent_session_id = sessionId });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(
            doc.RootElement.GetProperty("agent_session_id").GetString(),
            Is.EqualTo(sessionId));
    }

    // ── Tier 2: Fallback to FoundryEnvironment.SessionId ──

    [Test]
    public async Task POST_Default_NoPayloadSessionId_FallsBackToEnvVar()
    {
        const string envSessionId = "env-session-from-foundry";

        // Temporarily set and reload the environment variable
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", envSessionId);
            FoundryEnvironment.Reload();

            var response = await PostResponsesAsync(new { model = "test" });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = await ParseJsonAsync(response);
            Assert.That(
                doc.RootElement.GetProperty("agent_session_id").GetString(),
                Is.EqualTo(envSessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    [Test]
    public async Task POST_Default_PayloadSessionId_OverridesEnvVar()
    {
        const string payloadSessionId = "payload-wins";
        const string envSessionId = "env-loses";

        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", envSessionId);
            FoundryEnvironment.Reload();

            var response = await PostResponsesAsync(new { model = "test", agent_session_id = payloadSessionId });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = await ParseJsonAsync(response);
            Assert.That(
                doc.RootElement.GetProperty("agent_session_id").GetString(),
                Is.EqualTo(payloadSessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── Tier 3: Fallback to generated UUID ──

    [Test]
    public async Task POST_Default_NoPayloadOrEnv_GeneratesSessionId()
    {
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
            FoundryEnvironment.Reload();

            var response = await PostResponsesAsync(new { model = "test" });

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            using var doc = await ParseJsonAsync(response);
            var sessionId = doc.RootElement.GetProperty("agent_session_id").GetString();
            Assert.That(sessionId, Is.Not.Null.And.Not.Empty);

            // Verify it's a valid GUID
            Assert.That(Guid.TryParse(sessionId, out _), Is.True,
                $"Expected a GUID-format session ID, got: {sessionId}");
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    [Test]
    public async Task POST_Default_GeneratedSessionId_IsDifferentPerRequest()
    {
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
            FoundryEnvironment.Reload();

            var response1 = await PostResponsesAsync(new { model = "test" });
            var response2 = await PostResponsesAsync(new { model = "test" });

            using var doc1 = await ParseJsonAsync(response1);
            using var doc2 = await ParseJsonAsync(response2);
            var sessionId1 = doc1.RootElement.GetProperty("agent_session_id").GetString();
            var sessionId2 = doc2.RootElement.GetProperty("agent_session_id").GetString();

            Assert.That(sessionId1, Is.Not.EqualTo(sessionId2),
                "Generated session IDs should be unique per request");
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── Cross-mode consistency ──

    [Test]
    public async Task POST_Streaming_NoPayloadOrEnv_StampsGeneratedSessionId()
    {
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
            FoundryEnvironment.Reload();

            var response = await PostResponsesAsync(new { model = "test", stream = true });
            var events = await ParseSseAsync(response);

            var completedEvent = events.First(e => e.EventType == "response.completed");
            using var doc = JsonDocument.Parse(completedEvent.Data);
            var sessionId = doc.RootElement.GetProperty("response").GetProperty("agent_session_id").GetString();

            Assert.That(sessionId, Is.Not.Null.And.Not.Empty);
            Assert.That(Guid.TryParse(sessionId, out _), Is.True);
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }
}
