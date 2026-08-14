// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponsesServerOptionsTests
{
    [Test]
    public void DefaultFetchHistoryCount_Is100()
    {
        var options = new ResponsesServerOptions();

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(100));
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
