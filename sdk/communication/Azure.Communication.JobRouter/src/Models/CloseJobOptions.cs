// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for closing a job.
    /// </summary>
    public class CloseJobOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="assignmentId"> The id used to assign the job to a worker. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        public CloseJobOptions(string jobId, string assignmentId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));

            JobId = jobId;
            AssignmentId = assignmentId;
        }

        /// <summary>
        /// Id of the job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// The id used to assign the job to a worker.
        /// </summary>
        public string AssignmentId { get; }

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
