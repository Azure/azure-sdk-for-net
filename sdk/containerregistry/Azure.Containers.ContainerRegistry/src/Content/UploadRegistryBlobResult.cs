// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The result from uploading a blob.
    /// </summary>
    public class UploadRegistryBlobResult
    {
        internal UploadRegistryBlobResult(string digest, long size)
        {
            Digest = digest;
            SizeInBytes = size;
        }

        /// <summary>
        /// The digest of the uploaded blob, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The size of the uploaded blob.
        /// </summary>
        public long SizeInBytes { get; }
    }
}
