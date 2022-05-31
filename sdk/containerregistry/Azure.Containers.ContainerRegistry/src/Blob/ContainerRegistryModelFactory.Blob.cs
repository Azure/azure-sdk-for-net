﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
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
        /// <param name="manifest">The OCI manifest that was downloaded.</param>
        /// <param name="manifestStream">Manifest stream that was downloaded.</param>
        /// <returns> A new <see cref="Specialized.DownloadManifestResult"/> instance for mocking. </returns>
        public static DownloadManifestResult DownloadManifestResult(string digest = null, OciManifest manifest = null, Stream manifestStream = null)
        {
            return new DownloadManifestResult(digest, manifest, manifestStream);
        }

        /// <summary> Initializes a new instance of <see cref="Specialized.UploadBlobResult" />. </summary>
        /// <param name="digest"> The digest of the uploaded blob, calculated by the registry. </param>
        /// <returns> A new <see cref="Specialized.UploadBlobResult"/> instance for mocking. </returns>
        public static UploadBlobResult UploadBlobResult(string digest = null)
        {
            return new UploadBlobResult(digest);
        }

        /// <summary> Initializes a new instance of <see cref="Specialized.DownloadBlobResult" />. </summary>
        /// <param name="digest"> The blob's digest, calculated by the registry. </param>
        /// <param name="content">The blob content.</param>
        /// <returns> A new <see cref="Specialized.DownloadBlobResult"/> instance for mocking. </returns>
        public static DownloadBlobResult DownloadBlobResult(string digest = null, Stream content = null)
        {
            return new DownloadBlobResult(digest, content);
        }
    }
}
