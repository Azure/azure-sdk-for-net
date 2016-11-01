
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Parameters required for endpoint purge.
    /// </summary>
    public partial class PurgeParameters
    {
        /// <summary>
        /// Initializes a new instance of the PurgeParameters class.
        /// </summary>
        public PurgeParameters() { }

        /// <summary>
        /// Initializes a new instance of the PurgeParameters class.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be purged.
        /// Can describe a file path or a wild card directory.</param>
        public PurgeParameters(System.Collections.Generic.IList<string> contentPaths)
        {
            ContentPaths = contentPaths;
        }

        /// <summary>
        /// Gets or sets the path to the content to be purged. Can describe a
        /// file path or a wild card directory.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "contentPaths")]
        public System.Collections.Generic.IList<string> ContentPaths { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ContentPaths == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "ContentPaths");
            }
        }
    }
}
