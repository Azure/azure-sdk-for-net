
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
    /// The mandatory device configuration request.
    /// </summary>
    [JsonTransformation]
    public partial class ConfigureDeviceRequest : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the ConfigureDeviceRequest class.
        /// </summary>
        public ConfigureDeviceRequest() { }

        /// <summary>
        /// Initializes a new instance of the ConfigureDeviceRequest class.
        /// </summary>
        /// <param name="friendlyName">The friendly name for the
        /// device.</param>
        /// <param name="currentDeviceName">The current name of the
        /// device.</param>
        /// <param name="timeZone">The device time zone. For eg: "Pacific
        /// Standard Time"</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="dnsSettings">The secondary DNS Settings of the
        /// device.</param>
        /// <param name="networkInterfaceData0Settings">The 'Data 0' network
        /// interface card settings.</param>
        public ConfigureDeviceRequest(string friendlyName, string currentDeviceName, string timeZone, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), SecondaryDNSSettings dnsSettings = default(SecondaryDNSSettings), NetworkInterfaceData0Settings networkInterfaceData0Settings = default(NetworkInterfaceData0Settings))
            : base(id, name, type, kind)
        {
            FriendlyName = friendlyName;
            CurrentDeviceName = currentDeviceName;
            TimeZone = timeZone;
            DnsSettings = dnsSettings;
            NetworkInterfaceData0Settings = networkInterfaceData0Settings;
        }

        /// <summary>
        /// Gets or sets the friendly name for the device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the current name of the device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.currentDeviceName")]
        public string CurrentDeviceName { get; set; }

        /// <summary>
        /// Gets or sets the device time zone. For eg: "Pacific Standard Time"
        /// </summary>
        [JsonProperty(PropertyName = "properties.timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the secondary DNS Settings of the device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dnsSettings")]
        public SecondaryDNSSettings DnsSettings { get; set; }

        /// <summary>
        /// Gets or sets the 'Data 0' network interface card settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkInterfaceData0Settings")]
        public NetworkInterfaceData0Settings NetworkInterfaceData0Settings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (FriendlyName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FriendlyName");
            }
            if (CurrentDeviceName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CurrentDeviceName");
            }
            if (TimeZone == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TimeZone");
            }
        }
    }
}

