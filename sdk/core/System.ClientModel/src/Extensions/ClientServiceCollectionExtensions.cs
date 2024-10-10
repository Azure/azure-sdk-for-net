// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class ClientServiceCollectionExtensions
{
    public static IServiceCollection AddClientPipelineOptions(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection,
        Action<ClientPipelineOptions> configureOptions)
    {
        services.AddLogging();

        // Bind common options to common IConfiguration block
        services.AddOptions<ClientPipelineOptions>()
                .Configure<ILoggerFactory>((options, loggerFactory) =>
                {
                    options.Logging.LoggerFactory = loggerFactory;
                })
                .Bind(commonConfigurationSection);

        // Add common policy options to the service collection
        services.AddSingleton<ClientLoggingOptions>(sp =>
        {
            IOptions<ClientPipelineOptions> options = sp.GetRequiredService<IOptions<ClientPipelineOptions>>();
            return options.Value.Logging;
        });

        return services;
    }

    public static Uri GetClientEndpoint(IConfiguration clientConfigurationSection)
    {
        string? sectionName = (clientConfigurationSection as IConfigurationSection)?.Key;

        Uri endpoint = clientConfigurationSection.GetValue<Uri>("ServiceUri") ??
            throw new InvalidOperationException($"Expected 'ServiceUri' to be present in '{sectionName ?? "configuration"}' configuration settings.");

        return endpoint;
    }

    public static TOptions AddCustomPolicies<TOptions>(IServiceProvider serviceProvider, TOptions options)
        where TOptions : ClientPipelineOptions
    {
        // TODO: need to apply SCM settings to HttpClient
        // Check whether an HttpClient has been injected.
        HttpClient? httpClient = serviceProvider.GetService<HttpClient>();
        if (httpClient is not null)
        {
            options.Transport = new HttpClientPipelineTransport(httpClient);
        }

        // Check whether known policy types have been added to the service collection.
        HttpLoggingPolicy? httpLoggingPolicy = serviceProvider.GetService<HttpLoggingPolicy>();
        if (httpLoggingPolicy is not null)
        {
            options.HttpLoggingPolicy = httpLoggingPolicy;
        }

        return options;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
