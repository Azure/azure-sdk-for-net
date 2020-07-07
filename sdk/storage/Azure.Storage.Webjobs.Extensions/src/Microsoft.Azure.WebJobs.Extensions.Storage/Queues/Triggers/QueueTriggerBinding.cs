// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Converters;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Storage.Queue;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class QueueTriggerBinding : ITriggerBinding
    {
        private readonly string _parameterName;
        private readonly CloudQueue _queue;
        private readonly ITriggerDataArgumentBinding<CloudQueueMessage> _argumentBinding;
        private readonly IReadOnlyDictionary<string, Type> _bindingDataContract;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IObjectToTypeConverter<CloudQueueMessage> _converter;
        private readonly IQueueProcessorFactory _queueProcessorFactory;

        public QueueTriggerBinding(string parameterName,
            CloudQueue queue,
            ITriggerDataArgumentBinding<CloudQueueMessage> argumentBinding,
            QueuesOptions queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            IQueueProcessorFactory queueProcessorFactory)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _argumentBinding = argumentBinding ?? throw new ArgumentNullException(nameof(argumentBinding));
            _bindingDataContract = CreateBindingDataContract(argumentBinding.BindingDataContract);
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));

            _parameterName = parameterName;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
            _converter = CreateConverter(queue);
        }

        public Type TriggerValueType
        {
            get
            {
                return typeof(CloudQueueMessage);
            }
        }

        public IReadOnlyDictionary<string, Type> BindingDataContract
        {
            get { return _bindingDataContract; }
        }

        public string QueueName
        {
            get { return _queue.Name; }
        }

        private static IReadOnlyDictionary<string, Type> CreateBindingDataContract(IReadOnlyDictionary<string, Type> argumentBindingContract)
        {
            Dictionary<string, Type> contract = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
            contract.Add("QueueTrigger", typeof(string));
            contract.Add("DequeueCount", typeof(int));
            contract.Add("ExpirationTime", typeof(DateTimeOffset));
            contract.Add("Id", typeof(string));
            contract.Add("InsertionTime", typeof(DateTimeOffset));
            contract.Add("NextVisibleTime", typeof(DateTimeOffset));
            contract.Add("PopReceipt", typeof(string));

            if (argumentBindingContract != null)
            {
                foreach (KeyValuePair<string, Type> item in argumentBindingContract)
                {
                    // In case of conflict, binding data from the value type overrides the built-in binding data above.
                    contract[item.Key] = item.Value;
                }
            }

            return contract;
        }

        private static IObjectToTypeConverter<CloudQueueMessage> CreateConverter(CloudQueue queue)
        {
            return new CompositeObjectToTypeConverter<CloudQueueMessage>(
                new OutputConverter<CloudQueueMessage>(new IdentityConverter<CloudQueueMessage>()),
                new OutputConverter<string>(new StringToStorageQueueMessageConverter(queue)));
        }

        public async Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            CloudQueueMessage message = null;

            if (!_converter.TryConvert(value, out message))
            {
                throw new InvalidOperationException("Unable to convert trigger to IStorageQueueMessage.");
            }

            ITriggerData triggerData = await _argumentBinding.BindAsync(message, context);
            IReadOnlyDictionary<string, object> bindingData = CreateBindingData(message, triggerData.BindingData);

            return new TriggerData(triggerData.ValueProvider, bindingData);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var factory = new QueueListenerFactory(_queue, _queueOptions, _exceptionHandler,
                    _messageEnqueuedWatcherSetter, _loggerFactory, context.Executor, _queueProcessorFactory, context.Descriptor);

            return factory.CreateAsync(context.CancellationToken);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new QueueTriggerParameterDescriptor
            {
                Name = _parameterName,
                AccountName = _queue.ServiceClient.GetAccountName(),
                QueueName = _queue.Name
            };
        }

        private static IReadOnlyDictionary<string, object> CreateBindingData(CloudQueueMessage value,
            IReadOnlyDictionary<string, object> bindingDataFromValueType)
        {
            Dictionary<string, object> bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            string queueMessageString = value.TryGetAsString();

            // Don't provide the QueueTrigger binding data when the queue message is not a valid string.
            if (queueMessageString != null)
            {
                bindingData.Add("QueueTrigger", queueMessageString);
            }

            bindingData.Add("DequeueCount", value.DequeueCount);
            bindingData.Add("ExpirationTime", value.ExpirationTime.GetValueOrDefault(DateTimeOffset.MaxValue));
            bindingData.Add("Id", value.Id);
            bindingData.Add("InsertionTime", value.InsertionTime.GetValueOrDefault(DateTimeOffset.UtcNow));
            bindingData.Add("NextVisibleTime", value.NextVisibleTime.GetValueOrDefault(DateTimeOffset.MaxValue));
            bindingData.Add("PopReceipt", value.PopReceipt);

            if (bindingDataFromValueType != null)
            {
                foreach (KeyValuePair<string, object> item in bindingDataFromValueType)
                {
                    // In case of conflict, binding data from the value type overrides the built-in binding data above.
                    bindingData[item.Key] = item.Value;
                }
            }

            return bindingData;
        }
    }
}
