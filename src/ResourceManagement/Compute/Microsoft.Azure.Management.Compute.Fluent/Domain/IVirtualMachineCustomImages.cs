// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineCustomImage.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point for image management API.
    /// </summary>
    public interface IVirtualMachineCustomImages  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsCreating<VirtualMachineCustomImage.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsGettingByGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsDeletingByGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        IHasManager<IComputeManager>,
        IHasInner<IImagesOperations>
    {
    }
}