// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class LoggingOptionsTests
{
    [Test]
    public void CanDisableLoggingFromConfigurationSettings()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString),
                new("SimpleClient:Logging:EnableLogging", "false")
            });

        services.AddSingleton<IConfiguration>(sp => configuration);
        services.AddLogging();

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(false, client.Options.Logging.EnableLogging);

        // TODO: we should also add a pipeline test that there is no logging
        // policy in the pipeline.  This can be separate in PipelineOptions tests.
    }

    [Test]
    public void CanAddAllowedHeadersFromConfigurationSettings()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString),
                new("SimpleClient:Logging:EnableLogging", "false"),

                // The below is the equivalent of adding JSON [ "x-allowed" ]
                // array via Microsoft.Extensions.Configuration.Json config
                new("SimpleClient:Logging:AllowedHeaderNames", null),
                new("SimpleClient:Logging:AllowedHeaderNames:0", "x-user-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);
        services.AddLogging();

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        // SCM defaults
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "Content-Length");

        // Client defaults (client-author additions)
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-client-allowed");

        // User additions
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-user-allowed");
    }

    [Test]
    public void CanConfigureCustomLoggingPolicyFromConfigurationSettings()
    {
    }
}
