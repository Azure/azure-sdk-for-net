// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("Manifest")]
    public abstract partial class ImageManifest
    {
        internal ImageManifest() { }

        internal string Digest { get; }

        public ManifestMediaType MediaType { get; internal set; }

        /// <summary> Schema version. </summary>
        public int SchemaVersion { get; }

        public DockerManifestV1 AsDockerManifestV1()
        {
            throw new NotImplementedException();
        }

        public DockerManifestV2 AsDockerManifestV2()
        {
            throw new NotImplementedException();
        }

        public DockerManifestList AsDockerManifestList()
        {
            throw new NotImplementedException();
        }

        public OciIndex AsOciIndex()
        {
            throw new NotImplementedException();
        }

        public OciManifest AsOciManifest()
        {
            throw new NotImplementedException();
        }
    }
}
