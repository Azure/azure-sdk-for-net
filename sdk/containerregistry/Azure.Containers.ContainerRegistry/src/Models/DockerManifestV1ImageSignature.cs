// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("ImageSignature")]
    internal sealed partial class DockerManifestV1ImageSignature
    {
        /// <summary> Initializes a new instance of DockerManifestV1ImageSignature. </summary>
        internal DockerManifestV1ImageSignature()
        {
        }

        /// <summary> A JSON web signature. </summary>
        public DockerManifestV1Jwk Header { get; }

        /// <summary> A signature for the image manifest, signed by a libtrust private key. </summary>
        public string Signature { get; }

        /// <summary> The signed protected header. </summary>
        public string Protected { get; }
    }
}
