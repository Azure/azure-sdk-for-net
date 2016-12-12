// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image type.
    /// </summary>
    public interface IVirtualMachineExtensionImageType :
        IWrapper<Models.VirtualMachineExtensionImageInner>,
        IHasName
    {
        /// <return>Virtual machine image extension versions available in this type.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions Versions { get; }

        /// <return>The region in which virtual machine extension image type is available.</return>
        string RegionName { get; }

        /// <return>The publisher of this virtual machine extension image type.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Publisher { get; }

        /// <return>The resource ID of the virtual machine extension image type.</return>
        string Id { get; }
    }
}