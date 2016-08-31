// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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

            builder.AppendFormat("TaskId={0}", this.TaskId);
            builder.AppendFormat(", Status={0}", this.Status);
            builder.AppendFormat(", Error.Code={0}", this.Error?.Code);
            builder.AppendFormat(", Error.Message={0}", this.Error?.Message?.Value);
            if (this.Error?.Values != null)
            {
                builder.AppendFormat(", Error.Values=[{0}]", string.Join(", ", this.Error.Values.Select(value => string.Format("{0}={1}", value.Key, value.Value))));
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
