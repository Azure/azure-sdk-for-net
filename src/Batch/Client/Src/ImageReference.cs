namespace Microsoft.Azure.Batch
{
    using System;

    public partial class ImageReference
    {
        /// <summary>
        /// Gets the sku of the image.
        /// </summary>
        [Obsolete("Use Sku instead.")]
        public string SkuId
        {
            get { return this.sku; }
        }
    }
}
