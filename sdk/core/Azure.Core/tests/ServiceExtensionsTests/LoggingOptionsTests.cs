// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

#nullable enable

namespace Azure.Core.Tests;

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
                new("SimpleClient:Diagnostics:IsLoggingEnabled", "false")
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Pass configuration section to configure from settings per options pattern

        IConfigurationSection commonSection = configuration.GetSection("ClientCommon");
        IConfigurationSection clientSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(commonSection, clientSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.AreEqual(false, client.Options.Diagnostics.IsLoggingEnabled);

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
                new("SimpleClient:Diagnostics:LoggedHeaderNames", null),
                new("SimpleClient:Diagnostics:LoggedHeaderNames:0", "x-config-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection commonSection = configuration.GetSection("ClientCommon");
        IConfigurationSection clientSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(commonSection, clientSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        // SCM defaults
        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "Content-Length");

        // Client defaults (client-author additions)
        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "x-simple-client-allowed");

        // User additions
        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "x-config-allowed");
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

        // Add custom retry policy to service collection
        services.AddSingleton<RetryPolicy, CustomHttpRetryPolicy>();

        // Client will have custom retry policy injected at creation time
        services.AddSimpleClient();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();
        ILoggerFactory loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

        Assert.AreEqual(uriString, client.Endpoint.ToString());
        Assert.AreEqual(loggerFactory, client.Options.Diagnostics.LoggerFactory);
    }

    [Test]
    public void CanInjectCustomLoggingPolicyViaServiceCollection()
    {
        string uriString = "https://www.example.com/";

        ServiceCollection services = new ServiceCollection();
        ConfigurationManager configuration = new ConfigurationManager();
        services.AddSingleton<IConfiguration>(sp => configuration);

        configuration.AddInMemoryCollection(new List<KeyValuePair<string, string?>>()
        {
            new("ClientCommon:Diagnostics:LoggedHeaderNames", null),
            new("ClientCommon:Diagnostics:LoggedHeaderNames:0", "x-common-config-allowed"),
            new("SimpleClient:ServiceUri", uriString)
        });

        services.AddSingleton<RetryPolicy, CustomHttpRetryPolicy>();

        services.AddSimpleClient(
            configuration.GetSection("ClientCommon"),
            configuration.GetSection("SimpleClient"),
            options => { });

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        Assert.IsNotNull(client.Options.Retry);
        //Assert.AreEqual(typeof(CustomHttpLoggingPolicy), client.Options.HttpLoggingPolicy!.GetType());

        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "x-common-config-allowed");

        // TODO: validate that it doesn't have client-specific values configured
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
                new("SimpleClient:Diagnostics:EnableLogging", "false"),

                // The below is the equivalent of adding JSON [ "x-allowed" ]
                // array via Microsoft.Extensions.Configuration.Json config
                new("SimpleClient:Diagnostics:LoggedHeaderNames", null),
                new("SimpleClient:Diagnostics:LoggedHeaderNames:0", "x-config-allowed"),
            });

        services.AddSingleton<IConfiguration>(sp => configuration);

        // Add custom logging policy to service collection
        services.AddSingleton<RetryPolicy, CustomHttpRetryPolicy>(sp =>
        {
            RetryOptions options = new();
            options.Mode = RetryMode.Fixed;
            return new CustomHttpRetryPolicy(options);
        });

        // Pass configuration section to configure from settings per options pattern
        IConfigurationSection commonSection = configuration.GetSection("ClientCommon");
        IConfigurationSection clientSection = configuration.GetSection("SimpleClient");
        services.AddSimpleClient(commonSection, clientSection);

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        SimpleClient client = serviceProvider.GetRequiredService<SimpleClient>();

        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "Content-Length");
        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "x-simple-client-allowed");
        CollectionAssert.Contains(client.Options.Diagnostics.LoggedHeaderNames, "x-config-allowed");

        // Validate that custom logging policy has been configured from the custom options
        // provided in the custom policy factory above.
        //CustomHttpLoggingPolicy? customPolicy =
        //Assert.IsNotNull(customPolicy);

        //CollectionAssert.Contains(customPolicy!.Options.LoggedHeaderNames, "Content-Length");
        //CollectionAssert.Contains(customPolicy!.Options.LoggedHeaderNames, "x-custom-allowed");

        // Validate that settings from client and settings from IConfiguration
        // have not also been added.
        //CollectionAssert.DoesNotContain(customPolicy!.Options.LoggedHeaderNames, "x-simple-client-allowed");
        //CollectionAssert.DoesNotContain(customPolicy!.Options.LoggedHeaderNames, "x-config-allowed");
    }

    #region Helpers
    public class CustomHttpRetryPolicy : RetryPolicy
    {
        private readonly RetryOptions _options;

        public CustomHttpRetryPolicy(RetryOptions options) : base(options.MaxRetries)
        {
            _options = options;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }
    }
    #endregion
}
