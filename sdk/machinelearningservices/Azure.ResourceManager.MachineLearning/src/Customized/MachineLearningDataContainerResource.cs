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
        // Customized: preserve GA MachineLearning-prefixed child accessors. These wrappers sit over
        // generated child-resource accessors, not standalone REST operations that client.tsp can rename.
        /// <summary> Gets a collection of MachineLearningDataVersionResources in the <see cref="MachineLearningDataContainerResource"/>. </summary>
        public virtual MachineLearningDataVersionCollection GetMachineLearningDataVersions() => new MachineLearningDataVersionCollection(Client, Id);

        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataVersionResource>> GetMachineLearningDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetMachineLearningDataVersions().GetAsync(version, cancellationToken);

        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataVersionResource> GetMachineLearningDataVersion(string version, CancellationToken cancellationToken = default) => GetMachineLearningDataVersions().Get(version, cancellationToken);
    }
}
