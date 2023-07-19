// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Queues;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    /// <summary>
    /// The default <see cref="IQueueProcessorFactory"/> implementation used by <see cref="QueuesOptions"/>.
    /// </summary>
    internal class DefaultQueueProcessorFactory : IQueueProcessorFactory
    {
        /// <inheritdoc/>
        public virtual QueueProcessor Create(QueueProcessorOptions context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            return new QueueProcessor(context);
        }
    }
}
