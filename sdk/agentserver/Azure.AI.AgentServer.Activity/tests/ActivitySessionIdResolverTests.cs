// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
[NonParallelizable]
public class ActivitySessionIdResolverTests
{
    [TearDown]
    public void TearDown()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", null);
        FoundryEnvironment.Reload();
    }

    [Test]
    public void Resolve_ReturnsQueryParam_WhenPresent()
    {
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?agent_session_id=session-from-query");

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("session-from-query"));
    }

    [Test]
    public void Resolve_ReturnsHeader_WhenQueryMissing()
    {
        var context = new DefaultHttpContext();
        context.Request.Headers[PlatformHeaders.SessionId] = "session-from-header";

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("session-from-header"));
    }

    [Test]
    public void Resolve_ReturnsEnvVar_WhenQueryAndHeaderMissing()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "session-from-env");
        FoundryEnvironment.Reload();
        var context = new DefaultHttpContext();

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("session-from-env"));
    }

    [Test]
    public void Resolve_GeneratesGuid_WhenAllMissing()
    {
        var context = new DefaultHttpContext();

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.Not.Null.And.Not.Empty);
        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Resolve_QueryParam_TakesPriority_OverHeader()
    {
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?agent_session_id=from-query");
        context.Request.Headers[PlatformHeaders.SessionId] = "from-header";

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("from-query"));
    }

    [Test]
    public void Resolve_Header_TakesPriority_OverEnvVar()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "from-env");
        FoundryEnvironment.Reload();
        var context = new DefaultHttpContext();
        context.Request.Headers[PlatformHeaders.SessionId] = "from-header";

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("from-header"));
    }

    [Test]
    public void Resolve_EmptyQueryParam_FallsThroughToHeader()
    {
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?agent_session_id=");
        context.Request.Headers[PlatformHeaders.SessionId] = "from-header";

        var result = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("from-header"));
    }

    [Test]
    public void Resolve_GeneratesUniqueIds_OnSuccessiveCalls()
    {
        var context = new DefaultHttpContext();

        var first = ActivitySessionIdResolver.Resolve(context.Request);
        var second = ActivitySessionIdResolver.Resolve(context.Request);

        Assert.That(first, Is.Not.EqualTo(second));
    }
}
