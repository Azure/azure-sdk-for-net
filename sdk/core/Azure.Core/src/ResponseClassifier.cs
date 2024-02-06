// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Azure.Core
{
    /// <summary>
    /// A type that analyzes HTTP responses and exceptions and determines if they should be retried,
    /// and/or analyzes responses and determines if they should be treated as error responses.
    /// </summary>
    public class ResponseClassifier : PipelineMessageClassifier
    {
        internal static ResponseClassifier Shared { get; } = new();

        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
        {
            bool classified = Default.TryClassify(message, exception: default, out bool isRetriable);

            Debug.Assert(classified);

            return isRetriable;
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
            // Azure.Core cannot use default logic in this case to support end-user overrides
            // of virtual IsRetriableException method.

            return IsRetriableException(exception) ||
                // Retry non-user initiated cancellations
                (exception is OperationCanceledException &&
                !message.CancellationToken.IsCancellationRequested);
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
        {
            bool classified = Default.TryClassify(message, out bool isError);

            Debug.Assert(classified);

            return isError;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO: Add a test that breaks if we unseal this to prevent that from happening
        // Note: this is sealed to force the base type to call through to any overridden virtual methods
        // on a subtype of ResponseClassifier.
        public sealed override bool TryClassify(PipelineMessage message, out bool isError)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);

            isError = IsErrorResponse(httpMessage);

            return true;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <param name="isRetriable"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // TODO: Add a test that breaks if we unseal this to prevent that from happening
        // Note: this is sealed to force the base type to call through to any overridden virtual methods
        // on a subtype of ResponseClassifier.
        public sealed override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            HttpMessage httpMessage = HttpMessage.AssertHttpMessage(message);

            isRetriable = exception is null ?
                IsRetriableResponse(httpMessage) :
                IsRetriable(httpMessage, exception);

            return true;
        }
    }
}
