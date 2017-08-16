
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents the network adapter on device.
    /// </summary>
    public partial class NetworkAdapters
    {
        /// <summary>
        /// Initializes a new instance of the NetworkAdapters class.
        /// </summary>
        public NetworkAdapters() { }

        /// <summary>
        /// Initializes a new instance of the NetworkAdapters class.
        /// </summary>
        /// <param name="interfaceId">The ID of the network adapter. Possible
        /// values include: 'Invalid', 'Data0', 'Data1', 'Data2', 'Data3',
        /// 'Data4', 'Data5'</param>
        /// <param name="netInterfaceStatus">Value indicating status of network
        /// adapter. Possible values include: 'Enabled', 'Disabled'</param>
        /// <param name="iscsiAndCloudStatus">Value indicating cloud and ISCSI
        /// status of network adapter. Possible values include: 'Disabled',
        /// 'IscsiEnabled', 'CloudEnabled', 'IscsiAndCloudEnabled'</param>
        /// <param name="mode">The mode of network adapter, either IPv4, IPv6
        /// or both. Possible values include: 'Invalid', 'IPV4', 'IPV6',
        /// 'BOTH'</param>
        /// <param name="isDefault">Value indicating whether this instance is
        /// default.</param>
        /// <param name="speed">The speed of the network adapter.</param>
        /// <param name="nicIpv4Settings">The IPv4 configuration of the network
        /// adapter.</param>
        /// <param name="nicIpv6Settings">The IPv6 configuration of the network
        /// adapter.</param>
        public NetworkAdapters(NetInterfaceId interfaceId, NetInterfaceStatus netInterfaceStatus, ISCSIAndCloudStatus iscsiAndCloudStatus, NetworkMode mode, bool? isDefault = default(bool?), long? speed = default(long?), NicIPv4 nicIpv4Settings = default(NicIPv4), NicIPv6 nicIpv6Settings = default(NicIPv6))
        {
            InterfaceId = interfaceId;
            NetInterfaceStatus = netInterfaceStatus;
            IsDefault = isDefault;
            IscsiAndCloudStatus = iscsiAndCloudStatus;
            Speed = speed;
            Mode = mode;
            NicIpv4Settings = nicIpv4Settings;
            NicIpv6Settings = nicIpv6Settings;
        }

        /// <summary>
        /// Gets or sets the ID of the network adapter. Possible values
        /// include: 'Invalid', 'Data0', 'Data1', 'Data2', 'Data3', 'Data4',
        /// 'Data5'
        /// </summary>
        [JsonProperty(PropertyName = "interfaceId")]
        public NetInterfaceId InterfaceId { get; set; }

        /// <summary>
        /// Gets or sets value indicating status of network adapter. Possible
        /// values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "netInterfaceStatus")]
        public NetInterfaceStatus NetInterfaceStatus { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether this instance is default.
        /// </summary>
        [JsonProperty(PropertyName = "isDefault")]
        public bool? IsDefault { get; set; }

        /// <summary>
        /// Gets or sets value indicating cloud and ISCSI status of network
        /// adapter. Possible values include: 'Disabled', 'IscsiEnabled',
        /// 'CloudEnabled', 'IscsiAndCloudEnabled'
        /// </summary>
        [JsonProperty(PropertyName = "iscsiAndCloudStatus")]
        public ISCSIAndCloudStatus IscsiAndCloudStatus { get; set; }

        /// <summary>
        /// Gets or sets the speed of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "speed")]
        public long? Speed { get; set; }

        /// <summary>
        /// Gets or sets the mode of network adapter, either IPv4, IPv6 or
        /// both. Possible values include: 'Invalid', 'IPV4', 'IPV6', 'BOTH'
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public NetworkMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the IPv4 configuration of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "nicIpv4Settings")]
        public NicIPv4 NicIpv4Settings { get; set; }

        /// <summary>
        /// Gets or sets the IPv6 configuration of the network adapter.
        /// </summary>
        [JsonProperty(PropertyName = "nicIpv6Settings")]
        public NicIPv6 NicIpv6Settings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

