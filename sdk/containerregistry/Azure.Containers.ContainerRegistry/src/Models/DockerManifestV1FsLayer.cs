// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("FsLayer")]
    internal sealed partial class DockerManifestV1FsLayer
    {
        /// <summary> Initializes a new instance of DockerManifestV1FsLayer. </summary>
        internal DockerManifestV1FsLayer()
        {
        }

        /// <summary> SHA of an image layer. </summary>
        public string BlobSum { get; }
    }
}
