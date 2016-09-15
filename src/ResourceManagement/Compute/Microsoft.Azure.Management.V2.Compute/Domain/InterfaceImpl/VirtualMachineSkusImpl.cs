/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    public partial class VirtualMachineSkusImpl 
    {
        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku> Microsoft.Azure.Management.V2.Resource.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku>.List () {
            return this.List() as Microsoft.Azure.Management.V2.Resource.Core.PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineSku>;
        }

    }
}