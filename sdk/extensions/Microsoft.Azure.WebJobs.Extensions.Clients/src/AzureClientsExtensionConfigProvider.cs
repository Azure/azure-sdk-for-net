// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    internal class AzureClientsExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly AzureComponentFactory _componentFactory;
        private readonly IConfiguration _configuration;
        private readonly INameResolver _nameResolver;

        public AzureClientsExtensionConfigProvider(AzureComponentFactory componentFactory, IConfiguration configuration, INameResolver nameResolver)
        {
            _componentFactory = componentFactory;
            _configuration = configuration;
            _nameResolver = nameResolver;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<AzureClientAttribute>()
                .BindToValueProvider((attribute, type) => Task.FromResult(CreateValueBinder(type, attribute)));
        }

        private IValueBinder CreateValueBinder(Type type, AzureClientAttribute attribute)
        {
            var name = _nameResolver.ResolveWholeString(attribute.Connection);
            var section = _configuration.GetWebJobsConnectionStringSection(name);
            if (!section.Exists())
            {
                throw new InvalidOperationException($"Unable to find a configuration section with the name {name} to configure the client with.");
            }

            return new AzureClientValueProvider(
                type,
                _componentFactory,
                section);
        }

        private class AzureClientValueProvider : IValueBinder
        {
            private readonly Type _clientType;
            private readonly AzureComponentFactory _componentFactory;
            private readonly IConfigurationSection _configuration;

            public AzureClientValueProvider(Type clientType, AzureComponentFactory componentFactory, IConfigurationSection configuration)
            {
                _clientType = clientType;
                _componentFactory = componentFactory;
                _configuration = configuration;
            }

            public Task<object> GetValueAsync()
            {
                Type clientOptionType = null;
                foreach (var constructor in _clientType.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
                {
                    var lastParameter = constructor.GetParameters().LastOrDefault();
                    if (lastParameter != null && typeof(ClientOptions).IsAssignableFrom(lastParameter.ParameterType))
                    {
                        clientOptionType = lastParameter.ParameterType;
                        break;
                    }
                }

                if (clientOptionType == null)
                {
                    throw new InvalidOperationException("Unable to detect the client option type");
                }

                var credential = _componentFactory.CreateTokenCredential(_configuration);
                var options = _componentFactory.CreateClientOptions(clientOptionType, null, _configuration);

                return Task.FromResult(_componentFactory.CreateClient(_clientType, _configuration, credential, options));
            }

            public string ToInvokeString() => $"{_clientType.Name} Connection: {_configuration.Path}";

            public Type Type => _clientType;

            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}