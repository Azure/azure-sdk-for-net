
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ServiceBusAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the ServiceBusAuthentication class.
        /// </summary>
        public ServiceBusAuthentication() { }

        /// <summary>
        /// Initializes a new instance of the ServiceBusAuthentication class.
        /// </summary>
        public ServiceBusAuthentication(string sasKey = default(string), string sasKeyName = default(string), ServiceBusAuthenticationType? type = default(ServiceBusAuthenticationType?))
        {
            SasKey = sasKey;
            SasKeyName = sasKeyName;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the SAS key.
        /// </summary>
        [JsonProperty(PropertyName = "sasKey")]
        public string SasKey { get; set; }

        /// <summary>
        /// Gets or sets the SAS key name.
        /// </summary>
        [JsonProperty(PropertyName = "sasKeyName")]
        public string SasKeyName { get; set; }

        /// <summary>
        /// Gets or sets the authentication type. Possible values include:
        /// 'NotSpecified', 'SharedAccessKey'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public ServiceBusAuthenticationType? Type { get; set; }

    }
}
