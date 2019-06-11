
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The web proxy settings on the device.
    /// </summary>
    public partial class WebproxySettings
    {
        /// <summary>
        /// Initializes a new instance of the WebproxySettings class.
        /// </summary>
        public WebproxySettings() { }

        /// <summary>
        /// Initializes a new instance of the WebproxySettings class.
        /// </summary>
        /// <param name="authentication">The authentication type. Possible
        /// values include: 'Invalid', 'None', 'Basic', 'NTLM'</param>
        /// <param name="username">The webproxy username.</param>
        /// <param name="connectionUri">The connection URI.</param>
        public WebproxySettings(AuthenticationType authentication, string username, string connectionUri = default(string))
        {
            ConnectionUri = connectionUri;
            Authentication = authentication;
            Username = username;
        }

        /// <summary>
        /// Gets or sets the connection URI.
        /// </summary>
        [JsonProperty(PropertyName = "connectionUri")]
        public string ConnectionUri { get; set; }

        /// <summary>
        /// Gets or sets the authentication type. Possible values include:
        /// 'Invalid', 'None', 'Basic', 'NTLM'
        /// </summary>
        [JsonProperty(PropertyName = "authentication")]
        public AuthenticationType Authentication { get; set; }

        /// <summary>
        /// Gets or sets the webproxy username.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Username == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Username");
            }
        }
    }
}

