
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// The customDomain JSON object required for custom domain creation or
    /// update.
    /// </summary>
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class CustomDomainParameters
    {
        /// <summary>
        /// Initializes a new instance of the CustomDomainParameters class.
        /// </summary>
        public CustomDomainParameters() { }

        /// <summary>
        /// Initializes a new instance of the CustomDomainParameters class.
        /// </summary>
        /// <param name="hostName">The host name of the custom domain. Must be
        /// a domain name.</param>
        public CustomDomainParameters(string hostName)
        {
            HostName = hostName;
        }

        /// <summary>
        /// Gets or sets the host name of the custom domain. Must be a domain
        /// name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "properties.hostName")]
        public string HostName { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (HostName == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "HostName");
            }
        }
    }
}
