// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Linq;
    using System.Text;

    public partial class AddTaskResult
    {
        private readonly CloudTask task;
        private readonly int retryCount;

        internal AddTaskResult(CloudTask task, int retryCount, Protocol.Models.TaskAddResult addTaskResult) : this(addTaskResult)
        {
            this.task = task;
            this.retryCount = retryCount;
        }

        /// <summary>
        /// Gets details of the task.
        /// </summary>
        public CloudTask Task
        {
            get { return this.task; }
        }

        /// <summary>
        /// Gets the number of times the Add Task operation was retried for this task.
        /// </summary>
        public int RetryCount
        {
            get { return this.retryCount; }
        }

        //TODO: Code generate this?
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"TaskId={this.TaskId}");
            builder.Append($", Status={this.Status}");
            builder.Append($", Error.Code={this.Error?.Code}");
            builder.Append($", Error.Message={this.Error?.Message?.Value}");
            if (this.Error?.Values != null)
            {
                builder.AppendFormat(
                    System.Globalization.CultureInfo.CurrentCulture,
                    ", Error.Values=[{0}]", string.Join(", ", this.Error.Values.Select(value => $"{value.Key}={value.Value}")));
            }

            return builder.ToString();
        }
    };
    
    /// <summary>
    /// Used by <see cref="AddTaskCollectionResultHandler"/> to classify an <see cref="AddTaskResult"/> as successful or
    /// requiring a retry.
    /// </summary>
    /// <remarks>AddTaskResultStatus is not used to report non-retryable failure; a result handler should throw
    /// <see cref="AddTaskCollectionTerminatedException"/> for that.</remarks>
    public enum AddTaskResultStatus
    {
        /// <summary>
        /// Classifies the result as a success.
        /// </summary>
        Success,

        /// <summary>
        /// Classifies the result as requiring a retry.
        /// </summary>
        Retry
    }
}
