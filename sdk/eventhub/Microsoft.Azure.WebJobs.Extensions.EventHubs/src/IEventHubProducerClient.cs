// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/16504 is fixed
    internal interface IEventHubProducerClient
    {
        public Task<IEventDataBatch> CreateBatchAsync(CancellationToken cancellationToken);
        public Task<IEventDataBatch> CreateBatchAsync(CreateBatchOptions options, CancellationToken cancellationToken);
        public Task SendAsync(IEventDataBatch batch, CancellationToken cancellationToken);
    }
}