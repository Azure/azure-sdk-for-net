// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningFeatureStoreEntityContainerCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureStoreEntityContainerResource> GetAllAsync(MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureStoreEntityContainerResource> GetAll(MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);
    }
}
