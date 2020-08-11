
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The virtual machine image.
    /// </summary>
    public partial class VmImage
    {
        /// <summary>
        /// Initializes a new instance of the VmImage class.
        /// </summary>
        public VmImage() { }

        /// <summary>
        /// Initializes a new instance of the VmImage class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="version">The version.</param>
        /// <param name="offer">The offer.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="sku">The SKU.</param>
        public VmImage(string name, string version, string offer, string publisher, string sku)
        {
            Name = name;
            Version = version;
            Offer = offer;
            Publisher = publisher;
            Sku = sku;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the offer.
        /// </summary>
        [JsonProperty(PropertyName = "offer")]
        public string Offer { get; set; }

        /// <summary>
        /// Gets or sets the publisher.
        /// </summary>
        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Version == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Version");
            }
            if (Offer == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Offer");
            }
            if (Publisher == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Publisher");
            }
            if (Sku == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Sku");
            }
        }
    }
}

