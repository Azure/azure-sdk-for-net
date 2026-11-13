// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class ClientHeaderForwarderTests
{
    [Test]
    public void ExtractClientHeaders_ReturnsXClientHeaders()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["x-client-foo"] = "bar";
        context.Request.Headers["x-client-baz"] = "qux";
        context.Request.Headers["Authorization"] = "Bearer token";
        context.Request.Headers["Content-Type"] = "application/json";

        var result = ClientHeaderForwarder.ExtractClientHeaders(context.Request);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result["x-client-foo"], Is.EqualTo("bar"));
        Assert.That(result["x-client-baz"], Is.EqualTo("qux"));
    }

    [Test]
    public void ExtractClientHeaders_ReturnsEmpty_WhenNoXClientHeaders()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["Authorization"] = "Bearer token";

        var result = ClientHeaderForwarder.ExtractClientHeaders(context.Request);

        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]
    public void ExtractClientHeaders_IsCaseInsensitive()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers["X-Client-Test"] = "value";

        var result = ClientHeaderForwarder.ExtractClientHeaders(context.Request);

        Assert.That(result.Count, Is.EqualTo(1));
    }

    [Test]
    public void ExtractQueryParameters_ReturnsAllParams()
    {
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?key1=val1&key2=val2");

        var result = ClientHeaderForwarder.ExtractQueryParameters(context.Request);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result["key1"].ToString(), Is.EqualTo("val1"));
        Assert.That(result["key2"].ToString(), Is.EqualTo("val2"));
    }

    [Test]
    public void ExtractQueryParameters_ReturnsEmpty_WhenNoParams()
    {
        var context = new DefaultHttpContext();

        var result = ClientHeaderForwarder.ExtractQueryParameters(context.Request);

        Assert.That(result.Count, Is.EqualTo(0));
    }

    [Test]
    public void ExtractQueryParameters_IncludesAgentSessionId()
    {
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?agent_session_id=sess-1&custom=val");

        var result = ClientHeaderForwarder.ExtractQueryParameters(context.Request);

        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result["agent_session_id"].ToString(), Is.EqualTo("sess-1"));
        Assert.That(result["custom"].ToString(), Is.EqualTo("val"));
    }
}
