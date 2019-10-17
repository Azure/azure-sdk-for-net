// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// Specifies options for listing queues with the
    /// <see cref="QueueServiceClient.GetQueuesAsync"/> operation.
    /// </summary>
    [Flags]
    public enum QueueTraits
    {
        /// <summary>
        /// Flag specifying only the default information for queues
        /// should be included.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the queue's metadata should be
        /// included.
        /// </summary>
        Metadata = 1,
    }

    /// <summary>
    /// QueueTraits enum methods
    /// </summary>
    internal static partial class QueueExtensions
    {
        /// <summary>
        /// Convert the details into a <see cref="ListQueuesIncludeType"/> value.
        /// </summary>
        /// <returns>A <see cref="ListQueuesIncludeType"/> value.</returns>
        internal static IEnumerable<ListQueuesIncludeType> AsIncludeTypes(this QueueTraits traits) =>
            ((traits & QueueTraits.Metadata) == QueueTraits.Metadata)
                ?
                new ListQueuesIncludeType[] { ListQueuesIncludeType.Metadata } :
                Array.Empty<ListQueuesIncludeType>();
    }
}
