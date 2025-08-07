// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Triggers
{
    internal class QueueTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly IQueueTriggerArgumentBindingProvider _innerProvider;
        private readonly INameResolver _nameResolver;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IQueueProcessorFactory _queueProcessorFactory;
        private readonly QueueCausalityManager _queueCausalityManager;
        private readonly ConcurrencyManager _concurrencyManager;
        private readonly IDrainModeManager _drainModeManager;

        public QueueTriggerAttributeBindingProvider(INameResolver nameResolver,
            QueueServiceClientProvider queueServiceClientProvider,
            IOptions<QueuesOptions> queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            IQueueProcessorFactory queueProcessorFactory,
            QueueCausalityManager queueCausalityManager,
            ConcurrencyManager concurrencyManager,
            IDrainModeManager drainModeManager)
        {
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _queueOptions = (queueOptions ?? throw new ArgumentNullException(nameof(queueOptions))).Value;
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));
            _queueCausalityManager = queueCausalityManager ?? throw new ArgumentNullException(nameof(queueCausalityManager));
            _concurrencyManager = concurrencyManager ?? throw new ArgumentNullException(nameof(concurrencyManager));

            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;

            _innerProvider =
            new CompositeArgumentBindingProvider(
                new ConverterArgumentBindingProvider<QueueMessage>(new CloudQueueMessageDirectConverter(), loggerFactory), // $$$: Is this the best way to handle a direct CloudQueueMessage? TODO (kasobol-msft) is this needed?
                new ConverterArgumentBindingProvider<string>(new StorageQueueMessageToStringConverter(), loggerFactory),
                new ConverterArgumentBindingProvider<byte[]>(new StorageQueueMessageToByteArrayConverter(), loggerFactory),
                new ConverterArgumentBindingProvider<BinaryData>(new StorageQueueMessageToBinaryDataConverter(), loggerFactory),
                new ConverterArgumentBindingProvider<ParameterBindingData>(new StorageQueueMessageToParameterBindingDataConverter(), loggerFactory),
                new UserTypeArgumentBindingProvider(loggerFactory)); // Must come last, because it will attempt to bind all types.
            _drainModeManager = drainModeManager;
        }

        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            ParameterInfo parameter = context.Parameter;
            var queueTrigger = TypeUtility.GetResolvedAttribute<QueueTriggerAttribute>(context.Parameter);

            if (queueTrigger == null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            string queueName = Resolve(queueTrigger.QueueName);
            queueName = NormalizeAndValidate(queueName);

            ITriggerDataArgumentBinding<QueueMessage> argumentBinding = _innerProvider.TryCreate(parameter);

            if (argumentBinding == null)
            {
                throw new InvalidOperationException(
                    "Can't bind QueueTrigger to type '" + parameter.ParameterType + "'.");
            }

            QueueServiceClient client = _queueServiceClientProvider.Get(queueTrigger.Connection, _nameResolver);
            var queue = client.GetQueueClient(queueName);

            ITriggerBinding binding = new QueueTriggerBinding(
                parameter.Name,
                client,
                queue,
                argumentBinding,
                _queueOptions,
                _exceptionHandler,
                _messageEnqueuedWatcherSetter,
                _loggerFactory,
                _queueProcessorFactory,
                _queueCausalityManager,
                _concurrencyManager,
                _drainModeManager);
            return Task.FromResult(binding);
        }

        private static string NormalizeAndValidate(string queueName)
        {
            queueName = queueName.ToLowerInvariant(); // must be lowercase. coerce here to be nice.
            QueueClientExtensions.ValidateQueueName(queueName);
            return queueName;
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
