// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class PlatformContextFromRequestTests
{
    [Test]
    public void FromRequest_BothHeaders_ReturnsPopulatedContext()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "user-key-abc";
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = "call-id-xyz";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.EqualTo("user-key-abc"));
        Assert.That(result.CallId, Is.EqualTo("call-id-xyz"));
    }

    [Test]
    public void FromRequest_OnlyUserHeader_ReturnsCallIdAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "user-only";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.EqualTo("user-only"));
        Assert.That(result.CallId, Is.Null);
    }

    [Test]
    public void FromRequest_OnlyCallIdHeader_ReturnsUserAsNull()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = "call-id-only";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.Null);
        Assert.That(result.CallId, Is.EqualTo("call-id-only"));
    }

    [Test]
    public void FromRequest_NoHeaders_ReturnsEmpty()
    {
        var httpContext = new DefaultHttpContext();

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(PlatformContext.Empty));
    }

    [Test]
    public void FromRequest_EmptyStringHeaders_TreatedAsAbsent()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "";
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = "";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(PlatformContext.Empty));
    }

    [Test]
    public void FromRequest_WhitespaceOnlyHeaders_TreatedAsAbsent()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "   ";
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = "\t";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result, Is.SameAs(PlatformContext.Empty));
    }

    [Test]
    public void FromRequest_MultipleHeaderValues_UsesFirstValue()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers.Append(PlatformHeaders.UserId, "first-user");
        httpContext.Request.Headers.Append(PlatformHeaders.UserId, "second-user");
        httpContext.Request.Headers.Append(PlatformHeaders.FoundryCallId, "first-call");
        httpContext.Request.Headers.Append(PlatformHeaders.FoundryCallId, "second-call");

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.EqualTo("first-user"));
        Assert.That(result.CallId, Is.EqualTo("first-call"));
    }

    [Test]
    public void FromRequest_HeaderWithLeadingTrailingWhitespace_IsTrimmed()
    {
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "  user-key  ";
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = " call-id ";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.EqualTo("user-key"));
        Assert.That(result.CallId, Is.EqualTo("call-id"));
    }

    [Test]
    public void FromRequest_EqualKeysInOneToOneSession_BothPopulated()
    {
        // In a 1:1 user↔agent session the user id and call id can be equal.
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Headers[PlatformHeaders.UserId] = "same-key";
        httpContext.Request.Headers[PlatformHeaders.FoundryCallId] = "same-key";

        var result = PlatformContext.FromRequest(httpContext.Request);

        Assert.That(result.UserIdKey, Is.EqualTo("same-key"));
        Assert.That(result.CallId, Is.EqualTo("same-key"));
    }

    [Test]
    public void HeaderNameConstants_MatchExpectedValues()
    {
        Assert.That(PlatformHeaders.UserId, Is.EqualTo("x-agent-user-id"));
        Assert.That(PlatformHeaders.FoundryCallId, Is.EqualTo("x-agent-foundry-call-id"));
    }
}
