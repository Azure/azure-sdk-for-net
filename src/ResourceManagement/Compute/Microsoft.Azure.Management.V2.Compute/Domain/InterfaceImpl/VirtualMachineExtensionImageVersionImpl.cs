// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models ;
    public partial class VirtualMachineExtensionImageVersionImpl 
    {
        /// <returns>the name of the virtual machine extension image version</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>the virtual machine extension image type this version belongs to</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion.Type {
            get
            {
                return this.Type as Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType;
            }
        }

        /// <returns>virtual machine extension image this version represents</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion.Image () {
            return this.Image() as Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImage;
        }

        /// <returns>the region in which virtual machine extension image version is available</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion.RegionName
        {
            get
            {
                return this.RegionName as string;
            }
        }
        /// <returns>the resource ID of the extension image version</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersion.Id
        {
            get
            {
                return this.Id as string;
            }
        }
    }
}