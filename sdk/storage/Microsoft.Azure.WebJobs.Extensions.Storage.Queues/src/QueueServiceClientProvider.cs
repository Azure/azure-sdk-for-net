// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    internal class QueueServiceClientProvider : StorageClientProvider<QueueServiceClient, QueueClientOptions>
    {
        private readonly QueuesOptions _queuesOptions;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IQueueProcessorFactory _queueProcessorFactory;
        private readonly SharedQueueWatcher _messageEnqueuedWatcher;

        public QueueServiceClientProvider(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            AzureEventSourceLogForwarder logForwarder,
            IOptions<QueuesOptions> queueOptions,
            ILoggerFactory loggerFactory,
            IQueueProcessorFactory queueProcessorFactory,
            SharedQueueWatcher messageEnqueuedWatcher)
            : base(configuration, componentFactory, logForwarder)
        {
            _queuesOptions = queueOptions?.Value;
            _loggerFactory = loggerFactory;
            _queueProcessorFactory = queueProcessorFactory;
            _messageEnqueuedWatcher = messageEnqueuedWatcher;
        }

        protected override QueueClientOptions CreateClientOptions(IConfiguration configuration)
        {
            var options = base.CreateClientOptions(configuration);

            options.MessageEncoding = _queuesOptions.MessageEncoding;
            return options;
        }

        protected override QueueServiceClient CreateClient(IConfiguration configuration, TokenCredential tokenCredential, QueueClientOptions options)
        {
            var originalEncoding = options.MessageEncoding;
            options.MessageEncoding = QueueMessageEncoding.None;
            var nonEncodingClient = base.CreateClient(configuration, tokenCredential, options);
            options.MessageDecodingFailed += CreateMessageDecodingFailedHandler(nonEncodingClient);
            options.MessageEncoding = originalEncoding;

            return base.CreateClient(configuration, tokenCredential, options);
        }

        private SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs> CreateMessageDecodingFailedHandler(QueueServiceClient nonEncodingQueueServiceClient)
        {
            return async (QueueMessageDecodingFailedEventArgs args) =>
            {
                // This event is raised only in async paths hence args.IsRunningSynchronously is ignored.
                if (args.ReceivedMessage != null)
                {
                    var queueClient = args.Queue;
                    var poisonQueueClient = QueueListenerFactory.CreatePoisonQueueReference(nonEncodingQueueServiceClient, queueClient.Name);
                    var queueProcessor = QueueListenerFactory.CreateQueueProcessor(queueClient, poisonQueueClient, _loggerFactory, _queueProcessorFactory, _queuesOptions, _messageEnqueuedWatcher);
                    await queueProcessor.HandlePoisonMessageAsync(args.ReceivedMessage, args.CancellationToken).ConfigureAwait(false);
                }
            };
        }
    }
}
