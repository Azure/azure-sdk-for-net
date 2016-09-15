/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using System.Collections.Generic;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    public partial class VirtualMachineImageImpl 
    {
        /// <returns>description of the OS Disk image in the virtual machine image.</returns>
        Microsoft.Azure.Management.Compute.Models.OSDiskImage Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.OsDiskImage
        {
            get
            {
                return this.OsDiskImage as Microsoft.Azure.Management.Compute.Models.OSDiskImage;
            }
        }
        /// <returns>the version of the virtual machine image</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.Version
        {
            get
            {
                return this.Version as string;
            }
        }
        /// <returns>the publisher name of the virtual machine image</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.PublisherName
        {
            get
            {
                return this.PublisherName as string;
            }
        }
        /// <returns>the commercial name of the virtual machine image (SKU)</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.Sku
        {
            get
            {
                return this.Sku as string;
            }
        }
        /// <returns>the purchase plan for the virtual machine image.</returns>
        Microsoft.Azure.Management.Compute.Models.PurchasePlan Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.Plan
        {
            get
            {
                return this.Plan as Microsoft.Azure.Management.Compute.Models.PurchasePlan;
            }
        }
        /// <returns>description of the Data disk images in the virtual machine.</returns>
        System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.DataDiskImage> Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.DataDiskImages
        {
            get
            {
                return this.DataDiskImages as System.Collections.Generic.IList<Microsoft.Azure.Management.Compute.Models.DataDiskImage>;
            }
        }
        /// <returns>the name of the virtual machine image offer this image is part of</returns>
        string Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.Offer
        {
            get
            {
                return this.Offer as string;
            }
        }
        /// <returns>the region in which virtual machine image is available</returns>
        Microsoft.Azure.Management.V2.Resource.Core.Region? Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.Location
        {
            get
            {
                return this.Location;
            }
        }
        /// <returns>the image reference representing publisher, offer, sku and version of the virtual machine image</returns>
        Microsoft.Azure.Management.Compute.Models.ImageReference Microsoft.Azure.Management.V2.Compute.IVirtualMachineImage.ImageReference
        {
            get
            {
                return this.ImageReference as Microsoft.Azure.Management.Compute.Models.ImageReference;
            }
        }
    }
}