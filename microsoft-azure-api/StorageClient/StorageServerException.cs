//-----------------------------------------------------------------------
// <copyright file="StorageServerException.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the StorageServerException class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an exception thrown due to a server-side error.
    /// </summary>
    [SuppressMessage(
        "Microsoft.Design",
        "CA1032:ImplementStandardExceptionConstructors",
        Justification = "Since this exception comes from the server, there must be an HTTP response code associated with it," +
            "hence we exclude the default constructor taking only a string but no status code.")]
    [Serializable]
    public class StorageServerException : StorageException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageServerException"/> class.
        /// </summary>
        public StorageServerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageServerException"/> class.
        /// </summary>
        /// <param name="errorCode">The storage client error code.</param>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="statusCode">The HTTP status code returned in the response.</param>
        /// <param name="innerException">The <see cref="Exception"/> instance that caused the current exception.</param>
        internal StorageServerException(
            StorageErrorCode errorCode,
            string message,
            HttpStatusCode statusCode,
            Exception innerException)
            : base(errorCode, message, statusCode, null, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageServerException"/> class.
        /// </summary>
        /// <param name="errorCode">The storage client error code.</param>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="statusCode">The HTTP status code returned in the response.</param>
        /// <param name="extendedErrorInfo">The extended error information.</param>
        /// <param name="innerException">The <see cref="Exception"/> instance that caused the current exception.</param>
        internal StorageServerException(
            StorageErrorCode errorCode,
            string message,
            HttpStatusCode statusCode,
            StorageExtendedErrorInformation extendedErrorInfo,
            Exception innerException)
            : base(errorCode, message, statusCode, extendedErrorInfo, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageServerException"/> class with
        /// serialized data.
        /// </summary>
        /// <param name="info">The object that contains serialized data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information
        /// about the source or destination.</param>
        protected StorageServerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}