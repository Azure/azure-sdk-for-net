/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    /// <summary>
    /// Entry point to virtual machine image offer skus.
    /// </summary>
    public interface IVirtualMachineSkus  :
        ISupportsListing<IVirtualMachineSku>
    {
    }
}