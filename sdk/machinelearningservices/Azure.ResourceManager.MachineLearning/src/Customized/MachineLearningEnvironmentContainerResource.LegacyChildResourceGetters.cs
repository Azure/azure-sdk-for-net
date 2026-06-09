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
    public partial class MachineLearningEnvironmentContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningEnvironmentVersionCollection GetMachineLearningEnvironmentVersions() => GetEnvironmentVersions();
        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentVersionResource>> GetMachineLearningEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersionAsync(version, cancellationToken);
        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentVersionResource> GetMachineLearningEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersion(version, cancellationToken);
    }
}
