// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    /// <summary>Provides well-known blob metadata keys.</summary>
    internal static class BlobMetadataKeys
    {
        /// <summary>
        /// Gets the name of the blob metadata key used to store ID of the function instance that wrote the blob.
        /// </summary>
        public const string ParentId = "AzureWebJobsParentId";
    }
}
