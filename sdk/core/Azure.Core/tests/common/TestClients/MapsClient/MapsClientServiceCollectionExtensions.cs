// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core.TestFramework;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Core.Experimental.Tests;

public static class MapsClientServiceCollectionExtensions
{
    public static IServiceCollection AddMapsClient(this IServiceCollection services)
    {
        services.AddCommonOptions();

        services.AddOptions<MapsClientOptions>()
                .Configure<IOptions<ClientOptions>>((clientOptions, commonOptions) =>
                {
                    clientOptions.Diagnostics.LoggerFactory = commonOptions.Value.Diagnostics.LoggerFactory;
                });

        services.AddSingleton(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration commonConfiguration = configuration.GetSection("ClientCommon");
            IConfiguration clientConfiguration = configuration.GetSection("MapsClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            DefaultAzureCredential credential = new();

            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddMapsClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection)
    {
        services.AddCommonOptions(commonConfigurationSection);

        services.AddOptions<MapsClientOptions>()
                .Configure<IOptions<ClientOptions>>((clientOptions, commonOptions) =>
                {
                    clientOptions.Diagnostics.LoggerFactory = commonOptions.Value.Diagnostics.LoggerFactory;
                })
            .Bind(clientConfigurationSection);

        services.AddSingleton(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);
            DefaultAzureCredential credential = new();

            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }
}
