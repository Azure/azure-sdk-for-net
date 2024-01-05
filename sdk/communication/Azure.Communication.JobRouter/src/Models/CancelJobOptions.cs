// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for cancelling a job.
    /// </summary>
    public partial class CancelJobOptions
    {
        /// <summary> Initializes a new instance of CancelJobOptions. </summary>
        internal CancelJobOptions()
        {
        }

        /// <param name="jobId"> Id of a job. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        public CancelJobOptions(string jobId)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));

            JobId = jobId;
        }

        /// <summary>
        /// Id of a job.
        /// </summary>
        public string JobId { get; }

        /// <summary> Indicates the outcome of a job, populate this field with your own custom values. If not provided, default value of "Cancelled" is set. </summary>
        public string DispositionCode { get; set; }

        /// <summary>
        /// A note that will be appended to a job's Notes collection with the current timestamp.
        /// </summary>
        public string Note { get; set; }
    }
}
