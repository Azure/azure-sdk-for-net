// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Raised when an <c>If-Match</c> precondition fails (HTTP 412).</summary>
    public class FoundryStoragePreconditionException : FoundryStorageException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStoragePreconditionException"/> class.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="currentETag">The current server-side ETag, if returned.</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        public FoundryStoragePreconditionException(string message, string? currentETag = null, string? errorCode = null)
            : base(412, message, errorCode)
        {
            CurrentETag = currentETag;
        }

        /// <summary>Gets the current server-side ETag returned with the precondition failure, if any.</summary>
        public string? CurrentETag { get; }
    }
}
