namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The image reference.
    /// </summary>
    public partial class ImageReference
    {
        /// <summary>
        /// Gets or sets the image publisher.
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the image offer.
        /// </summary>
        [JsonProperty(PropertyName = "offer")]
        public string Offer { get; set; }

        /// <summary>
        /// Gets or sets the image sku.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the image version. The allowed formats are
        /// Major.Minor.Build or 'latest'. Major, Minor and Build being
        /// decimal numbers. Specify 'latest' to use the latest version of
        /// image.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

    }
}
