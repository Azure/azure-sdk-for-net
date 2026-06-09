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
    public partial class MachineLearningModelContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningModelVersionCollection GetMachineLearningModelVersions() => GetModelVersions();
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningModelVersionResource>> GetMachineLearningModelVersionAsync(string version, CancellationToken cancellationToken = default) => GetModelVersionAsync(version, cancellationToken);
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningModelVersionResource> GetMachineLearningModelVersion(string version, CancellationToken cancellationToken = default) => GetModelVersion(version, cancellationToken);
    }
}
