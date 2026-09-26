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

        Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(-1));
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

    [TestCase("-1", -1)]
    [TestCase("10", 10)]
    [NonParallelizable]
    public void AddResponsesServer_AppliesValidHistoryLimitFromEnvironment(string value, int expected)
    {
        var previous = Environment.GetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT");
        try
        {
            Environment.SetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT", value);
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddResponsesServer();

            var provider = services.BuildServiceProvider();
            var options = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value;

            Assert.That(options.DefaultFetchHistoryCount, Is.EqualTo(expected));
        }
        finally
        {
            Environment.SetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT", previous);
        }
    }

    [TestCase("0")]
    [TestCase("-2")]
    [TestCase("invalid")]
    [NonParallelizable]
    public void AddResponsesServer_RejectsInvalidHistoryLimitFromEnvironment(string value)
    {
        var previous = Environment.GetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT");
        try
        {
            Environment.SetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT", value);
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddResponsesServer();
            var provider = services.BuildServiceProvider();

            Assert.That(
                () => _ = provider.GetRequiredService<IOptions<ResponsesServerOptions>>().Value,
                Throws.InstanceOf<Exception>().With.Message.Contains("unlimited"));
        }
        finally
        {
            Environment.SetEnvironmentVariable("DEFAULT_FETCH_HISTORY_ITEM_COUNT", previous);
        }
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
