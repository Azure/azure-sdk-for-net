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
        httpContext.Request.Headers[IsolationContext.UserIsolationKeyHeaderName] = "user-key-abc";
        httpContext.Request.Headers[IsolationContext.ChatIsolationKeyHeaderName] = "chat-key-xyz";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("user-key-abc"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("chat-key-xyz"));
    }

    [Test]
    public void FromRequest_OnlyUserHeader_ReturnsChatAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[IsolationContext.UserIsolationKeyHeaderName] = "user-only";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("user-only"));
        Assert.That(result.ChatIsolationKey, Is.Null);
    }

    [Test]
    public void FromRequest_OnlyChatHeader_ReturnsUserAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[IsolationContext.ChatIsolationKeyHeaderName] = "chat-only";

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
        httpContext.Request.Headers[IsolationContext.UserIsolationKeyHeaderName] = "";
        httpContext.Request.Headers[IsolationContext.ChatIsolationKeyHeaderName] = "";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void FromRequest_EqualKeysInOneToOneChat_BothPopulated()
    {
        // In a 1:1 user↔agent chat the two keys are equal.
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[IsolationContext.UserIsolationKeyHeaderName] = "same-key";
        httpContext.Request.Headers[IsolationContext.ChatIsolationKeyHeaderName] = "same-key";

        var result = IsolationContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIsolationKey, Is.EqualTo("same-key"));
        Assert.That(result.ChatIsolationKey, Is.EqualTo("same-key"));
    }

    [Test]
    public void HeaderNameConstants_MatchExpectedValues()
    {
        Assert.That(IsolationContext.UserIsolationKeyHeaderName, Is.EqualTo("x-agent-user-isolation-key"));
        Assert.That(IsolationContext.ChatIsolationKeyHeaderName, Is.EqualTo("x-agent-chat-isolation-key"));
    }
}
