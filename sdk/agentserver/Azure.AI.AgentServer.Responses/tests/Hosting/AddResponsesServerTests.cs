using Azure.AI.AgentServer.Responses.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

public class AddResponsesServerTests
{
    [Test]
    public void AddResponsesServer_RegistersResponseExecutionTracker()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResponsesServer();

        var provider = services.BuildServiceProvider();
        var tracker = provider.GetService<ResponseExecutionTracker>();

        Assert.IsNotNull(tracker);
    }

    [Test]
    public void AddResponsesServer_RegistersOptions_WithDefaults()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResponsesServer();

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.AreEqual(Timeout.InfiniteTimeSpan, options.SseKeepAliveInterval);
    }

    [Test]
    public void AddResponsesServer_WithConfigureCallback_AppliesOptions()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResponsesServer(options =>
        {
            options.SseKeepAliveInterval = TimeSpan.FromSeconds(30);
        });

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.AreEqual(TimeSpan.FromSeconds(30), options.SseKeepAliveInterval);
    }

    [Test]
    public void AddResponsesServer_ReturnsServiceCollection_ForChaining()
    {
        var services = new ServiceCollection();
        services.AddLogging();

        var result = services.AddResponsesServer();

        Assert.AreSame(services, result);
    }
}
