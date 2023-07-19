
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
    /// Represents the patch request for the security settings of a device.
    /// </summary>
    [JsonTransformation]
    public partial class SecuritySettingsPatch
    {
        /// <summary>
        /// Initializes a new instance of the SecuritySettingsPatch class.
        /// </summary>
        public SecuritySettingsPatch() { }

        /// <summary>
        /// Initializes a new instance of the SecuritySettingsPatch class.
        /// </summary>
        /// <param name="remoteManagementSettings">The remote management
        /// settings.</param>
        /// <param name="deviceAdminPassword">The device administrator
        /// password.</param>
        /// <param name="snapshotPassword">The snapshot manager
        /// password.</param>
        /// <param name="chapSettings">The device CHAP and reverse-CHAP
        /// settings.</param>
        /// <param name="cloudApplianceSettings">The cloud appliance
        /// settings.</param>
        public SecuritySettingsPatch(RemoteManagementSettingsPatch remoteManagementSettings = default(RemoteManagementSettingsPatch), AsymmetricEncryptedSecret deviceAdminPassword = default(AsymmetricEncryptedSecret), AsymmetricEncryptedSecret snapshotPassword = default(AsymmetricEncryptedSecret), ChapSettings chapSettings = default(ChapSettings), CloudApplianceSettings cloudApplianceSettings = default(CloudApplianceSettings))
        {
            RemoteManagementSettings = remoteManagementSettings;
            DeviceAdminPassword = deviceAdminPassword;
            SnapshotPassword = snapshotPassword;
            ChapSettings = chapSettings;
            CloudApplianceSettings = cloudApplianceSettings;
        }

        /// <summary>
        /// Gets or sets the remote management settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.remoteManagementSettings")]
        public RemoteManagementSettingsPatch RemoteManagementSettings { get; set; }

        /// <summary>
        /// Gets or sets the device administrator password.
        /// </summary>
        [JsonProperty(PropertyName = "properties.deviceAdminPassword")]
        public AsymmetricEncryptedSecret DeviceAdminPassword { get; set; }

        /// <summary>
        /// Gets or sets the snapshot manager password.
        /// </summary>
        [JsonProperty(PropertyName = "properties.snapshotPassword")]
        public AsymmetricEncryptedSecret SnapshotPassword { get; set; }

        /// <summary>
        /// Gets or sets the device CHAP and reverse-CHAP settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.chapSettings")]
        public ChapSettings ChapSettings { get; set; }

        /// <summary>
        /// Gets or sets the cloud appliance settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.cloudApplianceSettings")]
        public CloudApplianceSettings CloudApplianceSettings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (RemoteManagementSettings != null)
            {
                RemoteManagementSettings.Validate();
            }
            if (DeviceAdminPassword != null)
            {
                DeviceAdminPassword.Validate();
            }
            if (SnapshotPassword != null)
            {
                SnapshotPassword.Validate();
            }
            if (ChapSettings != null)
            {
                ChapSettings.Validate();
            }
            if (CloudApplianceSettings != null)
            {
                CloudApplianceSettings.Validate();
            }
        }
    }
}

