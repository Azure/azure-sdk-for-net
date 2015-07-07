namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class ConnectionResetSharedKeyPropertiesFormat
    {
        /// <summary>
        /// The virtual network connection reset shared key length
        /// </summary>
        [JsonProperty(PropertyName = "keyLength")]
        public long? KeyLength { get; set; }

    }
}
