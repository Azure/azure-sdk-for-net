// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.ServiceModel.Rest.Core;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried,
    /// and/or analyzes responses and determines if they should be treated as error responses.
    /// </summary>
    public class ResponseClassifier : ResponseErrorClassifier
    {
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
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        // TODO: would it make sense to template classifier to avoid this override?
        public virtual bool IsErrorResponse(HttpMessage message) => base.IsErrorResponse(message);
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class ResponseClassifierAdapter : ResponseClassifier
#pragma warning restore SA1402 // File may only contain a single type
    {
        private readonly ResponseErrorClassifier _classifier;

        public ResponseClassifierAdapter(ResponseErrorClassifier classifier)
        {
            _classifier = classifier;
        }

        public override bool IsErrorResponse(HttpMessage message)
            => _classifier.IsErrorResponse(message);

        public override bool IsErrorResponse(PipelineMessage message)
            => _classifier.IsErrorResponse(message);
    }
}
