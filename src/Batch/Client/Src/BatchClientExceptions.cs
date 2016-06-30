namespace Microsoft.Azure.Batch
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
        internal AddTaskCollectionTerminatedException(string message = null, Exception inner = null) : base(message, inner)
        {
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
