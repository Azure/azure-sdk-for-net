// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class IsolationContextTests
{
    [Test]
    public void Constructor_SetsBothKeys()
    {
        var ctx = new IsolationContext("user-key-1", "chat-key-2");

        Assert.That(ctx.UserIsolationKey, Is.EqualTo("user-key-1"));
        Assert.That(ctx.ChatIsolationKey, Is.EqualTo("chat-key-2"));
    }

    [Test]
    public void Constructor_AcceptsNullKeys()
    {
        var ctx = new IsolationContext(null, null);

        Assert.That(ctx.UserIsolationKey, Is.Null);
        Assert.That(ctx.ChatIsolationKey, Is.Null);
    }

    [Test]
    public void Constructor_AcceptsMixedNullAndValue()
    {
        var ctx = new IsolationContext("user-only", null);

        Assert.That(ctx.UserIsolationKey, Is.EqualTo("user-only"));
        Assert.That(ctx.ChatIsolationKey, Is.Null);
    }

    [Test]
    public void Empty_HasNullKeys()
    {
        Assert.That(IsolationContext.Empty.UserIsolationKey, Is.Null);
        Assert.That(IsolationContext.Empty.ChatIsolationKey, Is.Null);
    }

    [Test]
    public void Empty_IsSingleton()
    {
        Assert.That(IsolationContext.Empty, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void Properties_AreVirtual_ForMocking()
    {
        // Verify the protected parameterless constructor exists and properties are overridable.
        var mock = new MockIsolationContext("mock-user", "mock-chat");

        Assert.That(mock.UserIsolationKey, Is.EqualTo("mock-user"));
        Assert.That(mock.ChatIsolationKey, Is.EqualTo("mock-chat"));
    }

    private sealed class MockIsolationContext : IsolationContext
    {
        private readonly string? _user;
        private readonly string? _chat;

        public MockIsolationContext(string? user, string? chat)
        {
            _user = user;
            _chat = chat;
        }

        public override string? UserIsolationKey => _user;
        public override string? ChatIsolationKey => _chat;
    }
}
