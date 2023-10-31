// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for cancelling a job.
    /// </summary>
    public partial class CancelJobOptions
    {
        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string DispositionCode { get; set; }

        /// <summary>
        /// Custom supplied note, e.g., cancellation reason.
        /// </summary>
        public string Note { get; set; }
    }
}
