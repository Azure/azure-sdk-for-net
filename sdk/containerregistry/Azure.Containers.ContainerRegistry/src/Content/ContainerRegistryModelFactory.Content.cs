// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    public static partial class ContainerRegistryModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="SetManifestResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded manifest, calculated by the registry. </param>
        /// <returns> A new <see cref="SetManifestResult"/> instance for mocking. </returns>
        public static SetManifestResult SetManifestResult(string digest = null)
        {
            return new SetManifestResult(digest);
        }

        /// <summary> Initializes a new instance of <see cref="GetManifestResult" />. </summary>
        /// <param name="digest"> The manifest's digest, calculated by the registry. </param>
        /// <param name="mediaType">The media type of the downloaded manifest.</param>
        /// <param name="manifest">Manifest content that was downloaded.</param>
        /// <returns> A new <see cref="GetManifestResult"/> instance for mocking. </returns>
        public static GetManifestResult GetManifestResult(string digest = null, string mediaType = null, BinaryData manifest = null)
        {
            return new GetManifestResult(digest, mediaType, manifest);
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
