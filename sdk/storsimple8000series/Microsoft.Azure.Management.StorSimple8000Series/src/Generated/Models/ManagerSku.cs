
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The Sku.
    /// </summary>
    public partial class ManagerSku
    {
        /// <summary>
        /// Initializes a new instance of the ManagerSku class.
        /// </summary>
        public ManagerSku() { }

        /// <summary>
        /// Static constructor for ManagerSku class.
        /// </summary>
        static ManagerSku()
        {
            Name = "Standard";
        }

        /// <summary>
        /// Refers to the sku name which should be "Standard"
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public static string Name { get; private set; }

    }
}

