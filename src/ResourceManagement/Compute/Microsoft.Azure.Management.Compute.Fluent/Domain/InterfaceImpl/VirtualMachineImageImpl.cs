// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;

    internal partial class VirtualMachineImageImpl
    {
        /// <return>OS disk image in the virtual machine image.</return>
        Models.OSDiskImage Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.OsDiskImage
        {
            get
            {
                return this.OsDiskImage() as Models.OSDiskImage;
            }
        }

        /// <return>The version of the virtual machine image.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.Version
        {
            get
            {
                return this.Version() as string;
            }
        }

        /// <return>The publisher name of the virtual machine image.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.PublisherName
        {
            get
            {
                return this.PublisherName() as string;
            }
        }

        /// <return>The commercial name of the virtual machine image (SKU).</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.Sku
        {
            get
            {
                return this.Sku() as string;
            }
        }

        /// <return>The purchase plan for the virtual machine image.</return>
        Models.PurchasePlan Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.Plan
        {
            get
            {
                return this.Plan() as Models.PurchasePlan;
            }
        }

        /// <return>Data disk images in the virtual machine image.</return>
        System.Collections.Generic.IList<Models.DataDiskImage> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.DataDiskImages
        {
            get
            {
                return this.DataDiskImages() as System.Collections.Generic.IList<Models.DataDiskImage>;
            }
        }

        /// <return>The name of the virtual machine image offer this image is part of.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.Offer
        {
            get
            {
                return this.Offer() as string;
            }
        }

        /// <return>The region in which virtual machine image is available.</return>
        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.Location
        {
            get
            {
                return this.Location() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }

        /// <return>The image reference representing the publisher, offer, SKU and version of the virtual machine image.</return>
        Models.ImageReference Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineImage.ImageReference
        {
            get
            {
                return this.ImageReference() as Models.ImageReference;
            }
        }
    }
}