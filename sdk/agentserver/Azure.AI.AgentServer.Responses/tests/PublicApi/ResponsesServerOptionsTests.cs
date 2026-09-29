// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponsesServerOptionsTests
{
    [Test]
    public void DefaultFetchHistoryCount_IsUnlimited()
    {
        var options = new ResponsesServerOptions();

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(-1));
    }

    [TestCase(-1)]
    [TestCase(1)]
    [TestCase(1000)]
    public void DefaultFetchHistoryCount_AcceptsUnlimitedOrPositiveValues(int value)
    {
        var options = new ResponsesServerOptions { DefaultFetchHistoryCount = value };

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(value));
    }

    [TestCase(0)]
    [TestCase(-2)]
    [TestCase(-100)]
    public void DefaultFetchHistoryCount_RejectsInvalidValues(int value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new ResponsesServerOptions { DefaultFetchHistoryCount = value });
    }

    [Test]
    public void DefaultModel_IsNull()
    {
        var options = new ResponsesServerOptions();

        Assert.That(options.DefaultModel, Is.Null);
    }
}

public class InMemoryProviderOptionsTests
{
    [Test]
    public void DefaultEventStreamTtl_Is10Minutes()
    {
        var options = new InMemoryProviderOptions();

        Assert.That(options.EventStreamTtl, Is.EqualTo(TimeSpan.FromMinutes(10)));
    }

    [Test]
    public void EventStreamTtl_CanBeSet()
    {
        var options = new InMemoryProviderOptions
        {
            EventStreamTtl = TimeSpan.FromMinutes(5),
        };

        Assert.That(options.EventStreamTtl, Is.EqualTo(TimeSpan.FromMinutes(5)));
    }
}
