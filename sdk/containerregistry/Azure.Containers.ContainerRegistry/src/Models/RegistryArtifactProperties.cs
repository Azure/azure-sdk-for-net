// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary> Manifest attributes details. </summary>
    public partial class RegistryArtifactProperties
    {
        /// <summary>
        /// </summary>
        public IReadOnlyList<RegistryArtifactProperties> References { get; }
    }
}
