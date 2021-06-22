// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("History")]
    internal sealed partial class DockerManifestV1History
    {
        /// <summary> Initializes a new instance of DockerManifestV1History. </summary>
        internal DockerManifestV1History()
        {
        }

        /// <summary> The raw v1 compatibility information. </summary>
        public string V1Compatibility { get; }
    }
}
