// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VirtualMachineExtensionImageVersionImpl 
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

        /// <return>Virtual machine extension image this version represents.</return>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.GetImage()
        {
            return this.GetImage() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage;
        }

        /// <return>Virtual machine extension image this version represents.</return>
        Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersionBeta.GetImageAsync(CancellationToken cancellationToken)
        {
            return this.GetImageAsync(cancellationToken) as Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImage>;
        }

        /// <summary>
        /// Gets the virtual machine extension image type this version belongs to.
        /// </summary>
        Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.Type
        {
            get
            {
                return this.Type() as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageType;
            }
        }

        /// <summary>
        /// Gets the region in which virtual machine extension image version is available.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the resource ID of the extension image version.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionImageVersion.Id
        {
            get
            {
                return this.Id();
            }
        }
    }
}