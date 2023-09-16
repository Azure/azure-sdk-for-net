// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ServiceErrorException : Exception
    {
        /// <summary>
        /// Gets the HTTP status code of the response. Returns. <code>0</code> if response was not received.
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// Gets the service specific error code if available. Please refer to the client documentation for the list of supported error codes.
        /// </summary>
        public string? ErrorCode { get; }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="result"></param>
        public ServiceErrorException(Result result) : base(GetMessageFromResult(result))
        {
            Status = result.Status;
            ErrorCode = GetErrorCode(result);
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected ServiceErrorException(Result result, string message, Exception? innerException)
            // TODO: what is the actual behavior of the EBN RFE constructor that takes both erroCode and message?
            // Duplicate that here.
            : base(message, innerException)
        {
            Status = result.Status;
            ErrorCode = GetErrorCode(result);
        }

        private static string? GetErrorCode(Result result)
        {
            if (result.Content is null)
            {
                return null;
            }

            // TODO: Parse content with Utf8JsonReader to get error code.
            // ErrorCode = errorCode;
            return string.Empty;
        }

        private static string GetMessageFromResult(Result result)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        /// <summary>
        /// TBD
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ServiceErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Status = info.GetInt32(nameof(Status));
            ErrorCode = info.GetString(nameof(ErrorCode));
        }
    }
}
