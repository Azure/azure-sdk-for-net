// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Azure.WebJobs.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    internal class EventHubTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly ILogger _logger;
        private readonly IOptions<EventHubOptions> _options;
        private readonly EventHubClientFactory _clientFactory;
        private readonly IConverterManager _converterManager;

        public EventHubTriggerAttributeBindingProvider(
            IConverterManager converterManager,
            IOptions<EventHubOptions> options,
            ILoggerFactory loggerFactory,
            EventHubClientFactory clientFactory)
        {
            _converterManager = converterManager;
            _options = options;
            _clientFactory = clientFactory;
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

            Func<ListenerFactoryContext, bool, Task<IListener>> createListener =
             (factoryContext, singleDispatch) =>
             {
                 var options = _options.Value;
                 if (singleDispatch && !options.IsSingleDispatchEnabled)
                 {
                     throw new NotSupportedException("Binding to individual events is not supported. Please use batch processing by binding to an array instead.");
                 }

                 var checkpointStore = new BlobsCheckpointStore(
                     _clientFactory.GetCheckpointStoreClient(),
                     options.EventProcessorOptions.RetryOptions.ToRetryPolicy(),
                     factoryContext.Descriptor.Id,
                     _logger);

                 IListener listener = new EventHubListener(
                                                factoryContext.Descriptor.Id,
                                                factoryContext.Executor,
                                                _clientFactory.GetEventProcessorHost(attribute.EventHubName, attribute.Connection, attribute.ConsumerGroup),
                                                singleDispatch,
                                                _clientFactory.GetEventHubConsumerClient(attribute.EventHubName, attribute.Connection, attribute.ConsumerGroup),
                                                checkpointStore,
                                                options,
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
