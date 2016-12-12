// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine image.
    /// </summary>
    public interface IVirtualMachineImage :
        IWrapper<Models.VirtualMachineImageInner>
    {
        /// <return>The name of the virtual machine image offer this image is part of.</return>
        string Offer { get; }

        /// <return>OS disk image in the virtual machine image.</return>
        Models.OSDiskImage OsDiskImage { get; }

        /// <return>The publisher name of the virtual machine image.</return>
        string PublisherName { get; }

        /// <return>The region in which virtual machine image is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Location { get; }

        /// <return>The commercial name of the virtual machine image (SKU).</return>
        string Sku { get; }

        /// <return>The image reference representing the publisher, offer, SKU and version of the virtual machine image.</return>
        Models.ImageReference ImageReference { get; }

        /// <return>Data disk images in the virtual machine image.</return>
        System.Collections.Generic.IList<Models.DataDiskImage> DataDiskImages { get; }

        /// <return>The version of the virtual machine image.</return>
        string Version { get; }

        /// <return>The purchase plan for the virtual machine image.</return>
        Models.PurchasePlan Plan { get; }
    }
}