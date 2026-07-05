// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class InvocationIdResolverTests
{
    [Test]
    public void Resolve_ReturnsHeaderValue_WhenPresent()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["x-agent-invocation-id"] = "my-known-id";

        var result = InvocationIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("my-known-id"));
    }

    [Test]
    public void Resolve_GeneratesGuid_WhenHeaderMissing()
    {
        var context = new DefaultHttpContext();

        var result = InvocationIdResolver.Resolve(context.Request);

        Assert.That(result, Is.Not.Null.And.Not.Empty);
        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Resolve_GeneratesGuid_WhenHeaderEmpty()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["x-agent-invocation-id"] = "";

        var result = InvocationIdResolver.Resolve(context.Request);

        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Resolve_GeneratesUniqueIds_OnSuccessiveCalls()
    {
        var context1 = new DefaultHttpContext();
        var context2 = new DefaultHttpContext();

        var id1 = InvocationIdResolver.Resolve(context1.Request);
        var id2 = InvocationIdResolver.Resolve(context2.Request);

        Assert.That(id1, Is.Not.EqualTo(id2));
    }
}
