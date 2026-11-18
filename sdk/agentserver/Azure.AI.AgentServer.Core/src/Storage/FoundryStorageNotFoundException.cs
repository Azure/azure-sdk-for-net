// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>Raised when a storage resource is not found (HTTP 404).</summary>
    [Experimental("AAAS004")]
    public class FoundryStorageNotFoundException : FoundryStorageException
    {
        /// <summary>Initializes a new instance of the <see cref="FoundryStorageNotFoundException"/> class.</summary>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The service-defined error code, if any.</param>
        public FoundryStorageNotFoundException(string message, string? errorCode = null)
            : base(404, message, errorCode)
        {
        }
    }
}
