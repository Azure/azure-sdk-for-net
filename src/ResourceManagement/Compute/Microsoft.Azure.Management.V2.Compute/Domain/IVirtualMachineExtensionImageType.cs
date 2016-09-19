using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Compute
{
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine extension image type.
    /// </summary>
    public interface IVirtualMachineExtensionImageType : IWrapper<VirtualMachineExtensionImageInner>
    {
        /// <returns>The resource ID of the extension image</returns>
        string Id { get; }

        /// <returns>the region in which virtual machine extension image is available</returns>
        string RegionName { get; }

        /// <returns>the name of the publisher of the virtual machine extension image</returns>
        IVirtualMachinePublisher Publisher { get; }

        /// <returns>Virtual machine image extension versions available in this type</returns>
        IVirtualMachineExtensionImageVersions Versions { get; }
    }
}
