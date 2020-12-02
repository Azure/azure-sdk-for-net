// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    internal class EventHubTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly INameResolver _nameResolver;
        private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly IOptions<EventHubOptions> _options;
        private readonly IConverterManager _converterManager;

        public EventHubTriggerAttributeBindingProvider(
            IConfiguration configuration,
            INameResolver nameResolver,
            IConverterManager converterManager,
            IOptions<EventHubOptions> options,
            ILoggerFactory loggerFactory)
        {
            _config = configuration;
            _nameResolver = nameResolver;
            _converterManager = converterManager;
            _options = options;
            _logger = loggerFactory?.CreateLogger(LogCategories.CreateTriggerCategory("EventHub"));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;
            EventHubTriggerAttribute attribute = parameter.GetCustomAttribute<EventHubTriggerAttribute>(inherit: false);

            if (attribute == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            string resolvedEventHubName = _nameResolver.ResolveWholeString(attribute.EventHubName);

            string consumerGroup = attribute.ConsumerGroup ?? EventHubConsumerClient.DefaultConsumerGroupName;
            string resolvedConsumerGroup = _nameResolver.ResolveWholeString(consumerGroup);

            if (!string.IsNullOrWhiteSpace(attribute.Connection))
            {
                var connection = _nameResolver.ResolveWholeString(attribute.Connection);
                var connectionString = _config.GetConnectionStringOrSetting(connection);
                _options.Value.AddReceiver(resolvedEventHubName, connectionString);
            }

            var eventHostListener = _options.Value.GetEventProcessorHost(resolvedEventHubName, resolvedConsumerGroup);
            var checkpointStoreConnectionString = _options.Value.GetCheckpointStoreConnectionString(_config, resolvedEventHubName);

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
             (factoryContext, singleDispatch) =>
             {
                 var checkpointStore = new BlobsCheckpointStore(
                     new BlobContainerClient(checkpointStoreConnectionString, _options.Value.LeaseContainerName),
                     _options.Value.EventProcessorOptions.RetryOptions.ToRetryPolicy(),
                     factoryContext.Descriptor.Id,
                     _logger);

                 IListener listener = new EventHubListener(
                                                factoryContext.Descriptor.Id,
                                                factoryContext.Executor,
                                                eventHostListener,
                                                singleDispatch,
                                                () => _options.Value.GetEventHubConsumerClient(resolvedEventHubName, consumerGroup),
                                                checkpointStore,
                                                _options.Value,
                                                _logger);
                 return Task.FromResult(listener);
             };

#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new EventHubTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618
            return Task.FromResult(binding);
        }
    } // end class
}