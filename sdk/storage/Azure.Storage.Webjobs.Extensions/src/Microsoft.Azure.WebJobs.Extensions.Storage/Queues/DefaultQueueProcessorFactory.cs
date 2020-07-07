// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// The default <see cref="IQueueProcessorFactory"/> implementation used by <see cref="QueuesOptions"/>.
    /// </summary>
    internal class DefaultQueueProcessorFactory : IQueueProcessorFactory
    {
        /// <inheritdoc/>
        public virtual QueueProcessor Create(QueueProcessorFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            return new QueueProcessor(context);
        }
    }
}
