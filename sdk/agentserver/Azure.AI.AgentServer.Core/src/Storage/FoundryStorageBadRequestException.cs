// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Raised when the storage service rejects a request as invalid (HTTP 400).</summary>
    public class FoundryStorageBadRequestException : FoundryStorageException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStorageBadRequestException"/> class.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="param">The offending request parameter, if reported by the service.</param>
        /// <param name="status">The HTTP status code (400 by default; 409 for conflicts).</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        public FoundryStorageBadRequestException(string message, string? param = null, int status = 400, string? errorCode = null)
            : base(status, message, errorCode)
        {
            Param = param;
        }

        /// <summary>Gets the offending request parameter reported by the service, if any.</summary>
        public string? Param { get; }
    }
}
