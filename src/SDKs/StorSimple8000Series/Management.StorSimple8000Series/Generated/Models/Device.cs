
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
    /// The StorSimple device.
    /// </summary>
    [JsonTransformation]
    public partial class Device : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        public Device() { }

        /// <summary>
        /// Initializes a new instance of the Device class.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the device.</param>
        /// <param name="activationTime">The UTC time at which the device was
        /// activated</param>
        /// <param name="culture">The language culture setting on the device.
        /// For eg: "en-US"</param>
        /// <param name="deviceDescription">The device description.</param>
        /// <param name="deviceSoftwareVersion">The version number of the
        /// software running on the device.</param>
        /// <param name="deviceConfigurationStatus">The current configuration
        /// status of the device. Possible values include: 'Complete',
        /// 'Pending'</param>
        /// <param name="targetIqn">The target IQN.</param>
        /// <param name="modelDescription">The device model.</param>
        /// <param name="status">The current status of the device. Possible
        /// values include: 'Unknown', 'Online', 'Offline', 'Deactivated',
        /// 'RequiresAttention', 'MaintenanceMode', 'Creating', 'Provisioning',
        /// 'Deactivating', 'Deleted', 'ReadyToSetup'</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="deviceType">The type of the device. Possible values
        /// include: 'Invalid', 'Series8000VirtualAppliance',
        /// 'Series8000PhysicalAppliance'</param>
        /// <param name="activeController">The identifier of the active
        /// controller of the device. Possible values include: 'Unknown',
        /// 'None', 'Controller0', 'Controller1'</param>
        /// <param name="friendlySoftwareVersion">The device friendly software
        /// version.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        /// <param name="friendlySoftwareName">The friendly name of the
        /// software running on the device.</param>
        /// <param name="availableLocalStorageInBytes">The storage in bytes
        /// that is available locally on the device.</param>
        /// <param name="availableTieredStorageInBytes">The storage in bytes
        /// that is available on the device for tiered volumes.</param>
        /// <param name="provisionedTieredStorageInBytes">The storage in bytes
        /// that has been provisioned on the device for tiered volumes.</param>
        /// <param name="provisionedLocalStorageInBytes">The storage in bytes
        /// used for locally pinned volumes on the device (including additional
        /// local reservation).</param>
        /// <param name="provisionedVolumeSizeInBytes">Total capacity in bytes
        /// of tiered and locally pinned volumes on the device</param>
        /// <param name="usingStorageInBytes">The storage in bytes that is
        /// currently being used on the device, including both local and
        /// cloud.</param>
        /// <param name="totalTieredStorageInBytes">The total tiered storage
        /// available on the device in bytes.</param>
        /// <param name="agentGroupVersion">The device agent group
        /// version.</param>
        /// <param name="networkInterfaceCardCount">The number of network
        /// interface cards</param>
        /// <param name="deviceLocation">The location of the virtual
        /// appliance.</param>
        /// <param name="virtualMachineApiType">The virtual machine API type.
        /// Possible values include: 'Classic', 'Arm'</param>
        /// <param name="details">The additional device details regarding the
        /// end point count and volume container count.</param>
        /// <param name="rolloverDetails">The additional device details for the
        /// service data encryption key rollover.</param>
        public Device(string friendlyName, System.DateTime activationTime, string culture, string deviceDescription, string deviceSoftwareVersion, DeviceConfigurationStatus deviceConfigurationStatus, string targetIqn, string modelDescription, DeviceStatus status, string serialNumber, DeviceType deviceType, ControllerId activeController, string friendlySoftwareVersion, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?), string friendlySoftwareName = default(string), long? availableLocalStorageInBytes = default(long?), long? availableTieredStorageInBytes = default(long?), long? provisionedTieredStorageInBytes = default(long?), long? provisionedLocalStorageInBytes = default(long?), long? provisionedVolumeSizeInBytes = default(long?), long? usingStorageInBytes = default(long?), long? totalTieredStorageInBytes = default(long?), int? agentGroupVersion = default(int?), int? networkInterfaceCardCount = default(int?), string deviceLocation = default(string), VirtualMachineApiType? virtualMachineApiType = default(VirtualMachineApiType?), DeviceDetails details = default(DeviceDetails), DeviceRolloverDetails rolloverDetails = default(DeviceRolloverDetails))
            : base(id, name, type, kind)
        {
            FriendlyName = friendlyName;
            ActivationTime = activationTime;
            Culture = culture;
            DeviceDescription = deviceDescription;
            DeviceSoftwareVersion = deviceSoftwareVersion;
            FriendlySoftwareName = friendlySoftwareName;
            DeviceConfigurationStatus = deviceConfigurationStatus;
            TargetIqn = targetIqn;
            ModelDescription = modelDescription;
            Status = status;
            SerialNumber = serialNumber;
            DeviceType = deviceType;
            ActiveController = activeController;
            FriendlySoftwareVersion = friendlySoftwareVersion;
            AvailableLocalStorageInBytes = availableLocalStorageInBytes;
            AvailableTieredStorageInBytes = availableTieredStorageInBytes;
            ProvisionedTieredStorageInBytes = provisionedTieredStorageInBytes;
            ProvisionedLocalStorageInBytes = provisionedLocalStorageInBytes;
            ProvisionedVolumeSizeInBytes = provisionedVolumeSizeInBytes;
            UsingStorageInBytes = usingStorageInBytes;
            TotalTieredStorageInBytes = totalTieredStorageInBytes;
            AgentGroupVersion = agentGroupVersion;
            NetworkInterfaceCardCount = networkInterfaceCardCount;
            DeviceLocation = deviceLocation;
            VirtualMachineApiType = virtualMachineApiType;
            Details = details;
            RolloverDetails = rolloverDetails;
        }

        /// <summary>
        /// Gets or sets the friendly name of the device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the UTC time at which the device was activated
        /// </summary>
        [JsonProperty(PropertyName = "properties.activationTime")]
        public System.DateTime ActivationTime { get; set; }

        /// <summary>
        /// Gets or sets the language culture setting on the device. For eg:
        /// "en-US"
        /// </summary>
        [JsonProperty(PropertyName = "properties.culture")]
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the device description.
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceDescription")]
        public string DeviceDescription { get; set; }

        /// <summary>
        /// Gets or sets the version number of the software running on the
        /// device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceSoftwareVersion")]
        public string DeviceSoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the software running on the
        /// device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.friendlySoftwareName")]
        public string FriendlySoftwareName { get; set; }

        /// <summary>
        /// Gets or sets the current configuration status of the device.
        /// Possible values include: 'Complete', 'Pending'
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceConfigurationStatus")]
        public DeviceConfigurationStatus DeviceConfigurationStatus { get; set; }

        /// <summary>
        /// Gets or sets the target IQN.
        /// </summary>
        [JsonProperty(PropertyName = "properties.targetIqn")]
        public string TargetIqn { get; set; }

        /// <summary>
        /// Gets or sets the device model.
        /// </summary>
        [JsonProperty(PropertyName = "properties.modelDescription")]
        public string ModelDescription { get; set; }

        /// <summary>
        /// Gets or sets the current status of the device. Possible values
        /// include: 'Unknown', 'Online', 'Offline', 'Deactivated',
        /// 'RequiresAttention', 'MaintenanceMode', 'Creating', 'Provisioning',
        /// 'Deactivating', 'Deleted', 'ReadyToSetup'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public DeviceStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        [JsonProperty(PropertyName = "properties.serialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of the device. Possible values include:
        /// 'Invalid', 'Series8000VirtualAppliance',
        /// 'Series8000PhysicalAppliance'
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceType")]
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the active controller of the device.
        /// Possible values include: 'Unknown', 'None', 'Controller0',
        /// 'Controller1'
        /// </summary>
        [JsonProperty(PropertyName = "properties.activeController")]
        public ControllerId ActiveController { get; set; }

        /// <summary>
        /// Gets or sets the device friendly software version.
        /// </summary>
        [JsonProperty(PropertyName = "properties.friendlySoftwareVersion")]
        public string FriendlySoftwareVersion { get; set; }

        /// <summary>
        /// Gets or sets the storage in bytes that is available locally on the
        /// device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.availableLocalStorageInBytes")]
        public long? AvailableLocalStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the storage in bytes that is available on the device
        /// for tiered volumes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.availableTieredStorageInBytes")]
        public long? AvailableTieredStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the storage in bytes that has been provisioned on the
        /// device for tiered volumes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisionedTieredStorageInBytes")]
        public long? ProvisionedTieredStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the storage in bytes used for locally pinned volumes
        /// on the device (including additional local reservation).
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisionedLocalStorageInBytes")]
        public long? ProvisionedLocalStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets total capacity in bytes of tiered and locally pinned
        /// volumes on the device
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisionedVolumeSizeInBytes")]
        public long? ProvisionedVolumeSizeInBytes { get; set; }

        /// <summary>
        /// Gets or sets the storage in bytes that is currently being used on
        /// the device, including both local and cloud.
        /// </summary>
        [JsonProperty(PropertyName = "properties.usingStorageInBytes")]
        public long? UsingStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the total tiered storage available on the device in
        /// bytes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.totalTieredStorageInBytes")]
        public long? TotalTieredStorageInBytes { get; set; }

        /// <summary>
        /// Gets or sets the device agent group version.
        /// </summary>
        [JsonProperty(PropertyName = "properties.agentGroupVersion")]
        public int? AgentGroupVersion { get; set; }

        /// <summary>
        /// Gets or sets the number of network interface cards
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkInterfaceCardCount")]
        public int? NetworkInterfaceCardCount { get; set; }

        /// <summary>
        /// Gets or sets the location of the virtual appliance.
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceLocation")]
        public string DeviceLocation { get; set; }

        /// <summary>
        /// Gets the virtual machine API type. Possible values include:
        /// 'Classic', 'Arm'
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualMachineApiType")]
        public VirtualMachineApiType? VirtualMachineApiType { get; protected set; }

        /// <summary>
        /// Gets or sets the additional device details regarding the end point
        /// count and volume container count.
        /// </summary>
        [JsonProperty(PropertyName = "properties.details")]
        public DeviceDetails Details { get; set; }

        /// <summary>
        /// Gets or sets the additional device details for the service data
        /// encryption key rollover.
        /// </summary>
        [JsonProperty(PropertyName = "properties.rolloverDetails")]
        public DeviceRolloverDetails RolloverDetails { get; set; }

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
            if (Culture == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Culture");
            }
            if (DeviceDescription == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DeviceDescription");
            }
            if (DeviceSoftwareVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DeviceSoftwareVersion");
            }
            if (TargetIqn == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetIqn");
            }
            if (ModelDescription == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ModelDescription");
            }
            if (SerialNumber == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SerialNumber");
            }
            if (FriendlySoftwareVersion == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FriendlySoftwareVersion");
            }
        }
    }
}

