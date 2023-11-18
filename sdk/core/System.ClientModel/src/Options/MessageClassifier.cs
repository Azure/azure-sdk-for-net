// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace System.ClientModel.Primitives
{
    public class MessageClassifier
    {
        internal static MessageClassifier Default { get; } = new MessageClassifier();

        protected internal MessageClassifier() { }

        /// <summary>
        /// Specifies if the response contained in the <paramref name="message"/> is not successful.
        /// </summary>
        public virtual bool IsError(PipelineMessage message)
        {
            if (message.Response is null)
            {
                throw new InvalidOperationException("IsError must be called on a message where the OutputMessage is populated.");
            }

            int statusKind = message.Response.Status / 100;
            return statusKind == 4 || statusKind == 5;
        }

        // TODO: If we use retry classification as part of the same class as error
        // classification, we need to do something special to not override user-set
        // retry classifier when we set error classifier in DPG.  I think we *do*
        // have to solve this.  Consider a separate class "RetryClassifier" that could
        // be set in Message property bag if we don't want it in the public API.

        /// <summary>
        /// Specifies if the request contained in the <paramref name="message"/> should be retried.
        /// </summary>
        public virtual bool IsRetriable(PipelineMessage message)
            => message.Response.Status switch
            {
                // Request Timeout
                408 => true,

                // Too Many Requests
                429 => true,

                // Internal Server Error
                500 => true,

                // Bad Gateway
                502 => true,

                // Service Unavailable
                503 => true,

                // Gateway Timeout
                504 => true,

                // Default case
                _ => false
            };

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried.
        /// </summary>
        public virtual bool IsRetriable(Exception exception)
            => (exception is IOException) ||
               (exception is ClientRequestException ex && ex.Status == 0);

        /// <summary>
        /// Specifies if the operation that caused the exception should be retried,
        /// taking the <see cref="PipelineMessage"/> into consideration.
        /// </summary>
        public virtual bool IsRetriable(PipelineMessage message, Exception exception)
         => IsRetriable(exception) ||
            // Retry non-user initiated cancellations
            (exception is OperationCanceledException &&
            !message.CancellationToken.IsCancellationRequested);
    }
}
