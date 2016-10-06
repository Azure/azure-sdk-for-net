// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{

    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine image.
    /// </summary>
    public interface IVirtualMachineImage  :
        IWrapper<Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineImageInner>
    {
        /// <returns>the region in which virtual machine image is available</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Location { get; }

        /// <returns>the publisher name of the virtual machine image</returns>
        string PublisherName { get; }

        /// <returns>the name of the virtual machine image offer this image is part of</returns>
        string Offer { get; }

        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Sku { get; }

        /// <returns>the version of the virtual machine image</returns>
        string Version { get; }

        /// <returns>the image reference representing the publisher, offer, SKU and version of the virtual machine image</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.ImageReference ImageReference { get; }

        /// <returns>the purchase plan for the virtual machine image</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.PurchasePlan Plan { get; }

        /// <returns>OS disk image in the virtual machine image</returns>
        Microsoft.Azure.Management.Compute.Fluent.Models.OSDiskImage OsDiskImage { get; }

        /// <returns>data disk images in the virtual machine image</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Fluent.Models.DataDiskImage> DataDiskImages { get; }

    }
}