// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClientModel.ReferenceClients.MapsClient;

public static class MapsClientServiceCollectionExtensions
{
    public static IServiceCollection AddMapsClient(this IServiceCollection services)
    {
        // Add common options
        services.AddCommonOptions();

        // Add client options
        services.AddOptions<MapsClientOptions>()
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                {
                    // TODO: devise strategy for copying common options to client options
                    clientOptions.Observability.LoggerFactory = commonOptions.Value.Observability.LoggerFactory;
                });

        services.AddSingleton<MapsClient>(sp =>
        {
            // TODO: factor out configuration lookup cases per proposed schema
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration commonConfiguration = configuration.GetSection("ClientCommon");
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
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

        // Bind client options to common and client settings, and configure
        // with caller-specified configure options delegate.
        services.AddOptions<MapsClientOptions>()
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                {
                    // TODO: devise strategy for copying common options to client options
                    clientOptions.Observability.LoggerFactory = commonOptions.Value.Observability.LoggerFactory;
                })
            .Bind(commonConfigurationSection)

            // TODO: validate that binding to client config second allows client
            // configuration to override comon settings.
            .Bind(clientConfigurationSection);

        services.AddSingleton<MapsClient>(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }
}
