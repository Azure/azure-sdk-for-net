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
    public partial class MachineLearningRegistryCodeContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryCodeVersionCollection GetMachineLearningRegistryCodeVersions() => GetRegistryCodeVersions();
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeVersionResource>> GetMachineLearningRegistryCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeVersionResource> GetMachineLearningRegistryCodeVersion(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersion(version, cancellationToken);
    }
}
