// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;

    internal partial class VirtualMachineExtensionImageVersionImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>Virtual machine extension image this version represents.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.GetImage()
        {
            return this.GetImage() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage;
        }

        /// <return>The virtual machine extension image type this version belongs to.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.Type
        {
            get
            {
                return this.Type() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType;
            }
        }

        /// <return>The region in which virtual machine extension image version is available.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.RegionName
        {
            get
            {
                return this.RegionName() as string;
            }
        }

        /// <return>The resource ID of the extension image version.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.Id
        {
            get
            {
                return this.Id() as string;
            }
        }
    }
}