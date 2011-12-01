//-----------------------------------------------------------------------
// <copyright file="StorageException.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the StorageException class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    /// <summary>
    /// The base class for Windows Azure storage service exceptions.
    /// </summary>
    [Serializable]
    public abstract class StorageException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class.
        /// </summary>
        protected StorageException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class.
        /// </summary>
        /// <param name="errorCode">The storage client error code.</param>
        /// <param name="message">The message that describes the exception.</param>
        /// <param name="statusCode">The HTTP status code returned in the response.</param>
        /// <param name="extendedErrorInfo">The extended error information.</param>
        /// <param name="innerException">The <see cref="Exception"/> instance that caused the current exception.</param>
        protected StorageException(
            StorageErrorCode errorCode,
            string message,
            HttpStatusCode statusCode,
            StorageExtendedErrorInformation extendedErrorInfo,
            Exception innerException)
            : base(message, innerException)
        {
            this.ErrorCode = errorCode;
            this.StatusCode = statusCode;
            this.ExtendedErrorInformation = extendedErrorInfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageException"/> class with
        /// serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> object that contains serialized object
        /// data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information
        /// about the source or destionation. </param>
        protected StorageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (null == info)
            {
                throw new ArgumentNullException("info");
            }

            this.StatusCode = (HttpStatusCode)info.GetValue("StatusCode", typeof(HttpStatusCode));
            this.ErrorCode = (StorageErrorCode)info.GetValue("ErrorCode", typeof(StorageErrorCode));
            this.ExtendedErrorInformation = (StorageExtendedErrorInformation)info.GetValue(
                        "ExtendedErrorInformation", typeof(StorageExtendedErrorInformation));
        }

        /// <summary>
        /// Gets the HTTP status code that was returned by the service.
        /// </summary>
        /// <value>The HTTP status code.</value>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the specific error code returned by the service.
        /// </summary>
        /// <value>The storage error code.</value>
        public StorageErrorCode ErrorCode { get; private set; }

        /// <summary>
        /// Gets the extended error information returned by the service.
        /// </summary>
        /// <value>The extended error information.</value>
        public StorageExtendedErrorInformation ExtendedErrorInformation { get; private set; }

        /// <summary>
        /// Sets the <see cref="SerializationInfo"/> object with additional exception information.
        /// </summary>
        /// <param name="info">The object that contains serialized data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information
        /// about the source or destination.</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (null == info)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("StatusCode", this.StatusCode);
            info.AddValue("ErrorCode", this.ErrorCode);
            info.AddValue("ExtendedErrorInformation", this.ExtendedErrorInformation);
            base.GetObjectData(info, context);
        }
    }
}
