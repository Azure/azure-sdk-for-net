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

        // Client will have custom logging policy injected at creation time
        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
    }

    [Test]
    public void CanAddAllowedHeadersFromConfigurationSettings()
    {
    }

    [Test]
    public void CanAddToClientAuthorAllowedHeadersListFromConfigurationSettings()
    {
    }

    [Test]
    public void CanConfigureCustomLoggingPolicyFromConfigurationSettings()
    {
    }
}
