// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO.Pipelines;
using System.Threading.Tasks;
using System;
using Azure.Storage.Queues;

namespace Azure.Storage.CoreWCF.Channels
{
    internal interface IQueueBase
    {
        public QueueClient queueClient { get; set; }

        //Task Send(PipeReader message, Uri endpoint);

        public Task<Azure.Response<Azure.Storage.Queues.Models.QueueMessage>> ReceiveMessageAsync(TimeSpan? visibilityTimeout = default, System.Threading.CancellationToken cancellationToken = default);

        public Azure.Response DeleteMessage(string messageId, string popReceipt, System.Threading.CancellationToken cancellationToken = default);
    }
}
