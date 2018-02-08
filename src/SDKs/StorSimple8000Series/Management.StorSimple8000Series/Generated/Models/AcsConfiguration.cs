
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The ACS configuration.
    /// </summary>
    public partial class AcsConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the AcsConfiguration class.
        /// </summary>
        public AcsConfiguration() { }

        /// <summary>
        /// Initializes a new instance of the AcsConfiguration class.
        /// </summary>
        /// <param name="namespaceProperty">The namespace.</param>
        /// <param name="realm">The realm.</param>
        /// <param name="serviceUrl">The service URL.</param>
        public AcsConfiguration(string namespaceProperty, string realm, string serviceUrl)
        {
            NamespaceProperty = namespaceProperty;
            Realm = realm;
            ServiceUrl = serviceUrl;
        }

        /// <summary>
        /// Gets or sets the namespace.
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; set; }

        /// <summary>
        /// Gets or sets the realm.
        /// </summary>
        [JsonProperty(PropertyName = "realm")]
        public string Realm { get; set; }

        /// <summary>
        /// Gets or sets the service URL.
        /// </summary>
        [JsonProperty(PropertyName = "serviceUrl")]
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NamespaceProperty == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NamespaceProperty");
            }
            if (Realm == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Realm");
            }
            if (ServiceUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ServiceUrl");
            }
        }
    }
}

