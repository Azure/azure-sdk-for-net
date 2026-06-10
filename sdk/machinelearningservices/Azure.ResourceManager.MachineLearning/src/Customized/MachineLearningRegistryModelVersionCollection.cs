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
    public partial class MachineLearningRegistryModelVersionCollection
    {
        public virtual AsyncPageable<MachineLearningRegistryModelVersionResource> GetAllAsync(MachineLearningRegistryModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Tags, options?.Properties, options?.ListViewType, cancellationToken);

        public virtual Pageable<MachineLearningRegistryModelVersionResource> GetAll(MachineLearningRegistryModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Tags, options?.Properties, options?.ListViewType, cancellationToken);
    }
}
