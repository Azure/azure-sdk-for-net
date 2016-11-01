
namespace Microsoft.Azure.Management.Cdn.Models
{
    using System.Linq;

    /// <summary>
    /// SSO URI required to login to third party web portal.
    /// </summary>
    public partial class SsoUri
    {
        /// <summary>
        /// Initializes a new instance of the SsoUri class.
        /// </summary>
        public SsoUri() { }

        /// <summary>
        /// Initializes a new instance of the SsoUri class.
        /// </summary>
        /// <param name="ssoUriValue">The URI used to login to third party web
        /// portal.</param>
        public SsoUri(string ssoUriValue = default(string))
        {
            SsoUriValue = ssoUriValue;
        }

        /// <summary>
        /// Gets or sets the URI used to login to third party web portal.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "ssoUriValue")]
        public string SsoUriValue { get; set; }

    }
}
