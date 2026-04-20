// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.Primitives;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
public class InvocationContextTests
{
    private static readonly Dictionary<string, string> s_emptyHeaders = new();
    private static readonly Dictionary<string, StringValues> s_emptyQueryParams = new();

    [Test]
    public void Constructor_SetsAllProperties()
    {
        var headers = new Dictionary<string, string> { ["x-client-foo"] = "bar" };
        var queryParams = new Dictionary<string, StringValues> { ["key"] = "value" };
        var isolation = new IsolationContext("user-1", "chat-2");

        var context = new InvocationContext("inv-1", "sess-2", headers, queryParams, isolation);

        Assert.That(context.InvocationId, Is.EqualTo("inv-1"));
        Assert.That(context.SessionId, Is.EqualTo("sess-2"));
        Assert.That(context.ClientHeaders, Is.SameAs(headers));
        Assert.That(context.QueryParameters, Is.SameAs(queryParams));
        Assert.That(context.Isolation, Is.SameAs(isolation));
    }

    [Test]
    public void Constructor_WithEmptyIsolation_SetsEmpty()
    {
        var context = new InvocationContext("inv-1", "sess-2", s_emptyHeaders, s_emptyQueryParams, IsolationContext.Empty);

        Assert.That(context.Isolation, Is.SameAs(IsolationContext.Empty));
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenIsolationIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "sess-2", s_emptyHeaders, s_emptyQueryParams, null!),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenInvocationIdIsNull()
    {
        Assert.That(
            () => new InvocationContext(null!, "sess", s_emptyHeaders, s_emptyQueryParams, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenInvocationIdIsEmpty()
    {
        Assert.That(
            () => new InvocationContext("", "sess", s_emptyHeaders, s_emptyQueryParams, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenSessionIdIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", null!, s_emptyHeaders, s_emptyQueryParams, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenSessionIdIsEmpty()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "", s_emptyHeaders, s_emptyQueryParams, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenClientHeadersIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "sess", null!, s_emptyQueryParams, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenQueryParametersIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "sess", s_emptyHeaders, null!, IsolationContext.Empty),
            Throws.InstanceOf<ArgumentNullException>());
    }
}
