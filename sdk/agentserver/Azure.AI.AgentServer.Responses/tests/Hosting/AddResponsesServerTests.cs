// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        Assert.That(tracker, Is.Not.Null);
    }

    [Test]
    public void AddResponsesServer_RegistersOptions_WithDefaults()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResponsesServer();

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(100));
    }

    [Test]
    public void AddResponsesServer_WithConfigureCallback_AppliesOptions()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddResponsesServer(options =>
        {
            options.DefaultFetchHistoryCount = 50;
        });

        var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(50));
    }

    [Test]
    public void AddResponsesServer_ReturnsServiceCollection_ForChaining()
    {
        var services = new ServiceCollection();
        services.AddLogging();

        var result = services.AddResponsesServer();

        Assert.That(result, Is.SameAs(services));
    }
}
