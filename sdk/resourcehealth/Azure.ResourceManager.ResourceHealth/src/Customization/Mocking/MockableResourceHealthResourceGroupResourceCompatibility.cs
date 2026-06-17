// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.ResourceManager.ResourceHealth.Models;

namespace Azure.ResourceManager.ResourceHealth.Mocking
{
    // This file preserves the GA resource-group availability status mockable APIs.
    // Preserve the GA GetAvailabilityStatusesByResourceGroup* names by forwarding to
    // the generated model-returning resource-group availability list methods.
    public partial class MockableResourceHealthResourceGroupResource
    {
        /// <summary> Lists current availability status for resources in the resource group. </summary>
        public virtual AsyncPageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroupAsync(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusResourcesByResourceGroupAsync(filter, expand, cancellationToken);
        }

        /// <summary> Lists current availability status for resources in the resource group. </summary>
        public virtual Pageable<ResourceHealthAvailabilityStatus> GetAvailabilityStatusesByResourceGroup(string filter = default, string expand = default, CancellationToken cancellationToken = default)
        {
            return GetAvailabilityStatusResourcesByResourceGroup(filter, expand, cancellationToken);
        }
    }
}
