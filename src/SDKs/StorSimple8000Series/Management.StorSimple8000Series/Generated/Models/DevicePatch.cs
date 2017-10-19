
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The device patch.
    /// </summary>
    [JsonTransformation]
    public partial class DevicePatch
    {
        /// <summary>
        /// Initializes a new instance of the DevicePatch class.
        /// </summary>
        public DevicePatch() { }

        /// <summary>
        /// Initializes a new instance of the DevicePatch class.
        /// </summary>
        /// <param name="deviceDescription">Short description given for the
        /// device</param>
        public DevicePatch(string deviceDescription = default(string))
        {
            DeviceDescription = deviceDescription;
        }

        /// <summary>
        /// Gets or sets short description given for the device
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceDescription")]
        public string DeviceDescription { get; set; }

    }
}

