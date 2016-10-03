// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Fluent.Compute
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    /// <summary>
    /// Entry point to virtual machine image management API.
    /// </summary>
    public interface IVirtualMachineImages  :
        ISupportsListingByRegion<Microsoft.Azure.Management.Fluent.Compute.IVirtualMachineImage>
    {
        /// <returns>entry point to virtual machine image publishers</returns>
        Microsoft.Azure.Management.Fluent.Compute.IVirtualMachinePublishers Publishers { get; }

    }
}