// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Pipeline;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace System.ClientModel.Tests.Options;

public class ConfigurePipelineTests
{
    [Test]
    public void CanSetClientEndpointFromConfigurationSettings()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSingleton<IConfiguration>(sp => configuration);
        services.AddLogging();

        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
    }

    [Test]
    public void CanSpecifyConfigurationSectionViaExtensions()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSingleton<IConfiguration>(sp => configuration);
        services.AddLogging();

        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

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
    public void CanInjectCustomPolicyViaExtensions()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString),
                new("SimpleClient:Logging:AllowedHeaderNames", "[\"x-allowed\"]")
            });

        services.AddSingleton<IConfiguration>(sp => configuration);
        services.AddLogging();

        // Add custom logging policy to service collection
        services.AddSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>();

        // Client will have custom logging policy injected at creation time
        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
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

    #region Helpers
    public class CustomHttpLoggingPolicy : HttpLoggingPolicy
    {
        public CustomHttpLoggingPolicy(ClientLoggingOptions options) : base(options)
        {
        }
    }
    #endregion
}
