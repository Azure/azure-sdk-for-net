// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// This exception is used to notify the user that the set of inner exceptions has been trimmed because it exceeded our allowed send limit.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1064:ExceptionsShouldBePublic", Justification = "We expect that this exception will be caught within the internal scope and should never be exposed to an end user.")]
    internal class InnerExceptionCountExceededException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class.
        /// </summary>
        public InnerExceptionCountExceededException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public InnerExceptionCountExceededException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InnerExceptionCountExceededException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param><param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public InnerExceptionCountExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
