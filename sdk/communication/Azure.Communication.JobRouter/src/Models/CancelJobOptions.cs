// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for cancelling a job.
    /// </summary>
    public class CancelJobOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        public CancelJobOptions(string jobId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));

            JobId = jobId;
        }

        /// <summary>
        /// Id of the job.
        /// </summary>
        public string JobId { get; }

        /// <summary> Reason code for cancelled or closed jobs. </summary>
        public string DispositionCode { get; set; }

        /// <summary>
        /// Custom supplied note, e.g., cancellation reason.
        /// </summary>
        public string Note { get; set; }
    }
}
