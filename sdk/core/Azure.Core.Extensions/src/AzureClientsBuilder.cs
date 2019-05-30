// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Azure.Core.Extensions
{
    public sealed class AzureClientsBuilder : IAzureClientsBuilderWithConfiguration<IConfiguration>
    {
        private readonly IServiceCollection _serviceCollection;
        private static readonly ConfigurationClientFactory ConfigurationClientFactory = new ConfigurationClientFactory();

        internal AzureClientsBuilder(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            _serviceCollection.AddOptions();
            _serviceCollection.TryAddSingleton<EventSourceLogForwarder>();
        }

        void IAzureClientsBuilder.RegisterClient<TClient, TOptions>(string name, Func<TOptions, TClient> clientFactory, Action<TOptions> configureOptions)
        {
            _serviceCollection.AddSingleton(new ClientRegistration<TClient, TOptions>(name, clientFactory));

            _serviceCollection.TryAddSingleton(typeof(IAzureClientFactory<TClient>), typeof(AzureClientFactory<TClient, TOptions>));

            if (configureOptions != null)
            {
                _serviceCollection.Configure<TOptions>(name, configureOptions);
            }
        }

        void IAzureClientsBuilderWithConfiguration<IConfiguration>.RegisterClient<TClient, TOptions>(string name, IConfiguration configuration)
        {
            ((IAzureClientsBuilder)this).RegisterClient<TClient, TOptions>(
                name,
                options => (TClient)ConfigurationClientFactory.CreateClient(typeof(TClient), typeof(TOptions), options, configuration),
                options => configuration.Bind(options));
        }
    }
}