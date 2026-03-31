// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    public partial class MockableContainerInstanceSubscriptionResource
    {
        /// <summary> Get the list of cached images on specific OS type for a subscription in a region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CachedImages> GetCachedImagesWithLocation(AzureLocation location, CancellationToken cancellationToken = default)
            => GetCachedImages(location.Name, cancellationToken);

        /// <summary> Get the list of cached images on specific OS type for a subscription in a region. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CachedImages> GetCachedImagesWithLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetCachedImagesAsync(location.Name, cancellationToken);

        /// <summary> Get the list of container instance service usage in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerInstanceUsage> GetUsagesWithLocation(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsage(location.Name, cancellationToken);

        /// <summary> Get the list of container instance service usage in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerInstanceUsage> GetUsagesWithLocationAsync(AzureLocation location, CancellationToken cancellationToken = default)
            => GetUsageAsync(location.Name, cancellationToken);
    }
}
