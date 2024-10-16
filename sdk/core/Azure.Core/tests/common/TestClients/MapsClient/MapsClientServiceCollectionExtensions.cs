// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Core.Experimental.Tests;

public static class MapsClientServiceCollectionExtensions
{
    public static IServiceCollection AddMapsClient(this IServiceCollection services)
    {
        // Add common options
        services.AddCommonOptions();

        // Add client options
        services.AddOptions<MapsClientOptions>()
                .Configure<IOptions<ClientOptions>>((clientOptions, commonOptions) =>
                {
                    // TODO: devise strategy for copying common options to client options
                    clientOptions.Diagnostics.LoggerFactory = commonOptions.Value.Diagnostics.LoggerFactory;
                });

        services.AddSingleton(sp =>
        {
            // TODO: factor out configuration lookup cases per proposed schema
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration commonConfiguration = configuration.GetSection("ClientCommon");
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            // TODO: how to get this securely?
            var credential = new MockCredential();

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
        IConfiguration clientConfigurationSection)
    {
        // Bind client options to common and client settings, and configure
        // with caller-specified configure options delegate.
        services.AddOptions<MapsClientOptions>()
                .Configure(clientOptions =>
                {
                    var defaultOptions = ClientOptions.Default;
                    clientOptions.Diagnostics.LoggerFactory = defaultOptions.Diagnostics.LoggerFactory;
                })
            .Bind(clientConfigurationSection);

        services.AddSingleton(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);

            // TODO: how to get this securely?
            var credential = new MockCredential();

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
