// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningOnlineEndpointCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningOnlineEndpointResource> GetAllAsync(MachineLearningOnlineEndpointCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Name, options?.Count, options?.ComputeType, options?.Skip, options?.Tags, options?.Properties, options?.OrderBy, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningOnlineEndpointResource> GetAll(MachineLearningOnlineEndpointCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Name, options?.Count, options?.ComputeType, options?.Skip, options?.Tags, options?.Properties, options?.OrderBy, cancellationToken);
    }
}
