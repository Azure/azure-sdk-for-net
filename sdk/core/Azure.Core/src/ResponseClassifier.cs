// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried.
    /// </summary>
    public class ResponseClassifier
    {
        private readonly RequestContext? _context;

        /// <summary>
        /// </summary>
        public ResponseClassifier()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public ResponseClassifier(RequestContext context)
        {
            _context = context;
        }

        internal static ResponseClassifier Shared { get; } = new();

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
            if (TryClassify(message.Response.Status, out bool isError))
            {
                return isError;
            }

            var statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }

        /// <summary>
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        protected bool TryClassify(int statusCode, out bool isError)
        {
            if (_context?.CustomErrors?.Contains(statusCode) ?? false)
            {
                isError = true;
                return true;
            }

            if (_context?.CustomNonErrors?.Contains(statusCode) ?? false)
            {
                isError = false;
                return true;
            }

            isError = false;
            return false;
        }
    }
}
