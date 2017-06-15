// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using ResourceManager.Fluent.Core;
    using System.Linq;

    /// <summary>
    /// The image reference.
    /// </summary>
    public partial class ImageReference : Wrapper<ImageReferenceInner>
    {
        /// <summary>
        /// Creates ImageReference.
        /// </summary>
        public ImageReference() : base(null) { }

        /// <summary>
        /// Creates ImageReference.
        /// </summary>
        /// <param name="inner">the inner object</param>
        public ImageReference(ImageReferenceInner inner) : base(inner)
        {

            Publisher = inner.Publisher;
            Offer = inner.Offer;
            Sku = inner.Sku;
            Version = inner.Version;
            Id = inner.Id;
        }

        public override ImageReferenceInner Inner
        {
            get
            {
                if (base.Inner != null)
                {
                    return base.Inner;
                }
                ImageReferenceInner imageReferenceInner = new ImageReferenceInner()
                {
                    Publisher = this.Publisher,
                    Offer = this.Offer,
                    Version = this.Version,
                    Sku = this.Sku,
                    Id = this.Id
                };
                return imageReferenceInner;
            }
        }

        /// <summary>
        /// Gets or sets the image publisher.
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the image offer.
        /// </summary>
        public string Offer { get; set; }

        /// <summary>
        /// Gets or sets the image sku.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the image version. The allowed formats are
        /// Major.Minor.Build or 'latest'. Major, Minor and Build being
        /// decimal numbers. Specify 'latest' to use the latest version of
        /// image.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Image resource id.
        /// </summary>
        private string Id;
    }
}