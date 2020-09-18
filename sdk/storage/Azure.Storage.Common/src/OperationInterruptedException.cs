// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Azure.Core;

namespace Azure.Storage
{
#pragma warning disable CA2229, CA2235 // False positive
    /// <summary>
    /// An exception thrown when an operation is interrupted and can be continued later on.
    /// </summary>
    [Serializable]
    public class OperationInterruptedException : RequestFailedException, ISerializable
    {
        /// <summary>
        /// Gets the continuation token from the last successful response from the service.
        /// </summary>
        public string ContinuationToken { get; }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public OperationInterruptedException(string message) : this(0, message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OperationInterruptedException(string message, Exception innerException) : this(0, message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and HTTP status code.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The message that describes the error.</param>
        public OperationInterruptedException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OperationInterruptedException(int status, string message, Exception innerException)
            : this(status, message, null, innerException, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The service specific error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OperationInterruptedException(int status, string message, string errorCode, Exception innerException)
            : this(status, message, errorCode, innerException, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="exception">The exception thrown from the failed request.</param>
        /// <param name="continuationToken">The continuation token returned from the previous successful response.</param>
        public OperationInterruptedException(RequestFailedException exception, string continuationToken)
            : base(exception.Status, exception.Message, exception.ErrorCode, exception.InnerException)
        {
            ContinuationToken = continuationToken;
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The service specific error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="continuationToken">The continuation token returned from the previous successful response.</param>
        public OperationInterruptedException(int status, string message, string errorCode, Exception innerException, string continuationToken)
            : base(status, message, errorCode, innerException)
        {
            ContinuationToken = continuationToken;
        }

        /// <inheritdoc />
        protected OperationInterruptedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ContinuationToken = info.GetString(nameof(ContinuationToken));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(ContinuationToken), ContinuationToken);

            base.GetObjectData(info, context);
        }
    }
}
