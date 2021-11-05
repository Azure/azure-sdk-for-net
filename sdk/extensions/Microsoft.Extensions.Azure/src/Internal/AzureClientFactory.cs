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

        private readonly AzureEventSourceLogForwarder _logForwarder;

        public AzureClientFactory(
            IServiceProvider serviceProvider,
            IOptionsMonitor<AzureClientsGlobalOptions> globalOptions,
            IOptionsMonitor<AzureClientCredentialOptions<TClient>> clientsOptions,
            IEnumerable<ClientRegistration<TClient>> clientRegistrations,
            IOptionsMonitor<TOptions> monitor,
            AzureEventSourceLogForwarder logForwarder)
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
        }

        public TClient CreateClient(string name)
        {
            _logForwarder.Start();

            if (!_clientRegistrations.TryGetValue(name, out ClientRegistration<TClient> registration))
            {
                throw new InvalidOperationException($"Unable to find client registration with type '{typeof(TClient).Name}' and name '{name}'.");
            }

            return registration.GetClient(_serviceProvider, _monitor.Get(name), _clientsOptions.Get(name).CredentialFactory(_serviceProvider));
        }
    }
}