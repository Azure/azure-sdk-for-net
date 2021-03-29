// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class ServiceBusTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ServiceBusOptions _options;
        private readonly ServiceBusClientFactory _clientFactory;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConverterManager _converterManager;

        public ServiceBusTriggerAttributeBindingProvider(
            INameResolver nameResolver,
            ServiceBusOptions options,
            ServiceBusClientFactory messagingProvider,
            ILoggerFactory loggerFactory,
            IConverterManager converterManager)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _clientFactory = messagingProvider ?? throw new ArgumentNullException(nameof(messagingProvider));
            _loggerFactory = loggerFactory;
            _converterManager = converterManager;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            var attribute = TypeUtility.GetResolvedAttribute<ServiceBusTriggerAttribute>(parameter);

            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            attribute.Connection = _nameResolver.ResolveWholeString(attribute.Connection);
            string entityPath;
            EntityType entityType;
            if (attribute.QueueName != null)
            {
                var queueName = _nameResolver.ResolveWholeString(attribute.QueueName);
                entityPath = queueName;
                entityType = EntityType.Queue;
            }
            else
            {
                var topicName = _nameResolver.ResolveWholeString(attribute.TopicName);
                var subscriptionName = _nameResolver.ResolveWholeString(attribute.SubscriptionName);
                entityPath = EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName);
                entityType = EntityType.Topic;
            }

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
            (factoryContext, singleDispatch) =>
            {
                IListener listener = new ServiceBusListener(factoryContext.Descriptor.Id, entityType, entityPath, attribute.IsSessionsEnabled, factoryContext.Executor, _options, attribute.Connection, _clientFactory, _loggerFactory, singleDispatch);
                return Task.FromResult(listener);
            };

#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new ServiceBusTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618

            return Task.FromResult<ITriggerBinding>(binding);
        }
    }
}
