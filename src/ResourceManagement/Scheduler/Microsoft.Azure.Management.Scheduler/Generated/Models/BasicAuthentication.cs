
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class BasicAuthentication : HttpAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the BasicAuthentication class.
        /// </summary>
        public BasicAuthentication() { }

        /// <summary>
        /// Initializes a new instance of the BasicAuthentication class.
        /// </summary>
        public BasicAuthentication(HttpAuthenticationType? type = default(HttpAuthenticationType?), string username = default(string), string password = default(string))
            : base(type)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

    }
}
