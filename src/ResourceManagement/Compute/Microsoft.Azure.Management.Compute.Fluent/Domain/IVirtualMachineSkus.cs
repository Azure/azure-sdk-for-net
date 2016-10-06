// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    /// <summary>
    /// Entry point to virtual machine image offer skus.
    /// </summary>
    public interface IVirtualMachineSkus  :
        ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSku>
    {
    }
}