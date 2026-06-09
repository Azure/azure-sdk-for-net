// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningDataContainerResource
    {
        // Customized: generated child getters cannot currently be renamed from TypeSpec decorators.
        public virtual MachineLearningDataVersionCollection GetMachineLearningDataVersions() => GetDataVersions();

        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataVersionResource>> GetMachineLearningDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetDataVersionAsync(version, cancellationToken);

        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataVersionResource> GetMachineLearningDataVersion(string version, CancellationToken cancellationToken = default) => GetDataVersion(version, cancellationToken);
    }
}
