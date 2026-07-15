// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Agents.Builder.App;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ActivityServerTests
{
    [Test]
    public void Run_NullRequestHandler_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => ActivityServer.Run((RequestDelegate)null!));
    }

    [Test]
    public void Run_NullAgentApp_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => ActivityServer.Run((AgentApplication)null!));
    }

    [Test]
    public void Run_NullFactory_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => ActivityServer.Run((Func<IServiceProvider, AgentApplication>)null!));
    }

    [Test]
    public void Run_NullConfigureAgent_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => ActivityServer.Run((Action<AgentApplication>)null!));
    }
}
