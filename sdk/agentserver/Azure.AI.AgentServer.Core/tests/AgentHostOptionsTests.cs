// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class AgentHostOptionsTests
{
    [Test]
    public void DefaultShutdownTimeout_Is30Seconds()
    {
        var options = new AgentHostOptions();
        Assert.That(options.ShutdownTimeout, Is.EqualTo(TimeSpan.FromSeconds(30)));
    }

    [Test]
    public void AdditionalServerIdentity_DefaultsToNull()
    {
        var options = new AgentHostOptions();
        Assert.That(options.AdditionalServerIdentity, Is.Null);
    }

    [Test]
    public void Validate_ThrowsForNegativeShutdownTimeout()
    {
        var options = new AgentHostOptions { ShutdownTimeout = TimeSpan.FromSeconds(-1) };
        Assert.Throws<InvalidOperationException>(() => options.Validate());
    }

    [Test]
    public void Validate_SucceedsForValidShutdownTimeout()
    {
        var options = new AgentHostOptions { ShutdownTimeout = TimeSpan.FromSeconds(60) };
        Assert.DoesNotThrow(() => options.Validate());
    }
}
