/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image version.
    /// </summary>
    public interface IVirtualMachineExtensionImageVersion : IWrapper<VirtualMachineExtensionImageInner>
    {
        ///<returns>the resource ID of the extension image version</returns>
        string Id { get; }

        ///<returns>the name of the virtual machine extension image version</returns>
        string Name { get; }

        ///<returns> the region in which virtual machine extension image version is available</returns>
        string RegionName { get; }

        ///<returns> the virtual machine extension image type this version belongs to</returns>
        IVirtualMachineExtensionImageType Type { get; }

        ///<returns> virtual machine extension image this version represents</returns>
        IVirtualMachineExtensionImage image { get; }
    }
}
