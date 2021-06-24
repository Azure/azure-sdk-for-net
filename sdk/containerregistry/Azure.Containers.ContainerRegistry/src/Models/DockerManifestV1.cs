// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.ResumableStorage
{
    [CodeGenModel("V1Manifest")]
    internal sealed partial class DockerManifestV1
    {
        ///// <summary> Initializes a new instance of DockerManifestV1. </summary>
        //internal DockerManifestV1()
        //{
        //    FsLayers = new ChangeTrackingList<DockerManifestV1FsLayer>();
        //    History = new ChangeTrackingList<DockerManifestV1History>();
        //    Signatures = new ChangeTrackingList<DockerManifestV1ImageSignature>();
        //}

        /// <summary> CPU architecture. </summary>
        [CodeGenMember("Architecture")]
        public string CpuArchitecture { get; }

        /// <summary> Image name. </summary>
        public string Name { get; }
        /// <summary> Image tag. </summary>
        public string Tag { get; }
        /// <summary> List of layer information. </summary>
        public IReadOnlyList<DockerManifestV1FsLayer> FsLayers { get; }
        /// <summary> Image history. </summary>
        public IReadOnlyList<DockerManifestV1History> History { get; }
        /// <summary> Image signature. </summary>
        public IReadOnlyList<DockerManifestV1ImageSignature> Signatures { get; }
    }
}
