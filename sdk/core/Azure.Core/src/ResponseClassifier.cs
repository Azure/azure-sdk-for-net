// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried.
    /// </summary>
    public class ResponseClassifier
    {
        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            switch (message.Response.Status)
            {
                case 408: // Request Timeout
                case 429: // Too Many Requests
                case 500: // Internal Server Error
                case 502: // Bad Gateway
                case 503: // Service Unavailable
                case 504: // Gateway Timeout
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            return (exception is IOException) ||
                   (exception is RequestFailedException requestFailed && requestFailed.Status == 0);
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried taking the <see cref="HttpMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(HttpMessage message, Exception exception)
        {
            return IsRetriableException(exception) ||
                   // Retry non-user initiated cancellations
                   (exception is OperationCanceledException && !message.CancellationToken.IsCancellationRequested);
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            var status = message.Response.Status;
            switch (status)
            {
                case 409:
                    var header = message.Request.Headers;
                    // Don't treat 409 responses to conditional requests as errors
                    var isConditional =
                            header.Contains(HttpHeader.Names.IfMatch) ||
                            header.Contains(HttpHeader.Names.IfNoneMatch) ||
                            header.Contains(HttpHeader.Names.IfModifiedSince) ||
                            header.Contains(HttpHeader.Names.IfUnmodifiedSince);
                    return !isConditional;
                case >= 400 and <= 599: return true;
                default: return false;
            }
        }
    }
}
