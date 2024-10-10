// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using ClientModel.ReferenceClients.SimpleClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

                // The below is the equivalent of adding JSON [ "x-allowed" ]
                // array via Microsoft.Extensions.Configuration.Json config
                new("SimpleClient:Logging:AllowedHeaderNames", null),
                new("SimpleClient:Logging:AllowedHeaderNames:0", "x-config-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        // SCM defaults
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "Content-Length");

        // Client defaults (client-author additions)
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-simple-client-allowed");

        // User additions
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-config-allowed");
    }

    [Test]
    public void CanInjectLoggerFactoryViaExtensions()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Add custom logging policy to service collection
        services.AddSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>();

        // Client will have custom logging policy injected at creation time
        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();
        ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
        Assert.AreEqual(loggerFactory, client.Options.Logging.LoggerFactory);
    }

    [Test]
    public void CanInjectCustomLoggingPolicyViaServiceRegistration()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        configuration.AddInMemoryCollection(
            new List<KeyValuePair<string, string?>>() {
                new("SimpleClient:ServiceUri", uriString)
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Client will have custom logging policy injected at creation time
        // Note this is the parameterless overload
        services.AddSimpleClient(options =>
        {
            options.HttpLoggingPolicy = new CustomHttpLoggingPolicy(options.Logging);
        });

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.IsNotNull(client.Options.HttpLoggingPolicy);
        Assert.AreEqual(typeof(CustomHttpLoggingPolicy), client.Options.HttpLoggingPolicy!.GetType());
    }

    [Test]
    public void CanConfigureCustomLoggingPolicyFromConfigurationSettings()
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
                new("SimpleClient:Logging:AllowedHeaderNames:0", "x-config-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Add custom logging policy to service collection
        services.AddSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>();

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-config-allowed");

        // Validate that custom logging policy has been bound to the same options
        CustomHttpLoggingPolicy? customPolicy = client.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;
        Assert.IsNotNull(customPolicy);

        CollectionAssert.Contains(customPolicy!.Options.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(customPolicy!.Options.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(customPolicy!.Options.AllowedHeaderNames, "x-config-allowed");
    }

    [Test]
    public void CanInjectCustomLoggingPolicyWithNonConfiguredOptions()
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
                new("SimpleClient:Logging:AllowedHeaderNames:0", "x-config-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Add custom logging policy to service collection
        services.AddSingleton<HttpLoggingPolicy, CustomHttpLoggingPolicy>(sp =>
        {
            ClientLoggingOptions options = new();
            options.AllowedHeaderNames.Add("x-custom-allowed");
            return new CustomHttpLoggingPolicy(options);
        });

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection configurationSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(configurationSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(client.Options.Logging.AllowedHeaderNames, "x-config-allowed");

        // Validate that custom logging policy has been configured from the custom options
        // provided in the custom policy factory above.
        CustomHttpLoggingPolicy? customPolicy = client.Options.HttpLoggingPolicy as CustomHttpLoggingPolicy;
        Assert.IsNotNull(customPolicy);

        CollectionAssert.Contains(customPolicy!.Options.AllowedHeaderNames, "Content-Length");
        CollectionAssert.Contains(customPolicy!.Options.AllowedHeaderNames, "x-custom-allowed");

        // Validate that settings from client and settings from IConfiguration
        // have not also been added.
        CollectionAssert.DoesNotContain(customPolicy!.Options.AllowedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.DoesNotContain(customPolicy!.Options.AllowedHeaderNames, "x-config-allowed");
    }

    #region Helpers
    public class CustomHttpLoggingPolicy : HttpLoggingPolicy
    {
        private readonly ClientLoggingOptions _options;

        public CustomHttpLoggingPolicy(ClientLoggingOptions options) : base(options)
        {
            _options = options;
        }

        // public for tests
        public ClientLoggingOptions Options => _options;
    }
    #endregion
}
