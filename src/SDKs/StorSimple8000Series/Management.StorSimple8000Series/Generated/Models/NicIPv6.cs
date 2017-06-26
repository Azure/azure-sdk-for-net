
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Details related to the IPv6 address configuration.
    /// </summary>
    public partial class NicIPv6
    {
        /// <summary>
        /// Initializes a new instance of the NicIPv6 class.
        /// </summary>
        public NicIPv6() { }

        /// <summary>
        /// Initializes a new instance of the NicIPv6 class.
        /// </summary>
        /// <param name="ipv6Address">The IPv6 address of the network
        /// adapter.</param>
        /// <param name="ipv6Prefix">The IPv6 prefix of the network
        /// adapter.</param>
        /// <param name="ipv6Gateway">The IPv6 gateway of the network
        /// adapter.</param>
        /// <param name="controller0Ipv6Address">The IPv6 address of
        /// Controller0.</param>
        /// <param name="controller1Ipv6Address">The IPv6 address of
        /// Controller1.</param>
        public NicIPv6(string ipv6Address = default(string), string ipv6Prefix = default(string), string ipv6Gateway = default(string), string controller0Ipv6Address = default(string), string controller1Ipv6Address = default(string))
        {
            Ipv6Address = ipv6Address;
            Ipv6Prefix = ipv6Prefix;
            Ipv6Gateway = ipv6Gateway;
            Controller0Ipv6Address = controller0Ipv6Address;
            Controller1Ipv6Address = controller1Ipv6Address;
        }

        /// <summary>
        /// Gets or sets the IPv6 address of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv6Address")]
        public string Ipv6Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 prefix of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv6Prefix")]
        public string Ipv6Prefix { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 gateway of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "ipv6Gateway")]
        public string Ipv6Gateway { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 address of Controller0.
        /// </summary>
        [JsonProperty(PropertyName = "controller0Ipv6Address")]
        public string Controller0Ipv6Address { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 address of Controller1.
        /// </summary>
        [JsonProperty(PropertyName = "controller1Ipv6Address")]
        public string Controller1Ipv6Address { get; set; }

    }
}

