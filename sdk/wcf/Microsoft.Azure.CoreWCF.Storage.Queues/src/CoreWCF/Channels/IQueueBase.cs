// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using System;
using System.Threading.Tasks;

namespace Azure.Storage.CoreWCF.Channels
{
    internal interface IQueueBase
    {
        public QueueClient queueClient { get; set; }

        //Task Send(PipeReader message, Uri endpoint);

        public Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage>> ReceiveMessageAsync(TimeSpan? visibilityTimeout = default, System.Threading.CancellationToken cancellationToken = default);

        public Task<Azure.Response> DeleteMessageAsync(string messageId, string popReceipt, System.Threading.CancellationToken cancellationToken = default);
    }
}
