// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using AvailabilitySet.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    /// <summary>
    /// Entry point to availability set management API.
    /// </summary>
    public interface IAvailabilitySets  :
        ISupportsListingByGroup<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsCreating<AvailabilitySet.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>
    {
    }
}