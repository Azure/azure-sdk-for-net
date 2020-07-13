// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Provides well-known blob metadata keys.</summary>
#if PUBLICPROTOCOL
    public static class BlobMetadataKeys
#else
    internal static class BlobMetadataKeys
#endif
    {
        /// <summary>
        /// Gets the name of the blob metadata key used to store ID of the function instance that wrote the blob.
        /// </summary>
        public const string ParentId = "AzureWebJobsParentId";
    }
}
