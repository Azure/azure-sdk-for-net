// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition;
    /// <summary>
    /// Entry point to availability set management API.
    /// </summary>
    public interface IAvailabilitySets :
        ISupportsListingByGroup<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>,
        ISupportsGettingById<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>,
        ISupportsListing<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>,
        ISupportsCreating<Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.V2.Compute.IAvailabilitySet>
    {
    }
}