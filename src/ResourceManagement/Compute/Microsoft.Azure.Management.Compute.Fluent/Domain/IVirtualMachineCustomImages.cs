// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using VirtualMachineCustomImage.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to custom virtual machine image management..
    /// </summary>
    public interface IVirtualMachineCustomImages  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsCreating<VirtualMachineCustomImage.Definition.IBlank>,
        ISupportsDeletingById,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsGettingById<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineCustomImage>,
        ISupportsBatchDeletion,
        IHasManager<IComputeManager>,
        IHasInner<IImagesOperations>
    {
    }
}