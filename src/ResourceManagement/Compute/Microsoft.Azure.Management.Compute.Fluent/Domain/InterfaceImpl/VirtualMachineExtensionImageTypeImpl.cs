// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    internal partial class VirtualMachineExtensionImageTypeImpl
    {
        /// <return>The name of the resource.</return>
        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name() as string;
            }
        }

        /// <return>Virtual machine image extension versions available in this type.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Versions
        {
            get
            {
                return this.Versions() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions;
            }
        }

        /// <return>The publisher of this virtual machine extension image type.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <return>The region in which virtual machine extension image type is available.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.RegionName
        {
            get
            {
                return this.RegionName() as string;
            }
        }

        /// <return>The resource ID of the virtual machine extension image type.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Id
        {
            get
            {
                return this.Id() as string;
            }
        }
    }
}