
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
    /// Represents the patch request for the network settings of a device.
    /// </summary>
    [JsonTransformation]
    public partial class NetworkSettingsPatch
    {
        /// <summary>
        /// Initializes a new instance of the NetworkSettingsPatch class.
        /// </summary>
        public NetworkSettingsPatch() { }

        /// <summary>
        /// Initializes a new instance of the NetworkSettingsPatch class.
        /// </summary>
        /// <param name="dnsSettings">The DNS (Domain Name System) settings of
        /// device.</param>
        /// <param name="networkAdapters">The network adapter list of
        /// device.</param>
        public NetworkSettingsPatch(DNSSettings dnsSettings = default(DNSSettings), NetworkAdapterList networkAdapters = default(NetworkAdapterList))
        {
            DnsSettings = dnsSettings;
            NetworkAdapters = networkAdapters;
        }

        /// <summary>
        /// Gets or sets the DNS (Domain Name System) settings of device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dnsSettings")]
        public DNSSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets or sets the network adapter list of device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkAdapters")]
        public NetworkAdapterList NetworkAdapters { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NetworkAdapters != null)
            {
                NetworkAdapters.Validate();
            }
        }
    }
}

