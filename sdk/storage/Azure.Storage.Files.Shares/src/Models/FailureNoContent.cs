// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Convert FailureNoContent into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class FailureNoContent
    {
        /// <summary>
        /// Create an exception corresponding to the FailureNoContent.
        /// </summary>
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => StorageExceptionExtensions.CreateException(response, null, null, ErrorCode);
    }
}
