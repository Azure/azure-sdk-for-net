// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.Azure
{
    internal class FallbackAzureClientFactory<TClient>: IAzureClientFactory<TClient>
    {
        private readonly AzureComponentFactory _componentFactory;
        private readonly EventSourceLogForwarder _logForwarder;
        private readonly Dictionary<string, FallbackClientRegistration<TClient>> _clientRegistrations;
        private readonly Type _clientOptionType;
        private readonly IConfiguration _configurationRoot;
        private readonly IClientOptionsFactory _optionsFactory;

        public FallbackAzureClientFactory(
            IOptionsMonitor<AzureClientsGlobalOptions> globalOptions,
            IServiceProvider serviceProvider,
            AzureComponentFactory componentFactory,
            EventSourceLogForwarder logForwarder)
        {
            _configurationRoot = globalOptions.CurrentValue.ConfigurationRootResolver?.Invoke(serviceProvider);

            _componentFactory = componentFactory;
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

            _optionsFactory = (IClientOptionsFactory)ActivatorUtilities.CreateInstance(serviceProvider, typeof(ClientOptionsFactory<,>).MakeGenericType(typeof(TClient), _clientOptionType));
        }

        public TClient CreateClient(string name)
        {
            if (_configurationRoot == null)
            {
                throw new InvalidOperationException($"Unable to find client registration with type '{typeof(TClient).Name}' and name '{name}'.");
            }

            _logForwarder.Start();

            FallbackClientRegistration<TClient> registration;
            lock (_clientRegistrations)
            {
                if (!_clientRegistrations.TryGetValue(name, out registration))
                {
                    var section = _configurationRoot.GetSection(name);

                    if (!section.Exists())
                    {
                        throw new InvalidOperationException($"Unable to find a configuration section with the name {name} to configure the client with.");
                    }

                    registration = new FallbackClientRegistration<TClient>(
                        name,
                        (options, credential) => (TClient) ClientFactory.CreateClient(typeof(TClient), _clientOptionType, options, section, credential),
                        section);

                    _clientRegistrations.Add(name, registration);
                }
            }

            var currentOptions = _optionsFactory.CreateOptions(name);
            registration.Configuration.Bind(currentOptions);
            return registration.GetClient(currentOptions, _componentFactory.CreateCredential(registration.Configuration));
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