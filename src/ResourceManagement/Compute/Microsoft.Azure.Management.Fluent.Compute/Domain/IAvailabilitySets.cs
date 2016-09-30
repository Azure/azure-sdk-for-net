// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition;
    /// <summary>
    /// Entry point to availability set management API.
    /// </summary>
    public interface IAvailabilitySets :
        ISupportsListingByGroup<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>,
        ISupportsGettingById<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>,
        ISupportsListing<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>,
        ISupportsCreating<Microsoft.Azure.Management.Fluent.Compute.AvailabilitySet.Definition.IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Fluent.Compute.IAvailabilitySet>
    {
    }
}