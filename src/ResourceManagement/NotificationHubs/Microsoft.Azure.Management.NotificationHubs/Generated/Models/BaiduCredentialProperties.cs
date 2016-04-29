
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Description of a NotificationHub BaiduCredential.
    /// </summary>
    public partial class BaiduCredentialProperties
    {
        /// <summary>
        /// Initializes a new instance of the BaiduCredentialProperties class.
        /// </summary>
        public BaiduCredentialProperties() { }

        /// <summary>
        /// Initializes a new instance of the BaiduCredentialProperties class.
        /// </summary>
        public BaiduCredentialProperties(string baiduApiKey = default(string), string baiduEndPoint = default(string), string baiduSecretKey = default(string))
        {
            BaiduApiKey = baiduApiKey;
            BaiduEndPoint = baiduEndPoint;
            BaiduSecretKey = baiduSecretKey;
        }

        /// <summary>
        /// Get or Set Baidu Api Key.
        /// </summary>
        [JsonProperty(PropertyName = "baiduApiKey")]
        public string BaiduApiKey { get; set; }

        /// <summary>
        /// Get or Set Baidu Endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "baiduEndPoint")]
        public string BaiduEndPoint { get; set; }

        /// <summary>
        /// Get or Set Baidu Secret Key
        /// </summary>
        [JsonProperty(PropertyName = "baiduSecretKey")]
        public string BaiduSecretKey { get; set; }

    }
}
