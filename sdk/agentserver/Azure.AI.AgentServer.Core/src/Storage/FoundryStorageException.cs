// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Base exception for all Foundry storage service errors. Derives from
    /// <see cref="RequestFailedException"/> so callers get the HTTP status and error code.
    /// </summary>
    public class FoundryStorageException : RequestFailedException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStorageException"/> class.</summary>
        /// <param name="status">The HTTP status code returned by the storage service.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        /// <param name="innerException">The inner exception, if any.</param>
        public FoundryStorageException(int status, string message, string? errorCode = null, Exception? innerException = null)
            : base(status, message, errorCode, innerException)
        {
        }
    }
}
