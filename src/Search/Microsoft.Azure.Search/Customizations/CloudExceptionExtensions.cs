// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Rest.Azure
{
    using System.Net;

    /// <summary>
    /// Defines extension methods for the CloudException class.
    /// </summary>
    public static class CloudExceptionExtensions
    {
        /// <summary>
        /// Indicates whether the exception is the result of a failed access condition (ETag) check.
        /// </summary>
        /// <param name="exception">The exception to check.</param>
        /// <returns>true if the exception is a failed access condition (HTTP 412 Precondition Failed), false otherwise.</returns>
        public static bool IsAccessConditionFailed(this CloudException exception)
        {
            return exception?.Response?.StatusCode == HttpStatusCode.PreconditionFailed;
        }
    }
}
