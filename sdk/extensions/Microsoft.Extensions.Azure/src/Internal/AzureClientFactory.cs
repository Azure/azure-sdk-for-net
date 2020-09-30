// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class AzureClientFactory<TClient, TOptions>: IAzureClientFactory<TClient>
    {
        private readonly Dictionary<string, ClientRegistration<TClient>> _clientRegistrations;

        private readonly IServiceProvider _serviceProvider;
        private readonly IOptionsMonitor<AzureClientsGlobalOptions> _globalOptions;

        private readonly IOptionsMonitor<AzureClientCredentialOptions<TClient>> _clientsOptions;

        private readonly IOptionsMonitor<TOptions> _monitor;

        private readonly EventSourceLogForwarder _logForwarder;
        private readonly AzureComponentFactory _componentFactory;
        private FallbackAzureClientFactory<TClient> _fallbackFactory;

        public AzureClientFactory(
            IServiceProvider serviceProvider,
            IOptionsMonitor<AzureClientsGlobalOptions> globalOptions,
            IOptionsMonitor<AzureClientCredentialOptions<TClient>> clientsOptions,
            IEnumerable<ClientRegistration<TClient>> clientRegistrations,
            IOptionsMonitor<TOptions> monitor,
            EventSourceLogForwarder logForwarder,
            AzureComponentFactory componentFactory)
        {
            _clientRegistrations = new Dictionary<string, ClientRegistration<TClient>>();
            foreach (var registration in clientRegistrations)
            {
                _clientRegistrations[registration.Name] = registration;
            }

            _serviceProvider = serviceProvider;
            _globalOptions = globalOptions;
            _clientsOptions = clientsOptions;
            _monitor = monitor;
            _logForwarder = logForwarder;
            _componentFactory = componentFactory;
        }

        public TClient CreateClient(string name)
        {
            _logForwarder.Start();

            if (!_clientRegistrations.TryGetValue(name, out ClientRegistration<TClient> registration))
            {
                _fallbackFactory ??= new FallbackAzureClientFactory<TClient>(
                    _globalOptions,
                    _serviceProvider,
                    _componentFactory,
                    _logForwarder);
                return _fallbackFactory.CreateClient(name);
            }

            return registration.GetClient(_monitor.Get(name), _clientsOptions.Get(name).CredentialFactory(_serviceProvider));
        }
    }
}