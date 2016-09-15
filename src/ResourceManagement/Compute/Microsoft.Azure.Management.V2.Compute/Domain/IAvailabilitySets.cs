/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Compute.AvailabilitySet.Definition;
    /// <summary>
    /// Entry point to availability set management API.
    /// </summary>
    public interface IAvailabilitySets  :
        ISupportsListingByGroup<IAvailabilitySet>,
        ISupportsGettingByGroup<IAvailabilitySet>,
        ISupportsGettingById<IAvailabilitySet>,
        ISupportsListing<IAvailabilitySet>,
        ISupportsCreating<IBlank>,
        ISupportsDeleting,
        ISupportsDeletingByGroup
    {
    }
}