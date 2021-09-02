// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("Manifest")]
    internal abstract partial class ArtifactManifest
    {
        /// <summary> Initializes a new instance of ArtifactManifest. </summary>
        internal ArtifactManifest()
        {
        }
    }
}
