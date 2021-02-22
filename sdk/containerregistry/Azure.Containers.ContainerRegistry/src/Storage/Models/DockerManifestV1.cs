﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("V1Manifest")]
    public sealed partial class DockerManifestV1
    {
        /// <summary> CPU architecture. </summary>
        [CodeGenMember("Architecture")]
        public string CpuArchitecture { get; set; }
    }
}
