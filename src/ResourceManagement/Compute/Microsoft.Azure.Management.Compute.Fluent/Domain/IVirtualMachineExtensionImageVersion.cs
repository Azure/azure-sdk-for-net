// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image version.
    /// </summary>
    public interface IVirtualMachineExtensionImageVersion :
        IWrapper<Models.VirtualMachineExtensionImageInner>,
        IHasName
    {
        /// <return>The region in which virtual machine extension image version is available.</return>
        string RegionName { get; }

        /// <return>The resource ID of the extension image version.</return>
        string Id { get; }

        /// <return>The virtual machine extension image type this version belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType Type { get; }

        /// <return>Virtual machine extension image this version represents.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage GetImage();
    }
}