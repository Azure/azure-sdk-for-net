// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat overloads are grouped to keep related shims together.

using System.Threading;
using Azure;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    public partial class MachineLearningWorkspaceCollection
    {
        // Customized: preserve the previous list overload shape.
        public virtual AsyncPageable<MachineLearningWorkspaceResource> GetAllAsync(string kind, CancellationToken cancellationToken)
            => GetAllAsync(kind, default, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        public virtual Pageable<MachineLearningWorkspaceResource> GetAll(string kind, CancellationToken cancellationToken)
            => GetAll(kind, default, default, cancellationToken);
    }

    public partial class MachineLearningWorkspaceConnectionCollection
    {
        // Customized: preserve the previous list overload shape.
        public virtual AsyncPageable<MachineLearningWorkspaceConnectionResource> GetAllAsync(string target, string category, CancellationToken cancellationToken)
            => GetAllAsync(target, category, default, cancellationToken);

        // Customized: preserve the previous list overload shape.
        public virtual Pageable<MachineLearningWorkspaceConnectionResource> GetAll(string target, string category, CancellationToken cancellationToken)
            => GetAll(target, category, default, cancellationToken);
    }

    public partial class MachineLearningDatastoreCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningDatastoreResource> GetAllAsync(MachineLearningDatastoreCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Count, options?.IsDefault, options?.Names, options?.SearchText, options?.OrderBy, options?.OrderByAsc, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningDatastoreResource> GetAll(MachineLearningDatastoreCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Count, options?.IsDefault, options?.Names, options?.SearchText, options?.OrderBy, options?.OrderByAsc, cancellationToken);
    }

    public partial class MachineLearningFeatureCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureResource> GetAllAsync(MachineLearningFeatureCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.FeatureName, options?.Description, options?.ListViewType, options?.PageSize, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureResource> GetAll(MachineLearningFeatureCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.FeatureName, options?.Description, options?.ListViewType, options?.PageSize, cancellationToken);
    }

    public partial class MachineLearningFeatureSetContainerCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureSetContainerResource> GetAllAsync(MachineLearningFeatureSetContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureSetContainerResource> GetAll(MachineLearningFeatureSetContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);
    }

    public partial class MachineLearningFeatureStoreEntityContainerCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureStoreEntityContainerResource> GetAllAsync(MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureStoreEntityContainerResource> GetAll(MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.Name, options?.Description, options?.CreatedBy, cancellationToken);
    }

    public partial class MachineLearningFeatureSetVersionCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeatureSetVersionResource> GetAllAsync(MachineLearningFeatureSetVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.VersionName, options?.Version, options?.Description, options?.CreatedBy, options?.Stage, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeatureSetVersionResource> GetAll(MachineLearningFeatureSetVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.VersionName, options?.Version, options?.Description, options?.CreatedBy, options?.Stage, cancellationToken);
    }

    public partial class MachineLearningFeaturestoreEntityVersionCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningFeaturestoreEntityVersionResource> GetAllAsync(MachineLearningFeaturestoreEntityVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.VersionName, options?.Version, options?.Description, options?.CreatedBy, options?.Stage, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningFeaturestoreEntityVersionResource> GetAll(MachineLearningFeaturestoreEntityVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.Tags, options?.ListViewType, options?.PageSize, options?.VersionName, options?.Version, options?.Description, options?.CreatedBy, options?.Stage, cancellationToken);
    }

    public partial class MachineLearningModelVersionCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningModelVersionResource> GetAllAsync(MachineLearningModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Offset, options?.Tags, options?.Properties, options?.Feed, options?.ListViewType, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningModelVersionResource> GetAll(MachineLearningModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Offset, options?.Tags, options?.Properties, options?.Feed, options?.ListViewType, cancellationToken);
    }

    public partial class MachineLearningRegistryModelVersionCollection
    {
        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual AsyncPageable<MachineLearningRegistryModelVersionResource> GetAllAsync(MachineLearningRegistryModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Tags, options?.Properties, options?.ListViewType, cancellationToken);

        // Customized: preserve options-object overloads from the previous generated SDK.
        public virtual Pageable<MachineLearningRegistryModelVersionResource> GetAll(MachineLearningRegistryModelVersionCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options?.Skip, options?.OrderBy, options?.Top, options?.Version, options?.Description, options?.Tags, options?.Properties, options?.ListViewType, cancellationToken);
    }

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

#pragma warning restore SA1402
