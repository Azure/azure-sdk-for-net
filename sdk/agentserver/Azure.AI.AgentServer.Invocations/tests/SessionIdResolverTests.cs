// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class SessionIdResolverTests
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

        var result = SessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("session-from-query"));
    }

    [Test]
    public void Resolve_ReturnsEnvVar_WhenQueryParamMissing()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "session-from-env");
        FoundryEnvironment.Reload();
        var context = new DefaultHttpContext();

        var result = SessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("session-from-env"));
    }

    [Test]
    public void Resolve_GeneratesGuid_WhenBothMissing()
    {
        var context = new DefaultHttpContext();

        var result = SessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.Not.Null.And.Not.Empty);
        Assert.That(Guid.TryParse(result, out _), Is.True);
    }

    [Test]
    public void Resolve_QueryParam_TakesPriorityOverEnvVar()
    {
        Environment.SetEnvironmentVariable("FOUNDRY_AGENT_SESSION_ID", "env-session");
        FoundryEnvironment.Reload();
        var context = new DefaultHttpContext();
        context.Request.QueryString = new QueryString("?agent_session_id=query-session");

        var result = SessionIdResolver.Resolve(context.Request);

        Assert.That(result, Is.EqualTo("query-session"));
    }
}
