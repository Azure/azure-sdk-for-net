// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    internal partial class VirtualMachineExtensionImagesImpl 
    {
        /// <returns>entry point to virtual machine extension image publishers</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublishers Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImages.Publishers () {
            return this.Publishers() as Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublishers;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">region the selected Azure region</param>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage>.ListByRegion (Region region) {
            return this.ListByRegion( region) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">regionName the name of an Azure region</param>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage>.ListByRegion (string regionName) {
            return this.ListByRegion( regionName) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage>;
        }

    }
}