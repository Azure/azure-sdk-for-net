/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    /// <summary>
    /// Entry point to virtual machine image management API.
    /// </summary>
    public interface IVirtualMachineImages  :
        ISupportsListingByRegion<IVirtualMachineImage>
    {
        /// <returns>entry point to virtual machine image publishers</returns>
        IVirtualMachinePublishers Publishers ();

        /// <summary>
        /// Lists all the virtual machine images available in a given region.
        /// <p>
        /// Note this is a very long running call, as it enumerates through all publishers, offers and skus.
        /// </summary>
        /// <returns>list of virtual machine images</returns>
        /// <param name="regionName">regionName the name of the region as used internally by Azure</param>
        PagedList<IVirtualMachineImage> ListByRegion (string regionName);

        /// <summary>
        /// Lists all the virtual machine images available in a given region.
        /// <p>
        /// Note this is a very long running call, as it enumerates through all publishers, offers and skus.
        /// </summary>
        /// <returns>list of virtual machine images</returns>
        /// <param name="region">region the region to list the images from</param>
        PagedList<IVirtualMachineImage> ListByRegion (Region region);

    }
}