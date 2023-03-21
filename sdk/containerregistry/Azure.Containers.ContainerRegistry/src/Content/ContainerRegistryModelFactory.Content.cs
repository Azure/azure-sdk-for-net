// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    public static partial class ContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="UploadManifestResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded manifest, calculated by the registry. </param>
        /// <returns> A new <see cref="UploadManifestResult"/> instance for mocking. </returns>
        public static UploadManifestResult UploadManifestResult(string digest = null)
        {
            return new UploadManifestResult(digest);
        }

        /// <summary> Initializes a new instance of <see cref="DownloadManifestResult" />. </summary>
        /// <param name="digest"> The manifest's digest, calculated by the registry. </param>
        /// <param name="mediaType">The media type of the downloaded manifest.</param>
        /// <param name="content">Manifest content that was downloaded.</param>
        /// <returns> A new <see cref="DownloadManifestResult"/> instance for mocking. </returns>
        public static DownloadManifestResult DownloadManifestResult(string digest = null, string mediaType = null, BinaryData content = null)
        {
            return new DownloadManifestResult(digest, mediaType, content);
        }

        /// <summary> Initializes a new instance of <see cref="UploadRegistryBlobResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded blob, calculated by the registry. </param>
        /// <param name="sizeInBytes">The size of the uploaded blob.</param>
        /// <returns> A new <see cref="UploadRegistryBlobResult"/> instance for mocking. </returns>
        public static UploadRegistryBlobResult UploadRegistryBlobResult(string digest, long sizeInBytes)
        {
            return new UploadRegistryBlobResult(digest, sizeInBytes);
        }

        /// <summary> Initializes a new instance of <see cref="DownloadRegistryBlobResult" />. </summary>
        /// <param name="digest"> The blob's digest, calculated by the registry. </param>
        /// <param name="content">The blob content.</param>
        /// <returns> A new <see cref="DownloadRegistryBlobResult"/> instance for mocking. </returns>
        public static DownloadRegistryBlobResult DownloadRegistryBlobResult(string digest = null, BinaryData content = null)
        {
            return new DownloadRegistryBlobResult(digest, content);
        }
    }
}
