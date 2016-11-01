
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// Geo filter of a CDN endpoint.
    /// </summary>
    public partial class GeoFilter
    {
        /// <summary>
        /// Initializes a new instance of the GeoFilter class.
        /// </summary>
        public GeoFilter() { }

        /// <summary>
        /// Initializes a new instance of the GeoFilter class.
        /// </summary>
        /// <param name="relativePath">Relative path applicable to geo filter.
        /// (e.g. '/mypictures', '/mypicture/kitty.jpg', and etc.)</param>
        /// <param name="action">Action of the geo filter. Possible values
        /// include: 'Block', 'Allow'</param>
        /// <param name="countryCodes">Two letter country codes of the geo
        /// filter. (e.g. AU, MX, and etc.)</param>
        public GeoFilter(string relativePath, GeoFilterActions action, System.Collections.Generic.IList<string> countryCodes)
        {
            RelativePath = relativePath;
            Action = action;
            CountryCodes = countryCodes;
        }

        /// <summary>
        /// Gets or sets relative path applicable to geo filter. (e.g.
        /// '/mypictures', '/mypicture/kitty.jpg', and etc.)
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "relativePath")]
        public string RelativePath { get; set; }

        /// <summary>
        /// Gets or sets action of the geo filter. Possible values include:
        /// 'Block', 'Allow'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "action")]
        public GeoFilterActions Action { get; set; }

        /// <summary>
        /// Gets or sets two letter country codes of the geo filter. (e.g. AU,
        /// MX, and etc.)
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "countryCodes")]
        public System.Collections.Generic.IList<string> CountryCodes { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (RelativePath == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "RelativePath");
            }
            if (CountryCodes == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "CountryCodes");
            }
        }
    }
}
