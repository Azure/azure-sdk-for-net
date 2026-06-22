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
    public partial class MachineLearningRegistryCodeContainerResource
    {
        // Customized: keep the historical MachineLearning* method names for source compatibility.
        public virtual MachineLearningRegistryCodeVersionCollection GetMachineLearningRegistryCodeVersions() => GetRegistryCodeVersions();
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeVersionResource>> GetMachineLearningRegistryCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeVersionResource> GetMachineLearningRegistryCodeVersion(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersion(version, cancellationToken);
    }
}
