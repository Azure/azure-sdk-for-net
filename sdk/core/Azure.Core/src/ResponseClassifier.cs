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
    public class ResponseClassifier : PipelineMessageClassifier
    {
        internal static ResponseClassifier Shared { get; } = new();

        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriableResponse(HttpMessage message)
            => base.IsRetriableResponse(message);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public sealed override bool IsRetriableResponse(PipelineMessage message)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);

            return IsRetriableResponse(httpMessage);
        }

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried taking the <see cref="HttpMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(HttpMessage message, Exception exception)
            => base.IsRetriable(message, exception);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool IsRetriable(PipelineMessage message, Exception exception)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);

            return IsRetriable(httpMessage, exception);
        }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsErrorResponse(HttpMessage message)
            => base.IsErrorResponse(message);

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override sealed bool IsErrorResponse(PipelineMessage message)
        {
            HttpMessage httpMessage = AssertHttpMessage(message);

            return IsErrorResponse(httpMessage);
        }

        // TODO: remove duplication with this and other instances
        private static HttpMessage AssertHttpMessage(PipelineMessage message)
        {
            if (message is not HttpMessage httpMessage)
            {
                throw new InvalidOperationException($"Invalid type for PipelineMessage: '{message?.GetType()}'.");
            }

            return httpMessage;
        }
    }
}
