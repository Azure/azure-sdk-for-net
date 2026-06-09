// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    [CodeGenSuppress("ContainerRegistryCredentials")]
    public partial class MachineLearningWorkspaceGetKeysResult
    {
        /// <summary> The resource ID of the workspace storage. </summary>
        [WirePath("userStorageResourceId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserStorageResourceId => UserStorageArmId;

        /// <summary> Gets the ContainerRegistryCredentials. </summary>
        [WirePath("containerRegistryCredentials")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningContainerRegistryCredentials ContainerRegistryCredentials { get; internal set; }
    }
}
