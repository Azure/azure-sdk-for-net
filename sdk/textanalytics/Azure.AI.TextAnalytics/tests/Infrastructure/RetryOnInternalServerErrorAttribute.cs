// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework.Internal;

namespace Azure.AI.TextAnalytics.Tests.Infrastructure
{
    /// <summary>
    /// Attribute used to specify that a test must be retried in the specific case of a known transient issue where the
    /// server returns a successful 200 OK response status but reports an internal server error in the response body
    /// for one or more text analysis tasks. If the test continues to fail due to this particular issue after reaching
    /// the limit of tries, the test result is marked as inconclusive.
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
            return
                context.CurrentResult.Message.Contains("Azure.RequestFailedException")
                && context.CurrentResult.Message.Contains("Status: 200 (OK)")
                && context.CurrentResult.Message.Contains("ErrorCode: InternalServerError");
        }
    }
}
