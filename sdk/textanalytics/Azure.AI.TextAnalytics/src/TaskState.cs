// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// TaskState.
    /// </summary>
    [CodeGenModel("TaskState")]
    public partial class TaskState
    {
        /// <summary> Initializes a new instance of TaskState. </summary>
        /// <param name="lastUpdateDateTime"> . </param>
        /// <param name="name"> . </param>
        /// <param name="status"> . </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal TaskState(DateTimeOffset lastUpdateDateTime, string name, JobStatus status)
        {
            LastUpdateDateTime = lastUpdateDateTime;
            Name = name;
            Status = status;
        }

        /// <summary>
        /// Last updated time.
        /// </summary>
        public DateTimeOffset LastUpdateDateTime { get; }

        /// <summary>
        /// Name for the Task.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Status for Task.
        /// </summary>
        public JobStatus Status { get; }
    }
}
