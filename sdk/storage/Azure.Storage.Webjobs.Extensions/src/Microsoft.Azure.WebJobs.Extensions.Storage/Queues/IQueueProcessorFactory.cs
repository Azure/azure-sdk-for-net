// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Queues
{
    /// <summary>
    /// Factory for creating <see cref="QueueProcessor"/> instances.
    /// </summary>
    public interface IQueueProcessorFactory
    {
        /// <summary>
        /// Creates a <see cref="QueueProcessor"/> using the specified context.
        /// </summary>
        /// <param name="context">The <see cref="QueueProcessorFactoryContext"/> to use.</param>
        /// <returns>A <see cref="QueueProcessor"/> instance.</returns>
        QueueProcessor Create(QueueProcessorFactoryContext context);
    }
}
