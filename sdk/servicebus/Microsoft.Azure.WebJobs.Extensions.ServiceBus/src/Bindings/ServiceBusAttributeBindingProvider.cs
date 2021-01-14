// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.ServiceBus.Bindings
{
    internal class ServiceBusAttributeBindingProvider : IBindingProvider
    {
        private static readonly IQueueArgumentBindingProvider InnerProvider =
            new CompositeArgumentBindingProvider(
                new MessageSenderArgumentBindingProvider(),
                new MessageArgumentBindingProvider(),
                new StringArgumentBindingProvider(),
                new ByteArrayArgumentBindingProvider(),
                new UserTypeArgumentBindingProvider(),
                new CollectorArgumentBindingProvider(),
                new AsyncCollectorArgumentBindingProvider());

        private readonly INameResolver _nameResolver;
        private readonly ServiceBusOptions _options;
        private readonly IConfiguration _configuration;
        private readonly MessagingProvider _messagingProvider;

        public ServiceBusAttributeBindingProvider(INameResolver nameResolver, ServiceBusOptions options, IConfiguration configuration, MessagingProvider messagingProvider)
        {
            if (nameResolver == null)
            {
                throw new ArgumentNullException(nameof(nameResolver));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            if (messagingProvider == null)
            {
                throw new ArgumentNullException(nameof(messagingProvider));
            }

            _nameResolver = nameResolver;
            _options = options;
            _configuration = configuration;
            _messagingProvider = messagingProvider;
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

            string queueOrTopicName = Resolve(attribute.QueueOrTopicName);
            IBindableServiceBusPath path = BindableServiceBusPath.Create(queueOrTopicName);
            ValidateContractCompatibility(path, context.BindingDataContract);

            IArgumentBinding<ServiceBusEntity> argumentBinding = InnerProvider.TryCreate(parameter);
            if (argumentBinding == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Can't bind ServiceBus to type '{0}'.", parameter.ParameterType));
            }

            attribute.Connection = Resolve(attribute.Connection);
            ServiceBusAccount account = new ServiceBusAccount(_options, _configuration, attribute);

            IBinding binding = new ServiceBusBinding(parameter.Name, argumentBinding, account, path, attribute, _messagingProvider);
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

        private string Resolve(string queueName)
        {
            if (_nameResolver == null)
            {
                return queueName;
            }

            return _nameResolver.ResolveWholeString(queueName);
        }
    }
}
