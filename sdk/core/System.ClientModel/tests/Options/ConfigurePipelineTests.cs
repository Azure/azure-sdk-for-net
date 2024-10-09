// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
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
        throw new NotImplementedException();
    }

    [Test]
    public void CanRollCredentialFromConfigurationSettings()
    {
        throw new NotImplementedException();
    }

    [Test]
    public void CanInjectCustomHttpClient()
    {
        // Maybe this uses HttpClientFactory instead in the future

        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Add custom logging policy to service collection

        // Using specific HttpClient instance for test to validate object
        // equality. Note that this is an anti-pattern from a DI perspective.
        HttpClient httpClientInstance = new();
        services.AddSingleton<HttpClient, HttpClient>(sp => httpClientInstance);

        // Client will have custom logging policy injected at creation time
        // Note this is the parameterless overload
        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        HttpClientPipelineTransport? transport = client.Options.Transport as HttpClientPipelineTransport;

        Assert.IsNotNull(transport);

        HttpClient pipelineHttpClient = transport!.GetPrivateField<HttpClient>("_httpClient");

        Assert.AreEqual(httpClientInstance, pipelineHttpClient);
    }

    [Test]
    public void CanRegisterClientsAsKeyedServices()
    {
        throw new NotImplementedException();
    }
}

#region Helpers
internal static class ReflectionExtensions
{
    public static T GetPrivateField<T>(this HttpClientPipelineTransport obj, string name)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        Type type = obj.GetType();
        FieldInfo? field = type.GetField(name, flags);
        return (T)field!.GetValue(obj)!;
    }
}
#endregion
