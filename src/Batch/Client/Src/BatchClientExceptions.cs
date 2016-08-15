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
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Azure.Batch.Common;

    /// <summary>
    /// An exception thrown by the Batch client.
    /// </summary>
    public class BatchClientException : BatchException
    {
        internal BatchClientException(string message = null, Exception inner = null) : base(null, message, inner)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when the AddTaskCollection operation is terminated.
    /// </summary>
    public class AddTaskCollectionTerminatedException : BatchClientException
    {
        /// <summary>
        /// Gets the <see cref="AddTaskResult"/> for the task which caused the exception.
        /// </summary>
        /// <remarks>
        /// More than one task may have failed. In order to see the full list, use an <see cref="AddTaskCollectionResultHandler"/>.
        /// </remarks>
        public AddTaskResult AddTaskResult { get; }

        internal AddTaskCollectionTerminatedException(AddTaskResult result, Exception inner = null) :
            base(GenerateMessageString(result), inner)
        {
            this.AddTaskResult = result;
        }

        private static string GenerateMessageString(AddTaskResult result)
        {
            return string.Format(BatchErrorMessages.AddTaskCollectionTerminated, result);
        }
    }

    /// <summary>
    /// An exception raised when one or more operations in a parallel set of operations fails.  
    /// The <see cref="AggregateException.InnerExceptions"/> collection contains the exceptions for each of the failed operations.
    /// </summary>
    public class ParallelOperationsException : AggregateException
    {
        internal ParallelOperationsException(IEnumerable<Exception> innerExceptions) : base(innerExceptions)
        {
        }

        internal ParallelOperationsException(string message, IEnumerable<Exception> innerExceptions) : base(message, innerExceptions)
        {
        }

        /// <summary>
        /// Creates and returns a string representation of the current <see cref="ParallelOperationsException"/>.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}: ", this.GetType()).AppendLine(this.Message);
            builder.AppendLine(this.StackTrace);
            builder.AppendLine();

            for (int i = 0; i < this.InnerExceptions.Count; i++)
            {
                builder.AppendFormat("Exception #{0}:", i).AppendLine();
                builder.Append(this.InnerExceptions[i]).AppendLine().AppendLine();
            }

            return builder.ToString();
        }
    }

    internal class RunOnceException : BatchException
    {
        internal RunOnceException(string message = null, Exception inner = null)
            : base(null, message, inner)
        {

        }
    }
}
