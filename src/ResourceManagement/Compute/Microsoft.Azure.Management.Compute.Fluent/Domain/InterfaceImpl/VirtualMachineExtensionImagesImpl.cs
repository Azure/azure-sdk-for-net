// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;

    internal partial class VirtualMachineExtensionImagesImpl 
    {
        /// <summary>
        /// Gets entry point to virtual machine extension image publishers.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImages.Publishers
        {
            get
            {
                return this.Publishers() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers;
            }
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">The selected Azure region.</param>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>.ListByRegion(Region region)
        {
            return this.ListByRegion(region) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">The name of an Azure region.</param>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>.ListByRegion(string regionName)
        {
            return this.ListByRegion(regionName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>;
        }
    }
}