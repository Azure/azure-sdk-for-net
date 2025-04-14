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
            builder.Append($"{this.GetType()}: ").AppendLine(this.Message);
            builder.AppendLine(this.StackTrace);
            builder.AppendLine();

            for (int i = 0; i < this.InnerExceptions.Count; i++)
            {
                builder.Append($"Exception #{i}:").AppendLine();
                builder.Append(this.InnerExceptions[i]).AppendLine().AppendLine();
            }

            return builder.ToString();
        }
    }
}
