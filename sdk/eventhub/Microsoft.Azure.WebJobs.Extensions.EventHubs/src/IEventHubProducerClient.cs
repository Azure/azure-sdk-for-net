// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/16504 is fixed
    internal interface IEventHubProducerClient
    {
        public Task<IEventDataBatch> CreateBatchAsync(CancellationToken cancellationToken);
        public Task SendAsync(IEventDataBatch batch, CancellationToken cancellationToken);
    }
}