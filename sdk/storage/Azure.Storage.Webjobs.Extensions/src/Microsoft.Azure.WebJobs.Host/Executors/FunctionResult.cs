// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    /// <summary>
    /// Represents the result of a job function invocation.
    /// </summary>
    [DebuggerDisplay("Succeeded = {Succeeded}")]
    public class FunctionResult
    {
        /// <summary>
        /// Constructs a new instance using the specified success value.
        /// </summary>
        /// <param name="succeeded">Value indicating whether the function succeeded.</param>
        public FunctionResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        /// <summary>
        /// Constructs a new failure instance using the provided exception.
        /// </summary>
        /// <param name="exception">The exception that the function threw.</param>
        public FunctionResult(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            Succeeded = false;
            Exception = exception;
        }

        /// <summary>
        /// Constructs a new failure instance using the specified success value
        /// and exception.
        /// </summary>
        /// <remarks>
        /// This overload allows a function result to be considered success,
        /// while also specifying an exception that occurred, but was handled.
        /// </remarks>
        /// <param name="succeeded">Value indicating whether the function succeeded.</param>
        /// <param name="exception">The exception that the function threw.</param>
        public FunctionResult(bool succeeded, Exception exception)
            : this(succeeded)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            Exception = exception;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the function succeeded.
        /// </summary>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// Gets or sets the exception that occurred during function execution.
        /// </summary>
        public Exception Exception { get; private set; }
    }
}
