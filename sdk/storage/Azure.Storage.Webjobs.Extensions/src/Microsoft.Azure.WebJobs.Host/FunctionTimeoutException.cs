// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Exception thrown when a job function invocation fails due to a timeout.
    /// </summary>
    [Serializable]
    public class FunctionTimeoutException : FunctionInvocationException
    {
        /// <inheritdoc/>
        public FunctionTimeoutException() : base()
        {
        }

        /// <inheritdoc/>
        public FunctionTimeoutException(string message) : base(message)
        {
        }

        /// <inheritdoc/>
        public FunctionTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc/>
        protected FunctionTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="instanceId">The function instance Id.</param>
        /// <param name="methodName">The fully qualified method name.</param>
        /// <param name="timeout">The configured timeout value.</param>
        /// <param name="task">The function Task.</param>
        /// <param name="innerException">The exception that is the cause of the current exception (or null).</param>
        public FunctionTimeoutException(string message, Guid instanceId, string methodName, TimeSpan timeout, Task task, Exception innerException)
            : base(message, instanceId, methodName, innerException)
        {
            Timeout = timeout;
            Task = task;
        }

        /// <summary>
        /// The function timeout value that expired.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        /// <summary>
        /// The task that did not complete due to a timeout.
        /// </summary>
        public Task Task { get; set; }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Timeout", this.Timeout);

            base.GetObjectData(info, context);
        }
    }
}
