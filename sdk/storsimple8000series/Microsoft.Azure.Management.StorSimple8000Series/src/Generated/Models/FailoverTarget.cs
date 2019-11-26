
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents the eligibility of a device as a failover target device.
    /// </summary>
    public partial class FailoverTarget
    {
        /// <summary>
        /// Initializes a new instance of the FailoverTarget class.
        /// </summary>
        public FailoverTarget() { }

        /// <summary>
        /// Initializes a new instance of the FailoverTarget class.
        /// </summary>
        /// <param name="deviceId">The path ID of the device.</param>
        /// <param name="deviceStatus">The status of the device. Possible
        /// values include: 'Unknown', 'Online', 'Offline', 'Deactivated',
        /// 'RequiresAttention', 'MaintenanceMode', 'Creating', 'Provisioning',
        /// 'Deactivating', 'Deleted', 'ReadyToSetup'</param>
        /// <param name="modelDescription">The model number of the
        /// device.</param>
        /// <param name="deviceSoftwareVersion">The software version of the
        /// device.</param>
        /// <param name="dataContainersCount">The count of datacontainers on
        /// the device.</param>
        /// <param name="volumesCount">The count of volumes on the
        /// device.</param>
        /// <param name="availableLocalStorageInBytes">The amount of free local
        /// storage available on the device in bytes.</param>
        /// <param name="availableTieredStorageInBytes">The amount of free
        /// tiered storage available for the device in bytes.</param>
        /// <param name="deviceLocation">The geo location (applicable only for
        /// cloud appliances) of the device.</param>
        /// <param name="friendlyDeviceSoftwareVersion">The friendly name for
        /// the current version of software on the device.</param>
        /// <param name="eligibilityResult">The eligibility result of the
        /// device, as a failover target device.</param>
        public FailoverTarget(string deviceId = default(string), DeviceStatus? deviceStatus = default(DeviceStatus?), string modelDescription = default(string), string deviceSoftwareVersion = default(string), int? dataContainersCount = default(int?), int? volumesCount = default(int?), long? availableLocalStorageInBytes = default(long?), long? availableTieredStorageInBytes = default(long?), string deviceLocation = default(string), string friendlyDeviceSoftwareVersion = default(string), TargetEligibilityResult eligibilityResult = default(TargetEligibilityResult))
        {
            DeviceId = deviceId;
            DeviceStatus = deviceStatus;
            ModelDescription = modelDescription;
            DeviceSoftwareVersion = deviceSoftwareVersion;
            DataContainersCount = dataContainersCount;
            VolumesCount = volumesCount;
            AvailableLocalStorageInBytes = availableLocalStorageInBytes;
            AvailableTieredStorageInBytes = availableTieredStorageInBytes;
            DeviceLocation = deviceLocation;
            FriendlyDeviceSoftwareVersion = friendlyDeviceSoftwareVersion;
            EligibilityResult = eligibilityResult;
        }

        /// <summary>
        /// Gets or sets the path ID of the device.
        /// </summary>
        [JsonProperty(PropertyName = "deviceId")]
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the status of the device. Possible values include:
        /// 'Unknown', 'Online', 'Offline', 'Deactivated', 'RequiresAttention',
        /// 'MaintenanceMode', 'Creating', 'Provisioning', 'Deactivating',
        /// 'Deleted', 'ReadyToSetup'
        /// </summary>
        [JsonProperty(PropertyName = "deviceStatus")]
        public DeviceStatus? DeviceStatus { get; set; }

        /// <summary>
        /// Gets or sets the model number of the device.
        /// </summary>
        [JsonProperty(PropertyName = "modelDescription")]
        public string ModelDescription { get; set; }

        /// <summary>
        /// Gets or sets the software version of the device.
        /// </summary>
        [JsonProperty(PropertyName = "deviceSoftwareVersion")]
        public string DeviceSoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the count of datacontainers on the device.
        /// </summary>
        [JsonProperty(PropertyName = "dataContainersCount")]
        public int? DataContainersCount { get; set; }

        /// <summary>
        /// Gets or sets the count of volumes on the device.
        /// </summary>
        [JsonProperty(PropertyName = "volumesCount")]
        public int? VolumesCount { get; set; }

        /// <summary>
        /// Gets or sets the amount of free local storage available on the
        /// device in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "availableLocalStorageInBytes")]
        public long? AvailableLocalStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the amount of free tiered storage available for the
        /// device in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "availableTieredStorageInBytes")]
        public long? AvailableTieredStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the geo location (applicable only for cloud
        /// appliances) of the device.
        /// </summary>
        [JsonProperty(PropertyName = "deviceLocation")]
        public string DeviceLocation { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the current version of software
        /// on the device.
        /// </summary>
        [JsonProperty(PropertyName = "friendlyDeviceSoftwareVersion")]
        public string FriendlyDeviceSoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the eligibility result of the device, as a failover
        /// target device.
        /// </summary>
        [JsonProperty(PropertyName = "eligibilityResult")]
        public TargetEligibilityResult EligibilityResult { get; set; }

    }
}

