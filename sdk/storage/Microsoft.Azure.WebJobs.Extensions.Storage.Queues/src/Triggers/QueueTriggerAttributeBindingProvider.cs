// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Azure.WebJobs.Host.Triggers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Triggers;
using Azure.WebJobs.Extensions.Storage.Queues;

namespace Microsoft.Azure.WebJobs.Host.Queues.Triggers
{
    internal class QueueTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private static readonly IQueueTriggerArgumentBindingProvider InnerProvider =
            new CompositeArgumentBindingProvider(
                new ConverterArgumentBindingProvider<QueueMessage>(new CloudQueueMessageDirectConverter()), // $$$: Is this the best way to handle a direct CloudQueueMessage? TODO (kasobol-msft) is this needed?
                new ConverterArgumentBindingProvider<string>(new StorageQueueMessageToStringConverter()),
                new ConverterArgumentBindingProvider<byte[]>(new StorageQueueMessageToByteArrayConverter()),
                new UserTypeArgumentBindingProvider()); // Must come last, because it will attempt to bind all types.

        private readonly INameResolver _nameResolver;
        private readonly QueueServiceClientProvider _queueServiceClientProvider;
        private readonly QueuesOptions _queueOptions;
        private readonly IWebJobsExceptionHandler _exceptionHandler;
        private readonly SharedQueueWatcher _messageEnqueuedWatcherSetter;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IQueueProcessorFactory _queueProcessorFactory;

        public QueueTriggerAttributeBindingProvider(INameResolver nameResolver,
            QueueServiceClientProvider queueServiceClientProvider,
            IOptions<QueuesOptions> queueOptions,
            IWebJobsExceptionHandler exceptionHandler,
            SharedQueueWatcher messageEnqueuedWatcherSetter,
            ILoggerFactory loggerFactory,
            IQueueProcessorFactory queueProcessorFactory)
        {
            _queueServiceClientProvider = queueServiceClientProvider ?? throw new ArgumentNullException(nameof(queueServiceClientProvider));
            _queueOptions = (queueOptions ?? throw new ArgumentNullException(nameof(queueOptions))).Value;
            _exceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            _messageEnqueuedWatcherSetter = messageEnqueuedWatcherSetter ?? throw new ArgumentNullException(nameof(messageEnqueuedWatcherSetter));

            _nameResolver = nameResolver;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
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

            ITriggerDataArgumentBinding<QueueMessage> argumentBinding = InnerProvider.TryCreate(parameter);

            if (argumentBinding == null)
            {
                throw new InvalidOperationException(
                    "Can't bind QueueTrigger to type '" + parameter.ParameterType + "'.");
            }

            QueueServiceClient client = _queueServiceClientProvider.Get(queueTrigger.Connection, _nameResolver);
            var queue = client.GetQueueClient(queueName);

            ITriggerBinding binding = new QueueTriggerBinding(parameter.Name, client, queue, argumentBinding,
                _queueOptions, _exceptionHandler, _messageEnqueuedWatcherSetter,
                _loggerFactory, _queueProcessorFactory);
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
