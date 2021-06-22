// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("JWK")]
    internal sealed partial class DockerManifestV1Jwk
    {
        /// <summary> Initializes a new instance of DockerManifestV1Jwk. </summary>
        internal DockerManifestV1Jwk()
        {
        }

        /// <summary> JSON web key parameter. </summary>
        public DockerManifestV1JwkHeader Jwk { get; }
        /// <summary> The algorithm used to sign or encrypt the JWT. </summary>
        public string Alg { get; }
    }
}
