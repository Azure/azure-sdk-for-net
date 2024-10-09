// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClientModel.ReferenceClients.SimpleClient;

public static class SimpleClientServiceCollectionExtensions
{
    // TODO: How much of these can SCM provide for SCM-based clients to use
    // from a central source?  Microsoft.Extensions.ClientModel, e.g.?

    // No parameters uses client defaults
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#parameterless
    public static IServiceCollection AddSimpleClient(this IServiceCollection services)
    {
        services.AddLogging();

        // Add client options
        services.AddOptions<SimpleClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory);

        // Proxy to logging options in case a custom logging policy is added
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<SimpleClientOptions> options = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            return options.Value.Logging;
        });

        //// Proxy to logging options in case a custom logging policy is added
        //services.AddKeyedSingleton<ClientLoggingOptions>(typeof(SimpleClientOptions),
        //    (sp, type) =>
        //    {
        //        IOptions<SimpleClientOptions> options = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
        //        return (options.Value.Logging as SimpleClientLoggingOptions)!;
        //    });

        services.AddSingleton<SimpleClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = clientConfiguration.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException("Expected 'ServiceUri' to be present in 'SimpleClient' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            // Check whether an HttpClient has been injected
            HttpClient? httpClient = sp.GetService<HttpClient>();
            if (httpClient is not null)
            {
                options.Transport = new HttpClientPipelineTransport(httpClient);
            }

            // Check whether known policy types have been added to the service
            // collection.
            HttpLoggingPolicy? httpLoggingPolicy = sp.GetService<HttpLoggingPolicy>();
            if (httpLoggingPolicy is not null)
            {
                options.HttpLoggingPolicy = httpLoggingPolicy;
            }

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    // Taking an IConfiguration uses that to configure the options per the pattern
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#iconfiguration-parameter
    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration configurationSection)
    {
        services.AddLogging();

        // Bind configuration to options
        services.AddOptions<SimpleClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(configurationSection);

        // Proxy to logging options in case a custom logging policy is added
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<SimpleClientOptions> options = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            return options.Value.Logging;
        });

        services.AddSingleton<SimpleClient>(sp =>
        {
            string? sectionName = (configurationSection as IConfigurationSection)?.Key;

            Uri endpoint = configurationSection.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            // Check whether an HttpClient has been injected
            HttpClient? httpClient = sp.GetService<HttpClient>();
            if (httpClient is not null)
            {
                options.Transport = new HttpClientPipelineTransport(httpClient);
            }

            // Check whether known policy types have been added to the service
            // collection.
            HttpLoggingPolicy? httpLoggingPolicy = sp.GetService<HttpLoggingPolicy>();
            if (httpLoggingPolicy is not null)
            {
                options.HttpLoggingPolicy = httpLoggingPolicy;
            }

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    // TODO: is this the right pattern for taking both common and client-specific
    // configuration sections?  Or should there be a higher level block that holds both?
    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection)
    {
        services.AddLogging();

        // Bind configuration to options
        services.AddOptions<SimpleClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(commonConfigurationSection)

            // TODO: validate that binding to client config second allows client
            // configuration to override comon settings.
            .Bind(clientConfigurationSection);

        // Proxy to logging options in case a custom logging policy is added
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<SimpleClientOptions> options = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            return options.Value.Logging;
        });

        services.AddSingleton<SimpleClient>(sp =>
        {
            string? sectionName = (clientConfigurationSection as IConfigurationSection)?.Key;

            Uri endpoint = clientConfigurationSection.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            // Check whether an HttpClient has been injected
            HttpClient? httpClient = sp.GetService<HttpClient>();
            if (httpClient is not null)
            {
                options.Transport = new HttpClientPipelineTransport(httpClient);
            }

            // Check whether known policy types have been added to the service
            // collection.
            HttpLoggingPolicy? httpLoggingPolicy = sp.GetService<HttpLoggingPolicy>();
            if (httpLoggingPolicy is not null)
            {
                options.HttpLoggingPolicy = httpLoggingPolicy;
            }

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }
}
