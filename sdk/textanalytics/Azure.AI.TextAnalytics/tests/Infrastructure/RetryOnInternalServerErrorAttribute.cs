// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework.Internal;

namespace Azure.AI.TextAnalytics.Tests.Infrastructure
{
    /// <summary>
    /// Attribute used to specify that a test must be retried in the specific case of a known internal server error. If
    /// the test continues to fail due to this particular issue after reaching the specified limit of tries, the test
    /// result is marked as inconclusive.
    /// </summary>
    public class RetryOnInternalServerErrorAttribute : RetryOnErrorAttribute
    {
        internal const int TryCount = 3;

        public RetryOnInternalServerErrorAttribute()
            : base(TryCount, ShouldRetry)
        {
        }

        /// <summary>
        /// Indicates whether the encountered exception corresponds to the issue in question.
        /// </summary>
        private static bool ShouldRetry(TestExecutionContext context)
        {
            string message = context?.CurrentResult?.Message;

            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            // A known transient issue where the server returns a successful 200 OK response status but reports an
            // internal server error in the response body for one or more text analysis tasks.
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/35677
            bool failedToProcessTaskTransientError =
                message.Contains("Azure.RequestFailedException")
                    && message.Contains("Failed to process task after several retry")
                    && message.Contains("Status: 200 (OK)")
                    && message.Contains("ErrorCode: InternalServerError");

            // A known transient issue where the server appears to be unable to process a valid text analysis task.
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/35679
            bool invalidTaskTypeTransientError =
                message.Contains("Azure.RequestFailedException")
                    && message.Contains("Invalid Task Type")
                    && message.Contains("Status: 500 (Internal Server Error)")
                    && message.Contains("ErrorCode: InternalServerError");

            // A known transient issue where the server fails to process a request and does not provide more context.
            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/35678
            bool internalServerTransientError =
                message.Contains("Azure.RequestFailedException")
                    && message.Contains("Internal Server Error.")
                    && message.Contains("Status: 200 (OK)")
                    && message.Contains("ErrorCode: InternalServerError");

            return failedToProcessTaskTransientError || invalidTaskTypeTransientError || internalServerTransientError;
        }
    }
}
