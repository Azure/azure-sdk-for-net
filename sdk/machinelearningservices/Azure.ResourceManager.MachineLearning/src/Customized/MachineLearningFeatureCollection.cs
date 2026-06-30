// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningFeatureCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureResource> GetAllAsync(MachineLearningFeatureCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.FeatureName, options?.Description, options?.ListViewType, options?.PageSize, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureResource> GetAll(MachineLearningFeatureCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.FeatureName, options?.Description, options?.ListViewType, options?.PageSize, cancellationToken);
    }
}
