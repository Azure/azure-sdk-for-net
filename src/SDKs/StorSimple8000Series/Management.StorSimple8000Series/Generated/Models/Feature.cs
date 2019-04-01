
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The feature.
    /// </summary>
    public partial class Feature
    {
        /// <summary>
        /// Initializes a new instance of the Feature class.
        /// </summary>
        public Feature() { }

        /// <summary>
        /// Initializes a new instance of the Feature class.
        /// </summary>
        /// <param name="name">The name of the feature.</param>
        /// <param name="status">The feature support status. Possible values
        /// include: 'NotAvailable', 'UnsupportedDeviceVersion',
        /// 'Supported'</param>
        public Feature(string name, FeatureSupportStatus status)
        {
            Name = name;
            Status = status;
        }

        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the feature support status. Possible values include:
        /// 'NotAvailable', 'UnsupportedDeviceVersion', 'Supported'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public FeatureSupportStatus Status { get; set; }

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
        }
    }
}

