// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ClientModel.ReferenceClients.SimpleClient;

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
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                    {
                        // TODO: devise strategy for copying common options to client options
                        clientOptions.Logging.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
                    });

        services.AddSingleton<SimpleClient>(sp =>
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
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    // TODO: is this the right pattern for taking both common and client-specific
    // configuration sections?  Or should there be a higher level block that holds both?
    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection)
    {
        services.AddCommonOptions(commonConfigurationSection);

        // Bind client options to common and client settings, and configure
        // with caller-specified configure options delegate.
        services.AddOptions<SimpleClientOptions>()
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                {
                    // TODO: devise strategy for copying common options to client options
                    clientOptions.Logging.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
                })
            .Bind(commonConfigurationSection)

            // TODO: validate that binding to client config second allows client
            // configuration to override comon settings.
            .Bind(clientConfigurationSection);

        services.AddSingleton<SimpleClient>(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }

    public static IServiceCollection AddSimpleClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection,
        Action<SimpleClientOptions> configureOptions)
    {
        services.AddCommonOptions(commonConfigurationSection);

        // Bind client options to common and client settings, and configure
        // with caller-specified configure options delegate.
        services.AddOptions<SimpleClientOptions>()
                .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
                {
                    // TODO: devise strategy for copying common options to client options
                    clientOptions.Logging.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
                })
                .Bind(commonConfigurationSection)
                .Bind(clientConfigurationSection)
                .Configure(configureOptions);

        // Add the requested client
        services.AddSingleton<SimpleClient>(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);

            // TODO: how to get this securely?
            ApiKeyCredential credential = new("fake key");

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SimpleClientOptions> iOptions = sp.GetRequiredService<IOptions<SimpleClientOptions>>();
            SimpleClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SimpleClient(endpoint, credential, options);
        });

        return services;
    }
}
