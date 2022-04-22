// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ServiceBusAttributeBindingProvider : IBindingProvider
    {
        private readonly IQueueArgumentBindingProvider _innerProvider;
        private readonly INameResolver _nameResolver;
        private readonly MessagingProvider _messagingProvider;
        private readonly ServiceBusClientFactory _clientFactory;

        public ServiceBusAttributeBindingProvider(
            INameResolver nameResolver,
            MessagingProvider messagingProvider,
            ServiceBusClientFactory clientFactory)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _messagingProvider = messagingProvider ?? throw new ArgumentNullException(nameof(messagingProvider));
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            var jsonSettings = _messagingProvider.Options.JsonSerializerSettings;
            _innerProvider = new CompositeArgumentBindingProvider(
                new MessageSenderArgumentBindingProvider(),
                new MessageArgumentBindingProvider(),
                new StringArgumentBindingProvider(),
                new ByteArrayArgumentBindingProvider(),
                new BinaryDataArgumentBindingProvider(),
                new UserTypeArgumentBindingProvider(jsonSettings),
                new SyncCollectorArgumentBindingProvider(jsonSettings),
                new AsyncCollectorArgumentBindingProvider(jsonSettings));
        }

        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            var attribute = TypeUtility.GetResolvedAttribute<ServiceBusAttribute>(parameter);

            if (attribute == null)
            {
                return Task.FromResult<IBinding>(null);
            }

            string queueOrTopicName = _nameResolver.ResolveWholeString(attribute.QueueOrTopicName);
            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicName);
            ValidateContractCompatibility(path, context.BindingDataContract);

            IArgumentBinding<ServiceBusEntity> argumentBinding = _innerProvider.TryCreate(parameter);
            if (argumentBinding == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Can't bind ServiceBus to type '{0}'.", parameter.ParameterType));
            }

            attribute.Connection = _nameResolver.ResolveWholeString(attribute.Connection);

            IBinding binding = new ServiceBusBinding(parameter.Name, argumentBinding, path, attribute, _messagingProvider, _clientFactory);
            return Task.FromResult<IBinding>(binding);
        }

        private static void ValidateContractCompatibility(IBindableServiceBusPath path, IReadOnlyDictionary<string, Type> bindingDataContract)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            IEnumerable<string> parameterNames = path.ParameterNames;
            if (parameterNames != null)
            {
                foreach (string parameterName in parameterNames)
                {
                    if (bindingDataContract != null && !bindingDataContract.ContainsKey(parameterName))
                    {
                        throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "No binding parameter exists for '{0}'.", parameterName));
                    }
                }
            }
        }
    }
}
