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
        // Customized: generated child getters cannot currently be renamed from TypeSpec decorators.
        public virtual MachineLearningComponentVersionCollection GetMachineLearningComponentVersions() => GetComponentVersions();

        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentVersionResource>> GetMachineLearningComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetComponentVersionAsync(version, cancellationToken);

        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentVersionResource> GetMachineLearningComponentVersion(string version, CancellationToken cancellationToken = default) => GetComponentVersion(version, cancellationToken);
    }
}
