/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{
    using Microsoft.Azure.Management.Compute.Models ;
    using Microsoft.Azure.Management.V2.Resource.Core;
    public partial class VirtualMachineExtensionImageTypeImpl 
    {
        /// <returns>Virtual machine image extension versions available in this type</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersions Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType.Versions {
            get
            {
                return this.Versions as Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageVersions;
            }
        }

        /// <returns>the name of the virtual machine extension image type</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType.Name
        {
            get
            {
                return this.Name as string;
            }
        }
        /// <returns>the publisher of this virtual machine extension image type</returns>
        Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType.Publisher {
            get
            {
                return this.Publisher as Microsoft.Azure.Management.V2.Compute.IVirtualMachinePublisher;
            }
        }

        /// <returns>the region in which virtual machine extension image type is available</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType.RegionName
        {
            get
            {
                return this.RegionName as string;
            }
        }
        /// <returns>the resource ID of the virtual machine extension image type</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineExtensionImageType.Id
        {
            get
            {
                return this.Id as string;
            }
        }
    }
}