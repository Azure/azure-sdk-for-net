// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.EventHubs
{
    /// <summary>
    /// Configuration options to control the initial offset to use when processing an Event Hub. These options only apply
    /// when no checkpoint information is available.
    /// </summary>
    public class InitialOffsetOptions
    {
        /// <summary>
        /// Gets or sets the type of the initial offset.
        /// <list type="bullet">
        /// <item>
        /// <description>fromStart: The default option if not specified. Will start processing from the start of the stream.</description>
        /// </item>
        /// <item>
        /// <description>fromEnd: Will start processing events from the end of the stream.Use this option if you only want to process events
        /// that are added after the function starts.</description>
        /// </item>
        /// <item>
        /// <description>fromEnqueuedTime: Will process events that were enqueued by Event Hubs on or after the specified time.Note that this applies
        /// to all Event Hubs partitions and there is no support for specifying a per-partition value.</description>
        /// </item>
        /// </list>
        /// </summary>
        public string Type { get; set; } = "";

        /// <summary>
        /// Gets or sets the time that events should be processed after. Any parsable format is accepted.
        /// Only applies when the <see cref="Type"/> is "fromEnqueuedTime".
        /// </summary>
        public string EnqueuedTimeUTC { get; set; } = "";
    }
}