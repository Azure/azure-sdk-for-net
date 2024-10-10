// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        IConfiguration clientConfigurationSection)
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
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
