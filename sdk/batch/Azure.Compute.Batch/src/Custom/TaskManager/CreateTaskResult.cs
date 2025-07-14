// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Represents the result of adding a task to a Batch job.
    /// </summary>
    public class CreateTaskResult
    {
        private readonly BatchTaskCreateOptions task;
        private readonly int retryCount;
        private readonly BatchTaskCreateResult batchTaskResult;

        internal CreateTaskResult(BatchTaskCreateOptions task, int retryCount, BatchTaskCreateResult addTaskResult)
        {
            this.task = task;
            this.retryCount = retryCount;
            this.batchTaskResult = addTaskResult;
        }

        /// <summary>
        /// Gets details of the task.
        /// </summary>
        public BatchTaskCreateOptions Task
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

        /// <summary>
        /// Gets the result of the Add Task operation.
        /// </summary>
        public BatchTaskCreateResult BatchTaskResult
        {
            get { return this.batchTaskResult; }
        }

        //TODO: Code generate this?
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"TaskId={this.batchTaskResult.TaskId}");
            builder.Append($", Status={this.batchTaskResult.Status}");
            builder.Append($", Error.Code={this.batchTaskResult.Error?.Code}");
            builder.Append($", Error.Message={this.batchTaskResult.Error?.Message?.Value}");
            if (this.batchTaskResult.Error?.Values != null)
            {
                builder.AppendFormat(
                    System.Globalization.CultureInfo.CurrentCulture,
                    ", Error.Values=[{0}]", string.Join(", ", this.batchTaskResult.Error.Values.Select(value => $"{value.Key}={value.Value}")));
            }

            return builder.ToString();
        }
    }
}
