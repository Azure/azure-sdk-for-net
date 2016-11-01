
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Parameters required for endpoint load.
    /// </summary>
    public partial class LoadParameters
    {
        /// <summary>
        /// Initializes a new instance of the LoadParameters class.
        /// </summary>
        public LoadParameters() { }

        /// <summary>
        /// Initializes a new instance of the LoadParameters class.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be loaded.
        /// Should describe a file path.</param>
        public LoadParameters(System.Collections.Generic.IList<string> contentPaths)
        {
            ContentPaths = contentPaths;
        }

        /// <summary>
        /// Gets or sets the path to the content to be loaded. Should describe
        /// a file path.
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
