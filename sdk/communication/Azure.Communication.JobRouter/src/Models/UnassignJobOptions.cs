// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for unassigning a job.
    /// </summary>
    public class UnassignJobOptions
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="jobId"> Id of the job. </param>
        /// <param name="assignmentId"> Id of the assignment. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> is null. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="assignmentId"/> is null. </exception>
        public UnassignJobOptions(string jobId, string assignmentId)
        {
            Argument.AssertNotNullOrWhiteSpace(jobId, nameof(jobId));
            Argument.AssertNotNullOrWhiteSpace(assignmentId, nameof(assignmentId));

            JobId = jobId;
            AssignmentId = assignmentId;
        }

        /// <summary>
        /// Unique key that identifies this job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// Unique key that identifies this job assignment.
        /// </summary>
        public string AssignmentId { get; }
    }
}
