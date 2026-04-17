// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class ServerVersionRegistryTests
{
    [Test]
    public void Register_AddsSegment()
    {
        var registry = new ServerVersionRegistry();
        registry.Register("test-protocol/1.0.0");
        Assert.That(registry.GetSegments(), Has.Count.EqualTo(1));
        Assert.That(registry.GetSegments()[0], Is.EqualTo("test-protocol/1.0.0"));
    }

    [Test]
    public void Register_IgnoresDuplicates()
    {
        var registry = new ServerVersionRegistry();
        registry.Register("test-protocol/1.0.0");
        registry.Register("test-protocol/1.0.0");
        Assert.That(registry.GetSegments(), Has.Count.EqualTo(1));
    }

    [Test]
    public void Register_AllowsDistinctSegments()
    {
        var registry = new ServerVersionRegistry();
        registry.Register("protocol-a/1.0");
        registry.Register("protocol-b/2.0");
        Assert.That(registry.GetSegments(), Has.Count.EqualTo(2));
        Assert.That(registry.GetSegments()[0], Is.EqualTo("protocol-a/1.0"));
        Assert.That(registry.GetSegments()[1], Is.EqualTo("protocol-b/2.0"));
    }

    [Test]
    public void Register_ThrowsOnNull()
    {
        var registry = new ServerVersionRegistry();
        Assert.Throws<ArgumentNullException>(() => registry.Register(null!));
    }

    [Test]
    public void Register_ThrowsOnEmpty()
    {
        var registry = new ServerVersionRegistry();
        Assert.Throws<ArgumentException>(() => registry.Register(""));
    }

    [Test]
    public void GetSegments_ReturnsEmptyByDefault()
    {
        var registry = new ServerVersionRegistry();
        Assert.That(registry.GetSegments(), Is.Empty);
    }

    [Test]
    public void GetSegments_PreservesRegistrationOrder()
    {
        var registry = new ServerVersionRegistry();
        registry.Register("c/1.0");
        registry.Register("a/1.0");
        registry.Register("b/1.0");
        var segments = registry.GetSegments();
        Assert.That(segments[0], Is.EqualTo("c/1.0"));
        Assert.That(segments[1], Is.EqualTo("a/1.0"));
        Assert.That(segments[2], Is.EqualTo("b/1.0"));
    }

    [Test]
    public void GetSegments_ReturnsCopy()
    {
        var registry = new ServerVersionRegistry();
        registry.Register("x/1.0");
        var first = registry.GetSegments();
        registry.Register("y/2.0");
        var second = registry.GetSegments();

        // First snapshot should not be affected by subsequent registrations
        Assert.That(first, Has.Count.EqualTo(1));
        Assert.That(second, Has.Count.EqualTo(2));
    }

    [Test]
    public void BuildIdentityString_FormatsCorrectly()
    {
        var assembly = typeof(ServerVersionRegistry).Assembly;
        var identity = ServerVersionRegistry.BuildIdentityString("test-sdk", assembly);
        Assert.That(identity, Does.StartWith("test-sdk/"));
        Assert.That(identity, Does.Contain("(dotnet/"));
        Assert.That(identity, Does.EndWith(")"));
    }

    [Test]
    public void BuildIdentityString_StripsMetadata()
    {
        // The assembly version may contain +commit-hash metadata
        // BuildIdentityString should strip everything after '+'
        var assembly = typeof(ServerVersionRegistry).Assembly;
        var identity = ServerVersionRegistry.BuildIdentityString("test-sdk", assembly);
        Assert.That(identity, Does.Not.Contain("+"));
    }

    [Test]
    public void BuildIdentityString_ThrowsOnNullSdkName()
    {
        var assembly = typeof(ServerVersionRegistry).Assembly;
        Assert.Throws<ArgumentNullException>(() => ServerVersionRegistry.BuildIdentityString(null!, assembly));
    }

    [Test]
    public void BuildIdentityString_ThrowsOnEmptySdkName()
    {
        var assembly = typeof(ServerVersionRegistry).Assembly;
        Assert.Throws<ArgumentException>(() => ServerVersionRegistry.BuildIdentityString("", assembly));
    }

    [Test]
    public void BuildIdentityString_ThrowsOnNullAssembly()
    {
        Assert.Throws<ArgumentNullException>(() => ServerVersionRegistry.BuildIdentityString("test-sdk", null!));
    }

    [Test]
    public void BuildIdentityString_IncludesRuntimeVersion()
    {
        var assembly = typeof(ServerVersionRegistry).Assembly;
        var identity = ServerVersionRegistry.BuildIdentityString("test-sdk", assembly);
        var expected = $"dotnet/{Environment.Version.Major}.{Environment.Version.Minor}";
        Assert.That(identity, Does.Contain(expected));
    }
}
