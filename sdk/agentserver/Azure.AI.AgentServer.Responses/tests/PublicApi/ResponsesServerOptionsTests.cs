namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class ResponsesServerOptionsTests
{
    [Test]
    public void DefaultSseKeepAliveInterval_IsDisabled()
    {
        var options = new ResponsesServerOptions();

        Assert.AreEqual(Timeout.InfiniteTimeSpan, options.SseKeepAliveInterval);
    }

    [Test]
    public void SseKeepAliveInterval_CanBeSetToPositiveValue()
    {
        var options = new ResponsesServerOptions
        {
            SseKeepAliveInterval = TimeSpan.FromSeconds(15),
        };

        Assert.AreEqual(TimeSpan.FromSeconds(15), options.SseKeepAliveInterval);
    }
}

public class InMemoryProviderOptionsTests
{
    [Test]
    public void DefaultEventStreamTtl_Is10Minutes()
    {
        var options = new InMemoryProviderOptions();

        Assert.AreEqual(TimeSpan.FromMinutes(10), options.EventStreamTtl);
    }

    [Test]
    public void EventStreamTtl_CanBeSet()
    {
        var options = new InMemoryProviderOptions
        {
            EventStreamTtl = TimeSpan.FromMinutes(5),
        };

        Assert.AreEqual(TimeSpan.FromMinutes(5), options.EventStreamTtl);
    }
}
