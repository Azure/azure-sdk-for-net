
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The Challenge-Handshake Authentication Protocol (CHAP) settings.
    /// </summary>
    public partial class ChapSettings
    {
        /// <summary>
        /// Initializes a new instance of the ChapSettings class.
        /// </summary>
        public ChapSettings() { }

        /// <summary>
        /// Initializes a new instance of the ChapSettings class.
        /// </summary>
        /// <param name="initiatorUser">The CHAP initiator user.</param>
        /// <param name="initiatorSecret">The CHAP initiator secret.</param>
        /// <param name="targetUser">The CHAP target user.</param>
        /// <param name="targetSecret">The target secret.</param>
        public ChapSettings(string initiatorUser = default(string), AsymmetricEncryptedSecret initiatorSecret = default(AsymmetricEncryptedSecret), string targetUser = default(string), AsymmetricEncryptedSecret targetSecret = default(AsymmetricEncryptedSecret))
        {
            InitiatorUser = initiatorUser;
            InitiatorSecret = initiatorSecret;
            TargetUser = targetUser;
            TargetSecret = targetSecret;
        }

        /// <summary>
        /// Gets or sets the CHAP initiator user.
        /// </summary>
        [JsonProperty(PropertyName = "initiatorUser")]
        public string InitiatorUser { get; set; }

        /// <summary>
        /// Gets or sets the CHAP initiator secret.
        /// </summary>
        [JsonProperty(PropertyName = "initiatorSecret")]
        public AsymmetricEncryptedSecret InitiatorSecret { get; set; }

        /// <summary>
        /// Gets or sets the CHAP target user.
        /// </summary>
        [JsonProperty(PropertyName = "targetUser")]
        public string TargetUser { get; set; }

        /// <summary>
        /// Gets or sets the target secret.
        /// </summary>
        [JsonProperty(PropertyName = "targetSecret")]
        public AsymmetricEncryptedSecret TargetSecret { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (InitiatorSecret != null)
            {
                InitiatorSecret.Validate();
            }
            if (TargetSecret != null)
            {
                TargetSecret.Validate();
            }
        }
    }
}

