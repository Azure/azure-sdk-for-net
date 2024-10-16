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
                .Configure(clientOptions =>
                {
                    clientOptions.Diagnostics.LoggerFactory = ClientOptions.Default.Diagnostics.LoggerFactory;
                });

        services.AddSingleton(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("MapsClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            var credential = new MockCredential();

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
            var credential = new MockCredential();

            IOptions<MapsClientOptions> iOptions = sp.GetRequiredService<IOptions<MapsClientOptions>>();
            MapsClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new MapsClient(endpoint, credential, options);
        });

        return services;
    }
}
