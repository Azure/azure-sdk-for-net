
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The public key.
    /// </summary>
    public partial class PublicKey
    {
        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        public PublicKey() { }

        /// <summary>
        /// Initializes a new instance of the PublicKey class.
        /// </summary>
        /// <param name="key">The key.</param>
        public PublicKey(string key)
        {
            Key = key;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Key == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Key");
            }
        }
    }
}

