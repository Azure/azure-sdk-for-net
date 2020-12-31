// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Convert FailureNoContent into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class FailureNoContent
    {
        /// <summary>
        /// Create an exception corresponding to the FailureNoContent.
        /// </summary>
        /// <param name="clientDiagnostics">The <see cref="ClientDiagnostics"/> instance to use.</param>
        /// <param name="response">The failed response.</param>
        /// <returns>A RequestFailedException.</returns>
        public Exception CreateException(ClientDiagnostics clientDiagnostics, Azure.Response response)
            => clientDiagnostics.CreateRequestFailedExceptionWithContent(
                response, message: null, content: null, response.GetErrorCode(ErrorCode));
    }
}
