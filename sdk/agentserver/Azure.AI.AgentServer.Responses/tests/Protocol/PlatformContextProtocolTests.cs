// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E tests verifying that <c>x-agent-user-id</c> and
/// <c>x-agent-foundry-call-id</c> headers flow through to the
/// <see cref="ResponseContext.PlatformContext"/> property.
/// </summary>
public class PlatformContextProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_IsolationHeaders_FlowToContext()
    {
        var response = await PostWithIsolationAsync("user-abc", "call-xyz");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext, Is.Not.Null);
        Assert.That(Handler.LastContext!.PlatformContext.UserIdKey, Is.EqualTo("user-abc"));
        Assert.That(Handler.LastContext.PlatformContext.CallId, Is.EqualTo("call-xyz"));
    }

    [Test]
    public async Task POST_Responses_NoIsolationHeaders_ReturnsEmpty()
    {
        await PostResponsesAsync(new { model = "test" });

        Assert.That(Handler.LastContext, Is.Not.Null);
        Assert.That(Handler.LastContext!.PlatformContext, Is.SameAs(PlatformContext.Empty));
        Assert.That(Handler.LastContext.PlatformContext.UserIdKey, Is.Null);
        Assert.That(Handler.LastContext.PlatformContext.CallId, Is.Null);
    }

    [Test]
    public async Task POST_Responses_OnlyUserIsolationHeader_CallIsNull()
    {
        var response = await PostWithIsolationAsync("user-only", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.PlatformContext.UserIdKey, Is.EqualTo("user-only"));
        Assert.That(Handler.LastContext.PlatformContext.CallId, Is.Null);
    }

    [Test]
    public async Task POST_Responses_OnlyCallIsolationHeader_UserIsNull()
    {
        var response = await PostWithIsolationAsync(null, "call-only");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.PlatformContext.UserIdKey, Is.Null);
        Assert.That(Handler.LastContext.PlatformContext.CallId, Is.EqualTo("call-only"));
    }

    [Test]
    public async Task POST_Responses_EqualKeys_OneToOneCall()
    {
        // In a 1:1 call, both keys are equal.
        var response = await PostWithIsolationAsync("same-key", "same-key");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.PlatformContext.UserIdKey, Is.EqualTo("same-key"));
        Assert.That(Handler.LastContext.PlatformContext.CallId, Is.EqualTo("same-key"));
    }

    [Test]
    public async Task POST_Responses_EmptyIsolationHeaders_TreatedAsAbsent()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test" }),
                Encoding.UTF8,
                "application/json")
        };
        request.Headers.Add(PlatformHeaders.UserId, "");
        request.Headers.Add(PlatformHeaders.FoundryCallId, "");
        await Client.SendAsync(request);

        Assert.That(Handler.LastContext!.PlatformContext, Is.SameAs(PlatformContext.Empty));
    }

    // ─── helpers ──────────────────────────────────────────────

    private async Task<HttpResponseMessage> PostWithIsolationAsync(
        string? userKey, string? callId)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(
                JsonSerializer.Serialize(new { model = "test" }),
                Encoding.UTF8,
                "application/json")
        };

        if (userKey is not null)
        {
            request.Headers.Add(PlatformHeaders.UserId, userKey);
        }

        if (callId is not null)
        {
            request.Headers.Add(PlatformHeaders.FoundryCallId, callId);
        }

        return await Client.SendAsync(request);
    }
}
