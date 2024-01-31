// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.EventHubs
{
    internal class EventHubTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IOptions<EventHubOptions> _options;
        private readonly EventHubClientFactory _clientFactory;
        private readonly IConverterManager _converterManager;
        private readonly IDrainModeManager _drainModeManager;

        public EventHubTriggerAttributeBindingProvider(
            IConverterManager converterManager,
            IOptions<EventHubOptions> options,
            ILoggerFactory loggerFactory,
            EventHubClientFactory clientFactory,
            IDrainModeManager drainModeManager)
        {
            _converterManager = converterManager;
            _options = options;
            _clientFactory = clientFactory;
            _loggerFactory = loggerFactory;
            _drainModeManager = drainModeManager;
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
                 var checkpointStore = new BlobCheckpointStoreInternal(
                     _clientFactory.GetCheckpointStoreClient(),
                     factoryContext.Descriptor.Id,
                     _loggerFactory.CreateLogger<BlobCheckpointStoreInternal>());

                 IListener listener = new EventHubListener(
                                                factoryContext.Descriptor.Id,
                                                factoryContext.Executor,
                                                _clientFactory.GetEventProcessorHost(attribute.EventHubName, attribute.Connection, attribute.ConsumerGroup, singleDispatch),
                                                singleDispatch,
                                                _clientFactory.GetEventHubConsumerClient(attribute.EventHubName, attribute.Connection, attribute.ConsumerGroup),
                                                checkpointStore,
                                                options,
                                                _loggerFactory,
                                                _drainModeManager);
                 return Task.FromResult(listener);
             };
#pragma warning disable 618
            ITriggerBinding binding = BindingFactory.GetTriggerBinding(new EventHubTriggerBindingStrategy(), parameter, _converterManager, createListener);
#pragma warning restore 618
            ITriggerBinding eventHubTriggerBindingWrapper = new EventHubTriggerBindingWrapper(binding);
            return Task.FromResult(eventHubTriggerBindingWrapper);
        }
    } // end class
}
