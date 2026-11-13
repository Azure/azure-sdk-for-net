// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Raised when a storage resource already exists or an optimistic-concurrency create conflicts (HTTP 409).</summary>
    public class FoundryStorageConflictException : FoundryStorageBadRequestException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStorageConflictException"/> class.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="param">The offending request parameter, if reported by the service.</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        public FoundryStorageConflictException(string message, string? param = null, string? errorCode = null)
            : base(message, param, 409, errorCode)
        {
        }
    }
}
