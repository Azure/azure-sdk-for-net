// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Containers.ContainerRegistry.Specialized;

namespace Azure.Containers.ContainerRegistry
{
    public static partial class ContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Specialized.UploadManifestResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded manifest, calculated by the registry. </param>
        /// <returns> A new <see cref="Specialized.UploadManifestResult"/> instance for mocking. </returns>
        public static UploadManifestResult UploadManifestResult(string digest = null)
        {
            return new UploadManifestResult(digest);
        }

        /// <summary> Initializes a new instance of <see cref="Specialized.DownloadManifestResult" />. </summary>
        /// <param name="digest"> The manifest's digest, calculated by the registry. </param>
        /// <param name="mediaType">The media type of the downloaded manifest.</param>
        /// <param name="content">Manifest content that was downloaded.</param>
        /// <returns> A new <see cref="Specialized.DownloadManifestResult"/> instance for mocking. </returns>
        public static DownloadManifestResult DownloadManifestResult(string digest = null, string mediaType = null, BinaryData content = null)
        {
            return new DownloadManifestResult(digest, mediaType, content);
        }

        /// <summary> Initializes a new instance of <see cref="Specialized.UploadBlobResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded blob, calculated by the registry. </param>
        /// <param name="size"> The size of the uploaded blob. </param>
        /// <returns> A new <see cref="Specialized.UploadBlobResult"/> instance for mocking. </returns>
        public static UploadBlobResult UploadBlobResult(string digest, long size)
        {
            return new UploadBlobResult(digest, size);
        }

        /// <summary> Initializes a new instance of <see cref="Specialized.DownloadBlobResult" />. </summary>
        /// <param name="digest"> The blob's digest, calculated by the registry. </param>
        /// <param name="content">The blob content.</param>
        /// <returns> A new <see cref="Specialized.DownloadBlobResult"/> instance for mocking. </returns>
        public static DownloadBlobResult DownloadBlobResult(string digest = null, BinaryData content = null)
        {
            return new DownloadBlobResult(digest, content);
        }
    }
}
