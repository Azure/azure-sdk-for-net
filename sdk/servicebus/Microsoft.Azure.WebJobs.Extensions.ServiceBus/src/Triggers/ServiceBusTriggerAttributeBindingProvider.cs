// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus.Listeners;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.ServiceBus.Triggers
{
    internal class ServiceBusTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ServiceBusOptions _options;
        private readonly MessagingProvider _messagingProvider;
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConverterManager _converterManager;

        public ServiceBusTriggerAttributeBindingProvider(INameResolver nameResolver, ServiceBusOptions options, MessagingProvider messagingProvider, IConfiguration configuration,
            ILoggerFactory loggerFactory, IConverterManager converterManager)
        {
            _nameResolver = nameResolver ?? throw new ArgumentNullException(nameof(nameResolver));
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _messagingProvider = messagingProvider ?? throw new ArgumentNullException(nameof(messagingProvider));
            _configuration = configuration;
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

            string queueName = null;
            string topicName = null;
            string subscriptionName = null;
            string entityPath = null;
            EntityType entityType;

            if (attribute.QueueName != null)
            {
                queueName = Resolve(attribute.QueueName);
                entityPath = queueName;
                entityType = EntityType.Queue;
            }
            else
            {
                topicName = Resolve(attribute.TopicName);
                subscriptionName = Resolve(attribute.SubscriptionName);
                entityPath = EntityNameHelper.FormatSubscriptionPath(topicName, subscriptionName);
                entityType = EntityType.Topic;
            }

            attribute.Connection = Resolve(attribute.Connection);
            ServiceBusAccount account = new ServiceBusAccount(_options, _configuration, attribute);

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
            (factoryContext, singleDispatch) =>
            {
                IListener listener = new ServiceBusListener(factoryContext.Descriptor.Id, entityType, entityPath, attribute.IsSessionsEnabled, factoryContext.Executor, _options, account, _messagingProvider, _loggerFactory, singleDispatch);
                return Task.FromResult(listener);
            };

#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new ServiceBusTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618

            return Task.FromResult<ITriggerBinding>(binding);
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
