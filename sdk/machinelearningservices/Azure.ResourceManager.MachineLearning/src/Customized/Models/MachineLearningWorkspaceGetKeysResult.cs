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
    // Customized: preserve the GA container registry credential model type over the generated
    // RegistryListCredentialsResult property type.
    [CodeGenSuppress("ContainerRegistryCredentials")]
    public partial class MachineLearningWorkspaceGetKeysResult
    {
        /// <summary> Gets the ContainerRegistryCredentials. </summary>
        [WirePath("containerRegistryCredentials")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningContainerRegistryCredentials ContainerRegistryCredentials { get; internal set; }
    }
}
