// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Azure.Core.Extensions
{
    public static class AzureClientBuilderExtensions
    {
        public static IAzureClientBuilder<TClient, TOptions> WithName<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, string name) where TOptions : class
        {
            builder.ToBuilder().Registration.Name = name;
            return builder;
        }

        public static IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, TokenCredential credential) where TOptions : class
        {
            return builder.WithCredential(_ => credential);
        }

        public static IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Func<IServiceProvider, TokenCredential> credentialFactory) where TOptions : class
        {
            var impl = builder.ToBuilder();
            impl.ServiceCollection.AddSingleton<IConfigureOptions<AzureClientCredentialOptions<TClient>>>(new ConfigureClientCredentials<TClient,TOptions>(impl.Registration, credentialFactory));
            return builder;
        }

        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Action<TOptions> configureOptions) where TOptions : class
        {
            return builder.ConfigureOptions((options, _) => configureOptions(options));
        }

        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, IConfiguration configuration) where TOptions : class
        {
            return builder.ConfigureOptions(options => configuration.Bind(options));
        }

        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Action<TOptions, IServiceProvider> configureOptions) where TOptions : class
        {
            var impl = builder.ToBuilder();
            impl.ServiceCollection.AddSingleton<IConfigureOptions<TOptions>>(provider => new ConfigureClientOptions<TClient,TOptions>(provider, impl.Registration, configureOptions));;
            return builder;
        }

        public static IAzureClientBuilder<TClient, TOptions> WithVersion<TClient, TOptions, TVersion>(this IAzureClientBuilder<TClient, TOptions> builder, TVersion version) where TOptions : class
        {
            builder.ToBuilder().Registration.Version = version;
            return builder;
        }

        private static AzureClientBuilder<TClient, TOptions> ToBuilder<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder) where TOptions : class
        {
            return (AzureClientBuilder<TClient, TOptions>)builder;
        }
    }
}