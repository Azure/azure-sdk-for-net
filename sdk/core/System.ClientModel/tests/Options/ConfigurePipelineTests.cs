// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace System.ClientModel.Tests.Options;

public class ConfigurePipelineTests
{
    [Test]
    public void CanSetClientEndpointFromConfigurationSettings()
    {
        string uriString = "https://www.example.com";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
    }

    [Test]
    public void CanSetClientCredentialFromConfigurationSettings()
    {
    }

    [Test]
    public void CanRollCredentialFromConfigurationSettings()
    {
    }

    [Test]
    public void CanInjectCustomPolicyUsingDependencyInjectionExtensions()
    {
    }

    [Test]
    public void CanManuallySpecifyConfigurationPathViaExtensions()
    {
    }

    [Test]
    public void CanRegisterAndUseDerivedLoggingPolicyType()
    {
    }

    [Test]
    public void CanInjectCustomHttpClient()
    {
    }

    [Test]
    public void CanRegisterClientsAsKeyedServices()
    {
    }
}
