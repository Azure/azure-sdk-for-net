// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class VirtualMachineExtensionImageTypeImpl 
    {
        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets Virtual machine image extension versions available in this type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Versions
        {
            get
            {
                return this.Versions() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersions;
            }
        }

        /// <summary>
        /// Gets the publisher of this virtual machine extension image type.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Publisher
        {
            get
            {
                return this.Publisher() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachinePublisher;
            }
        }

        /// <summary>
        /// Gets the region in which virtual machine extension image type is available.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the virtual machine extension image type.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}