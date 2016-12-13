// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine image.
    /// </summary>
    public interface IVirtualMachineImage  :
        IWrapper<Models.VirtualMachineImageInner>
    {
        /// <summary>
        /// Gets the name of the virtual machine image offer this image is part of.
        /// </summary>
        string Offer { get; }

        /// <summary>
        /// Gets OS disk image in the virtual machine image.
        /// </summary>
        Models.OSDiskImage OsDiskImage { get; }

        /// <summary>
        /// Gets the publisher name of the virtual machine image.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets the region in which virtual machine image is available.
        /// </summary>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Location { get; }

        /// <summary>
        /// Gets the commercial name of the virtual machine image (SKU).
        /// </summary>
        string Sku { get; }

        /// <summary>
        /// Gets the image reference representing the publisher, offer, SKU and version of the virtual machine image.
        /// </summary>
        Models.ImageReference ImageReference { get; }

        /// <summary>
        /// Gets data disk images in the virtual machine image.
        /// </summary>
        System.Collections.Generic.IList<Models.DataDiskImage> DataDiskImages { get; }

        /// <summary>
        /// Gets the version of the virtual machine image.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the purchase plan for the virtual machine image.
        /// </summary>
        Models.PurchasePlan Plan { get; }
    }
}