
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Profile properties required for profile update.
    /// </summary>
    public partial class ProfileUpdateParameters : Microsoft.Rest.Azure.IResource
    {
        /// <summary>
        /// Initializes a new instance of the ProfileUpdateParameters class.
        /// </summary>
        public ProfileUpdateParameters() { }

        /// <summary>
        /// Initializes a new instance of the ProfileUpdateParameters class.
        /// </summary>
        /// <param name="tags">Profile tags</param>
        public ProfileUpdateParameters(System.Collections.Generic.IDictionary<string, string> tags)
        {
            Tags = tags;
        }

        /// <summary>
        /// Gets or sets profile tags
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "tags")]
        public System.Collections.Generic.IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Tags == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Tags");
            }
        }
    }
}
