// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningCodeContainerResource
    {
        // Customized: generated child getters cannot currently be renamed from TypeSpec decorators.
        public virtual MachineLearningCodeVersionCollection GetMachineLearningCodeVersions() => GetCodeVersions();

        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningCodeVersionResource>> GetMachineLearningCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetCodeVersionAsync(version, cancellationToken);

        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningCodeVersionResource> GetMachineLearningCodeVersion(string version, CancellationToken cancellationToken = default) => GetCodeVersion(version, cancellationToken);
    }
}
