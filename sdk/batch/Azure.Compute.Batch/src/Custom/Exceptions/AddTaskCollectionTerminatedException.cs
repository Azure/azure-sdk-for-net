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
    /// An exception thrown when a task collection is terminated due to a non-retryable failure.
    /// </summary>
    public class AddTaskCollectionTerminatedException : BatchException
    {
        /// <summary>
        /// Gets the <see cref="AddTaskResult"/> for the task which caused the exception.
        /// </summary>
        /// <remarks>
        /// More than one task may have failed. In order to see the full list, use an <see cref="TasksWorkflowManager"/>.
        /// </remarks>
        public CreateTaskResult AddTaskResult { get; }

        internal AddTaskCollectionTerminatedException(CreateTaskResult result, Exception inner = null) :
            base(null,GenerateMessageString(result), inner)
        {
            this.AddTaskResult = result;
        }

        private static string GenerateMessageString(CreateTaskResult result)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, BatchErrorCode.AddTaskCollectionTerminated.ToString(), result);
        }
    }
}
