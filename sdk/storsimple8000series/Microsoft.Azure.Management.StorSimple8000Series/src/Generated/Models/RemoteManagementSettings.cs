
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The settings for remote management of a device.
    /// </summary>
    public partial class RemoteManagementSettings
    {
        /// <summary>
        /// Initializes a new instance of the RemoteManagementSettings class.
        /// </summary>
        public RemoteManagementSettings() { }

        /// <summary>
        /// Initializes a new instance of the RemoteManagementSettings class.
        /// </summary>
        /// <param name="remoteManagementMode">The remote management mode.
        /// Possible values include: 'Unknown', 'Disabled', 'HttpsEnabled',
        /// 'HttpsAndHttpEnabled'</param>
        /// <param name="remoteManagementCertificate">The remote management
        /// certificates.</param>
        public RemoteManagementSettings(RemoteManagementModeConfiguration remoteManagementMode, string remoteManagementCertificate = default(string))
        {
            RemoteManagementMode = remoteManagementMode;
            RemoteManagementCertificate = remoteManagementCertificate;
        }

        /// <summary>
        /// Gets or sets the remote management mode. Possible values include:
        /// 'Unknown', 'Disabled', 'HttpsEnabled', 'HttpsAndHttpEnabled'
        /// </summary>
        [JsonProperty(PropertyName = "remoteManagementMode")]
        public RemoteManagementModeConfiguration RemoteManagementMode { get; set; }

        /// <summary>
        /// Gets or sets the remote management certificates.
        /// </summary>
        [JsonProperty(PropertyName = "remoteManagementCertificate")]
        public string RemoteManagementCertificate { get; set; }

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

