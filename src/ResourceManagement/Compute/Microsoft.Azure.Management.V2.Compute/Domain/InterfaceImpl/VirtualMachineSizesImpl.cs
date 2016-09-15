/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    public partial class VirtualMachineSizesImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="region">region the selected Azure region</param>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize>.ListByRegion (Region region) {
            return this.ListByRegion( region) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize>;
        }

        /// <summary>
        /// List all the resources of the specified type in the specified region.
        /// </summary>
        /// <param name="regionName">regionName the name of an Azure region</param>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListingByRegion<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize>.ListByRegion (string regionName) {
            return this.ListByRegion( regionName) as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSize>;
        }

    }
}