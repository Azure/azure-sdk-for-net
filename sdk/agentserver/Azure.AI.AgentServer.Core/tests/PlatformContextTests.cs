// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class PlatformContextTests
{
    [Test]
    public void Constructor_SetsBothKeys()
    {
        var ctx = new PlatformContext("user-key-1", "chat-key-2");

        Assert.That(ctx.UserIdKey, Is.EqualTo("user-key-1"));
        Assert.That(ctx.CallId, Is.EqualTo("chat-key-2"));
    }

    [Test]
    public void Constructor_AcceptsNullKeys()
    {
        var ctx = new PlatformContext(null, null);

        Assert.That(ctx.UserIdKey, Is.Null);
        Assert.That(ctx.CallId, Is.Null);
    }

    [Test]
    public void Constructor_AcceptsMixedNullAndValue()
    {
        var ctx = new PlatformContext("user-only", null);

        Assert.That(ctx.UserIdKey, Is.EqualTo("user-only"));
        Assert.That(ctx.CallId, Is.Null);
    }

    [Test]
    public void Empty_HasNullKeys()
    {
        Assert.That(PlatformContext.Empty.UserIdKey, Is.Null);
        Assert.That(PlatformContext.Empty.CallId, Is.Null);
    }

    [Test]
    public void Empty_IsSingleton()
    {
        Assert.That(PlatformContext.Empty, Is.SameAs(PlatformContext.Empty));
    }

    [Test]
    public void Properties_AreVirtual_ForMocking()
    {
        // Verify the protected parameterless constructor exists and properties are overridable.
        var mock = new MockPlatformContext("mock-user", "mock-chat");

        Assert.That(mock.UserIdKey, Is.EqualTo("mock-user"));
        Assert.That(mock.CallId, Is.EqualTo("mock-chat"));
    }

    private sealed class MockPlatformContext : PlatformContext
    {
        private readonly string? _user;
        private readonly string? _chat;

        public MockPlatformContext(string? user, string? chat)
        {
            _user = user;
            _chat = chat;
        }

        public override string? UserIdKey => _user;
        public override string? CallId => _chat;
    }
}
