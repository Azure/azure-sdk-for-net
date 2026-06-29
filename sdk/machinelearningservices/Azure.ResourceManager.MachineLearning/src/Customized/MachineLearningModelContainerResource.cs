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
    // child-resource accessors, which are not standalone REST operations that client.tsp can rename.
    public partial class MachineLearningModelContainerResource
    {
        // Customized: keep the historical MachineLearning* method names for source compatibility.
        public virtual MachineLearningModelVersionCollection GetMachineLearningModelVersions() => new MachineLearningModelVersionCollection(Client, Id);
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningModelVersionResource>> GetMachineLearningModelVersionAsync(string version, CancellationToken cancellationToken = default) => GetMachineLearningModelVersions().GetAsync(version, cancellationToken);
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningModelVersionResource> GetMachineLearningModelVersion(string version, CancellationToken cancellationToken = default) => GetMachineLearningModelVersions().Get(version, cancellationToken);
    }
}
