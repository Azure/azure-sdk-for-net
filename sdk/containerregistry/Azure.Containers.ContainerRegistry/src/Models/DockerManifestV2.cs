// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("V2Manifest")]
    internal partial class DockerManifestV2
    {
        /// <summary> V2 image config descriptor. </summary>
        [CodeGenMember("Config")]
        public ContentDescriptor ConfigDescriptor { get; set; }
    }
}
