// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using ClientModel.ReferenceClients.MapsClient;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static System.ClientModel.Tests.Options.LoggingOptionsTests;

namespace System.ClientModel.Tests.Options;

public class ConfigurePipelineTests
{
    [Test]
    public void CanSetClientEndpointFromConfigurationSettings()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

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
    public void CanSpecifyConfigurationSectionViaExtensions()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        IConfigurationSection commonSection = configuration.GetSection("ClientCommon");
        IConfigurationSection clientSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(commonSection, clientSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
    }

    [Test]
    public void CanAddMultipleClientsWithDifferentConfigurationBlocks()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            // SimpleClient config block
            new("SimpleClient:ServiceUri", "https://www.simple-service.com/"),
            new("SimpleClient:Logging:AllowedHeaderNames", null),
            new("SimpleClient:Logging:AllowedHeaderNames:0", "x-simple-config-allowed"),

            // MapsClient config block
            new("MapsClient:ServiceUri", "https://www.maps-service.com/"),
            new("MapsClient:Logging:AllowedHeaderNames", null),
            new("MapsClient:Logging:AllowedHeaderNames:0", "x-maps-config-allowed"),
        });

        // Add the two clients
        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("SimpleClient"));
        services.AddMapsClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("MapsClient"));

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient simpleClient = serviceProvider.GetRequiredService<SimpleClient>();
        MapsClient mapsClient = serviceProvider.GetRequiredService<MapsClient>();

        // Validate that each client has the headers from their own client customizations
        // and their own client config blocks and not the headers from other client's
        // customizations or config blocks.

        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Logging.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Logging.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");
    }

    [Test]
    public void CanConfigureMultipleClientsFromCommonConfigurationBlock()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            // Common config block
            new("ClientCommon:Logging:AllowedHeaderNames", null),
            new("ClientCommon:Logging:AllowedHeaderNames:0", "x-common-config-allowed"),

            // SimpleClient config block
            new("SimpleClient:ServiceUri", "https://www.simple-service.com/"),
            new("SimpleClient:Logging:AllowedHeaderNames", null),
            new("SimpleClient:Logging:AllowedHeaderNames:0", "x-simple-config-allowed"),

            // MapsClient config block
            new("MapsClient:ServiceUri", "https://www.maps-service.com/"),
            new("MapsClient:Logging:AllowedHeaderNames", null),
            new("MapsClient:Logging:AllowedHeaderNames:0", "x-maps-config-allowed"),
        });

        // Add the two clients
        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("SimpleClient"));

        services.AddMapsClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("MapsClient"));

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient simpleClient = serviceProvider.GetRequiredService<SimpleClient>();
        MapsClient mapsClient = serviceProvider.GetRequiredService<MapsClient>();

        // Validate that both clients have headers from the common config block

        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");
    }

    [Test]
    public void CanInjectSinglePolicyUsedByAllClients()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            // Common config block
            new("ClientCommon:Logging:AllowedHeaderNames", null),
            new("ClientCommon:Logging:AllowedHeaderNames:0", "x-common-config-allowed"),

            // SimpleClient config block
            new("SimpleClient:ServiceUri", "https://www.simple-service.com/"),
            new("SimpleClient:Logging:AllowedHeaderNames", null),
            new("SimpleClient:Logging:AllowedHeaderNames:0", "x-simple-config-allowed"),

            // MapsClient config block
            new("MapsClient:ServiceUri", "https://www.maps-service.com/"),
            new("MapsClient:Logging:AllowedHeaderNames", null),
            new("MapsClient:Logging:AllowedHeaderNames:0", "x-maps-config-allowed"),
        });

        // Add custom policy to the service collection
        services.AddSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>();

        // Add the two clients
        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("SimpleClient"));

        services.AddMapsClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("MapsClient"));

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient simpleClient = serviceProvider.GetRequiredService<SimpleClient>();
        MapsClient mapsClient = serviceProvider.GetRequiredService<MapsClient>();

        CustomHttpLoggingPolicy? simpleClientPolicy = simpleClient.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;
        CustomHttpLoggingPolicy? mapsClientPolicy = simpleClient.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;

        Assert.IsNotNull(simpleClientPolicy);
        Assert.IsNotNull(mapsClientPolicy);

        CollectionAssert.Contains(simpleClientPolicy!.Options.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.DoesNotContain(simpleClientPolicy!.Options.AllowedHeaderNames, "x-simple-config-allowed");

        CollectionAssert.Contains(mapsClientPolicy!.Options.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.DoesNotContain(mapsClientPolicy!.Options.AllowedHeaderNames, "x-maps-config-allowed");

        // TODO: should we throw if individual client blocks try to configure the logging policy?
        // What is desired behavior here?
    }

    [Test]
    public void CanConfigureCustomPolicyDifferentlyPerClient()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            // Common config block
            new("ClientCommon:Logging:AllowedHeaderNames", null),
            new("ClientCommon:Logging:AllowedHeaderNames:0", "x-common-config-allowed"),

            // SimpleClient config block
            new("SimpleClient:ServiceUri", "https://www.simple-service.com/"),
            new("SimpleClient:Logging:AllowedHeaderNames", null),
            new("SimpleClient:Logging:AllowedHeaderNames:0", "x-simple-config-allowed"),

            // MapsClient config block
            new("MapsClient:ServiceUri", "https://www.maps-service.com/"),
            new("MapsClient:Logging:AllowedHeaderNames", null),
            new("MapsClient:Logging:AllowedHeaderNames:0", "x-maps-config-allowed"),
        });

        // Add the two clients
        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("SimpleClient"));

        services.AddMapsClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("MapsClient"));

        // Add custom logging policy to service collection
        // Add it as transient so different policy configurations can be added
        // to different clients...
        services.AddTransient<HttpLoggingPolicy, CustomHttpLoggingPolicy>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient simpleClient = serviceProvider.GetRequiredService<SimpleClient>();
        MapsClient mapsClient = serviceProvider.GetRequiredService<MapsClient>();

        // Validate that both clients have headers from the common config block

        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(simpleClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(mapsClient.Options.Logging.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Logging.AllowedHeaderNames, "x-simple-config-allowed");

        // Validate that the custom policy for each client is configured according to that client's options

        CustomHttpLoggingPolicy? simpleClientPolicy = simpleClient.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;
        Assert.IsNotNull(simpleClientPolicy);

        CollectionAssert.Contains(simpleClientPolicy!.Options.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(simpleClientPolicy!.Options.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(simpleClientPolicy!.Options.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClientPolicy!.Options.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.DoesNotContain(simpleClientPolicy!.Options.AllowedHeaderNames, "x-maps-config-allowed");

        CustomHttpLoggingPolicy? mapsClientPolicy = mapsClient.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;
        Assert.IsNotNull(mapsClientPolicy);

        CollectionAssert.Contains(mapsClientPolicy!.Options.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(mapsClientPolicy!.Options.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.Contains(mapsClientPolicy!.Options.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClientPolicy!.Options.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.DoesNotContain(mapsClientPolicy!.Options.AllowedHeaderNames, "x-simple-config-allowed");
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
