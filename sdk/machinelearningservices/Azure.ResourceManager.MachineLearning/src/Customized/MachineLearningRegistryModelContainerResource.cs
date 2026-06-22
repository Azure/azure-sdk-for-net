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
    // Customized: preserve GA MachineLearning-prefixed child resource accessors over shorter generated
    // registry child-resource accessors, which are not standalone REST operations that client.tsp can rename.
    public partial class MachineLearningRegistryModelContainerResource
    {
        // Customized: keep the historical MachineLearning* method names for source compatibility.
        public virtual MachineLearningRegistryModelVersionCollection GetMachineLearningRegistryModelVersions() => GetRegistryModelVersions();
        /// <summary> Gets a registry model version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryModelVersionResource>> GetMachineLearningRegistryModelVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryModelVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry model version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryModelVersionResource> GetMachineLearningRegistryModelVersion(string version, CancellationToken cancellationToken = default) => GetRegistryModelVersion(version, cancellationToken);
    }
}
