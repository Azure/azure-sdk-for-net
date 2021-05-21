// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class QueueServiceClientProvider : StorageClientProvider<QueueServiceClient, QueueClientOptions>
    {
        private readonly QueuesOptions _queuesOptions;
        private readonly ILogger<QueueServiceClient> _logger;

        public QueueServiceClientProvider(
            IConfiguration configuration,
            AzureComponentFactory componentFactory,
            AzureEventSourceLogForwarder logForwarder,
            IOptions<QueuesOptions> queueOptions,
            ILogger<QueueServiceClient> logger)
            : base(configuration, componentFactory, logForwarder, logger)
        {
            _queuesOptions = queueOptions?.Value;
            _logger = logger;
        }

        /// <inheritdoc/>
        protected override string ServiceUriSubDomain
        {
            get
            {
                return "queue";
            }
        }

        protected override QueueClientOptions CreateClientOptions(IConfiguration configuration)
        {
            var options = base.CreateClientOptions(configuration);
            options.MessageEncoding = _queuesOptions.MessageEncoding;
            options.MessageDecodingFailed += HandleMessageDecodingFailed;
            return options;
        }

        private async Task HandleMessageDecodingFailed(QueueMessageDecodingFailedEventArgs args)
        {
            // SharedBlobQueueProcessor moves to poison queue only if message is parsable and has corresponding registration.
            // Therefore, we log and discard garbage here.
            if (args.ReceivedMessage != null)
            {
                _logger.LogWarning("Invalid message in blob trigger queue {QueueName}, messageId={messageId}, body={body}",
                    args.Queue.Name, args.ReceivedMessage.MessageId, args.ReceivedMessage.Body.ToString());
                await args.Queue.DeleteMessageAsync(args.ReceivedMessage.MessageId, args.ReceivedMessage.PopReceipt).ConfigureAwait(false);
            }
        }
    }
}
