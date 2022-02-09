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
        internal static ResponseClassifier Shared { get; } = new();

        /// <summary>
        /// User-provided customizations to the classifier for this invocation
        /// of an operation. This classifier has try-classifier semantics and may
        /// not provide classifications for every possible status code.
        /// </summary>
        internal MessageClassifier? InvocationClassifier { get; set;}

        /// <summary>
        /// User-provided customizations to the classifier to be applied to every
        /// service method on the client. This classifier has try-classifier semantics
        /// and may not provide classifications for every possible status code.
        /// </summary>
        internal MessageClassifier? ClientClassifier { get; set; }

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

        internal bool IsError(HttpMessage message)
        {
            bool isError;

            if (InvocationClassifier?.TryClassify(message, out isError) ?? false)
            {
                return isError;
            }

            if (ClientClassifier?.TryClassify(message, out isError) ?? false)
            {
                return isError;
            }

            return IsErrorResponse(message);
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            // Final default classification of all error codes.
            var statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }
    }
}
