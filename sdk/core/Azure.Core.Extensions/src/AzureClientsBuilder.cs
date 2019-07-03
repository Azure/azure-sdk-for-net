// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Azure.Core.Extensions
{
    public sealed class AzureClientsBuilder : IAzureClientsBuilderWithConfiguration<IConfiguration>, IAzureClientsBuilderWithCredential
    {
        private readonly IServiceCollection _serviceCollection;

        private const string DefaultClientName = "Default";

        internal AzureClientsBuilder(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            _serviceCollection.AddOptions();
            _serviceCollection.TryAddSingleton<EventSourceLogForwarder>();
        }

        void IAzureClientsBuilder.RegisterClient<TClient, TOptions>(string name, Func<TOptions, TClient> clientFactory, Action<TOptions> configureOptions)
        {
            ((IAzureClientsBuilderWithCredential)this).RegisterClient<TClient, TOptions>(
                name,
                (options, _) => clientFactory(options),
                configureOptions,
                null);
        }

        void IAzureClientsBuilderWithConfiguration<IConfiguration>.RegisterClient<TClient, TOptions>(string name, IConfiguration configuration)
        {
            ((IAzureClientsBuilderWithCredential)this).RegisterClient<TClient, TOptions>(
                name,
                (options, credentials) => (TClient)ClientFactory.CreateClient(typeof(TClient), typeof(TOptions), options, configuration, credentials),
                options => configuration.Bind(options),
                ClientFactory.CreateCredentials(configuration));
        }

        public AzureClientsBuilder ConfigureDefaults(Action<ClientOptions> configureOptions)
        {
            ConfigureDefaults((options, provider) => configureOptions(options));
            return this;
        }

        public AzureClientsBuilder ConfigureDefaults(Action<ClientOptions, IServiceProvider> configureOptions)
        {
            _serviceCollection.Configure<AzureClientsGlobalOptions>(options => options.ConfigureOptions.Add(configureOptions));

            return this;
        }

        public AzureClientsBuilder UseDefaultConfiguration(IConfiguration configuration)
        {
            ConfigureDefaults(options => configuration.Bind(options));

            var credentialsFromConfig = ClientFactory.CreateCredentials(configuration);

            if (credentialsFromConfig != null)
            {
                UseCredential(credentialsFromConfig);
            }

            return this;
        }

        void IAzureClientsBuilderWithCredential.RegisterClient<TClient, TOptions>(string name, Func<TOptions, TokenCredential, TClient> clientFactory, Action<TOptions> configureOptions, TokenCredential providedCredential)
        {
            _serviceCollection.AddSingleton(new ClientRegistration<TClient, TOptions>(name, clientFactory));

            _serviceCollection.TryAddSingleton(typeof(IConfigureOptions<AzureClientOptions<TClient>>), typeof(DefaultCredentialClientOptionsSetup<TClient>));
            _serviceCollection.TryAddSingleton(typeof(IConfigureOptions<TOptions>), typeof(DefaultClientOptionsSetup<TOptions>));
            _serviceCollection.TryAddSingleton(typeof(IAzureClientFactory<TClient>), typeof(AzureClientFactory<TClient, TOptions>));
            _serviceCollection.TryAddSingleton(
                typeof(TClient),
                provider => provider.GetService<IAzureClientFactory<TClient>>().CreateClient(DefaultClientName));

            if (configureOptions != null)
            {
                _serviceCollection.Configure<TOptions>(name, configureOptions);
            }

            if (providedCredential != null)
            {
                UseCredential<TClient>(name, providedCredential);
            }
        }


        public AzureClientsBuilder UseCredential(TokenCredential tokenCredential)
        {
            return UseCredential(_ => tokenCredential);
        }

        public AzureClientsBuilder UseCredential(Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            _serviceCollection.Configure<AzureClientsGlobalOptions>(options => options.Credential = tokenCredentialFactory);
            return this;
        }

        public AzureClientsBuilder UseCredential<TClient>(string name, TokenCredential tokenCredential)
        {
            return UseCredential<TClient>(name, _ => tokenCredential);
        }

        public AzureClientsBuilder UseCredential<TClient>(string name, Func<IServiceProvider, TokenCredential> tokenCredentialFactory)
        {
            _serviceCollection.Configure<AzureClientOptions<TClient>>(name, options => options.CredentialFactory = tokenCredentialFactory);
            return this;
        }
    }
}