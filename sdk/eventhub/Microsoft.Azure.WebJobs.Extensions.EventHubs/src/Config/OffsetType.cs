// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// The types of offsets that can be configured in the <see cref="InitialOffsetOptions"/>.
    /// </summary>
    public enum OffsetType
    {
        /// <summary>
        /// The default option if not specified. Will start processing from the start of the stream.
        /// </summary>
        FromStart = 0,

        /// <summary>
        /// Will start processing events from the end of the stream. Use this option if you only want to process events
        /// that are added after the function starts.
        /// </summary>
        FromEnd = 1,

        /// <summary>
        /// Will process events that were enqueued by Event Hubs on or after the specified time.Note that this applies
        /// to all Event Hubs partitions and there is no support for specifying a per-partition value.
        /// </summary>
        FromEnqueuedTime = 2
    }
}
