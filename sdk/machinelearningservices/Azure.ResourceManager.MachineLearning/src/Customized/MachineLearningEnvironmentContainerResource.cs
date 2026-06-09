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
        // Customized: generated child getters cannot currently be renamed from TypeSpec decorators.
        public virtual MachineLearningEnvironmentVersionCollection GetMachineLearningEnvironmentVersions() => GetEnvironmentVersions();

        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentVersionResource>> GetMachineLearningEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersionAsync(version, cancellationToken);

        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentVersionResource> GetMachineLearningEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersion(version, cancellationToken);
    }
}
