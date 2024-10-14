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
    public static IServiceCollection AddCommonOptions(this IServiceCollection services)
    {
        services.AddRequiredServices();
        services.AddClientPipelineOptions();

        return services;
    }

    public static IServiceCollection AddCommonOptions(this IServiceCollection services,
        IConfiguration commonConfigurationSection)
    {
        services.AddRequiredServices();

        services.AddClientPipelineOptions()
                .Bind(commonConfigurationSection);

        return services;
    }

    private static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddLogging();

        return services;
    }

    private static OptionsBuilder<ClientPipelineOptions> AddClientPipelineOptions(this IServiceCollection services)
    {
        // Add common options with required dependencies
        OptionsBuilder<ClientPipelineOptions> builder =
            services.AddOptions<ClientPipelineOptions>()
                    .Configure<ILoggerFactory>((options, loggerFactory) =>
                    {
                        options.Observability.LoggerFactory = loggerFactory;
                    });

        // Add common policy options to the service collection
        services.AddSingleton<ClientObservabilityOptions>(sp =>
        {
            IOptions<ClientPipelineOptions> options = sp.GetRequiredService<IOptions<ClientPipelineOptions>>();
            return options.Value.Observability;
        });

        return builder;
    }

    //private static IServiceCollection AddLoggingOptions(this IServiceCollection services)
    //{
    //}
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
