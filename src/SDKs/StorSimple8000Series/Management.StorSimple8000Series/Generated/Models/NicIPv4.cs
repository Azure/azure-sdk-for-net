
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Details related to the IPv4 address configuration.
    /// </summary>
    public partial class NicIPv4
    {
        /// <summary>
        /// Initializes a new instance of the NicIPv4 class.
        /// </summary>
        public NicIPv4() { }

        /// <summary>
        /// Initializes a new instance of the NicIPv4 class.
        /// </summary>
        /// <param name="ipv4Address">The IPv4 address of the network
        /// adapter.</param>
        /// <param name="ipv4Netmask">The IPv4 netmask of the network
        /// adapter.</param>
        /// <param name="ipv4Gateway">The IPv4 gateway of the network
        /// adapter.</param>
        /// <param name="controller0Ipv4Address">The IPv4 address of
        /// Controller0.</param>
        /// <param name="controller1Ipv4Address">The IPv4 address of
        /// Controller1.</param>
        public NicIPv4(string ipv4Address = default(string), string ipv4Netmask = default(string), string ipv4Gateway = default(string), string controller0Ipv4Address = default(string), string controller1Ipv4Address = default(string))
        {
            Ipv4Address = ipv4Address;
            Ipv4Netmask = ipv4Netmask;
            Ipv4Gateway = ipv4Gateway;
            Controller0Ipv4Address = controller0Ipv4Address;
            Controller1Ipv4Address = controller1Ipv4Address;
        }

        /// <summary>
        /// Gets or sets the IPv4 address of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv4Address")]
        public string Ipv4Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 netmask of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv4Netmask")]
        public string Ipv4Netmask { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 gateway of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv4Gateway")]
        public string Ipv4Gateway { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 address of Controller0.
        /// </summary>
        [JsonProperty(PropertyName = "controller0Ipv4Address")]
        public string Controller0Ipv4Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 address of Controller1.
        /// </summary>
        [JsonProperty(PropertyName = "controller1Ipv4Address")]
        public string Controller1Ipv4Address { get; set; }

    }
}

