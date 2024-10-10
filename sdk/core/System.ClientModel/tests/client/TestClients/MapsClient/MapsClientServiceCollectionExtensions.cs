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

        services.AddSingleton<MapsClient>(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("MapsClient");

            Uri endpoint = clientConfiguration.GetValue<Uri>("ServiceUri") ??
                throw new InvalidOperationException("Expected 'ServiceUri' to be present in 'MapsClient' configuration settings.");

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

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddMapsClient(this IServiceCollection services,
        IConfiguration configurationSection)
    {
        services.AddLogging();

        // Bind configuration to options
        services.AddOptions<MapsClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(configurationSection);

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

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddMapsClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection)
    {
        services.AddLogging();

        // Bind configuration to options
        services.AddOptions<MapsClientOptions>()
            .Configure<ILoggerFactory>((options, loggerFactory)
                => options.Logging.LoggerFactory = loggerFactory)
            .Bind(commonConfigurationSection)
            .Bind(clientConfigurationSection);

        services.AddSingleton<MapsClient>(sp =>
        {
            string? sectionName = (clientConfigurationSection as IConfigurationSection)?.Key;

            Uri endpoint = clientConfigurationSection.GetValue<Uri>("ServiceUri") ??
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

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }
}
