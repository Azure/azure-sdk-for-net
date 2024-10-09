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

namespace ClientModel.ReferenceClients.MapsClient;

public static class MapsClientServiceCollectionExtensions
{
    public static IServiceCollection AddMapsClient(this IServiceCollection services)
    {
        services.AddLogging();

        // Add client options
        services.AddOptions<MapsClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory);

        // Proxy to logging options in case a custom logging policy is added
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<MapsClientOptions> options = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            return options.Value.Logging;
        });

        services.AddSingleton<MapsClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = clientConfiguration.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException("Expected 'ServiceUri' to be present in 'SimpleClient' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

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

            return new MapsClient(endpoint, credential, options);
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
        services.AddOptions<MapsClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(configurationSection);

        // Proxy to logging options in case a custom logging policy is added
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<MapsClientOptions> options = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            return options.Value.Logging;
        });

        services.AddSingleton<MapsClient>(sp =>
        {
            string? sectionName = (configurationSection as IConfigurationSection)?.Key;

            Uri endpoint = configurationSection.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

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

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }
}
