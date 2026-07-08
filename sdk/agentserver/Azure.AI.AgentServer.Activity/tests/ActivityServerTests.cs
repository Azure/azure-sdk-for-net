// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ActivityServerTests
{
    [Test]
    public void Create_WithRequestHandler_AgentAppThrows()
    {
        var host = ActivityServer.Create((RequestDelegate)(_ => System.Threading.Tasks.Task.CompletedTask));

        Assert.That(host, Is.Not.Null);
        Assert.Throws<InvalidOperationException>(() => _ = host.AgentApp);
    }

    [Test]
    public void Create_NullRequestHandler_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => ActivityServer.Create((RequestDelegate)null!));
    }

    [Test]
    public void Create_NullAgentApp_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => ActivityServer.Create((Microsoft.Agents.Builder.App.AgentApplication)null!));
    }

    [Test]
    public void Configure_NullCallback_Throws()
    {
        var host = ActivityServer.Create((RequestDelegate)(_ => System.Threading.Tasks.Task.CompletedTask));
        Assert.Throws<ArgumentNullException>(() => host.Configure(null!));
    }
}
