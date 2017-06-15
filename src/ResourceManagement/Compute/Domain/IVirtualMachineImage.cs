// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure virtual machine image.
    /// </summary>
    public interface IVirtualMachineImage  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.VirtualMachineImageInner>
    {
        /// <summary>
        /// Gets the resource ID of this image.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the purchase plan for the virtual machine image.
        /// </summary>
        Models.PurchasePlan Plan { get; }

        /// <summary>
        /// Gets the publisher name of the virtual machine image.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets the region in which virtual machine image is available.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Location { get; }

        /// <summary>
        /// Gets the image reference representing the publisher, offer, SKU and version of the virtual machine image.
        /// </summary>
        ImageReference ImageReference { get; }

        /// <summary>
        /// Gets the name of the virtual machine image offer this image is part of.
        /// </summary>
        string Offer { get; }

        /// <summary>
        /// Gets the commercial name of the virtual machine image (SKU).
        /// </summary>
        string Sku { get; }

        /// <summary>
        /// Gets data disk images in the virtual machine image, indexed by the disk LUN.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<int,Models.DataDiskImage> DataDiskImages { get; }

        /// <summary>
        /// Gets OS disk image in the virtual machine image.
        /// </summary>
        Models.OSDiskImage OSDiskImage { get; }

        /// <summary>
        /// Gets the version of the virtual machine image.
        /// </summary>
        string Version { get; }
    }
}