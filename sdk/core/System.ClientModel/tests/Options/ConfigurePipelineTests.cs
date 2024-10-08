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
        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", "https://www.example.com")
            });
        services.AddSimpleClient();
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
