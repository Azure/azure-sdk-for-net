// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    /// <summary>
    /// The builder type for registering Azure SDK clients.
    /// </summary>
    public sealed class AzureClientFactoryBuilder : IAzureClientFactoryBuilderWithConfiguration<IConfiguration>, IAzureClientFactoryBuilderWithCredential
    {
        private readonly IServiceCollection _serviceCollection;

        internal const string DefaultClientName = "Default";

        internal AzureClientFactoryBuilder(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        IAzureClientBuilder<TClient, TOptions> IAzureClientFactoryBuilder.RegisterClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TClient> clientFactory)
        {
            return ((IAzureClientFactoryBuilderWithCredential)this).RegisterClientFactory<TClient, TOptions>((options, _) => clientFactory(options));
        }

        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        IAzureClientBuilder<TClient, TOptions> IAzureClientFactoryBuilderWithConfiguration<IConfiguration>.RegisterClientFactory<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            IConfiguration configuration)
        {
            var credentialsFromConfig = ClientFactory.CreateCredential(configuration);
            var clientBuilder =((IAzureClientFactoryBuilderWithCredential)this).RegisterClientFactory<TClient, TOptions>(
                (options, credentials) => (TClient)ClientFactory.CreateClient(typeof(TClient), typeof(TOptions), options, configuration, credentials))
                .ConfigureOptions(configuration);

            if (credentialsFromConfig != null)
            {
                clientBuilder.WithCredential(credentialsFromConfig);
            }

            return clientBuilder;
        }

        /// <summary>
        /// Adds a configuration delegate that gets executed for all clients.
        /// </summary>
        /// <param name="configureOptions">The configuration delegate.</param>
        /// <returns>This instance.</returns>
        public AzureClientFactoryBuilder ConfigureDefaults(Action<ClientOptions> configureOptions)
        {
            ConfigureDefaults((options, provider) => configureOptions(options));
            return this;
        }

        /// <summary>
        /// Adds a configuration delegate that gets executed for all clients.
        /// </summary>
        /// <param name="configureOptions">The configuration delegate.</param>
        /// <returns>This instance.</returns>
        public AzureClientFactoryBuilder ConfigureDefaults(Action<ClientOptions, IServiceProvider> configureOptions)
        {
            _serviceCollection.Configure<AzureClientsGlobalOptions>(options => options.ConfigureOptionDelegates.Add(configureOptions));

            return this;
        }

        /// <summary>
        /// Adds a configuration instance to initialize all clients from.
        /// </summary>
        /// <param name="configuration">The configuration instance.</param>
        /// <returns>This instance.</returns>
        [RequiresUnreferencedCode("Binding strongly typed objects to configuration values is not supported with trimming. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        [RequiresDynamicCode("Binding strongly typed objects to configuration values requires generating dynamic code at runtime, for example instantiating generic types. Use the Configuration Binder Source Generator (EnableConfigurationBindingGenerator=true) instead.")]
        public AzureClientFactoryBuilder ConfigureDefaults(IConfiguration configuration)
        {
            ConfigureDefaults(configuration.Bind);

            var credentialsFromConfig = ClientFactory.CreateCredential(configuration);

            if (credentialsFromConfig != null)
            {
                UseCredential(credentialsFromConfig);
            }

            return this;
        }

        IAzureClientBuilder<TClient, TOptions> IAzureClientFactoryBuilderWithCredential.RegisterClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TokenCredential, TClient> clientFactory, bool requiresCredential)
        {
            return RegisterClientFactory<TClient, TOptions>((options, credential, _) => clientFactory(options, credential), requiresCredential);
        }

        /// <summary>
        /// Sets the credential to use by default for all clients.
        /// </summary>
        /// <param name="tokenCredential">The credential to use.</param>
        /// <returns>This instance.</returns>
        public AzureClientFactoryBuilder UseCredential(TokenCredential tokenCredential)
        {
            return UseCredential(_ => tokenCredential);
        }

        /// <summary>
        /// Sets the credential to use by default for all clients.
        /// </summary>
        /// <param name="tokenCredentialFactory">The credential factory to use.</param>
        /// <returns>This instance.</returns>
        public AzureClientFactoryBuilder UseCredential(Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            _serviceCollection.Configure<AzureClientsGlobalOptions>(options => options.CredentialFactory = tokenCredentialFactory);
            return this;
        }

        /// <summary>
        /// Adds a client factory for <typeparamref name="TClient"/> using <typeparamref name="TOptions"/> as options type.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The type of the client options.</typeparam>
        /// <returns>The <see cref="IAzureClientBuilder{TClient, TOptions}"/> to allow client configuration.</returns>
        public IAzureClientBuilder<TClient, TOptions> AddClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TClient> factory)
            where TOptions : class
        {
            return RegisterClientFactory<TClient, TOptions>((options, _, _) => factory(options), false);
        }

        /// <summary>
        /// Adds a client factory for <typeparamref name="TClient"/> using <typeparamref name="TOptions"/> as options type and a <see cref="TokenCredential"/> for authentication.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The type of the client options.</typeparam>
        /// <returns>The <see cref="IAzureClientBuilder{TClient, TOptions}"/> to allow client configuration.</returns>
        public IAzureClientBuilder<TClient, TOptions> AddClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TokenCredential, TClient> factory)
            where TOptions : class
        {
            return RegisterClientFactory<TClient, TOptions>((options, credential, _) => factory(options, credential), true);
        }

        /// <summary>
        /// Adds a client factory for <typeparamref name="TClient"/> using <typeparamref name="TOptions"/> as options type.
        /// Allows resolving services from <see cref="IServiceProvider"/> during the client construction.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The type of the client options.</typeparam>
        /// <returns>The <see cref="IAzureClientBuilder{TClient, TOptions}"/> to allow client configuration.</returns>
        public IAzureClientBuilder<TClient, TOptions> AddClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, IServiceProvider, TClient> factory)
            where TOptions : class
        {
            return RegisterClientFactory<TClient, TOptions>((options, _, provider) => factory(options, provider), true);
        }

        /// <summary>
        /// Adds a client factory for <typeparamref name="TClient"/> using <typeparamref name="TOptions"/> as options type and a <see cref="TokenCredential"/> for authentication.
        /// Allows resolving services from <see cref="IServiceProvider"/> during the client construction.
        /// </summary>
        /// <typeparam name="TClient">The type of the client.</typeparam>
        /// <typeparam name="TOptions">The type of the client options.</typeparam>
        /// <returns>The <see cref="IAzureClientBuilder{TClient, TOptions}"/> to allow client configuration.</returns>
        public IAzureClientBuilder<TClient, TOptions> AddClient<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TokenCredential, IServiceProvider, TClient> factory)
            where TOptions : class
        {
            return RegisterClientFactory<TClient, TOptions>((options, credential, provider) => factory(options, credential, provider), true);
        }

        private IAzureClientBuilder<TClient, TOptions> RegisterClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>(
            Func<TOptions, TokenCredential, IServiceProvider, TClient> clientFactory,
            bool requiresCredential)
            where TOptions : class
        {
            var clientRegistration = new ClientRegistration<TClient>(DefaultClientName, requiresCredential, (provider, options, credential) => clientFactory((TOptions) options, credential, provider));
            _serviceCollection.AddSingleton(clientRegistration);

            _serviceCollection.TryAddSingleton(typeof(IConfigureOptions<AzureClientCredentialOptions<TClient>>), typeof(DefaultCredentialClientOptionsSetup<TClient>));
            _serviceCollection.TryAddSingleton(typeof(IOptionsMonitor<TOptions>), typeof(ClientOptionsMonitor<TClient, TOptions>));
            _serviceCollection.TryAddSingleton(typeof(ClientOptionsFactory<TClient, TOptions>), typeof(ClientOptionsFactory<TClient, TOptions>));
            _serviceCollection.TryAddSingleton(typeof(IAzureClientFactory<TClient>), typeof(AzureClientFactory<TClient, TOptions>));
            _serviceCollection.TryAddSingleton(typeof(TClient), provider => provider.GetService<IAzureClientFactory<TClient>>().CreateClient(DefaultClientName));

            return new AzureClientBuilder<TClient, TOptions>(clientRegistration, _serviceCollection);
        }
    }
}