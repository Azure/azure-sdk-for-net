
namespace Microsoft.Azure.Management.PowerBIEmbedded.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class AzureSku
    {
        /// <summary>
        /// Initializes a new instance of the AzureSku class.
        /// </summary>
        public AzureSku() { }

        /// <summary>
        /// Static constructor for AzureSku class.
        /// </summary>
        static AzureSku()
        {
            Name = "S1";
            Tier = "Standard";
        }

        /// <summary>
        /// SKU name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public static string Name { get; private set; }

        /// <summary>
        /// SKU tier
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public static string Tier { get; private set; }

    }
}
