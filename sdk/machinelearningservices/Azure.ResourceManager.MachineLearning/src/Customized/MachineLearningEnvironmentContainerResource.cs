// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningEnvironmentContainerResource
    {
        // Customized: preserve GA MachineLearning-prefixed child accessors. These wrappers sit over
        // generated child-resource accessors, not standalone REST operations that client.tsp can rename.
        /// <summary> Gets a collection of MachineLearningEnvironmentVersionResources in the <see cref="MachineLearningEnvironmentContainerResource"/>. </summary>
        public virtual MachineLearningEnvironmentVersionCollection GetMachineLearningEnvironmentVersions() => new MachineLearningEnvironmentVersionCollection(Client, Id);

        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentVersionResource>> GetMachineLearningEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetMachineLearningEnvironmentVersions().GetAsync(version, cancellationToken);

        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentVersionResource> GetMachineLearningEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetMachineLearningEnvironmentVersions().Get(version, cancellationToken);
    }
}
