// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
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
        private readonly ILogger<QueueServiceClient> _logger;
        private readonly IQueueProcessorFactory _queueProcessorFactory;
        private readonly SharedQueueWatcher _messageEnqueuedWatcher;
        private readonly IConfiguration _configuration;
        private readonly AzureComponentFactory _componentFactory;
        private readonly AzureEventSourceLogForwarder _logForwarder;
        private QueueServiceClientProvider _rawProvider;

        public QueueServiceClientProvider(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            AzureEventSourceLogForwarder logForwarder,
            IOptions<QueuesOptions> queueOptions,
            ILoggerFactory loggerFactory,
            ILogger<QueueServiceClient> logger,
            IQueueProcessorFactory queueProcessorFactory,
            SharedQueueWatcher messageEnqueuedWatcher)
            : base(configuration, componentFactory, logForwarder, logger)
        {
            _queuesOptions = queueOptions?.Value;
            _loggerFactory = loggerFactory;
            _logger = logger;
            _queueProcessorFactory = queueProcessorFactory;
            _messageEnqueuedWatcher = messageEnqueuedWatcher;
            _configuration = configuration;
            _componentFactory = componentFactory;
            _logForwarder = logForwarder;
        }

        /// <summary>
        /// Gets a client that reads messages without decoding them, so results are never filtered by
        /// decode failures. Intended for scale metrics only - it must not be used to process messages,
        /// because it does not decode message bodies.
        /// </summary>
        /// <param name="name">Name of the connection to use.</param>
        /// <param name="resolver">A resolver to interpret the provided connection <paramref name="name"/>.</param>
        public virtual QueueServiceClient GetRaw(string name, INameResolver resolver)
        {
            // Delegating to Get keeps the raw client identical to the configured one apart from the
            // encoding. The delegate's own GetRaw is never called, so this does not recurse.
            _rawProvider ??= new QueueServiceClientProvider(
                _configuration,
                _componentFactory,
                _logForwarder,
                Options.Create(CreateRawOptions()),
                _loggerFactory,
                _logger,
                _queueProcessorFactory,
                _messageEnqueuedWatcher);

            return _rawProvider.Get(name, resolver);
        }

        /// <summary>
        /// Copies the configured options, overriding only the encoding, so the raw path cannot drift
        /// from the message-processing path.
        /// </summary>
        protected virtual QueuesOptions CreateRawOptions()
        {
            QueuesOptions options = _queuesOptions.Clone();

            options.MessageEncoding = QueueMessageEncoding.None;
            return options;
        }

        /// <inheritdoc/>
        protected override string ServiceUriSubDomain
        {
            get
            {
                return "queue";
            }
        }

        /// <inheritdoc/>
        protected override QueueClientOptions CreateClientOptions(IConfiguration configuration)
        {
            var options = base.CreateClientOptions(configuration);

            options.MessageEncoding = _queuesOptions.MessageEncoding;
            return options;
        }

        /// <inheritdoc/>
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
                    var receivedMessage = args.ReceivedMessage;
                    var queueClient = args.Queue;
                    _logger.LogWarning("Message decoding has failed! Check MessageEncoding settings. MessageId={messageId}.", receivedMessage.MessageId);
                    var poisonQueueClient = QueueListenerFactory.CreatePoisonQueueReference(nonEncodingQueueServiceClient, queueClient.Name);
                    var queueProcessor = QueueListenerFactory.CreateQueueProcessor(queueClient, poisonQueueClient, _loggerFactory, _queueProcessorFactory, _queuesOptions, _messageEnqueuedWatcher);
                    await queueProcessor.HandlePoisonMessageAsync(receivedMessage, args.CancellationToken).ConfigureAwait(false);
                }
            };
        }
    }
}
