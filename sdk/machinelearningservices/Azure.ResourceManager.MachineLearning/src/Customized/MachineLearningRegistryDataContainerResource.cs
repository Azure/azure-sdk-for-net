// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve legacy MachineLearning-prefixed child resource getters and related legacy resource helpers.
    public partial class MachineLearningRegistryDataContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryDataVersionCollection GetMachineLearningRegistryDataVersions() => GetRegistryDataVersions();
        /// <summary> Gets a registry data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryDataVersionResource>> GetMachineLearningRegistryDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryDataVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryDataVersionResource> GetMachineLearningRegistryDataVersion(string version, CancellationToken cancellationToken = default) => GetRegistryDataVersion(version, cancellationToken);
    }
}
