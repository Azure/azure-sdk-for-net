// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        var context = new InvocationContext("inv-1", "sess-2", headers, queryParams);

        Assert.That(context.InvocationId, Is.EqualTo("inv-1"));
        Assert.That(context.SessionId, Is.EqualTo("sess-2"));
        Assert.That(context.ClientHeaders, Is.SameAs(headers));
        Assert.That(context.QueryParameters, Is.SameAs(queryParams));
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenInvocationIdIsNull()
    {
        Assert.That(
            () => new InvocationContext(null!, "sess", s_emptyHeaders, s_emptyQueryParams),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenInvocationIdIsEmpty()
    {
        Assert.That(
            () => new InvocationContext("", "sess", s_emptyHeaders, s_emptyQueryParams),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenSessionIdIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", null!, s_emptyHeaders, s_emptyQueryParams),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentException_WhenSessionIdIsEmpty()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "", s_emptyHeaders, s_emptyQueryParams),
            Throws.InstanceOf<ArgumentException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenClientHeadersIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "sess", null!, s_emptyQueryParams),
            Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenQueryParametersIsNull()
    {
        Assert.That(
            () => new InvocationContext("inv-1", "sess", s_emptyHeaders, null!),
            Throws.InstanceOf<ArgumentNullException>());
    }
}
