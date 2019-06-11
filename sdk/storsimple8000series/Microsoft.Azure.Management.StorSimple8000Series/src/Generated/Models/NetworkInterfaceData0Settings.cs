
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The 'Data 0' network interface card settings.
    /// </summary>
    public partial class NetworkInterfaceData0Settings
    {
        /// <summary>
        /// Initializes a new instance of the NetworkInterfaceData0Settings
        /// class.
        /// </summary>
        public NetworkInterfaceData0Settings() { }

        /// <summary>
        /// Initializes a new instance of the NetworkInterfaceData0Settings
        /// class.
        /// </summary>
        /// <param name="controllerZeroIp">The controller 0's IPv4
        /// address.</param>
        /// <param name="controllerOneIp">The controller 1's IPv4
        /// address.</param>
        public NetworkInterfaceData0Settings(string controllerZeroIp = default(string), string controllerOneIp = default(string))
        {
            ControllerZeroIp = controllerZeroIp;
            ControllerOneIp = controllerOneIp;
        }

        /// <summary>
        /// Gets or sets the controller 0's IPv4 address.
        /// </summary>
        [JsonProperty(PropertyName = "controllerZeroIp")]
        public string ControllerZeroIp { get; set; }

        /// <summary>
        /// Gets or sets the controller 1's IPv4 address.
        /// </summary>
        [JsonProperty(PropertyName = "controllerOneIp")]
        public string ControllerOneIp { get; set; }

    }
}

