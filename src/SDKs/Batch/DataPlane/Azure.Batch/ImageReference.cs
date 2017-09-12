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
            this.offer = offer;
            this.publisher = publisher;
            this.sku = sku;
            this.version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageReference"/> class.
        /// </summary>
        /// <param name="virtualMachineImageId">
        /// The ARM resource identifier of the virtual machine image. Computes nodes of the pool will be created using
        /// this custom image. This is of the form /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Compute/images/{imageName}
        /// </param>
        public ImageReference(
            string virtualMachineImageId)
        {
            this.virtualMachineImageId = virtualMachineImageId;
        }
    }
}
