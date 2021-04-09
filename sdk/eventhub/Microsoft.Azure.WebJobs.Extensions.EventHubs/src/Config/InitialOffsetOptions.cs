// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

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
        /// </summary>
        public OffsetType? Type { get; set; }

        /// <summary>
        /// Gets or sets the time that events should be processed after. Any parsable format is accepted.
        /// Only applies when the <see cref="Type"/> is <see cref="OffsetType.FromEnqueuedTime"/>.
        /// </summary>
        public DateTimeOffset? EnqueuedTimeUtc { get; set; }
    }
}