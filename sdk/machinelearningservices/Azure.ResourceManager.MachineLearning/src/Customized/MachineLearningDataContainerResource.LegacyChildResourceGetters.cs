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
    public partial class MachineLearningDataContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningDataVersionCollection GetMachineLearningDataVersions() => GetDataVersions();
        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataVersionResource>> GetMachineLearningDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetDataVersionAsync(version, cancellationToken);
        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataVersionResource> GetMachineLearningDataVersion(string version, CancellationToken cancellationToken = default) => GetDataVersion(version, cancellationToken);
    }
}
