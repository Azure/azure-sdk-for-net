// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Net.NetworkInformation;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Security.KeyVault.Secrets;

/// <summary>
/// TODO
/// </summary>
public static class SecretClientServiceCollectionExtensions
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSecretClient(this IServiceCollection services)
    {
        services.AddCommonOptions();

        services.AddOptions<SecretClientOptions>()
            .Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
            {
                clientOptions.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
            });

        services.AddSingleton<SecretClient>(sp =>
        {
            // TODO: factor out configuration lookup cases per proposed schema
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            IConfiguration commonConfiguration = configuration.GetSection("ClientCommon");
            IConfiguration clientConfiguration = configuration.GetSection("SecretClient");

            Uri endpoint = sp.GetClientEndpoint(clientConfiguration);

            // TODO: how to get this securely?
            var credential = new DefaultAzureCredential();

            // TODO: to roll a credential, this will need to be IOptionsMonitor
            // not IOptions -- come back to this.
            IOptions<SecretClientOptions> iOptions = sp.GetRequiredService<IOptions<SecretClientOptions>>();
            SecretClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SecretClient(endpoint, credential, options);
        });

        return services;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="commonConfigurationSection"></param>
    /// <param name="clientConfigurationSection"></param>
    /// <returns></returns>
    public static IServiceCollection AddSecretClient(this IServiceCollection services,
        IConfiguration commonConfigurationSection,
        IConfiguration clientConfigurationSection)
    {
        services.AddCommonOptions(commonConfigurationSection);

        services.AddOptions<SecretClientOptions>().Configure<IOptions<ClientPipelineOptions>>((clientOptions, commonOptions) =>
        {
            clientOptions.LoggerFactory = commonOptions.Value.Logging.LoggerFactory;
        })
            .Bind(commonConfigurationSection).Bind(clientConfigurationSection);

        services.AddSingleton<SecretClient>(sp =>
        {
            Uri endpoint = sp.GetClientEndpoint(clientConfigurationSection);
            // TODO: how to get this securely?
            var credential = new DefaultAzureCredential();

            IOptions<SecretClientOptions> iOptions = sp.GetRequiredService<IOptions<SecretClientOptions>>();
            SecretClientOptions options = iOptions.Value;

            options = options.ConfigurePolicies(sp);

            return new SecretClient(endpoint, credential, options);
        });

        return services;
    }

    // I think this depends on how ClientOptions / ClientPipelineOptions are reconciled. Same as
    // Azure's logging policy and SCM logging policy / retry policy
    private static TOptions ConfigurePolicies<TOptions>(this TOptions options,
        IServiceProvider serviceProvider) where TOptions : ClientOptions
    {
        //// TODO: this doesn't really make sense yet

        return options;
    }
}
