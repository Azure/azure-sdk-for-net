// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// Extension methods to configure client registrations.
    /// </summary>
    public static class AzureClientBuilderExtensions
    {
        /// <summary>
        /// Sets the name for the client registration. To resolve named clients use <see cref="IAzureClientFactory{TClient}.CreateClient"/> method.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="name">The name to set.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> WithName<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, string name) where TOptions : class
        {
            builder.ToBuilder().Registration.Name = name;
            return builder;
        }

        /// <summary>
        /// Set the credential to use for this client registration.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="credential">The credential to use.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, TokenCredential credential) where TOptions : class
        {
            return builder.WithCredential(_ => credential);
        }

        /// <summary>
        /// Set the credential factory to use for this client registration.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="credentialFactory">The credential factory to use.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> WithCredential<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Func<IServiceProvider, TokenCredential> credentialFactory) where TOptions : class
        {
            var impl = builder.ToBuilder();
            impl.ServiceCollection.AddSingleton<IConfigureOptions<AzureClientCredentialOptions<TClient>>>(new ConfigureClientCredentials<TClient,TOptions>(impl.Registration, credentialFactory));
            return builder;
        }

        /// <summary>
        /// Adds a delegate to configure the client options. All delegates are executed in order they were added.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="configureOptions">The delegate to use to configure options.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Action<TOptions> configureOptions) where TOptions : class
        {
            return builder.ConfigureOptions((options, _) => configureOptions(options));
        }

        /// <summary>
        /// Configures client options using provided <see cref="IConfiguration"/> instance.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="configuration">The configuration instance to use.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, IConfiguration configuration) where TOptions : class
        {
            return builder.ConfigureOptions(options => configuration.Bind(options));
        }

        /// <summary>
        /// Adds a delegate to configure the client options. All delegates are executed in order they were added.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="configureOptions">The delegate to use to configure options.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> ConfigureOptions<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder, Action<TOptions, IServiceProvider> configureOptions) where TOptions : class
        {
            var impl = builder.ToBuilder();
            impl.ServiceCollection.AddSingleton<IConfigureOptions<TOptions>>(provider => new ConfigureClientOptions<TClient,TOptions>(provider, impl.Registration, configureOptions));;
            return builder;
        }

        /// <summary>
        /// Sets the service version to use for this client registration.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The options type the client uses.</typeparam>
        /// <typeparam name="TVersion">The service version enum type.</typeparam>
        /// <param name="builder">The client builder instance.</param>
        /// <param name="version">The delegate to use to configure options.</param>
        /// <returns>The client builder instance.</returns>
        public static IAzureClientBuilder<TClient, TOptions> WithVersion<TClient, TOptions, TVersion>(this IAzureClientBuilder<TClient, TOptions> builder, TVersion version) where TOptions : class
        {
            if (typeof(TVersion).DeclaringType != typeof(TOptions))
            {
                throw new ArgumentException($"Version should be of type {typeof(TOptions)}.ServiceVersion");
            }
            builder.ToBuilder().Registration.Version = version;
            return builder;
        }

        private static AzureClientBuilder<TClient, TOptions> ToBuilder<TClient, TOptions>(this IAzureClientBuilder<TClient, TOptions> builder) where TOptions : class
        {
            return (AzureClientBuilder<TClient, TOptions>)builder;
        }
    }
}