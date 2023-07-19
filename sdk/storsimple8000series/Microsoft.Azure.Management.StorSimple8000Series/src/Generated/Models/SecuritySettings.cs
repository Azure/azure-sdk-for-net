
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
    /// The security settings of a device.
    /// </summary>
    [JsonTransformation]
    public partial class SecuritySettings : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the SecuritySettings class.
        /// </summary>
        public SecuritySettings() { }

        /// <summary>
        /// Initializes a new instance of the SecuritySettings class.
        /// </summary>
        /// <param name="remoteManagementSettings">The settings for remote
        /// management of a device.</param>
        /// <param name="chapSettings">The Challenge-Handshake Authentication
        /// Protocol (CHAP) settings.</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public SecuritySettings(RemoteManagementSettings remoteManagementSettings, ChapSettings chapSettings, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
            : base(id, name, type, kind)
        {
            RemoteManagementSettings = remoteManagementSettings;
            ChapSettings = chapSettings;
        }

        /// <summary>
        /// Gets or sets the settings for remote management of a device.
        /// </summary>
        [JsonProperty(PropertyName = "properties.remoteManagementSettings")]
        public RemoteManagementSettings RemoteManagementSettings { get; set; }

        /// <summary>
        /// Gets or sets the Challenge-Handshake Authentication Protocol (CHAP)
        /// settings.
        /// </summary>
        [JsonProperty(PropertyName = "properties.chapSettings")]
        public ChapSettings ChapSettings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (RemoteManagementSettings == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RemoteManagementSettings");
            }
            if (ChapSettings == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ChapSettings");
            }
            if (RemoteManagementSettings != null)
            {
                RemoteManagementSettings.Validate();
            }
            if (ChapSettings != null)
            {
                ChapSettings.Validate();
            }
        }
    }
}

