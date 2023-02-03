// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.WebJobs.EventHubs;

namespace Microsoft.Azure.WebJobs
{
    public static class IAsyncCollectorExtensions
	{
        /// <summary>
        /// Add an event to be published using the provided <paramref name="partitionKey"/> for partition assignment.
        /// </summary>
        /// <param name="instance">The instance of the <see cref="IAsyncCollector{T}"/> that this method was invoked on.</param>
        /// <param name="item">The event to add</param>
        /// <param name="partitionKey">The partition key to use for partition assignment.  If <c>null</c>, round-robin partition assignment will be used.</param>
        /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
        public static Task AddAsync(this IAsyncCollector<EventData> instance, EventData item, string partitionKey, CancellationToken cancellationToken = default(CancellationToken)) =>
            instance switch
            {
                EventHubAsyncCollector ehCollector => ehCollector.AddAsync(item, partitionKey, cancellationToken),
                _ => throw new InvalidOperationException("Adding with a partition key is only available when using the Event Hubs extension package.")
            };
    }
}