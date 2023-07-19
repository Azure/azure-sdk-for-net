
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The OData filter to be used for features.
    /// </summary>
    public partial class FeatureFilter
    {
        /// <summary>
        /// Initializes a new instance of the FeatureFilter class.
        /// </summary>
        public FeatureFilter() { }

        /// <summary>
        /// Initializes a new instance of the FeatureFilter class.
        /// </summary>
        /// <param name="deviceId">Specifies the device ID for which the
        /// features are required. Only 'Equality' operator is supported for
        /// this property.</param>
        public FeatureFilter(string deviceId = default(string))
        {
            DeviceId = deviceId;
        }

        /// <summary>
        /// Gets or sets specifies the device ID for which the features are
        /// required. Only 'Equality' operator is supported for this property.
        /// </summary>
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }

    }
}

