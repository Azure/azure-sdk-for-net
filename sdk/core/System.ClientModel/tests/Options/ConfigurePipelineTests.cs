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
using Microsoft.Extensions.Options;
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

        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Observability.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");
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

        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");
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

        // Add single custom policy to the service collection
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
    public void CanInjectCustomPoliciesConfiguredDifferentlyPerClient()
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

        // Add a custom policy to the service collection configured for each client
        services.AddKeyedSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>(typeof(SimpleClientOptions),
            (sp, sco) =>
            {
                SimpleClientOptions options = sp.GetRequiredService<IOptions<SimpleClientOptions>>().Value;
                return new CustomHttpLoggingPolicy(options.Observability);
            });

        services.AddKeyedSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>(typeof(MapsClientOptions),
            (sp, mco) =>
            {
                MapsClientOptions options = sp.GetRequiredService<IOptions<MapsClientOptions>>().Value;
                return new CustomHttpLoggingPolicy(options.Observability);
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

        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(simpleClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Observability.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.DoesNotContain(simpleClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");

        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-maps-client-allowed");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(mapsClient.Options.Observability.AllowedHeaderNames, "x-maps-config-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.DoesNotContain(mapsClient.Options.Observability.AllowedHeaderNames, "x-simple-config-allowed");

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
    public void CanRegisterMultipleInstancesOfTheSameClientType()
    {
        // see: https://learn.microsoft.com/en-us/dotnet/azure/sdk/dependency-injection?tabs=web-app-builder#configure-multiple-service-clients-with-different-names

        string publicUriString = "https://www.simple-public.com/";
        string privateUriString = "https://www.simple-private.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            // Common config block
            new("ClientCommon:Logging:AllowedHeaderNames", null),
            new("ClientCommon:Logging:AllowedHeaderNames:0", "x-common-config-allowed"),

            // PublicClient config block
            new("PublicClient:ServiceUri", publicUriString),
            new("PublicClient:Logging:AllowedHeaderNames", null),
            new("PublicClient:Logging:AllowedHeaderNames:0", "x-public-config-allowed"),

            // PrivateClient config block
            new("PrivateClient:ServiceUri", privateUriString),
            new("PrivateClient:Logging:AllowedHeaderNames", null),
            new("PrivateClient:Logging:AllowedHeaderNames:0", "x-private-config-allowed"),
        });

        // Add the two client instances
        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("PublicClient"),
            options => { },
            "PublicClient");

        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("PrivateClient"),
            options => { },
            "PrivateClient");

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient publicClient = serviceProvider.GetRequiredKeyedService<SimpleClient>("PublicClient");
        SimpleClient privateClient = serviceProvider.GetRequiredKeyedService<SimpleClient>("PrivateClient");

        // Validate that both clients have headers from appropriate common config blocks

        Assert.AreEqual(publicUriString, publicClient.Endpoint.ToString());
        CollectionAssert.Contains(publicClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(publicClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(publicClient.Options.Observability.AllowedHeaderNames, "x-public-config-allowed");
        CollectionAssert.DoesNotContain(publicClient.Options.Observability.AllowedHeaderNames, "x-private-config-allowed");

        Assert.AreEqual(privateUriString, privateClient.Endpoint.ToString());
        CollectionAssert.Contains(privateClient.Options.Observability.AllowedHeaderNames, "x-common-config-allowed");
        CollectionAssert.Contains(privateClient.Options.Observability.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(privateClient.Options.Observability.AllowedHeaderNames, "x-private-config-allowed");
        CollectionAssert.DoesNotContain(privateClient.Options.Observability.AllowedHeaderNames, "x-public-config-allowed");
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
    public void CanApplyObservabilityOptionsToInjectedHttpClient()
    {
        // The HttpClient to inject
        HttpClient httpClient = new();

        SimpleClientOptions clientOptions = new();
        clientOptions.Observability.AllowedHeaderNames.Add("x-user-allowed");
        clientOptions.Transport = new HttpClientPipelineTransport(httpClient);

        SimpleClient client = new(new Uri("https://example.com"),
            new ApiKeyCredential("fake key"),
            clientOptions);
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

internal static class HttpClientExtensions
{
    public static void EnableLoggingHeaderName(this HttpClient httpClient, string headerName)
    {
        // TODO: What is this API?
    }

    public static void EnableLoggingQueryParameter(this HttpClient httpClient, string headerName)
    {
        // TODO: What is this API?
    }
}
#endregion
