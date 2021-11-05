// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Messaging.EventHubs;

namespace Microsoft.Azure.WebJobs
{
    /// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/9117 is fixed
    internal interface IEventDataBatch
    {
        int Count { get; }
        long MaximumSizeInBytes { get; }
        bool TryAdd(EventData eventData);
    }
}