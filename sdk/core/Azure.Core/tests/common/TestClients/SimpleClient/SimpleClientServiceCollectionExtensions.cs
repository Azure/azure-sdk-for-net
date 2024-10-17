// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Core.Experimental.Tests;

public static class SimpleClientServiceCollectionExtensions
{
    // No parameters uses client defaults
    // See: https://learn.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#parameterless
    public static IServiceCollection AddSimpleClient(this IServiceCollection services)
    {
        // Add common options
        services.AddCommonOptions();

        // Add client options
        services.AddOptions<SimpleClientOptions>()
                .Configure(clientOptions =>
                {
                    clientOptions.Diagnostics.LoggerFactory = ClientOptions.Default.Diagnostics.LoggerFactory;
                });

        services.AddSingleton(sp =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration clientConfiguration = configuration.GetSection("SimpleClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            TokenCredential credential = new MockCredential();

            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration clientConfigurationSection)
    {
        services.AddOptions<SimpleClientOptions>()
                .Configure(clientOptions =>
                {
                    clientOptions.Diagnostics.LoggerFactory = ClientOptions.Default.Diagnostics.LoggerFactory;
                })
            .Bind(clientConfigurationSection);

        services.AddSingleton(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);

            TokenCredential credential = new MockCredential();

            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration clientConfigurationSection,
        Action<SimpleClientOptions> configureOptions,
        object key = default)
    {
        OptionsBuilder<SimpleClientOptions> optionsBuilder = key is null ?
            services.AddOptions<SimpleClientOptions>() :
            services.AddOptions<SimpleClientOptions>(key.ToString());

        optionsBuilder
            .Configure(clientOptions =>
            {
                clientOptions.Diagnostics.LoggerFactory = ClientOptions.Default.Diagnostics.LoggerFactory;
            })
            .Bind(clientConfigurationSection)
            .Configure(configureOptions);

        Func<IServiceProvider, object, SimpleClient> clientFactory = (sp, key) =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);
            TokenCredential credential = new MockCredential();

            IOptionsMonitor<SimpleClientOptions> iOptions =
                sp.GetRequiredService<IOptionsMonitor<SimpleClientOptions>>();

            SimpleClientOptions options = key is null ?
                iOptions.CurrentValue :
                iOptions.Get(key.ToString());

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        };
        if (key is null)
        {
            services.AddSingleton<SimpleClient>(sp => clientFactory(sp, key));
        }
        else
        {
            services.AddKeyedSingleton<SimpleClient>(key, clientFactory);
        }

        return services;
    }
}
