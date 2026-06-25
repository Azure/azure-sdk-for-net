// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve previous collection GetAll overload shapes.
    public partial class MachineLearningDatastoreCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningDatastoreResource> GetAllAsync(MachineLearningDatastoreCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Count, options?.IsDefault, options?.Names, options?.SearchText, options?.OrderBy, options?.OrderByAsc, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningDatastoreResource> GetAll(MachineLearningDatastoreCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Count, options?.IsDefault, options?.Names, options?.SearchText, options?.OrderBy, options?.OrderByAsc, cancellationToken);
    }
}
