// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for the <c>x-agent-session-id</c> response header (§8).
/// The resolved session ID MUST be echoed as a response header on every protocol
/// endpoint response — success and error alike.
/// </summary>
public class SessionIdResponseHeaderTests : ProtocolTestBase
{
    private const string SessionIdHeader = "x-agent-session-id";

    // ── POST /responses ──

    [Test]
    public async Task POST_Default_SessionIdHeader_IsPresent()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(SessionIdHeader), Is.True,
            "POST /responses response must include x-agent-session-id header");
        var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(headerValue, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task POST_Default_PayloadSessionId_EchoedAsHeader()
    {
        const string sessionId = "my-explicit-session-id";
        var response = await PostResponsesAsync(new { model = "test", agent_session_id = sessionId });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(headerValue, Is.EqualTo(sessionId));
    }

    [Test]
    public async Task POST_Streaming_SessionIdHeader_IsPresent()
    {
        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.Headers.Contains(SessionIdHeader), Is.True,
            "Streaming POST /responses must include x-agent-session-id header");
        var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(headerValue, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public async Task POST_Streaming_PayloadSessionId_EchoedAsHeader()
    {
        const string sessionId = "streaming-session-header-test";
        var response = await PostResponsesAsync(new { model = "test", stream = true, agent_session_id = sessionId });

        var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(headerValue, Is.EqualTo(sessionId));
    }

    [Test]
    public async Task POST_Background_SessionIdHeader_IsPresent()
    {
        var response = await PostResponsesAsync(new { model = "test", background = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(SessionIdHeader), Is.True);
    }

    // ── GET /responses/{id} ──

    [Test]
    public async Task GET_SessionIdHeader_MatchesResponseBody()
    {
        // Create with explicit session ID
        const string sessionId = "get-header-session";
        var createResponse = await PostResponsesAsync(new { model = "test", agent_session_id = sessionId });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        // GET the response — header should match body agent_session_id
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Headers.Contains(SessionIdHeader), Is.True);
        var headerValue = getResponse.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(headerValue, Is.EqualTo(sessionId));
    }

    // ── POST /responses/{id}/cancel ──

    [Test]
    public async Task Cancel_BackgroundInFlight_SessionIdHeader_IsPresent()
    {
        // Create a background response. The echo handler completes instantly,
        // but the orchestrator still processes it in-flight briefly.
        // Either cancel succeeds (header from response body) or background
        // completed first (cancel-after-completed error falls back to env var).
        const string sessionId = "cancel-header-session";
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", sessionId);
            FoundryEnvironment.Reload();

            var createResponse = await PostResponsesAsync(new { model = "test", background = true, agent_session_id = sessionId });
            using var createDoc = await ParseJsonAsync(createResponse);
            var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

            // Cancel — may succeed or return 400 if already completed.
            // Either way, the session ID header must be present.
            var cancelResponse = await CancelResponseAsync(responseId);
            Assert.That(cancelResponse.Headers.Contains(SessionIdHeader), Is.True,
                "Cancel response must include x-agent-session-id header");
            var headerValue = cancelResponse.Headers.GetValues(SessionIdHeader).Single();
            Assert.That(headerValue, Is.EqualTo(sessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── DELETE /responses/{id} ──

    [Test]
    public async Task Delete_SessionIdHeader_IsPresent()
    {
        const string sessionId = "delete-header-session";
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", sessionId);
            FoundryEnvironment.Reload();

            // Create a stored response
            var createResponse = await PostResponsesAsync(new { model = "test" });
            using var createDoc = await ParseJsonAsync(createResponse);
            var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

            // Delete — the resolved session ID header must be present.
            var deleteResponse = await Client.DeleteAsync($"/responses/{responseId}");
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(deleteResponse.Headers.Contains(SessionIdHeader), Is.True,
                "Delete response must include x-agent-session-id header");
            var headerValue = deleteResponse.Headers.GetValues(SessionIdHeader).Single();
            Assert.That(headerValue, Is.EqualTo(sessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── GET /responses/{id}/input_items ──

    [Test]
    public async Task InputItems_SessionIdHeader_IsPresent()
    {
        const string sessionId = "input-items-header-session";
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", sessionId);
            FoundryEnvironment.Reload();

            // Create a response
            var createResponse = await PostResponsesAsync(new { model = "test" });
            using var createDoc = await ParseJsonAsync(createResponse);
            var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

            // GET input items — the resolved session ID header must be present.
            var inputResponse = await Client.GetAsync($"/responses/{responseId}/input_items");
            Assert.That(inputResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(inputResponse.Headers.Contains(SessionIdHeader), Is.True,
                "Input items response must include x-agent-session-id header");
            var headerValue = inputResponse.Headers.GetValues(SessionIdHeader).Single();
            Assert.That(headerValue, Is.EqualTo(sessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── Error responses with env var fallback ──

    [Test]
    public async Task POST_ValidationError_SessionIdHeader_FallsBackToEnvVar()
    {
        // Set env var so the fallback path has a value
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        const string envSessionId = "env-fallback-session";
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", envSessionId);
            FoundryEnvironment.Reload();

            // Malformed JSON triggers 400 before session ID is resolved
            var response = await PostResponsesAsync("{invalid json");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Headers.Contains(SessionIdHeader), Is.True,
                "Error responses must include x-agent-session-id from env var fallback");
            var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
            Assert.That(headerValue, Is.EqualTo(envSessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    [Test]
    public async Task GET_NotFound_SessionIdHeader_FallsBackToEnvVar()
    {
        var originalValue = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID");
        const string envSessionId = "env-notfound-session";
        try
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", envSessionId);
            FoundryEnvironment.Reload();

            // Request a non-existent but format-valid response ID (caresp_ + 50 hex chars)
            var response = await GetResponseAsync("caresp_" + new string('0', 50));

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(response.Headers.Contains(SessionIdHeader), Is.True,
                "404 responses must include x-agent-session-id from env var fallback");
            var headerValue = response.Headers.GetValues(SessionIdHeader).Single();
            Assert.That(headerValue, Is.EqualTo(envSessionId));
        }
        finally
        {
            Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", originalValue);
            FoundryEnvironment.Reload();
        }
    }

    // ── Header consistency: POST session ID matches GET session ID ──

    [Test]
    public async Task SessionId_POST_And_GET_Headers_AreConsistent()
    {
        const string sessionId = "consistency-check-session";
        var createResponse = await PostResponsesAsync(new { model = "test", agent_session_id = sessionId });

        var postHeader = createResponse.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(postHeader, Is.EqualTo(sessionId));

        using var doc = await ParseJsonAsync(createResponse);
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        var getResponse = await GetResponseAsync(responseId);
        var getHeader = getResponse.Headers.GetValues(SessionIdHeader).Single();
        Assert.That(getHeader, Is.EqualTo(sessionId), "GET header must match POST header for same session");
    }
}
