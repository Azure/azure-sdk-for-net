// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class FallbackAzureClientFactory<TClient>: IAzureClientFactory<TClient>
    {
        private readonly IOptionsMonitor<AzureClientsGlobalOptions> _globalOptions;
        private readonly IServiceProvider _serviceProvider;
        private readonly EventSourceLogForwarder _logForwarder;
        private readonly Dictionary<string, FallbackClientRegistration<TClient>> _clientRegistrations;
        private readonly Type _clientOptionType;

        public FallbackAzureClientFactory(
            IOptionsMonitor<AzureClientsGlobalOptions> globalOptions,
            IServiceProvider serviceProvider,
            EventSourceLogForwarder logForwarder)
        {
            _globalOptions = globalOptions;
            _serviceProvider = serviceProvider;
            _logForwarder = logForwarder;
            _clientRegistrations = new Dictionary<string, FallbackClientRegistration<TClient>>();

            foreach (var constructor in typeof(TClient).GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            {
                var lastParameter = constructor.GetParameters().LastOrDefault();
                if (lastParameter != null && typeof(ClientOptions).IsAssignableFrom(lastParameter.ParameterType))
                {
                    _clientOptionType = lastParameter.ParameterType;
                    break;
                }
            }

            if (_clientOptionType == null)
            {
                throw new InvalidOperationException("Unable to detect the client option type");
            }
        }

        public TClient CreateClient(string name)
        {
            _logForwarder.Start();

            var globalOptions = _globalOptions.CurrentValue;

            FallbackClientRegistration<TClient> registration;
            lock (_clientRegistrations)
            {
                if (!_clientRegistrations.TryGetValue(name, out registration))
                {
                    var section = globalOptions.ConfigurationRootResolver?.Invoke(_serviceProvider).GetSection(name);
                    if (!section.Exists())
                    {
                        throw new InvalidOperationException($"Unable to find a configuration section with the name {name} to configure the client with or the configuration root wasn't set.");
                    }

                    registration = new FallbackClientRegistration<TClient>(
                        name,
                        (options, credential) => (TClient) ClientFactory.CreateClient(typeof(TClient), _clientOptionType, options, section, credential),
                        section);

                    _clientRegistrations.Add(name, registration);
                }
            }


            return registration.GetClient(
                GetClientOptions(globalOptions, registration.Configuration),
                ClientFactory.CreateCredential(registration.Configuration) ?? globalOptions.CredentialFactory(_serviceProvider));
        }

        private object GetClientOptions(AzureClientsGlobalOptions globalOptions, IConfiguration section)
        {
            var clientOptions = (ClientOptions) ClientFactory.CreateClientOptions(null, _clientOptionType);
            foreach (var globalConfigureOptions in globalOptions.ConfigureOptionDelegates)
            {
                globalConfigureOptions(clientOptions, _serviceProvider);
            }

            section.Bind(clientOptions);

            return clientOptions;
        }

        private class FallbackClientRegistration<T>: ClientRegistration<T>
        {
            public IConfiguration Configuration { get; }

            public FallbackClientRegistration(string name, Func<object, TokenCredential, T> factory, IConfiguration configuration) : base(name, factory)
            {
                Configuration = configuration;
            }
        }
    }
}