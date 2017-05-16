// %~6

namespace Microsoft.Azure.Management.Relay.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Relay;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Sku of the Namespace.
    /// </summary>
    public partial class Sku
    {
        /// <summary>
        /// Initializes a new instance of the Sku class.
        /// </summary>
        public Sku()
        {
          CustomInit();
        }

        /// <summary>
        /// Static constructor for Sku class.
        /// </summary>
        static Sku()
        {
            Name = "Standard";
            Tier = "Standard";
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Name of this Sku
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public static string Name { get; private set; }

        /// <summary>
        /// The tier of this particular SKU
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public static string Tier { get; private set; }

    }
}
