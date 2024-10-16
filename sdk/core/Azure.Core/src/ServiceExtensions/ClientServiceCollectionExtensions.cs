// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azure.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class ClientServiceCollectionExtensions
{
    public static IServiceCollection AddCommonOptions(this IServiceCollection services)
    {
        services.AddRequiredServices();
        services.AddClientOptions();

        return services;
    }

    public static IServiceCollection AddCommonOptions(this IServiceCollection services, IConfiguration commonConfigurationSection)
    {
        services.AddRequiredServices();

        services.AddClientOptions().Bind(commonConfigurationSection);

        return services;
    }

    private static IServiceCollection AddRequiredServices(this IServiceCollection services)
    {
        services.AddLogging();

        return services;
    }

    private static OptionsBuilder<ClientOptions> AddClientOptions(this IServiceCollection services)
    {
        OptionsBuilder<ClientOptions> builder =
            services.AddOptions<ClientOptions>()
                .Configure<ILoggerFactory>((options, loggerFactory) =>
                {
                    options.Diagnostics.LoggerFactory = loggerFactory;
                });

        services.AddSingleton(sp =>
        {
            IOptions<ClientOptions> options = sp.GetRequiredService<IOptions<ClientOptions>>();
            return options.Value.Diagnostics;
        });

        return builder;
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
