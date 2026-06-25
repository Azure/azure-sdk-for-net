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
    public partial class MachineLearningRegistryEnvironmentContainerResource
    {
        // Customized: keep the historical MachineLearning* method names for source compatibility.
        public virtual MachineLearningRegistryEnvironmentVersionCollection GetMachineLearningRegistryEnvironmentVersions() => GetRegistryEnvironmentVersions();
        /// <summary> Gets a registry environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryEnvironmentVersionResource>> GetMachineLearningRegistryEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryEnvironmentVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryEnvironmentVersionResource> GetMachineLearningRegistryEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetRegistryEnvironmentVersion(version, cancellationToken);
    }
}
