// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningComponentContainerResource
    {
        // Customized: preserve GA MachineLearning-prefixed child accessors. These wrappers sit over
        // generated child-resource accessors, not standalone REST operations that client.tsp can rename.
        public virtual MachineLearningComponentVersionCollection GetMachineLearningComponentVersions() => new MachineLearningComponentVersionCollection(Client, Id);

        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentVersionResource>> GetMachineLearningComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetMachineLearningComponentVersions().GetAsync(version, cancellationToken);

        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentVersionResource> GetMachineLearningComponentVersion(string version, CancellationToken cancellationToken = default) => GetMachineLearningComponentVersions().Get(version, cancellationToken);
    }
}
