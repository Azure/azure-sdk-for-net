/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Compute.Models;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine image.
    /// </summary>
    public interface IVirtualMachineImage  :
        IWrapper<VirtualMachineImageInner>
    {
        /// <returns>the region in which virtual machine image is available</returns>
        Region? Location { get; }

        /// <returns>the publisher name of the virtual machine image</returns>
        string PublisherName { get; }

        /// <returns>the name of the virtual machine image offer this image is part of</returns>
        string Offer { get; }

        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Sku { get; }

        /// <returns>the version of the virtual machine image</returns>
        string Version { get; }

        /// <returns>the image reference representing publisher, offer, sku and version of the virtual machine image</returns>
        ImageReference ImageReference { get; }

        /// <returns>the purchase plan for the virtual machine image.</returns>
        PurchasePlan Plan { get; }

        /// <returns>description of the OS Disk image in the virtual machine image.</returns>
        OSDiskImage OsDiskImage { get; }

        /// <returns>description of the Data disk images in the virtual machine.</returns>
        IList<DataDiskImage> DataDiskImages { get; }

    }
}