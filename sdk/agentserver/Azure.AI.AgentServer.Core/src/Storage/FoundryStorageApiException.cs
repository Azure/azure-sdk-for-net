// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Raised for storage service errors that do not map to a more specific type.</summary>
    public class FoundryStorageApiException : FoundryStorageException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStorageApiException"/> class.</summary>
        /// <param name="status">The HTTP status code returned by the storage service.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        public FoundryStorageApiException(int status, string message, string? errorCode = null)
            : base(status, message, errorCode)
        {
        }
    }
}
