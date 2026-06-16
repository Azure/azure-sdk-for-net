// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    // This file preserves the GA resource-group availability status mockable APIs.
    // The generator now returns AvailabilityStatusResource pages, so these custom methods
    // adapt each resource's Data back to the old ResourceHealthAvailabilityStatus model.
    public partial class MockableResourceHealthResourceGroupResource
    {
        /// <summary> Lists current availability status for resources in the resource group. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return new AsyncPageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(
                GetAvailabilityStatusResourcesByResourceGroupAsync(filter, expand, cancellationToken),
                resource => ResourceHealthAvailabilityStatus.FromData(resource.Data));
        }

        /// <summary> Lists current availability status for resources in the resource group. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return new PageableWrapper<AvailabilityStatusResource, ResourceHealthAvailabilityStatus>(
                GetAvailabilityStatusResourcesByResourceGroup(filter, expand, cancellationToken),
                resource => ResourceHealthAvailabilityStatus.FromData(resource.Data));
        }
    }
}
