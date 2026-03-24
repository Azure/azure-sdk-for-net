// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponsesServerOptionsTests
{
    [Test]
    public void DefaultSseKeepAliveInterval_IsDisabled()
    {
        var options = new ResponsesServerOptions();

        Assert.That(options.SseKeepAliveInterval, Is.EqualTo(Timeout.InfiniteTimeSpan));
    }

    [Test]
    public void SseKeepAliveInterval_CanBeSetToPositiveValue()
    {
        var options = new ResponsesServerOptions
        {
            SseKeepAliveInterval = TimeSpan.FromSeconds(15),
        };

        Assert.That(options.SseKeepAliveInterval, Is.EqualTo(TimeSpan.FromSeconds(15)));
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
