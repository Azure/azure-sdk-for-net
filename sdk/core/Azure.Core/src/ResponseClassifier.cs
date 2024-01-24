// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried,
    /// and/or analyzes responses and determines if they should be treated as error responses.
    /// </summary>
    public class ResponseClassifier : ErrorResponseClassifier
    {
        internal static ResponseClassifier Shared { get; } = new();

        private static ErrorResponseClassifier DefaultErrorClassifier { get; } = new();
        private static RetryResponseClassifier DefaultRetryClassifier { get; } = new();

        private readonly ErrorResponseClassifier _errorClassifier;
        private readonly RetryResponseClassifier _retryClassifier;

        /// <summary>
        /// TBD.
        /// </summary>
        public ResponseClassifier()
        {
            _errorClassifier = DefaultErrorClassifier;
            _retryClassifier = DefaultRetryClassifier;
        }

        internal ResponseClassifier(ErrorResponseClassifier errorClassifier,
            RetryResponseClassifier retryClassifier)
        {
            _errorClassifier = errorClassifier;
            _retryClassifier = retryClassifier;
        }

        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            _retryClassifier.TryClassify(message, default, out bool isRetriable);
            return isRetriable;
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
        {
            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried taking the <see cref="HttpMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(HttpMessage message, Exception exception)
        {
            _retryClassifier.TryClassify(message, exception, out bool isRetriable);
            return isRetriable;
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            _errorClassifier.TryClassify(message, out bool isError);
            return isError;
        }

        // TODO: with this approach, what happens if subtype of ResponseClassifier
        // overrides TryClassifier?  Will it work with chaining?  Will IsErrorResponse
        // be correct?
    }
}
