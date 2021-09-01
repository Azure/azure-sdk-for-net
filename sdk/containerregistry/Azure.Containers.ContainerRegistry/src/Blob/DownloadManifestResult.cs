// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class DownloadManifestResult
    {
        internal DownloadManifestResult(string digest, OciManifest manifest)
        {
            Digest = digest;
            Manifest = manifest;
        }

        /// <summary>
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// </summary>
        public OciManifest Manifest { get; }
    }
}
