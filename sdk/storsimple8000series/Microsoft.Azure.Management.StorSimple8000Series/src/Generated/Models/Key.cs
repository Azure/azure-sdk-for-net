
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The key.
    /// </summary>
    public partial class Key
    {
        /// <summary>
        /// Initializes a new instance of the Key class.
        /// </summary>
        public Key() { }

        /// <summary>
        /// Initializes a new instance of the Key class.
        /// </summary>
        /// <param name="activationKey">The activation key for the
        /// device.</param>
        public Key(string activationKey)
        {
            ActivationKey = activationKey;
        }

        /// <summary>
        /// Gets or sets the activation key for the device.
        /// </summary>
        [JsonProperty(PropertyName = "activationKey")]
        public string ActivationKey { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ActivationKey == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ActivationKey");
            }
        }
    }
}

