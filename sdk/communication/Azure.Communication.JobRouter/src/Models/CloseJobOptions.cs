// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for closing a job.
    /// </summary>
    public partial class CloseJobOptions
    {
        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string DispositionCode { get; set; }

        /// <summary>
        /// If not provided, worker capacity is released immediately along with a JobClosedEvent notification.
        /// If provided, worker capacity is released along with a JobClosedEvent notification at a future time in UTC.
        /// </summary>
        public DateTimeOffset CloseAt { get; set; }

        /// <summary>
        /// Custom supplied note.
        /// </summary>
        public string Note { get; set; }
    }
}
