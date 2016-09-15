/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    public partial class VirtualMachineImagesImpl 
    {
        /// <summary>
        /// Lists all the virtual machine images available in a given region.
        /// <p>
        /// Note this is a very long running call, as it enumerates through all publishers, offers and skus.
        /// </summary>
        /// <returns>list of virtual machine images</returns>
        /// <param name="region">region the region to list the images from</param>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage> Microsoft.Azure.Management.V2.Compute.IVirtualMachineImages.ListByRegion (Region region) {
            return this.ListByRegion( region) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage>;
        }

        /// <summary>
        /// Lists all the virtual machine images available in a given region.
        /// <p>
        /// Note this is a very long running call, as it enumerates through all publishers, offers and skus.
        /// </summary>
        /// <returns>list of virtual machine images</returns>
        /// <param name="regionName">regionName the name of the region as used internally by Azure</param>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage> Microsoft.Azure.Management.V2.Compute.IVirtualMachineImages.ListByRegion (string regionName) {
            return this.ListByRegion( regionName) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage>;
        }

        /// <returns>entry point to virtual machine image publishers</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublishers Microsoft.Azure.Management.V2.Compute.IVirtualMachineImages.Publishers () {
            return this.Publishers() as Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublishers;
        }

    }
}