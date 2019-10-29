// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    public partial class ImageReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageReference"/> class.
        /// </summary>
        /// <param name='offer'>The offer type of the Azure Virtual Machines Marketplace image.</param>
        /// <param name='publisher'>The publisher of the Azure Virtual Machines Marketplace image.</param>
        /// <param name='sku'>The SKU of the Azure Virtual Machines Marketplace image.</param>
        /// <param name='version'>The version of the Azure Virtual Machines Marketplace image.</param>
        public ImageReference(
            string offer,
            string publisher,
            string sku,
            string version = default(string))
        {
            this.Offer = offer;
            this.Publisher = publisher;
            this.Sku = sku;
            this.Version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageReference"/> class.
        /// </summary>
        /// <param name="virtualMachineImageId">
        /// The ARM resource identifier of the Virtual Machine Image or Shared Image Gallery Image. Computes Compute Nodes of the Pool will be created using this Image Id. 
        /// This is of either the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/images/{imageName} for Virtual Machine Image or 
        /// /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/galleries/{galleryName}/images/{imageDefinitionName}/versions/{versionId} for SIG image.
        /// </param>
        public ImageReference(
            string virtualMachineImageId)
        {
            this.VirtualMachineImageId = virtualMachineImageId;
        }
    }
}
