
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The settings for updating remote management mode of the device.
    /// </summary>
    public partial class RemoteManagementSettingsPatch
    {
        /// <summary>
        /// Initializes a new instance of the RemoteManagementSettingsPatch
        /// class.
        /// </summary>
        public RemoteManagementSettingsPatch() { }

        /// <summary>
        /// Initializes a new instance of the RemoteManagementSettingsPatch
        /// class.
        /// </summary>
        /// <param name="remoteManagementMode">The remote management mode.
        /// Possible values include: 'Unknown', 'Disabled', 'HttpsEnabled',
        /// 'HttpsAndHttpEnabled'</param>
        public RemoteManagementSettingsPatch(RemoteManagementModeConfiguration remoteManagementMode)
        {
            RemoteManagementMode = remoteManagementMode;
        }

        /// <summary>
        /// Gets or sets the remote management mode. Possible values include:
        /// 'Unknown', 'Disabled', 'HttpsEnabled', 'HttpsAndHttpEnabled'
        /// </summary>
        [JsonProperty(PropertyName = "remoteManagementMode")]
        public RemoteManagementModeConfiguration RemoteManagementMode { get; set; }

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

