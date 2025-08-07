// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class AzureClientFactory<TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TOptions>
        : IAzureClientFactory<TClient>, IDisposable, IAsyncDisposable
    {
        private readonly Dictionary<string, ClientRegistration<TClient>> _clientRegistrations;

        private readonly IServiceProvider _serviceProvider;
        private readonly IOptionsMonitor<AzureClientsGlobalOptions> _globalOptions;
        private readonly IOptionsMonitor<AzureClientCredentialOptions<TClient>> _clientsOptions;
        private readonly IOptionsMonitor<TOptions> _monitor;
        private readonly AzureEventSourceLogForwarder _logForwarder;

        private volatile bool _disposed;

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

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;

                foreach (var registration in _clientRegistrations.Values)
                {
                    registration.Dispose();
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!_disposed)
            {
                _disposed = true;

                var disposeTasks = new List<Task>(_clientRegistrations.Values.Count);

                foreach (var registration in _clientRegistrations.Values)
                {
                    disposeTasks.Add(registration.DisposeAsync().AsTask());
                }

                await Task.WhenAll(disposeTasks).ConfigureAwait(false);
            }
        }
    }
}