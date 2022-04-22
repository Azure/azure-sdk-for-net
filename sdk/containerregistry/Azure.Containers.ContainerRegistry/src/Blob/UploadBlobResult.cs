// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// The result from uploading a blob.
    /// </summary>
    public class UploadBlobResult
    {
        internal UploadBlobResult(string digest)
        {
            Digest = digest;
        }

        /// <summary>
        /// The digest of the uploaded blob, calculated by the registry.
        /// </summary>
        public string Digest { get; }
    }
}
