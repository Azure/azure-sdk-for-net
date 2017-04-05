// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using AvailabilitySet.Definition;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to availability set management API.
    /// </summary>
    public interface IAvailabilitySets  :
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        ISupportsCreating<AvailabilitySet.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet>,
        IHasManager<IComputeManager>,
        IHasInner<IAvailabilitySetsOperations>
    {
    }
}