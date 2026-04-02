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
/// E2E tests verifying that <c>x-agent-user-isolation-key</c> and
/// <c>x-agent-chat-isolation-key</c> headers flow through to the
/// <see cref="ResponseContext.Isolation"/> property.
/// </summary>
public class IsolationContextProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_IsolationHeaders_FlowToContext()
    {
        var response = await PostWithIsolationAsync("user-abc", "chat-xyz");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext, Is.Not.Null);
        Assert.That(Handler.LastContext!.Isolation.UserIsolationKey, Is.EqualTo("user-abc"));
        Assert.That(Handler.LastContext.Isolation.ChatIsolationKey, Is.EqualTo("chat-xyz"));
    }

    [Test]
    public async Task POST_Responses_NoIsolationHeaders_ReturnsEmpty()
    {
        await PostResponsesAsync(new { model = "test" });

        Assert.That(Handler.LastContext, Is.Not.Null);
        Assert.That(Handler.LastContext!.Isolation, Is.SameAs(IsolationContext.Empty));
        Assert.That(Handler.LastContext.Isolation.UserIsolationKey, Is.Null);
        Assert.That(Handler.LastContext.Isolation.ChatIsolationKey, Is.Null);
    }

    [Test]
    public async Task POST_Responses_OnlyUserIsolationHeader_ChatIsNull()
    {
        var response = await PostWithIsolationAsync("user-only", null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.Isolation.UserIsolationKey, Is.EqualTo("user-only"));
        Assert.That(Handler.LastContext.Isolation.ChatIsolationKey, Is.Null);
    }

    [Test]
    public async Task POST_Responses_OnlyChatIsolationHeader_UserIsNull()
    {
        var response = await PostWithIsolationAsync(null, "chat-only");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.Isolation.UserIsolationKey, Is.Null);
        Assert.That(Handler.LastContext.Isolation.ChatIsolationKey, Is.EqualTo("chat-only"));
    }

    [Test]
    public async Task POST_Responses_EqualKeys_OneToOneChat()
    {
        // In a 1:1 chat, both keys are equal.
        var response = await PostWithIsolationAsync("same-key", "same-key");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(Handler.LastContext!.Isolation.UserIsolationKey, Is.EqualTo("same-key"));
        Assert.That(Handler.LastContext.Isolation.ChatIsolationKey, Is.EqualTo("same-key"));
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
        request.Headers.Add(IsolationContext.UserIsolationKeyHeaderName, "");
        request.Headers.Add(IsolationContext.ChatIsolationKeyHeaderName, "");
        await Client.SendAsync(request);

        Assert.That(Handler.LastContext!.Isolation, Is.SameAs(IsolationContext.Empty));
    }

    // ─── helpers ──────────────────────────────────────────────

    private async Task<HttpResponseMessage> PostWithIsolationAsync(
        string? userKey, string? chatKey)
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
            request.Headers.Add(IsolationContext.UserIsolationKeyHeaderName, userKey);
        }

        if (chatKey is not null)
        {
            request.Headers.Add(IsolationContext.ChatIsolationKeyHeaderName, chatKey);
        }

        return await Client.SendAsync(request);
    }
}
