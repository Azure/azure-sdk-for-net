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
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Config;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class ServiceBusTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConverterManager _converterManager;
        private readonly ServiceBusClientFactory _clientFactory;

        public ServiceBusTriggerAttributeBindingProvider(
            INameResolver nameResolver,
            ServiceBusOptions options,
            MessagingProvider messagingProvider,
            ILoggerFactory loggerFactory,
            IConverterManager converterManager,
            ServiceBusClientFactory clientFactory)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messagingProvider = messagingProvider ?? throw new ArgumentNullException(nameof(messagingProvider));
            _loggerFactory = loggerFactory;
            _converterManager = converterManager;
            _clientFactory = clientFactory;
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
            ServiceBusEntityType serviceBusEntityType;
            if (attribute.QueueName != null)
            {
                var queueName = _nameResolver.ResolveWholeString(attribute.QueueName);
                entityPath = queueName;
                serviceBusEntityType = ServiceBusEntityType.Queue;
            }
            else
            {
                var topicName = _nameResolver.ResolveWholeString(attribute.TopicName);
                var subscriptionName = _nameResolver.ResolveWholeString(attribute.SubscriptionName);
                entityPath = EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName);
                serviceBusEntityType = ServiceBusEntityType.Topic;
            }

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
            (factoryContext, singleDispatch) =>
            {
                IListener listener = new ServiceBusListener(factoryContext.Descriptor.Id, serviceBusEntityType, entityPath, attribute.IsSessionsEnabled, factoryContext.Executor, _options, attribute.Connection, _messagingProvider, _loggerFactory, singleDispatch, _clientFactory);
                return Task.FromResult(listener);
            };

#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new ServiceBusTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618

            return Task.FromResult<ITriggerBinding>(binding);
        }
    }
}
