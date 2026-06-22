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
    // Customized: preserve GA MachineLearnin-prefixed child resource accessors over shorter generated registry child accessors.
    public partial class MachineLearninRegistryComponentContainerResource
    {
        // Customized: keep the historical MachineLearnin* typo in method names for source compatibility.
        public virtual MachineLearninRegistryComponentVersionCollection GetMachineLearninRegistryComponentVersions() => GetRegistryComponentVersions();
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentVersionResource>> GetMachineLearninRegistryComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryComponentVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentVersionResource> GetMachineLearninRegistryComponentVersion(string version, CancellationToken cancellationToken = default) => GetRegistryComponentVersion(version, cancellationToken);
    }
}
