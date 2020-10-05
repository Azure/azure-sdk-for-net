// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting
{
    internal class AzureClientsExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INameResolver _nameResolver;

        public AzureClientsExtensionConfigProvider(IServiceProvider serviceProvider, INameResolver nameResolver)
        {
            _serviceProvider = serviceProvider;
            _nameResolver = nameResolver;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<AzureClientAttribute>()
                .BindToValueProvider((attribute, type) => Task.FromResult(CreateValueBinder(type, attribute)));
        }

        private IValueBinder CreateValueBinder(Type type, AzureClientAttribute attribute)
        {
            return (IValueBinder)Activator.CreateInstance(
                typeof(AzureClientValueProvider<>).MakeGenericType(type),
                _serviceProvider,
                _nameResolver.ResolveWholeString(attribute.Connection));
        }

        private class AzureClientValueProvider<TClient> : IValueBinder
        {
            private readonly IServiceProvider _serviceProvider;
            private readonly string _connection;

            public AzureClientValueProvider(IServiceProvider serviceProvider, string connection)
            {
                _serviceProvider = serviceProvider;
                _connection = connection;
            }

            public Task<object> GetValueAsync()
            {
                return Task.FromResult(
                    (object)_serviceProvider
                        .GetRequiredService<IAzureClientFactory<TClient>>()
                        .CreateClient(_connection));
            }

            public string ToInvokeString() => $"{typeof(TClient).Name} Connection: {_connection}";

            public Type Type => typeof(TClient);

            public Task SetValueAsync(object value, CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }
    }
}