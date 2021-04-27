// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Converters;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class QueueTriggerBinding : ITriggerBinding
    {
        private readonly string _parameterName;
        private readonly QueueServiceClient _queueServiceClient;
        private readonly QueueClient _queue;
        private readonly ITriggerDataArgumentBinding<QueueMessage> _argumentBinding;
        private readonly IReadOnlyDictionary<string, Type> _bindingDataContract;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<QueueTriggerBinding> _logger;
        private readonly IObjectToTypeConverter<QueueMessage> _converter;
        private readonly IQueueProcessorFactory _queueProcessorFactory;
        private readonly QueueCausalityManager _queueCausalityManager;

        public QueueTriggerBinding(string parameterName,
            QueueServiceClient queueServiceClient,
            QueueClient queue,
            ITriggerDataArgumentBinding<QueueMessage> argumentBinding,
            QueuesOptions queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            IQueueProcessorFactory queueProcessorFactory,
            QueueCausalityManager queueCausalityManager)
        {
            _queueServiceClient = queueServiceClient ?? throw new ArgumentNullException(nameof(queueServiceClient));
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _argumentBinding = argumentBinding ?? throw new ArgumentNullException(nameof(argumentBinding));
            _bindingDataContract = CreateBindingDataContract(argumentBinding.BindingDataContract);
            _queueOptions = queueOptions ?? throw new ArgumentNullException(nameof(queueOptions));
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _queueCausalityManager = queueCausalityManager ?? throw new ArgumentNullException(nameof(queueCausalityManager));

            _parameterName = parameterName;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
            _converter = CreateConverter(_queue);
            _logger = loggerFactory.CreateLogger<QueueTriggerBinding>();
        }

        public Type TriggerValueType
        {
            get
            {
                return typeof(QueueMessage);
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
            contract.Add("DequeueCount", typeof(long));
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

        private static IObjectToTypeConverter<QueueMessage> CreateConverter(QueueClient queue)
        {
            return new CompositeObjectToTypeConverter<QueueMessage>(
                new OutputConverter<QueueMessage>(new IdentityConverter<QueueMessage>()),
                new OutputConverter<string>(new StringToStorageQueueMessageConverter(queue)));
        }

        public async Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            QueueMessage message = null;

            if (!_converter.TryConvert(value, out message))
            {
                throw new InvalidOperationException("Unable to convert trigger to IStorageQueueMessage.");
            }

            ITriggerData triggerData = await _argumentBinding.BindAsync(message, context).ConfigureAwait(false);
            IReadOnlyDictionary<string, object> bindingData = CreateBindingData(message, triggerData.BindingData);

            return new TriggerData(triggerData.ValueProvider, bindingData);
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var factory = new QueueListenerFactory(_queueServiceClient, _queue, _queueOptions, _exceptionHandler,
                    _messageEnqueuedWatcherSetter, _loggerFactory, context.Executor, _queueProcessorFactory, _queueCausalityManager, context.Descriptor);

            return factory.CreateAsync(context.CancellationToken);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new QueueTriggerParameterDescriptor
            {
                Name = _parameterName,
                AccountName = _queueServiceClient.AccountName,
                QueueName = _queue.Name
            };
        }

        private IReadOnlyDictionary<string, object> CreateBindingData(QueueMessage value,
            IReadOnlyDictionary<string, object> bindingDataFromValueType)
        {
            Dictionary<string, object> bindingData = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            string queueMessageString = value.TryGetAsString(_logger);

            // Don't provide the QueueTrigger binding data when the queue message is not a valid string.
            if (queueMessageString != null)
            {
                bindingData.Add("QueueTrigger", queueMessageString);
            }

            bindingData.Add("DequeueCount", value.DequeueCount);
            bindingData.Add("ExpirationTime", value.ExpiresOn.GetValueOrDefault(DateTimeOffset.MaxValue));
            bindingData.Add("Id", value.MessageId);
            bindingData.Add("InsertionTime", value.InsertedOn.GetValueOrDefault(DateTimeOffset.UtcNow));
            bindingData.Add("NextVisibleTime", value.NextVisibleOn.GetValueOrDefault(DateTimeOffset.MaxValue));
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
