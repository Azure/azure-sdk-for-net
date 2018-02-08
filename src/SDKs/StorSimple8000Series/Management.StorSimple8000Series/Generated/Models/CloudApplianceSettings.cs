
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The cloud appliance settings.
    /// </summary>
    public partial class CloudApplianceSettings
    {
        /// <summary>
        /// Initializes a new instance of the CloudApplianceSettings class.
        /// </summary>
        public CloudApplianceSettings() { }

        /// <summary>
        /// Initializes a new instance of the CloudApplianceSettings class.
        /// </summary>
        /// <param name="serviceDataEncryptionKey">The service data encryption
        /// key (encrypted with DAK).</param>
        /// <param name="channelIntegrityKey">The channel integrity key
        /// (encrypted with DAK).</param>
        public CloudApplianceSettings(AsymmetricEncryptedSecret serviceDataEncryptionKey = default(AsymmetricEncryptedSecret), AsymmetricEncryptedSecret channelIntegrityKey = default(AsymmetricEncryptedSecret))
        {
            ServiceDataEncryptionKey = serviceDataEncryptionKey;
            ChannelIntegrityKey = channelIntegrityKey;
        }

        /// <summary>
        /// Gets or sets the service data encryption key (encrypted with DAK).
        /// </summary>
        [JsonProperty(PropertyName = "serviceDataEncryptionKey")]
        public AsymmetricEncryptedSecret ServiceDataEncryptionKey { get; set; }

        /// <summary>
        /// Gets or sets the channel integrity key (encrypted with DAK).
        /// </summary>
        [JsonProperty(PropertyName = "channelIntegrityKey")]
        public AsymmetricEncryptedSecret ChannelIntegrityKey { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ServiceDataEncryptionKey != null)
            {
                ServiceDataEncryptionKey.Validate();
            }
            if (ChannelIntegrityKey != null)
            {
                ChannelIntegrityKey.Validate();
            }
        }
    }
}

