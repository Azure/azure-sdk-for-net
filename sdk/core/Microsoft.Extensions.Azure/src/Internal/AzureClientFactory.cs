// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class AzureClientFactory<TClient, TOptions>: IAzureClientFactory<TClient>
    {
        private readonly Dictionary<string, ClientRegistration<TClient, TOptions>> _clientRegistrations;

        private readonly IServiceProvider _serviceProvider;

        private readonly IOptionsMonitor<AzureClientCredentialOptions<TClient>> _clientsOptions;

        private readonly IOptionsMonitor<TOptions> _monitor;

        private readonly EventSourceLogForwarder _logForwarder;

        public AzureClientFactory(
            IServiceProvider serviceProvider,
            IOptionsMonitor<AzureClientCredentialOptions<TClient>> clientsOptions,
            IEnumerable<ClientRegistration<TClient, TOptions>> clientRegistrations, IOptionsMonitor<TOptions> monitor,
            EventSourceLogForwarder logForwarder)
        {
            _clientRegistrations = new Dictionary<string, ClientRegistration<TClient, TOptions>>();
            foreach (var registration in clientRegistrations)
            {
                _clientRegistrations[registration.Name] = registration;
            }

            _serviceProvider = serviceProvider;
            _clientsOptions = clientsOptions;
            _monitor = monitor;
            _logForwarder = logForwarder;
        }

        public TClient CreateClient(string name)
        {
            if (!_clientRegistrations.TryGetValue(name, out ClientRegistration<TClient, TOptions> registration))
            {
                throw new InvalidOperationException($"Unable to find client registration with type '{typeof(TClient).Name}' and name '{name}'.");
            }

            return registration.GetClient(_monitor.Get(name), _clientsOptions.Get(name).CredentialFactory(_serviceProvider));
        }
    }
}