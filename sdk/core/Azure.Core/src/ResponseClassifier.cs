// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.ClientModel.Primitives;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried,
    /// and/or analyzes responses and determines if they should be treated as error responses.
    /// </summary>
    public class ResponseClassifier : MessageClassifier
    {
        internal static ResponseClassifier Shared { get; } = new();

        private readonly RetryClassifier _retryClassifier;

        /// <summary>
        /// TBD.
        /// </summary>
        public ResponseClassifier()
        {
            _retryClassifier = new RetryClassifier();
        }

        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
            => _retryClassifier.IsRetriable(message);

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriableException(Exception exception)
            => _retryClassifier.IsRetriable(exception);

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried taking the <see cref="HttpMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(HttpMessage message, Exception exception)
            => _retryClassifier.IsRetriable(message, exception);

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message) => base.IsError(message);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsError(PipelineMessage message)
            => base.IsError(message);
    }
}
