// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class IsolationContextFromRequestTests
{
    [Test]
    public void FromRequest_BothHeaders_ReturnsPopulatedContext()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "user-key-abc";
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = "chat-key-xyz";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("user-key-abc"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("chat-key-xyz"));
    }

    [Test]
    public void FromRequest_OnlyUserHeader_ReturnsChatAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "user-only";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("user-only"));
        Assert.That(result.ChatIsolationKey, Is.Null);
    }

    [Test]
    public void FromRequest_OnlyChatHeader_ReturnsUserAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = "chat-only";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.Null);
        Assert.That(result.ChatIsolationKey, Is.EqualTo("chat-only"));
    }

    [Test]
    public void FromRequest_NoHeaders_ReturnsEmpty()
    {
        var httpContext = new DefaultHttpContext();

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void FromRequest_EmptyStringHeaders_TreatedAsAbsent()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "";
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = "";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void FromRequest_WhitespaceOnlyHeaders_TreatedAsAbsent()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "   ";
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = "\t";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void FromRequest_MultipleHeaderValues_UsesFirstValue()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Append(PlatformHeaders.UserIsolationKey, "first-user");
        httpContext.Request.Headers.Append(PlatformHeaders.UserIsolationKey, "second-user");
        httpContext.Request.Headers.Append(PlatformHeaders.ChatIsolationKey, "first-chat");
        httpContext.Request.Headers.Append(PlatformHeaders.ChatIsolationKey, "second-chat");

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("first-user"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("first-chat"));
    }

    [Test]
    public void FromRequest_HeaderWithLeadingTrailingWhitespace_IsTrimmed()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "  user-key  ";
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = " chat-key ";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("user-key"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("chat-key"));
    }

    [Test]
    public void FromRequest_EqualKeysInOneToOneChat_BothPopulated()
    {
        // In a 1:1 user↔agent chat the two keys are equal.
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserIsolationKey] = "same-key";
        httpContext.Request.Headers[PlatformHeaders.ChatIsolationKey] = "same-key";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("same-key"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("same-key"));
    }

    [Test]
    public void HeaderNameConstants_MatchExpectedValues()
    {
        Assert.That(PlatformHeaders.UserIsolationKey, Is.EqualTo("x-agent-user-isolation-key"));
        Assert.That(PlatformHeaders.ChatIsolationKey, Is.EqualTo("x-agent-chat-isolation-key"));
    }
}
