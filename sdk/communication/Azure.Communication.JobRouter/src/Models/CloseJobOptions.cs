// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for closing a job.
    /// </summary>
    public class CloseJobOptions
    {
        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string? DispositionCode { get; set; }

        /// <summary>
        /// If provided, the future time at which to release the capacity. If not provided capacity will be released immediately.
        /// </summary>
        public DateTimeOffset? CloseTime { get; set; }

        /// <summary>
        /// Custom supplied note.
        /// </summary>
        public string? Note { get; set; }
    }
}
