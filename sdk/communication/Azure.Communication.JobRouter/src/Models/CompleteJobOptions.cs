// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Options for completing a job.
    /// </summary>
    public partial class CompleteJobOptions
    {
        /// <summary> Initializes a new instance of CompleteJobOptions. </summary>
        internal CompleteJobOptions()
        {
        }

        /// <param name="jobId"> Id of a job. </param>
        /// <param name="assignmentId"> Id of a job assignment. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> or <paramref name="assignmentId"/> is an empty string, and was expected to be non-empty. </exception>

        public CompleteJobOptions(string jobId, string assignmentId)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            Argument.AssertNotNullOrEmpty(assignmentId, nameof(assignmentId));

            JobId = jobId;
            AssignmentId = assignmentId;
        }

        /// <summary> Id of a job assignment. </summary>
        public string AssignmentId { get; }

        /// <summary>
        /// Id of a job.
        /// </summary>
        public string JobId { get; }

        /// <summary>
        /// A note that will be appended to a job's notes collection with the current timestamp.
        /// </summary>
        public string Note { get; set; }
    }
}
