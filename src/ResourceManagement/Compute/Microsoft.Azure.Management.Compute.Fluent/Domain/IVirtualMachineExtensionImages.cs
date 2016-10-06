// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    /// <summary>
    /// Entry point to virtual machine extension image management API.
    /// </summary>
    public interface IVirtualMachineExtensionImages  :
        ISupportsListingByRegion<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>
    {
        /// <returns>entry point to virtual machine extension image publishers</returns>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublishers Publishers { get; }

    }
}