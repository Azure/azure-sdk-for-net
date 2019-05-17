// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.Test
{
    /// <summary>
    /// We're going to make our tests retry a few additional error types that
    /// may be more wasteful, but are less likely to cause test failures.
    /// </summary>
    public class TestResponseClassifier : ResponseClassifier
    {
        /// <summary>
        /// Determine if a response should be retried.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Whether it should be retried.</returns>
        public override bool IsRetriableResponse(Response response)
        {
            // Retry select Storage Error Codes
            if (response.Status >= 400 &&
                response.Headers.TryGetValue("x-ms-error-code", out var error))
            {
                switch (error)
                {
                    case "InternalError":
                    case "OperationTimedOut":
                    case "ServerBusy":
                    case "CannotVerifyCopySource":
                        return true;
                }
            }

            // Otherwise use the default rules
            return base.IsRetriableResponse(response);
        }
    }
}
