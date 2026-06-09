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
    public partial class MachineLearningCodeContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningCodeVersionCollection GetMachineLearningCodeVersions() => GetCodeVersions();
        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningCodeVersionResource>> GetMachineLearningCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetCodeVersionAsync(version, cancellationToken);
        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningCodeVersionResource> GetMachineLearningCodeVersion(string version, CancellationToken cancellationToken = default) => GetCodeVersion(version, cancellationToken);
    }
}
