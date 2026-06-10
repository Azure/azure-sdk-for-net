// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve GA options-bag GetAll overloads; the TypeSpec generator now expands
    // grouped query parameters into individual method parameters instead of emitting an options bag.
    public partial class MachineLearningOnlineEndpointCollection
    {
        public virtual AsyncPageable<MachineLearningOnlineEndpointResource> GetAllAsync(MachineLearningOnlineEndpointCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Name, options?.Count, options?.ComputeType, options?.Skip, options?.Tags, options?.Properties, options?.OrderBy, cancellationToken);

        public virtual Pageable<MachineLearningOnlineEndpointResource> GetAll(MachineLearningOnlineEndpointCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Name, options?.Count, options?.ComputeType, options?.Skip, options?.Tags, options?.Properties, options?.OrderBy, cancellationToken);
    }
}
