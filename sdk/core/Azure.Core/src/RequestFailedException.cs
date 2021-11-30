// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    #pragma warning disable CA2229, CA2235 // False positive
    /// <summary>
    /// An exception thrown when service request fails.
    /// </summary>
    [Serializable]
    public class RequestFailedException : Exception, ISerializable
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string? ErrorCode { get; }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public RequestFailedException(string message) : this(0, message)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(string message, Exception? innerException) : this(0, message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and HTTP status code.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The message that describes the error.</param>
        public RequestFailedException(int status, string message)
            : this(status, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(int status, string message, Exception? innerException)
            : this(status, message, null, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class with a specified error message, HTTP status code, error code, and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="status">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="errorCode">The service specific error code.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RequestFailedException(int status, string message, string? errorCode, Exception? innerException)
            : base(message, innerException)
        {
            Status = status;
            ErrorCode = errorCode;
        }

        internal RequestFailedException(int status, (string Message, string? ErrorCode) details):
            this(status, details.Message, details.ErrorCode, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="RequestFailedException"></see> class
        /// with an error message, HTTP status code, error code obtained from the specified response.</summary>
        /// <param name="response">The response to obtain error details from.</param>
        public RequestFailedException(Response response)
            : this(response.Status, GetErrorDetails(response))
        {
        }

        /// <inheritdoc />
        protected RequestFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
            ErrorCode = info.GetString(nameof(ErrorCode));
        }

        private static (string Message, string? ErrorCode) GetErrorDetails(Response response)
        {
            string? message = null;
            string? errorCode = null;

            string? content = ClientDiagnostics.ReadContentAsync(response, false).EnsureCompleted();
            ClientDiagnostics.ExtractAzureErrorContent(content, ref message, ref errorCode);
            string exceptionMessage = ClientDiagnostics.CreateRequestFailedMessageWithContent(
                response,
                message,
                content,
                errorCode,
                null,
                response.Sanitizer!);

            return (exceptionMessage, errorCode);
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Status), Status);
            info.AddValue(nameof(ErrorCode), ErrorCode);

            base.GetObjectData(info, context);
        }
    }
}
