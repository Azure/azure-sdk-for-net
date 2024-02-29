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

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override bool TryClassify(PipelineMessage message, out bool isError)
        {
            HttpMessage httpMessage = HttpMessage.GetHttpMessage(message);

            isError = IsErrorResponse(httpMessage);

            return true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sealed override bool TryClassify(PipelineMessage message, Exception? exception, out bool isRetriable)
        {
            HttpMessage httpMessage = HttpMessage.GetHttpMessage(message);

            isRetriable = exception is null ?
                IsRetriableResponse(httpMessage) :
                IsRetriable(httpMessage, exception);

            return true;
        }

        internal sealed class PipelineMessageClassifierAdapter : ResponseClassifier
        {
            private readonly PipelineMessageClassifier _classifier;

            public PipelineMessageClassifierAdapter(PipelineMessageClassifier classifier)
            {
                _classifier = classifier;
            }

            public override bool IsErrorResponse(HttpMessage message)
            {
                bool classified = _classifier.TryClassify(message, out bool isError);

                Debug.Assert(classified);

                return isError;
            }

            public override bool IsRetriable(HttpMessage message, Exception exception)
            {
                bool classified = _classifier.TryClassify(message, exception, out bool isRetriable);

                Debug.Assert(classified);

                return isRetriable;
            }

            public override bool IsRetriableException(Exception exception)
                => base.IsRetriableException(exception);

            public override bool IsRetriableResponse(HttpMessage message)
            {
                bool classified = _classifier.TryClassify(message, exception: default, out bool isRetriable);

                Debug.Assert(classified);

                return isRetriable;
            }
        }
    }
}
