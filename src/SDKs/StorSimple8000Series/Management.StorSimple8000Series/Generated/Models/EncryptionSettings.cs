
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
    /// The encryption settings.
    /// </summary>
    [JsonTransformation]
    public partial class EncryptionSettings : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the EncryptionSettings class.
        /// </summary>
        public EncryptionSettings() { }

        /// <summary>
        /// Initializes a new instance of the EncryptionSettings class.
        /// </summary>
        /// <param name="encryptionStatus">The encryption status to indicates
        /// if encryption is enabled or not. Possible values include:
        /// 'Enabled', 'Disabled'</param>
        /// <param name="keyRolloverStatus">The key rollover status to
        /// indicates if key rollover is required or not. If secret's
        /// encryption has been upgraded, then it requires key rollover.
        /// Possible values include: 'Required', 'NotRequired'</param>
        /// <param name="id">The path ID that uniquely identifies the
        /// object.</param>
        /// <param name="name">The name of the object.</param>
        /// <param name="type">The hierarchical type of the object.</param>
        /// <param name="kind">The Kind of the object. Currently only
        /// Series8000 is supported. Possible values include:
        /// 'Series8000'</param>
        public EncryptionSettings(EncryptionStatus encryptionStatus, KeyRolloverStatus keyRolloverStatus, string id = default(string), string name = default(string), string type = default(string), Kind? kind = default(Kind?))
            : base(id, name, type, kind)
        {
            EncryptionStatus = encryptionStatus;
            KeyRolloverStatus = keyRolloverStatus;
        }

        /// <summary>
        /// Gets or sets the encryption status to indicates if encryption is
        /// enabled or not. Possible values include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.encryptionStatus")]
        public EncryptionStatus EncryptionStatus { get; set; }

        /// <summary>
        /// Gets or sets the key rollover status to indicates if key rollover
        /// is required or not. If secret's encryption has been upgraded, then
        /// it requires key rollover. Possible values include: 'Required',
        /// 'NotRequired'
        /// </summary>
        [JsonProperty(PropertyName = "properties.keyRolloverStatus")]
        public KeyRolloverStatus KeyRolloverStatus { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}

