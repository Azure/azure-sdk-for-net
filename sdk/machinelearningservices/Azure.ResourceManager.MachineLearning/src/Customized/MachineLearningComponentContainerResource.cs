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
    public partial class MachineLearningComponentContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningComponentVersionCollection GetMachineLearningComponentVersions() => GetComponentVersions();
        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentVersionResource>> GetMachineLearningComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetComponentVersionAsync(version, cancellationToken);
        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentVersionResource> GetMachineLearningComponentVersion(string version, CancellationToken cancellationToken = default) => GetComponentVersion(version, cancellationToken);
    }
}
